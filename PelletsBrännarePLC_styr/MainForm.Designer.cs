namespace PelletsBrännarePLC_styr
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btnTcpClientConnect = new System.Windows.Forms.Button();
            this.btnTcpClientDisconnect = new System.Windows.Forms.Button();
            this.rtxtLog = new System.Windows.Forms.RichTextBox();
            this.btnJustGetDisplay = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTcpClient_Ip = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTcpClient_Port = new System.Windows.Forms.TextBox();
            this.grpBoxM3remote = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.rtxtM3_SLOUT_values = new System.Windows.Forms.RichTextBox();
            this.btnM3get_SLOUT_41_48 = new System.Windows.Forms.Button();
            this.btnM3get_SLOUT = new System.Windows.Forms.Button();
            this.btnModbusRawPacketSender = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnPLC_btnESC = new System.Windows.Forms.Button();
            this.imgLstM3 = new System.Windows.Forms.ImageList(this.components);
            this.btnPLC_btnA = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnM3_btnEscOK = new System.Windows.Forms.Button();
            this.btnPLC_btnMinus = new System.Windows.Forms.Button();
            this.btnPLC_btnB = new System.Windows.Forms.Button();
            this.btnPLC_btnPlus = new System.Windows.Forms.Button();
            this.btnStopPLC = new System.Windows.Forms.Button();
            this.btnStartPLC = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.btnPLC_btnOK = new System.Windows.Forms.Button();
            this.textLcd = new DotMatrix.DotMatrixCell();
            this.numUpDownDisplayRefreshRate = new System.Windows.Forms.NumericUpDown();
            this.chkBoxDisplayAutoGet = new System.Windows.Forms.CheckBox();
            this.btnStopServer = new System.Windows.Forms.Button();
            this.btnStartServer = new System.Windows.Forms.Button();
            this.txtTcpServer_Port = new System.Windows.Forms.TextBox();
            this.btnTcpSend2 = new System.Windows.Forms.Button();
            this.btnTcpSend = new System.Windows.Forms.Button();
            this.txtBoxTcpRawSend2 = new System.Windows.Forms.TextBox();
            this.txtBoxTcpRawSend = new System.Windows.Forms.TextBox();
            this.panelDestinationSettings = new System.Windows.Forms.Panel();
            this.btnClearLogOutput = new System.Windows.Forms.Button();
            this.chkBoxAutoclearBeforeSend = new System.Windows.Forms.CheckBox();
            this.btnFont = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSerialPortRefreshPorts = new System.Windows.Forms.Button();
            this.cmbSerialPorts = new System.Windows.Forms.ComboBox();
            this.btnSerialPortDisconnect = new System.Windows.Forms.Button();
            this.btnSerialPortConnect = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkBoxShowModbusReceiveInAscii = new System.Windows.Forms.CheckBox();
            this.grpBoxTcpClientSend = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.panelTcpServerSettings = new System.Windows.Forms.Panel();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTcpServerMessageEnd_ID = new System.Windows.Forms.TextBox();
            this.txtTcpServerMessageStart_ID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txtTcpServerToSend = new System.Windows.Forms.TextBox();
            this.btnTcpServerSend = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.rtxtLCD = new System.Windows.Forms.RichTextBox();
            this.chkLogDontEmptyScreen = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.grpBoxM3remote.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownDisplayRefreshRate)).BeginInit();
            this.panelDestinationSettings.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.grpBoxTcpClientSend.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.panelTcpServerSettings.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnTcpClientConnect
            // 
            this.btnTcpClientConnect.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnTcpClientConnect.Location = new System.Drawing.Point(11, 14);
            this.btnTcpClientConnect.Name = "btnTcpClientConnect";
            this.btnTcpClientConnect.Size = new System.Drawing.Size(72, 23);
            this.btnTcpClientConnect.TabIndex = 0;
            this.btnTcpClientConnect.Text = "Connect";
            this.btnTcpClientConnect.UseVisualStyleBackColor = true;
            this.btnTcpClientConnect.Click += new System.EventHandler(this.btnTcpClientConnect_Click);
            // 
            // btnTcpClientDisconnect
            // 
            this.btnTcpClientDisconnect.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnTcpClientDisconnect.Location = new System.Drawing.Point(11, 37);
            this.btnTcpClientDisconnect.Name = "btnTcpClientDisconnect";
            this.btnTcpClientDisconnect.Size = new System.Drawing.Size(72, 23);
            this.btnTcpClientDisconnect.TabIndex = 1;
            this.btnTcpClientDisconnect.Text = "Disconnect";
            this.btnTcpClientDisconnect.UseVisualStyleBackColor = true;
            this.btnTcpClientDisconnect.Click += new System.EventHandler(this.btnTcpClientDisconnect_Click);
            // 
            // rtxtLog
            // 
            this.rtxtLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtxtLog.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxtLog.Location = new System.Drawing.Point(3, 30);
            this.rtxtLog.Name = "rtxtLog";
            this.rtxtLog.Size = new System.Drawing.Size(1002, 263);
            this.rtxtLog.TabIndex = 2;
            this.rtxtLog.Text = "";
            // 
            // btnJustGetDisplay
            // 
            this.btnJustGetDisplay.Location = new System.Drawing.Point(79, -2);
            this.btnJustGetDisplay.Name = "btnJustGetDisplay";
            this.btnJustGetDisplay.Size = new System.Drawing.Size(105, 20);
            this.btnJustGetDisplay.TabIndex = 6;
            this.btnJustGetDisplay.Text = "refresh display";
            this.btnJustGetDisplay.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnJustGetDisplay.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnJustGetDisplay.UseVisualStyleBackColor = true;
            this.btnJustGetDisplay.Click += new System.EventHandler(this.btnJustGetDisplay_Click);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "addr:";
            // 
            // txtTcpClient_Ip
            // 
            this.txtTcpClient_Ip.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtTcpClient_Ip.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTcpClient_Ip.Font = new System.Drawing.Font("Courier New", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTcpClient_Ip.Location = new System.Drawing.Point(40, 2);
            this.txtTcpClient_Ip.MaxLength = 15;
            this.txtTcpClient_Ip.Name = "txtTcpClient_Ip";
            this.txtTcpClient_Ip.Size = new System.Drawing.Size(140, 17);
            this.txtTcpClient_Ip.TabIndex = 8;
            this.txtTcpClient_Ip.Text = "192.168.000.002";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Port:";
            // 
            // txtTcpClient_Port
            // 
            this.txtTcpClient_Port.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtTcpClient_Port.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTcpClient_Port.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTcpClient_Port.Location = new System.Drawing.Point(40, 23);
            this.txtTcpClient_Port.MaxLength = 5;
            this.txtTcpClient_Port.Name = "txtTcpClient_Port";
            this.txtTcpClient_Port.Size = new System.Drawing.Size(45, 15);
            this.txtTcpClient_Port.TabIndex = 10;
            this.txtTcpClient_Port.Text = "2000";
            // 
            // grpBoxM3remote
            // 
            this.grpBoxM3remote.Controls.Add(this.button1);
            this.grpBoxM3remote.Controls.Add(this.rtxtM3_SLOUT_values);
            this.grpBoxM3remote.Controls.Add(this.btnM3get_SLOUT_41_48);
            this.grpBoxM3remote.Controls.Add(this.btnM3get_SLOUT);
            this.grpBoxM3remote.Controls.Add(this.btnModbusRawPacketSender);
            this.grpBoxM3remote.Controls.Add(this.groupBox3);
            this.grpBoxM3remote.Location = new System.Drawing.Point(3, 73);
            this.grpBoxM3remote.Name = "grpBoxM3remote";
            this.grpBoxM3remote.Size = new System.Drawing.Size(778, 345);
            this.grpBoxM3remote.TabIndex = 16;
            this.grpBoxM3remote.TabStop = false;
            this.grpBoxM3remote.Text = "M3 remote control";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(616, 195);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 38;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // rtxtM3_SLOUT_values
            // 
            this.rtxtM3_SLOUT_values.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtxtM3_SLOUT_values.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxtM3_SLOUT_values.Location = new System.Drawing.Point(697, 16);
            this.rtxtM3_SLOUT_values.Name = "rtxtM3_SLOUT_values";
            this.rtxtM3_SLOUT_values.Size = new System.Drawing.Size(75, 320);
            this.rtxtM3_SLOUT_values.TabIndex = 35;
            this.rtxtM3_SLOUT_values.Text = "";
            // 
            // btnM3get_SLOUT_41_48
            // 
            this.btnM3get_SLOUT_41_48.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnM3get_SLOUT_41_48.Location = new System.Drawing.Point(616, 139);
            this.btnM3get_SLOUT_41_48.Name = "btnM3get_SLOUT_41_48";
            this.btnM3get_SLOUT_41_48.Size = new System.Drawing.Size(75, 36);
            this.btnM3get_SLOUT_41_48.TabIndex = 34;
            this.btnM3get_SLOUT_41_48.Text = "Get SLOUT 41-48";
            this.btnM3get_SLOUT_41_48.UseVisualStyleBackColor = true;
            this.btnM3get_SLOUT_41_48.Click += new System.EventHandler(this.BtnM3get_SLOUT_41_48Click);
            // 
            // btnM3get_SLOUT
            // 
            this.btnM3get_SLOUT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnM3get_SLOUT.Location = new System.Drawing.Point(616, 86);
            this.btnM3get_SLOUT.Name = "btnM3get_SLOUT";
            this.btnM3get_SLOUT.Size = new System.Drawing.Size(75, 36);
            this.btnM3get_SLOUT.TabIndex = 34;
            this.btnM3get_SLOUT.Text = "Get SLOUT 25-32";
            this.btnM3get_SLOUT.UseVisualStyleBackColor = true;
            this.btnM3get_SLOUT.Click += new System.EventHandler(this.btnM3get_SLOUT_Click);
            // 
            // btnModbusRawPacketSender
            // 
            this.btnModbusRawPacketSender.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnModbusRawPacketSender.Location = new System.Drawing.Point(616, 16);
            this.btnModbusRawPacketSender.Name = "btnModbusRawPacketSender";
            this.btnModbusRawPacketSender.Size = new System.Drawing.Size(75, 54);
            this.btnModbusRawPacketSender.TabIndex = 33;
            this.btnModbusRawPacketSender.Text = "Modbus Raw Packet Sender";
            this.btnModbusRawPacketSender.UseVisualStyleBackColor = true;
            this.btnModbusRawPacketSender.Click += new System.EventHandler(this.btnModbusRawPacketSender_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.chkLogDontEmptyScreen);
            this.groupBox3.Controls.Add(this.rtxtLCD);
            this.groupBox3.Controls.Add(this.panel2);
            this.groupBox3.Controls.Add(this.textLcd);
            this.groupBox3.Controls.Add(this.numUpDownDisplayRefreshRate);
            this.groupBox3.Controls.Add(this.btnJustGetDisplay);
            this.groupBox3.Controls.Add(this.chkBoxDisplayAutoGet);
            this.groupBox3.Location = new System.Drawing.Point(8, 16);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(602, 320);
            this.groupBox3.TabIndex = 32;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Front Panel:";
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.btnPLC_btnESC);
            this.panel2.Controls.Add(this.btnPLC_btnA);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.btnM3_btnEscOK);
            this.panel2.Controls.Add(this.btnPLC_btnMinus);
            this.panel2.Controls.Add(this.btnPLC_btnB);
            this.panel2.Controls.Add(this.btnPLC_btnPlus);
            this.panel2.Controls.Add(this.btnStopPLC);
            this.panel2.Controls.Add(this.btnStartPLC);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.btnPLC_btnOK);
            this.panel2.Location = new System.Drawing.Point(6, 256);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(585, 58);
            this.panel2.TabIndex = 33;
            // 
            // btnPLC_btnESC
            // 
            this.btnPLC_btnESC.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnPLC_btnESC.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPLC_btnESC.BackgroundImage")));
            this.btnPLC_btnESC.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPLC_btnESC.FlatAppearance.BorderSize = 0;
            this.btnPLC_btnESC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPLC_btnESC.Font = new System.Drawing.Font("Courier New", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPLC_btnESC.ImageIndex = 4;
            this.btnPLC_btnESC.ImageList = this.imgLstM3;
            this.btnPLC_btnESC.Location = new System.Drawing.Point(89, 16);
            this.btnPLC_btnESC.Name = "btnPLC_btnESC";
            this.btnPLC_btnESC.Size = new System.Drawing.Size(42, 39);
            this.btnPLC_btnESC.TabIndex = 29;
            this.btnPLC_btnESC.UseVisualStyleBackColor = true;
            // 
            // imgLstM3
            // 
            this.imgLstM3.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgLstM3.ImageStream")));
            this.imgLstM3.TransparentColor = System.Drawing.Color.White;
            this.imgLstM3.Images.SetKeyName(0, "button1_up");
            this.imgLstM3.Images.SetKeyName(1, "button1_down");
            this.imgLstM3.Images.SetKeyName(2, "button2_up");
            this.imgLstM3.Images.SetKeyName(3, "button2_down");
            this.imgLstM3.Images.SetKeyName(4, "button3_up");
            this.imgLstM3.Images.SetKeyName(5, "button3_down");
            this.imgLstM3.Images.SetKeyName(6, "button4_up");
            this.imgLstM3.Images.SetKeyName(7, "button4_down");
            this.imgLstM3.Images.SetKeyName(8, "button5_up");
            this.imgLstM3.Images.SetKeyName(9, "button5_down");
            this.imgLstM3.Images.SetKeyName(10, "button6_up");
            this.imgLstM3.Images.SetKeyName(11, "button6_down");
            this.imgLstM3.Images.SetKeyName(12, "interbutton5.png");
            // 
            // btnPLC_btnA
            // 
            this.btnPLC_btnA.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPLC_btnA.BackgroundImage")));
            this.btnPLC_btnA.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPLC_btnA.FlatAppearance.BorderSize = 0;
            this.btnPLC_btnA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPLC_btnA.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnPLC_btnA.ImageIndex = 0;
            this.btnPLC_btnA.ImageList = this.imgLstM3;
            this.btnPLC_btnA.Location = new System.Drawing.Point(6, 16);
            this.btnPLC_btnA.Name = "btnPLC_btnA";
            this.btnPLC_btnA.Size = new System.Drawing.Size(42, 39);
            this.btnPLC_btnA.TabIndex = 29;
            this.btnPLC_btnA.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(96, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 16);
            this.label7.TabIndex = 38;
            this.label7.Text = "ESC";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(62, 1);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 16);
            this.label6.TabIndex = 36;
            this.label6.Text = "B";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 16);
            this.label1.TabIndex = 35;
            this.label1.Text = "A";
            // 
            // btnM3_btnEscOK
            // 
            this.btnM3_btnEscOK.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnM3_btnEscOK.AutoSize = true;
            this.btnM3_btnEscOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnM3_btnEscOK.Location = new System.Drawing.Point(334, 0);
            this.btnM3_btnEscOK.Name = "btnM3_btnEscOK";
            this.btnM3_btnEscOK.Size = new System.Drawing.Size(49, 32);
            this.btnM3_btnEscOK.TabIndex = 34;
            this.btnM3_btnEscOK.Text = "esc+ok";
            this.btnM3_btnEscOK.UseVisualStyleBackColor = true;
            // 
            // btnPLC_btnMinus
            // 
            this.btnPLC_btnMinus.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnPLC_btnMinus.FlatAppearance.BorderSize = 0;
            this.btnPLC_btnMinus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPLC_btnMinus.Font = new System.Drawing.Font("Arial", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPLC_btnMinus.ImageIndex = 6;
            this.btnPLC_btnMinus.ImageList = this.imgLstM3;
            this.btnPLC_btnMinus.Location = new System.Drawing.Point(130, 16);
            this.btnPLC_btnMinus.Name = "btnPLC_btnMinus";
            this.btnPLC_btnMinus.Size = new System.Drawing.Size(42, 39);
            this.btnPLC_btnMinus.TabIndex = 29;
            this.btnPLC_btnMinus.UseVisualStyleBackColor = true;
            // 
            // btnPLC_btnB
            // 
            this.btnPLC_btnB.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPLC_btnB.BackgroundImage")));
            this.btnPLC_btnB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPLC_btnB.FlatAppearance.BorderSize = 0;
            this.btnPLC_btnB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPLC_btnB.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnPLC_btnB.ImageIndex = 2;
            this.btnPLC_btnB.ImageList = this.imgLstM3;
            this.btnPLC_btnB.Location = new System.Drawing.Point(47, 16);
            this.btnPLC_btnB.Name = "btnPLC_btnB";
            this.btnPLC_btnB.Size = new System.Drawing.Size(42, 39);
            this.btnPLC_btnB.TabIndex = 29;
            this.btnPLC_btnB.UseVisualStyleBackColor = true;
            // 
            // btnPLC_btnPlus
            // 
            this.btnPLC_btnPlus.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnPLC_btnPlus.BackColor = System.Drawing.Color.Transparent;
            this.btnPLC_btnPlus.FlatAppearance.BorderSize = 0;
            this.btnPLC_btnPlus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPLC_btnPlus.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPLC_btnPlus.ImageIndex = 8;
            this.btnPLC_btnPlus.ImageList = this.imgLstM3;
            this.btnPLC_btnPlus.Location = new System.Drawing.Point(171, 16);
            this.btnPLC_btnPlus.Name = "btnPLC_btnPlus";
            this.btnPLC_btnPlus.Size = new System.Drawing.Size(42, 39);
            this.btnPLC_btnPlus.TabIndex = 29;
            this.btnPLC_btnPlus.UseVisualStyleBackColor = false;
            // 
            // btnStopPLC
            // 
            this.btnStopPLC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStopPLC.Location = new System.Drawing.Point(516, 0);
            this.btnStopPLC.Name = "btnStopPLC";
            this.btnStopPLC.Size = new System.Drawing.Size(66, 32);
            this.btnStopPLC.TabIndex = 30;
            this.btnStopPLC.Text = "Stop PLC";
            this.btnStopPLC.UseVisualStyleBackColor = true;
            this.btnStopPLC.Click += new System.EventHandler(this.btnStopPLC_Click);
            // 
            // btnStartPLC
            // 
            this.btnStartPLC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStartPLC.Location = new System.Drawing.Point(444, 0);
            this.btnStartPLC.Name = "btnStartPLC";
            this.btnStartPLC.Size = new System.Drawing.Size(66, 32);
            this.btnStartPLC.TabIndex = 30;
            this.btnStartPLC.Text = "Start PLC";
            this.btnStartPLC.UseVisualStyleBackColor = true;
            this.btnStartPLC.Click += new System.EventHandler(this.btnStartPLC_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(142, -12);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(26, 36);
            this.label8.TabIndex = 39;
            this.label8.Text = "-";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(182, -4);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(26, 27);
            this.label9.TabIndex = 40;
            this.label9.Text = "+";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button2.ImageKey = "interbutton5.png";
            this.button2.ImageList = this.imgLstM3;
            this.button2.Location = new System.Drawing.Point(212, 21);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(42, 39);
            this.button2.TabIndex = 41;
            this.button2.UseVisualStyleBackColor = false;
            // 
            // btnPLC_btnOK
            // 
            this.btnPLC_btnOK.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnPLC_btnOK.AutoSize = true;
            this.btnPLC_btnOK.BackColor = System.Drawing.Color.Transparent;
            this.btnPLC_btnOK.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnPLC_btnOK.FlatAppearance.BorderSize = 0;
            this.btnPLC_btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPLC_btnOK.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPLC_btnOK.ImageIndex = 10;
            this.btnPLC_btnOK.ImageList = this.imgLstM3;
            this.btnPLC_btnOK.Location = new System.Drawing.Point(250, 13);
            this.btnPLC_btnOK.Name = "btnPLC_btnOK";
            this.btnPLC_btnOK.Size = new System.Drawing.Size(48, 45);
            this.btnPLC_btnOK.TabIndex = 29;
            this.btnPLC_btnOK.UseVisualStyleBackColor = false;
            // 
            // textLcd
            // 
            this.textLcd.AutoSize = true;
            this.textLcd.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.textLcd.BackColor = System.Drawing.Color.GreenYellow;
            this.textLcd.BorderMargin = 6;
            this.textLcd.CharacterHorizontalDistance = 3;
            this.textLcd.CharacterVerticalDistance = 3;
            this.textLcd.Location = new System.Drawing.Point(6, 25);
            this.textLcd.Name = "textLcd";
            this.textLcd.PixelBorderAsRectangle = false;
            this.textLcd.PixelBorderColor = System.Drawing.Color.GreenYellow;
            this.textLcd.PixelBorderSize = 0.5F;
            this.textLcd.PixelBorderVisible = false;
            this.textLcd.PixelHeight = 3;
            this.textLcd.PixelTurnOFFColor = System.Drawing.Color.GreenYellow;
            this.textLcd.PixelTurnONColor = System.Drawing.Color.Black;
            this.textLcd.PixelWidth = 3;
            this.textLcd.PrintCGROM = false;
            this.textLcd.Size = new System.Drawing.Size(333, 117);
            this.textLcd.TabIndex = 20;
            this.textLcd.TextColumnCount = 18;
            this.textLcd.TextLines = new string[] {
        "123456789012345678",
        "ABCDEFGHIJKLMNOPQR",
        "STUVWXYZÅÄÖ!\"#¤%&/",
        "(){}[]$£@\\´?=µåäö"};
            this.textLcd.TextRowCount = 4;
            // 
            // numUpDownDisplayRefreshRate
            // 
            this.numUpDownDisplayRefreshRate.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numUpDownDisplayRefreshRate.Location = new System.Drawing.Point(275, -1);
            this.numUpDownDisplayRefreshRate.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numUpDownDisplayRefreshRate.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUpDownDisplayRefreshRate.Name = "numUpDownDisplayRefreshRate";
            this.numUpDownDisplayRefreshRate.Size = new System.Drawing.Size(50, 20);
            this.numUpDownDisplayRefreshRate.TabIndex = 31;
            this.numUpDownDisplayRefreshRate.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // chkBoxDisplayAutoGet
            // 
            this.chkBoxDisplayAutoGet.AutoSize = true;
            this.chkBoxDisplayAutoGet.Location = new System.Drawing.Point(200, 1);
            this.chkBoxDisplayAutoGet.Name = "chkBoxDisplayAutoGet";
            this.chkBoxDisplayAutoGet.Size = new System.Drawing.Size(79, 17);
            this.chkBoxDisplayAutoGet.TabIndex = 28;
            this.chkBoxDisplayAutoGet.Text = "autorefresh";
            this.chkBoxDisplayAutoGet.UseVisualStyleBackColor = true;
            this.chkBoxDisplayAutoGet.CheckedChanged += new System.EventHandler(this.chkBoxDisplayAutoGet_CheckedChanged);
            // 
            // btnStopServer
            // 
            this.btnStopServer.Location = new System.Drawing.Point(6, 53);
            this.btnStopServer.Name = "btnStopServer";
            this.btnStopServer.Size = new System.Drawing.Size(45, 23);
            this.btnStopServer.TabIndex = 36;
            this.btnStopServer.Text = "stop";
            this.btnStopServer.UseVisualStyleBackColor = true;
            this.btnStopServer.Click += new System.EventHandler(this.btnStopServer_Click);
            // 
            // btnStartServer
            // 
            this.btnStartServer.Location = new System.Drawing.Point(6, 21);
            this.btnStartServer.Name = "btnStartServer";
            this.btnStartServer.Size = new System.Drawing.Size(45, 23);
            this.btnStartServer.TabIndex = 36;
            this.btnStartServer.Text = "start";
            this.btnStartServer.UseVisualStyleBackColor = true;
            this.btnStartServer.Click += new System.EventHandler(this.btnStartServer_Click);
            // 
            // txtTcpServer_Port
            // 
            this.txtTcpServer_Port.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTcpServer_Port.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTcpServer_Port.Location = new System.Drawing.Point(6, 19);
            this.txtTcpServer_Port.MaxLength = 5;
            this.txtTcpServer_Port.Name = "txtTcpServer_Port";
            this.txtTcpServer_Port.Size = new System.Drawing.Size(48, 15);
            this.txtTcpServer_Port.TabIndex = 10;
            this.txtTcpServer_Port.Text = "2020";
            // 
            // btnTcpSend2
            // 
            this.btnTcpSend2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTcpSend2.Location = new System.Drawing.Point(281, 35);
            this.btnTcpSend2.Name = "btnTcpSend2";
            this.btnTcpSend2.Size = new System.Drawing.Size(75, 23);
            this.btnTcpSend2.TabIndex = 21;
            this.btnTcpSend2.Text = "tcpSend";
            this.btnTcpSend2.UseVisualStyleBackColor = true;
            this.btnTcpSend2.Click += new System.EventHandler(this.btnTcpSend2_Click);
            // 
            // btnTcpSend
            // 
            this.btnTcpSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTcpSend.Location = new System.Drawing.Point(281, 12);
            this.btnTcpSend.Name = "btnTcpSend";
            this.btnTcpSend.Size = new System.Drawing.Size(75, 23);
            this.btnTcpSend.TabIndex = 21;
            this.btnTcpSend.Text = "tcpSend";
            this.btnTcpSend.UseVisualStyleBackColor = true;
            this.btnTcpSend.Click += new System.EventHandler(this.btnTcpSend_Click);
            // 
            // txtBoxTcpRawSend2
            // 
            this.txtBoxTcpRawSend2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBoxTcpRawSend2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBoxTcpRawSend2.Font = new System.Drawing.Font("Courier New", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxTcpRawSend2.Location = new System.Drawing.Point(6, 38);
            this.txtBoxTcpRawSend2.Name = "txtBoxTcpRawSend2";
            this.txtBoxTcpRawSend2.Size = new System.Drawing.Size(269, 17);
            this.txtBoxTcpRawSend2.TabIndex = 18;
            this.txtBoxTcpRawSend2.Text = ":011000006F4E010031\\r\\n";
            // 
            // txtBoxTcpRawSend
            // 
            this.txtBoxTcpRawSend.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBoxTcpRawSend.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBoxTcpRawSend.Font = new System.Drawing.Font("Courier New", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxTcpRawSend.Location = new System.Drawing.Point(6, 15);
            this.txtBoxTcpRawSend.Name = "txtBoxTcpRawSend";
            this.txtBoxTcpRawSend.Size = new System.Drawing.Size(269, 17);
            this.txtBoxTcpRawSend.TabIndex = 18;
            this.txtBoxTcpRawSend.Text = ":0110";
            // 
            // panelDestinationSettings
            // 
            this.panelDestinationSettings.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.panelDestinationSettings.Controls.Add(this.label3);
            this.panelDestinationSettings.Controls.Add(this.txtTcpClient_Ip);
            this.panelDestinationSettings.Controls.Add(this.txtTcpClient_Port);
            this.panelDestinationSettings.Controls.Add(this.label4);
            this.panelDestinationSettings.Location = new System.Drawing.Point(89, 9);
            this.panelDestinationSettings.Name = "panelDestinationSettings";
            this.panelDestinationSettings.Size = new System.Drawing.Size(182, 48);
            this.panelDestinationSettings.TabIndex = 12;
            // 
            // btnClearLogOutput
            // 
            this.btnClearLogOutput.Location = new System.Drawing.Point(3, 3);
            this.btnClearLogOutput.Name = "btnClearLogOutput";
            this.btnClearLogOutput.Size = new System.Drawing.Size(97, 23);
            this.btnClearLogOutput.TabIndex = 13;
            this.btnClearLogOutput.Text = "Clear Log Output";
            this.btnClearLogOutput.UseVisualStyleBackColor = true;
            this.btnClearLogOutput.Click += new System.EventHandler(this.btnClearLogOutput_Click);
            // 
            // chkBoxAutoclearBeforeSend
            // 
            this.chkBoxAutoclearBeforeSend.AutoSize = true;
            this.chkBoxAutoclearBeforeSend.Checked = true;
            this.chkBoxAutoclearBeforeSend.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBoxAutoclearBeforeSend.Location = new System.Drawing.Point(106, 7);
            this.chkBoxAutoclearBeforeSend.Name = "chkBoxAutoclearBeforeSend";
            this.chkBoxAutoclearBeforeSend.Size = new System.Drawing.Size(154, 17);
            this.chkBoxAutoclearBeforeSend.TabIndex = 14;
            this.chkBoxAutoclearBeforeSend.Text = "Autoclear before send data";
            this.chkBoxAutoclearBeforeSend.UseVisualStyleBackColor = true;
            this.chkBoxAutoclearBeforeSend.CheckedChanged += new System.EventHandler(this.chkBoxAutoclearBeforeSend_CheckedChanged);
            // 
            // btnFont
            // 
            this.btnFont.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFont.Location = new System.Drawing.Point(905, 3);
            this.btnFont.Name = "btnFont";
            this.btnFont.Size = new System.Drawing.Size(100, 23);
            this.btnFont.TabIndex = 15;
            this.btnFont.Text = "Change Font";
            this.btnFont.UseVisualStyleBackColor = true;
            this.btnFont.Click += new System.EventHandler(this.btnFont_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnTcpClientConnect);
            this.groupBox1.Controls.Add(this.btnTcpClientDisconnect);
            this.groupBox1.Controls.Add(this.panelDestinationSettings);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(276, 64);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "TCP client:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSerialPortRefreshPorts);
            this.groupBox2.Controls.Add(this.cmbSerialPorts);
            this.groupBox2.Controls.Add(this.btnSerialPortDisconnect);
            this.groupBox2.Controls.Add(this.btnSerialPortConnect);
            this.groupBox2.Location = new System.Drawing.Point(286, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(188, 64);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "M3 soft virtual com0com:";
            // 
            // btnSerialPortRefreshPorts
            // 
            this.btnSerialPortRefreshPorts.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnSerialPortRefreshPorts.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSerialPortRefreshPorts.Location = new System.Drawing.Point(107, 39);
            this.btnSerialPortRefreshPorts.Name = "btnSerialPortRefreshPorts";
            this.btnSerialPortRefreshPorts.Size = new System.Drawing.Size(59, 21);
            this.btnSerialPortRefreshPorts.TabIndex = 2;
            this.btnSerialPortRefreshPorts.Text = "refresh";
            this.btnSerialPortRefreshPorts.UseVisualStyleBackColor = true;
            this.btnSerialPortRefreshPorts.Click += new System.EventHandler(this.btnSerialPortRefreshPorts_Click);
            // 
            // cmbSerialPorts
            // 
            this.cmbSerialPorts.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cmbSerialPorts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbSerialPorts.FormattingEnabled = true;
            this.cmbSerialPorts.Location = new System.Drawing.Point(92, 16);
            this.cmbSerialPorts.Name = "cmbSerialPorts";
            this.cmbSerialPorts.Size = new System.Drawing.Size(74, 21);
            this.cmbSerialPorts.TabIndex = 1;
            // 
            // btnSerialPortDisconnect
            // 
            this.btnSerialPortDisconnect.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnSerialPortDisconnect.Location = new System.Drawing.Point(11, 38);
            this.btnSerialPortDisconnect.Name = "btnSerialPortDisconnect";
            this.btnSerialPortDisconnect.Size = new System.Drawing.Size(75, 23);
            this.btnSerialPortDisconnect.TabIndex = 0;
            this.btnSerialPortDisconnect.Text = "Disconnect";
            this.btnSerialPortDisconnect.UseVisualStyleBackColor = true;
            this.btnSerialPortDisconnect.Click += new System.EventHandler(this.btnSerialPortDisconnect_Click);
            // 
            // btnSerialPortConnect
            // 
            this.btnSerialPortConnect.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnSerialPortConnect.Location = new System.Drawing.Point(11, 13);
            this.btnSerialPortConnect.Name = "btnSerialPortConnect";
            this.btnSerialPortConnect.Size = new System.Drawing.Size(75, 23);
            this.btnSerialPortConnect.TabIndex = 0;
            this.btnSerialPortConnect.Text = "Connect";
            this.btnSerialPortConnect.UseVisualStyleBackColor = true;
            this.btnSerialPortConnect.Click += new System.EventHandler(this.btnSerialPortConnect_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.chkBoxShowModbusReceiveInAscii);
            this.panel1.Controls.Add(this.btnClearLogOutput);
            this.panel1.Controls.Add(this.chkBoxAutoclearBeforeSend);
            this.panel1.Controls.Add(this.btnFont);
            this.panel1.Controls.Add(this.rtxtLog);
            this.panel1.Location = new System.Drawing.Point(0, 424);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1008, 296);
            this.panel1.TabIndex = 19;
            // 
            // chkBoxShowModbusReceiveInAscii
            // 
            this.chkBoxShowModbusReceiveInAscii.AutoSize = true;
            this.chkBoxShowModbusReceiveInAscii.Location = new System.Drawing.Point(304, 7);
            this.chkBoxShowModbusReceiveInAscii.Name = "chkBoxShowModbusReceiveInAscii";
            this.chkBoxShowModbusReceiveInAscii.Size = new System.Drawing.Size(97, 17);
            this.chkBoxShowModbusReceiveInAscii.TabIndex = 16;
            this.chkBoxShowModbusReceiveInAscii.Text = "show rx in ascii";
            this.chkBoxShowModbusReceiveInAscii.UseVisualStyleBackColor = true;
            this.chkBoxShowModbusReceiveInAscii.CheckedChanged += new System.EventHandler(this.chkBoxShowModbusReceiveInAscii_CheckedChanged);
            // 
            // grpBoxTcpClientSend
            // 
            this.grpBoxTcpClientSend.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpBoxTcpClientSend.Controls.Add(this.txtBoxTcpRawSend);
            this.grpBoxTcpClientSend.Controls.Add(this.btnTcpSend2);
            this.grpBoxTcpClientSend.Controls.Add(this.txtBoxTcpRawSend2);
            this.grpBoxTcpClientSend.Controls.Add(this.btnTcpSend);
            this.grpBoxTcpClientSend.Location = new System.Drawing.Point(480, 3);
            this.grpBoxTcpClientSend.Name = "grpBoxTcpClientSend";
            this.grpBoxTcpClientSend.Size = new System.Drawing.Size(362, 64);
            this.grpBoxTcpClientSend.TabIndex = 17;
            this.grpBoxTcpClientSend.TabStop = false;
            this.grpBoxTcpClientSend.Text = "TCP client raw send:";
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.panelTcpServerSettings);
            this.groupBox4.Controls.Add(this.groupBox5);
            this.groupBox4.Controls.Add(this.btnStopServer);
            this.groupBox4.Controls.Add(this.btnStartServer);
            this.groupBox4.Location = new System.Drawing.Point(792, 81);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(213, 233);
            this.groupBox4.TabIndex = 37;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "TCP server:";
            // 
            // panelTcpServerSettings
            // 
            this.panelTcpServerSettings.Controls.Add(this.groupBox7);
            this.panelTcpServerSettings.Controls.Add(this.groupBox6);
            this.panelTcpServerSettings.Location = new System.Drawing.Point(57, 19);
            this.panelTcpServerSettings.Name = "panelTcpServerSettings";
            this.panelTcpServerSettings.Size = new System.Drawing.Size(152, 127);
            this.panelTcpServerSettings.TabIndex = 38;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.txtTcpServer_Port);
            this.groupBox7.Location = new System.Drawing.Point(3, 3);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(89, 44);
            this.groupBox7.TabIndex = 38;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Port";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label5);
            this.groupBox6.Controls.Add(this.txtTcpServerMessageEnd_ID);
            this.groupBox6.Controls.Add(this.txtTcpServerMessageStart_ID);
            this.groupBox6.Controls.Add(this.label2);
            this.groupBox6.Location = new System.Drawing.Point(3, 50);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(144, 68);
            this.groupBox6.TabIndex = 39;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Msg. Start/Stop Identifiers";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 41;
            this.label5.Text = "End:";
            // 
            // txtTcpServerMessageEnd_ID
            // 
            this.txtTcpServerMessageEnd_ID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTcpServerMessageEnd_ID.Font = new System.Drawing.Font("Courier New", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTcpServerMessageEnd_ID.Location = new System.Drawing.Point(38, 43);
            this.txtTcpServerMessageEnd_ID.Name = "txtTcpServerMessageEnd_ID";
            this.txtTcpServerMessageEnd_ID.Size = new System.Drawing.Size(56, 17);
            this.txtTcpServerMessageEnd_ID.TabIndex = 40;
            this.txtTcpServerMessageEnd_ID.Text = "\\";
            // 
            // txtTcpServerMessageStart_ID
            // 
            this.txtTcpServerMessageStart_ID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTcpServerMessageStart_ID.Font = new System.Drawing.Font("Courier New", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTcpServerMessageStart_ID.Location = new System.Drawing.Point(38, 20);
            this.txtTcpServerMessageStart_ID.Name = "txtTcpServerMessageStart_ID";
            this.txtTcpServerMessageStart_ID.Size = new System.Drawing.Size(56, 17);
            this.txtTcpServerMessageStart_ID.TabIndex = 40;
            this.txtTcpServerMessageStart_ID.TextChanged += new System.EventHandler(this.TextBox1TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 41;
            this.label2.Text = "Start:";
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.txtTcpServerToSend);
            this.groupBox5.Controls.Add(this.btnTcpServerSend);
            this.groupBox5.Location = new System.Drawing.Point(6, 151);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(201, 76);
            this.groupBox5.TabIndex = 39;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "To Clients";
            // 
            // txtTcpServerToSend
            // 
            this.txtTcpServerToSend.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTcpServerToSend.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTcpServerToSend.Font = new System.Drawing.Font("Courier New", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTcpServerToSend.Location = new System.Drawing.Point(4, 19);
            this.txtTcpServerToSend.Name = "txtTcpServerToSend";
            this.txtTcpServerToSend.Size = new System.Drawing.Size(192, 17);
            this.txtTcpServerToSend.TabIndex = 38;
            this.txtTcpServerToSend.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtTcpServerToSendKeyPress);
            this.txtTcpServerToSend.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxtTcpServerToSendKeyUp);
            // 
            // btnTcpServerSend
            // 
            this.btnTcpServerSend.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTcpServerSend.Location = new System.Drawing.Point(5, 45);
            this.btnTcpServerSend.Name = "btnTcpServerSend";
            this.btnTcpServerSend.Size = new System.Drawing.Size(192, 23);
            this.btnTcpServerSend.TabIndex = 37;
            this.btnTcpServerSend.Text = "send";
            this.btnTcpServerSend.UseVisualStyleBackColor = true;
            this.btnTcpServerSend.Click += new System.EventHandler(this.BtnTcpServerSendClick);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(261, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(27, 16);
            this.label10.TabIndex = 42;
            this.label10.Text = "OK";
            // 
            // rtxtLCD
            // 
            this.rtxtLCD.BackColor = System.Drawing.Color.GreenYellow;
            this.rtxtLCD.Font = new System.Drawing.Font("M3normalFont", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxtLCD.Location = new System.Drawing.Point(363, 37);
            this.rtxtLCD.Name = "rtxtLCD";
            this.rtxtLCD.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.rtxtLCD.Size = new System.Drawing.Size(225, 96);
            this.rtxtLCD.TabIndex = 34;
            this.rtxtLCD.Text = "123456789012345678\nABCDEFGHIJKLMNOPQR\nSTUVWXYZÅÄÖ!\"#¤\n{[]}\\";
            // 
            // chkLogDontEmptyScreen
            // 
            this.chkLogDontEmptyScreen.AutoSize = true;
            this.chkLogDontEmptyScreen.Location = new System.Drawing.Point(419, -1);
            this.chkLogDontEmptyScreen.Name = "chkLogDontEmptyScreen";
            this.chkLogDontEmptyScreen.Size = new System.Drawing.Size(169, 17);
            this.chkLogDontEmptyScreen.TabIndex = 35;
            this.chkLogDontEmptyScreen.Text = "show empty screen data in log";
            this.chkLogDontEmptyScreen.UseVisualStyleBackColor = true;
            this.chkLogDontEmptyScreen.CheckedChanged += new System.EventHandler(this.chkLogDontEmptyScreen_CheckedChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(328, 3);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(48, 13);
            this.label11.TabIndex = 36;
            this.label11.Text = "x 100mS";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1010, 725);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.grpBoxM3remote);
            this.Controls.Add(this.grpBoxTcpClientSend);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "PelletsBränarePLC styr";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.grpBoxM3remote.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownDisplayRefreshRate)).EndInit();
            this.panelDestinationSettings.ResumeLayout(false);
            this.panelDestinationSettings.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.grpBoxTcpClientSend.ResumeLayout(false);
            this.grpBoxTcpClientSend.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.panelTcpServerSettings.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnTcpClientConnect;
        private System.Windows.Forms.Button btnTcpClientDisconnect;
        private System.Windows.Forms.RichTextBox rtxtLog;
        private System.Windows.Forms.Button btnJustGetDisplay;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTcpClient_Ip;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTcpClient_Port;
        private System.Windows.Forms.Panel panelDestinationSettings;
        private System.Windows.Forms.Button btnClearLogOutput;
        private System.Windows.Forms.CheckBox chkBoxAutoclearBeforeSend;
        private System.Windows.Forms.Button btnFont;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnSerialPortConnect;
        private System.Windows.Forms.Button btnSerialPortDisconnect;
        private System.Windows.Forms.Button btnSerialPortRefreshPorts;
        private System.Windows.Forms.ComboBox cmbSerialPorts;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnTcpSend;
        private System.Windows.Forms.TextBox txtBoxTcpRawSend;
        private System.Windows.Forms.Button btnTcpSend2;
        private System.Windows.Forms.TextBox txtBoxTcpRawSend2;
        private System.Windows.Forms.CheckBox chkBoxDisplayAutoGet;
        private System.Windows.Forms.Button btnPLC_btnA;
        private System.Windows.Forms.Button btnPLC_btnOK;
        private System.Windows.Forms.Button btnPLC_btnPlus;
        private System.Windows.Forms.Button btnPLC_btnMinus;
        private System.Windows.Forms.Button btnPLC_btnESC;
        private System.Windows.Forms.Button btnPLC_btnB;
        private System.Windows.Forms.Button btnStartPLC;
        private System.Windows.Forms.Button btnStopPLC;
        private System.Windows.Forms.GroupBox grpBoxM3remote;
        private System.Windows.Forms.NumericUpDown numUpDownDisplayRefreshRate;
        private System.Windows.Forms.CheckBox chkBoxShowModbusReceiveInAscii;
        private DotMatrix.DotMatrixCell textLcd;
        private System.Windows.Forms.GroupBox grpBoxTcpClientSend;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnModbusRawPacketSender;
        private System.Windows.Forms.Button btnM3get_SLOUT;
        private System.Windows.Forms.RichTextBox rtxtM3_SLOUT_values;
        private System.Windows.Forms.Button btnStartServer;
        private System.Windows.Forms.TextBox txtTcpServer_Port;
        private System.Windows.Forms.Button btnStopServer;
        private System.Windows.Forms.Button btnM3_btnEscOK;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtTcpServerToSend;
        private System.Windows.Forms.Button btnTcpServerSend;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTcpServerMessageStart_ID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTcpServerMessageEnd_ID;
        private System.Windows.Forms.Panel panelTcpServerSettings;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Button btnM3get_SLOUT_41_48;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ImageList imgLstM3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.RichTextBox rtxtLCD;
        private System.Windows.Forms.CheckBox chkLogDontEmptyScreen;
        private System.Windows.Forms.Label label11;
    }
}

