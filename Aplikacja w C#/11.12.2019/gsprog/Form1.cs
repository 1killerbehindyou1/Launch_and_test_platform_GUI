using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using Kucia.sprog.Programmer;
using System.Threading;

namespace gsprog
{
    public partial class Form1 : Form
    {
        Programmer prog = new Programmer();
        DateTime startTime;
        PagesOfCode flash = null;
        Thread worker;
        int errcnt;

        public Form1()
        {
            InitializeComponent();

            foreach (string s in SerialPort.GetPortNames())
            {
                portToolStripMenuItem.DropDownItems.Add(s, null, portXToolStripMenuItem_Click);
            }
            prog.OnFlashPageWriteError += OnFlashWriteErrorOccur;
            prog.OnFlashPageWriteSuccess += OnFlashPageWriteSuccess;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFD.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                filePath.Text = openFD.FileName;

                flash = Importer.ImportRawBinary(openFD.FileName, prog.device.FlashPageSize);

            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void portXToolStripMenuItem_Click(object sender, EventArgs e)
        {
            prog.portName = (sender as ToolStripMenuItem).Text;
            foreach (ToolStripMenuItem tsi in portToolStripMenuItem.DropDownItems)
            {
                tsi.Checked = false;
            }
            (sender as ToolStripMenuItem).Checked = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if ((worker == null) || (worker.ThreadState == ThreadState.Stopped))
            {
                worker = new Thread(DoWriteFlash);

            }
            if (worker.IsAlive)
            {
                worker.Abort();
            }
            else
            {
                worker.Start();
            }

        }

        void DoWriteFlash()
        {
            try
            {
                startTime = DateTime.Now;
                errcnt = 0;
                timerTime.Enabled = true;
                button2.BeginInvoke((MethodInvoker)delegate() { button2.Text = "!Abort!"; });
                label_errors.BeginInvoke((MethodInvoker)delegate()
                {
                    label_errors.Text = "Errors: 0";
                });
                prog.Connect();
                label_fuses.BeginInvoke((MethodInvoker)delegate() { label_fuses.Text = String.Format("Hfuse: 0x{0:X2} Lfuse: 0x{1:X2} Lock: 0x{2:X2}", prog.hfuse, prog.lfuse, prog.lockb); });

                if (flash != null)
                    prog.WriteFlash(flash);
            }
            catch (Exception ex)
            {
                MessageBox.Show(null, ex.Message, "Fatal error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                prog.Disconnect();
                timerTime_Tick(this, new EventArgs());
                timerTime.Enabled = false;
                progressBar.BeginInvoke((MethodInvoker)delegate() { progressBar.Value = 100; });
                button2.BeginInvoke((MethodInvoker)delegate() { button2.Text = "Start"; });
            }
        }

        private void timerTime_Tick(object sender, EventArgs e)
        {
            TimeSpan span = DateTime.Now.Subtract(startTime);
            label_time.BeginInvoke((MethodInvoker)delegate()
            {
                label_time.Text = String.Format("Total time {0:D2}:{1:D2}.{2:D3}", span.Minutes, span.Seconds, span.Milliseconds);
            });
        }

        void OnFlashWriteErrorOccur()
        {
            errcnt++;
            label_errors.BeginInvoke((MethodInvoker)delegate()
            {
                label_errors.Text = String.Format("Errors: {0}", errcnt);
            });
        }

        void OnFlashPageWriteSuccess(int page, int pages)
        {
            progressBar.BeginInvoke((MethodInvoker)delegate()
            {
                progressBar.Value = (int)(100 * page / (pages - 1));
            });
        }

        private void deviceToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
