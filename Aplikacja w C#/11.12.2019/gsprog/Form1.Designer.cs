namespace gsprog
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.filePath = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label_fuses = new System.Windows.Forms.Label();
            this.label_errors = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.label_time = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.deviceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aTMega32ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.portToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timerTime = new System.Windows.Forms.Timer(this.components);
            this.openFD = new System.Windows.Forms.OpenFileDialog();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // filePath
            // 
            this.filePath.Location = new System.Drawing.Point(6, 19);
            this.filePath.Name = "filePath";
            this.filePath.Size = new System.Drawing.Size(307, 20);
            this.filePath.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(319, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(63, 20);
            this.button1.TabIndex = 1;
            this.button1.Text = "Open";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(388, 19);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(63, 20);
            this.button2.TabIndex = 2;
            this.button2.Text = "Start";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 24);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(464, 337);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label_fuses);
            this.tabPage1.Controls.Add(this.label_errors);
            this.tabPage1.Controls.Add(this.progressBar);
            this.tabPage1.Controls.Add(this.label_time);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.filePath);
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(456, 311);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Write Flash";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label_fuses
            // 
            this.label_fuses.AutoSize = true;
            this.label_fuses.Location = new System.Drawing.Point(118, 58);
            this.label_fuses.Name = "label_fuses";
            this.label_fuses.Size = new System.Drawing.Size(178, 13);
            this.label_fuses.TabIndex = 7;
            this.label_fuses.Text = "Hfuse: 0x?? Lfuse: 0x?? Lock: 0x??";
            // 
            // label_errors
            // 
            this.label_errors.AutoSize = true;
            this.label_errors.Location = new System.Drawing.Point(405, 58);
            this.label_errors.Name = "label_errors";
            this.label_errors.Size = new System.Drawing.Size(46, 13);
            this.label_errors.TabIndex = 6;
            this.label_errors.Text = "Errors: 0";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(6, 45);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(445, 10);
            this.progressBar.TabIndex = 5;
            // 
            // label_time
            // 
            this.label_time.AutoSize = true;
            this.label_time.Location = new System.Drawing.Point(8, 58);
            this.label_time.Name = "label_time";
            this.label_time.Size = new System.Drawing.Size(104, 13);
            this.label_time.TabIndex = 4;
            this.label_time.Text = "Total time 00:00.000";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Flash binary patch:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deviceToolStripMenuItem,
            this.portToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(464, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // deviceToolStripMenuItem
            // 
            this.deviceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aTMega32ToolStripMenuItem});
            this.deviceToolStripMenuItem.Name = "deviceToolStripMenuItem";
            this.deviceToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.deviceToolStripMenuItem.Text = "Device";
            this.deviceToolStripMenuItem.Click += new System.EventHandler(this.deviceToolStripMenuItem_Click);
            // 
            // aTMega32ToolStripMenuItem
            // 
            this.aTMega32ToolStripMenuItem.Checked = true;
            this.aTMega32ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.aTMega32ToolStripMenuItem.Name = "aTMega32ToolStripMenuItem";
            this.aTMega32ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.aTMega32ToolStripMenuItem.Text = "ATMega32";
            // 
            // portToolStripMenuItem
            // 
            this.portToolStripMenuItem.Name = "portToolStripMenuItem";
            this.portToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.portToolStripMenuItem.Text = "Port";
            // 
            // timerTime
            // 
            this.timerTime.Interval = 500;
            this.timerTime.Tick += new System.EventHandler(this.timerTime_Tick);
            // 
            // openFD
            // 
            this.openFD.Filter = "Binary|*.hex|Binary|*.bin|All files|*.*";
            this.openFD.Title = "Select binary file (do not use intel hex)";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 361);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(480, 400);
            this.MinimumSize = new System.Drawing.Size(480, 400);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "gsprog Serial Programming Utility";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox filePath;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label label_time;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem deviceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem portToolStripMenuItem;
        private System.Windows.Forms.Timer timerTime;
        private System.Windows.Forms.OpenFileDialog openFD;
        private System.Windows.Forms.Label label_errors;
        private System.Windows.Forms.Label label_fuses;
        private System.Windows.Forms.ToolStripMenuItem aTMega32ToolStripMenuItem;
    }
}

