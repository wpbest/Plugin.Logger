using Plugin.Logger.Abstractions;
using System;
using System.IO;
using System.Diagnostics;

namespace Plugin.Logger
{
    /// <summary>
    /// Implementation for Feature
    /// </summary>
    public class LoggerImplementation : LoggerBase
    {
        /// <summary>
        /// Configure Console
        /// </summary>
        /// <param name="logFileName"></param>
        /// <param name="maxLogFilesCount"></param>
        /// <param name="maxLogFileSizeKb"></param>
        /// <param name="logLevel"></param>
        /// <param name="logToConsole"></param>
        public override void Configure(string logFileName = "app.log", int maxLogFilesCount = 3, int maxLogFileSizeKb = 100, LogLevel logLevel = LogLevel.Warn, bool logToConsole = false)
        {
            base.Configure(logFileName, maxLogFilesCount, maxLogFileSizeKb, logLevel);
        }
        /// <summary>
        /// Get local stoage path
        /// </summary>
        /// <returns></returns>
        public override string GetLocalStoragePath()
        {
            string localStoragePath = Windows.Storage.ApplicationData.Current.LocalFolder.Path;
            return localStoragePath;
        }
        /// <summary>
        /// Log message
        /// </summary>
        /// <param name="logLevel"></param>
        /// <param name="tag"></param>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public override void Log(LogLevel logLevel = LogLevel.Warn, string tag = "tag", string message = "message", Exception exception = null)
        {
            LogLevel currentLogLevel = GetLogLevel();
            if (logLevel >= currentLogLevel)
            {
                string logFileName = GetLogFileName();
                string localStoragePath = GetLocalStoragePath();
                string logFilePath = Path.Combine(localStoragePath, logFileName);
                string formattedMessage = FormatMessage(logLevel, tag, message, exception);
                File.AppendAllText(logFilePath, formattedMessage);
                bool logToConsole = GetLogToConsole();
                if (logToConsole)
                {
                    Debug.WriteLine(formattedMessage);
                }
            }
        }
        /// <summary>
        /// Get log
        /// </summary>
        /// <returns></returns>
        public override string GetAll()
        {
            string log = "";
            string logFileName = GetLogFileName();
            string localStoragePath = GetLocalStoragePath();
            string logFilePath = Path.Combine(localStoragePath, logFileName);
            if (File.Exists(logFilePath)) log = File.ReadAllText(logFilePath);
            return log;
        }
        /// <summary>
        /// Purge log
        /// </summary>
        public override void Purge()
        {
            string logFileName = GetLogFileName();
            string localStoragePath = GetLocalStoragePath();
            string logFilePath = Path.Combine(localStoragePath, logFileName);
            if (File.Exists(logFilePath)) File.Delete(logFilePath);
        }
    }
}