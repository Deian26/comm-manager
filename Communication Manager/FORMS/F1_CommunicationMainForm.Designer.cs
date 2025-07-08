namespace Communication_Manager
{
    partial class F1_CommunicationMainForm
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
            components = new System.ComponentModel.Container();
            F1_comboBox_Protocols = new ComboBox();
            F1_tableLayoutPanel_CommMainFormOptionsLayoutControl = new TableLayoutPanel();
            F1_checkBox_LogTransmission = new CheckBox();
            F1_label_ProtocolLabel = new Label();
            F1_label_ResourceLabel = new Label();
            F1_comboBox_Resources = new ComboBox();
            F1_button_SearchBytes = new Button();
            F1_textBox_SearchTextBox = new TextBox();
            F1_label_BaudRate = new Label();
            F1_comboBox_BaudRate = new ComboBox();
            F1_checkBox_OnlySimulatedResources = new CheckBox();
            F1_button_SendPacket = new Button();
            F1_listBox_RawData = new ListBox();
            F1_treeView_ProcessedData = new TreeView();
            F1_textBox_RawDataToBeSent = new TextBox();
            F1_label_RawDataToBeSentLabel = new Label();
            F1_errorProvider_InputValidation = new ErrorProvider(components);
            F1_tableLayoutPanel_CommMainFormOptionsLayoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)F1_errorProvider_InputValidation).BeginInit();
            SuspendLayout();
            // 
            // F1_comboBox_Protocols
            // 
            F1_comboBox_Protocols.FormattingEnabled = true;
            F1_comboBox_Protocols.Location = new Point(3, 55);
            F1_comboBox_Protocols.Name = "F1_comboBox_Protocols";
            F1_comboBox_Protocols.Size = new Size(313, 48);
            F1_comboBox_Protocols.TabIndex = 0;
            // 
            // F1_tableLayoutPanel_CommMainFormOptionsLayoutControl
            // 
            F1_tableLayoutPanel_CommMainFormOptionsLayoutControl.ColumnCount = 5;
            F1_tableLayoutPanel_CommMainFormOptionsLayoutControl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 51.263F));
            F1_tableLayoutPanel_CommMainFormOptionsLayoutControl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 48.737F));
            F1_tableLayoutPanel_CommMainFormOptionsLayoutControl.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 210F));
            F1_tableLayoutPanel_CommMainFormOptionsLayoutControl.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 364F));
            F1_tableLayoutPanel_CommMainFormOptionsLayoutControl.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 500F));
            F1_tableLayoutPanel_CommMainFormOptionsLayoutControl.Controls.Add(F1_checkBox_LogTransmission, 3, 0);
            F1_tableLayoutPanel_CommMainFormOptionsLayoutControl.Controls.Add(F1_label_ProtocolLabel, 0, 0);
            F1_tableLayoutPanel_CommMainFormOptionsLayoutControl.Controls.Add(F1_label_ResourceLabel, 1, 0);
            F1_tableLayoutPanel_CommMainFormOptionsLayoutControl.Controls.Add(F1_comboBox_Resources, 1, 1);
            F1_tableLayoutPanel_CommMainFormOptionsLayoutControl.Controls.Add(F1_comboBox_Protocols, 0, 1);
            F1_tableLayoutPanel_CommMainFormOptionsLayoutControl.Controls.Add(F1_button_SearchBytes, 4, 0);
            F1_tableLayoutPanel_CommMainFormOptionsLayoutControl.Controls.Add(F1_textBox_SearchTextBox, 4, 1);
            F1_tableLayoutPanel_CommMainFormOptionsLayoutControl.Controls.Add(F1_label_BaudRate, 2, 0);
            F1_tableLayoutPanel_CommMainFormOptionsLayoutControl.Controls.Add(F1_comboBox_BaudRate, 2, 1);
            F1_tableLayoutPanel_CommMainFormOptionsLayoutControl.Controls.Add(F1_checkBox_OnlySimulatedResources, 3, 1);
            F1_tableLayoutPanel_CommMainFormOptionsLayoutControl.Location = new Point(12, 12);
            F1_tableLayoutPanel_CommMainFormOptionsLayoutControl.Name = "F1_tableLayoutPanel_CommMainFormOptionsLayoutControl";
            F1_tableLayoutPanel_CommMainFormOptionsLayoutControl.RowCount = 2;
            F1_tableLayoutPanel_CommMainFormOptionsLayoutControl.RowStyles.Add(new RowStyle(SizeType.Percent, 45.9677429F));
            F1_tableLayoutPanel_CommMainFormOptionsLayoutControl.RowStyles.Add(new RowStyle(SizeType.Percent, 54.0322571F));
            F1_tableLayoutPanel_CommMainFormOptionsLayoutControl.Size = new Size(1711, 114);
            F1_tableLayoutPanel_CommMainFormOptionsLayoutControl.TabIndex = 1;
            // 
            // F1_checkBox_LogTransmission
            // 
            F1_checkBox_LogTransmission.AutoSize = true;
            F1_checkBox_LogTransmission.Location = new Point(849, 3);
            F1_checkBox_LogTransmission.Name = "F1_checkBox_LogTransmission";
            F1_checkBox_LogTransmission.Size = new Size(343, 44);
            F1_checkBox_LogTransmission.TabIndex = 11;
            F1_checkBox_LogTransmission.Text = "Log transmission";
            F1_checkBox_LogTransmission.UseVisualStyleBackColor = true;
            F1_checkBox_LogTransmission.CheckedChanged += F1_checkBox_LogTransmission_CheckedChanged;
            // 
            // F1_label_ProtocolLabel
            // 
            F1_label_ProtocolLabel.AutoSize = true;
            F1_label_ProtocolLabel.Font = new Font("Cascadia Code", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            F1_label_ProtocolLabel.Location = new Point(3, 0);
            F1_label_ProtocolLabel.Name = "F1_label_ProtocolLabel";
            F1_label_ProtocolLabel.Size = new Size(161, 40);
            F1_label_ProtocolLabel.TabIndex = 1;
            F1_label_ProtocolLabel.Text = "Protocol";
            // 
            // F1_label_ResourceLabel
            // 
            F1_label_ResourceLabel.AutoSize = true;
            F1_label_ResourceLabel.Font = new Font("Cascadia Code", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            F1_label_ResourceLabel.Location = new Point(329, 0);
            F1_label_ResourceLabel.Name = "F1_label_ResourceLabel";
            F1_label_ResourceLabel.Size = new Size(161, 40);
            F1_label_ResourceLabel.TabIndex = 2;
            F1_label_ResourceLabel.Text = "Resource";
            // 
            // F1_comboBox_Resources
            // 
            F1_comboBox_Resources.FormattingEnabled = true;
            F1_comboBox_Resources.Location = new Point(329, 55);
            F1_comboBox_Resources.Name = "F1_comboBox_Resources";
            F1_comboBox_Resources.Size = new Size(304, 48);
            F1_comboBox_Resources.TabIndex = 3;
            F1_comboBox_Resources.SelectedIndexChanged += F1_comboBox_Resources_SelectedIndexChanged;
            // 
            // F1_button_SearchBytes
            // 
            F1_button_SearchBytes.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            F1_button_SearchBytes.Location = new Point(1520, 3);
            F1_button_SearchBytes.Name = "F1_button_SearchBytes";
            F1_button_SearchBytes.Size = new Size(188, 46);
            F1_button_SearchBytes.TabIndex = 6;
            F1_button_SearchBytes.Text = "Search";
            F1_button_SearchBytes.UseVisualStyleBackColor = true;
            F1_button_SearchBytes.Click += F1_button_SearchBytes_Click;
            // 
            // F1_textBox_SearchTextBox
            // 
            F1_textBox_SearchTextBox.Location = new Point(1213, 55);
            F1_textBox_SearchTextBox.Name = "F1_textBox_SearchTextBox";
            F1_textBox_SearchTextBox.Size = new Size(495, 42);
            F1_textBox_SearchTextBox.TabIndex = 6;
            // 
            // F1_label_BaudRate
            // 
            F1_label_BaudRate.AutoSize = true;
            F1_label_BaudRate.Font = new Font("Cascadia Code", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            F1_label_BaudRate.Location = new Point(639, 0);
            F1_label_BaudRate.Name = "F1_label_BaudRate";
            F1_label_BaudRate.Size = new Size(179, 40);
            F1_label_BaudRate.TabIndex = 7;
            F1_label_BaudRate.Text = "Baud Rate";
            // 
            // F1_comboBox_BaudRate
            // 
            F1_comboBox_BaudRate.FormattingEnabled = true;
            F1_comboBox_BaudRate.Items.AddRange(new object[] { "9600", "300", "1200", "2400", "4800", "19200", "38400", "57600", "115200", "230400", "460800", "921600" });
            F1_comboBox_BaudRate.Location = new Point(639, 55);
            F1_comboBox_BaudRate.Name = "F1_comboBox_BaudRate";
            F1_comboBox_BaudRate.Size = new Size(204, 48);
            F1_comboBox_BaudRate.TabIndex = 8;
            // 
            // F1_checkBox_OnlySimulatedResources
            // 
            F1_checkBox_OnlySimulatedResources.AutoSize = true;
            F1_checkBox_OnlySimulatedResources.Location = new Point(849, 55);
            F1_checkBox_OnlySimulatedResources.Name = "F1_checkBox_OnlySimulatedResources";
            F1_checkBox_OnlySimulatedResources.Size = new Size(307, 44);
            F1_checkBox_OnlySimulatedResources.TabIndex = 10;
            F1_checkBox_OnlySimulatedResources.Text = "Only Simulated";
            F1_checkBox_OnlySimulatedResources.UseVisualStyleBackColor = true;
            F1_checkBox_OnlySimulatedResources.CheckedChanged += F1_checkBox_OnlySimulatedResources_CheckedChanged;
            // 
            // F1_button_SendPacket
            // 
            F1_button_SendPacket.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            F1_button_SendPacket.Location = new Point(1537, 164);
            F1_button_SendPacket.Name = "F1_button_SendPacket";
            F1_button_SendPacket.Size = new Size(188, 49);
            F1_button_SendPacket.TabIndex = 4;
            F1_button_SendPacket.Text = "Send";
            F1_button_SendPacket.UseVisualStyleBackColor = true;
            F1_button_SendPacket.Click += F1_button_SendPacket_Click;
            // 
            // F1_listBox_RawData
            // 
            F1_listBox_RawData.FormattingEnabled = true;
            F1_listBox_RawData.Location = new Point(12, 219);
            F1_listBox_RawData.Name = "F1_listBox_RawData";
            F1_listBox_RawData.Size = new Size(1711, 484);
            F1_listBox_RawData.TabIndex = 2;
            // 
            // F1_treeView_ProcessedData
            // 
            F1_treeView_ProcessedData.Location = new Point(12, 709);
            F1_treeView_ProcessedData.Name = "F1_treeView_ProcessedData";
            F1_treeView_ProcessedData.Size = new Size(1711, 421);
            F1_treeView_ProcessedData.TabIndex = 3;
            // 
            // F1_textBox_RawDataToBeSent
            // 
            F1_textBox_RawDataToBeSent.Location = new Point(12, 171);
            F1_textBox_RawDataToBeSent.Name = "F1_textBox_RawDataToBeSent";
            F1_textBox_RawDataToBeSent.Size = new Size(1472, 42);
            F1_textBox_RawDataToBeSent.TabIndex = 5;
            F1_textBox_RawDataToBeSent.TextChanged += F1_textBox_RawDataToBeSent_TextChanged;
            // 
            // F1_label_RawDataToBeSentLabel
            // 
            F1_label_RawDataToBeSentLabel.AutoSize = true;
            F1_label_RawDataToBeSentLabel.Font = new Font("Cascadia Code", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            F1_label_RawDataToBeSentLabel.Location = new Point(12, 129);
            F1_label_RawDataToBeSentLabel.Name = "F1_label_RawDataToBeSentLabel";
            F1_label_RawDataToBeSentLabel.Size = new Size(107, 40);
            F1_label_RawDataToBeSentLabel.TabIndex = 5;
            F1_label_RawDataToBeSentLabel.Text = "Bytes";
            // 
            // F1_errorProvider_InputValidation
            // 
            F1_errorProvider_InputValidation.ContainerControl = this;
            // 
            // F1_CommunicationMainForm
            // 
            AutoScaleDimensions = new SizeF(18F, 40F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            ClientSize = new Size(1735, 1142);
            Controls.Add(F1_label_RawDataToBeSentLabel);
            Controls.Add(F1_textBox_RawDataToBeSent);
            Controls.Add(F1_treeView_ProcessedData);
            Controls.Add(F1_listBox_RawData);
            Controls.Add(F1_tableLayoutPanel_CommMainFormOptionsLayoutControl);
            Controls.Add(F1_button_SendPacket);
            Font = new Font("Cascadia Code", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "F1_CommunicationMainForm";
            Text = "Communication Manager";
            Load += F1_CommunicationMainForm_Load;
            F1_tableLayoutPanel_CommMainFormOptionsLayoutControl.ResumeLayout(false);
            F1_tableLayoutPanel_CommMainFormOptionsLayoutControl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)F1_errorProvider_InputValidation).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox F1_comboBox_Protocols;
        private TableLayoutPanel F1_tableLayoutPanel_CommMainFormOptionsLayoutControl;
        private Label F1_label_ProtocolLabel;
        private Label F1_label_ResourceLabel;
        private ComboBox F1_comboBox_Resources;
        private Button F1_button_SendPacket;
        private ListBox F1_listBox_RawData;
        private TreeView F1_treeView_ProcessedData;
        private TextBox F1_textBox_RawDataToBeSent;
        private Label F1_label_RawDataToBeSentLabel;
        private ErrorProvider F1_errorProvider_InputValidation;
        private TextBox F1_textBox_SearchTextBox;
        private Label F1_label_BaudRate;
        private ComboBox F1_comboBox_BaudRate;
        private Button F1_button_SearchBytes;
        private CheckBox F1_checkBox_OnlySimulatedResources;
        private CheckBox F1_checkBox_LogTransmission;
    }
}