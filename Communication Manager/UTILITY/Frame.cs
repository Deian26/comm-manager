using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Communication_Manager
{
    /// <summary>
    /// Defines a frame transmitted / received over an interface.
    /// </summary>
    public class Frame
    {
        public struct Field
        {
            public string name;
            public int bitSize; // left -> right
            public string relativeLengthFieldName = null; // the name of the field that determines the length of this field (optional)
            public Dictionary<string, string> interpretations = new Dictionary<string, string>(); // possible interpretations for the values contained by this field

            // eof
            public bool eof; // marks the EoF
            public int eofValue; // the expected field value for the frame to be considered an EoF frame
            
            /// <summary>
            /// Store details about the field.
            /// </summary>
            /// <param name="name">field name</param>
            /// <param name="value">value for either the bit-size attribute (general an frame) or expected field value (for an EoF frame)</param>
            /// <param name="eof">if true, this field is part of an EoF frame</param>
            public Field(string name, int value, bool eof, string relativeLengthFieldName, Dictionary<string, string> interpretations)
            {
                this.name = name;
                this.relativeLengthFieldName = relativeLengthFieldName; // optional; if not relevant, this field will be 'null'

                if (eof == true) // EoF frame
                {
                    this.eofValue = value;
                }
                else // general frame
                {
                    this.bitSize = value;
                }

                // add interpretations, if any
                this.interpretations = interpretations;
            }
        }

        public double breakTimeNs; // the break time, in ns, between frames
        public Dictionary<string, Field> fields = new Dictionary<string, Field>();  // a field from the frame
        
        public bool eof; // if 'true', this object defines an EoF frame
        public double eofTimeoutNs; // optional timeout, in ns, after which a transmission is considered to have timed out; 'eof' must also be 'true' for this value to have an effect
    }
}
