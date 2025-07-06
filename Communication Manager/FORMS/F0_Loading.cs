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
        }

        /// <summary>
        /// Load configuration files; initialize application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void F0_Loading_Load(object sender, EventArgs e)
        {
            Logging.InitLog();
            Utility.LoadProtocolDefinitions(Utility.CONFIG_FOLDER_PATH);
        }
    }
}
