using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace gsprog
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
               }

        /* ------------------------------Graph-------------------------------------*/


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
           int  graph_scaler = (int)graph_scale.Value;
            for (int i = 0; i < 5; i++)
                graph.Series[i].Points.Clear();
        }
        /* set graph max value*/
        private void set_graph_max_enable_CheckedChanged(object sender, EventArgs e)
        {

            graph.ChartAreas[0].AxisY.Maximum = (int)graph_max.Value;

        }


        private void clear_graph_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 5; i++)
                graph.Series[i].Points.Clear();
        }

        private void saveAsImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /* if (saveImageDialog.ShowDialog() == DialogResult.OK)
                 graph.SaveImage(saveImageDialog.FileName, ChartImageFormat.Png);*/
        }

    }
}
