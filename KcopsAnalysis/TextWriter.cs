using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace KcopsAnalysis
{
   public static class TextWriter
    {

        public static string LOG_PATH =string.Empty;
        public static string LOG_FILE = string.Empty;

        public static object populationLock = new object();
        static ReaderWriterLock locker = new ReaderWriterLock();
        // 파일에 로깅
        /// <summary>
        /// Todo 스래드 작동시 문제가 발생되지 않도록 수정.2022.10.12 스래드 safe 사용
        /// https://learn.microsoft.com/en-us/dotnet/api/system.threading.readerwriterlock?redirectedfrom=MSDN&view=net-6.0
        /// </summary>
        /// <param name="ClassName"></param>
        /// <param name="LogMessages"></param>
        public static bool LoggingToFileThreadSafe(string LogMessages)
        {
            var classname =Product;
            Thread thread = Thread.CurrentThread;
            using (TextWriterTraceListener writer = new TextWriterTraceListener(Application.StartupPath + @"\log.txt"))
            {
                try
                {
                    locker.AcquireWriterLock(int.MaxValue);

                    Trace.AutoFlush = true;
                    Trace.Listeners.Add(writer);
                    string messagetoWrite =
                      $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")} :: {LogMessages}";
                    // Console.WriteLine(messagetoWrite);
                    Trace.WriteLine(messagetoWrite);
                    Trace.Listeners.Remove(writer);
                    return true;
                }
                catch (FormatException ex)
                {
                    MessageBox.Show(ex.Message + ex.Source);
                    Console.WriteLine(ex.Message);
                    throw new Exception(ex.Message);
                }
                catch (IOException IoException)
                {
                    MessageBox.Show(IoException.Message + IoException.Source);
                    Console.WriteLine(IoException.Message);
                    throw new Exception(IoException.Message);
                }

                finally
                {
                    locker.ReleaseWriterLock();
                }

            }

        }
        /// <summary>
        /// 스래드에서 호출시 로그 폴더에 기록되지 않고 예외 발생되면서
        /// d0412131-39a3-4ec9-a87b-bdb6bc6e219elog 이런 형태로 기록됨 
        /// </summary>
        /// <param name="ClassName"></param>
        /// <param name="LogMessages"></param>
        public static void LoggingToFile(string ClassName, string LogMessages)
        {
            var classname = Product;
            Thread thread = Thread.CurrentThread;
            string? FileTitle = Path.GetFileNameWithoutExtension(Assembly.GetEntryAssembly().Location); // Get File Title
            string? AssemblyName = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            string? LogFolder = $"{AssemblyName}\\LOGS";
            var LogPathfile = $"{LogFolder}\\{FileTitle}_{DateTime.Now.ToString("yyyy-MM-dd")}.LOG";
            using (TextWriterTraceListener writer = new TextWriterTraceListener(LogPathfile))
            {
                try
                {

                    if (!Directory.Exists(LogFolder))
                    { 
                     Directory.CreateDirectory(LogFolder);
                    }
                        


                    locker.AcquireWriterLock(int.MaxValue);

                    Trace.AutoFlush = true;
                    Trace.Listeners.Add(writer);
                    string messagetoWrite =
                      $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")} :: {LogMessages} :: {ClassName}";
                    // Console.WriteLine(messagetoWrite);
                    Trace.WriteLine(messagetoWrite);
                    Trace.Listeners.Remove(writer);

                }
                catch (FormatException ex)
                {
                    MessageBox.Show(ex.Message + ex.Source);
                    Console.WriteLine(ex.Message);
                    throw new Exception(ex.Message);
                }
                catch (IOException IoException)
                {
                    MessageBox.Show(IoException.Message + IoException.Source);
                    Console.WriteLine(IoException.Message);
                    throw new Exception(IoException.Message);
                }

                finally
                {
                    locker.ReleaseWriterLock();
                }

            }


       


        }

        public static string Product
        {
            get
            {
                // 이어셈블리에있는모든Product 특성을가져옴
                object[] attributes =
                    Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);

                // Product 특성이없으면빈문자열을반환
                if (attributes.Length == 0) return string.Empty;

                // Product 특성이있으면해당값을반환
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

    }

}
