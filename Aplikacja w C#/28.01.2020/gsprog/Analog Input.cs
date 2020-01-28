using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gsprog
{
    public partial class Analog_Input : Form
    {

       private int NumberOfPoints =50;
        // graph.
        public Analog_Input()
        {
            InitializeComponent();


        }

        

       public void addDataToPlot(string[] variables)
        
        {
            double number;
            foreach (string s in variables)
            {
                if (s != "")
                {
                    if (double.TryParse(variables[0], out number))
                    {
                        if (chart1.Series[0].Points.Count > NumberOfPoints)
                            chart1.Series[0].Points.RemoveAt(0);
                        chart1.Series[0].Points.Add(number);
                    }
                }
            }
        }

        

private void button1_Click(object sender, EventArgs e)
        {
           
            /* if (double.TryParse(variables[0], out number))
             {
                 if graph.Series[0].Points.Count > NumberOfPoints.Value)
                     graph.Series[0].Points.RemoveAt(0);
                 graph.Series[0].Points.Add(number);
             }*/
        }

       
    }
}

