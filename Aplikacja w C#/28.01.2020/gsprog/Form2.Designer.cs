namespace gsprog
{
    partial class Form2
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
        public void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.LineAnnotation lineAnnotation1 = new System.Windows.Forms.DataVisualization.Charting.LineAnnotation();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.plotter_option_group = new System.Windows.Forms.GroupBox();
            this.clear_graph = new System.Windows.Forms.Button();
            this.label27 = new System.Windows.Forms.Label();
            this.graph_min = new System.Windows.Forms.NumericUpDown();
            this.Savefilebutton2 = new System.Windows.Forms.Button();
            this.OpenFile2 = new System.Windows.Forms.Button();
            this.LogujBox = new System.Windows.Forms.CheckBox();
            this.run_box = new System.Windows.Forms.CheckBox();
            this.label26 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.graph_max = new System.Windows.Forms.NumericUpDown();
            this.graph_scale = new System.Windows.Forms.NumericUpDown();
            this.label24 = new System.Windows.Forms.Label();
            this.graph_speed = new System.Windows.Forms.NumericUpDown();
            this.label25 = new System.Windows.Forms.Label();
            this.graph = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.plotter_option_group.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.graph_min)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.graph_max)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.graph_scale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.graph_speed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.graph)).BeginInit();
            this.SuspendLayout();
            // 
            // plotter_option_group
            // 
            this.plotter_option_group.Controls.Add(this.clear_graph);
            this.plotter_option_group.Controls.Add(this.label27);
            this.plotter_option_group.Controls.Add(this.graph_min);
            this.plotter_option_group.Controls.Add(this.Savefilebutton2);
            this.plotter_option_group.Controls.Add(this.OpenFile2);
            this.plotter_option_group.Controls.Add(this.LogujBox);
            this.plotter_option_group.Controls.Add(this.run_box);
            this.plotter_option_group.Controls.Add(this.label26);
            this.plotter_option_group.Controls.Add(this.numericUpDown1);
            this.plotter_option_group.Controls.Add(this.graph_max);
            this.plotter_option_group.Controls.Add(this.graph_scale);
            this.plotter_option_group.Controls.Add(this.label24);
            this.plotter_option_group.Controls.Add(this.graph_speed);
            this.plotter_option_group.Controls.Add(this.label25);
            this.plotter_option_group.Location = new System.Drawing.Point(41, 370);
            this.plotter_option_group.Name = "plotter_option_group";
            this.plotter_option_group.Size = new System.Drawing.Size(527, 69);
            this.plotter_option_group.TabIndex = 29;
            this.plotter_option_group.TabStop = false;
            this.plotter_option_group.Text = "Plotter options";
            // 
            // clear_graph
            // 
            this.clear_graph.Location = new System.Drawing.Point(407, 15);
            this.clear_graph.Name = "clear_graph";
            this.clear_graph.Size = new System.Drawing.Size(100, 23);
            this.clear_graph.TabIndex = 28;
            this.clear_graph.Text = "Czyść wykres";
            this.clear_graph.UseVisualStyleBackColor = true;
            this.clear_graph.UseWaitCursor = true;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.Location = new System.Drawing.Point(68, 24);
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
            this.graph_min.Location = new System.Drawing.Point(71, 43);
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
            this.Savefilebutton2.Location = new System.Drawing.Point(326, 15);
            this.Savefilebutton2.Name = "Savefilebutton2";
            this.Savefilebutton2.Size = new System.Drawing.Size(75, 23);
            this.Savefilebutton2.TabIndex = 33;
            this.Savefilebutton2.Text = "Screen";
            this.Savefilebutton2.UseVisualStyleBackColor = true;
            // 
            // OpenFile2
            // 
            this.OpenFile2.Location = new System.Drawing.Point(326, 40);
            this.OpenFile2.Name = "OpenFile2";
            this.OpenFile2.Size = new System.Drawing.Size(75, 23);
            this.OpenFile2.TabIndex = 32;
            this.OpenFile2.Text = "Otwórz";
            this.OpenFile2.UseVisualStyleBackColor = true;
            // 
            // LogujBox
            // 
            this.LogujBox.AutoSize = true;
            this.LogujBox.Location = new System.Drawing.Point(250, 19);
            this.LogujBox.Name = "LogujBox";
            this.LogujBox.Size = new System.Drawing.Size(52, 17);
            this.LogujBox.TabIndex = 31;
            this.LogujBox.Text = "Loguj";
            this.LogujBox.UseVisualStyleBackColor = true;
            // 
            // run_box
            // 
            this.run_box.AutoSize = true;
            this.run_box.Checked = true;
            this.run_box.CheckState = System.Windows.Forms.CheckState.Checked;
            this.run_box.Location = new System.Drawing.Point(250, 46);
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
            this.label26.Location = new System.Drawing.Point(124, 24);
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
            this.numericUpDown1.Location = new System.Drawing.Point(177, 43);
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
            this.graph_scale.Location = new System.Drawing.Point(127, 43);
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
            // graph_speed
            // 
            this.graph_speed.AllowDrop = true;
            this.graph_speed.AutoSize = true;
            this.graph_speed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.graph_speed.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.graph_speed.Location = new System.Drawing.Point(422, 43);
            this.graph_speed.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.graph_speed.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.graph_speed.Name = "graph_speed";
            this.graph_speed.Size = new System.Drawing.Size(53, 20);
            this.graph_speed.TabIndex = 17;
            this.graph_speed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.graph_speed.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(174, 24);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(56, 16);
            this.label25.TabIndex = 18;
            this.label25.Text = "Interval:";
            // 
            // graph
            // 
            lineAnnotation1.Name = "U_wyj";
            this.graph.Annotations.Add(lineAnnotation1);
            this.graph.BorderlineColor = System.Drawing.Color.Black;
            this.graph.BorderlineWidth = 0;
            chartArea1.AlignmentOrientation = System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations.None;
            chartArea1.AxisX.IsMarginVisible = false;
            chartArea1.AxisX.LabelStyle.Enabled = false;
            chartArea1.AxisX.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            chartArea1.AxisX.MajorGrid.Interval = 0D;
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea1.AxisX.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea1.AxisX.MajorTickMark.TickMarkStyle = System.Windows.Forms.DataVisualization.Charting.TickMarkStyle.InsideArea;
            chartArea1.AxisX.MinorGrid.Enabled = true;
            chartArea1.AxisX.MinorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            chartArea1.AxisX.MinorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea1.AxisY.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea1.AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea1.AxisY.Maximum = 20D;
            chartArea1.AxisY.MinorGrid.Enabled = true;
            chartArea1.AxisY.MinorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            chartArea1.AxisY.MinorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea1.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
            chartArea1.BorderColor = System.Drawing.Color.Maroon;
            chartArea1.BorderWidth = 0;
            chartArea1.Name = "ChartArea1";
            this.graph.ChartAreas.Add(chartArea1);
            legend1.Alignment = System.Drawing.StringAlignment.Center;
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend1.LegendStyle = System.Windows.Forms.DataVisualization.Charting.LegendStyle.Row;
            legend1.MaximumAutoSize = 20F;
            legend1.Name = "Legend1";
            legend1.TitleAlignment = System.Drawing.StringAlignment.Near;
            legend1.TitleFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.graph.Legends.Add(legend1);
            this.graph.Location = new System.Drawing.Point(47, 12);
            this.graph.Name = "graph";
            series1.BorderWidth = 2;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(123)))), ((int)(((byte)(182)))));
            series1.Legend = "Legend1";
            series1.Name = "var 1";
            series1.YValuesPerPoint = 32;
            this.graph.Series.Add(series1);
            this.graph.Size = new System.Drawing.Size(510, 352);
            this.graph.TabIndex = 28;
            this.graph.Text = "chart2";
            title1.Name = "Kanał 3";
            this.graph.Titles.Add(title1);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 450);
            this.Controls.Add(this.plotter_option_group);
            this.Controls.Add(this.graph);
            this.Name = "Form2";
            this.Text = "Form2";
            this.plotter_option_group.ResumeLayout(false);
            this.plotter_option_group.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.graph_min)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.graph_max)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.graph_scale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.graph_speed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.graph)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox plotter_option_group;
        private System.Windows.Forms.Button clear_graph;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.NumericUpDown graph_min;
        private System.Windows.Forms.Button Savefilebutton2;
        private System.Windows.Forms.Button OpenFile2;
        public System.Windows.Forms.CheckBox LogujBox;
        public System.Windows.Forms.CheckBox run_box;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.NumericUpDown graph_max;
        private System.Windows.Forms.NumericUpDown graph_scale;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.NumericUpDown graph_speed;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.DataVisualization.Charting.Chart graph;
    }
}