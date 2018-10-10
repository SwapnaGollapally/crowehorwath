/// <summary>
/// This interface is inherited by all the log writers like log file,log error to database or send email about error etc.
/// </summary>

namespace HellowWorldAPI.Interfaces
{
    public interface ILogger
    {
        void Debug(string message);
        void Debug(string messageFormat, params object[] args);
        void Error(string message);
        void Error(string messageFormat, params object[] args);
        void Fatal(string message);
        void Fatal(string messageFormat, params object[] args);
        void Info(string message);
        void Info(string messageFormat, params object[] args);
        void Warn(string message);
        void Warn(string messageFormat, params object[] args);
    }
}