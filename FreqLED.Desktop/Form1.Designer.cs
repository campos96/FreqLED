namespace FreqLED.Desktop
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            PreviewFPSLabel = new Label();
            RedTrackBar = new TrackBar();
            GreenTrackBar = new TrackBar();
            BlueTrackBar = new TrackBar();
            timer1 = new System.Windows.Forms.Timer(components);
            progressBar1 = new ProgressBar();
            AudioDeviceName = new Label();
            label3 = new Label();
            richTextBox1 = new RichTextBox();
            comboBox1 = new ComboBox();
            Aux1TrackBar = new TrackBar();
            Aux2Trackbar = new TrackBar();
            tableLayoutPanel2 = new TableLayoutPanel();
            flowLayoutPanel2 = new FlowLayoutPanel();
            tableLayoutPanel1 = new TableLayoutPanel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            label4 = new Label();
            RedTrackbarLabel = new Label();
            GreenTrackbarLabel = new Label();
            BlueTrackbarLabel = new Label();
            Aux1TrackbarLabel = new Label();
            Aux2TrackbarLabel = new Label();
            RedTrackBarColor = new PictureBox();
            GreenTrackBarColor = new PictureBox();
            BlueTrackBarColor = new PictureBox();
            TrackBarsColor = new PictureBox();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            DevicesComboBox = new ComboBox();
            label10 = new Label();
            AudioDeviceType = new Label();
            COMDevicesComboBox = new ComboBox();
            ConnectCOMDeviceButton = new Button();
            RefreshCOMDevicesButton = new Button();
            ((System.ComponentModel.ISupportInitialize)RedTrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)GreenTrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)BlueTrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Aux1TrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Aux2Trackbar).BeginInit();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)RedTrackBarColor).BeginInit();
            ((System.ComponentModel.ISupportInitialize)GreenTrackBarColor).BeginInit();
            ((System.ComponentModel.ISupportInitialize)BlueTrackBarColor).BeginInit();
            ((System.ComponentModel.ISupportInitialize)TrackBarsColor).BeginInit();
            SuspendLayout();
            // 
            // backgroundWorker1
            // 
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;
            backgroundWorker1.DoWork += backgroundWorker1_DoWork;
            backgroundWorker1.ProgressChanged += backgroundWorker1_ProgressChanged;
            // 
            // PreviewFPSLabel
            // 
            PreviewFPSLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            PreviewFPSLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            PreviewFPSLabel.ForeColor = Color.Silver;
            PreviewFPSLabel.Location = new Point(1119, 576);
            PreviewFPSLabel.Name = "PreviewFPSLabel";
            PreviewFPSLabel.Size = new Size(50, 17);
            PreviewFPSLabel.TabIndex = 5;
            PreviewFPSLabel.Text = "FPS 0";
            PreviewFPSLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // RedTrackBar
            // 
            RedTrackBar.BackColor = Color.Black;
            RedTrackBar.Location = new Point(85, 182);
            RedTrackBar.Maximum = 255;
            RedTrackBar.Name = "RedTrackBar";
            RedTrackBar.Size = new Size(352, 45);
            RedTrackBar.SmallChange = 5;
            RedTrackBar.TabIndex = 6;
            RedTrackBar.TickFrequency = 5;
            RedTrackBar.TickStyle = TickStyle.Both;
            RedTrackBar.ValueChanged += RedTrackBar_ValueChanged;
            // 
            // GreenTrackBar
            // 
            GreenTrackBar.BackColor = Color.Black;
            GreenTrackBar.Location = new Point(85, 233);
            GreenTrackBar.Maximum = 255;
            GreenTrackBar.Name = "GreenTrackBar";
            GreenTrackBar.Size = new Size(352, 45);
            GreenTrackBar.SmallChange = 5;
            GreenTrackBar.TabIndex = 7;
            GreenTrackBar.TickFrequency = 5;
            GreenTrackBar.TickStyle = TickStyle.Both;
            GreenTrackBar.ValueChanged += GreenTrackBar_ValueChanged;
            // 
            // BlueTrackBar
            // 
            BlueTrackBar.BackColor = Color.Black;
            BlueTrackBar.Location = new Point(85, 284);
            BlueTrackBar.Maximum = 255;
            BlueTrackBar.Name = "BlueTrackBar";
            BlueTrackBar.Size = new Size(352, 45);
            BlueTrackBar.SmallChange = 5;
            BlueTrackBar.TabIndex = 8;
            BlueTrackBar.TickFrequency = 5;
            BlueTrackBar.TickStyle = TickStyle.Both;
            BlueTrackBar.ValueChanged += BlueTrackBar_ValueChanged;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 25;
            timer1.Tick += timer1_Tick;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(43, 109);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(394, 20);
            progressBar1.TabIndex = 9;
            // 
            // AudioDeviceName
            // 
            AudioDeviceName.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            AudioDeviceName.ForeColor = Color.Silver;
            AudioDeviceName.Location = new Point(43, 79);
            AudioDeviceName.Name = "AudioDeviceName";
            AudioDeviceName.Size = new Size(270, 27);
            AudioDeviceName.TabIndex = 10;
            AudioDeviceName.Text = "Audio Device Name";
            AudioDeviceName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            label3.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Silver;
            label3.Location = new Point(443, 98);
            label3.Name = "label3";
            label3.Size = new Size(30, 45);
            label3.TabIndex = 11;
            label3.Text = "0";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // richTextBox1
            // 
            richTextBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            richTextBox1.BackColor = Color.Black;
            richTextBox1.BorderStyle = BorderStyle.None;
            richTextBox1.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            richTextBox1.ForeColor = Color.Silver;
            richTextBox1.Location = new Point(903, 41);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(266, 524);
            richTextBox1.TabIndex = 12;
            richTextBox1.Text = "";
            // 
            // comboBox1
            // 
            comboBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            comboBox1.BackColor = Color.Black;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FlatStyle = FlatStyle.Flat;
            comboBox1.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox1.ForeColor = Color.Silver;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(527, 12);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(363, 25);
            comboBox1.TabIndex = 13;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // Aux1TrackBar
            // 
            Aux1TrackBar.BackColor = Color.Black;
            Aux1TrackBar.Location = new Point(43, 335);
            Aux1TrackBar.Maximum = 255;
            Aux1TrackBar.Name = "Aux1TrackBar";
            Aux1TrackBar.Size = new Size(394, 45);
            Aux1TrackBar.SmallChange = 5;
            Aux1TrackBar.TabIndex = 15;
            Aux1TrackBar.TickFrequency = 5;
            Aux1TrackBar.TickStyle = TickStyle.Both;
            Aux1TrackBar.ValueChanged += Aux1TrackBar_ValueChanged;
            // 
            // Aux2Trackbar
            // 
            Aux2Trackbar.BackColor = Color.Black;
            Aux2Trackbar.Location = new Point(43, 386);
            Aux2Trackbar.Maximum = 255;
            Aux2Trackbar.Name = "Aux2Trackbar";
            Aux2Trackbar.Size = new Size(394, 45);
            Aux2Trackbar.SmallChange = 5;
            Aux2Trackbar.TabIndex = 16;
            Aux2Trackbar.TickFrequency = 5;
            Aux2Trackbar.TickStyle = TickStyle.Both;
            Aux2Trackbar.ValueChanged += Aux2Trackbar_ValueChanged;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel2.BackColor = Color.Black;
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(flowLayoutPanel2, 0, 0);
            tableLayoutPanel2.Location = new Point(12, 596);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(1157, 73);
            tableLayoutPanel2.TabIndex = 18;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Anchor = AnchorStyles.None;
            flowLayoutPanel2.AutoSize = true;
            flowLayoutPanel2.BackColor = Color.FromArgb(20, 20, 20);
            flowLayoutPanel2.Location = new Point(578, 36);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(0, 0);
            flowLayoutPanel2.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.BackColor = Color.Black;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(flowLayoutPanel1, 0, 0);
            tableLayoutPanel1.Location = new Point(479, 41);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(411, 524);
            tableLayoutPanel1.TabIndex = 19;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Anchor = AnchorStyles.None;
            flowLayoutPanel1.AutoSize = true;
            flowLayoutPanel1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            flowLayoutPanel1.ForeColor = Color.Silver;
            flowLayoutPanel1.Location = new Point(205, 262);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(0, 0);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label4.BackColor = Color.Black;
            label4.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.Silver;
            label4.Location = new Point(902, 12);
            label4.Name = "label4";
            label4.Size = new Size(266, 26);
            label4.TabIndex = 20;
            label4.Text = "TX/RX Errors";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // RedTrackbarLabel
            // 
            RedTrackbarLabel.BackColor = Color.FromArgb(26, 26, 26);
            RedTrackbarLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            RedTrackbarLabel.ForeColor = Color.Silver;
            RedTrackbarLabel.Location = new Point(443, 182);
            RedTrackbarLabel.Name = "RedTrackbarLabel";
            RedTrackbarLabel.Size = new Size(30, 45);
            RedTrackbarLabel.TabIndex = 21;
            RedTrackbarLabel.Text = "0";
            RedTrackbarLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // GreenTrackbarLabel
            // 
            GreenTrackbarLabel.BackColor = Color.FromArgb(26, 26, 26);
            GreenTrackbarLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            GreenTrackbarLabel.ForeColor = Color.Silver;
            GreenTrackbarLabel.Location = new Point(443, 233);
            GreenTrackbarLabel.Name = "GreenTrackbarLabel";
            GreenTrackbarLabel.Size = new Size(30, 45);
            GreenTrackbarLabel.TabIndex = 22;
            GreenTrackbarLabel.Text = "0";
            GreenTrackbarLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // BlueTrackbarLabel
            // 
            BlueTrackbarLabel.BackColor = Color.FromArgb(26, 26, 26);
            BlueTrackbarLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BlueTrackbarLabel.ForeColor = Color.Silver;
            BlueTrackbarLabel.Location = new Point(443, 284);
            BlueTrackbarLabel.Name = "BlueTrackbarLabel";
            BlueTrackbarLabel.Size = new Size(30, 45);
            BlueTrackbarLabel.TabIndex = 23;
            BlueTrackbarLabel.Text = "0";
            BlueTrackbarLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Aux1TrackbarLabel
            // 
            Aux1TrackbarLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Aux1TrackbarLabel.ForeColor = Color.Silver;
            Aux1TrackbarLabel.Location = new Point(443, 335);
            Aux1TrackbarLabel.Name = "Aux1TrackbarLabel";
            Aux1TrackbarLabel.Size = new Size(30, 45);
            Aux1TrackbarLabel.TabIndex = 24;
            Aux1TrackbarLabel.Text = "0";
            Aux1TrackbarLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Aux2TrackbarLabel
            // 
            Aux2TrackbarLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Aux2TrackbarLabel.ForeColor = Color.Silver;
            Aux2TrackbarLabel.Location = new Point(443, 386);
            Aux2TrackbarLabel.Name = "Aux2TrackbarLabel";
            Aux2TrackbarLabel.Size = new Size(30, 45);
            Aux2TrackbarLabel.TabIndex = 25;
            Aux2TrackbarLabel.Text = "0";
            Aux2TrackbarLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // RedTrackBarColor
            // 
            RedTrackBarColor.BackColor = Color.Black;
            RedTrackBarColor.Location = new Point(43, 182);
            RedTrackBarColor.Name = "RedTrackBarColor";
            RedTrackBarColor.Size = new Size(15, 45);
            RedTrackBarColor.TabIndex = 26;
            RedTrackBarColor.TabStop = false;
            // 
            // GreenTrackBarColor
            // 
            GreenTrackBarColor.BackColor = Color.Black;
            GreenTrackBarColor.Location = new Point(43, 233);
            GreenTrackBarColor.Name = "GreenTrackBarColor";
            GreenTrackBarColor.Size = new Size(15, 45);
            GreenTrackBarColor.TabIndex = 27;
            GreenTrackBarColor.TabStop = false;
            // 
            // BlueTrackBarColor
            // 
            BlueTrackBarColor.BackColor = Color.Black;
            BlueTrackBarColor.Location = new Point(43, 284);
            BlueTrackBarColor.Name = "BlueTrackBarColor";
            BlueTrackBarColor.Size = new Size(15, 45);
            BlueTrackBarColor.TabIndex = 28;
            BlueTrackBarColor.TabStop = false;
            // 
            // TrackBarsColor
            // 
            TrackBarsColor.BackColor = Color.Black;
            TrackBarsColor.Location = new Point(64, 182);
            TrackBarsColor.Name = "TrackBarsColor";
            TrackBarsColor.Size = new Size(15, 147);
            TrackBarsColor.TabIndex = 29;
            TrackBarsColor.TabStop = false;
            // 
            // label5
            // 
            label5.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.Silver;
            label5.Location = new Point(12, 386);
            label5.Name = "label5";
            label5.Size = new Size(25, 45);
            label5.TabIndex = 34;
            label5.Text = "A2";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            label6.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.Silver;
            label6.Location = new Point(12, 335);
            label6.Name = "label6";
            label6.Size = new Size(25, 45);
            label6.TabIndex = 33;
            label6.Text = "A1";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            label7.BackColor = Color.FromArgb(26, 26, 26);
            label7.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.Silver;
            label7.Location = new Point(12, 284);
            label7.Name = "label7";
            label7.Size = new Size(25, 45);
            label7.TabIndex = 32;
            label7.Text = "B";
            label7.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            label8.BackColor = Color.FromArgb(26, 26, 26);
            label8.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.Silver;
            label8.Location = new Point(12, 233);
            label8.Name = "label8";
            label8.Size = new Size(25, 45);
            label8.TabIndex = 31;
            label8.Text = "G";
            label8.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            label9.BackColor = Color.FromArgb(26, 26, 26);
            label9.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.Silver;
            label9.Location = new Point(12, 182);
            label9.Name = "label9";
            label9.Size = new Size(25, 45);
            label9.TabIndex = 30;
            label9.Text = "R";
            label9.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // DevicesComboBox
            // 
            DevicesComboBox.BackColor = Color.Black;
            DevicesComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            DevicesComboBox.FlatStyle = FlatStyle.Flat;
            DevicesComboBox.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            DevicesComboBox.ForeColor = Color.Silver;
            DevicesComboBox.FormattingEnabled = true;
            DevicesComboBox.Location = new Point(40, 41);
            DevicesComboBox.Name = "DevicesComboBox";
            DevicesComboBox.Size = new Size(397, 25);
            DevicesComboBox.TabIndex = 35;
            DevicesComboBox.SelectedIndexChanged += DevicesComboBox_SelectedIndexChanged;
            // 
            // label10
            // 
            label10.BackColor = Color.FromArgb(26, 26, 26);
            label10.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label10.ForeColor = Color.Silver;
            label10.Location = new Point(12, 98);
            label10.Name = "label10";
            label10.Size = new Size(25, 45);
            label10.TabIndex = 37;
            label10.Text = "V";
            label10.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // AudioDeviceType
            // 
            AudioDeviceType.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            AudioDeviceType.ForeColor = Color.Silver;
            AudioDeviceType.Location = new Point(319, 79);
            AudioDeviceType.Name = "AudioDeviceType";
            AudioDeviceType.Size = new Size(118, 27);
            AudioDeviceType.TabIndex = 38;
            AudioDeviceType.Text = "Device Type";
            AudioDeviceType.TextAlign = ContentAlignment.MiddleRight;
            // 
            // COMDevicesComboBox
            // 
            COMDevicesComboBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            COMDevicesComboBox.BackColor = Color.Black;
            COMDevicesComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            COMDevicesComboBox.FlatStyle = FlatStyle.Flat;
            COMDevicesComboBox.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            COMDevicesComboBox.ForeColor = Color.Silver;
            COMDevicesComboBox.FormattingEnabled = true;
            COMDevicesComboBox.Location = new Point(40, 509);
            COMDevicesComboBox.Name = "COMDevicesComboBox";
            COMDevicesComboBox.Size = new Size(397, 25);
            COMDevicesComboBox.TabIndex = 39;
            // 
            // ConnectCOMDeviceButton
            // 
            ConnectCOMDeviceButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            ConnectCOMDeviceButton.BackColor = Color.Black;
            ConnectCOMDeviceButton.FlatAppearance.BorderColor = Color.Gray;
            ConnectCOMDeviceButton.FlatStyle = FlatStyle.Flat;
            ConnectCOMDeviceButton.Location = new Point(340, 540);
            ConnectCOMDeviceButton.Name = "ConnectCOMDeviceButton";
            ConnectCOMDeviceButton.Size = new Size(97, 25);
            ConnectCOMDeviceButton.TabIndex = 40;
            ConnectCOMDeviceButton.Text = "Connect";
            ConnectCOMDeviceButton.UseVisualStyleBackColor = false;
            ConnectCOMDeviceButton.Click += ConnectCOMDeviceButton_Click;
            // 
            // RefreshCOMDevicesButton
            // 
            RefreshCOMDevicesButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            RefreshCOMDevicesButton.BackColor = Color.Black;
            RefreshCOMDevicesButton.FlatAppearance.BorderColor = Color.Gray;
            RefreshCOMDevicesButton.FlatStyle = FlatStyle.Flat;
            RefreshCOMDevicesButton.Location = new Point(40, 540);
            RefreshCOMDevicesButton.Name = "RefreshCOMDevicesButton";
            RefreshCOMDevicesButton.Size = new Size(97, 25);
            RefreshCOMDevicesButton.TabIndex = 41;
            RefreshCOMDevicesButton.Text = "Refresh";
            RefreshCOMDevicesButton.UseVisualStyleBackColor = false;
            RefreshCOMDevicesButton.Click += RefreshCOMDevicesButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(26, 26, 26);
            ClientSize = new Size(1180, 681);
            Controls.Add(RefreshCOMDevicesButton);
            Controls.Add(ConnectCOMDeviceButton);
            Controls.Add(COMDevicesComboBox);
            Controls.Add(AudioDeviceType);
            Controls.Add(DevicesComboBox);
            Controls.Add(label10);
            Controls.Add(progressBar1);
            Controls.Add(label5);
            Controls.Add(AudioDeviceName);
            Controls.Add(label6);
            Controls.Add(label3);
            Controls.Add(label7);
            Controls.Add(label8);
            Controls.Add(label9);
            Controls.Add(TrackBarsColor);
            Controls.Add(BlueTrackBarColor);
            Controls.Add(GreenTrackBarColor);
            Controls.Add(RedTrackBarColor);
            Controls.Add(Aux2TrackbarLabel);
            Controls.Add(Aux1TrackbarLabel);
            Controls.Add(BlueTrackbarLabel);
            Controls.Add(GreenTrackbarLabel);
            Controls.Add(RedTrackbarLabel);
            Controls.Add(label4);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(tableLayoutPanel2);
            Controls.Add(Aux2Trackbar);
            Controls.Add(Aux1TrackBar);
            Controls.Add(comboBox1);
            Controls.Add(richTextBox1);
            Controls.Add(BlueTrackBar);
            Controls.Add(GreenTrackBar);
            Controls.Add(RedTrackBar);
            Controls.Add(PreviewFPSLabel);
            ForeColor = Color.White;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FreqLED Studio";
            WindowState = FormWindowState.Maximized;
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)RedTrackBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)GreenTrackBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)BlueTrackBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)Aux1TrackBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)Aux2Trackbar).EndInit();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)RedTrackBarColor).EndInit();
            ((System.ComponentModel.ISupportInitialize)GreenTrackBarColor).EndInit();
            ((System.ComponentModel.ISupportInitialize)BlueTrackBarColor).EndInit();
            ((System.ComponentModel.ISupportInitialize)TrackBarsColor).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Label PreviewFPSLabel;
        private TrackBar RedTrackBar;
        private TrackBar GreenTrackBar;
        private TrackBar BlueTrackBar;
        private System.Windows.Forms.Timer timer1;
        private ProgressBar progressBar1;
        private Label AudioDeviceName;
        private Label label3;
        private RichTextBox richTextBox1;
        private ComboBox comboBox1;
        private TrackBar Aux1TrackBar;
        private TrackBar Aux2Trackbar;
        private TableLayoutPanel tableLayoutPanel2;
        private FlowLayoutPanel flowLayoutPanel2;
        private TableLayoutPanel tableLayoutPanel1;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label label4;
        private Label RedTrackbarLabel;
        private Label GreenTrackbarLabel;
        private Label BlueTrackbarLabel;
        private Label Aux1TrackbarLabel;
        private Label Aux2TrackbarLabel;
        private PictureBox RedTrackBarColor;
        private PictureBox GreenTrackBarColor;
        private PictureBox BlueTrackBarColor;
        private PictureBox TrackBarsColor;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private ComboBox DevicesComboBox;
        private Label label10;
        private Label AudioDeviceType;
        private ComboBox COMDevicesComboBox;
        private Button ConnectCOMDeviceButton;
        private Button RefreshCOMDevicesButton;
    }
}
