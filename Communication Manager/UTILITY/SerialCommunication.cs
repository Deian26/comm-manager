using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Runtime.Versioning;
using System.IO;
using System.Runtime.CompilerServices;

namespace Communication_Manager
{
    [SupportedOSPlatform("windows")] // only supported on Windows
    /// <summary>
    /// Implements functions and stores values for serial data transmission/reception.
    /// </summary>
    public static class SerialCommunication
    {
        public const int SIMULATED_PORT_COUNT = 1; // number of simulated ports; the name is fixed to 'SIM-COM#number'
        public static SerialPort CrtPort = null; // current port (used for serial communication)
        public static int READ_TIMEOUT_MS = 100; // timeout, in ms, used when reading the input buffer

        public static int MAX_READ_BUFFER_SIZE_BYTES = 4096;
        public static int MAX_WRITE_BUFFER_SIZE = 4096;
        public static int READ_WRITE_TIMEOUT_MS = 1000;
        public static int SEND_TELEGRAM_COOLDOWN_MS = 100; // time waited after a telegram is sent (to prevent the connection from breaking

        public enum Direction { Transmit = 0, Receive = 1}; // Transmit = data is being transmitted app => port; Receive = data is being transmitted port => app
        public static string[] DirectionStr = { "Tx", "Rx" }; // formatted values for SerialCommunication.Direction

        // logging
        public static DateTime COMM_LOG_START_TS = DateTime.UnixEpoch; // the starting timestamp for a serial communication log
        public static string COMM_LOG = @$"{Directory.GetCurrentDirectory()}\..\..\..\ARTIFACTS\LOGS\serial--{SerialCommunication.COMM_LOG_START_TS}.log"; // current serial communication log, which starts when the associated

        // detected / simulated resources
        public static Dictionary<string, SerialPort> Resources = new Dictionary<string, SerialPort>(); // format: { resource name (string} : SerialPort object }
        
        // stored protocol and app definitions
        public static Dictionary<string, Protocol> Protocols = new Dictionary<string, Protocol>(); // format: { protocol name (string) : 'Protocol' object}

        // stored protocol display styles (the background colour will be changed by the system, to show whether a telegram is sent or received)
        public static Dictionary<string, Dictionary<SerialCommunication.Direction,DataGridViewCellStyle>> ProtocolStyles = new Dictionary<string, Dictionary<SerialCommunication.Direction, DataGridViewCellStyle>>();

        /// <summary>
        /// Sends the specified raw data to the currently selected port ('SerialCommunication.CrtPort').
        /// </summary>
        /// <param name="data">raw bytes to be sent over the port</param>
        /// <returns>error code: 0 = no error, -1 = port closed; -2 = error sending data</returns>
        public static int Write(byte[] data)
        {

            if (SerialCommunication.CrtPort.IsOpen == true)
            {
                try
                {
                    SerialCommunication.CrtPort.Handshake = Handshake.None; // expect no handshake protocol
                    SerialCommunication.CrtPort.DtrEnable = true; // do not wait for receive confirmation

                    SerialCommunication.CrtPort.Write(data, 0, data.Length); // send data

                    return 0;
                }catch(Exception ex)
                {
                    Logging.Log($"Could not send data over resource {SerialCommunication.CrtPort.PortName} ! Details: {ex.Message}", Logging.Level.ERROR);
                    return -2;
                }
            }
            else // the port is closed
            {
                Logging.Log($"Port {SerialCommunication.CrtPort.PortName} is not open!", Logging.Level.ERROR);
                return -1;
            }
        }

        /// <summary>
        /// Sends the specified data over the given resource, using the given settings.
        /// </summary>
        /// <param name="dataHexStr">data to be sent as a hex-string</param>
        /// <param name="resource">name of the resource (string)</param>
        /// <param name="baudRate">baud rate (int)</param>
        /// <param name="errMsgs">recorded error messages, if any; otherwise the variable will store an empty string</param>
        /// <returns>error code: 0 = no error, -1 = port closed, -2 = error sending data; -3 = general error</returns>
        public static int SendData(string dataHexStr, string resource, int baudRate, out string errMsgs)
        {

            // validate input (bytes)
            errMsgs = ""; // no error (init)
            int writeErrCode = 0; // no error sending data
            byte[] rawBytes = Utility.getBytesFromHexString(dataHexStr);

            if (rawBytes.Length != 0) // valid hex-string
            {
                try
                {
                    // close the previous serial communication port (if it exists and is open)
                    if (SerialCommunication.CrtPort != null)
                    {
                        if (SerialCommunication.CrtPort.IsOpen == true)
                            SerialCommunication.CrtPort.Close();
                    }

                    // get the new port and set it as the current serial communication port for the application
                    SerialCommunication.CrtPort = SerialCommunication.Resources[resource];

                    // if this is a simulated resource, remove the prefix
                    if (SerialCommunication.CrtPort.PortName.StartsWith("SIM-") == false)
                    { // real port

                        SerialCommunication.CrtPort.Open(); // open port

                        // set communication details
                        SerialCommunication.CrtPort.BaudRate = baudRate;

                        // send data
                        writeErrCode = SerialCommunication.Write(rawBytes); // error code

                        // clear buffer
                        SerialCommunication.CrtPort.DiscardOutBuffer();
                    }
                }
                catch (Exception ex) // error sending data
                {
                    errMsgs += $"Error sending raw data! Details: {ex.Message}";
                    Logging.Log($"Error sending raw data! Details: {ex.Message}", Logging.Level.ERROR);
                    writeErrCode = - 3; // general error
                }
            
            }
            else // invalid data to be sent
            {
                errMsgs += $"Invalid byte data: 0x{dataHexStr} !";
                writeErrCode = -3;
            }

            return writeErrCode;
        }
    }
}
