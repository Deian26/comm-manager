using Communication_Manager;
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
    public partial class F0_Loading : Form
    {
        public F0_Loading()
        {
            InitializeComponent();

            this.MaximumSize = this.MinimumSize = this.Size;
        }

        /// <summary>
        /// Load configuration files; initialize application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void F0_Loading_Load(object sender, EventArgs e)
        {
            // start event log
            this.F0_listBox_loadingEventLog.Items.Add("Initializing logs ...");
            Logging.InitLog();

            this.F0_listBox_loadingEventLog.Items.Add("Loading configuration files");
            Utility.LoadProtocolDefinitions(Utility.CONFIG_FOLDER_PATH, this.F0_listBox_loadingEventLog);

            this.F0_listBox_loadingEventLog.Items.Add("Finished loading configuration files");

            // wait to smooth the transition
            Thread.Sleep(2000);

            // hide this form and open the communication interface main form
            Start.f1_CommMainForm.ShowDialog();

            this.Close();
        }
    }
}
