// Sprog Maciej Kucia Kraków 2010
//
// This software is based on MIT Licence
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.IO.Ports;
using System.Threading;
using System.IO;
using Kucia.sprog.Programmer;

namespace SprogNamespace
{
    class Program
    {

        static Programmer prog;

        static void OnDisconnected()
        {
            Console.WriteLine("Disconnected");
        }

        static void OnPortOpen()
        {
            Console.WriteLine(String.Format("Port {0} open [baud rate:{1}, parity:{2}, data bits:{3}, stop bits:{4}]", prog.portName, prog.portBaud, prog.portParity, 8, prog.portStopBits));
        }



        static void PrintInfo()
        {
            Console.WriteLine("======================================================================");
            Console.WriteLine("Usage: sprog [options]");
            Console.WriteLine("______________________________________________________________________");
            Console.WriteLine(" Options: ");
            Console.WriteLine("  -port:string         Serial port name (default '{0}')", prog.portName);
            Console.WriteLine("  -flash:string        File name for flash upload (dont use to skip)");
            Console.WriteLine("  -flashread:string    File name for flash downoad (dont use to skip)");
            Console.WriteLine("  -terminal            Start in terminal mode");
            Console.WriteLine("______________________________________________________________________");
            Console.WriteLine(" Extended options (Do not change if using unmodified sprogATM8)");
            Console.WriteLine("  -baud:int            Serial port baud rate (default {0})", prog.portBaud);
            Console.WriteLine("  -stopbits:1,1.5,2    Serial port stop bits (default {0})", prog.portStopBits);
            Console.WriteLine("  -bootsize:int        Size of device bootloader (default {0})", prog.bootloaderSize);
            Console.WriteLine("______________________________________________________________________");
            Console.WriteLine(" Hardware specific options");
            Console.WriteLine("  -timeout:int         Maximum device prompt time (default {0})", prog.defaultDeviceConnectionTimeout);
            Console.WriteLine("  -reset:none,dtr,rts  Device reset signal (default '{0}')", prog.resetLine);
            Console.WriteLine("  -resettime:int       Length of reset pulse (default {0})", prog.defaultResetPulseTime);
            Console.WriteLine("______________________________________________________________________");
            Console.WriteLine(" THIS VERSION IS ONLY FOR ATMEGA32 DEVICE!");
            Console.WriteLine(" sprog Serial Programmer Maciej Kucia Kraków 2010 " + Assembly.GetExecutingAssembly().GetName().Version.ToString());
            Console.WriteLine("======================================================================");
        }

        static int Main(string[] args)
        {
            //Dzięki osobnej klasie można łatwo zbudować gui dla programatora
            prog = new Programmer();
            prog.OnDisconnected += OnDisconnected;
            prog.OnPortOpen += OnPortOpen;


            bool TerminalMode = false;

            Console.Title = "sprog";
            DateTime startT = DateTime.Now;

            Console.WriteLine("sprog Maciej Kucia 2010 " + Assembly.GetExecutingAssembly().GetName().Version.ToString());
            Console.WriteLine("Dir:" + Environment.CurrentDirectory);

            string FlashFileName = "";
            string FlashRFileName = "";

            if (args.Length == 0)
            {
                PrintInfo();
                return -1;
            }

            #region Args Processing
            // Przetwarzanie argumentów
            foreach (string arg in args)
            {
                arg.ToLower();

                if (arg == "-?")
                {
                    PrintInfo();
                    if (args.Length == 1)
                        return 0;
                    else
                        return -1;
                }

                string[] argg = arg.Split(':');

                switch (argg[0])
                {
                    case "-t":
                    case "-terminal":
                        TerminalMode = true;
                        break;

                    case "-p":
                    case "-port":
                        prog.portName = argg[1];
                        break;

                    case "-f":
                    case "-flash":
                        FlashFileName = argg[1];
                        break;

                    case "-fr":
                    case "-flashread":
                        FlashRFileName = argg[1];
                        break;

                    //Hidden
                    case "-d":
                    case "-device":
                        switch (argg[1])
                        {
                            //case "m8":
                            //    prog.device = AVRDevices.AtMega8;
                            //    break;

                            case "m32":
                                prog.device = AVRDevices.AtMega32;
                                // tu jakiś error, brak wsparcia
                                break;

                            default:
                                throw new Exception("Error! Device:" + argg[1] + " unrecognized.");
                        }
                        break;

                    //case "-fast":
                    //    skipCompare = false;
                    //    break;
                    //case "-devices":
                    //    Console.WriteLine("Supported devices:"); 
                    //    Console.WriteLine(" m8  - AtMega8"); 
                    //    //Console.WriteLine("");
                    //    break;

                    case "-stopbits":
                        switch (argg[1])
                        {
                            case "1":
                                prog.portStopBits = StopBits.One;
                                break;

                            case "1.5":
                                prog.portStopBits = StopBits.OnePointFive;
                                break;

                            case "2":
                                prog.portStopBits = StopBits.Two;
                                break;

                            default:
                                Console.WriteLine("Warning! Argument [{0}] unrecognized, skipping.", arg);
                                break;
                        }
                        break;

                    case "-bootsize":
                        int bs = Convert.ToInt32(argg[1]);
                        if ((bs == 128) || (bs == 256) || (bs == 512) || (bs == 1024))
                            prog.bootloaderSize = bs;
                        else
                            Console.WriteLine("Warning! Bootloader size [{0}] is not valid. Use only: 128, 256, 512, 1024. Using default 256.", bs);
                        break;

                    case "-timeout":
                        prog.defaultDeviceConnectionTimeout = Convert.ToInt32(argg[1]);
                        break;

                    case "-reset":
                        switch (argg[1])
                        {
                            case "none":
                                prog.resetLine = ResetLine.None;
                                break;

                            case "dtr":
                                prog.resetLine = ResetLine.DTR;
                                break;

                            case "rts":
                                prog.resetLine = ResetLine.RTS;
                                break;

                            default:
                                Console.WriteLine("Warning! Argument [{0}] unrecognized, skipping.", arg);
                                break;
                        }
                        break;

                    case "-resettime":
                        prog.defaultResetPulseTime = Convert.ToInt32(argg[1]);
                        break;

                    case "-baud":
                        prog.portBaud = Convert.ToInt32(argg[1]);
                        break;

                    default:
                        Console.WriteLine("Warning! Argument [{0}] unrecognized, skipping.", arg);
                        break;
                }
            }
            #endregion

            PagesOfCode flash = null;
            if ((FlashFileName != "") && File.Exists(Environment.CurrentDirectory + "\\" + FlashFileName))
            {
                flash = Importer.ImportRawBinary(FlashFileName, prog.device.FlashPageSize);
                if (flash != null)
                {
                    Console.WriteLine("Imported flash: {0}. File contains {1} pages.", FlashFileName, flash.PageCount);
                }
            }
            else
            {
                Console.WriteLine("[Warning!] No flash to import!");
            }

            // Część zasadnicza
           // try
            //{
                prog.Connect();

                if (TerminalMode)
                {
                    Console.WriteLine("=== Terminal mode ===");
                    TerminalLoop();
                }
                else
                {
                    if (flash != null)
                    {
                        Console.WriteLine("- Writing flash...");
                        prog.WriteFlash(flash);
                    }
                    if (FlashRFileName != "")
                    {
                        Console.WriteLine("- Reading flash...");
                        prog.ReadFlash(FlashRFileName);
                    }
                }
                prog.Disconnect();
           // }
           // catch (Exception exc)
          //  {
         //       Console.WriteLine("Fatal error: " + exc.Message);
        //        return -1;
         //   }

            //Podliczenie całkowitego czasu
            TimeSpan deltaT = DateTime.Now.Subtract(startT);
            Console.WriteLine("Total time taken: {0}m {1}s {2}ms", deltaT.Minutes, deltaT.Seconds, deltaT.Milliseconds);
            return 0;
        }

        private static void TerminalLoop()
        {
            String command = "";
            while (true)
            {
                Console.Write(">");
                command = Console.ReadLine();
                command = command.ToLower();

                String[] splitC = command.Split(' ');

                if (splitC.Length == 0) continue;

                UInt16 address;
                byte dataByte;

                switch (splitC[0])
                {
                    case "quit":
                    case "exit":
                    case "q":
                        return;

                    case "fuse":
                    case "f":
                        Console.WriteLine(" # Chip Hfuse:0x{0:X2} LFuse:0x{1:X2} LockBits{2:X2}.", prog.hfuse, prog.lfuse, prog.lockb);
                        break;

                    case "readf":
                    case "rf":
                        if (splitC.Length != 2)
                        {
                            Console.WriteLine(" # Comand error. Type 'help' for info.");
                            break;
                        }
                        address = Convert.ToUInt16(splitC[1], 16);
                        Console.WriteLine(" # Flash read @Page: {0:X4}\n{1}", address * prog.device.FlashPageSize, prog.ReadFlashPage(address));
                        break;

                    case "writef":
                    case "wf":
                        if ((splitC.Length != 3) || (splitC[2].Length != (prog.device.FlashPageSize * 2)))
                        {
                            Console.WriteLine(" # Comand error. Type 'help' for info.");
                            break;
                        }
                        //Adress to po prostu numer strony 2DO
                        address = Convert.ToUInt16(splitC[1], 16);
                        PageOfCode pa = new PageOfCode();
                        for (int i = 0; i < splitC[2].Length; i += 2)
                            pa.code.Add(Convert.ToByte(splitC[2].Substring(i, 2), 16));
                        pa.number = address;
                        prog.WriteFlashPage(pa);
                        prog.EnableRRW();
                        Console.WriteLine(" # Flash write @Page: {0:X4}\n{1}", address * prog.device.FlashPageSize, prog.ReadFlashPage(address));
                        break;


                    case "reade":
                    case "re":
                        if (splitC.Length != 2)
                        {
                            Console.WriteLine(" # Comand error. Type 'help' for info.");
                            break;
                        }
                        address = Convert.ToUInt16(splitC[1], 16);
                        Console.WriteLine(" # EEPROM read @0x{0:X4}:0x{1:X2}", address, prog.ReadEEPROM(address));
                        break;

                    case "writee":
                    case "we":
                        if (splitC.Length != 3)
                        {
                            Console.WriteLine(" # Comand error. Type 'help' for info.");
                            break;
                        }
                        address = Convert.ToUInt16(splitC[1], 16);
                        dataByte = Convert.ToByte(splitC[2], 16);
                        prog.WriteEEPROM(address, dataByte);
                        Console.WriteLine(" # EEPROM write @0x{0:X4}: {1:X2}", address, prog.ReadEEPROM(address));
                        break;

                    case "reset":
                        prog.DeviceReset();
                        return;

                    case "wtf":
                    case "-?":
                    case "help":
                    case "?":
                    case "h":
                        Console.WriteLine(" Terminal mode help");
                        Console.WriteLine("  Avaible commands:");
                        Console.WriteLine("  quit   - Quit terminal mode and disconnect");
                        Console.WriteLine("  fuse   - Show device fuse and lock bytes");
                        Console.WriteLine("  readF  - Read page from flash use: readF <page> ex: 'readf 1C'");
                        Console.WriteLine("  writeF - Write flash memory page");
                        Console.WriteLine("           use: writeF <page> <byte0byte1...byte63> ex: 'writef 1C 01C54B...");
                        Console.WriteLine("  readE  - Read byte from EEPROM memory use: readE <address> ex: 'reade 01AB'");
                        Console.WriteLine("  writeE - Write byte to EEPROM memory");
                        Console.WriteLine("           use: writeE <address> <byte> ex: 'writee 10BA CD'");
                        Console.WriteLine("  reset  - Send reset signal and disconnect");
                        Console.WriteLine("  help   - Show this message");
                        break;

                    default:
                        Console.WriteLine(" Command {0} unrecognized.", splitC[0]);
                        break;
                }

            }
        }

    }
}
