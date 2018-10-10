/// <summary>
/// This file is responsible for writing the application errors to a log system.
/// </summary>
using HellowWorldAPI.Enumerations;
using HellowWorldAPI.Interfaces;
using System;
using System.Configuration;
using System.IO;
using System.Text;
namespace HellowWorldAPI.Logger
{
    public class ApplicationFileLogger : ILogger
    {
        private string DatetimeFormat;
        private string Filename;
        public ApplicationFileLogger()
        {
            DatetimeFormat = "yyyy-MM-dd HH:mm:ss.fff";
            string directoryPath = ConfigurationManager.AppSettings["application_log"].ToString();
            Filename = ConfigurationManager.AppSettings["application_log"] + "\\" +DateTime.Now.ToFileTime() + ".log";
            // Log file header line
            if (!string.IsNullOrWhiteSpace(directoryPath))
            {
                //create directory if not exists.
                Directory.CreateDirectory(directoryPath);
                using (var fileStream = File.Open(Filename, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                {

                }
            }
        }
        public ILogger Logger { get; set; }

        public void Debug(string message)
        {
            WriteFormattedLog(LogLevel.DEBUG, message);
        }

        public void Debug(string messageFormat, params object[] args)
        {
            WriteFormattedLog(LogLevel.DEBUG, messageFormat);
        }

        public void Error(string message)
        {
            WriteFormattedLog(LogLevel.ERROR, message);
        }

        public void Error(string messageFormat, params object[] args)
        {
            WriteFormattedLog(LogLevel.ERROR, messageFormat);
        }

        public void Fatal(string message)
        {
            WriteFormattedLog(LogLevel.FATAL, message);
        }

        public void Fatal(string messageFormat, params object[] args)
        {
            WriteFormattedLog(LogLevel.FATAL, messageFormat);
        }

        public void Info(string message)
        {
            WriteFormattedLog(LogLevel.INFO, message);
        }

        public void Info(string messageFormat, params object[] args)
        {
            WriteFormattedLog(LogLevel.INFO, messageFormat);
        }

        public void Warn(string message)
        {
            WriteFormattedLog(LogLevel.TRACE, message);
        }

        public void Warn(string messageFormat, params object[] args)
        {
            WriteFormattedLog(LogLevel.TRACE, messageFormat);
        }
        /// <summary>
        /// Format a log message based on log level
        /// </summary>
        /// <param name="level">Log level</param>
        /// <param name="text">Log message</param>
        private void WriteFormattedLog(LogLevel level, string text)
        {
            string pretext;
            switch (level)
            {
                case LogLevel.TRACE: pretext = DateTime.Now.ToString(DatetimeFormat) + " [TRACE]   "; break;
                case LogLevel.INFO: pretext = DateTime.Now.ToString(DatetimeFormat) + " [INFO]    "; break;
                case LogLevel.DEBUG: pretext = DateTime.Now.ToString(DatetimeFormat) + " [DEBUG]   "; break;
                case LogLevel.WARNING: pretext = DateTime.Now.ToString(DatetimeFormat) + " [WARNING] "; break;
                case LogLevel.ERROR: pretext = DateTime.Now.ToString(DatetimeFormat) + " [ERROR]   "; break;
                case LogLevel.FATAL: pretext = DateTime.Now.ToString(DatetimeFormat) + " [FATAL]   "; break;
                default: pretext = ""; break;
            }

            WriteLine(pretext + text);
        }

        /// <summary>
        /// Write a line of formatted log message into a log file
        /// </summary>
        /// <param name="text">Formatted log message</param>
        /// <param name="append">True to append, False to overwrite the file</param>
        /// <exception cref="System.IO.IOException"></exception>
        private void WriteLine(string text, bool append = true)
        {
            try
            {
                using (StreamWriter Writer = new StreamWriter(Filename, append, Encoding.UTF8))
                {
                    if (text != "") Writer.WriteLine(text);
                }
            }
            catch
            {
                throw;
            }
        }
       
    }
    
}


