using Plugin.Logger.Abstractions;
using System;
using System.Collections.Generic;
using System.IO;
using Windows.Storage;
using System.Diagnostics;

namespace Plugin.Logger
{
    /// <summary>
    /// Implementation for Logger
    /// </summary>
    public class LoggerImplementation : LoggerBase
    {
        /// <summary>
        /// Configure logger
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
        /// Get local storage path
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
                StorageFolder localFolder = ApplicationData.Current.LocalFolder;
                StorageFile logFile = null;
                bool logFileFound = true;
                try
                {
                    logFile = localFolder.GetFileAsync(logFileName).GetAwaiter().GetResult();
                }
                catch (FileNotFoundException)
                {
                    logFileFound = false;
                }
                
                string formattedMessage = FormatMessage(logLevel, tag, message, exception);
                if (logFileFound)
                {
                    FileIO.AppendTextAsync(logFile, formattedMessage).GetAwaiter().GetResult();
                }
                else
                {
                    StorageFile newFile = localFolder.CreateFileAsync(logFileName).GetAwaiter().GetResult();
                    FileIO.WriteTextAsync(newFile, formattedMessage).GetAwaiter().GetResult();
                }
                bool logToConsole = GetLogToConsole();
                if (logToConsole)
                {
                    System.Diagnostics.Debug.WriteLine(formattedMessage);
                }
            }
        }
        /// <summary>
        /// Get log
        /// </summary>
        /// <returns></returns>
        public override string GetAll()
        {
            string logFileName = GetLogFileName();
            StorageFolder localFolder = ApplicationData.Current.LocalFolder;
            StorageFile logFile = localFolder.GetFileAsync(logFileName).GetAwaiter().GetResult();
            string log = FileIO.ReadTextAsync(logFile).GetAwaiter().GetResult();
            return log;
        }
        /// <summary>
        /// Purge log
        /// </summary>
        public override void Purge()
        {
            StorageFolder localFolder = ApplicationData.Current.LocalFolder;
            StorageFile logFile = null;
            bool logFileFound = true;
            string logFileName = GetLogFileName();
            try
            {
                logFile = localFolder.GetFileAsync(logFileName).GetAwaiter().GetResult();
            }
            catch (FileNotFoundException)
            {
                logFileFound = false;
            }
            if (logFileFound)
            {
                logFile.DeleteAsync().GetAwaiter().GetResult();
            }
        }
    }
}