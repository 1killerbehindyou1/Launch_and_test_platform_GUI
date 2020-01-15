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
using MySql.Data.MySqlClient;
using BazyDanych;


namespace gsprog
{
    public partial class Form1 : Form
    {


        BazyDanych.Serwer Baza = new Serwer();

        delegate void Delegate1();
       
        bool loggingFlag = false;
        public string data { get; set; }
        bool plotter_flag_zas3 = false;
        public bool plotter_flag;
        char[] arg = new char[9];
        char[] value = new char[9];
        int lineCounter = 0;
        string[] singleLinesTab;
        int commandArrayElem;

        
            OpenFileDialog openFileDialog2,  openFileDialog;



        int graph_scaler = 500;
        int send_repeat_counter = 0;
        bool send_data_flag = false;
        
        public static string ParseCommand(string command)
        {
            string[] argPhr;
            argPhr = command.Split(new char[] { ' ' });
            int quanPhrElem = argPhr.Length;
            string arg = string.Empty;
            float val;

            switch (argPhr[0])
            {
                case ("set"):
                    {
                        arg += '0';
                        break;
                    }
                case ("get"):
                    {

                        arg += '1';
                        break;
                    }

                case ("change"):
                    {

                        arg += '2';
                        break;
                    }
            }

            switch (argPhr[1])
            {
                case ("supp"):
                    {
                        arg += 'z';
                        break;
                    }
                case ("gen"):
                    {

                        arg += 'g';
                        break;
                    }

                case ("analog"):
                    {

                        arg += 'a';
                        break;
                    }
            }

            arg += argPhr[2];

            switch (argPhr[3])
            {
                case ("vol"):
                    {
                        arg += 'v';
                        break;
                    }
                case ("curr"):
                    {

                        arg += 'c';
                        break;
                    }
            }

            val = float.Parse(argPhr[4]);

            return "#" + arg + "/*" + val + "/";
        }

        public Form1()
        {
            InitializeComponent();
            MySqlConnection polaczenie = new MySqlConnection();
            foreach (string s in SerialPort.GetPortNames())
            {
                ComList.Items.Add(s);
            }

            Savefilebutton2.Enabled = false;
            baudList.Items.Add(9600);
            baudList.Items.Add(38400);
            serialPort1.DataReceived += rx_data_event;
            // backgroundWorker1.DoWork += new DoWorkEventHandler(update_rxtextarea_event);

        }
        /*
        //Event dla danych przychodzących do portu COM
        Serial.DataReceived += new SerialDataReceivedEventHandler(DataRecievedHandler);
         tabPageComPort.Enter += new EventHandler(Event_Data_Handler);
        New_Delegate1 = new Delegate1(WpiszOdebrane);

        //Ustawienie domyślnych wartości
        this.comboBoxPort.Items.Clear();
        this.comboBoxParity.Items.Clear();
        this.comboBoxStop.Items.Clear();
        foreach (String s in SerialPort.GetPortNames()) { this.comboBoxPort.Items.Add(s); }
        foreach (String s in Enum.GetNames(typeof(Parity))) { this.comboBoxParity.Items.Add(s); }
        foreach (String s in Enum.GetNames(typeof(StopBits))) { this.comboBoxStop.Items.Add(s); }

        comboBoxPort.Text = ComPort.PortName.ToString();
        comboBoxBaudRate.Text = ComPort.BaudRate.ToString();
        comboBoxData.Text = ComPort.DataBits.ToString();
        comboBoxParity.Text = ComPort.Parity.ToString();
        comboBoxStop.Text = ComPort.StopBits.ToString();
    }

    private void DataRecievedHandler(object sender, SerialDataReceivedEventArgs e)
    {
        richTextBoxTerminal.Invoke(New_Delegate1);
    }

    private void WpiszOdebrane()
    {
        try
        {
            if (rdoHex.Checked == true)
            {
                richTextBoxTerminal.SelectionColor = System.Drawing.Color.Blue;
                var StartIndex = richTextBoxTerminal.TextLength;
                richTextBoxTerminal.AppendText(ComPort.ReadByte().ToString("X") + Environment.NewLine);
                var EndIndex = richTextBoxTerminal.TextLength;
                richTextBoxTerminal.Select(StartIndex, EndIndex - StartIndex);
            }
            else
            {
                richTextBoxTerminal.SelectionColor = System.Drawing.Color.DarkRed;
                var StartIndex = terminalBox.TextLength;
                terminalBox.AppendText(Port1.ReadLine());
                var EndIndex = terminalBox.TextLength;
                terminalBox.Select((StartIndex), EndIndex - (StartIndex));

                terminalBox.AppendText(Environment.NewLine);
            }
        }
        catch (Exception ex) { }

        terminalBox.SelectionStart = terminalBox.Text.Length;
        terminalBox.ScrollToCar;
    }
    */




        private void ZalogujBt_MouseClick(object sender, MouseEventArgs e)
        {
            //blok try-catch przechwytuje błędy
            try
            {
                //otwórz połączenie z bazą danych
                Baza.zaloguj("localhost", "quiz", UserBox.Text, PasswordBox.Text);
            }

            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show("Błąd logowania do bazy danych MySQL", "Błąd");
            }


        }

        private void bazaDanych_TextChanged(object sender, EventArgs e)
        {

        }

        private void ImportButton_Click(object sender, EventArgs e)
        {
            dataGrid1.DataSource = Baza.PobierzDane(Column.Text, Tabel.Text);
        }



        private void loadButton_MouseClick(object sender, MouseEventArgs e)
        {

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c://";
                openFileDialog.Filter = "txt files (*.txt)|*.txt";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                var fileContent = string.Empty;
                var filePath = string.Empty;


                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    
                    var fileStream = openFileDialog.OpenFile();
                    adressBox.Text = openFileDialog.FileName;
                    //textBox5.Text = openFileDialog.RestoreDirectory;



                    try
                    {
                        using (StreamReader sr = new StreamReader(fileStream))
                        {
                            textBox2.Text = sr.ReadToEnd();
                           nextButton.Enabled = true;
                        }
                    }

                    catch (IOException ee)
                    {
                        MessageBox.Show("błąd otwarcia pliku", "Error");
                    }

                    catch(Exception ex)
                    {
                       
                    }

                    string contentTextBox = textBox2.Text;

                    singleLinesTab = contentTextBox.Split(new char[] { ';' });
                    commandArrayElem = singleLinesTab.Length;
                    command.Text = singleLinesTab[lineCounter];
                    commandArrayElem--;
                    prevButton.Enabled = false;
                    terminalCommandBox.Text = ParseCommand(command.Text);
                }
            }
        }

        private void stopButton_Click(object sender, EventArgs e)
        {

        }

        private void startButton_Click(object sender, EventArgs e)
        {

        }


        private void sendButton_Click(object sender, EventArgs e)
        {

            //Serial.serialPort.WriteLine(command.Text);
            terminalBox.Text += command.Text + "\r\n";
        }

        private void prevButton_Click(object sender, EventArgs e)
        {
            if ((lineCounter + 2) == commandArrayElem)
            {
                lineCounter--;
                nextButton.Enabled = true;
                command.Text = singleLinesTab[lineCounter];

            }

            lineCounter--;
            command.Text = singleLinesTab[lineCounter];

            if (lineCounter < 1)
            {
                prevButton.Enabled = false;
            }


            terminalCommandBox.Text = ParseCommand(command.Text);

        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            if (lineCounter >= 1)
            {
                prevButton.Enabled = true;
            }

            if ((lineCounter + 1) < commandArrayElem)
            {
                lineCounter++;
                command.Text = singleLinesTab[lineCounter];

            }
            else
            {
                lineCounter++;
                command.Text = singleLinesTab[lineCounter];

                nextButton.Enabled = false;
            }
            terminalCommandBox.Text = ParseCommand(command.Text);
        }

        private void openComButton_Click(object sender, EventArgs e)
        {

            serialPort1.StopBits = StopBits.One;
            serialPort1.Parity = Parity.None;
            serialPort1.DataBits = 8;

            serialPort1.PortName = ComList.Text;
            serialPort1.Open();

            if (serialPort1.IsOpen)
            {
                sendButton.Enabled = true;
                startButton.Enabled = true;
                stopButton.Enabled = true;
                serialSendButton.Enabled = true;
            }
        }


        private void serialSendButton_Click(object sender, EventArgs e)
        {

            //SerialCOM.port1.WriteLine(textBox3.Text);
            terminalBox.Text += terminalCommandBox.Text + "\r\n";
            terminalCommandBox.Clear();


        }



        private void rx_data_event(object sender, SerialDataReceivedEventArgs e)
        {
            {
                if (serialPort1.IsOpen)
                {
                    try
                    {
                        int dataLength = serialPort1.BytesToRead;
                        byte[] dataRecevied = new byte[dataLength];
                        int nbytes = serialPort1.Read(dataRecevied, 0, dataLength);
                        if (nbytes == 0) return;


                        if (LogujBox.Checked)
                        {

                            using (StreamWriter out_file = new StreamWriter("Log.txt"))
                            {
                                try
                                {
                                    out_file.Write(data.Replace("\\n", Environment.NewLine));
                                }
                                catch { /*alert("Can't write to " + datalogger_checkbox.Text + " file it might be not exist or it is opennd in another program"); */return; }
                            }


                            this.BeginInvoke((Action)(() =>
                            {
                                data = System.Text.Encoding.Default.GetString(dataRecevied);

                            /*
                            if (!plotter_flag && !backgroundWorker1.IsBusy)
                            {
                                if (display_hex_radiobutton.Checked)
                                    data = BitConverter.ToString(dataRecevied);

                                backgroundWorker1.RunWorkerAsync();
                            }*/

                                if (run_box.Checked)
                                {
                                    double number;
                                    string[] variables = data.Split('\n')[0].Split(',');
                                    for (int i = 0; i < variables.Length && i < 5; i++)
                                    {
                                        if (double.TryParse(variables[i], out number))
                                        {
                                            if (graph.Series[i].Points.Count > graph_scaler)
                                                graph.Series[i].Points.RemoveAt(0);
                                            graph.Series[i].Points.Add(number);
                                        }
                                    }
                                    graph.ResetAutoValues();

                                }

                            }));
                        }
                    }

                    catch { /*alert("Can't read form  " + serialPort1.PortName + " port it might be opennd in another program");*/ }
                }
            }
        }
        /*
        private void update_rxtextarea_event(object sender, DoWorkEventArgs e)
        {
            this.BeginInvoke((Action)(() =>
            {
                if (rx_textarea.Lines.Count() > 5000)
                    rx_textarea.ResetText();
                rx_textarea.AppendText("[RX]> " + data);
            }));
        }
*/
        /*
       

       

        /*TX------*/

/* Write data to serial port 
private void sendData_Click(object sender, EventArgs e)
{
    if (!send_data_flag)
    {
        tx_repeater_delay.Interval = (int)send_delay.Value;
        tx_repeater_delay.Start();

        if (send_word_radiobutton.Checked)
        {
            progressBar1.Maximum = (int)send_repeat.Value;
            progressBar1.Visible = true;
        }
        else if (write_form_file_radiobutton.Checked)
        {
            try
            {
                in_file = new System.IO.StreamReader(tx_textarea.Text, true);
            }
            catch
            {
                alert("Can't open " + tx_textarea.Text + " file, it might be not exist or it is used in another program");
                return;
            }

            progressBar1.Maximum = file_size(tx_textarea.Text);
            progressBar1.Visible = true;
        }

        send_data_flag = true;
        tx_num_panel.Enabled = false;
        tx_textarea.Enabled = false;
        tx_radiobuttons_panel.Enabled = false;
        sendData.Text = "Stop";
    }
    else
    {
        tx_repeater_delay.Stop();
        progressBar1.Value = 0;
        send_repeat_counter = 0;
        send_data_flag = false;
        progressBar1.Visible = false;
        tx_num_panel.Enabled = true;
        tx_textarea.Enabled = true;
        tx_radiobuttons_panel.Enabled = true;
        sendData.Text = "Send";
        if (write_form_file_radiobutton.Checked)
            try { in_file.Dispose(); }
            catch { }
    }
}

private void send_data(object sender, EventArgs e)
{

    string tx_data = "";
    if (send_word_radiobutton.Checked)
    {
        tx_data = tx_textarea.Text.Replace("\n", Environment.NewLine);
        if (send_repeat_counter < (int)send_repeat.Value)
        {
            send_repeat_counter++;
            progressBar1.Value = send_repeat_counter;
            progressBar1.Update();
        }
        else
            send_data_flag = false;
    }

    else if (write_form_file_radiobutton.Checked)
    {
        try { tx_data = in_file.ReadLine(); }
        catch { }

        if (tx_data == null)
            send_data_flag = false;
        else
        {
            progressBar1.Value = send_repeat_counter;
            send_repeat_counter++;
        }
        tx_data += "\\n";
    }

    if (send_data_flag)
    {
        if (mySerial.IsOpen)
        {
            try
            {

                mySerial.Write(tx_data.Replace("\\n", Environment.NewLine));
                tx_terminal.AppendText("[TX]> " + tx_data + "\n");
            }
            catch
            {
                alert("Can't write to " + mySerial.PortName + " port it might be opennd in another program");
            }
        }
    }
    else
    {
        tx_repeater_delay.Stop();
        sendData.Text = "Send";
        send_repeat_counter = 0;
        progressBar1.Value = 0;
        progressBar1.Visible = false;
        tx_radiobuttons_panel.Enabled = true;
        tx_num_panel.Enabled = true;
        tx_textarea.Enabled = true;

        if (write_form_file_radiobutton.Checked)
            try { in_file.Dispose(); }
            catch { }
    }
}



}*/

// Plotter ------
 private void graph_speed_ValueChanged(object sender, EventArgs e)
 {
     graph.ChartAreas[0].AxisY.Interval = (int)graph_speed.Value;
 }



       
        private void graph_min_ValueChanged(object sender, EventArgs e)
        {
            if (graph_min.Value < graph_max.Value)
                graph.ChartAreas[0].AxisY.Minimum = (int)graph_min.Value;
            else
            {/* alert("Invalid Minimum value");*/}
        }

 // change graph scale
 private void graph_scale_ValueChanged(object sender, EventArgs e)
 {
     graph_scaler = (int)graph_scale.Value;
     for (int i = 0; i < 5; i++)
         graph.Series[i].Points.Clear();
 }
/* set graph max value*/
                    private void set_graph_max_enable_CheckedChanged(object sender, EventArgs e)
        {
                      
                    graph.ChartAreas[0].AxisY.Maximum = (int)graph_max.Value;
                
        }



private void saveAsImageToolStripMenuItem_Click(object sender, EventArgs e)
{
            /* if (saveImageDialog.ShowDialog() == DialogResult.OK)
                 graph.SaveImage(saveImageDialog.FileName, ChartImageFormat.Png);*/
        }

        private void clear_graph_Click(object sender, EventArgs e)
{
    for (int i = 0; i < 5; i++)
        graph.Series[i].Points.Clear();
}


        /// <summary>
        /// ///////
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

private void ClearButton_Click(object sender, EventArgs e)
{
    terminalCommandBox.Clear();
}

private void closeButton_Click(object sender, EventArgs e)
    {
        sendButton.Enabled = false;
        startButton.Enabled = false;
        stopButton.Enabled = false;
        serialSendButton.Enabled = false;
        serialPort1.Close();
        serialPort1.DiscardInBuffer();
        serialPort1.DiscardOutBuffer();
    }



private void Savefilebutton2_Click(object sender, EventArgs e)
{
    using (SaveFileDialog openFileDialog = new SaveFileDialog())
    {
        openFileDialog2.InitialDirectory = "c://";
        openFileDialog2.Filter = "txt files (*.txt)|*.txt";
        openFileDialog2.FilterIndex = 2;
        openFileDialog2.RestoreDirectory = true;

        var fileContent = string.Empty;
        var filePath = string.Empty;



    }
}
    private void OpenFile2_Click(object sender, EventArgs e)
{
    using (openFileDialog2 = new OpenFileDialog())
    {
        openFileDialog2.InitialDirectory = "c://";
        openFileDialog2.Filter = "txt files (*.txt)|*.txt";
        openFileDialog2.FilterIndex = 2;
        openFileDialog2.RestoreDirectory = true;

        var fileContent = string.Empty;
        var filePath = string.Empty;


        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
            filePath = openFileDialog.FileName;
            //fileStream2 = openFileDialog2.OpenFile();
            Savefilebutton2.Enabled = true;
        }
    }
}


}
}
/*

            datalogger_checkbox.Checked = false;
            datalogger_append_radiobutton.Enabled = false;
            datalogger_overwrite_radiobutton.Enabled = false;
            datalogger_append_radiobutton.Enabled = false;
            datalogger_overwrite_radiobutton.Enabled = false;
        */




