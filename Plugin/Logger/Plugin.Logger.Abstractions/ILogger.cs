using System;

namespace Plugin.Logger.Abstractions
{
    /// <summary>
    /// LogLevel enum Debug, Info, Warn, Error and Fatal
    /// </summary>
    public enum LogLevel
    {
        /// <summary>
        /// Debug level logging
        /// </summary>
        Debug,
        /// <summary>
        /// Info level logging
        /// </summary>
        Info,
        /// <summary>
        /// Warn level logging
        /// </summary>
        Warn,
        /// <summary>
        /// Error level logging
        /// </summary>
        Error,
        /// <summary>
        /// Fatal level logging
        /// </summary>
        Fatal
    }
    /// <summary>
    /// Logger interface
    /// </summary>
    public interface ILogger
  {
        /// <summary>
        /// Configure log
        /// </summary>
        /// <param name="logFileName"></param>
        /// <param name="maxLogFilesCount"></param>
        /// <param name="maxLogFileSizeKb"></param>
        /// <param name="level"></param>
        /// <param name="logToConsole"></param>
        void Configure(string logFileName, int maxLogFilesCount = 3, int maxLogFileSizeKb = 100, LogLevel level = LogLevel.Warn, bool logToConsole = false);
        /// <summary>
        /// Log message
        /// </summary>
        /// <param name="logLevel"></param>
        /// <param name="tag"></param>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        void Log(LogLevel logLevel = LogLevel.Warn, string tag = "tag", string message = "message", Exception exception = null);
        /// <summary>
        /// Get the path to local storage
        /// </summary>
        /// <returns></returns>
        string GetLocalStoragePath();
        /// <summary>
        /// Get log
        /// </summary>
        /// <returns></returns>
        string GetAll();
        /// <summary>
        /// Purge log
        /// </summary>
        void Purge();
    }
}
