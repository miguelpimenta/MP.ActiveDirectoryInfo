using System;
using System.IO;
using System.Reflection;

namespace MP.Support.Logging
{
    public class Log2Text
    {
        public string LogsDir { get; set; }

        #region Singleton

        private static Log2Text instance = null;
        private static readonly object lockThis = new object();

        private Log2Text()
        {
            LogsDir = AppDomain.CurrentDomain.BaseDirectory + "Logs\\";
            if (!Directory.Exists(LogsDir))
            {
                Directory.CreateDirectory("Logs");
            }
#if DEBUG
#else
#endif
        }

        public static Log2Text Instance
        {
            get
            {
                lock (lockThis)
                {
                    if (instance == null)
                    {
                        instance = new Log2Text();
                    }

                    return instance;
                }
            }
        }

        #endregion Singleton

        /// <summary>
        /// Log error
        /// </summary>
        /// <param name="errorMessage"> Error msg.</param>
        public void ErrorLog(string errorMessage)
        {
            StreamWriter sw = null;
            string date = DateTime.Now.Date.ToString("yyyy-MM-dd");
            try
            {
                var outputDir = LogsDir + date + "-ErrorLog.txt";
                sw = new StreamWriter(outputDir, true);
                sw.WriteLine(DateTime.Now + ": " + Environment.NewLine + errorMessage);
                sw.Flush();
                sw.Close();
            }
            catch (Exception ex)
            {
                sw = new StreamWriter(Path.GetTempPath() + date + "-ErrorLog_" + Assembly.GetEntryAssembly().GetName().Name + ".txt", true);
                sw.WriteLine(DateTime.Now + ": " + Environment.NewLine + ex + Environment.NewLine + errorMessage);
                sw.Flush();
                sw.Close();
            }
        }

        /// <summary>
        /// Log error
        /// </summary>
        /// <param name="errorCode"> Error code.</param>
        /// <param name="errorMessage"> Error msg.</param>
        /// <param name="exception"> Exception info.</param>
        public void ErrorLog(string errorCode, string errorMessage, Exception exception)
        {
            StreamWriter sw = null;
            string date = DateTime.Now.Date.ToString("yyyy-MM-dd");
            try
            {
                var outputDir = LogsDir + date + "-ErrorLog.txt";
                sw = new StreamWriter(outputDir, true);
                sw.WriteLine(DateTime.Now + ": " + Environment.NewLine + "|" + errorCode + "| " + Environment.NewLine + errorMessage + Environment.NewLine + "Exception Type: " + exception.GetType() + Environment.NewLine + "Exception Message: " + exception.Message);
                sw.Flush();
                sw.Close();
            }
            catch (Exception ex)
            {
                sw = new StreamWriter(Path.GetTempPath() + date + "-ErrorLog_" + Assembly.GetEntryAssembly().GetName().Name + ".txt", true);
                sw.WriteLine(DateTime.Now + ": " + Environment.NewLine + ex + Environment.NewLine + errorMessage);
                sw.Flush();
                sw.Close();
            }
        }

        /// <summary>
        /// Info log
        /// </summary>
        /// <param name="message"> Info msg.</param>
        public void InfoLog(string message)
        {
            StreamWriter sw = null;
            string date = DateTime.Now.Date.ToString("yyyy-MM-dd");
            try
            {
                var outputDir = LogsDir + date + "-InfoLog.txt";
                sw = new StreamWriter(outputDir, true);
                if (message.Length > 50)
                {
                    sw.WriteLine(DateTime.Now + ": " + Environment.NewLine + message);
                }
                else
                {
                    sw.WriteLine(DateTime.Now + ": " + message);
                }
                sw.Flush();
                sw.Close();
            }
            catch (Exception ex)
            {
                sw = new StreamWriter(Path.GetTempPath() + date + "-InfoLog_" + Assembly.GetEntryAssembly().GetName().Name + ".txt", true);
                sw.WriteLine(DateTime.Now + ": " + Environment.NewLine + ex + Environment.NewLine + message);
                sw.Flush();
                sw.Close();
            }
        }
    }
}