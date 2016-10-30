using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugin.Logger.Abstractions
{
    /// <summary>
    /// Logger base class
    /// </summary>
    public class LoggerBase : ILogger
    {
        private string logFileName;
        private int maxLogFilesCount;
        private int maxLogFileSizeKb;
        private LogLevel logLevel;
        private bool logToConsole;
        /// <summary>
        /// Constructor
        /// </summary>
        public LoggerBase()
        {
            logFileName = "app.log";
            maxLogFilesCount = 3;
            maxLogFileSizeKb = 100;
            logLevel = LogLevel.Warn;
            logToConsole = false;
        }
        /// <summary>
        /// Get the log file name
        /// </summary>
        /// <returns></returns>
        public string GetLogFileName()
        {
            return this.logFileName;
        }
        /// <summary>
        /// Get log level
        /// </summary>
        /// <returns></returns>
        public LogLevel GetLogLevel()
        {
            return logLevel;
        }
        /// <summary>
        /// Get logToConsole
        /// </summary>
        /// <returns></returns>
        public bool GetLogToConsole()
        {
            return logToConsole;
        }
        /// <summary>
        /// Format message
        /// </summary>
        /// <param name="logLevel"></param>
        /// <param name="tag"></param>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        /// <returns></returns>
        public string FormatMessage (LogLevel logLevel = LogLevel.Warn, string tag = "tag", string message = "message", Exception exception = null)
        {
            string formattedMessage = "";
            if (exception == null)
            {
                formattedMessage = String.Format("{0} {1} {2} {3}", logLevel, DateTime.UtcNow, tag, message);
            }
            else
            {
                formattedMessage = String.Format("{0} {1} {2} {3} EXCEPTION: {4} STACK TRACE: {5}", logLevel.ToString(), DateTime.UtcNow, tag, message, exception.Message, exception.StackTrace.ToString());
            }
            formattedMessage += Environment.NewLine;
            return formattedMessage;
        }
        /// <summary>
        /// Configure logger
        /// </summary>
        /// <param name="logFileName"></param>
        /// <param name="maxLogFilesCount"></param>
        /// <param name="maxLogFileSizeKb"></param>
        /// <param name="logLevel"></param>
        /// <param name="logToConsole"></param>
        public virtual void Configure(string logFileName = "app.log", int maxLogFilesCount = 3, int maxLogFileSizeKb = 100, LogLevel logLevel = LogLevel.Warn, bool logToConsole = false)
        {
            this.logFileName = logFileName;
            this.maxLogFilesCount = maxLogFilesCount;
            this.maxLogFileSizeKb = maxLogFileSizeKb;
            this.logLevel = logLevel;
            this.logToConsole = logToConsole;
        }

        /// <summary>
        /// Get local storage path
        /// </summary>
        /// <returns></returns>
        public virtual string GetLocalStoragePath()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Log meggage
        /// </summary>
        /// <param name="logLevel"></param>
        /// <param name="tag"></param>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public virtual void Log(LogLevel logLevel = LogLevel.Warn, string tag ="tag", string message ="message", Exception exception = null)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Get local storage path
        /// </summary>
        /// <returns></returns>
        public virtual string GetAll ()
        {
            string log = "";
            return log;
        }
        /// <summary>
        /// Purge log
        /// </summary>
        public virtual void Purge()
        {
            throw new NotImplementedException();
        }
    }
}
