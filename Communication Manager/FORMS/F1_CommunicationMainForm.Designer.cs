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
            F1_label_SearchTextBoxLabel = new Label();
            F1_label_ProtocolLabel = new Label();
            F1_label_ResourceLabel = new Label();
            F1_comboBox_Resources = new ComboBox();
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
            F1_tableLayoutPanel_CommMainFormOptionsLayoutControl.ColumnCount = 3;
            F1_tableLayoutPanel_CommMainFormOptionsLayoutControl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 47.7489777F));
            F1_tableLayoutPanel_CommMainFormOptionsLayoutControl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 52.2510223F));
            F1_tableLayoutPanel_CommMainFormOptionsLayoutControl.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 366F));
            F1_tableLayoutPanel_CommMainFormOptionsLayoutControl.Controls.Add(F1_label_SearchTextBoxLabel, 2, 0);
            F1_tableLayoutPanel_CommMainFormOptionsLayoutControl.Controls.Add(F1_label_ProtocolLabel, 0, 0);
            F1_tableLayoutPanel_CommMainFormOptionsLayoutControl.Controls.Add(F1_label_ResourceLabel, 1, 0);
            F1_tableLayoutPanel_CommMainFormOptionsLayoutControl.Controls.Add(F1_comboBox_Resources, 1, 1);
            F1_tableLayoutPanel_CommMainFormOptionsLayoutControl.Controls.Add(F1_comboBox_Protocols, 0, 1);
            F1_tableLayoutPanel_CommMainFormOptionsLayoutControl.Location = new Point(12, 12);
            F1_tableLayoutPanel_CommMainFormOptionsLayoutControl.Name = "F1_tableLayoutPanel_CommMainFormOptionsLayoutControl";
            F1_tableLayoutPanel_CommMainFormOptionsLayoutControl.RowCount = 2;
            F1_tableLayoutPanel_CommMainFormOptionsLayoutControl.RowStyles.Add(new RowStyle(SizeType.Percent, 45.9677429F));
            F1_tableLayoutPanel_CommMainFormOptionsLayoutControl.RowStyles.Add(new RowStyle(SizeType.Percent, 54.0322571F));
            F1_tableLayoutPanel_CommMainFormOptionsLayoutControl.Size = new Size(1123, 114);
            F1_tableLayoutPanel_CommMainFormOptionsLayoutControl.TabIndex = 1;
            // 
            // F1_label_SearchTextBoxLabel
            // 
            F1_label_SearchTextBoxLabel.AutoSize = true;
            F1_label_SearchTextBoxLabel.Font = new Font("Cascadia Code", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            F1_label_SearchTextBoxLabel.Location = new Point(759, 0);
            F1_label_SearchTextBoxLabel.Name = "F1_label_SearchTextBoxLabel";
            F1_label_SearchTextBoxLabel.Size = new Size(125, 40);
            F1_label_SearchTextBoxLabel.TabIndex = 4;
            F1_label_SearchTextBoxLabel.Text = "Search";
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
            F1_label_ResourceLabel.Location = new Point(364, 0);
            F1_label_ResourceLabel.Name = "F1_label_ResourceLabel";
            F1_label_ResourceLabel.Size = new Size(161, 40);
            F1_label_ResourceLabel.TabIndex = 2;
            F1_label_ResourceLabel.Text = "Resource";
            // 
            // F1_comboBox_Resources
            // 
            F1_comboBox_Resources.FormattingEnabled = true;
            F1_comboBox_Resources.Location = new Point(364, 55);
            F1_comboBox_Resources.Name = "F1_comboBox_Resources";
            F1_comboBox_Resources.Size = new Size(361, 48);
            F1_comboBox_Resources.TabIndex = 3;
            // 
            // F1_button_SendPacket
            // 
            F1_button_SendPacket.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            F1_button_SendPacket.Location = new Point(1141, 164);
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
            F1_listBox_RawData.Size = new Size(1308, 484);
            F1_listBox_RawData.TabIndex = 2;
            // 
            // F1_treeView_ProcessedData
            // 
            F1_treeView_ProcessedData.Location = new Point(12, 709);
            F1_treeView_ProcessedData.Name = "F1_treeView_ProcessedData";
            F1_treeView_ProcessedData.Size = new Size(1308, 421);
            F1_treeView_ProcessedData.TabIndex = 3;
            // 
            // F1_textBox_RawDataToBeSent
            // 
            F1_textBox_RawDataToBeSent.Location = new Point(12, 171);
            F1_textBox_RawDataToBeSent.Name = "F1_textBox_RawDataToBeSent";
            F1_textBox_RawDataToBeSent.Size = new Size(1123, 42);
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
            ClientSize = new Size(1339, 1142);
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
        private Label F1_label_SearchTextBoxLabel;
        private TextBox F1_textBox_RawDataToBeSent;
        private Label F1_label_RawDataToBeSentLabel;
        private ErrorProvider F1_errorProvider_InputValidation;
    }
}