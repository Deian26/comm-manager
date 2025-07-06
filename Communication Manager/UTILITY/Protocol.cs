using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Communication_Manager
{
    /// <summary>
    /// Defines a communication protocol.
    /// </summary>
    public class Protocol
    {
        private string name { get; }
        private string description { get; }
        private Frame frame { get; }
        private string interfaceType { get; } // e.g., Serial
        private string resourceType { get; } // e.g., COM


        public Protocol(string name, string description, Frame frame, string interfaceType, string resourceType)
        {
            this.name = name;
            this.description = description;
            this.frame = frame;
            this.interfaceType = interfaceType;
            this.resourceType = resourceType;
        }
    }
}
