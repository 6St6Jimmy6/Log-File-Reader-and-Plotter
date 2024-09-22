
namespace Log_File_Reader_and_Plotter
{
    partial class FormPlotter
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
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Y2ComboBox = new System.Windows.Forms.ComboBox();
            this.Y1ComboBox = new System.Windows.Forms.ComboBox();
            this.X1ComboBox = new System.Windows.Forms.ComboBox();
            this.stopButton = new System.Windows.Forms.Button();
            this.startButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.loadCSVButton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.plotToChart1 = new System.Windows.Forms.Button();
            this.toChartSettings = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.DelimiterTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(12, 286);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 247;
            this.label3.Text = "Y Axis Right";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 246);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 246;
            this.label2.Text = "Y Axis Left";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 206);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 245;
            this.label1.Text = "X Axis";
            // 
            // Y2ComboBox
            // 
            this.Y2ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Y2ComboBox.FormattingEnabled = true;
            this.Y2ComboBox.Location = new System.Drawing.Point(12, 302);
            this.Y2ComboBox.Name = "Y2ComboBox";
            this.Y2ComboBox.Size = new System.Drawing.Size(148, 21);
            this.Y2ComboBox.TabIndex = 244;
            this.Y2ComboBox.SelectedIndexChanged += new System.EventHandler(this.comboBox3_SelectedIndexChanged);
            // 
            // Y1ComboBox
            // 
            this.Y1ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Y1ComboBox.FormattingEnabled = true;
            this.Y1ComboBox.Location = new System.Drawing.Point(12, 262);
            this.Y1ComboBox.Name = "Y1ComboBox";
            this.Y1ComboBox.Size = new System.Drawing.Size(148, 21);
            this.Y1ComboBox.TabIndex = 243;
            this.Y1ComboBox.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // X1ComboBox
            // 
            this.X1ComboBox.BackColor = System.Drawing.SystemColors.Control;
            this.X1ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.X1ComboBox.FormattingEnabled = true;
            this.X1ComboBox.Location = new System.Drawing.Point(12, 222);
            this.X1ComboBox.Name = "X1ComboBox";
            this.X1ComboBox.Size = new System.Drawing.Size(148, 21);
            this.X1ComboBox.TabIndex = 242;
            this.X1ComboBox.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(12, 509);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(75, 23);
            this.stopButton.TabIndex = 241;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Visible = false;
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(12, 480);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 23);
            this.startButton.TabIndex = 240;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Visible = false;
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(12, 12);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(60, 25);
            this.closeButton.TabIndex = 238;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // loadCSVButton
            // 
            this.loadCSVButton.Location = new System.Drawing.Point(12, 43);
            this.loadCSVButton.Name = "loadCSVButton";
            this.loadCSVButton.Size = new System.Drawing.Size(75, 51);
            this.loadCSVButton.TabIndex = 236;
            this.loadCSVButton.Text = "Load log file";
            this.loadCSVButton.UseVisualStyleBackColor = true;
            this.loadCSVButton.Click += new System.EventHandler(this.loadCSVButton_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(485, 34);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(429, 261);
            this.textBox1.TabIndex = 237;
            this.textBox1.Visible = false;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(486, 301);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox2.Size = new System.Drawing.Size(428, 57);
            this.textBox2.TabIndex = 239;
            this.textBox2.Visible = false;
            // 
            // chart1
            // 
            this.chart1.BorderlineColor = System.Drawing.Color.Black;
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            legend2.BackColor = System.Drawing.Color.Transparent;
            legend2.ForeColor = System.Drawing.Color.White;
            legend2.Name = "Legend1";
            legend2.TitleBackColor = System.Drawing.Color.White;
            this.chart1.Legends.Add(legend2);
            this.chart1.Location = new System.Drawing.Point(166, 12);
            this.chart1.Name = "chart1";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(1080, 720);
            this.chart1.TabIndex = 248;
            this.chart1.Text = "chart1";
            this.chart1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.chart1_MouseDoubleClick);
            // 
            // plotToChart1
            // 
            this.plotToChart1.Location = new System.Drawing.Point(12, 100);
            this.plotToChart1.Name = "plotToChart1";
            this.plotToChart1.Size = new System.Drawing.Size(75, 51);
            this.plotToChart1.TabIndex = 249;
            this.plotToChart1.Text = "Plot to chart";
            this.plotToChart1.UseVisualStyleBackColor = true;
            this.plotToChart1.Click += new System.EventHandler(this.plotToChart_Click);
            // 
            // toChartSettings
            // 
            this.toChartSettings.Location = new System.Drawing.Point(12, 399);
            this.toChartSettings.Name = "toChartSettings";
            this.toChartSettings.Size = new System.Drawing.Size(75, 75);
            this.toChartSettings.TabIndex = 253;
            this.toChartSettings.Text = "Chart settings";
            this.toChartSettings.UseVisualStyleBackColor = true;
            this.toChartSettings.Click += new System.EventHandler(this.toChartSettings_Click);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(15, 508);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(145, 95);
            this.textBox3.TabIndex = 254;
            this.textBox3.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(9, 345);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 255;
            this.label4.Text = "Drag to zoom";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(9, 366);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(155, 13);
            this.label5.TabIndex = 256;
            this.label5.Text = "Double click right to reset zoom";
            // 
            // DelimiterTextBox
            // 
            this.DelimiterTextBox.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DelimiterTextBox.Location = new System.Drawing.Point(12, 183);
            this.DelimiterTextBox.Name = "DelimiterTextBox";
            this.DelimiterTextBox.Size = new System.Drawing.Size(36, 21);
            this.DelimiterTextBox.TabIndex = 257;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(9, 167);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 258;
            this.label6.Text = "Delimiter";
            // 
            // FormPlotter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1258, 778);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.DelimiterTextBox);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.toChartSettings);
            this.Controls.Add(this.plotToChart1);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Y2ComboBox);
            this.Controls.Add(this.Y1ComboBox);
            this.Controls.Add(this.X1ComboBox);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.loadCSVButton);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.textBox2);
            this.Name = "FormPlotter";
            this.Text = "Chart";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Plotter1_FormClosing);
            this.Load += new System.EventHandler(this.Plotter1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox Y2ComboBox;
        private System.Windows.Forms.ComboBox Y1ComboBox;
        private System.Windows.Forms.ComboBox X1ComboBox;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Button loadCSVButton;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button plotToChart1;
        private System.Windows.Forms.Button toChartSettings;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox DelimiterTextBox;
        private System.Windows.Forms.Label label6;
    }
}

