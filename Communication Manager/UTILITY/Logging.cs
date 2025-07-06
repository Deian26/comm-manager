using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Communication_Manager
{
    /// <summary>
    /// Implements logging.
    /// </summary>
    static class Logging
    {
        static string LOG_FILE = @$"{Directory.GetCurrentDirectory()}\..\..\..\ARTIFACTS\LOGS\log.log";
        public enum Level { INFO = 0, WARN, ERROR, DEBUG };

        /// <summary>
        /// Initializes logging.
        /// </summary>
        public static void InitLog()
        {
            File.Create(Logging.LOG_FILE).Close(); // overwrite the log file
            File.AppendAllText(Logging.LOG_FILE, $"Started log at {DateTime.UtcNow.ToLocalTime()}\n");
        }

        /// <summary>
        /// Log an event with the given message and level and the current local date and time.
        /// </summary>
        /// <param name="message">the message to be logged</param>
        /// <param name="level">the level (must be taken from 'Logging.Level')</param>
        public static void Log(string message, Logging.Level level)
        {
            // print the message to the log file set in 'Logging.LOG_FILE'
            File.AppendAllText(Logging.LOG_FILE, $"{DateTime.UtcNow.ToLocalTime()} > [{Enum.GetName(level)}] {message}\n");
        }
    }
    
}
