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
        public string name { get; }
        public string description { get; }
        public Frame frame { get; }
        public Frame eofFrame { get; }
        public string interfaceType { get; } // e.g., Serial
        public string resourceType { get; } // e.g., COM
        
        // application specific data
        public string appIdField { get; } // the name of the field that contains the app ID
        public string appDataField { get; } // the name of the field that contains the useful (app) data

        public Protocol(string name, string description, 
                        Frame frame, Frame eofFrame, 
                        string interfaceType, string resourceType,
                        string appIdField, string appDataField
                        )
        {
            this.name = name;
            this.description = description;
            this.frame = frame;
            this.eofFrame = eofFrame;
            this.interfaceType = interfaceType;
            this.resourceType = resourceType;
            this.appIdField = appIdField;
            this.appDataField = appDataField;
        }
    }
}
