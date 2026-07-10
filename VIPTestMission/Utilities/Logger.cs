using System;
using System.IO;

namespace VIPTestMission
{
    /// <summary>
    /// Logging utility for the VIPTestMission script
    /// </summary>
    public class Logger
    {
        private string _prefix = "";
        private static readonly object _lockObject = new object();
        private static string _logFilePath = "VIPTestMission.log";

        /// <summary>
        /// Log levels enumeration
        /// </summary>
        public enum LogLevel
        {
            Debug,
            Info,
            Warning,
            Error
        }

        /// <summary>
        /// Initializes a new logger instance
        /// </summary>
        public Logger(string prefix)
        {
            _prefix = prefix;
        }

        /// <summary>
        /// Logs a debug message
        /// </summary>
        public void Debug(string message)
        {
            Log(LogLevel.Debug, message);
        }

        /// <summary>
        /// Logs an info message
        /// </summary>
        public void Info(string message)
        {
            Log(LogLevel.Info, message);
        }

        /// <summary>
        /// Logs a warning message
        /// </summary>
        public void Warning(string message)
        {
            Log(LogLevel.Warning, message);
        }

        /// <summary>
        /// Logs an error message
        /// </summary>
        public void Error(string message)
        {
            Log(LogLevel.Error, message);
        }

        /// <summary>
        /// Internal logging method
        /// </summary>
        private void Log(LogLevel level, string message)
        {
            try
            {
                if (!App.Config.EnableLogging)
                    return;

                string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                string logMessage = $"[{timestamp}] [{level.ToString().ToUpper()}] [{_prefix}] {message}";

                // Console output
                ConsoleOutput(level, logMessage);

                // File output
                if (App.Config.DebugMode)
                {
                    FileOutput(logMessage);
                }
            }
            catch (Exception ex)
            {
                // Fail silently to prevent logging errors from crashing the script
            }
        }

        /// <summary>
        /// Outputs log to console
        /// </summary>
        private void ConsoleOutput(LogLevel level, string message)
        {
            try
            {
                // TODO: Output to GTA game console when using ScriptHookVDotNet
                // For now, output to console
                Console.WriteLine(message);
            }
            catch (Exception ex)
            {
                // Silently fail
            }
        }

        /// <summary>
        /// Outputs log to file
        /// </summary>
        private void FileOutput(string message)
        {
            lock (_lockObject)
            {
                try
                {
                    // TODO: Get proper GTA script folder path
                    string logPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _logFilePath);
                    File.AppendAllText(logPath, message + Environment.NewLine);
                }
                catch (Exception ex)
                {
                    // Silently fail
                }
            }
        }

        /// <summary>
        /// Sets the log file path
        /// </summary>
        public static void SetLogFilePath(string path)
        {
            _logFilePath = path;
        }

        /// <summary>
        /// Gets the log file path
        /// </summary>
        public static string GetLogFilePath()
        {
            return _logFilePath;
        }
    }
}
