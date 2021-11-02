namespace PelletsBrännarePLC_styr
{
    partial class ModbusPacketCreatorForm
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
            this.btnSendModbusPacket = new System.Windows.Forms.Button();
            this.txtBoxModbusGeneratedPacket = new System.Windows.Forms.TextBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.txtBoxModbusData = new System.Windows.Forms.TextBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.txtBoxModbusDeviceAddress = new System.Windows.Forms.TextBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.txtBoxModbusDataCount = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txtBoxModbusAddress = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.radBtnModbusWrite = new System.Windows.Forms.RadioButton();
            this.radBtnModbusRead = new System.Windows.Forms.RadioButton();
            this.btnGenerateModbusPacket = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblWarningDelegateNotSet = new System.Windows.Forms.Label();
            this.groupBox7.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSendModbusPacket
            // 
            this.btnSendModbusPacket.Location = new System.Drawing.Point(90, 102);
            this.btnSendModbusPacket.Name = "btnSendModbusPacket";
            this.btnSendModbusPacket.Size = new System.Drawing.Size(75, 23);
            this.btnSendModbusPacket.TabIndex = 28;
            this.btnSendModbusPacket.Text = "&Send";
            this.btnSendModbusPacket.UseVisualStyleBackColor = true;
            this.btnSendModbusPacket.Click += new System.EventHandler(this.btnSendModbusPacket_Click);
            // 
            // txtBoxModbusGeneratedPacket
            // 
            this.txtBoxModbusGeneratedPacket.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBoxModbusGeneratedPacket.Location = new System.Drawing.Point(9, 76);
            this.txtBoxModbusGeneratedPacket.Name = "txtBoxModbusGeneratedPacket";
            this.txtBoxModbusGeneratedPacket.Size = new System.Drawing.Size(733, 20);
            this.txtBoxModbusGeneratedPacket.TabIndex = 27;
            // 
            // groupBox7
            // 
            this.groupBox7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox7.Controls.Add(this.txtBoxModbusData);
            this.groupBox7.Location = new System.Drawing.Point(300, 11);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(442, 59);
            this.groupBox7.TabIndex = 26;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "write data contents (multiline)";
            // 
            // txtBoxModbusData
            // 
            this.txtBoxModbusData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBoxModbusData.Enabled = false;
            this.txtBoxModbusData.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxModbusData.Location = new System.Drawing.Point(6, 15);
            this.txtBoxModbusData.MaxLength = 64;
            this.txtBoxModbusData.Multiline = true;
            this.txtBoxModbusData.Name = "txtBoxModbusData";
            this.txtBoxModbusData.Size = new System.Drawing.Size(426, 35);
            this.txtBoxModbusData.TabIndex = 22;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.txtBoxModbusDeviceAddress);
            this.groupBox8.Location = new System.Drawing.Point(9, 11);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(54, 59);
            this.groupBox8.TabIndex = 25;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "device addr:";
            // 
            // txtBoxModbusDeviceAddress
            // 
            this.txtBoxModbusDeviceAddress.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxModbusDeviceAddress.Location = new System.Drawing.Point(14, 30);
            this.txtBoxModbusDeviceAddress.MaxLength = 2;
            this.txtBoxModbusDeviceAddress.Name = "txtBoxModbusDeviceAddress";
            this.txtBoxModbusDeviceAddress.Size = new System.Drawing.Size(24, 22);
            this.txtBoxModbusDeviceAddress.TabIndex = 24;
            this.txtBoxModbusDeviceAddress.Text = "01";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.txtBoxModbusDataCount);
            this.groupBox6.Location = new System.Drawing.Point(240, 11);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(54, 58);
            this.groupBox6.TabIndex = 25;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "data count";
            // 
            // txtBoxModbusDataCount
            // 
            this.txtBoxModbusDataCount.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxModbusDataCount.Location = new System.Drawing.Point(14, 30);
            this.txtBoxModbusDataCount.MaxLength = 2;
            this.txtBoxModbusDataCount.Name = "txtBoxModbusDataCount";
            this.txtBoxModbusDataCount.Size = new System.Drawing.Size(24, 22);
            this.txtBoxModbusDataCount.TabIndex = 24;
            this.txtBoxModbusDataCount.Text = "01";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.txtBoxModbusAddress);
            this.groupBox5.Location = new System.Drawing.Point(144, 11);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(90, 59);
            this.groupBox5.TabIndex = 24;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "reg addr:";
            // 
            // txtBoxModbusAddress
            // 
            this.txtBoxModbusAddress.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxModbusAddress.Location = new System.Drawing.Point(6, 19);
            this.txtBoxModbusAddress.MaxLength = 8;
            this.txtBoxModbusAddress.Name = "txtBoxModbusAddress";
            this.txtBoxModbusAddress.Size = new System.Drawing.Size(75, 22);
            this.txtBoxModbusAddress.TabIndex = 22;
            this.txtBoxModbusAddress.Text = "00000000";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.radBtnModbusWrite);
            this.groupBox3.Controls.Add(this.radBtnModbusRead);
            this.groupBox3.Location = new System.Drawing.Point(69, 11);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(69, 59);
            this.groupBox3.TabIndex = 20;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "read/write";
            // 
            // radBtnModbusWrite
            // 
            this.radBtnModbusWrite.AutoSize = true;
            this.radBtnModbusWrite.Location = new System.Drawing.Point(16, 36);
            this.radBtnModbusWrite.Name = "radBtnModbusWrite";
            this.radBtnModbusWrite.Size = new System.Drawing.Size(47, 17);
            this.radBtnModbusWrite.TabIndex = 20;
            this.radBtnModbusWrite.Text = "write";
            this.radBtnModbusWrite.UseVisualStyleBackColor = true;
            // 
            // radBtnModbusRead
            // 
            this.radBtnModbusRead.AutoSize = true;
            this.radBtnModbusRead.Checked = true;
            this.radBtnModbusRead.Location = new System.Drawing.Point(16, 15);
            this.radBtnModbusRead.Name = "radBtnModbusRead";
            this.radBtnModbusRead.Size = new System.Drawing.Size(46, 17);
            this.radBtnModbusRead.TabIndex = 19;
            this.radBtnModbusRead.TabStop = true;
            this.radBtnModbusRead.Text = "read";
            this.radBtnModbusRead.UseVisualStyleBackColor = true;
            this.radBtnModbusRead.CheckedChanged += new System.EventHandler(this.radBtnModbusReadWrite_CheckedChanged);
            // 
            // btnGenerateModbusPacket
            // 
            this.btnGenerateModbusPacket.Location = new System.Drawing.Point(9, 102);
            this.btnGenerateModbusPacket.Name = "btnGenerateModbusPacket";
            this.btnGenerateModbusPacket.Size = new System.Drawing.Size(75, 23);
            this.btnGenerateModbusPacket.TabIndex = 27;
            this.btnGenerateModbusPacket.Text = "&Generate";
            this.btnGenerateModbusPacket.UseVisualStyleBackColor = true;
            this.btnGenerateModbusPacket.Click += new System.EventHandler(this.btnGenerateModbusPacket_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(667, 102);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 29;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblWarningDelegateNotSet
            // 
            this.lblWarningDelegateNotSet.AutoSize = true;
            this.lblWarningDelegateNotSet.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWarningDelegateNotSet.ForeColor = System.Drawing.Color.Red;
            this.lblWarningDelegateNotSet.Location = new System.Drawing.Point(171, 105);
            this.lblWarningDelegateNotSet.Name = "lblWarningDelegateNotSet";
            this.lblWarningDelegateNotSet.Size = new System.Drawing.Size(468, 18);
            this.lblWarningDelegateNotSet.TabIndex = 30;
            this.lblWarningDelegateNotSet.Text = "\"The SendPacket - Action Delegate is not set!\"";
            // 
            // ModbusPacketCreatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(754, 132);
            this.Controls.Add(this.lblWarningDelegateNotSet);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtBoxModbusGeneratedPacket);
            this.Controls.Add(this.btnSendModbusPacket);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.btnGenerateModbusPacket);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Name = "ModbusPacketCreatorForm";
            this.Text = "Modbus Packet Creating";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ModbusPacketCreatorForm_FormClosing);
            this.VisibleChanged += new System.EventHandler(this.ModbusPacketCreatorForm_VisibleChanged);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSendModbusPacket;
        private System.Windows.Forms.TextBox txtBoxModbusGeneratedPacket;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.TextBox txtBoxModbusData;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.TextBox txtBoxModbusDeviceAddress;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox txtBoxModbusDataCount;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox txtBoxModbusAddress;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton radBtnModbusWrite;
        private System.Windows.Forms.RadioButton radBtnModbusRead;
        private System.Windows.Forms.Button btnGenerateModbusPacket;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblWarningDelegateNotSet;
    }
}