using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Contacts.DataProvider;



namespace Communication_Manager
{
    /// <summary>
    /// Implements the Real Time Temperature (Pico 2W) app
    /// </summary>
    public static class RTT
    {
        public const string APP_NAME = "RTT";
        public const int SIMPLE_RESP_LEN = 3; // the length of the data of a simple response (i.e., a response that only contains the type, data length (BDTP) followed by status, command ID and response code)
        
        #region command-args
        public static string[] POWER_LEVELS = { "00", "01", "02" };
        public static Dictionary<string, byte> MODES = new Dictionary<string, byte>
        {
            {"Idle", 0x00 },
            {"Active", 0x01 }
        };
        public static Dictionary<string, byte> LOCK_STATE_REQUESTS = new Dictionary<string, byte>
        {
            {"Unlock", 0x00 },
            {"Lock", 0x01 }
        };

        #endregion

        #region commands
        public const byte CMD_PING = 0x50; public const string CMD_PING_NAME = "Ping";
        public const byte CMD_ADD_NODE = 0x41; public const string CMD_ADD_NODE_NAME = "Add node";
        public const byte CMD_RESET = 0x52; public const string CMD_RESET_NAME = "Reset";
        public const byte CMD_TX_DATA = 0x54; public const string CMD_TX_DATA_NAME = "Transmit data";
        public const byte CMD_SET_MODE = 0x4D; public const string CMD_SET_MODE_NAME = "Set mode";
        public const byte CMD_CHANGE_POWER_LEVEL = 0x4C; public const string CMD_CHANGE_POWER_LEVEL_NAME = "Change power level";
        public const byte CMD_GET_INFO = 0x49; public const string CMD_GET_INFO_NAME = "Get info";
        public const byte CMD_SHUTDOWN = 0x53; public const string CMD_SHUTDOWN_NAME = "Shutdown";
        public const byte CMD_LOCK = 0x4B; public const string CMD_LOCK_NAME = "Lock";
        #endregion

        #region response-codes
        // positive
        public const byte R_PROCESSED = 0x00;
        public const byte R_PERIODIC_TEMP_TX = 0x01;

        // negative
        public const byte R_UNRECOGNIZED_CMD = 0x81;
        public const byte R_INVALID_LEN = 0x82;
        public const byte R_ACTION_NOT_IMPLEMENTED = 0x83;
        public const byte R_INVALID_ARGS = 0x84;
        public const byte R_REQ_REFUSED = 0x85;
        public const byte R_UNSPECIFIED_ERROR = 0x8F;
        #endregion

        public const string TELEGRAM_TYPE_CMD = "CMD";
        public const string TELEGRAM_TYPE_RESP = "RESP";

        public static Dictionary<string, byte> Commands = new Dictionary<string, byte>
        {
                { RTT.CMD_PING_NAME, RTT.CMD_PING },
                { RTT.CMD_ADD_NODE_NAME, RTT.CMD_ADD_NODE },
                { RTT.CMD_RESET_NAME, RTT.CMD_RESET },
                { RTT.CMD_TX_DATA_NAME, RTT.CMD_TX_DATA },
                { RTT.CMD_SET_MODE_NAME, RTT.CMD_SET_MODE},
                { RTT.CMD_CHANGE_POWER_LEVEL_NAME, RTT.CMD_CHANGE_POWER_LEVEL},
                { RTT.CMD_GET_INFO_NAME, RTT.CMD_GET_INFO},
                { RTT.CMD_SHUTDOWN_NAME, RTT.CMD_SHUTDOWN},
                { RTT.CMD_LOCK_NAME, RTT.CMD_LOCK}
        };

        /// <summary>
        /// Interprets the given telegram (full), either it being a command or a response
        /// </summary>
        /// <param name="data">full telegram</param>
        /// <param name="telegramType">telegram type (RTT.TELEGRAM_TYPE_CMD or RTT.TELEGRAM_TYPE_RESP)</param>
        /// <param name="negativeResp">true if the telegram is a negative response</param>
        /// <returns>telegram interpretation</returns>
        public static TreeNode InterpretTelegram(byte[] data, out string telegramType, out bool negativeResp)
        {
            TreeNode info = new TreeNode();
            telegramType = "?";
            negativeResp = false;

            // check length
            if (data.Length < 1)
            {
                info.Tag += "No bytes to interpret!";
                return info;
            }

            // determine if this telegram is a command or a response
            if ((data[0] & 0b01000000) != 0) // command
            {
                telegramType = RTT.TELEGRAM_TYPE_CMD;
                info = RTT.InterpretCmdTelegramPayload(data.Skip(2).ToArray()); // skip the first 2 bytes (the 'Type' and 'Status' fields)
            }else // response
            {
                telegramType = RTT.TELEGRAM_TYPE_RESP;
                info = RTT.InterpretRespTelegramPayload(data.Skip(2).ToArray(), out negativeResp);
            }

            info.Text = "Interpretation";
            return info;
        }

        /// <summary>
        /// Interprets the given RTT command telegram payload and returns data about it as a TreeNode
        /// </summary>
        /// <param name="data">payload telegram bytes (without TP encapsulation) to be interpreted</param>
        /// <returns>data extracted from the telegram payload that was provided</returns>
        public static TreeNode InterpretCmdTelegramPayload(byte[] data)
        {
            TreeNode info = new TreeNode();

            if(data.Length == 0)
            {
                info.Tag += "No bytes to interpret!";
                return info;
            }

            // get Command ID
            byte cmdID = data[0];
            string hexCmdId = Utility.getHexString(cmdID, true); // get command ID as a hex-string

            switch (cmdID)
            {
                case RTT.CMD_PING:
                    {
                        info.Nodes.Add("Command", $"Command: Ping (0x{hexCmdId})");
                        break;
                    }

                case RTT.CMD_ADD_NODE:
                    {
                        info.Nodes.Add("Command", $"Command: Add Node (0x{hexCmdId})");

                        if (data.Length != 5) // invalid length
                        {
                            info.Tag += $"Invalid command length: {data.Length} bytes (expected 5 bytes)";
                        }
                        else // valid length
                        {
                            info.Nodes.Add("Command", $"IP Address: 0x{data[1]}.{data[2]}.{data[3]}.{data[4]}");
                        }

                        break;
                    }

                case RTT.CMD_RESET:
                    {
                        info.Nodes.Add("Command", $"Command: Reset (0x{hexCmdId})");
                        break;
                    }

                case RTT.CMD_TX_DATA:
                    {
                        info.Nodes.Add("Command", $"Command: Transmit Data (0x{hexCmdId})");
                        break;
                    }

                case RTT.CMD_SET_MODE:
                    {
                        info.Nodes.Add("Command", $"Command: Set Mode (0x{hexCmdId})");

                        if (data.Length != 2) // invalid length
                        {
                            info.Tag += $"Invalid command length: {data.Length} bytes (expected 2 bytes)";
                        }
                        else // valid length
                        {
                            string[] modes = { "Idle", "Active" };
                            info.Nodes.Add("Command", $"Mode: {modes[data[1]]} (0x{data[1]})");
                        }

                        break;
                    }

                case RTT.CMD_CHANGE_POWER_LEVEL:
                    {
                        info.Nodes.Add("Command", $"Command: Change Power Level (0x{hexCmdId})");

                        if (data.Length != 2) // invalid length
                        {
                            info.Tag += $"Invalid command length: {data.Length} bytes (expected 2 bytes)";
                        }
                        else // valid length
                        {
                            info.Nodes.Add("Command", $"Power Level: 0x{data[1]}");
                        }

                        break;
                    }

                case RTT.CMD_GET_INFO:
                    {
                        info.Nodes.Add("Command", $"Command: Get Info (0x{hexCmdId})");
                        break;
                    }

                case RTT.CMD_SHUTDOWN:
                    {
                        info.Nodes.Add("Command", $"Command: Shutdown (0x{hexCmdId})");
                        break;
                    }

                case RTT.CMD_LOCK:
                    {
                        info.Nodes.Add("Command", $"Command: Lock (0x{hexCmdId})");

                        if (data.Length != 5) // invalid length
                        {
                            info.Tag += $"Invalid command length: {data.Length} bytes (expected 5 bytes)";
                        }
                        else // valid length
                        {
                            string[] lockReqNames = { "Unlock", "Lock" };
                            info.Nodes.Add("Command", $"Request: {lockReqNames[data[1]]} (0x{data[1]})");
                            info.Nodes.Add("Command", $"Key: 0x{data[1]} {data[2]} {data[3]} {data[4]}");
                        }

                        break;
                    }


                default: // unrecognized command
                    {
                        info.Tag += $"Unknown command: 0x{hexCmdId}";
                        break;
                    }
            }

            return info;
        }

        /// <summary>
        /// Returns the message associated with the given code.
        /// </summary>
        /// <param name="code">response code</param>
        /// <param name="negativeResponse">true if the response is negative</param>
        /// <returns>response message</returns>
        private static string getResponseCodeText(byte code, out bool negativeResponse)
        {
            string responseCodeMsg;
            Dictionary<byte, string> responseCodes = new Dictionary<byte, string>();
            negativeResponse = false;

            if (responseCodes.Count == 0) // first time the function is called
            {
                // add code messages
                responseCodes.Add(RTT.R_PROCESSED, "Processed");
                responseCodes.Add(RTT.R_PERIODIC_TEMP_TX, "Periodic temperature transmission");

                responseCodes.Add(RTT.R_UNRECOGNIZED_CMD, "Unrecognized command");
                responseCodes.Add(RTT.R_INVALID_LEN, "Invalid length");
                responseCodes.Add(RTT.R_ACTION_NOT_IMPLEMENTED, "Action not implemented");
                responseCodes.Add(RTT.R_INVALID_ARGS, "Invalid arguments");
                responseCodes.Add(RTT.R_REQ_REFUSED, "Request refused");
                responseCodes.Add(RTT.R_UNSPECIFIED_ERROR, "Unspecified processing error");
            }

            negativeResponse = (code & 0b10000000) != 0;
            if(responseCodes.TryGetValue(code, out responseCodeMsg) == false) // try to extract code message
            {
                responseCodeMsg = $"ERROR: Invalid code: {code}";
            }

            return responseCodeMsg; // return code
        }

        /// <summary>
        /// Get the interpretation of the status byte
        /// </summary>
        /// <param name="status">status byte</param>
        /// <returns>interpreted status, where each sub-node represents a field in the status byte</returns>
        private static TreeNode getStatusInterpretation(byte status)
        {
            TreeNode info = new TreeNode("Status");
            string[] boolInt2Str = { "false", "true" }; // 0 = false, 1 = true

            // get the status fields
            info.Nodes.Add("Processing error flag", $"Processing error detected: {boolInt2Str[(status >> 7) & 0x01]}");
            info.Nodes.Add("Locked flag", $"Locked: {boolInt2Str[(status >> 6) & 0x01]}");
            info.Nodes.Add("Current power level", $"Current power level: {(status >> 4) & 0x03}");
            info.Nodes.Add("Requested reset flag", $"Reset requested: {(status >> 3) & 0x01}");
            info.Nodes.Add("Power reset flag", $"Power reset detected: {(status >> 2) & 0x01}");
            info.Nodes.Add("Active flag", $"Active: {(status >> 1) & 0x01}");
            info.Nodes.Add("Data tx error flag", $"Data transmission error detected: {status & 0x01}");

            return info;
        }

        /// <summary>
        /// Interprets the given RTT response telegram payload and returns data about it as a TreeNode
        /// </summary>
        /// <param name="data">payload telegram bytes (without TP encapsulation) to be interpreted</param>
        /// <param name="negativeResp">true if the response is negative</param>
        /// <returns>data extracted from the telegram payload that was provided</returns>
        public static TreeNode InterpretRespTelegramPayload(byte[] data, out bool negativeResp)
        {
            TreeNode info = new TreeNode();
            negativeResp = false;

            if (data.Length < RTT.SIMPLE_RESP_LEN) // invalid length
            {
                info.Nodes.Add("ERROR", $"Invalid response length: {data.Length}; expected at least 2 bytes!");
                return info;
            }

            // get status
            info.Nodes.Add(RTT.getStatusInterpretation(data[0]));

            // get Command ID
            byte cmdID = data[1]; // the command for which the response was sent


            // display code
            info.Nodes.Add("Response", $"Response code: {RTT.getResponseCodeText(data[2], out negativeResp)} (0x{Utility.getHexString(data[2], true)})");

            // set response code interpretation background colour
            if(negativeResp == true)
            {
                info.Nodes["Response"].BackColor = Color.Salmon;
            }
            else
            {
                info.Nodes["Response"].BackColor = Color.LimeGreen;
            }

            switch (cmdID)
            {
                case RTT.CMD_PING:
                    {
                        info.Nodes.Add("Response", $"Response for: Ping (0x{Utility.getHexString(RTT.CMD_PING, true)})");
                        break;
                    }

                case RTT.CMD_ADD_NODE:
                    {
                        info.Nodes.Add("Response", $"Response for: Add Node (0x{Utility.getHexString(RTT.CMD_ADD_NODE, true)})");
                        break;
                    }

                case RTT.CMD_RESET:
                    {
                        info.Nodes.Add("Response", $"Response for: Reset (0x{Utility.getHexString(RTT.CMD_RESET, true)})");
                        break;
                    }

                case RTT.CMD_TX_DATA:
                    {
                        info.Nodes.Add("Response", $"Response for: Transmit Data (0x{Utility.getHexString(RTT.CMD_TX_DATA, true)})");
                        break;
                    }

                case RTT.CMD_SET_MODE:
                    {
                        info.Nodes.Add("Response", $"Response for: Set Mode (0x{Utility.getHexString(RTT.CMD_SET_MODE, true)})");
                        break;
                    }

                case RTT.CMD_CHANGE_POWER_LEVEL:
                    {
                        info.Nodes.Add("Response", $"Response for: Change Power Level (0x{Utility.getHexString(RTT.CMD_CHANGE_POWER_LEVEL, true)})");
                        break;
                    }

                case RTT.CMD_GET_INFO:
                    {

                        string[] asciiInfo = System.Text.Encoding.ASCII.GetString(data.Skip(3).ToArray()).Split(";");

                        info.Nodes.Add("Response", $"Response for: Get Info (0x{Utility.getHexString(RTT.CMD_GET_INFO, true)})");
                        info.Nodes.Add("Response ASCII version", $"[ASCII] Version: {asciiInfo[0].Trim()}");
                        info.Nodes.Add("Response ASCII UTC Build time", $"[ASCII] UTC Build time: {asciiInfo[1].Trim()}");
                        break;
                    }

                case RTT.CMD_SHUTDOWN:
                    {
                        info.Nodes.Add("Response", $"Response for: Shutdown (0x{Utility.getHexString(RTT.CMD_SHUTDOWN, true)})");
                        break;
                    }

                case RTT.CMD_LOCK:
                    {
                        info.Nodes.Add("Response", $"Response for: Lock (0x{Utility.getHexString(RTT.CMD_LOCK, true)})");
                        break;
                    }


                default: // unrecognized command
                    {
                        if (data[2] == RTT.R_PERIODIC_TEMP_TX) // periodic temperature update
                        {
                            float tempCelsius;
                            byte[] tempBytes = new byte[4];

                            // get the temperature as bytes and store it in little-endian (reversed) byte order (expected by BitConverter)
                            for (int i = 3; i < 7; i++)
                            {
                                tempBytes[6 - i] = data[i];
                            }

                            // decode temperature
                            tempCelsius = BitConverter.ToSingle(tempBytes,0);// the value is converted from float before being sent (on the board)

                            info.Nodes.Add("Response", $"Periodic temperature transmission response (response code 0x{Utility.getHexString(cmdID, true)})");
                            info.Nodes.Add("Response", $"Temperature: {tempCelsius} °C");
                        }
                        else // unknown command
                        {
                            info.Nodes.Add("ERROR", $"Unknown command for which the response was sent: 0x{Utility.getHexString(cmdID, true)}");
                        }

                        break;
                    }
            }

            return info;
        }

    }
}
