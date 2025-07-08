using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Communication_Manager
{
    public partial class F1_CommunicationMainForm : Form
    {
        public F1_CommunicationMainForm()
        {
            InitializeComponent();
            this.MaximumSize = this.MinimumSize = this.Size;
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

        /// <summary>
        /// Checks if the given string is a valid hexadecimal string, converts it to a byte array and returns it.
        /// If the input string is not a valid hex-string, the returned value will be an empty byte array.
        /// </summary>
        /// <param name="input">string to be checked</param>
        /// <returns>byte array representing the input hex-string</returns>
        private byte[] getBytesFromHexString(string input)
        {
            byte[] rawBytes = [];

            try
            {
                rawBytes = Convert.FromHexString(input); // try to convert the input string to a byte array
            }
            catch (Exception ex)
            {
                // display error
                this.F1_errorProvider_InputValidation.SetError(this.F1_textBox_RawDataToBeSent, $"Invalid hexadecimal value provided: {ex.Message}");
            }

            return rawBytes;
        }
        
        /// <summary>
        /// Log data into the F1 raw data list box.
        /// </summary>
        /// <param name="data">data to be logged</param>
        /// <param name="direction">direction, with respect to the application (Tx by the app / Rx by the app ) </param>
        private void logDataIntoView(byte[] data, SerialCommunication.Direction direction)
        {
            string dataLog = $"[{DateTime.Now.Subtract(Logging.START_SERIAL_COMM_TS_MS).TotalMilliseconds}] [{SerialCommunication.DirectionStr[(int)direction]}] {Utility.FormatHextString(data)}";
            this.F1_listBox_RawData.Items.Add(dataLog);
        }

        #endregion


        private void F1_CommunicationMainForm_Load(object sender, EventArgs e)
        {
            // display the loaded communication protocols as options for communication
            this.displayProtocols();
            this.displayResources();
            if (this.F1_comboBox_BaudRate.Items.Count > 0) this.F1_comboBox_BaudRate.SelectedIndex = 0;
        }

        /// <summary>
        /// Send raw data over the selected port, with the specified details.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void F1_button_SendPacket_Click(object sender, EventArgs e)
        {
            // store starting timestamp
            if(Logging.START_SERIAL_COMM_TS_MS == DateTime.UnixEpoch) // if the starting timestamp was not yet set, set it to the current timestamp 
                Logging.START_SERIAL_COMM_TS_MS = DateTime.Now;

            // validate input (bytes)
            byte[] rawBytes = this.getBytesFromHexString(this.F1_textBox_RawDataToBeSent.Text);

            if (rawBytes.Length != 0) // valid hex-string
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

                    // get the new port and set it as the current serial communication port for the application
                    SerialCommunication.CrtPort = SerialCommunication.Resources[this.F1_comboBox_Resources.SelectedItem.ToString()];

                    // set communication details
                    SerialCommunication.CrtPort.BaudRate = Int32.Parse(this.F1_comboBox_BaudRate.SelectedItem.ToString());

                    // send data
                    SerialCommunication.Write(rawBytes);

                    // log data in the GUI
                    this.logDataIntoView(rawBytes, SerialCommunication.Direction.Transmit); // log data into the GUI

                    // log data to Logging.SERIAL_COMM_LOG, if logging is enabled
                    if (this.F1_checkBox_LogTransmission.Checked == true)
                    {
                        Logging.LogData(rawBytes, SerialCommunication.Direction.Transmit); // log data
                    }

                }
                catch (Exception ex) // error sending data
                {
                    Logging.Log($"Error sending raw data! Details: {ex.Message}", Logging.Level.ERROR);
                }

            }
            // an error is displayed in 'getBytesFromHexString()'

        }

        private void F1_textBox_RawDataToBeSent_TextChanged(object sender, EventArgs e)
        {

        }

        private void F1_button_SearchBytes_Click(object sender, EventArgs e)
        {
            // search the specified bytes in the raw data
            //TODO: Implement raw bytes search
        }

        private void F1_comboBox_Resources_SelectedIndexChanged(object sender, EventArgs e)
        {

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
    }
}
