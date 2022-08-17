using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;

using System.Threading;



namespace gsprog
{
    public partial class Form1 : Form
    {

        public string data { get; set; }
        int offset = 16;
        public bool plotter_flag;
        char[] arg = new char[9];
        char[] value = new char[9];
        int lineCounter = 0;
        string[] singleLinesTab;
        int commandArrayElem;
        int  i = 0;
        int param = 16;
        string logffilename = string.Empty;
        Analog_Input analogMonitor;
        delegate void Delegat1();   //deklaracja delegata i zrwacanego typu - void
        Delegat1 moj_del1;      //deklaracja delegatu moj_del1 typu Delegat1
        StreamWriter out_file;
        ScriptOperation script;
        public Form1()
        {
            InitializeComponent();
           

            foreach (string s in SerialPort.GetPortNames())
            {
                ComList.Items.Add(s);
            }         
            
            baudList.Items.Add(9600);
            baudList.Items.Add(38400);
            serialPort2.DataReceived += rx_data_event;
            moj_del1 = new Delegat1(SerialRecevieEvent);

            script = new ScriptOperation();

           
            using (StreamReader sr = new StreamReader(@"Test_Scripts\generator.txt"))
            {

                script.SyntaxHightlight(ScriptBox, sr);
            }

           
            nextButton.Enabled = true;
           
        }
        
        /* -----------------------------SKRYPT-------------------------------------*/
       

         private void stopButton_Click(object sender, EventArgs e)
                {
                   script.StopScript();
                }

         private void startButton_Click(object sender, EventArgs e)
                {
            script.StartScript();
        }
      

        private void prevButton_Click(object sender, EventArgs e)
        {
            command.Text = script.NawigationScript(prevButton, nextButton, "prev");

            if (AutosendBox.Checked == true)
            {
                SerialSend(command.Text);
            }

        }
        private void nextButton_Click(object sender, EventArgs e)
                {
            command.Text = script.NawigationScript(prevButton, nextButton, "next");
            if (AutosendBox.Checked == true)
            {
                SerialSend(command.Text);
            }
                   
                  }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            terminalBox.Clear();
        }

/* -------------------------------Serial-------------------------------------*/

 private void openComButton_Click(object sender, EventArgs e)
        {

            serialPort2.StopBits = StopBits.One;
            serialPort2.Parity = Parity.None;
            serialPort2.DataBits = 8;
            serialPort2.BaudRate = 9600;
            serialPort2.PortName = ComList.Text;
            serialPort2.Open();

            if (serialPort2.IsOpen)
            {
                
                startButton.Enabled = true;
                stopButton.Enabled = true;
                serialSendButton.Enabled = true;
            }
        }

 private void closeButton_Click(object sender, EventArgs e)
        {
           
            startButton.Enabled = false;
            stopButton.Enabled = false;
            serialSendButton.Enabled = false;
            serialPort2.Close();
            //serialPort2.DiscardInBuffer();
            //serialPort2.DiscardOutBuffer();
        }

 private void SerialSend(string arg)
        {
            serialPort2.Write(arg);

        string[] arg_tab = new string[1];
            arg_tab[0] = arg;
            AddToTerminalBox(arg_tab, "TX");


           

             if (checkBox1.Checked == true)
             {
                using (out_file = File.AppendText(@logffilename))
                {
                    out_file.WriteLine("<TX>\t" + arg);
                }
            }
             
        }
 private void serialSendButton_Click(object sender, EventArgs e)
        {

            SerialSend(command.Text);
        
        }

private void SerialRecevieEvent()
        {         
            int dataLength = serialPort2.BytesToRead;
            byte[] dataRecevied = new byte[dataLength];
            serialPort2.Read(dataRecevied, 0, dataLength);
 
            data = System.Text.Encoding.Default.GetString(dataRecevied);
            string[] variables = data.Split(';');


            AddToTerminalBox(variables, "RX");
          
            if (checkBox1.Checked)
            {
                using (out_file = File.AppendText(@logffilename))
                {

                    foreach (string s in variables)
                        if (s != "")
                        {
                            out_file.WriteLine("<RX>\t" + s);
                        }
                }
            }

            /*if(analogMonitor != 0) 
            {
                

            }*/

            analogMonitor.addDataToPlot(variables);


        }
private void rx_data_event(object sender, SerialDataReceivedEventArgs e)
        {
            this.BeginInvoke(moj_del1);
        }   
        
 private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            i++;
            if (checkBox1.Checked == true)
            {
                checkBox1.Checked = true;
               logffilename = "Logs\\log" + i +".txt";
             
            }
            else
            {

                checkBox1.Checked = false;
            }
            
        }


        /* -----------------------------------------------------------------*/
 /*
 
 
         */
public void AddToTerminalBox( string[] arg, string dir)
        {
            foreach (string s in arg)
            {
                var StartIndex = terminalBox.TextLength;

                switch (dir)
                {
                    case "TX":
                        {
                            terminalBox.SelectionColor = Color.Red;
                            terminalBox.AppendText("<TX>\t");
                            break;
                        }
                    case "RX":
                        {
                            terminalBox.SelectionColor = Color.Green;
                            terminalBox.AppendText("<RX>\t");
                            break;
                        }

                }
                terminalBox.AppendText(s);
                var StopIndex = terminalBox.TextLength;
                terminalBox.Select(StartIndex, StopIndex - StartIndex);
                terminalBox.AppendText("\r\n");
            }
                
        }





/* ----------------------------------MENU-----------------------------------*/


        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = @"";


                openFileDialog.Filter = "txt files (*.txt)|*.txt";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                var fileContent = string.Empty;
                var filePath = string.Empty;


                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {

                    var fileStream = openFileDialog.OpenFile();

                    try
                    {
                        using (StreamReader sr = new StreamReader(fileStream))
                        {
                            ScriptBox.Text = sr.ReadToEnd();
                            nextButton.Enabled = true;
                        }
                    }

                    catch (IOException ee)
                    {
                        MessageBox.Show("błąd otwarcia pliku", "Error");
                    }

                    catch (Exception ex)
                    {

                    }

                    string contentTextBox = ScriptBox.Text;

                    singleLinesTab = contentTextBox.Split(new char[] { ';' });
                    commandArrayElem = singleLinesTab.Length;
                    command.Text = singleLinesTab[lineCounter] + ";";
                    commandArrayElem--;
                    prevButton.Enabled = false;
                    //terminalCommandBox.Text = ParseCommand(command.Text);
                }
            }
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Tutorial okno_help = new Tutorial();
            okno_help.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            analogMonitor = new Analog_Input();
            analogMonitor.Show();
        }
    }
}
