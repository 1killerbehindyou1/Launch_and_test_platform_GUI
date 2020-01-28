namespace gsprog
{
    partial class Analog_Input
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.CustomLabel customLabel1 = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.Input1_graph = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label27 = new System.Windows.Forms.Label();
            this.graph_min = new System.Windows.Forms.NumericUpDown();
            this.Savefilebutton2 = new System.Windows.Forms.Button();
            this.OpenFile2 = new System.Windows.Forms.Button();
            this.run_box = new System.Windows.Forms.CheckBox();
            this.label26 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.graph_max = new System.Windows.Forms.NumericUpDown();
            this.graph_scale = new System.Windows.Forms.NumericUpDown();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.Input1_graph.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.graph_min)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.graph_max)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.graph_scale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // Input1_graph
            // 
            this.Input1_graph.Controls.Add(this.button1);
            this.Input1_graph.Controls.Add(this.label27);
            this.Input1_graph.Controls.Add(this.graph_min);
            this.Input1_graph.Controls.Add(this.Savefilebutton2);
            this.Input1_graph.Controls.Add(this.OpenFile2);
            this.Input1_graph.Controls.Add(this.run_box);
            this.Input1_graph.Controls.Add(this.label26);
            this.Input1_graph.Controls.Add(this.numericUpDown1);
            this.Input1_graph.Controls.Add(this.graph_max);
            this.Input1_graph.Controls.Add(this.graph_scale);
            this.Input1_graph.Controls.Add(this.label24);
            this.Input1_graph.Controls.Add(this.label25);
            this.Input1_graph.Location = new System.Drawing.Point(4, 369);
            this.Input1_graph.Name = "Input1_graph";
            this.Input1_graph.Size = new System.Drawing.Size(585, 69);
            this.Input1_graph.TabIndex = 30;
            this.Input1_graph.TabStop = false;
            this.Input1_graph.Text = "Plotter options";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(423, 16);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 23);
            this.button1.TabIndex = 30;
            this.button1.Text = "Zapisz wykres";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.Location = new System.Drawing.Point(110, 23);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(37, 16);
            this.label27.TabIndex = 35;
            this.label27.Text = "Vmin";
            // 
            // graph_min
            // 
            this.graph_min.AllowDrop = true;
            this.graph_min.AutoSize = true;
            this.graph_min.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.graph_min.Enabled = false;
            this.graph_min.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.graph_min.Location = new System.Drawing.Point(113, 42);
            this.graph_min.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.graph_min.Minimum = new decimal(new int[] {
            100000,
            0,
            0,
            -2147483648});
            this.graph_min.Name = "graph_min";
            this.graph_min.Size = new System.Drawing.Size(59, 20);
            this.graph_min.TabIndex = 34;
            this.graph_min.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Savefilebutton2
            // 
            this.Savefilebutton2.Location = new System.Drawing.Point(504, 42);
            this.Savefilebutton2.Name = "Savefilebutton2";
            this.Savefilebutton2.Size = new System.Drawing.Size(75, 23);
            this.Savefilebutton2.TabIndex = 33;
            this.Savefilebutton2.Text = "Zapisz";
            this.Savefilebutton2.UseVisualStyleBackColor = true;
            // 
            // OpenFile2
            // 
            this.OpenFile2.Location = new System.Drawing.Point(423, 42);
            this.OpenFile2.Name = "OpenFile2";
            this.OpenFile2.Size = new System.Drawing.Size(75, 23);
            this.OpenFile2.TabIndex = 32;
            this.OpenFile2.Text = "Otwórz";
            this.OpenFile2.UseVisualStyleBackColor = true;
            // 
            // run_box
            // 
            this.run_box.AutoSize = true;
            this.run_box.Checked = true;
            this.run_box.CheckState = System.Windows.Forms.CheckState.Checked;
            this.run_box.Location = new System.Drawing.Point(369, 46);
            this.run_box.Name = "run_box";
            this.run_box.Size = new System.Drawing.Size(46, 17);
            this.run_box.TabIndex = 28;
            this.run_box.Text = "Run";
            this.run_box.UseVisualStyleBackColor = true;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(211, 24);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(47, 16);
            this.label26.TabIndex = 30;
            this.label26.Text = "Points:";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.AllowDrop = true;
            this.numericUpDown1.AutoSize = true;
            this.numericUpDown1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numericUpDown1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.numericUpDown1.Location = new System.Drawing.Point(286, 42);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(53, 20);
            this.numericUpDown1.TabIndex = 29;
            this.numericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // graph_max
            // 
            this.graph_max.AllowDrop = true;
            this.graph_max.AutoSize = true;
            this.graph_max.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.graph_max.Enabled = false;
            this.graph_max.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.graph_max.Location = new System.Drawing.Point(3, 43);
            this.graph_max.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.graph_max.Minimum = new decimal(new int[] {
            100000,
            0,
            0,
            -2147483648});
            this.graph_max.Name = "graph_max";
            this.graph_max.Size = new System.Drawing.Size(59, 20);
            this.graph_max.TabIndex = 28;
            this.graph_max.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.graph_max.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // graph_scale
            // 
            this.graph_scale.AutoSize = true;
            this.graph_scale.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.graph_scale.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.graph_scale.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.graph_scale.Location = new System.Drawing.Point(214, 42);
            this.graph_scale.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.graph_scale.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.graph_scale.Name = "graph_scale";
            this.graph_scale.Size = new System.Drawing.Size(53, 20);
            this.graph_scale.TabIndex = 19;
            this.graph_scale.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.graph_scale.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(0, 22);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(40, 16);
            this.label24.TabIndex = 24;
            this.label24.Text = "Vmax";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(283, 24);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(56, 16);
            this.label25.TabIndex = 18;
            this.label25.Text = "Interval:";
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.Color.Transparent;
            customLabel1.Text = "Volt";
            chartArea1.AxisX.CustomLabels.Add(customLabel1);
            chartArea1.AxisX.LineColor = System.Drawing.Color.White;
            chartArea1.AxisX.MajorGrid.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Auto;
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.White;
            chartArea1.AxisX.MajorTickMark.LineColor = System.Drawing.Color.White;
            chartArea1.AxisX.Maximum = 20D;
            chartArea1.AxisX.MinorGrid.LineColor = System.Drawing.Color.White;
            chartArea1.AxisX.TitleForeColor = System.Drawing.Color.White;
            chartArea1.AxisY.LineColor = System.Drawing.Color.White;
            chartArea1.AxisY.MajorGrid.IntervalOffset = 0D;
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.White;
            chartArea1.AxisY.MajorGrid.LineWidth = 2;
            chartArea1.AxisY.Maximum = 20D;
            chartArea1.AxisY.MinorGrid.Enabled = true;
            chartArea1.AxisY.MinorGrid.LineColor = System.Drawing.Color.White;
            chartArea1.AxisY.MinorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea1.AxisY.Title = "Volt";
            chartArea1.BackColor = System.Drawing.Color.Black;
            chartArea1.BackImageTransparentColor = System.Drawing.Color.Black;
            chartArea1.BackSecondaryColor = System.Drawing.Color.White;
            chartArea1.BorderColor = System.Drawing.Color.White;
            chartArea1.Name = "ChartArea1";
            chartArea1.ShadowColor = System.Drawing.Color.White;
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(4, 24);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Fire;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Legend = "Legend1";
            series1.MarkerBorderColor = System.Drawing.Color.Black;
            series1.MarkerColor = System.Drawing.Color.Black;
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(678, 300);
            this.chart1.TabIndex = 31;
            this.chart1.Text = "chart1";
            // 
            // Analog_Input
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 450);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.Input1_graph);
            this.Location = new System.Drawing.Point(800, 0);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Analog_Input";
            this.Text = "Analog_Input";
            this.Input1_graph.ResumeLayout(false);
            this.Input1_graph.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.graph_min)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.graph_max)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.graph_scale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox Input1_graph;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.NumericUpDown graph_min;
        private System.Windows.Forms.Button Savefilebutton2;
        private System.Windows.Forms.Button OpenFile2;
        public System.Windows.Forms.CheckBox run_box;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.NumericUpDown graph_max;
        private System.Windows.Forms.NumericUpDown graph_scale;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
    }
}