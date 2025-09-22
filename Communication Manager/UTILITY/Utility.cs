using System.Diagnostics.Tracing;
using System.IO;
using System.IO.Ports;
using System.Numerics;
using System.Printing;
using System.Runtime;
using System.Text;
using System.Windows.Controls;
using System.Xml;

namespace Communication_Manager
{
    /// <summary>
    /// Implements configuration and auxiliary methods.
    /// </summary>
    static class Utility
    {
        #region conversion-tables
        public static string[] HexDigit2BinStr = { // binary string values for the hex digits; the index of this array represents the hex digit (e.g., the binary string for 0x0F is stored at [15])
            "0000", // 0x00
            "0001", // 0x01
            "0010", // 0x02
            "0011", // 0x03
            "0100", // 0x04
            "0101", // 0x05
            "0110", // 0x06
            "0111", // 0x07
            "1000", // 0x08
            "1001", // 0x09
            "1010", // 0x0A
            "1011", // 0x0B
            "1100", // 0x0C
            "1101", // 0x0D
            "1110", // 0x0E
            "1111" // 0x0F
            };

        public static string[] Int2HexDigit = { // contains values for converting integers into hex digit strings; the index of the array corresponds to the int value to be converted
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "A",
            "B",
            "C",
            "D",
            "E",
            "F"
        };
        #endregion

        #region configuration
        public const int LOADING_FORM_APP_START_DELAY_MS = 2000; // ms to wait after initializing the application, before form F0 is hidden and form F1 is opened
        public static string CONFIG_FOLDER_PATH = @$"{Directory.GetCurrentDirectory()}\..\..\..\UTILITY\RESOURCES\COMM_DEF\"; // local configuration files folder path
        public const string HEX_DIGTIS = "0123456789ABCDEF";
        

        /// <summary>
        /// Load protocol definition files from the specified folder.
        /// </summary>
        /// <param name="configFolderPath">configuration files folder</param>
        /// <param name="eventLog">ListBox where the names of the files being loaded should be displayed in real-time</param>
        public static void LoadProtocolDefinitions(string configFolderPath, System.Windows.Forms.ListBox eventLog)
        {
            if (Directory.Exists(configFolderPath) == false) // invalid path
            {
                Logging.Log($"Invalid path to the configuration folder path: {configFolderPath}", Logging.Level.WARN);
            }

            try
            {
                // load the definitions in memory
                XmlDocument defFile = new XmlDocument();
                eventLog.Items.Add($"Config folder: {Path.GetFullPath(configFolderPath)}");

                foreach (string filePath in Directory.EnumerateFiles(configFolderPath))
                {
                    eventLog.Items.Add($"Loading {Path.GetFileName(filePath)}..."); // log file being loaded
                    defFile.Load(filePath);
                    string protocolName = null, description = null, interfaceType = null, resourceType = null, appIdField = null, appDataField = null;
                    Frame frame = new Frame();
                    Frame eofFrame = new Frame();
                    Dictionary<string, string> interpretations = null;
                    List<string> tempFieldNames = new List<string>(); // temporarily store field names for processing

                    if (defFile.DocumentElement.Attributes["name"] == null)
                    {
                        Logging.Log($"The definition file '{filePath}' does not contain a protocol name!", Logging.Level.ERROR);
                    }
                    
                    protocolName = defFile.DocumentElement.Attributes["name"].Value;
                    
                    foreach (XmlNode node in defFile.DocumentElement.ChildNodes)
                    {
                        // extract details
                        switch (node.Name)
                        {
                            case "description":
                                {
                                    description = node.InnerText;
                                    break;
                                }
                            case "interface":
                                {
                                    if (node.Attributes["type"] == null)
                                    {
                                        Logging.Log($"Interface definition for protocol '{defFile.DocumentElement.Attributes["name"].Value}' is missing the mandatory attribute 'type' !", Logging.Level.ERROR);
                                        continue; // skip node
                                    }

                                    if (node.Attributes["resource-type"] == null)
                                    {
                                        Logging.Log($"Interface definition for protocol '{defFile.DocumentElement.Attributes["name"].Value}' is missing the mandatory attribute 'resource-type' !", Logging.Level.ERROR);
                                        continue; // skip node
                                    }

                                    interfaceType = node.Attributes["type"].Value;
                                    resourceType = node.Attributes["resource-type"].Value;
                                    break;
                                }
                            case "frame":
                                {
                                    if (node.Attributes["break-time-ns"] == null)
                                    {
                                        Logging.Log($"Frame definition for protocol '{defFile.DocumentElement.Attributes["name"].Value}' is missing the mandatory attribute 'break-time-ns' !", Logging.Level.ERROR);
                                        continue; // skip node
                                    }

                                    // extract frame details and construct a Frame object from it
                                    frame.breakTimeNs = Double.Parse(node.Attributes["break-time-ns"].Value);

                                    foreach(XmlNode field in node.ChildNodes)
                                    {
                                        if(field.Name.Equals("field") == true)
                                        {
                                            string relativeLengthFieldName = null; // the field that contains the length for this field (optional)
                                            if (field.Attributes["name"] == null)
                                            {
                                                Logging.Log($"Invalid field definition! The definition of a field (general frame definition) is missing the mandatory 'name' attribute!", Logging.Level.ERROR);
                                                continue; // skip node
                                            }

                                            tempFieldNames.Add(field.Attributes["name"].Value); // temporarily store field name

                                            if (field.Attributes["bit-size"] == null)
                                            {
                                                Logging.Log($"Invalid field definition! The definition of field '{field.Attributes["name"].Value}' is missing the mandatory 'bit-size' attribute!", Logging.Level.ERROR);
                                                continue; // skip node
                                            }
                                            if (field.Attributes["relative-length"] != null) // the length of this field is given by the field specified in this attribute
                                            {
                                                relativeLengthFieldName = field.Attributes["relative-length"].Value;
                                                if (tempFieldNames.Contains(relativeLengthFieldName) == false) // invalid relative length field name
                                                {
                                                    Logging.Log($"Invalid relative length field name! The name of the field ('{relativeLengthFieldName}') that contains the length for field '{field.Attributes["name"].Value}' does not exist in the definition of this frame !", Logging.Level.ERROR);
                                                    continue; // skip node
                                                }
                                            }
                                            if (field.Attributes["appID"] != null)
                                            {
                                                if(field.Attributes["appID"].Value.ToUpper() == "TRUE") // this field contains the app ID (hex)
                                                {
                                                    appIdField = field.Attributes["name"].Value;
                                                }
                                            }

                                            if (field.Attributes["appData"] != null)
                                            {
                                                if (field.Attributes["appData"].Value.ToUpper() == "TRUE") // this field contains the app ID (hex)
                                                {
                                                    appDataField = field.Attributes["name"].Value;
                                                }
                                            }

                                            // get interpretations
                                            interpretations = new Dictionary<string, string>(); // format: {hex-value (without the '0x' prefix) : meaning (string)}
                                            foreach (XmlNode interpretation in field.ChildNodes)
                                            {
                                                if (interpretation.Name.Equals("interpretation"))
                                                {
                                                    if (interpretation.Attributes["value"] != null && interpretation.Attributes["meaning"] != null)
                                                    {
                                                        interpretations.Add(interpretation.Attributes["value"].Value.Replace("0x", "").Replace(" ",""), interpretation.Attributes["meaning"].Value.ToString());
                                                    }
                                                    else // invalid definition
                                                    {
                                                        Logging.Log($"Invalid interpretation definition for field {field.Name} ! At least 1 of the interpretations is missing the 'value' or 'meaning' field!", Logging.Level.ERROR);
                                                    }
                                                }
                                            }

                                            frame.fields.Add(
                                                field.Attributes["name"].Value, // key
                                                new Frame.Field( // value
                                                    field.Attributes["name"].Value, // field name
                                                    Int32.Parse(field.Attributes["bit-size"].Value), // bit size (since eof = false)
                                                    false, // eof = false
                                                    relativeLengthFieldName,
                                                    interpretations
                                                    )
                                                );
                                        }
                                        else if (field.Name.Equals("#comment") == true)
                                        {
                                            continue; // skip comment
                                        }
                                        else // unrecognized field definition node
                                        {
                                            Logging.Log($"Unrecognized field definition node: {field.Name}!", Logging.Level.WARN);
                                            continue; // skip field node
                                        }
                                    }

                                    break;
                                }
                            case "eof": // definition of an 'End of File' frame (marks the end of a transmission)
                                {
                                    foreach (XmlNode eofFrameSubnode in node.ChildNodes)
                                    {
                                        // extract frame details and construct a Frame object from it
                                        eofFrame.eof = true;

                                        switch (eofFrameSubnode.Name)
                                        {
                                            case "frame":
                                            {
                                                foreach (XmlNode field in eofFrameSubnode.ChildNodes)
                                                {
                                                    if (field.Name.Equals("field") == true)
                                                    {
                                                        if (field.Attributes["name"] == null)
                                                        {
                                                            Logging.Log($"Invalid field definition! The definition of a field is missing the mandatory 'name' attribute!", Logging.Level.ERROR);
                                                            continue; // skip node
                                                        }
                                                        
                                                        tempFieldNames.Add(field.Attributes["name"].Value); // temporarily store field name
                                                        
                                                        if (field.Attributes["value"] == null)
                                                        {
                                                            Logging.Log($"Invalid field definition! The definition of field '{field.Attributes["name"].Value}' (EoF frame) is missing the mandatory 'value' attribute!", Logging.Level.ERROR);
                                                            continue; // skip node
                                                        }

                                                        eofFrame.fields.Add(
                                                        field.Attributes["name"].Value, // key
                                                        new Frame.Field( // value
                                                            field.Attributes["name"].Value, // field name
                                                            Int32.Parse(field.Attributes["value"].Value), // EoF frame field value (since eof = true)
                                                            true, // eof = true
                                                            null, // relative length field name (optional; not present for EoF frames)
                                                            null // interpretation (none for EoF telegrams)
                                                            )
                                                        );
                                                    }
                                                    else if (field.Name.Equals("#comment") == true)
                                                    {
                                                        continue; // skip comment
                                                    }
                                                    else // unrecognized field definition node
                                                    {
                                                        Logging.Log($"Unrecognized field definition node: {field.Name}!", Logging.Level.WARN);
                                                        continue; // skip field
                                                    }

                                                }
                                                break;
                                            }

                                            case "timeout":
                                                {
                                                    if(eofFrameSubnode.Attributes["timeout-ns"] == null)
                                                    {
                                                        Logging.Log($"The EoF frame definition 'timeout' sub-node is missing the mandatory 'timeout-ns' attribute!", Logging.Level.ERROR);
                                                        continue; // skip node
                                                    }

                                                    eofFrame.eofTimeoutNs = Double.Parse(eofFrameSubnode.Attributes["timeout-ns"].Value);
                                                    break;
                                                }

                                            case "#comment":
                                                {
                                                    continue; // skip comment
                                                }
                                            default:
                                                {
                                                    Logging.Log($"Unrecognized node for an EoF sub-node definition: {eofFrameSubnode.Name}", Logging.Level.ERROR);
                                                    break;
                                                }
                                        } 
                                    }

                                    break;
                                }
                            case "#comment": // XML comment
                                {
                                    continue;// ignore the comment
                                }
                            case "styles": // basic style options for the way the telegrams are formatted
                                {
                                    // create and store styles
                                    SerialCommunication.ProtocolStyles.Clear(); // reset styles
                                    
                                    // create styles placeholder
                                    SerialCommunication.ProtocolStyles.Add(
                                        protocolName,
                                        new Dictionary<SerialCommunication.Direction, DataGridViewCellStyle>()
                                        );

                                    foreach (XmlNode styleNode in node.ChildNodes)
                                    {
                                        if (styleNode.Name == "#comment") // skip comments
                                            continue;
                                        
                                        if (styleNode.Attributes["background-colour"] == null || styleNode.Attributes["foreground-colour"] == null)
                                        {
                                            // missing stylistic attribute; skip node
                                            Logging.Log($"Incomplete style definition at: {node.Name} (missing at least 1 stylistic attribute - e.g., background or foreground colour)", Logging.Level.ERROR);
                                            continue;
                                        }
                                        DataGridViewCellStyle gridRowStyle = new DataGridViewCellStyle();
                                        gridRowStyle.ForeColor = Color.FromName(styleNode.Attributes["foreground-colour"].Value);
                                        gridRowStyle.BackColor = Color.FromName(styleNode.Attributes["background-colour"].Value);

                                        if (styleNode.Name.Equals("tx")) // transmitted telegram (transmitted by the Communication Manager utility)
                                        {
                                            // associate the style with the direction of the telegram
                                            SerialCommunication.ProtocolStyles[protocolName].Add(
                                                SerialCommunication.Direction.Transmit,
                                                gridRowStyle
                                                );
                                        }
                                        else if (styleNode.Name.Equals("rx")) // received telegram
                                        {
                                            // associate the style with the direction of the telegram
                                            SerialCommunication.ProtocolStyles[protocolName].Add(
                                                SerialCommunication.Direction.Receive,
                                                gridRowStyle
                                                );
                                        }
                                        else // erroneous definition
                                        {
                                            Logging.Log($"Unrecognized telegram style definition for: {styleNode.Name} (unknown node name)", Logging.Level.ERROR);
                                        }
                                    }

                                    break;
                                }

                            default: // unrecognized node
                                {
                                    Logging.Log($"Unrecognized communication definition item: {node.Name}", Logging.Level.WARN);
                                    break;
                                }
                        }
                    }
                    
                    // store protocol details
                    SerialCommunication.Protocols.Add(
                        defFile.DocumentElement.Attributes["name"].Value, // key
                        new Protocol( // value
                            defFile.DocumentElement.Attributes["name"].Value, // protocol name
                            description, // protocol description
                            frame, // frame definition
                            eofFrame, // EoF frame definition
                            interfaceType, // e.g., Serial
                            resourceType, // e.g., COM
                            appIdField, // the name of the field that contains the app ID
                            appDataField // the name of the field that contains the app data
                            )
                        );

                }
            }
            catch(Exception ex)
            {
                eventLog.Items.Add($"Error loading configuration files! Check the error log!"); // log file being loaded
                Logging.Log($"Error loading configuration from file! Details: {ex.Message}", Logging.Level.ERROR);
            }
        }

        /// <summary>
        /// Detects the available resources on the current machine and adds defined simulated ones and stores data about them in memory.
        /// </summary>
        /// <param name="onlySimulatedResources">if 'true', hardware resources are not added/removed from the list</param>
        public static void LoadResources(bool onlySimulatedResources)
        {
            // reset resource list
            SerialCommunication.Resources.Clear();
            string[] portsInUse = SerialPort.GetPortNames();

            // add simulated resources (the number of simulated serial ports is stored in SerialCommunication.SIMULATED_PORT_COUNT)
            string simPortName;
            for (int simPortIndex = 0; simPortIndex < SerialCommunication.SIMULATED_PORT_COUNT; simPortIndex++)
            {
                simPortName = $"SIM-COM{simPortIndex}";
                SerialCommunication.Resources.Add(simPortName, new SerialPort(simPortName));
            }

            if (onlySimulatedResources == false) // add hardware resources
            {
                // add hardware resources
                SerialPort port;

                foreach (string portName in portsInUse)
                {
                    port = new SerialPort(portName); // settings like baud rate will be set later, from the GUI
                    SerialCommunication.Resources.Add(portName, port);
                }
            }
        }
        #endregion

        #region formatting
        /// <summary>
        /// Formats the given byte array to be more readable.
        /// </summary>
        /// <param name="bytes">data to be formatted</param>
        /// <returns>a hex-string with the '0x' prefix and bytes separated by a space</returns>
        public static string FormatHextString(byte[] bytes)
        {
            string hexString = $"{Convert.ToHexString(bytes)}";
            string formattedHexString = "";

            // format data to be more readable
            for (int index = 0; index < hexString.Length; index += 2)
            {
                formattedHexString += $"{hexString[index]}{hexString[index + 1]} ";
            }

            return $"0x{formattedHexString}";
        }
        #endregion
    }
}
