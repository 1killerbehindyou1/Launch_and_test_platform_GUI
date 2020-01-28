using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;

using System.Windows.Forms;
using System.IO.Ports;

namespace gsprog
{
    class ScriptOperation
    {
        public int lineCounter = 0;
        public int lineMax = 0;
      private int pointer_relativeX = 16;
        private bool valuePresent = false;
        public  string [] ScriptLineArray;
        //public StreamReader scriptFile;
        public SerialPort scriptSerial;
        public string fileScriptContent= string.Empty;

        public ScriptOperation()
        {
           this.lineCounter = 0;
            this.lineMax = 0;
    }

        public void StartScript()
        {

        }
        public  void StopScript()
        {


        }

        public string NawigationScript(Button Prew, Button Next, string dir)
        {
           
            if (this.lineCounter == 0)
            {

                if (dir == "next") lineCounter++;

               Prew.Enabled = false;
               Next.Enabled = true;
            }
           else if((this.lineCounter > 0)|| (this.lineCounter < this.lineMax))
            {
                if (dir == "next") lineCounter++;
                if (dir == "prev") lineCounter--;
                Prew.Enabled = true;
                Next.Enabled = true;

            }
             else if (this.lineCounter == this.lineMax)
            {
                if (dir == "prev") lineCounter--;
                Prew.Enabled = true;
                Next.Enabled = false;
            }

            return ParseCommandToSend(lineCounter);

        }

        
        public  string ParseCommandToSend(int line_cnt)
        {
        string result= string.Empty;
        string arg = string.Empty;
            string val = string.Empty; 
        string[] argPhr;
            argPhr = ScriptLineArray[line_cnt].Split(new string[] { "><" }, StringSplitOptions.None);
            int quanPhrElem = argPhr.Length;
           
            foreach(string s in argPhr)
            {
                 if (s.StartsWith("device="))
                        {
                            string ss = s.Remove(0, 7);
                        switch(ss)
                            {
                                case "supply":
                                    {
                                arg += 'z';
                                break;
                                    }
                                case "generator":
                                    {
                                arg += 'g';
                                break;
                                    }
                                case"relay" :
                                    {
                                arg += 'r';
                                break;
                                    }
                                case "analog" :
                                    {
                                arg += 'r';
                                break;
                                    }

                           }


                 }

                 if (s.StartsWith("channel="))
                        {                 
                          string ss = s.Remove(0, 8);
                            arg += ss;
                         }
                
                 if (s.StartsWith("param="))
                        {
                          string ss = s.Remove(0, 6);
                            switch (ss)
                            {
                                case "volt":
                                    {
                                        arg += 'v';
                                        break;
                                    }
                                case "curr":
                                    {
                                        arg += 'c';
                                        break;
                                    }
                                case "pow":
                                    {
                                        arg += 'p';
                                        break;
                                    }
                                case "freq":
                                    {
                                        arg += 'f';
                                        break;
                                    }

                             case "signal":
                                    {
                                        arg += 's';
                                        break;
                                    }
                            
                            case "duty":
                                {
                                    arg += 'd';
                                    break;
                                }
                        case "enable":
                            {
                                arg += 'e';
                                break;
                            }
                    }
                          }

                 if (s.StartsWith("arg="))
                {

                    string ss = s.Remove(0, 4);
                    switch (ss)
                    {
                        case "true":
                            {
                                arg += '1';
                                break;
                            }
                        case "false":
                            {
                                arg += '0';
                                break;
                            }
                        case "sin":
                            {
                                arg += 'b';
                                break;
                            }
                        case "sqr":
                            {
                                arg += 'q';
                                break;
                            }

                    }
                }

                 if (s.StartsWith("value="))
                {
                    valuePresent = true;
                    val = s.Remove(0, 6);
                }
                
                 if (s == "set")
                        {
                            arg += '0';                  
                        }
                        
                  if (s == "get")
                        {

                            arg += '1';

                        }

                 
                
               
            }
            if (valuePresent == false) result = "#" + arg + "/;";
            else
            {
                result = "#" + arg + "/*" + val + "/;";
                valuePresent = false;
            }

            return result;
        }

        public void  SyntaxHightlight(RichTextBox ScriptBox, StreamReader scriptFile)
        {
          this.fileScriptContent = scriptFile.ReadToEnd();

            this.ScriptLineArray =  fileScriptContent.Split(new string[] { "></command>\r\n<command><" }, StringSplitOptions.None);  //dzieli cały skrypt na linie

            this.lineMax = this.ScriptLineArray.Length; //ilosc wierszy

          

            for(int i =0; i < this.lineMax; i++ )
            {
                string[] commands_phrase;
                
                commands_phrase = this.ScriptLineArray[i].Split(new string[] { "><" }, StringSplitOptions.None);
                var Index = commands_phrase.Length; //ilosc fraz w danej linijce
               
                foreach (string s in commands_phrase)
                {

                    var StartIndex = ScriptBox.TextLength;

                    if ((s == "set")|| (s == "get"))
                    {

                        ScriptBox.SelectionColor = Color.Blue;
                        ScriptBox.Select(StartIndex, StartIndex + 5);
                        if (s == "set")
                        {
                            ScriptBox.AppendText("\r\n<SET> ");
                        }
                        else
                        {
                            ScriptBox.AppendText("\r\n<GET> ");
                        }
                    }   
                        

                    if (s.StartsWith("device="))
                    {
                       
                        ScriptBox.SelectionColor = Color.Purple;
                        ScriptBox.Select(StartIndex, StartIndex + 6);
                        ScriptBox.AppendText("<" + s.Remove(0, 7) + "> ");
                    }

                    if (s.StartsWith("channel="))
                    {

                        ScriptBox.SelectionColor = Color.Coral;
                        ScriptBox.Select(StartIndex, StartIndex + 5);
                        ScriptBox.AppendText("<CH:" + s.Remove(0, 8) + "> ");
                    }


                    if (s.StartsWith("param="))
                    {

                        ScriptBox.SelectionColor = Color.DarkBlue;
                        ScriptBox.Select(StartIndex, StartIndex + 6);
                        ScriptBox.AppendText("<" + s.Remove(0, 6) + "> ");
                    }


                    if (s.StartsWith("arg="))
                    {

                        ScriptBox.SelectionColor = Color.Red;
                        ScriptBox.Select(StartIndex, StartIndex + 4);
                        ScriptBox.AppendText("<" + s.Remove(0, 4)+ "> ");
                    }

                    if (s.StartsWith("value="))
                    {

                        ScriptBox.SelectionColor = Color.Red;
                        ScriptBox.Select(StartIndex, StartIndex + 6);
                        ScriptBox.AppendText(s.Remove(0, 6) + " ");
                    }
                   
                }

            }

           
            
        }
    }
}


/*
< script >
< nr >
< command >
< set >
< get >
< device >
< param >
< arg >
< value >
< channel >
< delay >
*/
