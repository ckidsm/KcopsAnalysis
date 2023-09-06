namespace KcopsAnalysis
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
            winChartViewer1 = new ChartDirector.WinChartViewer();
            vlcControl1 = new Vlc.DotNet.Forms.VlcControl();
            ((System.ComponentModel.ISupportInitialize)winChartViewer1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)vlcControl1).BeginInit();
            SuspendLayout();
            // 
            // winChartViewer1
            // 
            winChartViewer1.AutoPopDelay = 5000;
            winChartViewer1.InitialDelay = 1000;
            winChartViewer1.Location = new Point(41, 23);
            winChartViewer1.Name = "winChartViewer1";
            winChartViewer1.ReshowDelay = 100;
            winChartViewer1.Size = new Size(693, 155);
            winChartViewer1.TabIndex = 0;
            winChartViewer1.TabStop = false;
            // 
            // vlcControl1
            // 
            vlcControl1.BackColor = Color.Black;
            vlcControl1.Location = new Point(375, 290);
            vlcControl1.Name = "vlcControl1";
            vlcControl1.Size = new Size(75, 23);
            vlcControl1.Spu = -1;
            vlcControl1.TabIndex = 1;
            vlcControl1.Text = "vlcControl1";
            vlcControl1.VlcLibDirectory = null;
            vlcControl1.VlcMediaplayerOptions = null;
            vlcControl1.Playing += vlcControl1_Playing;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1077, 672);
            Controls.Add(vlcControl1);
            Controls.Add(winChartViewer1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)winChartViewer1).EndInit();
            ((System.ComponentModel.ISupportInitialize)vlcControl1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private ChartDirector.WinChartViewer winChartViewer1;
        private Vlc.DotNet.Forms.VlcControl vlcControl1;
    }
}