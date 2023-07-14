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
            OpenFolder = new FontAwesome.Sharp.IconButton();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            SuspendLayout();
            // 
            // OpenFolder
            // 
            OpenFolder.IconChar = FontAwesome.Sharp.IconChar.Display;
            OpenFolder.IconColor = Color.Black;
            OpenFolder.IconFont = FontAwesome.Sharp.IconFont.Auto;
            OpenFolder.Location = new Point(146, 94);
            OpenFolder.Name = "OpenFolder";
            OpenFolder.Size = new Size(177, 93);
            OpenFolder.TabIndex = 0;
            OpenFolder.Text = "iconButton1";
            OpenFolder.UseVisualStyleBackColor = true;
            OpenFolder.Click += iconButton1_Click;
            // 
            // FormOpenVideo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(OpenFolder);
            Name = "FormOpenVideo";
            Text = "FormOpenVideo";
            ResumeLayout(false);
        }

        #endregion

        private FontAwesome.Sharp.IconButton OpenFolder;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}