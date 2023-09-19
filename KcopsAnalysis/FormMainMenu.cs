using FontAwesome.Sharp;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml.Linq;

namespace KcopsAnalysis
{
    public partial class FormMainMenu : Form
    {
        private IconButton currentBtn;
        private Panel leftBorderBtn;
        private Form currentChildForm;
        public FormMainMenu()
        {
            InitializeComponent();
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 60);
            panelMenu.Controls.Add(leftBorderBtn);

            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            StartDebugging()
;
        }

        private struct RGBColors
        {
            public static Color color1 = Color.FromArgb(172, 126, 241);
            public static Color color2 = Color.FromArgb(249, 118, 176);
            public static Color color3 = Color.FromArgb(253, 138, 114);
            public static Color color4 = Color.FromArgb(95, 77, 221);
            public static Color color5 = Color.FromArgb(249, 88, 155);
            public static Color color6 = Color.FromArgb(24, 161, 251);
        }

        //Methods
        private void ActivateButton(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                DisableButton();
                //Button
                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = Color.FromArgb(37, 36, 81);
                currentBtn.ForeColor = color;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = color;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign = ContentAlignment.MiddleRight;
                //Left border button
                leftBorderBtn.BackColor = color;
                leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();
                //Current Child Form Icon
                iconCurrentChildForm.IconChar = currentBtn.IconChar;
                iconCurrentChildForm.IconColor = color;
            }
        }

        private void DisableButton()
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = Color.FromArgb(31, 30, 68);
                currentBtn.ForeColor = Color.Gainsboro;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = Color.Gainsboro;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }

        private void OpenChildForm(Form childForm)
        {
            //open only form
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
            currentChildForm = childForm;
            //End
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelDesktop.Controls.Add(childForm);
            panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            //lblTitleChildForm.Text = childForm.Text;
        }

        private void Reset()
        {
            DisableButton();
            leftBorderBtn.Visible = false;
            iconCurrentChildForm.IconChar = IconChar.Home;
            iconCurrentChildForm.IconColor = Color.MediumPurple;
            iconCurrentChildForm.Text = "Home";
        }

        //Drag Form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }


        private void btnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                WindowState = FormWindowState.Maximized;
            else
                WindowState = FormWindowState.Normal;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            ProcessRun.ProcessFindAndKill("python");
            Application.Exit();
        }


        private void iconButton3_Click(object sender, EventArgs e)
        {
           // Application.Exit();
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            FormOpenVideo formOpenVideo = new FormOpenVideo();
            OpenChildForm(formOpenVideo);
            // formOpenVideo.ShowDialog();

        }

        private void StartDebugging()
        {

            string ProjectName = "KcopsAnalysis"; // Path.GetFileNameWithoutExtension(Assembly.GetEntryAssembly().Location); // Get File Title
            string AssemblyName = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            TextWriter.LOG_PATH = string.Format("{0}\\LOGS\\{1}", ProjectName, AssemblyName);
            TextWriter.LOG_FILE = AssemblyName + ".LOG";
            // m_LogWriter.LOG_PATH_FILE = string.Format("{0}\\{1}_{2}.LOG", m_LogWriter.LOG_PATH, c, DateTime.Now.ToString("yyyy-MM-dd_hhmmss"));
            // m_LogWriter.EnterDebug();
            String traceMsg = string.Format("**** StartDebugging()::로그를 시작합니다.");
            Trace.WriteLine(traceMsg);
            TextWriter.LoggingToFile(ProjectName, traceMsg);


        }

        private void iconBtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}