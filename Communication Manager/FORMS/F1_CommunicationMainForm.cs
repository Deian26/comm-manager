using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
            // parse the loaded protocols and load them into the form
            foreach(string protocolName in SerialCommunication.Protocols.Keys)
            {
                this.F1_comboBox_Protocols.Items.Add(protocolName);
            }
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
            } catch(Exception ex)
            {

            }

            return rawBytes;
        }
        #endregion


        private void F1_CommunicationMainForm_Load(object sender, EventArgs e)
        {
            // display the loaded communication protocols as options for communication


        }

        private void F1_button_SendPacket_Click(object sender, EventArgs e)
        {
            // send the current raw data on the selected resource
        }

        private void F1_textBox_RawDataToBeSent_TextChanged(object sender, EventArgs e)
        {
            // validate input (bytes)
            byte[] rawBytes = getBytesFromHexString(this.F1_textBox_RawDataToBeSent.Text);

            if (rawBytes.Length != 0) // valid hex-string
            {
                // send data
                //TODO: Implement raw data transmission

            }else // display error
            {
                this.F1_errorProvider_InputValidation.SetError(this.F1_textBox_RawDataToBeSent, "Invalid hexadecimal value provided!");
            }
        }
    }
}
