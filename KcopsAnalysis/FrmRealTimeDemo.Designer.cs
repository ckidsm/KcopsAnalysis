namespace KcopsAnalysis
{
    partial class FrmRealTimeDemo
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
            valueA = new TextBox();
            valueB = new TextBox();
            valueC = new TextBox();
            samplePeriod = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)winChartViewer1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)samplePeriod).BeginInit();
            SuspendLayout();
            // 
            // winChartViewer1
            // 
            winChartViewer1.Location = new Point(179, 31);
            winChartViewer1.Name = "winChartViewer1";
            winChartViewer1.Size = new Size(585, 376);
            winChartViewer1.TabIndex = 0;
            winChartViewer1.TabStop = false;
            winChartViewer1.UpdateInterval = 10;
            winChartViewer1.WaitOnLoad = true;
            winChartViewer1.MouseMovePlotArea += winChartViewer1_MouseMovePlotArea;
            winChartViewer1.ViewPortChanged += winChartViewer1_ViewPortChanged;
            // 
            // valueA
            // 
            valueA.Location = new Point(53, 123);
            valueA.Name = "valueA";
            valueA.Size = new Size(100, 23);
            valueA.TabIndex = 1;
            // 
            // valueB
            // 
            valueB.Location = new Point(53, 165);
            valueB.Name = "valueB";
            valueB.Size = new Size(100, 23);
            valueB.TabIndex = 1;
            // 
            // valueC
            // 
            valueC.Location = new Point(53, 231);
            valueC.Name = "valueC";
            valueC.Size = new Size(100, 23);
            valueC.TabIndex = 1;
            // 
            // samplePeriod
            // 
            samplePeriod.Location = new Point(33, 291);
            samplePeriod.Name = "samplePeriod";
            samplePeriod.Size = new Size(120, 23);
            samplePeriod.TabIndex = 2;
            samplePeriod.Value = new decimal(new int[] { 100, 0, 0, 0 });
            samplePeriod.ValueChanged += samplePeriod_ValueChanged;
            // 
            // FrmRealTimeDemo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(samplePeriod);
            Controls.Add(valueC);
            Controls.Add(valueB);
            Controls.Add(valueA);
            Controls.Add(winChartViewer1);
            Name = "FrmRealTimeDemo";
            Text = "FrmRealTimeDemo";
            Load += FrmRealTimeDemo_Load;
            ((System.ComponentModel.ISupportInitialize)winChartViewer1).EndInit();
            ((System.ComponentModel.ISupportInitialize)samplePeriod).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ChartDirector.WinChartViewer winChartViewer1;
        private TextBox valueA;
        private TextBox valueB;
        private TextBox valueC;
        private NumericUpDown samplePeriod;
    }
}