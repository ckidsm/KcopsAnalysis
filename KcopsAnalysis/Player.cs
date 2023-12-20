using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KcopsAnalysis
{
    public class Player
    {
        public static double Fps = 00.00;
        //fps분수표기
        public static string Fpsfractionnotation;
        //타임스케일
        public static string Timescale;
        //영상마지막시간
        public static string VideoEndTime;
        //시
        public static int Hour;
        //분
        public static int Minute;
        //초
        public static int Second;
        //밀리초
        public static int Milliseconds;
        //초밀리초
        public static double SecondMillisecond;
        //자르기 시간
        public static int CropTime;
        //자르기 분
        public static int CropMin;
        //자르기 초
        public static int CropSecond;
        //자르기 초밀리초
        public static double CropSecondMillisecond;
        //시작값이 이 프레임
        public static bool StartValuekeyframe;
        //종료값이 이 프레임
        public static bool EndValueKeyframe;
        //키프레임 추출 실패
        public static bool KeyframeExtractionFailed;
        //하드웨어 가속 옵션
        public static string HardwareAccelerationOptions;
        //비디오 코덱 옵션
        public static string vcodecoptions;
        //종료값 미지정
        public static bool UnspecifiedExitValue;
        //자르기 종료시간명령어
        public static string  CropEndTimeCommand;
        
        public static long VideoEndLength;

        public static ProcessStartInfo startInfo = new ProcessStartInfo(AppDomain.CurrentDomain.BaseDirectory + "\\ffmpeg.exe");
        public static ProcessStartInfo startInfo2 = new ProcessStartInfo(AppDomain.CurrentDomain.BaseDirectory + "\\ffprobe.exe");
        public static ProcessStartInfo startInfo3 = new ProcessStartInfo(AppDomain.CurrentDomain.BaseDirectory + "\\ffprobe.exe");

        public static Process processn;

    }
}
