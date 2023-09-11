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
            progressBar1 = new ProgressBar();
            lblStstus = new Label();
            tableLayoutPanel3 = new TableLayoutPanel();
            ButtonPlaying = new FontAwesome.Sharp.IconButton();
            BtnForward = new FontAwesome.Sharp.IconButton();
            BtnCapture = new FontAwesome.Sharp.IconButton();
            BtnBackward = new FontAwesome.Sharp.IconButton();
            tableLayoutPanel2 = new TableLayoutPanel();
            trackBar1 = new TrackBar();
            LblFps = new Label();
            lblPlayerTime = new Label();
            groupBox1 = new GroupBox();
            winChartViewer = new ChartDirector.WinChartViewer();
            MovieInfo = new GroupBox();
            dataGridView1 = new DataGridView();
            rightLayoutPanel = new TableLayoutPanel();
            BtnExit = new FontAwesome.Sharp.IconButton();
            iconBtnFileOpen = new FontAwesome.Sharp.IconButton();
            iconBtnAnalyze = new FontAwesome.Sharp.IconButton();
            btnRePlay = new FontAwesome.Sharp.IconButton();
            LeftMainPanel.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            groupBox1.SuspendLayout();
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
            LeftMainPanel.Controls.Add(progressBar1, 0, 5);
            LeftMainPanel.Controls.Add(lblStstus, 0, 4);
            LeftMainPanel.Controls.Add(tableLayoutPanel3, 0, 2);
            LeftMainPanel.Controls.Add(tableLayoutPanel2, 0, 1);
            LeftMainPanel.Controls.Add(groupBox1, 0, 3);
            LeftMainPanel.Dock = DockStyle.Fill;
            LeftMainPanel.Font = new Font("나눔고딕", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            LeftMainPanel.Location = new Point(0, 0);
            LeftMainPanel.Name = "LeftMainPanel";
            LeftMainPanel.RowCount = 6;
            LeftMainPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 45.24669F));
            LeftMainPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 5.17448854F));
            LeftMainPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 6.73886871F));
            LeftMainPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 36.70635F));
            LeftMainPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 6.15079355F));
            LeftMainPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 14F));
            LeftMainPanel.Size = new Size(947, 861);
            LeftMainPanel.TabIndex = 0;
            // 
            // progressBar1
            // 
            progressBar1.Dock = DockStyle.Fill;
            progressBar1.Location = new Point(3, 848);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(941, 10);
            progressBar1.TabIndex = 3;
            // 
            // lblStstus
            // 
            lblStstus.Dock = DockStyle.Fill;
            lblStstus.Font = new Font("나눔고딕 ExtraBold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblStstus.Location = new Point(3, 793);
            lblStstus.Name = "lblStstus";
            lblStstus.Size = new Size(941, 52);
            lblStstus.TabIndex = 5;
            lblStstus.Text = "가나라다라 마바사";
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 4;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 29.2517014F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70.7483F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 182F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 129F));
            tableLayoutPanel3.Controls.Add(ButtonPlaying, 1, 0);
            tableLayoutPanel3.Controls.Add(BtnForward, 2, 0);
            tableLayoutPanel3.Controls.Add(BtnCapture, 3, 0);
            tableLayoutPanel3.Controls.Add(BtnBackward, 0, 0);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(3, 429);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.Size = new Size(941, 51);
            tableLayoutPanel3.TabIndex = 1;
            // 
            // ButtonPlaying
            // 
            ButtonPlaying.BackColor = Color.FromArgb(21, 101, 192);
            ButtonPlaying.Dock = DockStyle.Fill;
            ButtonPlaying.FlatStyle = FlatStyle.Flat;
            ButtonPlaying.Font = new Font("나눔고딕 ExtraBold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            ButtonPlaying.ForeColor = SystemColors.ButtonFace;
            ButtonPlaying.IconChar = FontAwesome.Sharp.IconChar.Play;
            ButtonPlaying.IconColor = Color.Gainsboro;
            ButtonPlaying.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ButtonPlaying.Location = new Point(187, 3);
            ButtonPlaying.Name = "ButtonPlaying";
            ButtonPlaying.Size = new Size(439, 45);
            ButtonPlaying.TabIndex = 0;
            ButtonPlaying.UseVisualStyleBackColor = false;
            ButtonPlaying.Click += ButtonPlaying_Click;
            // 
            // BtnForward
            // 
            BtnForward.BackColor = Color.FromArgb(21, 101, 192);
            BtnForward.Dock = DockStyle.Fill;
            BtnForward.FlatStyle = FlatStyle.Flat;
            BtnForward.Font = new Font("나눔고딕 ExtraBold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            BtnForward.ForeColor = SystemColors.ButtonFace;
            BtnForward.IconChar = FontAwesome.Sharp.IconChar.Forward;
            BtnForward.IconColor = Color.Gainsboro;
            BtnForward.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnForward.Location = new Point(632, 3);
            BtnForward.Name = "BtnForward";
            BtnForward.Size = new Size(176, 45);
            BtnForward.TabIndex = 0;
            BtnForward.UseVisualStyleBackColor = false;
            BtnForward.Click += BtnForward_Click;
            // 
            // BtnCapture
            // 
            BtnCapture.BackColor = Color.FromArgb(21, 101, 192);
            BtnCapture.Dock = DockStyle.Fill;
            BtnCapture.FlatStyle = FlatStyle.Flat;
            BtnCapture.Font = new Font("나눔고딕 ExtraBold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            BtnCapture.ForeColor = SystemColors.ButtonFace;
            BtnCapture.IconChar = FontAwesome.Sharp.IconChar.Camera;
            BtnCapture.IconColor = Color.Gainsboro;
            BtnCapture.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnCapture.Location = new Point(814, 3);
            BtnCapture.Name = "BtnCapture";
            BtnCapture.Size = new Size(124, 45);
            BtnCapture.TabIndex = 0;
            BtnCapture.UseVisualStyleBackColor = false;
            BtnCapture.Click += BtnCapture_Click;
            // 
            // BtnBackward
            // 
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
            BtnBackward.Size = new Size(178, 45);
            BtnBackward.TabIndex = 0;
            BtnBackward.UseVisualStyleBackColor = false;
            BtnBackward.Click += BtnBackward_Click;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 3;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 39.9305573F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60.0694427F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 319F));
            tableLayoutPanel2.Controls.Add(trackBar1, 1, 0);
            tableLayoutPanel2.Controls.Add(LblFps, 2, 0);
            tableLayoutPanel2.Controls.Add(lblPlayerTime, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 386);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(941, 37);
            tableLayoutPanel2.TabIndex = 1;
            // 
            // trackBar1
            // 
            trackBar1.Dock = DockStyle.Fill;
            trackBar1.Location = new Point(251, 3);
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size(367, 31);
            trackBar1.TabIndex = 2;
            trackBar1.Scroll += trackBar1_Scroll;
            trackBar1.ValueChanged += trackBar1_ValueChanged;
            // 
            // LblFps
            // 
            LblFps.BackColor = Color.FromArgb(21, 101, 192);
            LblFps.Dock = DockStyle.Fill;
            LblFps.Font = new Font("나눔고딕", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            LblFps.ForeColor = Color.White;
            LblFps.Location = new Point(624, 0);
            LblFps.Name = "LblFps";
            LblFps.Size = new Size(314, 37);
            LblFps.TabIndex = 3;
            LblFps.Text = "프레임 번호 ";
            LblFps.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblPlayerTime
            // 
            lblPlayerTime.BackColor = Color.FromArgb(21, 101, 192);
            lblPlayerTime.Dock = DockStyle.Fill;
            lblPlayerTime.Font = new Font("나눔고딕", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            lblPlayerTime.ForeColor = Color.White;
            lblPlayerTime.Location = new Point(3, 0);
            lblPlayerTime.Name = "lblPlayerTime";
            lblPlayerTime.Size = new Size(242, 37);
            lblPlayerTime.TabIndex = 2;
            lblPlayerTime.Text = "00:00:00";
            lblPlayerTime.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(winChartViewer);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(3, 486);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(941, 304);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "분석결과";
            // 
            // winChartViewer
            // 
            winChartViewer.Dock = DockStyle.Fill;
            winChartViewer.Location = new Point(3, 28);
            winChartViewer.Name = "winChartViewer";
            winChartViewer.Size = new Size(935, 273);
            winChartViewer.TabIndex = 0;
            winChartViewer.TabStop = false;
            winChartViewer.Click += winChartViewer_Click;
            winChartViewer.DoubleClick += winChartViewer_DoubleClick;
            // 
            // MovieInfo
            // 
            MovieInfo.Controls.Add(dataGridView1);
            MovieInfo.Dock = DockStyle.Fill;
            MovieInfo.Location = new Point(3, 3);
            MovieInfo.Name = "MovieInfo";
            MovieInfo.Size = new Size(431, 299);
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
            dataGridView1.Size = new Size(425, 274);
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
            rightLayoutPanel.Location = new Point(947, 0);
            rightLayoutPanel.Name = "rightLayoutPanel";
            rightLayoutPanel.RowCount = 5;
            rightLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 35.4838753F));
            rightLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 16.1290321F));
            rightLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 16.1290321F));
            rightLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 16.1290321F));
            rightLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 16.1290321F));
            rightLayoutPanel.Size = new Size(437, 861);
            rightLayoutPanel.TabIndex = 3;
            // 
            // BtnExit
            // 
            BtnExit.BackColor = Color.FromArgb(21, 101, 192);
            BtnExit.Dock = DockStyle.Fill;
            BtnExit.FlatStyle = FlatStyle.Flat;
            BtnExit.Font = new Font("나눔고딕 ExtraBold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            BtnExit.ForeColor = SystemColors.ButtonFace;
            BtnExit.IconChar = FontAwesome.Sharp.IconChar.RightToBracket;
            BtnExit.IconColor = Color.Gainsboro;
            BtnExit.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnExit.Location = new Point(3, 722);
            BtnExit.Name = "BtnExit";
            BtnExit.Size = new Size(431, 136);
            BtnExit.TabIndex = 6;
            BtnExit.UseVisualStyleBackColor = false;
            BtnExit.Click += BtnExit_Click;
            // 
            // iconBtnFileOpen
            // 
            iconBtnFileOpen.BackColor = Color.FromArgb(21, 101, 192);
            iconBtnFileOpen.Dock = DockStyle.Fill;
            iconBtnFileOpen.FlatStyle = FlatStyle.Flat;
            iconBtnFileOpen.Font = new Font("나눔고딕 ExtraBold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            iconBtnFileOpen.ForeColor = SystemColors.ButtonFace;
            iconBtnFileOpen.IconChar = FontAwesome.Sharp.IconChar.FolderOpen;
            iconBtnFileOpen.IconColor = Color.Gainsboro;
            iconBtnFileOpen.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconBtnFileOpen.Location = new Point(3, 308);
            iconBtnFileOpen.Name = "iconBtnFileOpen";
            iconBtnFileOpen.Size = new Size(431, 132);
            iconBtnFileOpen.TabIndex = 3;
            iconBtnFileOpen.TextAlign = ContentAlignment.MiddleLeft;
            iconBtnFileOpen.UseVisualStyleBackColor = false;
            iconBtnFileOpen.Click += iconBtnFileOpen_Click;
            // 
            // iconBtnAnalyze
            // 
            iconBtnAnalyze.BackColor = Color.FromArgb(21, 101, 192);
            iconBtnAnalyze.Dock = DockStyle.Fill;
            iconBtnAnalyze.FlatStyle = FlatStyle.Flat;
            iconBtnAnalyze.Font = new Font("나눔고딕 ExtraBold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            iconBtnAnalyze.ForeColor = SystemColors.ButtonFace;
            iconBtnAnalyze.IconChar = FontAwesome.Sharp.IconChar.CarCrash;
            iconBtnAnalyze.IconColor = Color.Gainsboro;
            iconBtnAnalyze.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconBtnAnalyze.Location = new Point(3, 446);
            iconBtnAnalyze.Name = "iconBtnAnalyze";
            iconBtnAnalyze.Size = new Size(431, 132);
            iconBtnAnalyze.TabIndex = 4;
            iconBtnAnalyze.UseVisualStyleBackColor = false;
            iconBtnAnalyze.Click += iconBtnAnalyze_Click;
            // 
            // btnRePlay
            // 
            btnRePlay.BackColor = Color.FromArgb(21, 101, 192);
            btnRePlay.Dock = DockStyle.Fill;
            btnRePlay.FlatStyle = FlatStyle.Flat;
            btnRePlay.Font = new Font("나눔고딕 ExtraBold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnRePlay.ForeColor = SystemColors.ButtonFace;
            btnRePlay.IconChar = FontAwesome.Sharp.IconChar.Chalkboard;
            btnRePlay.IconColor = Color.Gainsboro;
            btnRePlay.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnRePlay.Location = new Point(3, 584);
            btnRePlay.Name = "btnRePlay";
            btnRePlay.Size = new Size(431, 132);
            btnRePlay.TabIndex = 5;
            btnRePlay.UseVisualStyleBackColor = false;
            btnRePlay.Click += btnRePlay_Click;
            // 
            // FormOpenVideo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1384, 861);
            Controls.Add(LeftMainPanel);
            Controls.Add(rightLayoutPanel);
            Name = "FormOpenVideo";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormOpenVideo";
            WindowState = FormWindowState.Maximized;
            Load += FormOpenVideo_Load;
            LeftMainPanel.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)winChartViewer).EndInit();
            MovieInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            rightLayoutPanel.ResumeLayout(false);
            ResumeLayout(false);
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
        private ProgressBar progressBar1;
        private Label lblStstus;
        private TableLayoutPanel rightLayoutPanel;
        private FontAwesome.Sharp.IconButton iconBtnFileOpen;
        private FontAwesome.Sharp.IconButton iconBtnAnalyze;
        private FontAwesome.Sharp.IconButton btnRePlay;
        private FontAwesome.Sharp.IconButton BtnExit;
        private ChartDirector.WinChartViewer winChartViewer;
    }
}