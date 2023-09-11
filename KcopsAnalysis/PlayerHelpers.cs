using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KcopsAnalysis
{
    internal static class PlayerHelpers
    {
        public static double Fps = 00.00;
        //fps분수표기
        public static string? Fpsfractionnotation = string.Empty;
        //타임스케일
        public static string? Timescale = string.Empty;
        //영상마지막시간
        public static string? VideoEndTime = string.Empty;
        //시
        public static int Hour = 0;
        //분
        public static int Minute = 0;
        //초
        public static int Second = 0;
        //밀리초
        public static int Milliseconds = 0;
        //초밀리초
        public static double SecondMillisecond = 0;
        //자르기 시간
        public static int CropTime = 0;
        //자르기 분
        public static int CropMin = 0;
        //자르기 초
        public static int CropSecond = 0;
        //자르기 초밀리초
        public static double CropSecondMillisecond = 0;
        //시작값이 이 프레임
        public static bool StartValuekeyframe = false;
        //종료값이 이 프레임
        public static bool EndValueKeyframe = false;
        //키프레임 추출 실패
        public static bool KeyframeExtractionFailed = false;
        //하드웨어 가속 옵션
        public static string HardwareAccelerationOptions = string.Empty;
        //비디오 코덱 옵션
        public static string vcodecoptions = string.Empty;

        //비디오 코덱명
        public static string VideoCodec = string.Empty;
        // 오디오 코덱명
        public static string AudioCodec = string.Empty;

        public static string AudioEncoder = string.Empty;

        public static string VideoEncoder = string.Empty;

        public static int DisPlayFrameNumber;

        //종료값 미지정
        public static bool UnspecifiedExitValue = false;
        //자르기 종료시간명령어
        public static string CropEndTimeCommand = string.Empty;


        public static ProcessStartInfo startInfo = new ProcessStartInfo(AppDomain.CurrentDomain.BaseDirectory + "\\ffmpeg.exe");
        public static ProcessStartInfo startInfo2 = new ProcessStartInfo(AppDomain.CurrentDomain.BaseDirectory + "\\ffprobe.exe");
        public static ProcessStartInfo startInfo3 = new ProcessStartInfo(AppDomain.CurrentDomain.BaseDirectory + "\\ffprobe.exe");

        public static Process processn;
        //시분초 
        public static long MillisecondHourMinute(string Hour, string Minute, string Second)
        {
            //초환산 값
            long SecondConversion = 0;
            //밀리초 환산값
            long MillisecondConversion = 0;
            SecondConversion = (Convert.ToInt32(Hour) * 3600) + (Convert.ToInt32(Minute) * 60) + Convert.ToInt32(Second);
            MillisecondConversion = SecondConversion * 1000;
            return MillisecondConversion;
        }

        //밀리초의시분초화
        public static void MillisecondHourMinuteSecond(long Millisecond)
        {
            //초밀리초
            SecondMillisecond = Convert.ToDouble(Millisecond / 1000.000);

            //초 - 60초 도달하면 0으로 바뀌도록 나머지 연산도 실시
            Second = Convert.ToInt32(Math.Truncate(SecondMillisecond % 60));

            //분 - 60초 도달하면 0으로 바뀌도록 나머지 연산도 실시
            Minute = Convert.ToInt32(Math.Truncate(Millisecond / 60000.0) % 60);

            //시
            Hour = Convert.ToInt32(Math.Truncate(Millisecond / 3600000.0));
        }
    }
}
