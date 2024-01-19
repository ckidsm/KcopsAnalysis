using KcopsAnalysis.Properties;

namespace KcopsAnalysis
{
    partial class FormOpenVideo
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
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            LeftMainPanel = new TableLayoutPanel();
            lblStstus = new Label();
            tableLayoutPanel2 = new TableLayoutPanel();
            ButtonZoomIn = new FontAwesome.Sharp.IconButton();
            trackBar1 = new TrackBar();
            LblFps = new Label();
            lblPlayerTime = new Label();
            ButtonZoomOut = new FontAwesome.Sharp.IconButton();
            numericUpDown1 = new NumericUpDown();
            label1 = new Label();
            tableLayoutPanel3 = new TableLayoutPanel();
            ButtonPlaying = new FontAwesome.Sharp.IconButton();
            BtnForward = new FontAwesome.Sharp.IconButton();
            BtnCapture = new FontAwesome.Sharp.IconButton();
            BtnBackward = new FontAwesome.Sharp.IconButton();
            groupBox1 = new GroupBox();
            progressBar1 = new ProgressBar();
            winChartViewer = new ChartDirector.WinChartViewer();
            pictureBox = new PictureBox();
            MovieInfo = new GroupBox();
            dataGridView1 = new DataGridView();
            rightLayoutPanel = new TableLayoutPanel();
            BtnExit = new FontAwesome.Sharp.IconButton();
            iconBtnFileOpen = new FontAwesome.Sharp.IconButton();
            iconBtnAnalyze = new FontAwesome.Sharp.IconButton();
            btnRePlay = new FontAwesome.Sharp.IconButton();
            LeftMainPanel.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            tableLayoutPanel3.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)winChartViewer).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            MovieInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            rightLayoutPanel.SuspendLayout();
            SuspendLayout();
            // 
            // LeftMainPanel
            // 
            LeftMainPanel.AutoSize = true;
            LeftMainPanel.ColumnCount = 1;
            LeftMainPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            LeftMainPanel.Controls.Add(lblStstus, 0, 4);
            LeftMainPanel.Controls.Add(tableLayoutPanel2, 0, 1);
            LeftMainPanel.Controls.Add(tableLayoutPanel3, 0, 2);
            LeftMainPanel.Controls.Add(groupBox1, 0, 3);
            LeftMainPanel.Dock = DockStyle.Top;
            LeftMainPanel.Font = new Font("나눔고딕", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            LeftMainPanel.Location = new Point(0, 0);
            LeftMainPanel.Name = "LeftMainPanel";
            LeftMainPanel.RowCount = 5;
            LeftMainPanel.RowStyles.Add(new RowStyle());
            LeftMainPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10.1754389F));
            LeftMainPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 8.636364F));
            LeftMainPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 68.97727F));
            LeftMainPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 12.1529493F));
            LeftMainPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            LeftMainPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            LeftMainPanel.Size = new Size(1054, 938);
            LeftMainPanel.TabIndex = 0;
            // 
            // lblStstus
            // 
            lblStstus.Dock = DockStyle.Fill;
            lblStstus.Font = new Font("나눔고딕 ExtraBold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblStstus.Location = new Point(3, 823);
            lblStstus.Name = "lblStstus";
            lblStstus.Size = new Size(1048, 115);
            lblStstus.TabIndex = 5;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 7;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25.7287712F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 17.1102657F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 19.64512F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 17.4904938F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 166F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 91F));
            tableLayoutPanel2.Controls.Add(ButtonZoomIn, 3, 0);
            tableLayoutPanel2.Controls.Add(trackBar1, 1, 0);
            tableLayoutPanel2.Controls.Add(LblFps, 2, 0);
            tableLayoutPanel2.Controls.Add(lblPlayerTime, 0, 0);
            tableLayoutPanel2.Controls.Add(ButtonZoomOut, 4, 0);
            tableLayoutPanel2.Controls.Add(numericUpDown1, 6, 0);
            tableLayoutPanel2.Controls.Add(label1, 5, 0);
            tableLayoutPanel2.Dock = DockStyle.Top;
            tableLayoutPanel2.Location = new Point(3, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle());
            tableLayoutPanel2.Size = new Size(1048, 75);
            tableLayoutPanel2.TabIndex = 1;
            // 
            // ButtonZoomIn
            // 
            ButtonZoomIn.BackColor = Color.FromArgb(21, 101, 192);
            ButtonZoomIn.BackgroundImageLayout = ImageLayout.None;
            ButtonZoomIn.Dock = DockStyle.Fill;
            ButtonZoomIn.FlatAppearance.BorderSize = 0;
            ButtonZoomIn.FlatStyle = FlatStyle.Flat;
            ButtonZoomIn.ForeColor = Color.White;
            ButtonZoomIn.IconChar = FontAwesome.Sharp.IconChar.PlusCircle;
            ButtonZoomIn.IconColor = Color.Gainsboro;
            ButtonZoomIn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ButtonZoomIn.IconSize = 32;
            ButtonZoomIn.ImageAlign = ContentAlignment.MiddleLeft;
            ButtonZoomIn.Location = new Point(499, 3);
            ButtonZoomIn.Name = "ButtonZoomIn";
            ButtonZoomIn.Size = new Size(149, 69);
            ButtonZoomIn.TabIndex = 4;
            ButtonZoomIn.Text = "화면 확대";
            ButtonZoomIn.UseVisualStyleBackColor = false;
            ButtonZoomIn.Click += ButtonZoomIn_Click;
            // 
            // trackBar1
            // 
            trackBar1.Dock = DockStyle.Fill;
            trackBar1.Location = new Point(161, 3);
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size(197, 69);
            trackBar1.TabIndex = 2;
            trackBar1.Scroll += trackBar1_Scroll;
            trackBar1.ValueChanged += trackBar1_ValueChanged;
            // 
            // LblFps
            // 
            LblFps.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            LblFps.BackColor = Color.FromArgb(21, 101, 192);
            LblFps.FlatStyle = FlatStyle.Flat;
            LblFps.Font = new Font("나눔고딕", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            LblFps.ForeColor = Color.White;
            LblFps.Location = new Point(364, 1);
            LblFps.Name = "LblFps";
            LblFps.Size = new Size(129, 72);
            LblFps.TabIndex = 3;
            LblFps.Text = "프레임 번호 ";
            LblFps.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblPlayerTime
            // 
            lblPlayerTime.BackColor = Color.FromArgb(21, 101, 192);
            lblPlayerTime.Dock = DockStyle.Fill;
            lblPlayerTime.Font = new Font("나눔고딕", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            lblPlayerTime.ForeColor = Color.White;
            lblPlayerTime.Location = new Point(3, 0);
            lblPlayerTime.Name = "lblPlayerTime";
            lblPlayerTime.Size = new Size(152, 75);
            lblPlayerTime.TabIndex = 2;
            lblPlayerTime.Text = "영상 재생 시간";
            lblPlayerTime.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ButtonZoomOut
            // 
            ButtonZoomOut.BackColor = Color.FromArgb(21, 101, 192);
            ButtonZoomOut.Dock = DockStyle.Fill;
            ButtonZoomOut.FlatAppearance.BorderSize = 0;
            ButtonZoomOut.FlatStyle = FlatStyle.Flat;
            ButtonZoomOut.ForeColor = Color.White;
            ButtonZoomOut.IconChar = FontAwesome.Sharp.IconChar.Minus;
            ButtonZoomOut.IconColor = Color.Gainsboro;
            ButtonZoomOut.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ButtonZoomOut.IconSize = 32;
            ButtonZoomOut.ImageAlign = ContentAlignment.MiddleLeft;
            ButtonZoomOut.Location = new Point(654, 3);
            ButtonZoomOut.Name = "ButtonZoomOut";
            ButtonZoomOut.Size = new Size(132, 69);
            ButtonZoomOut.TabIndex = 5;
            ButtonZoomOut.Text = "화면축소";
            ButtonZoomOut.UseVisualStyleBackColor = false;
            ButtonZoomOut.Click += ButtonZoomOut_Click;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            numericUpDown1.AutoSize = true;
            numericUpDown1.Font = new Font("나눔고딕 ExtraBold", 17.9999981F, FontStyle.Bold, GraphicsUnit.Point);
            numericUpDown1.Location = new Point(958, 3);
            numericUpDown1.Maximum = new decimal(new int[] { 3, 0, 0, 0 });
            numericUpDown1.Minimum = new decimal(new int[] { 3, 0, 0, int.MinValue });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(87, 35);
            numericUpDown1.TabIndex = 6;
            numericUpDown1.TextAlign = HorizontalAlignment.Center;
            numericUpDown1.ValueChanged += numericUpDown1_ValueChanged_1;
            numericUpDown1.KeyDown += numericUpDown1_KeyDown;
            numericUpDown1.KeyUp += numericUpDown1_KeyUp;
            numericUpDown1.MouseDown += numericUpDown1_MouseDown;
            numericUpDown1.MouseUp += numericUpDown1_MouseUp;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label1.BackColor = Color.FromArgb(21, 101, 192);
            label1.Font = new Font("나눔고딕", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(792, 4);
            label1.Name = "label1";
            label1.Size = new Size(160, 66);
            label1.TabIndex = 7;
            label1.Text = "재생속도 조절";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.AutoScroll = true;
            tableLayoutPanel3.ColumnCount = 4;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 29.2517014F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70.7483F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 182F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 129F));
            tableLayoutPanel3.Controls.Add(ButtonPlaying, 1, 0);
            tableLayoutPanel3.Controls.Add(BtnForward, 2, 0);
            tableLayoutPanel3.Controls.Add(BtnCapture, 3, 0);
            tableLayoutPanel3.Controls.Add(BtnBackward, 0, 0);
            tableLayoutPanel3.Dock = DockStyle.Top;
            tableLayoutPanel3.Location = new Point(3, 98);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.Size = new Size(1048, 61);
            tableLayoutPanel3.TabIndex = 1;
            // 
            // ButtonPlaying
            // 
            ButtonPlaying.AutoSize = true;
            ButtonPlaying.BackColor = Color.FromArgb(21, 101, 192);
            ButtonPlaying.Dock = DockStyle.Fill;
            ButtonPlaying.FlatStyle = FlatStyle.Flat;
            ButtonPlaying.Font = new Font("나눔고딕 ExtraBold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            ButtonPlaying.ForeColor = SystemColors.ButtonFace;
            ButtonPlaying.IconChar = FontAwesome.Sharp.IconChar.Play;
            ButtonPlaying.IconColor = Color.Gainsboro;
            ButtonPlaying.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ButtonPlaying.Location = new Point(218, 3);
            ButtonPlaying.Name = "ButtonPlaying";
            ButtonPlaying.Size = new Size(515, 55);
            ButtonPlaying.TabIndex = 0;
            ButtonPlaying.UseVisualStyleBackColor = false;
            ButtonPlaying.Click += ButtonPlaying_Click;
            // 
            // BtnForward
            // 
            BtnForward.AutoSize = true;
            BtnForward.BackColor = Color.FromArgb(21, 101, 192);
            BtnForward.Dock = DockStyle.Fill;
            BtnForward.FlatStyle = FlatStyle.Flat;
            BtnForward.Font = new Font("나눔고딕 ExtraBold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            BtnForward.ForeColor = SystemColors.ButtonFace;
            BtnForward.IconChar = FontAwesome.Sharp.IconChar.Forward;
            BtnForward.IconColor = Color.Gainsboro;
            BtnForward.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnForward.Location = new Point(739, 3);
            BtnForward.Name = "BtnForward";
            BtnForward.Size = new Size(176, 55);
            BtnForward.TabIndex = 0;
            BtnForward.UseVisualStyleBackColor = false;
            BtnForward.Click += BtnForward_Click;
            // 
            // BtnCapture
            // 
            BtnCapture.AutoSize = true;
            BtnCapture.BackColor = Color.FromArgb(21, 101, 192);
            BtnCapture.Dock = DockStyle.Fill;
            BtnCapture.FlatStyle = FlatStyle.Flat;
            BtnCapture.Font = new Font("나눔고딕 ExtraBold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            BtnCapture.ForeColor = SystemColors.ButtonFace;
            BtnCapture.IconChar = FontAwesome.Sharp.IconChar.Camera;
            BtnCapture.IconColor = Color.Gainsboro;
            BtnCapture.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnCapture.Location = new Point(921, 3);
            BtnCapture.Name = "BtnCapture";
            BtnCapture.Size = new Size(124, 55);
            BtnCapture.TabIndex = 0;
            BtnCapture.UseVisualStyleBackColor = false;
            BtnCapture.Click += BtnCapture_Click;
            // 
            // BtnBackward
            // 
            BtnBackward.AutoSize = true;
            BtnBackward.BackColor = Color.FromArgb(21, 101, 192);
            BtnBackward.Dock = DockStyle.Fill;
            BtnBackward.FlatStyle = FlatStyle.Flat;
            BtnBackward.Font = new Font("나눔고딕 ExtraBold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            BtnBackward.ForeColor = SystemColors.ButtonFace;
            BtnBackward.IconChar = FontAwesome.Sharp.IconChar.Backward;
            BtnBackward.IconColor = Color.Gainsboro;
            BtnBackward.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnBackward.Location = new Point(3, 3);
            BtnBackward.Name = "BtnBackward";
            BtnBackward.Size = new Size(209, 55);
            BtnBackward.TabIndex = 0;
            BtnBackward.UseVisualStyleBackColor = false;
            BtnBackward.Click += BtnBackward_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(progressBar1);
            groupBox1.Controls.Add(winChartViewer);
            groupBox1.Controls.Add(pictureBox);
            groupBox1.Location = new Point(3, 179);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(941, 187);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "분석결과";
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(79, 251);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(100, 23);
            progressBar1.TabIndex = 2;
            // 
            // winChartViewer
            // 
            winChartViewer.Dock = DockStyle.Fill;
            winChartViewer.Location = new Point(3, 28);
            winChartViewer.Name = "winChartViewer";
            winChartViewer.Size = new Size(935, 156);
            winChartViewer.TabIndex = 0;
            winChartViewer.TabStop = false;
            winChartViewer.Visible = false;
            winChartViewer.Click += winChartViewer_Click;
            winChartViewer.DoubleClick += winChartViewer_DoubleClick;
            // 
            // pictureBox
            // 
            pictureBox.Dock = DockStyle.Fill;
            pictureBox.Location = new Point(3, 28);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(935, 156);
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.TabIndex = 1;
            pictureBox.TabStop = false;
            pictureBox.Click += pictureBox_Click;
            pictureBox.DoubleClick += pictureBox_DoubleClick;
            // 
            // MovieInfo
            // 
            MovieInfo.Controls.Add(dataGridView1);
            MovieInfo.Dock = DockStyle.Fill;
            MovieInfo.Location = new Point(3, 3);
            MovieInfo.Name = "MovieInfo";
            MovieInfo.Size = new Size(431, 297);
            MovieInfo.TabIndex = 2;
            MovieInfo.TabStop = false;
            MovieInfo.Text = "영상정보";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ColumnHeadersHeight = 30;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(3, 22);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(425, 272);
            dataGridView1.TabIndex = 3;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            dataGridView1.DoubleClick += dataGridView1_DoubleClick;
            // 
            // rightLayoutPanel
            // 
            rightLayoutPanel.ColumnCount = 1;
            rightLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            rightLayoutPanel.Controls.Add(BtnExit, 0, 4);
            rightLayoutPanel.Controls.Add(iconBtnFileOpen, 0, 1);
            rightLayoutPanel.Controls.Add(MovieInfo, 0, 0);
            rightLayoutPanel.Controls.Add(iconBtnAnalyze, 0, 2);
            rightLayoutPanel.Controls.Add(btnRePlay, 0, 3);
            rightLayoutPanel.Dock = DockStyle.Right;
            rightLayoutPanel.Font = new Font("나눔고딕", 12F, FontStyle.Bold, GraphicsUnit.Point);
            rightLayoutPanel.Location = new Point(1054, 0);
            rightLayoutPanel.Name = "rightLayoutPanel";
            rightLayoutPanel.RowCount = 5;
            rightLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 35.4838753F));
            rightLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 16.1290321F));
            rightLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 16.1290321F));
            rightLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 16.1290321F));
            rightLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 16.1290321F));
            rightLayoutPanel.Size = new Size(437, 855);
            rightLayoutPanel.TabIndex = 3;
            // 
            // BtnExit
            // 
            BtnExit.BackColor = Color.FromArgb(21, 101, 192);
            BtnExit.Dock = DockStyle.Fill;
            BtnExit.FlatStyle = FlatStyle.Flat;
            BtnExit.Font = new Font("나눔고딕 ExtraBold", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            BtnExit.ForeColor = SystemColors.ButtonFace;
            BtnExit.IconChar = FontAwesome.Sharp.IconChar.RightToBracket;
            BtnExit.IconColor = Color.Gainsboro;
            BtnExit.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnExit.Location = new Point(3, 717);
            BtnExit.Name = "BtnExit";
            BtnExit.Size = new Size(431, 135);
            BtnExit.TabIndex = 6;
            BtnExit.Text = "종료";
            BtnExit.TextAlign = ContentAlignment.BottomCenter;
            BtnExit.UseVisualStyleBackColor = false;
            BtnExit.Click += BtnExit_Click;
            // 
            // iconBtnFileOpen
            // 
            iconBtnFileOpen.BackColor = Color.FromArgb(21, 101, 192);
            iconBtnFileOpen.Dock = DockStyle.Fill;
            iconBtnFileOpen.FlatStyle = FlatStyle.Flat;
            iconBtnFileOpen.Font = new Font("나눔고딕 ExtraBold", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            iconBtnFileOpen.ForeColor = SystemColors.ButtonFace;
            iconBtnFileOpen.IconChar = FontAwesome.Sharp.IconChar.FolderOpen;
            iconBtnFileOpen.IconColor = Color.Gainsboro;
            iconBtnFileOpen.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconBtnFileOpen.Location = new Point(3, 306);
            iconBtnFileOpen.Name = "iconBtnFileOpen";
            iconBtnFileOpen.Size = new Size(431, 131);
            iconBtnFileOpen.TabIndex = 3;
            iconBtnFileOpen.Text = "파일열기";
            iconBtnFileOpen.TextAlign = ContentAlignment.BottomCenter;
            iconBtnFileOpen.UseVisualStyleBackColor = false;
            iconBtnFileOpen.Click += iconBtnFileOpen_Click;
            // 
            // iconBtnAnalyze
            // 
            iconBtnAnalyze.BackColor = Color.FromArgb(21, 101, 192);
            iconBtnAnalyze.Dock = DockStyle.Fill;
            iconBtnAnalyze.FlatStyle = FlatStyle.Flat;
            iconBtnAnalyze.Font = new Font("나눔고딕 ExtraBold", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            iconBtnAnalyze.ForeColor = SystemColors.ButtonFace;
            iconBtnAnalyze.IconChar = FontAwesome.Sharp.IconChar.CarCrash;
            iconBtnAnalyze.IconColor = Color.Gainsboro;
            iconBtnAnalyze.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconBtnAnalyze.Location = new Point(3, 443);
            iconBtnAnalyze.Name = "iconBtnAnalyze";
            iconBtnAnalyze.Size = new Size(431, 131);
            iconBtnAnalyze.TabIndex = 4;
            iconBtnAnalyze.Text = "영상분석";
            iconBtnAnalyze.TextAlign = ContentAlignment.BottomCenter;
            iconBtnAnalyze.UseVisualStyleBackColor = false;
            iconBtnAnalyze.Click += iconBtnAnalyze_Click;
            // 
            // btnRePlay
            // 
            btnRePlay.BackColor = Color.FromArgb(21, 101, 192);
            btnRePlay.Dock = DockStyle.Fill;
            btnRePlay.FlatStyle = FlatStyle.Flat;
            btnRePlay.Font = new Font("나눔고딕 ExtraBold", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnRePlay.ForeColor = SystemColors.ButtonFace;
            btnRePlay.IconChar = FontAwesome.Sharp.IconChar.Chalkboard;
            btnRePlay.IconColor = Color.Gainsboro;
            btnRePlay.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnRePlay.Location = new Point(3, 580);
            btnRePlay.Name = "btnRePlay";
            btnRePlay.Size = new Size(431, 131);
            btnRePlay.TabIndex = 5;
            btnRePlay.Text = "설정";
            btnRePlay.TextAlign = ContentAlignment.BottomCenter;
            btnRePlay.UseVisualStyleBackColor = false;
            btnRePlay.Click += btnRePlay_Click;
            // 
            // FormOpenVideo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1491, 855);
            Controls.Add(LeftMainPanel);
            Controls.Add(rightLayoutPanel);
            Name = "FormOpenVideo";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormOpenVideo";
            WindowState = FormWindowState.Maximized;
            Load += FormOpenVideo_Load;
            LeftMainPanel.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)winChartViewer).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            MovieInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            rightLayoutPanel.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private TableLayoutPanel LeftMainPanel;
        private TableLayoutPanel tableLayoutPanel2;
        private Label lblPlayerTime;
        private Label LblFps;
        private TrackBar trackBar1;
        private GroupBox MovieInfo;
        private DataGridView dataGridView1;
        private TableLayoutPanel tableLayoutPanel3;
        private FontAwesome.Sharp.IconButton ButtonPlaying;
        private FontAwesome.Sharp.IconButton BtnBackward;
        private FontAwesome.Sharp.IconButton BtnForward;
        private FontAwesome.Sharp.IconButton BtnCapture;
        private GroupBox groupBox1;
        private Label lblStstus;
        private TableLayoutPanel rightLayoutPanel;
        private FontAwesome.Sharp.IconButton iconBtnFileOpen;
        private FontAwesome.Sharp.IconButton iconBtnAnalyze;
        private FontAwesome.Sharp.IconButton btnRePlay;
        private FontAwesome.Sharp.IconButton BtnExit;
        private ChartDirector.WinChartViewer winChartViewer;
        private PictureBox pictureBox;
        private FontAwesome.Sharp.IconButton ButtonZoomIn;
        private FontAwesome.Sharp.IconButton ButtonZoomOut;
        private NumericUpDown numericUpDown1;
        private ProgressBar progressBar1;
        private Label label1;
    }
}