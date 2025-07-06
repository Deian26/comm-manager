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
            string name;
            int bitSize; // left -> right
            
            // eof
            bool eof;
            int eofValue; // the expected field value for the frame to be considered an EoF frame
            
            /// <summary>
            /// Store details about the field.
            /// </summary>
            /// <param name="name">field name</param>
            /// <param name="value">value for either the bit-size attribute (general an frame) or expected field value (for an EoF frame)</param>
            /// <param name="eof">if true, this field is part of an EoF frame</param>
            public Field(string name, int value, bool eof)
            {
                this.name = name;
                
                if(eof == true) // EoF frame
                {
                    this.eofValue = value;
                }
                else // general frame
                {
                    this.bitSize = value;
                }
            }
        }

        public double breakTimeNs; // the break time, in ns, between frames
        public Dictionary<string, Field> Fields = new Dictionary<string, Field>();  // a field from the frame
        
        public bool eof; // if 'true', this object defines an EoF frame
        public double eofTimeoutNs; // optional timeout, in ns, after which a transmission is considered to have timed out; 'eof' must also be 'true' for this value to have an effect
    }
}
