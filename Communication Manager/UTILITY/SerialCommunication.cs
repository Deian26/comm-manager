using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Runtime.Versioning;

namespace Communication_Manager
{
    [SupportedOSPlatform("windows")] // onlu supported on Windows
    /// <summary>
    /// Implements functions and stores values for serial data transmission/reception.
    /// </summary>
    public static class SerialCommunication
    {
        public const int SIMULATED_PORT_COUNT = 1; // number of simulated ports; the name is fixed to 'SIM-COM#number'
        public static SerialPort CrtPort = null; // current port (used for serial communication)
        public enum Direction { Transmit = 0, Receive = 1}; // Transmit = data is being transmitted app => port; Receive = data is being transmitted port => app
        public static string[] DirectionStr = { "Tx", "Rx" }; // formatted values for SerialCommunication.Direction

        // detected / simulated resources
        public static Dictionary<string, SerialPort> Resources = new Dictionary<string, SerialPort>(); // format: { resource name (string} : SerialPort object }
        
        // stored protocols
        public static Dictionary<string, Protocol> Protocols = new Dictionary<string, Protocol>(); // format: { protocol name (string) : 'Protocol' object}

        /// <summary>
        /// Sends the specified raw data to the currently selected port ('SerialCommunication.CrtPort').
        /// </summary>
        /// <param name="data">raw bytes to be sent over the port</param>
        public static void Write(byte[] data)
        {

            if (SerialCommunication.CrtPort.IsOpen == true)
            {
                SerialCommunication.CrtPort.Write(data, 0, data.Length); // send data
            }
            else // the port is closed
            {
                Logging.Log($"Port {SerialCommunication.CrtPort.PortName} is not open!", Logging.Level.ERROR);
            }
        }
    }
}
