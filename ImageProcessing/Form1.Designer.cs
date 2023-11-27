namespace ImageProcessing
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.label1 = new System.Windows.Forms.Label();
            this.cbProcesses = new System.Windows.Forms.ComboBox();
            this.btnRun = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.subtractToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadBackgroundToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label4 = new System.Windows.Forms.Label();
            this.labelCurrProcess = new System.Windows.Forms.Label();
            this.labelDescription1 = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label5 = new System.Windows.Forms.Label();
            this.cbHistogram = new System.Windows.Forms.ComboBox();
            this.labelDescription2 = new System.Windows.Forms.Label();
            this.btnOpenCam = new System.Windows.Forms.Button();
            this.pBoxIcon = new System.Windows.Forms.PictureBox();
            this.pBox3 = new System.Windows.Forms.PictureBox();
            this.pBox2 = new System.Windows.Forms.PictureBox();
            this.pBox1 = new System.Windows.Forms.PictureBox();
            this.labelSubtractionRes = new System.Windows.Forms.Label();
            this.btnCloseCam = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(59, 760);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Select process";
            // 
            // cbProcesses
            // 
            this.cbProcesses.FormattingEnabled = true;
            this.cbProcesses.Items.AddRange(new object[] {
            "Basic Copy",
            "Grey Scale",
            "Color Inversion",
            "Sepia",
            "Subtract"});
            this.cbProcesses.Location = new System.Drawing.Point(215, 758);
            this.cbProcesses.Name = "cbProcesses";
            this.cbProcesses.Size = new System.Drawing.Size(497, 21);
            this.cbProcesses.TabIndex = 3;
            this.cbProcesses.SelectedIndexChanged += new System.EventHandler(this.cbProcess_SelectedIndexChanged);
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(735, 754);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(315, 29);
            this.btnRun.TabIndex = 4;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(394, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Process:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1087, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importToolStripMenuItem,
            this.exportToolStripMenuItem,
            this.subtractToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.importToolStripMenuItem.Text = "Import image";
            this.importToolStripMenuItem.Click += new System.EventHandler(this.importToolStripMenuItem_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.exportToolStripMenuItem.Text = "Export";
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
            // 
            // subtractToolStripMenuItem
            // 
            this.subtractToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadImageToolStripMenuItem,
            this.loadBackgroundToolStripMenuItem});
            this.subtractToolStripMenuItem.Name = "subtractToolStripMenuItem";
            this.subtractToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.subtractToolStripMenuItem.Text = "Subtract";
            // 
            // loadImageToolStripMenuItem
            // 
            this.loadImageToolStripMenuItem.Name = "loadImageToolStripMenuItem";
            this.loadImageToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.loadImageToolStripMenuItem.Text = "Load image";
            this.loadImageToolStripMenuItem.Click += new System.EventHandler(this.loadImageToolStripMenuItem_Click);
            // 
            // loadBackgroundToolStripMenuItem
            // 
            this.loadBackgroundToolStripMenuItem.Name = "loadBackgroundToolStripMenuItem";
            this.loadBackgroundToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.loadBackgroundToolStripMenuItem.Text = "Load background";
            this.loadBackgroundToolStripMenuItem.Click += new System.EventHandler(this.loadBackgroundToolStripMenuItem_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(58, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "Original";
            // 
            // labelCurrProcess
            // 
            this.labelCurrProcess.AutoSize = true;
            this.labelCurrProcess.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCurrProcess.Location = new System.Drawing.Point(453, 40);
            this.labelCurrProcess.Name = "labelCurrProcess";
            this.labelCurrProcess.Size = new System.Drawing.Size(69, 15);
            this.labelCurrProcess.TabIndex = 10;
            this.labelCurrProcess.Text = "No process";
            // 
            // labelDescription1
            // 
            this.labelDescription1.AutoSize = true;
            this.labelDescription1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDescription1.Location = new System.Drawing.Point(59, 56);
            this.labelDescription1.Name = "labelDescription1";
            this.labelDescription1.Size = new System.Drawing.Size(16, 13);
            this.labelDescription1.TabIndex = 11;
            this.labelDescription1.Text = "---";
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.chart1.BorderlineWidth = 0;
            chartArea2.AxisX.MajorGrid.Enabled = false;
            chartArea2.AxisY.MajorGrid.Enabled = false;
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart1.Legends.Add(legend2);
            this.chart1.Location = new System.Drawing.Point(61, 404);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(989, 304);
            this.chart1.TabIndex = 12;
            this.chart1.Text = "chart1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(59, 723);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Histogram";
            // 
            // cbHistogram
            // 
            this.cbHistogram.FormattingEnabled = true;
            this.cbHistogram.Items.AddRange(new object[] {
            "Brightness",
            "Contrast",
            "Red",
            "Green",
            "Blue"});
            this.cbHistogram.Location = new System.Drawing.Point(215, 720);
            this.cbHistogram.Name = "cbHistogram";
            this.cbHistogram.Size = new System.Drawing.Size(497, 21);
            this.cbHistogram.TabIndex = 14;
            this.cbHistogram.SelectedIndexChanged += new System.EventHandler(this.cbHistogram_SelectedIndexChanged);
            // 
            // labelDescription2
            // 
            this.labelDescription2.AutoSize = true;
            this.labelDescription2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDescription2.Location = new System.Drawing.Point(393, 58);
            this.labelDescription2.Name = "labelDescription2";
            this.labelDescription2.Size = new System.Drawing.Size(16, 13);
            this.labelDescription2.TabIndex = 15;
            this.labelDescription2.Text = "---";
            // 
            // btnOpenCam
            // 
            this.btnOpenCam.Location = new System.Drawing.Point(735, 717);
            this.btnOpenCam.Name = "btnOpenCam";
            this.btnOpenCam.Size = new System.Drawing.Size(150, 32);
            this.btnOpenCam.TabIndex = 18;
            this.btnOpenCam.Text = "Open Camera";
            this.btnOpenCam.UseVisualStyleBackColor = true;
            this.btnOpenCam.Click += new System.EventHandler(this.btnOpenCam_Click);
            // 
            // pBoxIcon
            // 
            this.pBoxIcon.BackColor = System.Drawing.SystemColors.MenuBar;
            this.pBoxIcon.Image = global::ImageProcessing.Properties.Resources.camera1;
            this.pBoxIcon.Location = new System.Drawing.Point(673, 359);
            this.pBoxIcon.Name = "pBoxIcon";
            this.pBoxIcon.Size = new System.Drawing.Size(39, 38);
            this.pBoxIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pBoxIcon.TabIndex = 19;
            this.pBoxIcon.TabStop = false;
            this.pBoxIcon.DoubleClick += new System.EventHandler(this.pBoxIcon_DoubleClick);
            // 
            // pBox3
            // 
            this.pBox3.BackColor = System.Drawing.Color.Gainsboro;
            this.pBox3.Location = new System.Drawing.Point(735, 76);
            this.pBox3.Name = "pBox3";
            this.pBox3.Size = new System.Drawing.Size(315, 321);
            this.pBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pBox3.TabIndex = 16;
            this.pBox3.TabStop = false;
            // 
            // pBox2
            // 
            this.pBox2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pBox2.Location = new System.Drawing.Point(397, 76);
            this.pBox2.Name = "pBox2";
            this.pBox2.Size = new System.Drawing.Size(315, 321);
            this.pBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pBox2.TabIndex = 1;
            this.pBox2.TabStop = false;
            this.pBox2.DoubleClick += new System.EventHandler(this.pBox2_DoubleClick);
            // 
            // pBox1
            // 
            this.pBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pBox1.Location = new System.Drawing.Point(61, 76);
            this.pBox1.Name = "pBox1";
            this.pBox1.Size = new System.Drawing.Size(315, 321);
            this.pBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pBox1.TabIndex = 0;
            this.pBox1.TabStop = false;
            this.pBox1.DoubleClick += new System.EventHandler(this.pBox1_DoubleClick);
            // 
            // labelSubtractionRes
            // 
            this.labelSubtractionRes.AutoSize = true;
            this.labelSubtractionRes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSubtractionRes.Location = new System.Drawing.Point(732, 40);
            this.labelSubtractionRes.Name = "labelSubtractionRes";
            this.labelSubtractionRes.Size = new System.Drawing.Size(115, 16);
            this.labelSubtractionRes.TabIndex = 20;
            this.labelSubtractionRes.Text = "Subtraction Result";
            // 
            // btnCloseCam
            // 
            this.btnCloseCam.Enabled = false;
            this.btnCloseCam.Location = new System.Drawing.Point(900, 717);
            this.btnCloseCam.Name = "btnCloseCam";
            this.btnCloseCam.Size = new System.Drawing.Size(150, 32);
            this.btnCloseCam.TabIndex = 21;
            this.btnCloseCam.Text = "Close Camera";
            this.btnCloseCam.UseVisualStyleBackColor = true;
            this.btnCloseCam.Click += new System.EventHandler(this.btnCloseCam_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1087, 791);
            this.Controls.Add(this.btnCloseCam);
            this.Controls.Add(this.labelSubtractionRes);
            this.Controls.Add(this.pBoxIcon);
            this.Controls.Add(this.btnOpenCam);
            this.Controls.Add(this.pBox3);
            this.Controls.Add(this.labelDescription2);
            this.Controls.Add(this.cbHistogram);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.labelDescription1);
            this.Controls.Add(this.labelCurrProcess);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.cbProcesses);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pBox2);
            this.Controls.Add(this.pBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pBox1;
        private System.Windows.Forms.PictureBox pBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbProcesses;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelCurrProcess;
        private System.Windows.Forms.Label labelDescription1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbHistogram;
        private System.Windows.Forms.Label labelDescription2;
        private System.Windows.Forms.PictureBox pBox3;
        private System.Windows.Forms.ToolStripMenuItem subtractToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadBackgroundToolStripMenuItem;
        private System.Windows.Forms.Button btnOpenCam;
        private System.Windows.Forms.PictureBox pBoxIcon;
        private System.Windows.Forms.Label labelSubtractionRes;
        private System.Windows.Forms.Button btnCloseCam;
    }
}

