namespace KcopsAnalysis
{
    partial class FormMessageBox
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
            panelBody = new Panel();
            panelButtons = new Panel();
            panelTitleBar = new Panel();
            labelCaption = new Label();
            btnClose = new Button();
            pictureBoxIcon = new PictureBox();
            labelMessage = new Label();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            panelBody.SuspendLayout();
            panelButtons.SuspendLayout();
            panelTitleBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxIcon).BeginInit();
            SuspendLayout();
            // 
            // panelBody
            // 
            panelBody.BackColor = Color.WhiteSmoke;
            panelBody.Controls.Add(labelMessage);
            panelBody.Controls.Add(pictureBoxIcon);
            panelBody.Dock = DockStyle.Fill;
            panelBody.Location = new Point(0, 38);
            panelBody.Name = "panelBody";
            panelBody.Size = new Size(466, 55);
            panelBody.TabIndex = 0;
            // 
            // panelButtons
            // 
            panelButtons.Controls.Add(button3);
            panelButtons.Controls.Add(button2);
            panelButtons.Controls.Add(button1);
            panelButtons.Dock = DockStyle.Bottom;
            panelButtons.Location = new Point(0, 93);
            panelButtons.Name = "panelButtons";
            panelButtons.Size = new Size(466, 63);
            panelButtons.TabIndex = 1;
            // 
            // panelTitleBar
            // 
            panelTitleBar.BackColor = Color.CornflowerBlue;
            panelTitleBar.Controls.Add(btnClose);
            panelTitleBar.Controls.Add(labelCaption);
            panelTitleBar.Dock = DockStyle.Top;
            panelTitleBar.Location = new Point(0, 0);
            panelTitleBar.Name = "panelTitleBar";
            panelTitleBar.Size = new Size(466, 38);
            panelTitleBar.TabIndex = 2;
            // 
            // labelCaption
            // 
            labelCaption.AutoSize = true;
            labelCaption.BackColor = Color.CornflowerBlue;
            labelCaption.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            labelCaption.ForeColor = Color.White;
            labelCaption.Location = new Point(3, 12);
            labelCaption.Name = "labelCaption";
            labelCaption.Size = new Size(46, 17);
            labelCaption.TabIndex = 3;
            labelCaption.Text = "label1";
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.CornflowerBlue;
            btnClose.Dock = DockStyle.Right;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Microsoft Sans Serif", 13F, FontStyle.Regular, GraphicsUnit.Point);
            btnClose.ForeColor = Color.WhiteSmoke;
            btnClose.Location = new Point(391, 0);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(75, 38);
            btnClose.TabIndex = 3;
            btnClose.Text = "X";
            btnClose.UseVisualStyleBackColor = false;
            // 
            // pictureBoxIcon
            // 
            pictureBoxIcon.Dock = DockStyle.Left;
            pictureBoxIcon.Image = Properties.Resources.chat;
            pictureBoxIcon.Location = new Point(0, 0);
            pictureBoxIcon.Name = "pictureBoxIcon";
            pictureBoxIcon.Size = new Size(62, 55);
            pictureBoxIcon.TabIndex = 3;
            pictureBoxIcon.TabStop = false;
            // 
            // labelMessage
            // 
            labelMessage.AutoSize = true;
            labelMessage.Dock = DockStyle.Fill;
            labelMessage.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            labelMessage.Location = new Point(62, 0);
            labelMessage.Name = "labelMessage";
            labelMessage.Size = new Size(46, 17);
            labelMessage.TabIndex = 4;
            labelMessage.Text = "label1";
            // 
            // button1
            // 
            button1.BackColor = Color.SeaGreen;
            button1.FlatStyle = FlatStyle.Flat;
            button1.ForeColor = Color.WhiteSmoke;
            button1.Location = new Point(12, 19);
            button1.Name = "button1";
            button1.Size = new Size(117, 32);
            button1.TabIndex = 0;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            button2.BackColor = Color.SeaGreen;
            button2.FlatStyle = FlatStyle.Flat;
            button2.ForeColor = Color.WhiteSmoke;
            button2.Location = new Point(152, 19);
            button2.Name = "button2";
            button2.Size = new Size(117, 32);
            button2.TabIndex = 0;
            button2.Text = "button1";
            button2.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            button3.BackColor = Color.SeaGreen;
            button3.FlatStyle = FlatStyle.Flat;
            button3.ForeColor = Color.WhiteSmoke;
            button3.Location = new Point(304, 19);
            button3.Name = "button3";
            button3.Size = new Size(117, 32);
            button3.TabIndex = 0;
            button3.Text = "button1";
            button3.UseVisualStyleBackColor = false;
            // 
            // FormMessageBox
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(466, 156);
            Controls.Add(panelBody);
            Controls.Add(panelTitleBar);
            Controls.Add(panelButtons);
            Name = "FormMessageBox";
            Text = "FormMessageBox";
            panelBody.ResumeLayout(false);
            panelBody.PerformLayout();
            panelButtons.ResumeLayout(false);
            panelTitleBar.ResumeLayout(false);
            panelTitleBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxIcon).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelBody;
        private Panel panelButtons;
        private Panel panelTitleBar;
        private Label labelCaption;
        private Button btnClose;
        private PictureBox pictureBoxIcon;
        private Label labelMessage;
        private Button button1;
        private Button button3;
        private Button button2;
    }
}