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

        // serial communication logging
        public static DateTime SERIAL_COMM_LOG_START_TS = DateTime.UnixEpoch; // the starting timestamp for a serial communication log
        public static DateTime START_SERIAL_COMM_TS_MS = DateTime.UnixEpoch; // will be set to the current timestamp when the first serial packet is sent / received;

        public static string SERIAL_COMM_LOG = @$"{Directory.GetCurrentDirectory()}\..\..\..\ARTIFACTS\LOGS\serial--{Logging.SERIAL_COMM_LOG_START_TS}.log"; // current serial communication log, which starts when the associated
                                                                                                                   // checkbox (F1) is 'checked' and stops when it is unchecked
                                                                                                                  // (the filename will also contain the start timestamp)
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

        /// <summary>
        /// Logs the specified data to 'Logging.SERIAL_COMM_LOG'.
        /// </summary>
        /// <param name="data">raw bytes to be logged</param>
        /// <param name="data">direction of the data (transmitted or received by the application</param>
        public static void LogData(byte[] data, SerialCommunication.Direction direction)
        {
            // timestamps are in milliseconds
            File.AppendAllText(Logging.SERIAL_COMM_LOG, $"[{DateTime.Now.Subtract(Logging.SERIAL_COMM_LOG_START_TS).TotalMilliseconds}] [{SerialCommunication.DirectionStr[(int)direction]}] {Utility.FormatHextString(data)}\n");
        }
    }
    
}
