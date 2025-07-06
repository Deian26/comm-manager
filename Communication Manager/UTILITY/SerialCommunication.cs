using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Communication_Manager
{
    /// <summary>
    /// Implements functions and stores values for serial data transmission/reception.
    /// </summary>
    public static class SerialCommunication
    {
        // stored protocols
        public static Dictionary<string, Protocol> Protocols = new Dictionary<string, Protocol>(); // format: { protocol name (string) : 'Protocol' object}


    }
}
