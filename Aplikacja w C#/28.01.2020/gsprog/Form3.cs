using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace gsprog
{
    public partial class Tutorial : Form
    {
        public Tutorial()
        {
            InitializeComponent();


            using (StreamReader sr = new StreamReader(@"help.txt"))
            {
                richTextBox1.Text = sr.ReadToEnd();

            }

        }
    }
}

