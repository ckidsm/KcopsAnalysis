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
            PlaybackFunctionPanel = new TableLayoutPanel();
            trackBar1 = new TrackBar();
            lblPlayerTime = new Label();
            ButtonZoomIn = new FontAwesome.Sharp.IconButton();
            ButtonZoomOut = new FontAwesome.Sharp.IconButton();
            btnSpeedUp = new FontAwesome.Sharp.IconButton();
            BtnSpeedDown = new FontAwesome.Sharp.IconButton();
            PlayButtonPanel = new TableLayoutPanel();
            ButtonPlaying = new FontAwesome.Sharp.IconButton();
            BtnForward = new FontAwesome.Sharp.IconButton();
            BtnCapture = new FontAwesome.Sharp.IconButton();
            BtnBackward = new FontAwesome.Sharp.IconButton();
            InformationPanel = new TableLayoutPanel();
            groupBox1 = new GroupBox();
            LblFps = new Label();
            MovieSpeedNum = new NumericUpDown();
            winChartViewer = new ChartDirector.WinChartViewer();
            progressBar1 = new ProgressBar();
            lblStstus = new Label();
            MovieInfo = new GroupBox();
            dataGridView1 = new DataGridView();
            rightLayoutPanel = new TableLayoutPanel();
            BtnExit = new FontAwesome.Sharp.IconButton();
            iconBtnFileOpen = new FontAwesome.Sharp.IconButton();
            iconBtnAnalyze = new FontAwesome.Sharp.IconButton();
            btnRePlay = new FontAwesome.Sharp.IconButton();
            LeftMainPanel.SuspendLayout();
            PlaybackFunctionPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            PlayButtonPanel.SuspendLayout();
            InformationPanel.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)MovieSpeedNum).BeginInit();
            ((System.ComponentModel.ISupportInitialize)winChartViewer).BeginInit();
            MovieInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            rightLayoutPanel.SuspendLayout();
            SuspendLayout();
            // 
            // LeftMainPanel
            // 
            LeftMainPanel.ColumnCount = 1;
            LeftMainPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            LeftMainPanel.Controls.Add(PlaybackFunctionPanel, 0, 1);
            LeftMainPanel.Controls.Add(PlayButtonPanel, 0, 2);
            LeftMainPanel.Controls.Add(InformationPanel, 0, 4);
            LeftMainPanel.Dock = DockStyle.Top;
            LeftMainPanel.Font = new Font("나눔고딕", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            LeftMainPanel.Location = new Point(0, 0);
            LeftMainPanel.Name = "LeftMainPanel";
            LeftMainPanel.RowCount = 5;
            LeftMainPanel.RowStyles.Add(new RowStyle());
            LeftMainPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10.1754389F));
            LeftMainPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 8.636364F));
            LeftMainPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 1.00376415F));
            LeftMainPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 80.4266F));
            LeftMainPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            LeftMainPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            LeftMainPanel.Size = new Size(1054, 865);
            LeftMainPanel.TabIndex = 0;
            // 
            // PlaybackFunctionPanel
            // 
            PlaybackFunctionPanel.ColumnCount = 6;
            PlaybackFunctionPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            PlaybackFunctionPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 31.19159F));
            PlaybackFunctionPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.86616F));
            PlaybackFunctionPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.1830349F));
            PlaybackFunctionPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15.7366076F));
            PlaybackFunctionPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 149F));
            PlaybackFunctionPanel.Controls.Add(trackBar1, 1, 0);
            PlaybackFunctionPanel.Controls.Add(lblPlayerTime, 0, 0);
            PlaybackFunctionPanel.Controls.Add(ButtonZoomIn, 2, 0);
            PlaybackFunctionPanel.Controls.Add(ButtonZoomOut, 3, 0);
            PlaybackFunctionPanel.Controls.Add(btnSpeedUp, 4, 0);
            PlaybackFunctionPanel.Controls.Add(BtnSpeedDown, 5, 0);
            PlaybackFunctionPanel.Dock = DockStyle.Fill;
            PlaybackFunctionPanel.ForeColor = SystemColors.ControlLight;
            PlaybackFunctionPanel.Location = new Point(3, 3);
            PlaybackFunctionPanel.Name = "PlaybackFunctionPanel";
            PlaybackFunctionPanel.RowCount = 2;
            PlaybackFunctionPanel.RowStyles.Add(new RowStyle());
            PlaybackFunctionPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            PlaybackFunctionPanel.Size = new Size(1048, 81);
            PlaybackFunctionPanel.TabIndex = 1;
            // 
            // trackBar1
            // 
            trackBar1.Dock = DockStyle.Fill;
            trackBar1.Location = new Point(182, 3);
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size(274, 69);
            trackBar1.TabIndex = 2;
            trackBar1.Scroll += trackBar1_Scroll;
            trackBar1.ValueChanged += trackBar1_ValueChanged;
            // 
            // lblPlayerTime
            // 
            lblPlayerTime.BackColor = Color.FromArgb(21, 101, 192);
            lblPlayerTime.Dock = DockStyle.Fill;
            lblPlayerTime.Font = new Font("나눔고딕", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            lblPlayerTime.ForeColor = Color.White;
            lblPlayerTime.Location = new Point(3, 0);
            lblPlayerTime.Name = "lblPlayerTime";
            lblPlayerTime.Size = new Size(173, 75);
            lblPlayerTime.TabIndex = 2;
            lblPlayerTime.Text = "영상 재생 시간";
            lblPlayerTime.TextAlign = ContentAlignment.MiddleCenter;
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
            ButtonZoomIn.Location = new Point(462, 3);
            ButtonZoomIn.Name = "ButtonZoomIn";
            ButtonZoomIn.Size = new Size(145, 69);
            ButtonZoomIn.TabIndex = 4;
            ButtonZoomIn.Text = "화면 확대";
            ButtonZoomIn.TextAlign = ContentAlignment.MiddleRight;
            ButtonZoomIn.UseVisualStyleBackColor = false;
            ButtonZoomIn.Click += ButtonZoomIn_Click;
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
            ButtonZoomOut.ImageAlign = ContentAlignment.MiddleRight;
            ButtonZoomOut.Location = new Point(613, 3);
            ButtonZoomOut.Name = "ButtonZoomOut";
            ButtonZoomOut.Size = new Size(139, 69);
            ButtonZoomOut.TabIndex = 5;
            ButtonZoomOut.Text = "화면축소";
            ButtonZoomOut.TextAlign = ContentAlignment.MiddleLeft;
            ButtonZoomOut.UseVisualStyleBackColor = false;
            ButtonZoomOut.Click += ButtonZoomOut_Click;
            // 
            // btnSpeedUp
            // 
            btnSpeedUp.BackColor = Color.FromArgb(21, 101, 192);
            btnSpeedUp.Dock = DockStyle.Fill;
            btnSpeedUp.FlatStyle = FlatStyle.Flat;
            btnSpeedUp.ForeColor = Color.White;
            btnSpeedUp.IconChar = FontAwesome.Sharp.IconChar.PlusCircle;
            btnSpeedUp.IconColor = Color.Gainsboro;
            btnSpeedUp.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnSpeedUp.IconSize = 32;
            btnSpeedUp.ImageAlign = ContentAlignment.MiddleLeft;
            btnSpeedUp.Location = new Point(758, 3);
            btnSpeedUp.Name = "btnSpeedUp";
            btnSpeedUp.Size = new Size(135, 69);
            btnSpeedUp.TabIndex = 7;
            btnSpeedUp.Text = "속도 증가";
            btnSpeedUp.TextAlign = ContentAlignment.MiddleRight;
            btnSpeedUp.UseVisualStyleBackColor = false;
            btnSpeedUp.Click += btnSpeedUp_Click;
            // 
            // BtnSpeedDown
            // 
            BtnSpeedDown.BackColor = Color.FromArgb(21, 101, 192);
            BtnSpeedDown.Dock = DockStyle.Fill;
            BtnSpeedDown.FlatStyle = FlatStyle.Flat;
            BtnSpeedDown.ForeColor = Color.White;
            BtnSpeedDown.IconChar = FontAwesome.Sharp.IconChar.Minus;
            BtnSpeedDown.IconColor = Color.Gainsboro;
            BtnSpeedDown.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnSpeedDown.IconSize = 32;
            BtnSpeedDown.ImageAlign = ContentAlignment.MiddleRight;
            BtnSpeedDown.Location = new Point(899, 3);
            BtnSpeedDown.Name = "BtnSpeedDown";
            BtnSpeedDown.Size = new Size(146, 69);
            BtnSpeedDown.TabIndex = 8;
            BtnSpeedDown.Text = "속도 감소";
            BtnSpeedDown.UseVisualStyleBackColor = false;
            BtnSpeedDown.Click += BtnSpeedDown_Click;
            // 
            // PlayButtonPanel
            // 
            PlayButtonPanel.AutoScroll = true;
            PlayButtonPanel.AutoSize = true;
            PlayButtonPanel.ColumnCount = 4;
            PlayButtonPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 29.2517014F));
            PlayButtonPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70.7483F));
            PlayButtonPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 182F));
            PlayButtonPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 129F));
            PlayButtonPanel.Controls.Add(ButtonPlaying, 1, 0);
            PlayButtonPanel.Controls.Add(BtnForward, 2, 0);
            PlayButtonPanel.Controls.Add(BtnCapture, 3, 0);
            PlayButtonPanel.Controls.Add(BtnBackward, 0, 0);
            PlayButtonPanel.Dock = DockStyle.Fill;
            PlayButtonPanel.Location = new Point(3, 90);
            PlayButtonPanel.Name = "PlayButtonPanel";
            PlayButtonPanel.RowCount = 1;
            PlayButtonPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            PlayButtonPanel.Size = new Size(1048, 68);
            PlayButtonPanel.TabIndex = 1;
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
            ButtonPlaying.Size = new Size(515, 62);
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
            BtnForward.Size = new Size(176, 62);
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
            BtnCapture.Size = new Size(124, 62);
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
            BtnBackward.Size = new Size(209, 62);
            BtnBackward.TabIndex = 0;
            BtnBackward.UseVisualStyleBackColor = false;
            BtnBackward.Click += BtnBackward_Click;
            // 
            // InformationPanel
            // 
            InformationPanel.ColumnCount = 1;
            InformationPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            InformationPanel.Controls.Add(groupBox1, 0, 0);
            InformationPanel.Controls.Add(progressBar1, 0, 2);
            InformationPanel.Controls.Add(lblStstus, 0, 1);
            InformationPanel.Dock = DockStyle.Fill;
            InformationPanel.Location = new Point(3, 172);
            InformationPanel.Name = "InformationPanel";
            InformationPanel.RowCount = 3;
            InformationPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 84.46602F));
            InformationPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 15.53398F));
            InformationPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 36F));
            InformationPanel.Size = new Size(1048, 690);
            InformationPanel.TabIndex = 6;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(LblFps);
            groupBox1.Controls.Add(MovieSpeedNum);
            groupBox1.Controls.Add(winChartViewer);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(3, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1042, 546);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "분석결과";
            // 
            // LblFps
            // 
            LblFps.BackColor = Color.FromArgb(21, 101, 192);
            LblFps.FlatStyle = FlatStyle.Flat;
            LblFps.Font = new Font("나눔고딕 ExtraBold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            LblFps.ForeColor = Color.White;
            LblFps.Location = new Point(942, 103);
            LblFps.Name = "LblFps";
            LblFps.Size = new Size(109, 75);
            LblFps.TabIndex = 3;
            LblFps.Text = "Frames Per Second";
            LblFps.TextAlign = ContentAlignment.MiddleCenter;
            LblFps.Visible = false;
            // 
            // MovieSpeedNum
            // 
            MovieSpeedNum.BackColor = Color.FromArgb(21, 101, 192);
            MovieSpeedNum.BorderStyle = BorderStyle.None;
            MovieSpeedNum.Enabled = false;
            MovieSpeedNum.Font = new Font("나눔고딕 ExtraBold", 17.9999981F, FontStyle.Bold, GraphicsUnit.Point);
            MovieSpeedNum.ForeColor = Color.White;
            MovieSpeedNum.Location = new Point(971, 18);
            MovieSpeedNum.Margin = new Padding(3, 25, 3, 3);
            MovieSpeedNum.Maximum = new decimal(new int[] { 3, 0, 0, 0 });
            MovieSpeedNum.Minimum = new decimal(new int[] { 3, 0, 0, int.MinValue });
            MovieSpeedNum.Name = "MovieSpeedNum";
            MovieSpeedNum.Size = new Size(71, 31);
            MovieSpeedNum.TabIndex = 6;
            MovieSpeedNum.TextAlign = HorizontalAlignment.Center;
            MovieSpeedNum.Visible = false;
            MovieSpeedNum.ValueChanged += numericUpDown1_ValueChanged_1;
            MovieSpeedNum.KeyDown += numericUpDown1_KeyDown;
            MovieSpeedNum.KeyUp += numericUpDown1_KeyUp;
            MovieSpeedNum.MouseDown += numericUpDown1_MouseDown;
            MovieSpeedNum.MouseUp += numericUpDown1_MouseUp;
            // 
            // winChartViewer
            // 
            winChartViewer.Dock = DockStyle.Fill;
            winChartViewer.Location = new Point(3, 28);
            winChartViewer.Name = "winChartViewer";
            winChartViewer.Size = new Size(1036, 515);
            winChartViewer.TabIndex = 0;
            winChartViewer.TabStop = false;
            winChartViewer.Visible = false;
            winChartViewer.Click += winChartViewer_Click;
            winChartViewer.DoubleClick += winChartViewer_DoubleClick;
            // 
            // progressBar1
            // 
            progressBar1.Dock = DockStyle.Fill;
            progressBar1.Location = new Point(3, 656);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(1042, 31);
            progressBar1.TabIndex = 2;
            // 
            // lblStstus
            // 
            lblStstus.Dock = DockStyle.Fill;
            lblStstus.Font = new Font("나눔고딕 ExtraBold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblStstus.Location = new Point(3, 552);
            lblStstus.Name = "lblStstus";
            lblStstus.Size = new Size(1042, 101);
            lblStstus.TabIndex = 5;
            lblStstus.Text = "...";
            // 
            // MovieInfo
            // 
            MovieInfo.Controls.Add(dataGridView1);
            MovieInfo.Dock = DockStyle.Fill;
            MovieInfo.Location = new Point(3, 3);
            MovieInfo.Name = "MovieInfo";
            MovieInfo.Size = new Size(431, 302);
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
            dataGridView1.Size = new Size(425, 277);
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
            rightLayoutPanel.RowCount = 6;
            rightLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 35.4838753F));
            rightLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 16.1290321F));
            rightLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 16.1290321F));
            rightLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 16.1290321F));
            rightLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 16.1290321F));
            rightLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            rightLayoutPanel.Size = new Size(437, 889);
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
            BtnExit.Location = new Point(3, 731);
            BtnExit.Name = "BtnExit";
            BtnExit.Size = new Size(431, 134);
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
            iconBtnFileOpen.Location = new Point(3, 311);
            iconBtnFileOpen.Name = "iconBtnFileOpen";
            iconBtnFileOpen.Size = new Size(431, 134);
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
            iconBtnAnalyze.Location = new Point(3, 451);
            iconBtnAnalyze.Name = "iconBtnAnalyze";
            iconBtnAnalyze.Size = new Size(431, 134);
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
            btnRePlay.Location = new Point(3, 591);
            btnRePlay.Name = "btnRePlay";
            btnRePlay.Size = new Size(431, 134);
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
            ClientSize = new Size(1491, 889);
            Controls.Add(LeftMainPanel);
            Controls.Add(rightLayoutPanel);
            ForeColor = SystemColors.ControlLight;
            Name = "FormOpenVideo";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormOpenVideo";
            WindowState = FormWindowState.Maximized;
            Load += FormOpenVideo_Load;
            LeftMainPanel.ResumeLayout(false);
            LeftMainPanel.PerformLayout();
            PlaybackFunctionPanel.ResumeLayout(false);
            PlaybackFunctionPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            PlayButtonPanel.ResumeLayout(false);
            PlayButtonPanel.PerformLayout();
            InformationPanel.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)MovieSpeedNum).EndInit();
            ((System.ComponentModel.ISupportInitialize)winChartViewer).EndInit();
            MovieInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            rightLayoutPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private TableLayoutPanel LeftMainPanel;
        private TableLayoutPanel PlaybackFunctionPanel;
        private Label lblPlayerTime;
        private Label LblFps;
        private TrackBar trackBar1;
        private GroupBox MovieInfo;
        private DataGridView dataGridView1;
        private TableLayoutPanel PlayButtonPanel;
        private FontAwesome.Sharp.IconButton ButtonPlaying;
        private FontAwesome.Sharp.IconButton BtnBackward;
        private FontAwesome.Sharp.IconButton BtnForward;
        private GroupBox groupBox1;
        private Label lblStstus;
        private TableLayoutPanel rightLayoutPanel;
        private FontAwesome.Sharp.IconButton iconBtnFileOpen;
        private FontAwesome.Sharp.IconButton iconBtnAnalyze;
        private FontAwesome.Sharp.IconButton btnRePlay;
        private FontAwesome.Sharp.IconButton BtnExit;
        private ChartDirector.WinChartViewer winChartViewer;
        private FontAwesome.Sharp.IconButton ButtonZoomIn;
        private FontAwesome.Sharp.IconButton ButtonZoomOut;
        private NumericUpDown MovieSpeedNum;
        private ProgressBar progressBar1;
        private FontAwesome.Sharp.IconButton BtnCapture;
        private FontAwesome.Sharp.IconButton btnSpeedUp;
        private FontAwesome.Sharp.IconButton BtnSpeedDown;
        private TableLayoutPanel InformationPanel;
    }
}