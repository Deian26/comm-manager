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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            F1_comboBox_Protocols = new ComboBox();
            F1_tableLayoutPanel_CommMainFormOptionsLayoutControl = new TableLayoutPanel();
            F1_button_ResetConnectionToResource = new Button();
            F1_label_ProtocolLabel = new Label();
            F1_label_ResourceLabel = new Label();
            F1_label_BaudRate = new Label();
            F1_comboBox_BaudRate = new ComboBox();
            F1_comboBox_Resources = new ComboBox();
            F1_button_SearchBytes = new Button();
            F1_textBox_SearchTextBox = new TextBox();
            F1_checkBox_LogTransmission = new CheckBox();
            F1_checkBox_OnlySimulatedResources = new CheckBox();
            F1_button_SendPacket = new Button();
            F1_treeView_ProcessedData = new TreeView();
            F1_textBox_RawDataToBeSent = new TextBox();
            F1_label_RawDataToBeSentLabel = new Label();
            F1_errorProvider_InputValidation = new ErrorProvider(components);
            F1_dataGridView_CommView = new DataGridView();
            F1_toolTip_ToolTip = new ToolTip(components);
            F1_errorProvider_BackgroundProcessError = new ErrorProvider(components);
            F1_timer_PeriodicUpdate = new System.Windows.Forms.Timer(components);
            F1_panel_ApplicationPanel = new Panel();
            F1_panel_RTT_ApplicationPanelOptions = new Panel();
            F1_label_RTT_TemperatureUnitText = new Label();
            F1_textBox_RTT_Temperature = new TextBox();
            F1_label_RTT_TemperatureText = new Label();
            label_F1_AppName = new Label();
            F1_checkBox_RTT_PriorityCmd = new CheckBox();
            F1_button_RTT_SendCommand = new Button();
            F1_panel_RTT_LockPanel = new Panel();
            F1_comboBox_RTT_CommandLock_RequestedLockState = new ComboBox();
            F1_label_RTT_CommandLock_RequestedLockState = new Label();
            F1_label_RTT_CommandLock_LockKeyLabel = new Label();
            F1_textBox_RTT_CommandLock_LockKey = new TextBox();
            F1_panel_RTT_ChangePowerLevelPanel = new Panel();
            F1_comboBox_RTT_CommandChangePowerLevel_PowerLevel = new ComboBox();
            F1_label_RTT_CommandChangePowerLevel_PowerLevelLabel = new Label();
            F1_panel_RTT_SetModePanel = new Panel();
            F1_comboBox_RTT_CommandSetMode_Mode = new ComboBox();
            F1_label_RTT_CommandSetMode_ModeLabel = new Label();
            F1_label_RTT_RequestedCommandLabel = new Label();
            F1_panel_RTT_AddNode = new Panel();
            label_RTT_CommandAddNode_IpAddressLabel = new Label();
            textBox_RTT_CommandAddNode_IpAddress = new TextBox();
            F1_comboBox_RTT_RequestedCommand = new ComboBox();
            F1_label_RequestedAppNameLabel = new Label();
            F1_comboBox_RequestedAppName = new ComboBox();
            TimestampMs = new DataGridViewTextBoxColumn();
            Direction = new DataGridViewTextBoxColumn();
            Type = new DataGridViewTextBoxColumn();
            Payload = new DataGridViewTextBoxColumn();
            Protocol = new DataGridViewTextBoxColumn();
            F1_tableLayoutPanel_CommMainFormOptionsLayoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)F1_errorProvider_InputValidation).BeginInit();
            ((System.ComponentModel.ISupportInitialize)F1_dataGridView_CommView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)F1_errorProvider_BackgroundProcessError).BeginInit();
            F1_panel_ApplicationPanel.SuspendLayout();
            F1_panel_RTT_ApplicationPanelOptions.SuspendLayout();
            F1_panel_RTT_LockPanel.SuspendLayout();
            F1_panel_RTT_ChangePowerLevelPanel.SuspendLayout();
            F1_panel_RTT_SetModePanel.SuspendLayout();
            F1_panel_RTT_AddNode.SuspendLayout();
            SuspendLayout();
            // 
            // F1_comboBox_Protocols
            // 
            F1_comboBox_Protocols.DropDownStyle = ComboBoxStyle.DropDownList;
            F1_comboBox_Protocols.FormattingEnabled = true;
            F1_comboBox_Protocols.Location = new Point(3, 80);
            F1_comboBox_Protocols.Name = "F1_comboBox_Protocols";
            F1_comboBox_Protocols.Size = new Size(313, 48);
            F1_comboBox_Protocols.TabIndex = 0;
            // 
            // F1_tableLayoutPanel_CommMainFormOptionsLayoutControl
            // 
            F1_tableLayoutPanel_CommMainFormOptionsLayoutControl.ColumnCount = 6;
            F1_tableLayoutPanel_CommMainFormOptionsLayoutControl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 51.263F));
            F1_tableLayoutPanel_CommMainFormOptionsLayoutControl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 48.737F));
            F1_tableLayoutPanel_CommMainFormOptionsLayoutControl.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 239F));
            F1_tableLayoutPanel_CommMainFormOptionsLayoutControl.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 404F));
            F1_tableLayoutPanel_CommMainFormOptionsLayoutControl.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 374F));
            F1_tableLayoutPanel_CommMainFormOptionsLayoutControl.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 342F));
            F1_tableLayoutPanel_CommMainFormOptionsLayoutControl.Controls.Add(F1_button_ResetConnectionToResource, 3, 1);
            F1_tableLayoutPanel_CommMainFormOptionsLayoutControl.Controls.Add(F1_label_ProtocolLabel, 0, 0);
            F1_tableLayoutPanel_CommMainFormOptionsLayoutControl.Controls.Add(F1_label_ResourceLabel, 1, 0);
            F1_tableLayoutPanel_CommMainFormOptionsLayoutControl.Controls.Add(F1_comboBox_Protocols, 0, 1);
            F1_tableLayoutPanel_CommMainFormOptionsLayoutControl.Controls.Add(F1_label_BaudRate, 2, 0);
            F1_tableLayoutPanel_CommMainFormOptionsLayoutControl.Controls.Add(F1_comboBox_BaudRate, 2, 1);
            F1_tableLayoutPanel_CommMainFormOptionsLayoutControl.Controls.Add(F1_comboBox_Resources, 1, 1);
            F1_tableLayoutPanel_CommMainFormOptionsLayoutControl.Controls.Add(F1_button_SearchBytes, 5, 0);
            F1_tableLayoutPanel_CommMainFormOptionsLayoutControl.Controls.Add(F1_textBox_SearchTextBox, 5, 1);
            F1_tableLayoutPanel_CommMainFormOptionsLayoutControl.Controls.Add(F1_checkBox_LogTransmission, 4, 0);
            F1_tableLayoutPanel_CommMainFormOptionsLayoutControl.Controls.Add(F1_checkBox_OnlySimulatedResources, 4, 1);
            F1_tableLayoutPanel_CommMainFormOptionsLayoutControl.Location = new Point(12, 12);
            F1_tableLayoutPanel_CommMainFormOptionsLayoutControl.Name = "F1_tableLayoutPanel_CommMainFormOptionsLayoutControl";
            F1_tableLayoutPanel_CommMainFormOptionsLayoutControl.RowCount = 2;
            F1_tableLayoutPanel_CommMainFormOptionsLayoutControl.RowStyles.Add(new RowStyle(SizeType.Percent, 45.9677429F));
            F1_tableLayoutPanel_CommMainFormOptionsLayoutControl.RowStyles.Add(new RowStyle(SizeType.Percent, 54.0322571F));
            F1_tableLayoutPanel_CommMainFormOptionsLayoutControl.Size = new Size(2054, 169);
            F1_tableLayoutPanel_CommMainFormOptionsLayoutControl.TabIndex = 1;
            // 
            // F1_button_ResetConnectionToResource
            // 
            F1_errorProvider_BackgroundProcessError.SetIconAlignment(F1_button_ResetConnectionToResource, ErrorIconAlignment.MiddleLeft);
            F1_errorProvider_InputValidation.SetIconAlignment(F1_button_ResetConnectionToResource, ErrorIconAlignment.MiddleLeft);
            F1_button_ResetConnectionToResource.Location = new Point(936, 80);
            F1_button_ResetConnectionToResource.Name = "F1_button_ResetConnectionToResource";
            F1_button_ResetConnectionToResource.Size = new Size(332, 49);
            F1_button_ResetConnectionToResource.TabIndex = 13;
            F1_button_ResetConnectionToResource.Text = "Reset Connection";
            F1_button_ResetConnectionToResource.UseVisualStyleBackColor = true;
            F1_button_ResetConnectionToResource.Click += F1_button_ResetConnectionToResource_Click;
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
            F1_label_ResourceLabel.Location = new Point(359, 0);
            F1_label_ResourceLabel.Name = "F1_label_ResourceLabel";
            F1_label_ResourceLabel.Size = new Size(161, 40);
            F1_label_ResourceLabel.TabIndex = 2;
            F1_label_ResourceLabel.Text = "Resource";
            // 
            // F1_label_BaudRate
            // 
            F1_label_BaudRate.AutoSize = true;
            F1_label_BaudRate.Font = new Font("Cascadia Code", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            F1_label_BaudRate.Location = new Point(697, 0);
            F1_label_BaudRate.Name = "F1_label_BaudRate";
            F1_label_BaudRate.Size = new Size(179, 40);
            F1_label_BaudRate.TabIndex = 7;
            F1_label_BaudRate.Text = "Baud Rate";
            // 
            // F1_comboBox_BaudRate
            // 
            F1_comboBox_BaudRate.DropDownStyle = ComboBoxStyle.DropDownList;
            F1_comboBox_BaudRate.FormattingEnabled = true;
            F1_comboBox_BaudRate.Items.AddRange(new object[] { "9600", "300", "1200", "2400", "4800", "19200", "38400", "57600", "115200", "230400", "460800", "921600" });
            F1_comboBox_BaudRate.Location = new Point(697, 80);
            F1_comboBox_BaudRate.Name = "F1_comboBox_BaudRate";
            F1_comboBox_BaudRate.Size = new Size(204, 48);
            F1_comboBox_BaudRate.TabIndex = 8;
            // 
            // F1_comboBox_Resources
            // 
            F1_comboBox_Resources.DropDownStyle = ComboBoxStyle.DropDownList;
            F1_comboBox_Resources.FormattingEnabled = true;
            F1_comboBox_Resources.Location = new Point(359, 80);
            F1_comboBox_Resources.Name = "F1_comboBox_Resources";
            F1_comboBox_Resources.Size = new Size(256, 48);
            F1_comboBox_Resources.TabIndex = 3;
            F1_comboBox_Resources.SelectedIndexChanged += F1_comboBox_Resources_SelectedIndexChanged;
            // 
            // F1_button_SearchBytes
            // 
            F1_button_SearchBytes.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            F1_button_SearchBytes.Location = new Point(1863, 3);
            F1_button_SearchBytes.Name = "F1_button_SearchBytes";
            F1_button_SearchBytes.Size = new Size(188, 54);
            F1_button_SearchBytes.TabIndex = 6;
            F1_button_SearchBytes.Text = "Search";
            F1_button_SearchBytes.UseVisualStyleBackColor = true;
            F1_button_SearchBytes.Click += F1_button_SearchBytes_Click;
            // 
            // F1_textBox_SearchTextBox
            // 
            F1_textBox_SearchTextBox.Location = new Point(1714, 80);
            F1_textBox_SearchTextBox.Name = "F1_textBox_SearchTextBox";
            F1_textBox_SearchTextBox.Size = new Size(333, 42);
            F1_textBox_SearchTextBox.TabIndex = 6;
            // 
            // F1_checkBox_LogTransmission
            // 
            F1_checkBox_LogTransmission.AutoSize = true;
            F1_checkBox_LogTransmission.Location = new Point(1340, 3);
            F1_checkBox_LogTransmission.Name = "F1_checkBox_LogTransmission";
            F1_checkBox_LogTransmission.Size = new Size(343, 44);
            F1_checkBox_LogTransmission.TabIndex = 11;
            F1_checkBox_LogTransmission.Text = "Log transmission";
            F1_checkBox_LogTransmission.UseVisualStyleBackColor = true;
            F1_checkBox_LogTransmission.CheckedChanged += F1_checkBox_LogTransmission_CheckedChanged;
            // 
            // F1_checkBox_OnlySimulatedResources
            // 
            F1_checkBox_OnlySimulatedResources.AutoSize = true;
            F1_checkBox_OnlySimulatedResources.Location = new Point(1340, 80);
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
            F1_button_SendPacket.Location = new Point(1901, 230);
            F1_button_SendPacket.Name = "F1_button_SendPacket";
            F1_button_SendPacket.Size = new Size(162, 49);
            F1_button_SendPacket.TabIndex = 4;
            F1_button_SendPacket.Text = "Send";
            F1_button_SendPacket.UseVisualStyleBackColor = true;
            F1_button_SendPacket.Click += F1_button_SendPacket_Click;
            // 
            // F1_treeView_ProcessedData
            // 
            F1_treeView_ProcessedData.FullRowSelect = true;
            F1_treeView_ProcessedData.Location = new Point(12, 1001);
            F1_treeView_ProcessedData.Name = "F1_treeView_ProcessedData";
            F1_treeView_ProcessedData.Size = new Size(2054, 639);
            F1_treeView_ProcessedData.TabIndex = 3;
            // 
            // F1_textBox_RawDataToBeSent
            // 
            F1_textBox_RawDataToBeSent.Location = new Point(9, 237);
            F1_textBox_RawDataToBeSent.Name = "F1_textBox_RawDataToBeSent";
            F1_textBox_RawDataToBeSent.Size = new Size(1838, 42);
            F1_textBox_RawDataToBeSent.TabIndex = 5;
            // 
            // F1_label_RawDataToBeSentLabel
            // 
            F1_label_RawDataToBeSentLabel.AutoSize = true;
            F1_label_RawDataToBeSentLabel.Font = new Font("Cascadia Code", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            F1_label_RawDataToBeSentLabel.Location = new Point(15, 184);
            F1_label_RawDataToBeSentLabel.Name = "F1_label_RawDataToBeSentLabel";
            F1_label_RawDataToBeSentLabel.Size = new Size(107, 40);
            F1_label_RawDataToBeSentLabel.TabIndex = 5;
            F1_label_RawDataToBeSentLabel.Text = "Bytes";
            // 
            // F1_errorProvider_InputValidation
            // 
            F1_errorProvider_InputValidation.ContainerControl = this;
            // 
            // F1_dataGridView_CommView
            // 
            F1_dataGridView_CommView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            F1_dataGridView_CommView.Columns.AddRange(new DataGridViewColumn[] { TimestampMs, Direction, Type, Payload, Protocol });
            F1_dataGridView_CommView.EditMode = DataGridViewEditMode.EditProgrammatically;
            F1_dataGridView_CommView.ImeMode = ImeMode.NoControl;
            F1_dataGridView_CommView.Location = new Point(9, 285);
            F1_dataGridView_CommView.Name = "F1_dataGridView_CommView";
            F1_dataGridView_CommView.ReadOnly = true;
            F1_dataGridView_CommView.RowHeadersVisible = false;
            F1_dataGridView_CommView.RowHeadersWidth = 102;
            F1_dataGridView_CommView.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            F1_dataGridView_CommView.Size = new Size(2054, 710);
            F1_dataGridView_CommView.TabIndex = 6;
            F1_dataGridView_CommView.CellClick += F1_dataGridView_CommView_CellClick;
            F1_dataGridView_CommView.CellContentClick += F1_dataGridView_CommView_CellContentClick;
            F1_dataGridView_CommView.RowsAdded += F1_dataGridView_CommView_RowsAdded;
            // 
            // F1_errorProvider_BackgroundProcessError
            // 
            F1_errorProvider_BackgroundProcessError.ContainerControl = this;
            // 
            // F1_timer_PeriodicUpdate
            // 
            F1_timer_PeriodicUpdate.Tick += F1_timer_PeriodicUpdate_Tick;
            // 
            // F1_panel_ApplicationPanel
            // 
            F1_panel_ApplicationPanel.Controls.Add(F1_panel_RTT_ApplicationPanelOptions);
            F1_panel_ApplicationPanel.Controls.Add(F1_label_RequestedAppNameLabel);
            F1_panel_ApplicationPanel.Controls.Add(F1_comboBox_RequestedAppName);
            F1_panel_ApplicationPanel.Location = new Point(2072, 15);
            F1_panel_ApplicationPanel.Name = "F1_panel_ApplicationPanel";
            F1_panel_ApplicationPanel.Size = new Size(1089, 1625);
            F1_panel_ApplicationPanel.TabIndex = 7;
            // 
            // F1_panel_RTT_ApplicationPanelOptions
            // 
            F1_panel_RTT_ApplicationPanelOptions.Controls.Add(F1_label_RTT_TemperatureUnitText);
            F1_panel_RTT_ApplicationPanelOptions.Controls.Add(F1_textBox_RTT_Temperature);
            F1_panel_RTT_ApplicationPanelOptions.Controls.Add(F1_label_RTT_TemperatureText);
            F1_panel_RTT_ApplicationPanelOptions.Controls.Add(label_F1_AppName);
            F1_panel_RTT_ApplicationPanelOptions.Controls.Add(F1_checkBox_RTT_PriorityCmd);
            F1_panel_RTT_ApplicationPanelOptions.Controls.Add(F1_button_RTT_SendCommand);
            F1_panel_RTT_ApplicationPanelOptions.Controls.Add(F1_panel_RTT_LockPanel);
            F1_panel_RTT_ApplicationPanelOptions.Controls.Add(F1_panel_RTT_ChangePowerLevelPanel);
            F1_panel_RTT_ApplicationPanelOptions.Controls.Add(F1_panel_RTT_SetModePanel);
            F1_panel_RTT_ApplicationPanelOptions.Controls.Add(F1_label_RTT_RequestedCommandLabel);
            F1_panel_RTT_ApplicationPanelOptions.Controls.Add(F1_panel_RTT_AddNode);
            F1_panel_RTT_ApplicationPanelOptions.Controls.Add(F1_comboBox_RTT_RequestedCommand);
            F1_panel_RTT_ApplicationPanelOptions.Enabled = false;
            F1_panel_RTT_ApplicationPanelOptions.Location = new Point(9, 60);
            F1_panel_RTT_ApplicationPanelOptions.Name = "F1_panel_RTT_ApplicationPanelOptions";
            F1_panel_RTT_ApplicationPanelOptions.Size = new Size(1068, 996);
            F1_panel_RTT_ApplicationPanelOptions.TabIndex = 4;
            F1_panel_RTT_ApplicationPanelOptions.Visible = false;
            // 
            // F1_label_RTT_TemperatureUnitText
            // 
            F1_label_RTT_TemperatureUnitText.AutoSize = true;
            F1_label_RTT_TemperatureUnitText.Font = new Font("Cascadia Code", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            F1_label_RTT_TemperatureUnitText.Location = new Point(570, 926);
            F1_label_RTT_TemperatureUnitText.Name = "F1_label_RTT_TemperatureUnitText";
            F1_label_RTT_TemperatureUnitText.Size = new Size(53, 40);
            F1_label_RTT_TemperatureUnitText.TabIndex = 16;
            F1_label_RTT_TemperatureUnitText.Text = "°C";
            // 
            // F1_textBox_RTT_Temperature
            // 
            F1_textBox_RTT_Temperature.Location = new Point(260, 926);
            F1_textBox_RTT_Temperature.Name = "F1_textBox_RTT_Temperature";
            F1_textBox_RTT_Temperature.ReadOnly = true;
            F1_textBox_RTT_Temperature.Size = new Size(291, 42);
            F1_textBox_RTT_Temperature.TabIndex = 15;
            // 
            // F1_label_RTT_TemperatureText
            // 
            F1_label_RTT_TemperatureText.AutoSize = true;
            F1_label_RTT_TemperatureText.Font = new Font("Cascadia Code", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            F1_label_RTT_TemperatureText.Location = new Point(21, 926);
            F1_label_RTT_TemperatureText.Name = "F1_label_RTT_TemperatureText";
            F1_label_RTT_TemperatureText.Size = new Size(233, 40);
            F1_label_RTT_TemperatureText.TabIndex = 14;
            F1_label_RTT_TemperatureText.Text = "Temperature:";
            // 
            // label_F1_AppName
            // 
            label_F1_AppName.AutoSize = true;
            label_F1_AppName.Location = new Point(228, 40);
            label_F1_AppName.Name = "label_F1_AppName";
            label_F1_AppName.Size = new Size(503, 40);
            label_F1_AppName.TabIndex = 13;
            label_F1_AppName.Text = "Real Time Temperature [RTT]";
            // 
            // F1_checkBox_RTT_PriorityCmd
            // 
            F1_checkBox_RTT_PriorityCmd.AutoSize = true;
            F1_checkBox_RTT_PriorityCmd.Location = new Point(21, 210);
            F1_checkBox_RTT_PriorityCmd.Name = "F1_checkBox_RTT_PriorityCmd";
            F1_checkBox_RTT_PriorityCmd.Size = new Size(343, 44);
            F1_checkBox_RTT_PriorityCmd.TabIndex = 12;
            F1_checkBox_RTT_PriorityCmd.Text = "Priority Command";
            F1_checkBox_RTT_PriorityCmd.UseVisualStyleBackColor = true;
            // 
            // F1_button_RTT_SendCommand
            // 
            F1_button_RTT_SendCommand.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            F1_button_RTT_SendCommand.Location = new Point(661, 155);
            F1_button_RTT_SendCommand.Name = "F1_button_RTT_SendCommand";
            F1_button_RTT_SendCommand.Size = new Size(162, 49);
            F1_button_RTT_SendCommand.TabIndex = 8;
            F1_button_RTT_SendCommand.Text = "Send";
            F1_button_RTT_SendCommand.UseVisualStyleBackColor = true;
            F1_button_RTT_SendCommand.Click += F1_button_RTT_SendCommand_Click;
            // 
            // F1_panel_RTT_LockPanel
            // 
            F1_panel_RTT_LockPanel.Controls.Add(F1_comboBox_RTT_CommandLock_RequestedLockState);
            F1_panel_RTT_LockPanel.Controls.Add(F1_label_RTT_CommandLock_RequestedLockState);
            F1_panel_RTT_LockPanel.Controls.Add(F1_label_RTT_CommandLock_LockKeyLabel);
            F1_panel_RTT_LockPanel.Controls.Add(F1_textBox_RTT_CommandLock_LockKey);
            F1_panel_RTT_LockPanel.Enabled = false;
            F1_panel_RTT_LockPanel.Location = new Point(21, 691);
            F1_panel_RTT_LockPanel.Name = "F1_panel_RTT_LockPanel";
            F1_panel_RTT_LockPanel.Size = new Size(1031, 117);
            F1_panel_RTT_LockPanel.TabIndex = 11;
            F1_panel_RTT_LockPanel.Visible = false;
            // 
            // F1_comboBox_RTT_CommandLock_RequestedLockState
            // 
            F1_comboBox_RTT_CommandLock_RequestedLockState.DropDownStyle = ComboBoxStyle.DropDownList;
            F1_comboBox_RTT_CommandLock_RequestedLockState.FormattingEnabled = true;
            F1_comboBox_RTT_CommandLock_RequestedLockState.Location = new Point(231, 42);
            F1_comboBox_RTT_CommandLock_RequestedLockState.Name = "F1_comboBox_RTT_CommandLock_RequestedLockState";
            F1_comboBox_RTT_CommandLock_RequestedLockState.Size = new Size(302, 48);
            F1_comboBox_RTT_CommandLock_RequestedLockState.TabIndex = 15;
            // 
            // F1_label_RTT_CommandLock_RequestedLockState
            // 
            F1_label_RTT_CommandLock_RequestedLockState.AutoSize = true;
            F1_label_RTT_CommandLock_RequestedLockState.Font = new Font("Cascadia Code", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            F1_label_RTT_CommandLock_RequestedLockState.Location = new Point(6, 45);
            F1_label_RTT_CommandLock_RequestedLockState.Name = "F1_label_RTT_CommandLock_RequestedLockState";
            F1_label_RTT_CommandLock_RequestedLockState.Size = new Size(107, 40);
            F1_label_RTT_CommandLock_RequestedLockState.TabIndex = 9;
            F1_label_RTT_CommandLock_RequestedLockState.Text = "State";
            // 
            // F1_label_RTT_CommandLock_LockKeyLabel
            // 
            F1_label_RTT_CommandLock_LockKeyLabel.AutoSize = true;
            F1_label_RTT_CommandLock_LockKeyLabel.Font = new Font("Cascadia Code", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            F1_label_RTT_CommandLock_LockKeyLabel.Location = new Point(640, 45);
            F1_label_RTT_CommandLock_LockKeyLabel.Name = "F1_label_RTT_CommandLock_LockKeyLabel";
            F1_label_RTT_CommandLock_LockKeyLabel.Size = new Size(71, 40);
            F1_label_RTT_CommandLock_LockKeyLabel.TabIndex = 7;
            F1_label_RTT_CommandLock_LockKeyLabel.Text = "Key";
            // 
            // F1_textBox_RTT_CommandLock_LockKey
            // 
            F1_textBox_RTT_CommandLock_LockKey.Location = new Point(717, 45);
            F1_textBox_RTT_CommandLock_LockKey.Name = "F1_textBox_RTT_CommandLock_LockKey";
            F1_textBox_RTT_CommandLock_LockKey.Size = new Size(293, 42);
            F1_textBox_RTT_CommandLock_LockKey.TabIndex = 8;
            // 
            // F1_panel_RTT_ChangePowerLevelPanel
            // 
            F1_panel_RTT_ChangePowerLevelPanel.Controls.Add(F1_comboBox_RTT_CommandChangePowerLevel_PowerLevel);
            F1_panel_RTT_ChangePowerLevelPanel.Controls.Add(F1_label_RTT_CommandChangePowerLevel_PowerLevelLabel);
            F1_panel_RTT_ChangePowerLevelPanel.Enabled = false;
            F1_panel_RTT_ChangePowerLevelPanel.Location = new Point(21, 556);
            F1_panel_RTT_ChangePowerLevelPanel.Name = "F1_panel_RTT_ChangePowerLevelPanel";
            F1_panel_RTT_ChangePowerLevelPanel.Size = new Size(1031, 117);
            F1_panel_RTT_ChangePowerLevelPanel.TabIndex = 10;
            F1_panel_RTT_ChangePowerLevelPanel.Visible = false;
            // 
            // F1_comboBox_RTT_CommandChangePowerLevel_PowerLevel
            // 
            F1_comboBox_RTT_CommandChangePowerLevel_PowerLevel.DropDownStyle = ComboBoxStyle.DropDownList;
            F1_comboBox_RTT_CommandChangePowerLevel_PowerLevel.FormattingEnabled = true;
            F1_comboBox_RTT_CommandChangePowerLevel_PowerLevel.Location = new Point(228, 34);
            F1_comboBox_RTT_CommandChangePowerLevel_PowerLevel.Name = "F1_comboBox_RTT_CommandChangePowerLevel_PowerLevel";
            F1_comboBox_RTT_CommandChangePowerLevel_PowerLevel.Size = new Size(302, 48);
            F1_comboBox_RTT_CommandChangePowerLevel_PowerLevel.TabIndex = 14;
            // 
            // F1_label_RTT_CommandChangePowerLevel_PowerLevelLabel
            // 
            F1_label_RTT_CommandChangePowerLevel_PowerLevelLabel.AutoSize = true;
            F1_label_RTT_CommandChangePowerLevel_PowerLevelLabel.Font = new Font("Cascadia Code", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            F1_label_RTT_CommandChangePowerLevel_PowerLevelLabel.Location = new Point(3, 42);
            F1_label_RTT_CommandChangePowerLevel_PowerLevelLabel.Name = "F1_label_RTT_CommandChangePowerLevel_PowerLevelLabel";
            F1_label_RTT_CommandChangePowerLevel_PowerLevelLabel.Size = new Size(215, 40);
            F1_label_RTT_CommandChangePowerLevel_PowerLevelLabel.TabIndex = 7;
            F1_label_RTT_CommandChangePowerLevel_PowerLevelLabel.Text = "Power level";
            // 
            // F1_panel_RTT_SetModePanel
            // 
            F1_panel_RTT_SetModePanel.Controls.Add(F1_comboBox_RTT_CommandSetMode_Mode);
            F1_panel_RTT_SetModePanel.Controls.Add(F1_label_RTT_CommandSetMode_ModeLabel);
            F1_panel_RTT_SetModePanel.Enabled = false;
            F1_panel_RTT_SetModePanel.Location = new Point(21, 420);
            F1_panel_RTT_SetModePanel.Name = "F1_panel_RTT_SetModePanel";
            F1_panel_RTT_SetModePanel.Size = new Size(1031, 117);
            F1_panel_RTT_SetModePanel.TabIndex = 9;
            F1_panel_RTT_SetModePanel.Visible = false;
            // 
            // F1_comboBox_RTT_CommandSetMode_Mode
            // 
            F1_comboBox_RTT_CommandSetMode_Mode.DropDownStyle = ComboBoxStyle.DropDownList;
            F1_comboBox_RTT_CommandSetMode_Mode.FormattingEnabled = true;
            F1_comboBox_RTT_CommandSetMode_Mode.Location = new Point(228, 34);
            F1_comboBox_RTT_CommandSetMode_Mode.Name = "F1_comboBox_RTT_CommandSetMode_Mode";
            F1_comboBox_RTT_CommandSetMode_Mode.Size = new Size(302, 48);
            F1_comboBox_RTT_CommandSetMode_Mode.TabIndex = 13;
            // 
            // F1_label_RTT_CommandSetMode_ModeLabel
            // 
            F1_label_RTT_CommandSetMode_ModeLabel.AutoSize = true;
            F1_label_RTT_CommandSetMode_ModeLabel.Font = new Font("Cascadia Code", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            F1_label_RTT_CommandSetMode_ModeLabel.Location = new Point(3, 42);
            F1_label_RTT_CommandSetMode_ModeLabel.Name = "F1_label_RTT_CommandSetMode_ModeLabel";
            F1_label_RTT_CommandSetMode_ModeLabel.Size = new Size(89, 40);
            F1_label_RTT_CommandSetMode_ModeLabel.TabIndex = 7;
            F1_label_RTT_CommandSetMode_ModeLabel.Text = "Mode";
            // 
            // F1_label_RTT_RequestedCommandLabel
            // 
            F1_label_RTT_RequestedCommandLabel.AutoSize = true;
            F1_label_RTT_RequestedCommandLabel.Font = new Font("Cascadia Code", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            F1_label_RTT_RequestedCommandLabel.Location = new Point(21, 155);
            F1_label_RTT_RequestedCommandLabel.Name = "F1_label_RTT_RequestedCommandLabel";
            F1_label_RTT_RequestedCommandLabel.Size = new Size(143, 40);
            F1_label_RTT_RequestedCommandLabel.TabIndex = 5;
            F1_label_RTT_RequestedCommandLabel.Text = "Command";
            // 
            // F1_panel_RTT_AddNode
            // 
            F1_panel_RTT_AddNode.Controls.Add(label_RTT_CommandAddNode_IpAddressLabel);
            F1_panel_RTT_AddNode.Controls.Add(textBox_RTT_CommandAddNode_IpAddress);
            F1_panel_RTT_AddNode.Enabled = false;
            F1_panel_RTT_AddNode.Location = new Point(21, 274);
            F1_panel_RTT_AddNode.Name = "F1_panel_RTT_AddNode";
            F1_panel_RTT_AddNode.Size = new Size(1031, 126);
            F1_panel_RTT_AddNode.TabIndex = 6;
            F1_panel_RTT_AddNode.Visible = false;
            // 
            // label_RTT_CommandAddNode_IpAddressLabel
            // 
            label_RTT_CommandAddNode_IpAddressLabel.AutoSize = true;
            label_RTT_CommandAddNode_IpAddressLabel.Font = new Font("Cascadia Code", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_RTT_CommandAddNode_IpAddressLabel.Location = new Point(6, 42);
            label_RTT_CommandAddNode_IpAddressLabel.Name = "label_RTT_CommandAddNode_IpAddressLabel";
            label_RTT_CommandAddNode_IpAddressLabel.Size = new Size(197, 40);
            label_RTT_CommandAddNode_IpAddressLabel.TabIndex = 7;
            label_RTT_CommandAddNode_IpAddressLabel.Text = "IP Address";
            // 
            // textBox_RTT_CommandAddNode_IpAddress
            // 
            textBox_RTT_CommandAddNode_IpAddress.Location = new Point(231, 42);
            textBox_RTT_CommandAddNode_IpAddress.Name = "textBox_RTT_CommandAddNode_IpAddress";
            textBox_RTT_CommandAddNode_IpAddress.Size = new Size(302, 42);
            textBox_RTT_CommandAddNode_IpAddress.TabIndex = 8;
            // 
            // F1_comboBox_RTT_RequestedCommand
            // 
            F1_comboBox_RTT_RequestedCommand.DropDownStyle = ComboBoxStyle.DropDownList;
            F1_comboBox_RTT_RequestedCommand.FormattingEnabled = true;
            F1_comboBox_RTT_RequestedCommand.Location = new Point(234, 152);
            F1_comboBox_RTT_RequestedCommand.Name = "F1_comboBox_RTT_RequestedCommand";
            F1_comboBox_RTT_RequestedCommand.Size = new Size(412, 48);
            F1_comboBox_RTT_RequestedCommand.TabIndex = 5;
            F1_comboBox_RTT_RequestedCommand.SelectedIndexChanged += F1_comboBox_RTT_RequestedCommand_SelectedIndexChanged;
            // 
            // F1_label_RequestedAppNameLabel
            // 
            F1_label_RequestedAppNameLabel.AutoSize = true;
            F1_label_RequestedAppNameLabel.Font = new Font("Cascadia Code", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            F1_label_RequestedAppNameLabel.Location = new Point(9, 6);
            F1_label_RequestedAppNameLabel.Name = "F1_label_RequestedAppNameLabel";
            F1_label_RequestedAppNameLabel.Size = new Size(215, 40);
            F1_label_RequestedAppNameLabel.TabIndex = 3;
            F1_label_RequestedAppNameLabel.Text = "Application";
            // 
            // F1_comboBox_RequestedAppName
            // 
            F1_comboBox_RequestedAppName.DropDownStyle = ComboBoxStyle.DropDownList;
            F1_comboBox_RequestedAppName.FormattingEnabled = true;
            F1_comboBox_RequestedAppName.Location = new Point(237, 6);
            F1_comboBox_RequestedAppName.Name = "F1_comboBox_RequestedAppName";
            F1_comboBox_RequestedAppName.Size = new Size(418, 48);
            F1_comboBox_RequestedAppName.TabIndex = 0;
            F1_comboBox_RequestedAppName.SelectedIndexChanged += F1_comboBox_RequestedAppName_SelectedIndexChanged;
            // 
            // TimestampMs
            // 
            dataGridViewCellStyle1.Font = new Font("Cascadia Mono", 8.1F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TimestampMs.DefaultCellStyle = dataGridViewCellStyle1;
            TimestampMs.HeaderText = "Timestamp [ms]";
            TimestampMs.MinimumWidth = 12;
            TimestampMs.Name = "TimestampMs";
            TimestampMs.ReadOnly = true;
            TimestampMs.Resizable = DataGridViewTriState.True;
            TimestampMs.SortMode = DataGridViewColumnSortMode.NotSortable;
            TimestampMs.Width = 248;
            // 
            // Direction
            // 
            Direction.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Font = new Font("Cascadia Mono", 8.1F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Direction.DefaultCellStyle = dataGridViewCellStyle2;
            Direction.HeaderText = "Direction";
            Direction.MinimumWidth = 12;
            Direction.Name = "Direction";
            Direction.ReadOnly = true;
            Direction.Resizable = DataGridViewTriState.True;
            Direction.SortMode = DataGridViewColumnSortMode.NotSortable;
            Direction.Width = 185;
            // 
            // Type
            // 
            Type.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            Type.HeaderText = "Type";
            Type.MinimumWidth = 12;
            Type.Name = "Type";
            Type.ReadOnly = true;
            Type.Resizable = DataGridViewTriState.True;
            Type.SortMode = DataGridViewColumnSortMode.NotSortable;
            Type.Width = 95;
            // 
            // Payload
            // 
            Payload.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle3.Font = new Font("Cascadia Mono", 8.1F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Payload.DefaultCellStyle = dataGridViewCellStyle3;
            Payload.HeaderText = "Payload";
            Payload.MinimumWidth = 12;
            Payload.Name = "Payload";
            Payload.ReadOnly = true;
            Payload.Resizable = DataGridViewTriState.True;
            Payload.SortMode = DataGridViewColumnSortMode.NotSortable;
            Payload.Width = 1356;
            // 
            // Protocol
            // 
            Protocol.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridViewCellStyle4.Font = new Font("Cascadia Mono", 8.1F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Protocol.DefaultCellStyle = dataGridViewCellStyle4;
            Protocol.HeaderText = "Protocol";
            Protocol.MinimumWidth = 12;
            Protocol.Name = "Protocol";
            Protocol.ReadOnly = true;
            Protocol.Resizable = DataGridViewTriState.True;
            Protocol.SortMode = DataGridViewColumnSortMode.NotSortable;
            Protocol.Width = 167;
            // 
            // F1_CommunicationMainForm
            // 
            AutoScaleDimensions = new SizeF(18F, 40F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            ClientSize = new Size(3173, 1652);
            Controls.Add(F1_panel_ApplicationPanel);
            Controls.Add(F1_dataGridView_CommView);
            Controls.Add(F1_label_RawDataToBeSentLabel);
            Controls.Add(F1_textBox_RawDataToBeSent);
            Controls.Add(F1_treeView_ProcessedData);
            Controls.Add(F1_tableLayoutPanel_CommMainFormOptionsLayoutControl);
            Controls.Add(F1_button_SendPacket);
            Font = new Font("Cascadia Code", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "F1_CommunicationMainForm";
            Text = "Communication Manager";
            FormClosing += F1_CommunicationMainForm_FormClosing;
            Load += F1_CommunicationMainForm_Load;
            F1_tableLayoutPanel_CommMainFormOptionsLayoutControl.ResumeLayout(false);
            F1_tableLayoutPanel_CommMainFormOptionsLayoutControl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)F1_errorProvider_InputValidation).EndInit();
            ((System.ComponentModel.ISupportInitialize)F1_dataGridView_CommView).EndInit();
            ((System.ComponentModel.ISupportInitialize)F1_errorProvider_BackgroundProcessError).EndInit();
            F1_panel_ApplicationPanel.ResumeLayout(false);
            F1_panel_ApplicationPanel.PerformLayout();
            F1_panel_RTT_ApplicationPanelOptions.ResumeLayout(false);
            F1_panel_RTT_ApplicationPanelOptions.PerformLayout();
            F1_panel_RTT_LockPanel.ResumeLayout(false);
            F1_panel_RTT_LockPanel.PerformLayout();
            F1_panel_RTT_ChangePowerLevelPanel.ResumeLayout(false);
            F1_panel_RTT_ChangePowerLevelPanel.PerformLayout();
            F1_panel_RTT_SetModePanel.ResumeLayout(false);
            F1_panel_RTT_SetModePanel.PerformLayout();
            F1_panel_RTT_AddNode.ResumeLayout(false);
            F1_panel_RTT_AddNode.PerformLayout();
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
        private TreeView F1_treeView_ProcessedData;
        private TextBox F1_textBox_RawDataToBeSent;
        private Label F1_label_RawDataToBeSentLabel;
        private ErrorProvider F1_errorProvider_InputValidation;
        private Label F1_label_BaudRate;
        private ComboBox F1_comboBox_BaudRate;
        private CheckBox F1_checkBox_OnlySimulatedResources;
        private CheckBox F1_checkBox_LogTransmission;
        private DataGridView F1_dataGridView_CommView;
        private ToolTip F1_toolTip_ToolTip;
        private ErrorProvider F1_errorProvider_BackgroundProcessError;
        private System.Windows.Forms.Timer F1_timer_PeriodicUpdate;
        private Panel F1_panel_ApplicationPanel;
        private Label F1_label_RequestedAppNameLabel;
        private ComboBox F1_comboBox_RequestedAppName;
        private Panel F1_panel_RTT_ApplicationPanelOptions;
        private ComboBox F1_comboBox_RTT_RequestedCommand;
        private Panel F1_panel_RTT_AddNode;
        private Label F1_label_RTT_RequestedCommandLabel;
        private Panel F1_panel_RTT_SetModePanel;
        private Label F1_label_RTT_CommandSetMode_ModeLabel;
        private Label label_RTT_CommandAddNode_IpAddressLabel;
        private TextBox textBox_RTT_CommandAddNode_IpAddress;
        private Panel F1_panel_RTT_ChangePowerLevelPanel;
        private Label F1_label_RTT_CommandChangePowerLevel_PowerLevelLabel;
        private Panel F1_panel_RTT_LockPanel;
        private Label F1_label_RTT_CommandLock_LockKeyLabel;
        private TextBox F1_textBox_RTT_CommandLock_LockKey;
        private Button F1_button_RTT_SendCommand;
        private CheckBox F1_checkBox_RTT_PriorityCmd;
        private ComboBox F1_comboBox_RTT_CommandLock_RequestedLockState;
        private Label F1_label_RTT_CommandLock_RequestedLockState;
        private ComboBox F1_comboBox_RTT_CommandChangePowerLevel_PowerLevel;
        private ComboBox F1_comboBox_RTT_CommandSetMode_Mode;
        private Button F1_button_ResetConnectionToResource;
        private Button F1_button_SearchBytes;
        private TextBox F1_textBox_SearchTextBox;
        private Label label_F1_AppName;
        private TextBox F1_textBox_RTT_Temperature;
        private Label F1_label_RTT_TemperatureText;
        private Label F1_label_RTT_TemperatureUnitText;
        private DataGridViewTextBoxColumn TimestampMs;
        private DataGridViewTextBoxColumn Direction;
        private DataGridViewTextBoxColumn Type;
        private DataGridViewTextBoxColumn Payload;
        private DataGridViewTextBoxColumn Protocol;
    }
}