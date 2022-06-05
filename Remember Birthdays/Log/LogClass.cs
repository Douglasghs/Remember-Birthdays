using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Remember_Birthdays.Log
{
    public static class LogClass
    {

        const String LOG_FILE_NAME = "Remember Birthdays";
        static Boolean enableLog = true;
        static LogTag logLevel = LogTag.Debug;

        private static Object lockThis = new System.Object();

        public enum LogTag
        {
            Debug,
            Info,
            Warning,
            Error,
            System
        }

        public static String LogPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        //.GetExecutingAssembly().Location

        public static void EnableLog(Boolean value)
        {
            enableLog = value;
        }

        public static void SetLogLevel(LogTag ll)
        {
            logLevel = ll;
        }

        public static LogTag GetLogLevel()
        {
            return logLevel;
        }

        public static void Write(LogTag lt, String info,
            [System.Runtime.CompilerServices.CallerMemberName] string memberName = "", //NOSONAR 
            [System.Runtime.CompilerServices.CallerFilePath] string fileName = "") //NOSOANR
        {

            if (enableLog && (logLevel <= lt))
            {
                lock (lockThis)
                {

                    string shortFileName = Path.GetFileNameWithoutExtension(fileName);

                    String sLogsFolder = LogPath ;
                    Directory.CreateDirectory(sLogsFolder);

                    String sLogFile = Path.Combine(sLogsFolder, LOG_FILE_NAME + "-" + DateTime.Now.ToString("dd_MM_yyyy") + ".log");
                    String sLevel = lt.ToString();
                    sLevel = sLevel.PadRight(7);
                    String sSource = shortFileName + "." + memberName;
                    sSource = sSource.PadRight(40);
                    String logText = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss.fff") + "[ThreadID:" + System.Threading.Thread.CurrentThread.ManagedThreadId.ToString("0000") + "][" + sLevel + "][" + sSource + "]" + info;

                    Console.WriteLine(logText);

                    using (StreamWriter sw = new StreamWriter(sLogFile, true))
                    {
                        sw.WriteLine(logText);
                        sw.Close();
                    }

                    //Check file size
                    FileInfo fi = new FileInfo(sLogFile);
                    if (fi.Length > 50000000)
                    {
                        String sLogFileOld = Path.Combine(sLogsFolder, sLogFile + ".old");
                        File.Delete(sLogFileOld);
                        File.Move(sLogFile, sLogFileOld);
                    }
                }
            }

        }

    }
}