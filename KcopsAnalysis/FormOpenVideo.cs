using System.ComponentModel;
using System.Data;
using System.Text;
using Vlc.DotNet.Forms;
using FontAwesome.Sharp;
using Vlc.DotNet.Core;
using System.Diagnostics;
using ChartDirector;
using System.Globalization;
using System.Runtime.Intrinsics.Arm;

//Chart.setLicenseCode("RDST-352K-3KBY-6HVZ-B975-7DFD");
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

        CancellationTokenSource cts = null;

        //불러온 파일정보
        private VideoAnalysisSourceInfo sourceInfo;
        //분석된 파일정보
        private VideoAnalysisCompletion outputinfo;

        // 프로세스관련 정의
        private static string Process_name_Cmd = "cmd.exe ";
        private static ProcessStartInfo Psi;
        private static Process Proc;
        private static readonly bool IsRunning = false;

        //분석시작 측정 스톱워치
        private Stopwatch stopwatch = new Stopwatch();
        private VlcControl vlcControl;

        //플레이어 디렉토리 정보
        private DirectoryInfo libDirectory;

        //알고리즘 디렉토리 
        private readonly string AlgorithmDirectory = @"C:\HitRun\Demo";

        //파일 읽기 락
        private object fileLock = new object();
        // 분석 중
        private bool isRunning = false;
        // 에러 상태
        private bool isError = false;

        private bool AnalysisFigures = false;
        public int a = 0;
        public int c = 0;
        public delegate void UpdateControlsDelegate(); //Execute when video loads

        //프레임 이동단위
        private int framemovementunit = 1;
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
                if (!File.Exists(AppDomain.CurrentDomain.BaseDirectory + @"\ffprobe.exe") || !File.Exists(AppDomain.CurrentDomain.BaseDirectory + @"\ffmpeg.exe"))
                {
                    File.Copy(@"C:\ffmpeg-6.0\bin\ffmpeg.exe", AppDomain.CurrentDomain.BaseDirectory + @"\ffmpeg.exe", true);
                    File.Copy(@"C:\ffmpeg-6.0\bin\ffprobe.exe", AppDomain.CurrentDomain.BaseDirectory + @"\ffprobe.exe", true);
                }
                dataGridView1.DataSource = table;

                //에러상태 없음
                isError = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"예외 메시지 : {ex.Message} {Environment.NewLine} 위치: {ex.Source}");
                TextWriter.LoggingToFile(GetType().Name, $"예외 메시지 : {ex.Message} {Environment.NewLine} 위치: {ex.Source}");
            }
        }
        private void FormOpenVideo_Load(object sender, EventArgs e)
        {

        }

        #region 동영상 재생 시간 이벤트
        private void PlayertimerDeclaration()
        {
            Playertimer.Interval = 1000; // 1초

            Playertimer.Tick += new EventHandler(Playertimer_Tick);

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

            worker.DoWork += Worker_DoWork;


            worker.ProgressChanged += Worker_ProgressChanged;



            worker.RunWorkerCompleted += Worker_RunWorkerCompleted;

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

            vlcControl.VlcMediaPlayer.TimeChanged += VlcMediaPlayer_TimeChanged;
            vlcControl.VlcMediaPlayer.Playing += vlcControl1_Playing;
            vlcControl.VlcMediaPlayer.EndReached += VlcMediaPlayer_EndReached;
            vlcControl.PositionChanged += vlcControl_PositionChanged;

            trackBar1.Maximum = 100;
            trackBar1.Minimum = 0;
            trackBar1.Value = 0;

        }

        private void VlcMediaPlayer_EndReached(object sender, VlcMediaPlayerEndReachedEventArgs e)
        {

        }
        #region  VlcMediaPlayer 재생 시간 표시

        private void VlcMediaPlayer_TimeChanged(object sender, VlcMediaPlayerTimeChangedEventArgs e)
        {
            try
            {
                //vlcControl.Length 영상 전체 시간
                //e.NewTime 현재 재싱 시간.
                Invoke(new Action(() =>
                {
                    Player.VideoEndTime = TimeFormat((int)vlcControl.Length);
                    lblPlayerTime.Text = TimeFormat((int)e.NewTime) + "  | " + Player.VideoEndTime;
                    trackBar1.Maximum = (int)vlcControl.Length / 1000;
                    trackBar1.Value = (int)e.NewTime / 1000;
                    TextWriter.LoggingToFile(GetType().Name, $"VlcMediaPlayer_TimeChanged : trackBar1.Value = {trackBar1.Value} | e.NewTime ={e.NewTime} | trackBar1.Maximum ={trackBar1.Maximum} 위치: 영상재생 트랙바");
                }));
            }
            catch (Exception ex)
            {
                TextWriter.LoggingToFile(GetType().Name, $"예외 메시지 : {ex.Message} {Environment.NewLine} 위치: {ex.Source}");

            }

        }
        #endregion

        private string TimeFormat(int Milliseconds)
        {
            int TotalSeconds = Milliseconds / 1000;
            int hours = TotalSeconds / 3600;
            int hours_res = TotalSeconds - (hours * 3600);
            int minutes = TotalSeconds / 60;
            int minutes_res = hours_res - (minutes * 60);
            int seconds = minutes_res % 60;
            string strtime = string.Format("{0,1}:{1,2:D2}:{2,2:D2}", hours, minutes, seconds);
            return strtime;

        }


        private void vlcControl1_Playing(object sender, Vlc.DotNet.Core.VlcMediaPlayerPlayingEventArgs e)
        {

            Invoke(new Action(() =>
            {

                // lblPlayerTime.Text = vlcControl.VlcMediaPlayer.Video.
                // lblPlayerTime.Text = DateTimeFormat((int) vlcControl.i)

            }));



        }
        #endregion

        #region 불러운 영상 파일 정보 추출
        private void LoadMovie()
        {
            try
            {
               // var rowid = table.Rows.Count + 1;

                iconBtnAnalyze.Enabled = true;
                lblStstus.Text = "선택된 영상 명 :" + sourceInfo.FileFullName;
                if (sourceInfo.FileFullName is not null)
                {

                    FileInfo file = new(sourceInfo.FileFullName);
                    
                    FfprobeFrameValue();

                    isRunning = true;
                    
                    table.Rows.Add(table.Rows.Count+ 1, sourceInfo.FileName, PlayerHelpers.Fps, PlayerHelpers.VideoCodec, PlayerHelpers.AudioCodec, PlayerHelpers.Timescale, sourceInfo.FilePath, sourceInfo.CreationTime, sourceInfo.LastWriteTime);
                    
                    dataGridView1.DataSource = table;
                    
                    dataGridView1.AutoResizeColumns();
                    
                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].Selected = true;
                    
                    Videoplayback();
                    
                    vlcControl.Invalidate();
                    
                    vlcControl.Play(file);
                    
                    trackBar1.Maximum = (int)vlcControl.Length;
                    
                    Playertimer.Start();
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"예외 메시지 : {ex.Message} {Environment.NewLine} 위치: {ex.Source}");
                TextWriter.LoggingToFile(GetType().Name, $"예외 메시지 : {ex.Message} {Environment.NewLine} 위치: {ex.Source}");
                this.Close();
            }

        }
        #endregion


        private void SetProgresMax(object sender, VlcMediaPlayerPlayingEventArgs e)
        {
            Invoke(new Action(() =>
            {
                var vlc = (VlcControl)sender;
                trackBar1.Maximum = (int)vlc.Length;
            }));

        }

        private void vlcControl_PositionChanged(object sender, VlcMediaPlayerPositionChangedEventArgs e)
        {
            var value = e.NewPosition;

        }

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

            ButtonPlaying.IconChar = IconChar.Pushed;
            //https://github.com/ZeBobo5/Vlc.DotNet/issues/333

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

            // lblPlayerTime.Text = vlcControl.Time.ToString();
            //메소드에 넘겨주고
            PlayerHelpers.MillisecondHourMinuteSecond(vlcControl.Time);
            //계산된 값을 대입 및 형식변환

            //lblPlayerTime.Text = $"{PlayerHelpers.Hour:00} : {PlayerHelpers.Minute:00} : {PlayerHelpers.Second:00}";


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
            LblFps.Text = "영상 프레임  : " + PlayerHelpers.DisPlayFrameNumber;
            LblFps.Update();
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

                PlayerHelpers.processn.EnableRaisingEvents = true;

                PlayerHelpers.processn.WaitForExit(1);

                string result = PlayerHelpers.processn.StandardOutput.ReadLine(); //두번 찍히는 경우가 있어서 한 줄만 읽게 처리함.
                if (result is not null)
                {
                    result = result.Replace("\r", "").Replace("\n", ""); //개행문자 \r \n 둘 다 지워야 정상 출력됨.
                }

                PlayerHelpers.Fpsfractionnotation = result;

                string[] result2;

                result2 = result.Split(new string[] { "/" }, StringSplitOptions.None);

                PlayerHelpers.Fps = Convert.ToDouble(result2[0]) / Convert.ToDouble(result2[1]);
                PlayerHelpers.Fps.ToString("00.00");

                //비디오 타임스케일 값
                PlayerHelpers.startInfo2.Arguments = @"-v error -select_streams v:0 -show_entries stream=time_base -of default=noprint_wrappers=1:nokey=1 """ + sourceInfo.FileFullName + @"""";//-acodec
                PlayerHelpers.processn = Process.Start(PlayerHelpers.startInfo2);

                PlayerHelpers.processn.EnableRaisingEvents = true;

                PlayerHelpers.processn.WaitForExit(1);

                result = PlayerHelpers.processn.StandardOutput.ReadLine(); //두번 찍히는 경우가 있어서 한 줄만 읽게 처리함.

                result = result.Replace("\r", "").Replace("\n", ""); //개행문자 \r \n 둘 다 지워야 정상 출력됨.


                result2 = result.Split(new string[] { "/" }, StringSplitOptions.None);
                PlayerHelpers.Timescale = result2[1]; //분수 뒷부분을 취함.
                                                      // textBox14.Text = PlayerHelpers.Timescale;


                //영상 마지막 시간 값
                PlayerHelpers.startInfo2.Arguments = @"-v error -sexagesimal -show_entries format=duration -of default=noprint_wrappers=1:nokey=1 """ + sourceInfo.FileFullName + @"""";//yy.MM.ss:mmmmmm
                PlayerHelpers.processn = Process.Start(PlayerHelpers.startInfo2);

                PlayerHelpers.processn.EnableRaisingEvents = true;

                PlayerHelpers.processn.WaitForExit(1);

                result = PlayerHelpers.processn.StandardOutput.ReadLine(); //두번 찍히는 경우가 있어서 한 줄만 읽게 처리함.

                result = result.Replace("\r", "").Replace("\n", ""); //개행문자 \r \n 둘 다 지워야 정상 출력됨.

                PlayerHelpers.VideoEndTime = result;

                //비디오 코덱 값
                PlayerHelpers.startInfo2.Arguments = @"-v error -select_streams v:0 -show_entries stream=codec_name -of default=noprint_wrappers=1:nokey=1 """ + sourceInfo.FileFullName + @"""";//-acodec
                PlayerHelpers.processn = Process.Start(PlayerHelpers.startInfo2);

                PlayerHelpers.processn.EnableRaisingEvents = true;

                PlayerHelpers.processn.WaitForExit(1);

                result = PlayerHelpers.processn.StandardOutput.ReadLine(); //두번 찍히는 경우가 있어서 한 줄만 읽게 처리함.

                result = result.Replace("\r", "")
                    .Replace("\n", ""); //개행문자 \r \n 둘 다 지워야 정상 출력됨.

                // textBox7.Text = result;
                PlayerHelpers.VideoEndTime = result;

                //오디오 코덱 값
                PlayerHelpers.startInfo2.Arguments = @"-v error -select_streams a:0 -show_entries stream=codec_name -of default=noprint_wrappers=1:nokey=1 """ + sourceInfo.FileFullName + @"""";//-acodec
                PlayerHelpers.processn = Process.Start(PlayerHelpers.startInfo2);

                PlayerHelpers.processn.EnableRaisingEvents = true;

                PlayerHelpers.processn.WaitForExit(1);

                result = PlayerHelpers.processn.StandardOutput.ReadLine(); //두번 찍히는 경우가 있어서 한 줄만 읽게 처리함.

                if (null == result)
                {
                    result = "오디오 코덱 없음";
                    PlayerHelpers.AudioCodec = result;
                }
                else
                {
                    result = result.Replace("\r", "").Replace("\n", ""); //개행문자 \r \n 둘 다 지워야 정상 출력됨.

                    PlayerHelpers.AudioCodec = result;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                TextWriter.LoggingToFile(GetType().Name, $"예외 메시지 : {ex.Message} {Environment.NewLine} 위치: {ex.Source}");
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
                        TextWriter.LoggingToFile(GetType().Name, msg);
                    }));


                }
                else { lblStstus.Text = msg; lblStstus.Update(); }
                TextWriter.LoggingToFile(GetType().Name, msg);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                TextWriter.LoggingToFile(GetType().Name, $"예외 메시지 : {ex.Message} {Environment.NewLine} 위치: {ex.Source}");
                throw;
            }
        }
        #endregion

        #region 파일열기 클릭
        private void iconBtnFileOpen_Click(object sender, EventArgs e)
        {
            //https://stackoverflow.com/questions/24449988/how-to-get-file-path-from-openfiledialog-and-folderbrowserdialog

            trackBar1.Maximum = 100;
            trackBar1.Minimum = 0;
            trackBar1.Value = 0;

            vlcControl.Invalidate();
            if (vlcControl.IsPlaying)
            {
                vlcControl.Stop();
            }

            sourceInfo = new VideoAnalysisSourceInfo();
            using (System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog())
            {

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
                    TextWriter.LoggingToFile(GetType().Name, $"파일 열기 클릭(영상로드) :: 위치:{sourceInfo.FileFullName}");
                    //트랙바 설정

                }
            }
            worker.RunWorkerAsync();
        }
        #endregion

        #region 영상 분석 클릭
        private void iconBtnAnalyze_Click(object sender, EventArgs e)
        {
            try
            {

                TextWriter.LoggingToFile(GetType().Name, $"영상 분석 클릭 :: isRunning 상태: {isRunning}");
                if (!isRunning)
                {
                    return;
                }
                // 영상이 재생중이면 재생 중지.
                if (vlcControl.IsPlaying)
                    vlcControl.Stop();// Probably unnecessary
                //타이머 중지
                Playertimer.Stop();

                //파이썬 강제 종료
                ProcessRun.ProcessFindAndKill("python");
                // vlcControl.Invalidate();

                TextWriter.LoggingToFile(GetType().Name, $"영상 분석 클릭 :: isRunning 상태: {isRunning} vlcControl.IsPlaying 상태 : {vlcControl.IsPlaying} ");
                // 아웃풋 정보 정의 결과 동영상 파일, 수치 데이타 파일등.
                outputinfo = new VideoAnalysisCompletion();

                string result_fileName = sourceInfo.FileFullName.Substring(sourceInfo.FileFullName.LastIndexOf("\\") + 1);

                string ExtensionRemoveName = $"{System.IO.Path.GetFileNameWithoutExtension(result_fileName)}";
                outputinfo.OutputFileName = sourceInfo.FileName + "_0_output.avi";
                outputinfo.OutputFilePath = AlgorithmDirectory + @"\" + @"SaveVideo\" + outputinfo.OutputFileName;
                //20230901 충격수치결과값 텍스트파일로 변경
                //  outputinfo.OutputImage = sourceInfo.FilePath + @"\" + ExtensionRemoveName + "_impulse.png";
                TextWriter.LoggingToFile(GetType().Name, $"영상 분석 클릭 :: isRunning 상태: {isRunning} vlcControl.IsPlaying 상태 : {vlcControl.IsPlaying} :: 아웃풋 영상 파일명 지정 :{outputinfo.OutputFileName} :: 아웃풋 영상 경로 지정 {outputinfo.OutputFilePath} ");
                outputinfo.OutputImage = AlgorithmDirectory + @"\SaveLog" + @"\" + ExtensionRemoveName + "_Accident.txt";
                TextWriter.LoggingToFile(GetType().Name, $"영상 분석 클릭 :: isRunning 상태: {isRunning} :: 충격 수치 파일명 및  경로 {outputinfo.OutputImage} ");

                if (File.Exists(outputinfo.OutputFilePath))
                {
                    File.Delete(outputinfo.OutputFilePath);
                    TextWriter.LoggingToFile(GetType().Name, $"영상 분석 클릭 :: isRunning 상태: {isRunning} :: 아웃풋 영상 파일 삭제 {outputinfo.OutputFilePath} ");
                }
                if (File.Exists(outputinfo.OutputImage))
                {
                    File.Delete(outputinfo.OutputImage);
                    TextWriter.LoggingToFile(GetType().Name, $"영상 분석 클릭 :: isRunning 상태: {isRunning} :: 충격 수치 파일 삭제 {outputinfo.OutputFilePath} ");
                }
                StstusPrint("영상 분석 시작");
                AnalysisFigures = false;
                //프로세스 이벤트 메시지 받기
                ProcessStartEvent();
                //프로세스 시작
                ProcessStartSet();
                StstusPrint("충격 시간 / 수치 추출  완료 | 소요시간 :  " + stopwatch.Elapsed.Seconds.ToString() + "초");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                TextWriter.LoggingToFile(GetType().Name, $"예외 메시지 : {ex.Message} {Environment.NewLine} 위치: {ex.Source}");
                AnalysisFigures = false;
                throw;
            }


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
                        StstusPrint($"ProcessStartEvent :: ER-DataReceived = {e.Data}");
                    }


                    if (e.Data.Contains("error"))
                    {
                        //파이썬 강제 종료
                        ProcessRun.ProcessFindAndKill("python");
                        //  StstusPrint($"영상 분석 오류 발생 : {e.Data}");
                        TextWriter.LoggingToFile(GetType().Name, $"영상 분석중 오류 발생[error]: {e.Data} {Environment.NewLine} 위치: {sourceInfo.FilePath}");
                        MessageBox.Show($"{sourceInfo.FileFullName} 의  영상 분석 도중 오류가 발생되어 분석을 중단합니다", "error");
                        isError = true;

                    }

                    if (e.Data.Contains("오류"))
                    {
                        //파이썬 강제 종료
                        ProcessRun.ProcessFindAndKill("python");
                        //  StstusPrint($"영상 분석 오류 발생 : {e.Data}");
                        TextWriter.LoggingToFile(GetType().Name, $"영상 분석 오류 [오류] : {e.Data} {Environment.NewLine} 위치: {sourceInfo.FilePath}");
                        MessageBox.Show($"{sourceInfo.FileFullName} 의  영상 분석 도중 오류가 발생되어 분석을 중단합니다", "오류");
                        isError = true;

                    }


                };

                Proc.OutputDataReceived += (object sending_process, DataReceivedEventArgs e) =>
                {
                    if (e.Data != null)
                    {
                        StstusPrint($"\"ProcessStartEvent::OutputDataReceived = {e.Data}");
                    }
                };

                //  ProcessStartSet();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

                throw;
            }
        }

        #endregion

        #region ★ 프로세스 시작 및 작업 환경 지정
        private async void ProcessStartSet()
        {

            Psi.FileName = Process_name_Cmd;
            Psi.WorkingDirectory = @"C:\HitRun\Demo";// @"C:\Demo_0731";// "C:\\";
            //Psi.CreateNoWindow = false;

            Proc.StartInfo = Psi;
            Proc.Start();

            Proc.BeginOutputReadLine();
            Proc.BeginErrorReadLine();

            var value = await ProcessStartAsync();
            TextWriter.LoggingToFile(GetType().Name, $"ProcessStartSet Retrun : {value} {Environment.NewLine} 위치: await ProcessStartAsync()");
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
                CultureInfo ci = CultureInfo.InvariantCulture;
                StringBuilder sb = new StringBuilder();
                string AccidentValue = string.Empty;
                double[] Impactquantity = new double[3];
                string[] ImpactTime = new string[3];
                Process[] Processspython = Process.GetProcessesByName("Python.exe");
                string PassedValue = string.Empty;
                // 20230901 TODO  충격량 0,실제 충격량 값,0
                // 동영상 재생 시작시간 0. 감지한 시간, 끝 시간

                // string AlgorithmArgumentsMode2 = "python demo_hit_n_run_tracking.py evaluate --video " + sourceInfo.FileFullName + " --mode 2 --conf_files .\\X_Decoder\\configs\\xdecoder\\svlp_focalt_lang.yaml --overrides WEIGHT .\\X_Decoder\\weight\\xdecoder_focalt_best_openseg.pt";
                string AlgorithmArgumentsModeNew = "python optical_demo.py --video " + sourceInfo.FileFullName;

                Proc.StandardInput.Write(AlgorithmArgumentsModeNew + Environment.NewLine);

                Proc.StandardInput.Flush();

                StstusPrint($" 명령어 전송 {AlgorithmArgumentsModeNew}");

                stopwatch.Start();
                while (!File.Exists(outputinfo.OutputImage))
                {
                    await Task.Delay(TimeSpan.FromSeconds(1));
                    StstusPrint($"충격 시간/구간 추출 대기중... 경과 시간: {stopwatch.Elapsed}");

                    if (isError)
                    {
                        stopwatch.Stop(); //시간측정 끝
                        StstusPrint($"영상 분석중 오류가 발생되어 중단 되었습니다. {stopwatch.Elapsed}");
                        isError = false;
                        Proc.CloseMainWindow();
                        return "오류";
                    }
                }


                if (File.Exists(outputinfo.OutputImage))
                {
                    // FileInfo fi = new FileInfo(outputinfo.OutputImage);

                    TextWriter.LoggingToFile(GetType().Name, $"ProcessStartAsync : 충격 수치 파일 생성 됨 ?!  : {outputinfo.OutputImage}");
                    await Task.Delay(TimeSpan.FromSeconds(1));
                    stopwatch.Stop(); //시간측정 끝

                
                    lock (fileLock)
                    {
                        AccidentValue = File.ReadAllText(outputinfo.OutputImage);

                    }
                    //텍스트파일에서 충격량 시간을 가져온다.
                    outputinfo.GraphReferenceValue = AccidentValue.Split('|');

                    //  var num = GraphReferenceValue[0];
                    // var OutputTIme_Data = String.Format("{0:yyyy-MM-dd HH:mm:dd}", GraphReferenceValue[0]);
                    var OutputTIme_Data = Convert.ToDouble(outputinfo.GraphReferenceValue[0]); //System.String.Format("{0:D6}", GraphReferenceValue[0], ci);
                    var value = (int)Math.Truncate(OutputTIme_Data);


                    TimeSpan t = TimeSpan.FromMilliseconds(OutputTIme_Data);
                    //소수점 올림
                    var dd = Math.Ceiling(OutputTIme_Data);
                    //소수점 제거
                    var ddd = Math.Truncate(OutputTIme_Data);

                    //실수 반올림
                    var dddd=Math.Round(OutputTIme_Data);
                    string answer = string.Format("{0:D2}h:{1:D2}m:{2:D2}s:{3:D3}ms",
                                            t.Hours,
                                            t.Minutes,
                                            t.Seconds,
                                            t.Milliseconds);
                    var OutputTIme_Data_str0 = TimeSpan.FromSeconds(Convert.ToDouble(outputinfo.GraphReferenceValue[0])).ToString();

                    var OutputTIme_Data_str = DisplayInSeconds(value.ToString());
                    // var OutputTIme_Data_str1 = TimeCodeValue(value.ToString());
                  

                    //Math.Truncate
                    // 충격시간 그래프 구간
                    ImpactTime[0] = ("0");
                    ImpactTime[1] = TimeSpan.FromSeconds(Convert.ToDouble(outputinfo.GraphReferenceValue[0])).ToString();
                    ImpactTime[2] = Player.VideoEndTime;

                    //충격량 그래프 구간
                    Impactquantity[0] = 0;
                    Impactquantity[1] = Double.Parse(outputinfo.GraphReferenceValue[1]); //1.9197
                    Impactquantity[2] = 0;

                    // Create a XYChart object of size 600 x 400 pixels
                    XYChart c = new XYChart(935, 300);

                    // Set default text color to dark grey (0x333333)
                    c.setColor(Chart.TextColor, 0x333333);

                    // Add a title box using grey (0x555555) 24pt Arial Bold font
                    // c.addTitle("분석결과", "Arial Bold", 18, 0x555555);

                    // Set the plotarea at (70, 60) and of size 500 x 300 pixels, with transparent
                    // background and border and light grey (0xcccccc) horizontal grid lines
                    // c.setPlotArea(300, 60, 400, 400 ,Chart.Transparent, -1, Chart.Transparent, 0xcccccc);
                    c.setPlotArea(300, 10, 400, 200, Chart.Transparent, -1, Chart.Transparent, 0xcccccc);

                    // Set the x and y axis stems to transparent and the label font to 12pt Arial
                    c.xAxis().setColors(Chart.Transparent);
                    c.yAxis().setColors(Chart.Transparent);
                    c.xAxis().setLabelStyle("Arial", 12);
                    c.yAxis().setLabelStyle("Arial", 12);

                    // 주어진 데이터를 사용하여 투명 테두리가 있는 파란색 막대 바
                    c.addBarLayer(Impactquantity, 0x6699bb).setBorderColor(Chart.Transparent);

                    //x 축 레이블 설정(충격시간)
                    c.xAxis().setLabels(ImpactTime);

                    //자동 y축 레이블의 경우 최소 간격을 40픽셀로 설정
                    c.yAxis().setTickDensity(30);

                    // Add a title to the y axis using dark grey (0x555555) 14pt Arial Bold font
                    c.yAxis().setTitle("", "Arial Bold", 14, 0x555555);

                    // Output the chart
                    winChartViewer.Chart = c;

                    //include tool tip for the chart 
                    winChartViewer.ImageMap = c.getHTMLImageMap("clickable", "", "title='{xLabel}: {value} '");
                    AnalysisFigures = true;
                }

                stopwatch.Start();
                while (!File.Exists(outputinfo.OutputFilePath))
                {
                    if (isError)
                    {
                        stopwatch.Stop(); //시간측정 끝
                        StstusPrint($"영상 분석중 오류가 발생되어 중단 되었습니다. {stopwatch.Elapsed}");
                        isError = false;
                        Proc.CloseMainWindow();
                        return "오류";
                    }

                    await Task.Delay(TimeSpan.FromSeconds(1));
                    //Debug.WriteLine($" 파일 생성대기");
                    StstusPrint($"분석 결과 영상 생성중...{outputinfo.OutputFileName} || 경과 시간: {stopwatch.Elapsed} ");
                }

                if (File.Exists(outputinfo.OutputFilePath))
                {
                    await Task.Delay(TimeSpan.FromSeconds(1));
                    Proc.StandardInput.Close();

                    FileInfo file = new(outputinfo.OutputFilePath);
                    vlcControl.Invalidate();
                    vlcControl.VlcMediaPlayer.TimeChanged += new EventHandler<VlcMediaPlayerTimeChangedEventArgs>(VlcMediaPlayer_TimeChanged);
                    vlcControl.Play(file);
                    PassedValue = "AVI 파일 생성 완료";

                }

                return PassedValue;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                TextWriter.LoggingToFile(GetType().Name, $"예외 메시지 : {ex.Message} {Environment.NewLine} 위치: {ex.Source}");
                throw;
            }

        }
        #endregion


        private static string DisplayInSeconds(string inputsec)
        {
            int hours, minute, second;
            int num = int.Parse(inputsec);
            hours = num / 3600;//시 공식

            minute = num % 3600 / 60;//분을 구하기위해서 입력되고 남은값에서 또 60을 나눈다.

            second = num % 3600 % 60;//마지막 남은 시간에서 분을 뺀 나머지 시간을 초로 계산함
            return $"{hours} 시간 {minute} 분 {second} 초";
        }

        public double TimeCodeValue(string timecode)
        {
            // 00:01:53,039
            string[] parts = timecode.Replace(",", ":").Split(':', ',');
            double Hours = int.Parse(parts[0]);
            double Minutes = int.Parse(parts[1]);
            double Seconds = int.Parse(parts[2]);
            double Milliseconds = int.Parse(parts[3]);

            return (Hours * 3600 + Minutes * 60 + Seconds) * 1000 + Milliseconds;
        }

        private void btnRePlay_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.ShowDialog();
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            // vlcControl.Pause(); 
            // vlcControl.Time = trackBar1.Value;
            //trackBar1.Value =  (int) vlcControl.Time;
            

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if (vlcControl.IsPlaying)
            {
                var Maxvalue = trackBar1.Maximum;
                vlcControl.Time = trackBar1.Value;

            }

        }


        #region 닫기 클릭 이벤트
        private void BtnExit_Click(object sender, EventArgs e)
        {
            ProcessRun.ProcessFindAndKill("python");
            Close();
        }
        #endregion


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        #region 데이타 그리드 더블 클릭 이벤트
        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                var PlayFile = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[6].Value.ToString() + @"\" + dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[1].Value.ToString();
                TextWriter.LoggingToFile(GetType().Name, $" 재생목록 더블 클릭 : PlayFile ={PlayFile} ||  위치: dataGridView1_DoubleClick");

            }
        }
        #endregion

        #region 재생 버튼 클릭 이벤트
        private void ButtonPlaying_Click(object sender, EventArgs e)
        {
            if (vlcControl.IsPlaying == true)
            {
                vlcControl.Pause();  //Pause 상태에서 또 Pause 누르면 다시 재생되므로 이렇게 둘 것.
            }
            else
            {
                vlcControl.Play();
                Videoplayback();
            }
        }
        #endregion

        #region 뒤로가기 클릭 이벤트

        private void BtnBackward_Click(object sender, EventArgs e)
        {
            if (PlayerHelpers.DisPlayFrameNumber - framemovementunit < 0)
            {
                MessageBox.Show("더 이상 프레임을 뒤로 이동할 수 없습니다.");
                return;
            }
            Moveframe(PlayerHelpers.DisPlayFrameNumber - framemovementunit);
        }
        #endregion

        #region 앞으로 가기 클릭 이벤트
        private void BtnForward_Click(object sender, EventArgs e)
        {
            Moveframe(framemovementunit = +1);
        }
        #endregion


        private void BtnCapture_Click(object sender, EventArgs e)
        {

        }

        private void Moveframe(int FrameNumberMove)
        {
            //프레임 번호
            int FrameNumber = 0;
            //프레임 비율
            double FrameRate;
            //밀리초 계산
            double MillisecondCount;

            FrameNumber = FrameNumberMove;
            FrameRate = 1.00 / PlayerHelpers.Fps;
            MillisecondCount = FrameNumber * FrameRate * 1000;
            vlcControl.Time = Convert.ToInt32((double)MillisecondCount);
            if (vlcControl.IsPlaying == true)
            {
                vlcControl.Pause();  //Pause 상태에서 또 Pause 누르면 다시 재생되므로 이렇게 둘 것.
            }
        }

        private void winChartViewer_DoubleClick(object sender, EventArgs e)
        {
            if (AnalysisFigures)
            {
                if (!string.IsNullOrEmpty( outputinfo.GraphReferenceValue[0]))
                {
                    
                   
                    trackBar1.Value = (int)Math.Ceiling(Convert.ToDouble(outputinfo.GraphReferenceValue[0]));
                    vlcControl.Play();
                    System.Windows.Forms.Application.DoEvents();
                    vlcControl.Time = trackBar1.Value;
                    vlcControl.Pause();
                }
               
            }

            
        }
    }

}
