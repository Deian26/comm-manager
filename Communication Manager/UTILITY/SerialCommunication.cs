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
        // detected / simulated resources
        public static Dictionary<string, SerialPort> HardwareResources = new Dictionary<string, SerialPort>(); // format: { resource name (string} : SerialPort object }

        // stored protocols
        public static Dictionary<string, Protocol> Protocols = new Dictionary<string, Protocol>(); // format: { protocol name (string) : 'Protocol' object}


    }
}
