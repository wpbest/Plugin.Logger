using System;

namespace Plugin.Logger.Abstractions
{
    public enum LogLevel
    {
        Debug,
        Info,
        Warn,
        Error,
        Fatal
    }
    public interface ILogger
  {
        void Log(LogLevel logLevel, string tag, string message);
        string GetApplicationLocalStoragePath();
    }
}
