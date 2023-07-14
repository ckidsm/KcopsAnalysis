namespace KcopsAnalysis
{
    partial class FormMainMenu
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
            panelMenu = new Panel();
            iconButton4 = new FontAwesome.Sharp.IconButton();
            iconButton3 = new FontAwesome.Sharp.IconButton();
            BtnVideoLoad = new FontAwesome.Sharp.IconButton();
            iconButton1 = new FontAwesome.Sharp.IconButton();
            pictureBox1 = new PictureBox();
            panelTitleBar = new Panel();
            btnExit = new FontAwesome.Sharp.IconButton();
            btnMaximize = new FontAwesome.Sharp.IconButton();
            iconCurrentChildForm = new FontAwesome.Sharp.IconButton();
            btnMinimize = new FontAwesome.Sharp.IconButton();
            panelDesktop = new Panel();
            panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panelTitleBar.SuspendLayout();
            SuspendLayout();
            // 
            // panelMenu
            // 
            panelMenu.BackColor = Color.FromArgb(21, 101, 192);
            panelMenu.Controls.Add(iconButton4);
            panelMenu.Controls.Add(iconButton3);
            panelMenu.Controls.Add(BtnVideoLoad);
            panelMenu.Controls.Add(iconButton1);
            panelMenu.Controls.Add(pictureBox1);
            panelMenu.Dock = DockStyle.Left;
            panelMenu.Location = new Point(0, 0);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(144, 638);
            panelMenu.TabIndex = 0;
            // 
            // iconButton4
            // 
            iconButton4.FlatAppearance.BorderSize = 0;
            iconButton4.FlatStyle = FlatStyle.Flat;
            iconButton4.ForeColor = Color.White;
            iconButton4.IconChar = FontAwesome.Sharp.IconChar.PowerOff;
            iconButton4.IconColor = Color.Gainsboro;
            iconButton4.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton4.Location = new Point(0, 568);
            iconButton4.Name = "iconButton4";
            iconButton4.Size = new Size(144, 58);
            iconButton4.TabIndex = 1;
            iconButton4.UseVisualStyleBackColor = true;
            iconButton4.Click += iconButton3_Click;
            // 
            // iconButton3
            // 
            iconButton3.FlatAppearance.BorderSize = 0;
            iconButton3.FlatStyle = FlatStyle.Flat;
            iconButton3.ForeColor = Color.White;
            iconButton3.IconChar = FontAwesome.Sharp.IconChar.Gears;
            iconButton3.IconColor = Color.Gainsboro;
            iconButton3.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton3.Location = new Point(0, 365);
            iconButton3.Name = "iconButton3";
            iconButton3.Size = new Size(144, 58);
            iconButton3.TabIndex = 1;
            iconButton3.UseVisualStyleBackColor = true;
            iconButton3.Click += iconButton3_Click;
            // 
            // BtnVideoLoad
            // 
            BtnVideoLoad.FlatAppearance.BorderSize = 0;
            BtnVideoLoad.FlatStyle = FlatStyle.Flat;
            BtnVideoLoad.ForeColor = Color.White;
            BtnVideoLoad.IconChar = FontAwesome.Sharp.IconChar.VideoCamera;
            BtnVideoLoad.IconColor = Color.Gainsboro;
            BtnVideoLoad.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnVideoLoad.Location = new Point(0, 255);
            BtnVideoLoad.Name = "BtnVideoLoad";
            BtnVideoLoad.Size = new Size(144, 58);
            BtnVideoLoad.TabIndex = 1;
            BtnVideoLoad.UseVisualStyleBackColor = true;
            BtnVideoLoad.Click += iconButton2_Click;
            // 
            // iconButton1
            // 
            iconButton1.FlatAppearance.BorderSize = 0;
            iconButton1.FlatStyle = FlatStyle.Flat;
            iconButton1.ForeColor = Color.White;
            iconButton1.IconChar = FontAwesome.Sharp.IconChar.House;
            iconButton1.IconColor = Color.Gainsboro;
            iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton1.Location = new Point(-3, 142);
            iconButton1.Name = "iconButton1";
            iconButton1.Size = new Size(144, 58);
            iconButton1.TabIndex = 1;
            iconButton1.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Output__1_;
            pictureBox1.Location = new Point(3, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(138, 110);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // panelTitleBar
            // 
            panelTitleBar.BackColor = Color.FromArgb(21, 101, 192);
            panelTitleBar.Controls.Add(btnExit);
            panelTitleBar.Controls.Add(btnMaximize);
            panelTitleBar.Controls.Add(iconCurrentChildForm);
            panelTitleBar.Controls.Add(btnMinimize);
            panelTitleBar.Dock = DockStyle.Top;
            panelTitleBar.Location = new Point(144, 0);
            panelTitleBar.Name = "panelTitleBar";
            panelTitleBar.Size = new Size(890, 56);
            panelTitleBar.TabIndex = 1;
            panelTitleBar.MouseDown += panelTitleBar_MouseDown;
            // 
            // btnExit
            // 
            btnExit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnExit.FlatAppearance.BorderSize = 0;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.IconChar = FontAwesome.Sharp.IconChar.Xmark;
            btnExit.IconColor = Color.Gainsboro;
            btnExit.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnExit.IconSize = 32;
            btnExit.Location = new Point(802, 3);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(75, 50);
            btnExit.TabIndex = 0;
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // btnMaximize
            // 
            btnMaximize.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnMaximize.FlatAppearance.BorderSize = 0;
            btnMaximize.FlatStyle = FlatStyle.Flat;
            btnMaximize.IconChar = FontAwesome.Sharp.IconChar.WindowMaximize;
            btnMaximize.IconColor = Color.Gainsboro;
            btnMaximize.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnMaximize.IconSize = 32;
            btnMaximize.Location = new Point(713, 3);
            btnMaximize.Name = "btnMaximize";
            btnMaximize.Size = new Size(75, 50);
            btnMaximize.TabIndex = 0;
            btnMaximize.UseVisualStyleBackColor = true;
            btnMaximize.Click += btnMaximize_Click;
            // 
            // iconCurrentChildForm
            // 
            iconCurrentChildForm.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            iconCurrentChildForm.FlatAppearance.BorderSize = 0;
            iconCurrentChildForm.FlatStyle = FlatStyle.Flat;
            iconCurrentChildForm.IconChar = FontAwesome.Sharp.IconChar.WindowMinimize;
            iconCurrentChildForm.IconColor = Color.Gainsboro;
            iconCurrentChildForm.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconCurrentChildForm.IconSize = 32;
            iconCurrentChildForm.ImageAlign = ContentAlignment.MiddleLeft;
            iconCurrentChildForm.Location = new Point(3, 6);
            iconCurrentChildForm.Name = "iconCurrentChildForm";
            iconCurrentChildForm.Size = new Size(39, 50);
            iconCurrentChildForm.TabIndex = 0;
            iconCurrentChildForm.UseVisualStyleBackColor = true;
            // 
            // btnMinimize
            // 
            btnMinimize.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnMinimize.FlatAppearance.BorderSize = 0;
            btnMinimize.FlatStyle = FlatStyle.Flat;
            btnMinimize.IconChar = FontAwesome.Sharp.IconChar.WindowMinimize;
            btnMinimize.IconColor = Color.Gainsboro;
            btnMinimize.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnMinimize.IconSize = 32;
            btnMinimize.ImageAlign = ContentAlignment.BottomCenter;
            btnMinimize.Location = new Point(626, 3);
            btnMinimize.Name = "btnMinimize";
            btnMinimize.Size = new Size(75, 50);
            btnMinimize.TabIndex = 0;
            btnMinimize.UseVisualStyleBackColor = true;
            btnMinimize.Click += btnMinimize_Click;
            // 
            // panelDesktop
            // 
            panelDesktop.BackgroundImage = Properties.Resources.logo_home;
            panelDesktop.BackgroundImageLayout = ImageLayout.Center;
            panelDesktop.Dock = DockStyle.Fill;
            panelDesktop.Location = new Point(144, 56);
            panelDesktop.Name = "panelDesktop";
            panelDesktop.Size = new Size(890, 582);
            panelDesktop.TabIndex = 2;
            // 
            // FormMainMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1034, 638);
            Controls.Add(panelDesktop);
            Controls.Add(panelTitleBar);
            Controls.Add(panelMenu);
            Name = "FormMainMenu";
            Text = "Form1";
            panelMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panelTitleBar.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelMenu;
        private PictureBox pictureBox1;
        private FontAwesome.Sharp.IconButton iconButton3;
        private FontAwesome.Sharp.IconButton BtnVideoLoad;
        private FontAwesome.Sharp.IconButton iconButton1;
        private FontAwesome.Sharp.IconButton iconButton4;
        private Panel panelTitleBar;
        private FontAwesome.Sharp.IconButton btnExit;
        private FontAwesome.Sharp.IconButton btnMaximize;
        private FontAwesome.Sharp.IconButton btnMinimize;
        private Panel panelDesktop;
        private FontAwesome.Sharp.IconButton iconCurrentChildForm;
    }
}