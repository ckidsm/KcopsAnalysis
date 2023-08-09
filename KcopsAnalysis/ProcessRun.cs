using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KcopsAnalysis
{
    public class ProcessRun : Process
    {
        public ProcessRun()
        {
            // Process 환경 설정 클래스
            ProcessStartInfo startInfo = new ProcessStartInfo();
            // 실행할 프로그램 명
            startInfo.FileName = "CMD.exe";
            // 셀 배치 설정 = false
            startInfo.UseShellExecute = false;
            // 입력 Stream 사용 여부
            startInfo.RedirectStandardInput = true;
            // 출력 Stream 사용 여부
            startInfo.RedirectStandardOutput = true;
            // 에러 Stream 사용 여부
            startInfo.RedirectStandardError = true;
            // Process 종료시(Close 함수 호출시) 이벤트 발생 여부
            base.EnableRaisingEvents = false;
            // Process 클래스에 환경 설정
            base.StartInfo = startInfo;
            // 실행 함수 호출
            Executor();
        }

        public void Executor()
        {
            // 작업 시작 디렉토리
            base.StartInfo.WorkingDirectory = @"D:\";
            // 콘솔 화면에 표시
            Console.Write(base.StartInfo.WorkingDirectory + ">");
            // exit 명령어가 올 때까지 무한 루프
            while (true)
            {
                // 콘솔로부터 명령어를 입력 받는다.
                string ? cmd = Console.ReadLine();
                // exit 명령어가 입력시에 종료한다.
                if (cmd != null)
                {
                    "exit".Equals(cmd.Trim(), StringComparison.OrdinalIgnoreCase);
                }
                //if ("exit".Equals(cmd.Trim(), StringComparison.OrdinalIgnoreCase))
                //{
                //    break;
                //}
                try
                {
                    // Process 시작 (cmd.exe 실행)
                    base.Start();
                    // 입력 스트림.
                    using (base.StandardInput)
                    {
                        // cmd.exe 실행 후 명령어 입력
                        base.StandardInput.Write(cmd + Environment.NewLine);
                    }
                    // 에러 스트림
                    using (base.StandardError)
                    {
                        var ret = base.StandardError.ReadToEnd();
                        if (!String.IsNullOrWhiteSpace(ret))
                        {
                            Console.WriteLine(ret);
                        }
                    }
                    // 출력 스트림
                    using (base.StandardOutput)
                    {
                        // cmd.exe로 받은 출력을 ret 변수에 담는다.
                        var ret = base.StandardOutput.ReadToEnd();
                        // 개행 추가
                        cmd += "\r\n";
                        // 출력 스트림에 입력 값도 포함되어 있기 때문에 제거한다.
                        Console.Write(ret.Substring(ret.IndexOf(cmd) + cmd.Length));
                        // cmd.exe 명령어는 항상 명령어가 끝나면 디렉토리가 나온다. 최종 디렉토리를 추출한다.
                        String buffer = ret.Substring(ret.LastIndexOf("\r\n\r\n") + 4);
                        // 최종 디렉토리를 WorkDirectory 설정
                        base.StartInfo.WorkingDirectory = buffer.Substring(0, buffer.Length - 1);
                    }
                }
                catch (Exception e)
                {
                    // 에러 발생 시 디렉토리 재 설정
                    base.StartInfo.WorkingDirectory = @"C:\";
                    Console.WriteLine(e);
                }
                finally
                {
                    // cmd.exe 종료
                    base.Close();
                }
            }
        }

        public static string ProcessFindAndKill(string ProcessName)
        {
            Process[] processList = Process.GetProcessesByName(ProcessName);
            string killName=string.Empty;
            for (int i = processList.Length - 1; i >= 0; i--)
            {
                // processList[i].CloseMainWindow();
                processList[i].Kill();
                processList[i].Close();
                killName= processList[i].ToString();
            }
            return killName;
        }

    }
}
