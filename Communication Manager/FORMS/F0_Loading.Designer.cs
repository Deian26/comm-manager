namespace Communication_Manager
{
    partial class F0_Loading
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            F0_listBox_loadingEventLog = new ListBox();
            SuspendLayout();
            // 
            // F0_listBox_loadingEventLog
            // 
            F0_listBox_loadingEventLog.FormattingEnabled = true;
            F0_listBox_loadingEventLog.Location = new Point(12, 16);
            F0_listBox_loadingEventLog.Name = "F0_listBox_loadingEventLog";
            F0_listBox_loadingEventLog.Size = new Size(1886, 604);
            F0_listBox_loadingEventLog.TabIndex = 0;
            F0_listBox_loadingEventLog.UseWaitCursor = true;
            // 
            // F0_Loading
            // 
            AutoScaleDimensions = new SizeF(18F, 40F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            ClientSize = new Size(1910, 647);
            Controls.Add(F0_listBox_loadingEventLog);
            Font = new Font("Cascadia Code", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(3, 4, 3, 4);
            Name = "F0_Loading";
            Text = "Communication Manager";
            UseWaitCursor = true;
            Load += F0_Loading_Load;
            ResumeLayout(false);
        }

        #endregion

        private ListBox F0_listBox_loadingEventLog;
    }
}