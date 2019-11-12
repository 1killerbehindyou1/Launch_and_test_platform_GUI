using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.Threading;
using System.IO;

namespace Kucia.sprog.Programmer
{
    /// <summary>
    /// Definiuje sposób resetowania sprzętowego mikrokontrolera
    /// </summary>
    public enum ResetLine { None, DTR, RTS };


    /// <summary>
    /// Klasa programująca
    /// </summary>
    public class Programmer
    {
        private SerialPort sp;

        // Set to default values
        public AVRDevice device = AVRDevices.AtMega32;

        public int defaultDeviceConnectionTimeout = 5000;

        public ResetLine resetLine = ResetLine.DTR;
        public int defaultResetPulseTime = 300;

        public StopBits portStopBits = StopBits.One;
        public string portName = "COM1";
        public Parity portParity = Parity.None;
        public int portBaud = 9600;

        public int bootloaderSize = 256;

        public byte hfuse = 0x00;
        public byte lfuse = 0x00;
        public byte lockb = 0x00;

        // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // //

        public Action OnPortOpen;
        public Action OnConnected;
        public Action OnRecieveHeader;
        public Action OnDisconnected;

        public Action OnStartWritingFlash;
        public Action OnEndWritingFlash;
        public Action OnFlashPageWriteError;
        public Action<int, int> OnFlashPageWriteSuccess;



        // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // //

        #region Serial tools

        private Queue<byte> recievedData = new Queue<byte>();
        void serialPort_DataReceived(object s, SerialDataReceivedEventArgs e)
        {
            byte[] data = new byte[sp.BytesToRead];
            sp.Read(data, 0, data.Length);
            data.ToList().ForEach(b => recievedData.Enqueue(b));
        }

        void WaitFor(char c)
        {
            WaitFor((byte)c);
        }

        void WaitFor(byte c)
        {
            while (true)
            {
                if (recievedData.Count > 0)
                {
                    if (recievedData.Dequeue() == c)
                        return;
                }
                Thread.Sleep(1);
            }
        }

        byte ReadByte()
        {
            while (recievedData.Count == 0) { Thread.Sleep(1); }
            return recievedData.Dequeue();
        }

        void Send(char c)
        {
            Send((byte)c);
        }

        void Send(byte c)
        {
            sp.Write(new byte[] { c }, 0, 1);
        }

        private void ClearBuffer()
        {
            sp.DiscardOutBuffer();
            recievedData.Clear();
        }

        #endregion

        // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // //

        public void Connect()
        {
            // Otwarcie portu
            OpenPort(portName, portBaud, portParity, portStopBits);

            // Reset
            if (resetLine != ResetLine.None)
            {
                DeviceReset();
                ClearBuffer();
            }

            // Połączenie z bootloaderem
            Console.Write("Waiting for a bootloader ...");
            TimeOut.DoWork(delegate { WaitFor('?'); }, defaultDeviceConnectionTimeout);
            Send('s');
            Console.WriteLine("[OK]");
            //Sprawdzanie nagłówka
            TimeOut.DoWork(delegate { WaitFor(0xA0); }, 501); //Identyfikator bootloadera 
            // Na razie programuje tylko atm8
            if ((ReadByte() != 0x32)) throw new Exception("Chip identification failed!"); // Odczyt typu uC
            lfuse = ReadByte(); // Dolne fuse
            hfuse = ReadByte(); // Górne fuse
            lockb = ReadByte(); // Lockbity
            Console.WriteLine("Recieved header. Chip: ATMega32 32kB flash Hfuse:0x{0:X2} Lfuse:0x{1:X2} Lockbis:0x{2:X2}.", hfuse, lfuse, lockb);
        }

        public void Disconnect()
        {
            //Kończenie połączenia
            Send('Q');
            sp.Close();

            if (OnDisconnected != null)
                OnDisconnected();
        }

        public void OpenPort(String portname, int baud, Parity par, StopBits sb)
        {
            sp = new SerialPort(portname, portBaud, portParity, 8, portStopBits);
            sp.Encoding = Encoding.ASCII;
            sp.ReadBufferSize = 128;
            sp.DataReceived += serialPort_DataReceived;
            sp.Open();
            if (OnPortOpen != null)
                OnPortOpen();
        }

        public void DeviceReset()
        {
            switch (this.resetLine)
            {
                case ResetLine.None:
                    Console.WriteLine("No reset pulse send.");
                    return;

                case ResetLine.DTR:
                    Console.WriteLine("Reset device:{0} milisecond pulse send to DTR.", defaultResetPulseTime);
                    sp.DtrEnable = true;
                    Thread.Sleep(defaultResetPulseTime);
                    sp.DtrEnable = false;
                    return;

                case ResetLine.RTS:
                    Console.WriteLine("Reset device:{0} milisecond pulse send to RTS.", defaultResetPulseTime);
                    sp.RtsEnable = true;
                    Thread.Sleep(defaultResetPulseTime);
                    sp.RtsEnable = false;
                    return;

                default: throw new Exception("DeviceReset() resetLine enum unknown!");
            }
        }

        public void WriteFlash(PagesOfCode poc)
        {
            // Czy jest kod do zapisania?
            if ((poc == null) || (poc.PageCount == 0))
            {
                Console.WriteLine("[Warning!] No flash data to write. ");
                return;
            }

            //Pomiar czasu zapisu
            DateTime startT = DateTime.Now;

            Console.WriteLine("  0%                          100%");
            Console.WriteLine("  V                            V");
            Console.Write("  ");
            //For every page

            int lastnum = 0;
            int pagenum = 0;
            //Dla kadej strony
            foreach (PageOfCode page in poc.Pages)
            {
                pagenum++;
                //Jeżeli strona nie istnieje to pomijamy
                if (page != null)
                {
                    //Określamy nr strony w pamięci
                    if (page.number >= ((device.FlashSize - this.bootloaderSize) / device.FlashPageSize))
                    {
                        Console.WriteLine("[Warning!] Chip out of memory. Page {0} cannot be written. Aborting operation.", page.number);
                        break; ; //Nie nadpiszemy bootloadera
                    }

                    //Programujemy
                    WriteFlashPage(page);

                    if (OnFlashPageWriteSuccess != null)
                    {
                        OnFlashPageWriteSuccess(page.number, poc.PageCount);
                    }
                }
                //Obliczenia do wyświetlania paska postępu
                int newnum = (int)((float)30 * (pagenum - 1) / (poc.PageCount - 1));
                for (int i = 0; i < (newnum - lastnum); i++) Console.Write("|");
                lastnum = newnum;
            }


            //Enable rww section
            EnableRRW();

            TimeSpan time = DateTime.Now.Subtract(startT);
            Console.WriteLine("\n Writing time: {0}, {1}s {2}ms.", time.Minutes, time.Seconds, time.Milliseconds);
            Console.WriteLine("\nFlash write operation. [OK]");
        }

        public void WriteFlashPage(PageOfCode page)
        {

            byte crc = 0xFF;

            //Enter flash programming mode
            Send('F');
            ClearBuffer();


            //Send page address
            byte[] address = BitConverter.GetBytes(page.number * device.FlashPageSize);
            Send(address[0]);
            Send(address[1]);
            crc ^= address[0];
            crc ^= address[1];

            //Czeka na znak gotowosci
            TimeOut.DoWork(delegate { WaitFor('>'); }, 1003);

            for (int j = 0; j < device.FlashPageSize; j++)
            {
                Send(page.code[j]);
                crc ^= page.code[j];
            }

            byte crcResp = 0xFF;
            TimeOut.DoWork(delegate { crcResp = ReadByte(); }, 1003);

            // Sprawdzenie sumy kontrolnej
            if (crc != crcResp)
            {
                //Console.WriteLine("CRC ERROR {0:X2} {1:X2}", crc, crcResp);
                if (OnFlashPageWriteError != null)
                    OnFlashPageWriteError();
                Send('X');
                WriteFlashPage(page);
                return;
            }

            // Wszystko ok strona zostaje zapisana
            Send('k');

        }

        public byte ReadEEPROM(UInt16 address)
        {
            TimeOut.DoWork(delegate { WaitFor('>'); }, 101);

            //Enter EEPROM reading mode
            Send('e');
            ClearBuffer();

            //Send address in two bytes
            byte[] ba = BitConverter.GetBytes(address);
            Send(ba[0]);
            Send(ba[1]);

            byte response = 0x00;
            TimeOut.DoWork(delegate { response = ReadByte(); }, 501);
            return response;
        }

        public void WriteEEPROM(UInt16 address, byte data)
        {
            TimeOut.DoWork(delegate { WaitFor('>'); }, 101);
            //Enter EEPROM writing mode
            Send('E');
            ClearBuffer();

            //Send address in two bytes
            byte[] ba = BitConverter.GetBytes(address);
            Send(ba[0]);
            Send(ba[1]);

            //Send data byte
            Send(data);
            Thread.Sleep(5); // Some time for eeprom to finish writing 
        }

        //2DO
        public String ReadFlashPage(UInt16 pageNum)
        {
            string str = "";

            Send('f');
            ClearBuffer();
            //Adress
            byte[] ba = BitConverter.GetBytes((pageNum + 1) * 0xFF);
            Send(ba[0]);
            Send(ba[1]);

            for (int j = 0; j < device.FlashPageSize; j++)
            {
                byte b = 0x00;
                TimeOut.DoWork(delegate { b = ReadByte(); }, 501);
                str += String.Format("{0:X2}", b);
            }
            return str;
        }

        public String ReadFlash(string filename)
        {
            FileStream fs = new FileStream(filename, FileMode.Create, FileAccess.Write);

            string str = "";
            Console.WriteLine("  0%                          100%");
            Console.WriteLine("  V                            V");
            Console.Write("  ");
            int lastnum = 0;
            for (int i = 0; i < device.FlashPages; i++)
            {
                Send('f');
                ClearBuffer();
                //Adress
                byte[] ba = BitConverter.GetBytes((i + 1) * 0xFF);
                Send(ba[0]);
                Send(ba[1]);

                for (int j = 0; j < device.FlashPageSize; j++)
                {
                    byte b = 0x00;
                    TimeOut.DoWork(delegate { b = ReadByte(); }, 501);
                    fs.WriteByte(b);
                    str += String.Format("{0:X2}", b);
                }
                //Console.WriteLine(str);
                int newnum = (int)((float)30 * i / (device.FlashPages - 1));
                for (int k = 0; k < (newnum - lastnum); k++) Console.Write("|");
                lastnum = newnum;
                str = "";

            }
            Console.WriteLine();
            fs.Flush();
            fs.Close();
            return str;
        }

        public void EnableRRW()
        {
            Send('u');
        }

    }
}
