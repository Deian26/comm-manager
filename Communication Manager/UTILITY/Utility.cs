using System.IO;
using System.IO.Ports;
using System.Xml;

namespace Communication_Manager
{
    /// <summary>
    /// Implements configuration and auxiliary methods.
    /// </summary>
    static class Utility
    {
        #region configuration
        public const int LOADING_FORM_APP_START_DELAY_MS = 2000; // ms to wait after initializing the application, before form F0 is hidden and form F1 is opened
        public static string CONFIG_FOLDER_PATH = @$"{Directory.GetCurrentDirectory()}\..\..\..\UTILITY\RESOURCES\COMM_DEF\";
        public const string HEX_DIGTIS = "0123456789ABCDEF";

        /// <summary>
        /// Load protocol definition files from the specified folder.
        /// </summary>
        /// <param name="configFolderPath">configuration files folder</param>
        /// <param name="eventLog">ListBox where the names of the files being loaded should be displayed in real-time</param>
        public static void LoadProtocolDefinitions(string configFolderPath, ListBox eventLog)
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
                    string description = null, interfaceType = null, resourceType = null;
                    Frame frame = null;

                    if (defFile.DocumentElement.Attributes["name"] == null)
                    {
                        Logging.Log($"The definition file '{filePath}' does not contain a protocol name!", Logging.Level.ERROR);
                    }

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
                                    frame = new Frame();
                                    frame.breakTimeNs = Double.Parse(node.Attributes["break-time-ns"].Value);

                                    foreach(XmlNode field in node.ChildNodes)
                                    {
                                        if(field.Name.Equals("field") == true)
                                        {
                                            if (field.Attributes["name"] == null)
                                            {
                                                Logging.Log($"Invalid field definition! The definition of a field (general frame definition) is missing the mandatory 'name' attribute!", Logging.Level.ERROR);
                                                continue; // skip node
                                            }
                                            if (field.Attributes["bit-size"] == null)
                                            {
                                                Logging.Log($"Invalid field definition! The definition of field '{field.Attributes["name"].Value}' is missing the mandatory 'bit-size' attribute!", Logging.Level.ERROR);
                                                continue; // skip node
                                            }


                                            frame.Fields.Add(
                                                field.Attributes["name"].Value, // key
                                                new Frame.Field( // value
                                                    field.Attributes["name"].Value, // field name
                                                    Int32.Parse(field.Attributes["bit-size"].Value), // bit size (since eof = false)
                                                    false // eof = false
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
                                        frame = new Frame();
                                        frame.eof = true;

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
                                                        if (field.Attributes["value"] == null)
                                                        {
                                                            Logging.Log($"Invalid field definition! The definition of field '{field.Attributes["name"].Value}' (EoF frame) is missing the mandatory 'value' attribute!", Logging.Level.ERROR);
                                                            continue; // skip node
                                                        }


                                                        frame.Fields.Add(
                                                        field.Attributes["name"].Value, // key
                                                        new Frame.Field( // value
                                                            field.Attributes["name"].Value, // field name
                                                            Int32.Parse(field.Attributes["value"].Value), // EoF frame field value (since eof = true)
                                                            true // eof = true
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

                                                    frame.eofTimeoutNs = Double.Parse(eofFrameSubnode.Attributes["timeout-ns"].Value);
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
                            interfaceType, // e.g., Serial
                            resourceType // e.g., COM
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
                string[] portNames = SerialPort.GetPortNames();
                SerialPort port;

                foreach (string portName in portNames)
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
