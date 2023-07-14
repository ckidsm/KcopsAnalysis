using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
namespace KcopsAnalysis
{
    public partial class FormOpenVideo : Form
    {
        public FormOpenVideo()
        {
            InitializeComponent();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            VideoAnalysisSourceInfo sourceInfo = new VideoAnalysisSourceInfo();
            using (System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = Properties.Resources.Media_Files;
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    sourceInfo.FileName = openFileDialog.FileName;

                    //Read the contents of the file into a stream
                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        sourceInfo.fileContent = reader.ReadToEnd();
                    }
                }
            }

            MessageBox.Show(sourceInfo.fileContent, "File Content at path: " + sourceInfo.FileName, MessageBoxButtons.OK);

            //https://learn.microsoft.com/ko-kr/uwp/api/windows.media.playback.mediaplayer?view=winrt-22621
        }
    }
}
