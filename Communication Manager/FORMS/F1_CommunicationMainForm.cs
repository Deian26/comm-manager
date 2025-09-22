using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Dynamic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace Communication_Manager
{
    public partial class F1_CommunicationMainForm : Form
    {
        private const int UPDATE_TIMER_MS = 50; // ms
        private Point APP_ARGS_PANEL_LOCATION = new Point(3, 107);

        Thread rxDataListener = null;
        CancellationTokenSource listenForRxData = new CancellationTokenSource(); // signals the Rx data listener loop to continue listening

        private List<DataGridViewRow> TelegramQueue = new List<DataGridViewRow>(); // Rx and Tx events queued for displaying in the communication view control when the control is available

        public F1_CommunicationMainForm()
        {
            InitializeComponent();
            this.MaximumSize = this.MinimumSize = this.Size;

            // disable communication row editing
            this.F1_dataGridView_CommView.AllowUserToAddRows = false;
            this.F1_dataGridView_CommView.AllowUserToDeleteRows = false;
            this.F1_dataGridView_CommView.AllowUserToResizeRows = false;

            // start update timer
            this.F1_timer_PeriodicUpdate.Interval = UPDATE_TIMER_MS;
            this.F1_timer_PeriodicUpdate.Start();
        }

        #region utilitty
        /// <summary>
        /// Displays the communication protocols loaded from configuration files into the current form,
        /// as options for communication.
        /// </summary>
        private void displayProtocols()
        {
            this.F1_comboBox_Protocols.Items.Clear(); // clear current list

            // parse the loaded protocols and load them into the form
            foreach (string protocolName in SerialCommunication.Protocols.Keys)
            {
                if (this.F1_comboBox_Protocols.Items.Contains(protocolName) == false) // unique protocol name
                {
                    this.F1_comboBox_Protocols.Items.Add(protocolName);
                }
                else // log event
                {
                    Logging.Log($"Duplicate protocol: {protocolName} ! The subsequent prtoocols were discarded !", Logging.Level.WARN);
                }
            }

            // select the first item
            if (this.F1_comboBox_Protocols.Items.Count > 0)
                this.F1_comboBox_Protocols.SelectedIndex = 0;
        }

        /// <summary>
        /// Displays in the form the resources present in the system.
        /// </summary>
        private void displayResources()
        {
            this.F1_comboBox_Resources.Items.Clear(); // clear current combo-box list

            // add resources to combo-box list
            foreach (string resourceName in SerialCommunication.Resources.Keys)
            {
                if (this.F1_comboBox_Resources.Items.Contains(resourceName) == false) // unique resource
                {
                    this.F1_comboBox_Resources.Items.Add(resourceName); // resource names must be unique
                }
                else // log event
                {
                    Logging.Log($"Duplicate resource detected (hardware) or defined (virtual): {resourceName} ! The subsequent resources were discarded !", Logging.Level.WARN);
                }
            }

            // select the first item
            if (this.F1_comboBox_Resources.Items.Count > 0)
                this.F1_comboBox_Resources.SelectedIndex = 0;
        }
        #endregion


        private void F1_CommunicationMainForm_Load(object sender, EventArgs e)
        {
            // display the loaded communication protocols as options for communication
            this.displayProtocols();
            this.displayResources();
            if (this.F1_comboBox_BaudRate.Items.Count > 0) this.F1_comboBox_BaudRate.SelectedIndex = 0;

            // populate application controls
            this.F1_comboBox_RequestedAppName.Items.Clear();

            //=// RTT //=//
            this.F1_comboBox_RequestedAppName.Items.Add(RTT.APP_NAME);
            this.F1_comboBox_RequestedAppName.SelectedIndex = 0; // select the first app from the list

            // move, disable and hide application panels
            this.F1_panel_RTT_AddNode.Enabled = this.F1_panel_RTT_AddNode.Visible = false;
            this.F1_panel_RTT_AddNode.Location = this.APP_ARGS_PANEL_LOCATION;

            this.F1_panel_RTT_ChangePowerLevelPanel.Enabled = this.F1_panel_RTT_ChangePowerLevelPanel.Visible = false;
            this.F1_panel_RTT_ChangePowerLevelPanel.Location = this.APP_ARGS_PANEL_LOCATION;

            this.F1_panel_RTT_LockPanel.Enabled = this.F1_panel_RTT_LockPanel.Visible = false;
            this.F1_panel_RTT_LockPanel.Location = this.APP_ARGS_PANEL_LOCATION;

            this.F1_panel_RTT_SetModePanel.Enabled = this.F1_panel_RTT_SetModePanel.Visible = false;
            this.F1_panel_RTT_SetModePanel.Location = this.APP_ARGS_PANEL_LOCATION;


            // add commands
            this.F1_comboBox_RTT_RequestedCommand.Items.Clear();
            this.F1_comboBox_RTT_RequestedCommand.Items.AddRange(RTT.Commands.Keys.ToArray());
            this.F1_comboBox_RTT_RequestedCommand.SelectedIndex = 0; // select the first app from the list

            this.F1_comboBox_RTT_CommandChangePowerLevel_PowerLevel.Items.Clear();
            this.F1_comboBox_RTT_CommandChangePowerLevel_PowerLevel.Items.AddRange(RTT.POWER_LEVELS);

            this.F1_comboBox_RTT_CommandLock_RequestedLockState.Items.Clear();
            this.F1_comboBox_RTT_CommandLock_RequestedLockState.Items.AddRange(RTT.LOCK_STATE_REQUESTS.Keys.ToArray());

            this.F1_comboBox_RTT_CommandSetMode_Mode.Items.Clear();
            this.F1_comboBox_RTT_CommandSetMode_Mode.Items.AddRange(RTT.MODES.Keys.ToArray());

            // start listening thread
            rxDataListener = new Thread(new ThreadStart(RxDataListener));
            rxDataListener.Start();

        }

        /// <summary>
        /// Listens to the currently open resource and logs the data in the GUI as it is received.
        /// </summary>
        private void RxDataListener()
        {
            try
            {
                while (listenForRxData.IsCancellationRequested == false) // is stopped when the form is closed
                {
                    if (SerialCommunication.CrtPort != null && SerialCommunication.CrtPort.IsOpen == true) // resource is selected and open
                    {
                        if (SerialCommunication.CrtPort.BytesToRead != 0) // bytes can be read
                        {
                            // set timeout
                            // SerialCommunication.CrtPort.ReadTimeout = SerialCommunication.READ_TIMEOUT_MS;

                            Thread.Sleep(SerialCommunication.READ_TIMEOUT_MS); // wait for all bytes to be received (the timeout feature only allows the reading of the first byte)

                            // read bytes
                            byte[] rxBytes;
                            int bytesRead;

                            rxBytes = new byte[SerialCommunication.CrtPort.BytesToRead];
                            bytesRead = 0;

                            bytesRead = SerialCommunication.CrtPort.Read(rxBytes, 0, SerialCommunication.CrtPort.BytesToRead);
                            Array.Resize(ref rxBytes, bytesRead); // resize array based on the number of bytes actually  (if different than 'SerialCommunication.CrtPort.BytesToRead')

                            // log data in the GUI (call method on the object created in the other thread)
                            this.Invoke(new Action(() => this.storeTelegram(
                                    rxBytes,
                                    SerialCommunication.Direction.Receive,
                                    "?", // init; will be changed later
                                    this.F1_comboBox_Protocols.SelectedItem.ToString()
                                    )));

                            // clear buffer
                            SerialCommunication.CrtPort.DiscardInBuffer();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string errMsg = $"Port closed unexpectedly! Details: {ex.Message}";
                Logging.Log(errMsg, Logging.Level.ERROR);
                this.Invoke(new Action(() => this.F1_errorProvider_BackgroundProcessError.SetError(this.F1_comboBox_Resources, errMsg)));
            }
        }

        /// <summary>
        /// Send raw data over the selected port, with the specified details.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void F1_button_SendPacket_Click(object sender, EventArgs e)
        {
            // store starting timestamp
            if (Logging.START_SERIAL_COMM_TS_MS == DateTime.UnixEpoch) // if the starting timestamp was not yet set, set it to the current timestamp 
                Logging.START_SERIAL_COMM_TS_MS = DateTime.Now;

            // validate input (bytes)
            if (this.F1_textBox_RawDataToBeSent.Text != null && this.F1_textBox_RawDataToBeSent.Text.Length != 0) // valid hex-string
            {
                if (this.F1_comboBox_Resources.SelectedItem == null)
                {
                    Logging.Log($"Invalid resource selected!", Logging.Level.WARN);
                    return; // stop processing data for the request
                }

                try
                {
                    // close the previous serial communication port (if it exists and is open)
                    if (SerialCommunication.CrtPort != null)
                    {
                        if (SerialCommunication.CrtPort.IsOpen == true)
                            SerialCommunication.CrtPort.Close();
                    }


                    // send data
                    string errMsgs = "";

                    int errorCode = SerialCommunication.SendData(
                            this.F1_textBox_RawDataToBeSent.Text,
                            this.F1_comboBox_Resources.SelectedItem.ToString(),
                            Int32.Parse(this.F1_comboBox_BaudRate.SelectedItem.ToString()),
                            out errMsgs
                        );


                    if (errorCode == -1) // error port closed
                    {
                        errMsgs += " [ERROR: PORT CLOSED] ";
                        this.F1_errorProvider_BackgroundProcessError.SetError(this.F1_comboBox_Resources, "Port closed unexpectedly!");
                    }
                    else if (errorCode == -2) // error 
                    {
                        errMsgs += " [ERROR: SENDING DATA] ";
                    }
                    else if (errorCode == -3) // general error
                    {
                        errMsgs += " [ERROR GENERAL TRANSMISSION ERROR]";
                    }


                    if (errMsgs != "") // log error
                    {
                        Logging.Log(errMsgs, Logging.Level.ERROR);
                        this.F1_errorProvider_InputValidation.SetError(this.F1_button_SendPacket, $"ERROR Sending value! Details: {errMsgs}"); // display error
                    }

                    // log data in the GUI
                    this.storeTelegram(
                            Utility.GetBytesFromHexString(this.F1_textBox_RawDataToBeSent.Text),
                            SerialCommunication.Direction.Transmit,
                            "?", // init; will be changed later
                            this.F1_comboBox_Protocols.SelectedItem.ToString()
                            );

                    // log data to Logging.SERIAL_COMM_LOG, if logging is enabled
                    if (this.F1_checkBox_LogTransmission.Checked == true)
                    {
                        Logging.LogData(this.F1_textBox_RawDataToBeSent.Text, SerialCommunication.Direction.Transmit); // log data
                    }

                }
                catch (Exception ex) // error sending data
                {
                    // display error
                    Logging.Log($"Error sending raw data! Details: {ex.Message}", Logging.Level.ERROR);
                }

            }
            else // erroneous byte array provided => display error message
            {
                this.F1_errorProvider_InputValidation.SetError(this.F1_textBox_RawDataToBeSent, $"Invalid byte array provided: {this.F1_textBox_RawDataToBeSent.Text}");
            }

            Thread.Sleep(SerialCommunication.SEND_TELEGRAM_COOLDOWN_MS);
        }


        private void F1_button_SearchBytes_Click(object sender, EventArgs e)
        {
            // search the specified bytes in the raw data
            //TODO: Implement raw bytes search
        }


        private void F1_checkBox_OnlySimulatedResources_CheckedChanged(object sender, EventArgs e)
        {

            Utility.LoadResources(this.F1_checkBox_OnlySimulatedResources.Checked); // update resource list
            this.displayResources(); // update display list
        }

        private void F1_checkBox_LogTransmission_CheckedChanged(object sender, EventArgs e)
        {
            if (this.F1_checkBox_LogTransmission.Checked == true) // start serial communication log
            {
                Logging.SERIAL_COMM_LOG_START_TS = DateTime.Now; // store starting timestamp
                Logging.SERIAL_COMM_LOG = @$"{Directory.GetCurrentDirectory()}\..\..\..\ARTIFACTS\LOGS\serial--{Logging.SERIAL_COMM_LOG_START_TS.ToString().Replace("\\", "-").Replace("/", "-").Replace(":", "-")}.log"; // update log file path
                File.AppendAllText(Logging.SERIAL_COMM_LOG, $"Serial communication log started @ {DateTime.Now.ToString()}\n\n");
            }
        }

        private void F1_dataGridView_CommView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void F1_dataGridView_CommView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                string errMsg;
                TreeNode info = new TreeNode();
                TreeNode errors = new TreeNode();

                info.Tag = null;

                // interpret telegram
                try
                {
                    string telegramType = "?";
                    int negativeResp;

                    info = Utility.InterpretTelegram(
                            this.F1_comboBox_Protocols.SelectedItem.ToString(),
                            this.F1_dataGridView_CommView.Rows[e.RowIndex].Cells["Payload"].Value.ToString(),
                            (double)this.F1_dataGridView_CommView.Rows[e.RowIndex].Cells["TimestampMs"].Value,
                            out telegramType,
                            out negativeResp // 1 if the telegram is a negative response, 0 if it is a positive response; only useful for applications that implement negative responses (in those cases, the value is '2')
                        );

                    // change background colour in the grid view
                    if(negativeResp == 1) // negative response
                    {
                        this.F1_dataGridView_CommView.Rows[e.RowIndex].Cells["Type"].Style.BackColor = Color.Salmon;
                    }
                    else if(negativeResp == 0) // positive response
                    {
                        this.F1_dataGridView_CommView.Rows[e.RowIndex].Cells["Type"].Style.BackColor = Color.LimeGreen;
                    }// otherwise do not change the background colour

                    // set telegram type
                    this.F1_dataGridView_CommView.Rows[e.RowIndex].Cells["Type"].Value = telegramType;
                }
                catch (Exception ex)
                {
                    // exception will be thrown later
                    errors.Nodes.Add("ERROR", "Could not interpret telegram!"); // store error
                }


                if (info.Tag != null && info.Tag != "") // errors encountered while interpreting the telegram
                {
                    // delete expected protocol (if set)
                    this.F1_dataGridView_CommView.Rows[e.RowIndex].Cells["Protocol"].Value = "?";

                    // store error
                    this.F1_dataGridView_CommView.Rows[e.RowIndex].Tag = info;
                }

                // store interpretation, if interpretation was possible
                this.F1_dataGridView_CommView.Rows[e.RowIndex].Tag = info;

                // move view to the latest event
                this.F1_dataGridView_CommView.FirstDisplayedScrollingRowIndex = e.RowIndex;
                //this.F1_dataGridView_CommView.Rows[e.RowIndex].Selected = true;
                //this.F1_dataGridView_CommView.Rows[e.RowIndex].Selected = false;
            }
        }

        private void F1_dataGridView_CommView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                // display interpretation info, if any exists
                TreeNode info = (TreeNode)this.F1_dataGridView_CommView.Rows[e.RowIndex].Tag;
                this.F1_treeView_ProcessedData.Nodes.Clear(); // delete nodes

                if (info != null) // either the interpretation was possible or this node contains an error message (key "ERR")
                {
                    if (info.Tag != null) // error message
                    {
                        this.F1_dataGridView_CommView.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Salmon;
                        this.F1_treeView_ProcessedData.Nodes.Add((TreeNode)info.Tag);
                        this.F1_treeView_ProcessedData.Nodes[0].BackColor = Color.Salmon;
                    }
                    else // valid interpretation
                    {
                        this.F1_treeView_ProcessedData.Nodes.Add(info); // display info in the dedicated form control
                    }
                }
                else // no info => display a generic message
                {
                    this.F1_treeView_ProcessedData.Nodes.Add("ERROR", "Could not interpret the telegram!");
                    this.F1_treeView_ProcessedData.Nodes["ERROR"].BackColor = Color.Salmon;
                }
            }
        }

        private void F1_CommunicationMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // stop listening thread
            listenForRxData.Cancel();
            rxDataListener.Join();
        }

        /// <summary>
        /// Stores telegram data to be logged into view when the control is available (e.g., no other Tx/Rx events are being written from a different thread)
        /// </summary>
        /// <param name="dataBytes">data (bytes) to be logged (hex-string)</param>
        /// <param name="direction">direction, with respect to the application (Tx by the app / Rx by the app )</param>
        /// <param name="telegramType">telegram type (app specific)</param>
        /// <param name="protocol">the name of the protocol that the telegram to be logged is a part of</param>
        private void storeTelegram(byte[] dataBytes, SerialCommunication.Direction direction, string telegramType, string protocol)
        {
            DataGridViewRow row = new DataGridViewRow();

            // timestamp | direction | type | payload | message type
            row.CreateCells(
                this.F1_dataGridView_CommView,

                // store values
                DateTime.Now.Subtract(Logging.START_SERIAL_COMM_TS_MS).TotalMilliseconds, //ms
                SerialCommunication.DirectionStr[(int)direction],
                telegramType,
                Utility.getHexString(dataBytes, true).ToUpper(),
                protocol
                );

            // change style depending on direction
            if (direction == SerialCommunication.Direction.Receive)
            {
                row.DefaultCellStyle.BackColor = Color.Silver;
            }

            this.TelegramQueue.Add(row); // store row
        }

        private void F1_timer_PeriodicUpdate_Tick(object sender, EventArgs e)
        {
            // stop updating the UI
            this.F1_dataGridView_CommView.SuspendLayout();

            // update the communication DataGridView control with the items currently stored in the queues
            foreach (DataGridViewRow row in this.TelegramQueue)
            {
                this.F1_dataGridView_CommView.Rows.Add(row);
            }
            // clear queue
            this.TelegramQueue.Clear();

            // resume UI updates
            this.F1_dataGridView_CommView.ResumeLayout();

            // update UI now
            this.F1_dataGridView_CommView.PerformLayout();
        }

        // Send the configured command for RTT
        private void F1_button_RTT_SendCommand_Click(object sender, EventArgs e)
        {
            // get raw data based on the selected command
            byte cmdID = 0x00;
            List<byte> command = new List<byte>(); // full command (will be populated later)

            if (RTT.Commands.TryGetValue(this.F1_comboBox_RTT_RequestedCommand.SelectedItem.ToString(), out cmdID) == false) // get command ID
            {
                // unknown command
                string errMsg = $"Unrecognized command: {this.F1_comboBox_RTT_RequestedCommand.SelectedItem.ToString()}";
                Logging.Log(errMsg, Logging.Level.ERROR);
                this.F1_errorProvider_BackgroundProcessError.SetError(this.F1_button_RTT_SendCommand, errMsg);

                return;
            }

            command.Add((byte)(0x61 | ((this.F1_checkBox_RTT_PriorityCmd.Checked ? 1 : 0) << 6))); // App ID = 0x21, Cmd flag = 1, the priority is set based on the input from the Application panel    
            command.Add(0x00); // placeholder data length for BDTP
            command.Add(cmdID); // add command ID

            // gather command bytes (for commands that require them) and do nothing for commands without arguments
            switch (cmdID)
            {
                case RTT.CMD_PING: break;
                case RTT.CMD_ADD_NODE:
                    {
                        // get IP Address from the panel
                        string[] ipAddress = this.textBox_RTT_CommandAddNode_IpAddress.Text.Split(".");

                        if (ipAddress.Length != 4)
                        {
                            string errMsg = $"Invalid IP Address! Expected a 4 bytes mask, received {this.textBox_RTT_CommandAddNode_IpAddress.Text}";
                            Logging.Log(errMsg, Logging.Level.WARN);
                            this.F1_errorProvider_BackgroundProcessError.SetError(this.textBox_RTT_CommandAddNode_IpAddress, errMsg);

                            return;
                        }
                        // get bytes
                        foreach (string ipAddressDecField in ipAddress)
                        {
                            try
                            {
                                command.Add((byte)Convert.ToInt16(ipAddressDecField)); // add IP address byte to command

                            }
                            catch (Exception ex)
                            {
                                string errMsg = $"Invalid IP Address: {this.textBox_RTT_CommandAddNode_IpAddress.Text}. Details: {ex.Message}";
                                Logging.Log(errMsg, Logging.Level.WARN);
                                this.F1_errorProvider_BackgroundProcessError.SetError(this.textBox_RTT_CommandAddNode_IpAddress, errMsg);

                                return;
                            }
                        }

                        break;
                    }
                    ;
                case RTT.CMD_RESET: break;
                case RTT.CMD_TX_DATA: break;
                case RTT.CMD_CHANGE_POWER_LEVEL:
                    {
                        // get power level
                        command.Add((byte)Convert.ToInt16(this.F1_comboBox_RTT_CommandChangePowerLevel_PowerLevel.SelectedItem.ToString(), 16));

                        break;
                    }
                case RTT.CMD_SET_MODE:
                    {
                        byte mode;

                        // get requested mode
                        if (RTT.MODES.TryGetValue(this.F1_comboBox_RTT_CommandSetMode_Mode.SelectedItem.ToString(), out mode) == false) // error
                        {
                            string errMsg = $"Unrecognized mode: {this.F1_comboBox_RTT_CommandSetMode_Mode.SelectedItem.ToString()}";
                            Logging.Log(errMsg, Logging.Level.WARN);
                            this.F1_errorProvider_BackgroundProcessError.SetError(this.textBox_RTT_CommandAddNode_IpAddress, errMsg);

                            return;
                        }

                        command.Add(mode);

                        break;
                    }
                case RTT.CMD_GET_INFO: break;
                case RTT.CMD_SHUTDOWN: break;
                case RTT.CMD_LOCK:
                    {
                        // get lock state request and key (1 + 4 bytes)
                        try
                        {
                            byte reqLockState;
                            string errMsg = null;

                            // get requested lock state
                            if (RTT.LOCK_STATE_REQUESTS.TryGetValue(this.F1_comboBox_RTT_CommandLock_RequestedLockState.SelectedItem.ToString(), out reqLockState) == false) // error
                            {
                                errMsg = $"Unrecognized lock state requested: {this.F1_comboBox_RTT_CommandSetMode_Mode.SelectedItem.ToString()}";
                                Logging.Log(errMsg, Logging.Level.WARN);
                                this.F1_errorProvider_BackgroundProcessError.SetError(this.textBox_RTT_CommandAddNode_IpAddress, errMsg);

                                return;
                            }

                            command.Add(reqLockState);

                            // get lock key
                            errMsg = null;
                            byte[] lockKey = Utility.getBytesFromHexString(this.F1_textBox_RTT_CommandLock_LockKey.Text, out errMsg);

                            if (errMsg != "" && errMsg != "")
                            {
                                Logging.Log(errMsg, Logging.Level.WARN);
                                this.F1_errorProvider_BackgroundProcessError.SetError(this.textBox_RTT_CommandAddNode_IpAddress, errMsg);

                                return;
                            }

                            command.AddRange(lockKey);
                        }
                        catch (Exception ex)
                        {
                            string errMsg = $"Invalid Lock requested state ({this.F1_comboBox_RTT_CommandLock_RequestedLockState.SelectedItem.ToString()}) or key ({this.F1_comboBox_RTT_CommandChangePowerLevel_PowerLevel.Text}). Details: {ex.Message}";
                            Logging.Log(errMsg, Logging.Level.WARN);
                            this.F1_errorProvider_BackgroundProcessError.SetError(this.textBox_RTT_CommandAddNode_IpAddress, errMsg);

                            return;
                        }

                        break;
                    }


                default: // unrecognized command
                    {
                        string errMsg = $"Unsupported command: {this.F1_comboBox_RTT_RequestedCommand.SelectedItem.ToString()}";
                        Logging.Log(errMsg, Logging.Level.ERROR);
                        this.F1_errorProvider_BackgroundProcessError.SetError(this.F1_button_RTT_SendCommand, errMsg);

                        break;
                    }
            }

            // change command length
            command[1] = (byte)(command.Count - 2);

            // send command
            string commandHexStr = Utility.getHexString(command.ToArray(), true);

            this.F1_textBox_RawDataToBeSent.Text = commandHexStr;
            this.F1_button_SendPacket.PerformClick();
        }

        private void F1_comboBox_RequestedAppName_SelectedIndexChanged(object sender, EventArgs e)
        {
            // hide all other application panels
            // to be implemented when more apps are implemented

            // display Application panel
            switch (this.F1_comboBox_RequestedAppName.SelectedItem.ToString())
            {
                case RTT.APP_NAME:
                    {
                        this.F1_panel_RTT_ApplicationPanelOptions.Enabled = true;
                        this.F1_panel_RTT_ApplicationPanelOptions.Visible = true;
                        break;
                    }

                default: // unrecognized / unsupported app
                    {
                        break;
                    }
            }
        }

        private void F1_comboBox_RTT_RequestedCommand_SelectedIndexChanged(object sender, EventArgs e)
        {
            // hide all other application option panels
            // to be implemented when more apps are implemented

            switch (this.F1_comboBox_RequestedAppName.SelectedItem.ToString())
            {
                case RTT.APP_NAME:
                    {
                        // hide all panels
                        this.F1_panel_RTT_AddNode.Enabled = this.F1_panel_RTT_AddNode.Visible = false;
                        this.F1_panel_RTT_ChangePowerLevelPanel.Enabled = this.F1_panel_RTT_ChangePowerLevelPanel.Visible = false;
                        this.F1_panel_RTT_LockPanel.Enabled = this.F1_panel_RTT_LockPanel.Visible = false;
                        this.F1_panel_RTT_SetModePanel.Enabled = this.F1_panel_RTT_SetModePanel.Visible = false;

                        // display command options panel for commands that require arguments
                        switch (this.F1_comboBox_RTT_RequestedCommand.SelectedItem.ToString())
                        {
                            case RTT.CMD_ADD_NODE_NAME:
                                {
                                    this.F1_panel_RTT_AddNode.Enabled = true;
                                    this.F1_panel_RTT_AddNode.Visible = true;
                                    break;
                                }
                            case RTT.CMD_SET_MODE_NAME:
                                {
                                    this.F1_panel_RTT_SetModePanel.Enabled = true;
                                    this.F1_panel_RTT_SetModePanel.Visible = true;
                                    break;
                                }
                            case RTT.CMD_CHANGE_POWER_LEVEL_NAME:
                                {
                                    this.F1_panel_RTT_ChangePowerLevelPanel.Enabled = true;
                                    this.F1_panel_RTT_ChangePowerLevelPanel.Visible = true;
                                    break;
                                }
                            case RTT.CMD_LOCK_NAME:
                                {
                                    this.F1_panel_RTT_LockPanel.Enabled = true;
                                    this.F1_panel_RTT_LockPanel.Visible = true;
                                    break;
                                }
                            default: // unrecognized / unsupported app
                                {
                                    break;
                                }
                        }
                        break;
                    }

                default: // app unrecognized / unsupported for displaying command panel
                    {
                        break;
                    }
            }
        }

        // Reset port connection and flush buffers
        private void F1_button_ResetConnectionToResource_Click(object sender, EventArgs e)
        {
            try
            {
                // reset connection (for real ports, this closes and then re-opens the connection)
                if (SerialCommunication.CrtPort == null)
                {
                    // select the port again
                    SerialCommunication.CrtPort = SerialCommunication.Resources[this.F1_comboBox_Resources.SelectedItem.ToString()];
                }

                // flush buffers
                SerialCommunication.CrtPort.DiscardInBuffer();
                SerialCommunication.CrtPort.DiscardOutBuffer();

                // close then re-open port
                SerialCommunication.CrtPort.Close();
                SerialCommunication.CrtPort.Dispose();

                // re-init port
                SerialCommunication.Resources[this.F1_comboBox_Resources.SelectedItem.ToString()] = new SerialPort(
                    this.F1_comboBox_Resources.SelectedItem.ToString(),
                    Convert.ToInt32(this.F1_comboBox_BaudRate.SelectedItem.ToString()),
                    Parity.None
                    );

                SerialCommunication.CrtPort = SerialCommunication.Resources[this.F1_comboBox_Resources.SelectedItem.ToString()];

                SerialCommunication.CrtPort.ReadBufferSize = SerialCommunication.MAX_READ_BUFFER_SIZE_BYTES;
                SerialCommunication.CrtPort.WriteBufferSize = SerialCommunication.MAX_WRITE_BUFFER_SIZE;
                SerialCommunication.CrtPort.WriteTimeout = SerialCommunication.READ_WRITE_TIMEOUT_MS;
                SerialCommunication.CrtPort.ReadTimeout = SerialCommunication.READ_WRITE_TIMEOUT_MS;

                SerialCommunication.CrtPort.RtsEnable = false;
                SerialCommunication.CrtPort.DtrEnable = false;
                SerialCommunication.CrtPort.Open();
                Thread.Sleep(100);
                SerialCommunication.CrtPort.Handshake = Handshake.None; // expect no handshake protocol
                SerialCommunication.CrtPort.RtsEnable = true;
                SerialCommunication.CrtPort.DtrEnable = true; // do not wait for receive confirmation


                if (SerialCommunication.CrtPort.IsOpen == true)
                {
                    this.F1_errorProvider_BackgroundProcessError.Clear();
                }    

            }catch (Exception ex)
            {
                string errMsg = $"ERROR Resetting resource {SerialCommunication.CrtPort.PortName}! Details: {ex.Message}";
                Logging.Log(errMsg, Logging.Level.ERROR);
                this.F1_errorProvider_BackgroundProcessError.SetError(this.F1_button_ResetConnectionToResource, errMsg);
            }
        }
    }
}
