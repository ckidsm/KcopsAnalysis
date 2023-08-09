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
using System.Windows.Controls;
using System.Windows.Documents;
using System.Threading.Tasks;
using Vlc.DotNet.Forms;
using FontAwesome.Sharp;
using Vlc.DotNet.Core;
using System.Diagnostics;

namespace KcopsAnalysis
{
    public partial class FormOpenVideo : Form
    {
        //로드된 파일경로 및 정보를 담기위한 테이블
        private DataTable table;
        //백그라운드 워커
        BackgroundWorker worker;

        //플레이어 재생 시간
        private readonly System.Windows.Forms.Timer Playertimer = new();
        //불러온 파일정보
        private VideoAnalysisSourceInfo sourceInfo;
        //분석된 파일정보
        private VideoAnalysisCompletion outputinfo;

        // 프로세스관련 정의
        private static string Process_name_Cmd = "cmd.exe ";
        private static ProcessStartInfo? Psi = null;
        private static Process? Proc = null;
        private static readonly bool IsRunning = false;

        //분석시작 측정 스톱워치
        private Stopwatch stopwatch = new Stopwatch();
        private VlcControl vlcControl;

        //플레이어 디렉토리 정보
        private DirectoryInfo libDirectory;


        public FormOpenVideo()
        {
            //파이썬 강제 종료
            ProcessRun.ProcessFindAndKill("python");

            InitializeComponent();
            try
            {
                //동영상 재생기 생성
                vlcControlAdd();
                //플레이 리스트 데이타 테이블 생성
                PlaylistTable();
                //파일 복사 백그라운드 워커 생성
                BackgroundWorkerDeclaration();
                //영상 재생  타이머 생성
                PlayertimerDeclaration();

                //ffMpeg 파일 검사 및 복사
                if (!File.Exists(AppDomain.CurrentDomain.BaseDirectory + @"\ffprobe.exe")|| !File.Exists(AppDomain.CurrentDomain.BaseDirectory + @"\ffmpeg.exe"))
                {
                    File.Copy(@"C:\ffmpeg-6.0\bin\ffmpeg.exe", AppDomain.CurrentDomain.BaseDirectory + @"\ffmpeg.exe", true);
                    File.Copy(@"C:\ffmpeg-6.0\bin\ffprobe.exe", AppDomain.CurrentDomain.BaseDirectory + @"\ffprobe.exe", true);
                }
                dataGridView1.DataSource = table;
            }
            catch (Exception ex)
            {

                MessageBox.Show($"예외 메시지 : {ex.Message} {Environment.NewLine} 위치: {ex.Source}");
            }
        }
        private void FormOpenVideo_Load(object sender, EventArgs e)
        {

        }

        #region 동영상 재생 시간 이벤트 정의
        private void PlayertimerDeclaration()
        {
            Playertimer.Interval = 1000; // 1초

#pragma warning disable CS8622 // 매개 변수 형식에서 참조 형식의 Null 허용 여부가 대상 대리자와 일치하지 않습니다(Null 허용 여부 특성 때문일 수 있음).
            Playertimer.Tick += new EventHandler(Playertimer_Tick);
#pragma warning restore CS8622 // 매개 변수 형식에서 참조 형식의 Null 허용 여부가 대상 대리자와 일치하지 않습니다(Null 허용 여부 특성 때문일 수 있음).
            //Playertimer.Start();      
        }

        #endregion

        #region 백그라운드 워커 정의
        private void BackgroundWorkerDeclaration()
        {
            //파일 복사 백그라운드 워커 
            worker = new BackgroundWorker
            {
                WorkerReportsProgress = true,
                WorkerSupportsCancellation = true
            };
#pragma warning disable CS8622 // 매개 변수 형식에서 참조 형식의 Null 허용 여부가 대상 대리자와 일치하지 않습니다(Null 허용 여부 특성 때문일 수 있음).
            worker.DoWork += Worker_DoWork;
#pragma warning restore CS8622 // 매개 변수 형식에서 참조 형식의 Null 허용 여부가 대상 대리자와 일치하지 않습니다(Null 허용 여부 특성 때문일 수 있음).

#pragma warning disable CS8622 // 매개 변수 형식에서 참조 형식의 Null 허용 여부가 대상 대리자와 일치하지 않습니다(Null 허용 여부 특성 때문일 수 있음).
            worker.ProgressChanged += Worker_ProgressChanged;
#pragma warning restore CS8622 // 매개 변수 형식에서 참조 형식의 Null 허용 여부가 대상 대리자와 일치하지 않습니다(Null 허용 여부 특성 때문일 수 있음).

#pragma warning disable CS8622 // 매개 변수 형식에서 참조 형식의 Null 허용 여부가 대상 대리자와 일치하지 않습니다(Null 허용 여부 특성 때문일 수 있음).
            worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
#pragma warning restore CS8622 // 매개 변수 형식에서 참조 형식의 Null 허용 여부가 대상 대리자와 일치하지 않습니다(Null 허용 여부 특성 때문일 수 있음).
        }
        #endregion

        #region 불러온 영상파일 목록 정의 (테이블) 
        private void PlaylistTable()
        {
            table = new DataTable();
            // column 추가.
            table.Columns.Add("NO", typeof(string));
            table.Columns.Add("파일명", typeof(string));
            table.Columns.Add("초당프레임수", typeof(double));
            table.Columns.Add("비디오 코덱명 ", typeof(string));
            table.Columns.Add("오디오 코덱명", typeof(string));
            table.Columns.Add("타임스케일:", typeof(string));
            table.Columns.Add("파일경로", typeof(string));
            table.Columns.Add("생성일", typeof(string));
            table.Columns.Add("수정일", typeof(string));
        }
        #endregion

        #region Vlc 생성 및 패널에 ADD
        private void vlcControlAdd()
        {
            // .net standard 7.0 에서 도구상자에 첨부된 vlcControl를 윈폼에 쓰면  VlcLibDirectory를 설정할 수 없다. 비활성화.
            //https://github.com/ZeBobo5/Vlc.DotNet/issues/693 게시된 이슈가 있어
            //https://github.com/ZeBobo5/Vlc.DotNet/wiki/Getting-started#vlcdotnetforms  여기에 기재된 방법을 사용.
            //string libvlc = "C:\\SRC\\SynologyDrive\\62.Kcops\\WinForm\\KcopsAnalysis\\KcopsAnalysis\\bin\\Debug\\net7.0-windows\\";
            //string path = Directory.GetCurrentDirectory();
            vlcControl = new Vlc.DotNet.Forms.VlcControl();
            vlcControl.BeginInit();
            libDirectory = new DirectoryInfo(Path.Combine(Directory.GetCurrentDirectory(), "libvlc", IntPtr.Size == 4 ? "x86" : "win-x64"));
            vlcControl.VlcLibDirectory = libDirectory;
            vlcControl.VlcMediaplayerOptions = new string[] { "--subsdec-encoding=cp949", "--freetype-font=Malgun Gothic" };
            vlcControl.EndInit();
            vlcControl.Dock = DockStyle.Fill;
            //테이블 패널 ADD
            LeftMainPanel.Controls.Add(vlcControl);

        }
        #endregion

        #region 불러운 영상 파일 정보 추출
        private void LoadMovie()
        {
            var rowid = table.Rows.Count + 1;

            vlcControl.Stop();
            iconBtnAnalyze.Enabled = true;
            lblStstus.Text = "선택된 영상 명 :" + sourceInfo.FileFullName;
            if (sourceInfo.FileFullName is not null)
            {

                FileInfo file = new(sourceInfo.FileFullName);

                FfprobeFrameValue();

                vlcControl.SetMedia(file);
                vlcControl.Play();

                table.Rows.Add(rowid.ToString(), sourceInfo.FileName, PlayerHelpers.Fps, PlayerHelpers.VideoCodec, PlayerHelpers.AudioCodec, PlayerHelpers.Timescale, sourceInfo.FilePath, sourceInfo.CreationTime, sourceInfo.LastWriteTime);
                dataGridView1.DataSource = table;
                dataGridView1.AutoResizeColumns();
                Videoplayback();
            }
        }
        #endregion

        #region 파일복사 메소드
        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="des"></param>
        private void CopyFile(string source, string des)
        {
            try
            {
                FileStream FileOut = new FileStream(des, FileMode.Create);
                //다른프로세스가 파일을 읽을수 있도록 
                FileStream FileIn = new FileStream(source, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                byte[] bt = new byte[1048756];
                int RedByte;
                while ((RedByte = FileIn.Read(bt, 0, bt.Length)) > 0)
                {
                    worker.ReportProgress((int)(FileIn.Position * 100 / FileIn.Length));
                }
                FileOut.Close();
                FileIn.Close();

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        #endregion

        #region 동영상 재생 시작 시간 측정 
        private void Videoplayback()
        {
            Playertimer.Start();
            ButtonPlaying.IconChar = IconChar.Pushed;
            //https://github.com/ZeBobo5/Vlc.DotNet/issues/333
#pragma warning disable CS8622 // 매개 변수 형식에서 참조 형식의 Null 허용 여부가 대상 대리자와 일치하지 않습니다(Null 허용 여부 특성 때문일 수 있음).
            vlcControl.Playing += new EventHandler<VlcMediaPlayerPlayingEventArgs>(SetProgressMax);
#pragma warning restore CS8622 // 매개 변수 형식에서 참조 형식의 Null 허용 여부가 대상 대리자와 일치하지 않습니다(Null 허용 여부 특성 때문일 수 있음).
        }
        #endregion

        #region 동영상 길이 트랙바 대입
        private void SetProgressMax(object sender, VlcMediaPlayerPlayingEventArgs e)
        {
            Invoke(new Action(() =>
            {
                VlcControl vlc = (VlcControl)sender;
                trackBar1.Maximum = (int)vlc.Length;
            }));
        }
        #endregion

        #region 백그라운드 이벤트
        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            LoadMovie();
        }

        private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;

        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (sourceInfo.FileFullName != null)
            {
                CopyFile(sourceInfo.FileFullName, @"c:\temp\" + sourceInfo.FileName);
            }

        }
        #endregion

        #region 동영상 재생 시간 출력
        private void Playertimer_Tick(object sender, EventArgs e)
        {

            lblPlayerTime.Text = vlcControl.Time.ToString();
            //메소드에 넘겨주고
            PlayerHelpers.MillisecondHourMinuteSecond(vlcControl.Time);
            //계산된 값을 대입 및 형식변환

            lblPlayerTime.Text = $"{PlayerHelpers.Hour:00} : {PlayerHelpers.Minute:00} : {PlayerHelpers.Second:00}";
            DisplayFrameNumber();
        }
        #endregion

        #region 동영상 프레임 번호 출력
        private void DisplayFrameNumber()
        {
            double currentsecond = 0.000;
            double framerate;
            double frameapproximation = 0.000;
            //double frameapproximation = 0;

            framerate = 1.00 / Convert.ToDouble(PlayerHelpers.Fps); // 1.00 / fps. In this case, all values to be divided must have a decimal point.
            currentsecond = (PlayerHelpers.Hour * 3600) + (PlayerHelpers.Minute * 60) + PlayerHelpers.Second;
            frameapproximation = currentsecond / framerate;
            PlayerHelpers.DisPlayFrameNumber = Convert.ToInt32(Math.Truncate(frameapproximation));
            LblFps.Text = "프레임 번호 : " + PlayerHelpers.DisPlayFrameNumber;
        }
        #endregion

        #region 동영상 세부 정보 가져오기
        private void FfprobeFrameValue()
        {
            try
            {
                Debug.WriteLine("FfprobeFrameValue 시작");
                PlayerHelpers.startInfo2.WindowStyle = ProcessWindowStyle.Hidden;
                PlayerHelpers.startInfo2.CreateNoWindow = true; //cmd창 켜지는 것도 보이지 않게 하기.
                PlayerHelpers.startInfo2.WorkingDirectory = AppDomain.CurrentDomain.BaseDirectory + "\\";
                PlayerHelpers.startInfo2.RedirectStandardOutput = true; //Output값 가져오는데 필요한 설정값.
                PlayerHelpers.startInfo2.UseShellExecute = false; //Output값 가져오는데 필요한 설정값2.

                //프레임 값
                PlayerHelpers.startInfo2.Arguments = @"-v error -select_streams v:0 -show_entries stream=avg_frame_rate -of default=noprint_wrappers=1:nokey=1 """ + sourceInfo.FileFullName + @"""";//-acodec
                                                                                                                                                                                                     // Console.WriteLine(PlayerHelpers.startInfo2.Arguments);
                                                                                                                                                                                                     //동영상 정보 프로퍼티 선언
                PlayerHelpers.processn = Process.Start(PlayerHelpers.startInfo2);
#pragma warning disable CS8602 // null 가능 참조에 대한 역참조입니다.
                PlayerHelpers.processn.EnableRaisingEvents = true;
#pragma warning restore CS8602 // null 가능 참조에 대한 역참조입니다.
                PlayerHelpers.processn.WaitForExit(1);

                string? result = PlayerHelpers.processn.StandardOutput.ReadLine(); //두번 찍히는 경우가 있어서 한 줄만 읽게 처리함.
                if (result is not null)
                {
                    result = result.Replace("\r", "").Replace("\n", ""); //개행문자 \r \n 둘 다 지워야 정상 출력됨.
                }

                PlayerHelpers.Fpsfractionnotation = result;

                string[] result2;
#pragma warning disable CS8602 // null 가능 참조에 대한 역참조입니다.
                result2 = result.Split(new string[] { "/" }, StringSplitOptions.None);
#pragma warning restore CS8602 // null 가능 참조에 대한 역참조입니다.
                PlayerHelpers.Fps = Convert.ToDouble(result2[0]) / Convert.ToDouble(result2[1]);
                PlayerHelpers.Fps.ToString("00.00");

                //비디오 타임스케일 값
                PlayerHelpers.startInfo2.Arguments = @"-v error -select_streams v:0 -show_entries stream=time_base -of default=noprint_wrappers=1:nokey=1 """ + sourceInfo.FileFullName + @"""";//-acodec
                PlayerHelpers.processn = Process.Start(PlayerHelpers.startInfo2);
#pragma warning disable CS8602 // null 가능 참조에 대한 역참조입니다.
                PlayerHelpers.processn.EnableRaisingEvents = true;
#pragma warning restore CS8602 // null 가능 참조에 대한 역참조입니다.
                PlayerHelpers.processn.WaitForExit(1);

                result = PlayerHelpers.processn.StandardOutput.ReadLine(); //두번 찍히는 경우가 있어서 한 줄만 읽게 처리함.
#pragma warning disable CS8602 // null 가능 참조에 대한 역참조입니다.
                result = result.Replace("\r", "").Replace("\n", ""); //개행문자 \r \n 둘 다 지워야 정상 출력됨.
#pragma warning restore CS8602 // null 가능 참조에 대한 역참조입니다.

                result2 = result.Split(new string[] { "/" }, StringSplitOptions.None);
                PlayerHelpers.Timescale = result2[1]; //분수 뒷부분을 취함.
                                                      // textBox14.Text = PlayerHelpers.Timescale;


                //영상 마지막 시간 값
                PlayerHelpers.startInfo2.Arguments = @"-v error -sexagesimal -show_entries format=duration -of default=noprint_wrappers=1:nokey=1 """ + sourceInfo.FileFullName + @"""";//yy.MM.ss:mmmmmm
                PlayerHelpers.processn = Process.Start(PlayerHelpers.startInfo2);
#pragma warning disable CS8602 // null 가능 참조에 대한 역참조입니다.
                PlayerHelpers.processn.EnableRaisingEvents = true;
#pragma warning restore CS8602 // null 가능 참조에 대한 역참조입니다.
                PlayerHelpers.processn.WaitForExit(1);

                result = PlayerHelpers.processn.StandardOutput.ReadLine(); //두번 찍히는 경우가 있어서 한 줄만 읽게 처리함.
#pragma warning disable CS8602 // null 가능 참조에 대한 역참조입니다.
                result = result.Replace("\r", "").Replace("\n", ""); //개행문자 \r \n 둘 다 지워야 정상 출력됨.
#pragma warning restore CS8602 // null 가능 참조에 대한 역참조입니다.
                PlayerHelpers.VideoEndTime = result;

                //비디오 코덱 값
                PlayerHelpers.startInfo2.Arguments = @"-v error -select_streams v:0 -show_entries stream=codec_name -of default=noprint_wrappers=1:nokey=1 """ + sourceInfo.FileFullName + @"""";//-acodec
                PlayerHelpers.processn = Process.Start(PlayerHelpers.startInfo2);
#pragma warning disable CS8602 // null 가능 참조에 대한 역참조입니다.
                PlayerHelpers.processn.EnableRaisingEvents = true;
#pragma warning restore CS8602 // null 가능 참조에 대한 역참조입니다.
                PlayerHelpers.processn.WaitForExit(1);

                result = PlayerHelpers.processn.StandardOutput.ReadLine(); //두번 찍히는 경우가 있어서 한 줄만 읽게 처리함.
#pragma warning disable CS8602 // null 가능 참조에 대한 역참조입니다.
                result = result.Replace("\r", "")
                    .Replace("\n", ""); //개행문자 \r \n 둘 다 지워야 정상 출력됨.
#pragma warning restore CS8602 // null 가능 참조에 대한 역참조입니다.
                // textBox7.Text = result;
                PlayerHelpers.VideoEndTime = result;

                //오디오 코덱 값
                PlayerHelpers.startInfo2.Arguments = @"-v error -select_streams a:0 -show_entries stream=codec_name -of default=noprint_wrappers=1:nokey=1 """ + sourceInfo.FileFullName + @"""";//-acodec
                PlayerHelpers.processn = Process.Start(PlayerHelpers.startInfo2);
#pragma warning disable CS8602 // null 가능 참조에 대한 역참조입니다.
                PlayerHelpers.processn.EnableRaisingEvents = true;
#pragma warning restore CS8602 // null 가능 참조에 대한 역참조입니다.
                PlayerHelpers.processn.WaitForExit(1);

                result = PlayerHelpers.processn.StandardOutput.ReadLine(); //두번 찍히는 경우가 있어서 한 줄만 읽게 처리함.
#pragma warning disable CS8602 // null 가능 참조에 대한 역참조입니다.
                result = result.Replace("\r", "").Replace("\n", ""); //개행문자 \r \n 둘 다 지워야 정상 출력됨.
#pragma warning restore CS8602 // null 가능 참조에 대한 역참조입니다.
                PlayerHelpers.AudioCodec = result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }
        #endregion

        #region 작업 상태 정보 표시
        private void StstusPrint(string msg)
        {

            try
            {
                if (lblStstus.InvokeRequired)
                {
                    Invoke(new Action(delegate ()
                    {
                        lblStstus.Text = msg;
                        lblStstus.Update();

                    }));


                }
                else { lblStstus.Text = msg; lblStstus.Update(); }
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region 파일열기 클릭
        private void iconBtnFileOpen_Click(object sender, EventArgs e)
        {
            //https://stackoverflow.com/questions/24449988/how-to-get-file-path-from-openfiledialog-and-folderbrowserdialog
            sourceInfo = new VideoAnalysisSourceInfo();
            using (System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog())
            {
                vlcControl.Stop();
                openFileDialog.InitialDirectory = "C:\\";
                openFileDialog.Filter = Properties.Resources.Media_Files;
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {

                    sourceInfo.FileFullName = openFileDialog.FileName;

                    if (Path.GetDirectoryName(sourceInfo.FileFullName) is not null)
                    {
                        sourceInfo.FilePath = Path.GetDirectoryName(sourceInfo.FileFullName);
                    }


                    //파일 이름과 확장자를 가져옴
                    sourceInfo.FileName = Path.GetFileName(openFileDialog.FileName);

                    //확장자를 제거한 파일이름만 가져오기
                    // sourceInfo. FileName = Path.GetFileNameWithoutExtension(openFileDialog.FileName);
                    var fileStream = openFileDialog.OpenFile();

                    DateTime creationTime = File.GetCreationTime(sourceInfo.FileFullName);
                    DateTime lastWriteTime = File.GetLastWriteTime(sourceInfo.FileFullName);
                }
            }
            worker.RunWorkerAsync();
        }
        #endregion

        #region 영상 분석 클릭
        private void iconBtnAnalyze_Click(object sender, EventArgs e)
        {
            if (vlcControl.IsPlaying == true)
                vlcControl.Stop();// Probably unnecessary

            outputinfo = new VideoAnalysisCompletion();
            ProcessRun.ProcessFindAndKill("python");

#pragma warning disable CS8602 // null 가능 참조에 대한 역참조입니다.
            string result_fileName = sourceInfo.FileFullName.Substring(sourceInfo.FileFullName.LastIndexOf("\\") + 1);
#pragma warning restore CS8602 // null 가능 참조에 대한 역참조입니다.
            //pictureBox.Image = null;
            string ExtensionRemoveName = $"{System.IO.Path.GetFileNameWithoutExtension(result_fileName)}";
            outputinfo.OutputFileName = ExtensionRemoveName + "_output.avi";
            outputinfo.OutputFilePath = sourceInfo.FilePath + @"\" + outputinfo.OutputFileName;
            outputinfo.OutputImage = sourceInfo.FilePath + @"\" + ExtensionRemoveName + "_impulse.png";

            if (File.Exists(outputinfo.OutputFilePath))
            {
                File.Delete(outputinfo.OutputFilePath);
            }
            if (File.Exists(outputinfo.OutputImage))
            {
                File.Delete(outputinfo.OutputImage);
            }
            StstusPrint("영상 분석 시작");


            ProcessStartEvent();
            //timer.Stop();
            //sw.Stop();
            //lblTime.text = "Completed in " + sw.Elapsed.Seconds.ToString() + "seconds";
            StstusPrint("분석 완료 | 소요시간 :  " + stopwatch.Elapsed.Seconds.ToString() + "초");
        }
        #endregion

        #region ★ 프로세스 이벤트 정의
        private void ProcessStartEvent()
        {
            try
            {
                Psi = new ProcessStartInfo();
                Psi.UseShellExecute = false;
                Psi.CreateNoWindow = true;
                Psi.RedirectStandardOutput = true;
                Psi.RedirectStandardInput = true;
                Psi.RedirectStandardError = true;
                //https://learn.microsoft.com/en-us/dotnet/api/system.diagnostics.process.enableraisingevents?view=net-7.0
                Proc = new Process();
                Proc.EnableRaisingEvents = true;

                Proc.ErrorDataReceived += (object sending_process, DataReceivedEventArgs e) =>
                {
                    if (e.Data != null)
                    {
                        Debug.WriteLine(e.Data);
                        StstusPrint(e.Data);
                    }
                };


                Proc.OutputDataReceived += (object sending_process, DataReceivedEventArgs e) =>
                {
                    if (e.Data != null)
                    {
                        Debug.WriteLine("OutputDataReceived ::" + e.Data);
                        StstusPrint(e.Data);
                    }
                };

                ProcessStartSet();
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion

        #region ★ 프로세스 시작 및 작업 환경 지정
        private async void ProcessStartSet()
        {
#pragma warning disable CS8602 // null 가능 참조에 대한 역참조입니다.
            Psi.FileName = Process_name_Cmd;
#pragma warning restore CS8602 // null 가능 참조에 대한 역참조입니다.
            Psi.WorkingDirectory = @"C:\SRC\SynologyDrive\62.Kcops\Demo";// "C:\\";
            //Psi.CreateNoWindow = false;
#pragma warning disable CS8602 // null 가능 참조에 대한 역참조입니다.
            Proc.StartInfo = Psi;
#pragma warning restore CS8602 // null 가능 참조에 대한 역참조입니다.
            Proc.Start();

            Proc.BeginOutputReadLine();
            Proc.BeginErrorReadLine();

            await ProcessStartAsync();

            Proc.CancelOutputRead();
            Proc.CancelErrorRead();
            Proc.Close();
        }
        #endregion

        #region ★ 프로세스 작업 결과 확인
        private async Task<string> ProcessStartAsync()
        {
            //https://learn.microsoft.com/ko-kr/dotnet/api/system.diagnostics.process.totalprocessortime?view=net-7.0
            try
            {
                string AlgorithmArgumentsMode2 = "python demo_hit_n_run_tracking.py evaluate --video " + sourceInfo.FileFullName + " --mode 2 --conf_files .\\X_Decoder\\configs\\xdecoder\\svlp_focalt_lang.yaml --overrides WEIGHT .\\X_Decoder\\weight\\xdecoder_focalt_best_openseg.pt";
#pragma warning disable CS8602 // null 가능 참조에 대한 역참조입니다.
                Proc.StandardInput.Write(AlgorithmArgumentsMode2 + Environment.NewLine);
#pragma warning restore CS8602 // null 가능 참조에 대한 역참조입니다.
                Proc.StandardInput.Flush();

                stopwatch.Start();
                while (!File.Exists(outputinfo.OutputImage))
                {
                    if (File.Exists(outputinfo.OutputImage))
                    {
                        FileInfo fi = new FileInfo(outputinfo.OutputImage);
                        Debug.WriteLine($" 파일 생성 됨?! {fi.FullName}");

                        await Task.Delay(1000);
                        stopwatch.Stop(); //시간측정 끝

                        Debug.WriteLine("time Total: " + stopwatch.ElapsedMilliseconds + "ms");
                        //StstusPrint("time Total: " + stopwatch.ElapsedMilliseconds + "ms");
                        StstusPrint($" 파일 생성 됨?! {fi.FullName}");
                        // break;

                    }
                    await Task.Delay(100);
                    Debug.WriteLine($" 파일 생성대기");
                    StstusPrint("time Total: " + stopwatch.ElapsedMilliseconds + "ms");
                }


                await Task.Delay(1000);
                Proc.StandardInput.Close();
                //Proc.WaitForExit();
                return "종료";
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
    #endregion
}
