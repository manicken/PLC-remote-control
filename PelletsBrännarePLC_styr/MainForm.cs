using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.IO.Ports;
using CustomFontDialogNamespace;
using System.Threading;

namespace PelletsBrännarePLC_styr
{
    public partial class MainForm : Form
    {
        private Communication.SocketClient tcpClient;
        private Communication.TCP_Server tcpServer;

        private System.IO.Ports.SerialPort serialPort;

               
        
        private readonly string CROUZET_M3_BTN_A_AND_CHK = "2011";
        private readonly string CROUZET_M3_BTN_B_AND_CHK = "1021";
        private readonly string CROUZET_M3_BTN_ESC_AND_CHK = "0829";
        private readonly string CROUZET_M3_BTN_OK_AND_CHK = "0130";
        private readonly string CROUZET_M3_BTN_MINUS_AND_CHK = "042D";
        private readonly string CROUZET_M3_BTN_PLUS_AND_CHK = "022F";
        private readonly string CROUZET_M3_BTN_ESCOK_AND_CHK = "0928";
        private readonly string CROUZET_M3_BTNS_RELEASED_AND_CHK = "0031";
        
        private readonly string CROUZET_M3_GET_DISPLAY_CONTENTS_CMD = ":010300006F004E3F\r\n";
        private static string CROUZET_M3_BTN_CHK_REPLACE_DEF = "{bc}";
        private readonly string CROUZET_M3_SET_BUTTON_STATE_CMD = ":011000006F4E01" + CROUZET_M3_BTN_CHK_REPLACE_DEF + "\r\n";
        private readonly string CROUZET_M3_GET_SLOUT_25_32_CMD = ":04030000FF1830B2\r\n";
        private readonly string CROUZET_M3_GET_SLOUT_41_48_CMD = ":04030000FF2810C2\r\n";
        private readonly string CROUZET_M3_STOP_CMD = ":011000006C0002010080\r\n";
        private readonly string CROUZET_M3_START_CMD = ":011000006C000202007F\r\n";

        /// <summary> track what we send so when we receive the response we know what kind of data it's. </summary>
        private string lastTransmittedMessage = "";

        private bool AutoclearBeforeSend = false;

        private System.Windows.Forms.Timer timerRefreshDisplay;
        private bool autoRefreshDisplay = false;

        private bool showRxInAscii = false;

        private ModbusPacketCreatorForm modbusForm = null;

        private bool DEBUG_LOOPBACK_MODE = false;
        private readonly string DEBUG_LOOPBACK_IP = "127.0.0.1";
        //private readonly string DEBUG_LOOPBACK_PORT = "2020";

        private IniFile iniSettingFile;

        public MainForm()
        {
            //System.Threading.Thread.CurrentThread.Name = "MainFormThread: " + System.Threading.Thread.CurrentThread.GetHashCode().ToString("x4");
            
            InitializeComponent();

            iniSettingFile = new IniFile("Settings.ini");

            if (iniSettingFile.KeyExists("Port", "TcpServer"))
                txtTcpServer_Port.Text = iniSettingFile.Read("Port", "TcpServer");

            if (iniSettingFile.KeyExists("Width", "WindowSize"))
                this.Width = Convert.ToInt32(iniSettingFile.Read("Width", "WindowSize"));

            if (iniSettingFile.KeyExists("Height", "WindowSize"))
                this.Height = Convert.ToInt32(iniSettingFile.Read("Height", "WindowSize"));

            if (DEBUG_LOOPBACK_MODE)
            {
                txtTcpClient_Ip.Text = DEBUG_LOOPBACK_IP;
                txtTcpClient_Port.Text = txtTcpServer_Port.Text;
            }
            else
            {
                if (iniSettingFile.KeyExists("Ip", "TcpClient"))
                    txtTcpClient_Ip.Text = iniSettingFile.Read("Ip", "TcpClient");
                if (iniSettingFile.KeyExists("Port", "TcpClient"))
                    txtTcpClient_Port.Text = iniSettingFile.Read("Port", "TcpClient");

            }

            chkBoxAutoclearBeforeSend.Checked = AutoclearBeforeSend;

            tcpClient = new Communication.SocketClient(4);
            tcpClient.ConnectedStateChangedDelegate = tcpClient_ConnectedStateChanged;
            // tcpClient.DataReceivedDelegate = tcpClient_DataReceived;
            tcpClient.OnErrorDelegate = tcpClient_OnError;
            tcpClient.OnWarningDelegate = tcpClient_OnWarning;
            tcpClient_ConnectedStateChanged(false);
            tcpClient.SetMessagePacketReceiveIdentifiers(":", "\r\n", tcpClient_MessageReceivedDelegate);

            tcpServer = new Communication.TCP_Server("", "\\");
            RegisterAll_TcpServer_Events();
            
            serialPort = new SerialPort();
            serialPort.BaudRate = 115200;
            serialPort.DataBits = 7;
            serialPort.Parity = Parity.Even;
            serialPort.ErrorReceived += new SerialErrorReceivedEventHandler(serialPort_ErrorReceived);
            serialPort.DataReceived += new SerialDataReceivedEventHandler(serialPort_DataReceived);

            timerRefreshDisplay = new System.Windows.Forms.Timer();

            timerRefreshDisplay.Tick += new EventHandler(timerRefreshDisplay_Tick);
            
            Init_PLC_M3_buttons();
        }
        
        

        private void RegisterAll_TcpServer_Events()
        {
            tcpServer.MessageReceived += new Communication.TCP_Server.MessageReceivedEventHandler(tcpServer_MessageReceived);
            tcpServer.DebugWarningMessageEvent += new Communication.TCP_Server.DebugWarningMessageEventHandler(tcpServer_DebugWarningMessageEvent);
            tcpServer.DebugErrorMessageEvent += new Communication.TCP_Server.DebugErrorMessageEventHandler(tcpServer_DebugErrorMessageEvent);
            tcpServer.ListeningStarted = tcpServer_ListeningStarted;
            tcpServer.ListeningStopped = tcpServer_ListeningStopped;
            tcpServer.ClientConnected = tcpServer_ClientConnected;

        }

        private void DeRegisterAll_TcpServer_Events()
        {
            tcpServer.MessageReceived -= new Communication.TCP_Server.MessageReceivedEventHandler(tcpServer_MessageReceived);
            tcpServer.DebugWarningMessageEvent -= new Communication.TCP_Server.DebugWarningMessageEventHandler(tcpServer_DebugWarningMessageEvent);
            tcpServer.DebugErrorMessageEvent -= new Communication.TCP_Server.DebugErrorMessageEventHandler(tcpServer_DebugErrorMessageEvent);
            tcpServer.ListeningStarted = null;
            tcpServer.ListeningStopped = null;
            tcpServer.ClientConnected  = null;
        }
        
        private void tcpServer_ClientConnected(Communication.Threaded_TcpServerClient client)
        {
        	rtxtLog.AppendLine_s(true, false, "new tcp client connected @ " + client.tcpClient.Client.LocalEndPoint.ToString());
        }

        private void tcpServer_ListeningStarted()
        {
            this.Invoke((System.Windows.Forms.MethodInvoker)(delegate()
                        {
                            rtxtLog.AppendLine_s(true, false, "tcpServer_ListeningStarted");
                            btnStartServer.Enabled = false;
                            btnStopServer.Enabled = true;
                            panelTcpServerSettings.Enabled = false;
                        }));
        }

        private void tcpServer_ListeningStopped()
        {
            this.Invoke((System.Windows.Forms.MethodInvoker)(delegate()
                        {
                            rtxtLog.AppendLine_s(true, false, "tcpServer_ListeningStopped");
                            btnStartServer.Enabled = true;
                            btnStopServer.Enabled = false;
                            panelTcpServerSettings.Enabled = true;
                        }));
        }
        private void tcpServer_DebugWarningMessageEvent(string message)
        {
            rtxtLog.AppendTextWithColor(message, true, Color.LightYellow, Color.Black, true, true);
        }
        private void tcpServer_DebugErrorMessageEvent(string message)
        {
            rtxtLog.AppendTextWithColor(message, true, Color.LightPink, Color.Black, true, true);
        
            //rtxtTransceiveLog.AppendTextWithColor(errorMessage, true, Color.Pink, Color.Black, true, true);
        }
        string m3_rx_temp = "";
        private void tcpServer_MessageReceived(string message)
        {

                    //Decode_M3_message_and_send_response(m3_rx_temp);
                    rtxtLog.AppendLine_s(true, true, "tcpServer_MessageReceived: " + message);
                    //if (serialPort.IsOpen)
                    //serialPort.Write(m3_rx_temp + "\r\n");
                    if (message.ToLower() == "m3_lcd")
                        SendSocketMessage(CROUZET_M3_GET_DISPLAY_CONTENTS_CMD);
                    else if (message.ToLower() == "m3_slout")
                        SendSocketMessage(CROUZET_M3_GET_SLOUT_25_32_CMD);
                    else if (message.ToLower() == "m3_stop")
                        SendSocketMessage(CROUZET_M3_STOP_CMD);
                    else if (message.ToLower() == "m3_start")
                        SendSocketMessage(CROUZET_M3_START_CMD);
                    else if (message.ToLower().StartsWith("kb"))
                        SendKeys.SendWait(message.Substring(3));

        }

        private void timerRefreshDisplay_Tick(object s, EventArgs ea)
        {
            timerRefreshDisplay.Stop();
            
            SendSocketMessage(CROUZET_M3_GET_DISPLAY_CONTENTS_CMD);
        }

        private void serialPort_ErrorReceived(object s, SerialErrorReceivedEventArgs serea)
        {
            rtxtLog.AppendText_Invoked("serialPort_ErrorReceived: " + serea.EventType.ToString());
        }

        private void serialPort_DataReceived(object s, SerialDataReceivedEventArgs sdrea)
        {
            string data = serialPort.ReadExisting();

            
                SendSocketMessage(data);

            rtxtLog.AppendText_Invoked("serialPort_DataReceived: " + data);
        }

        private void tcpClient_ConnectedStateChanged(bool connected)
        {
            if (!this.IsHandleCreated)
                return;
            this.Invoke((System.Windows.Forms.MethodInvoker)(delegate()
                {
                    btnTcpClientConnect.Enabled = !connected;
                    btnTcpClientDisconnect.Enabled = connected;
                    panelDestinationSettings.Enabled = !connected;
                    //panelUserInput.Enabled = connected;
                    grpBoxTcpClientSend.Enabled = connected;
                    grpBoxM3remote.Enabled = connected;
                }));
        }
        private string ConvertFromM3CharTable_SpecialChars(string text)
        {
            StringBuilder sb = new StringBuilder(text);

            for (int i = 0; i < sb.Length; i++)
            {
                
                if (sb[i] == 'ý') sb[i] = '}';
                else if (sb[i] == 'ÿ') sb[i] = '{';
                else if (sb[i] == '{') sb[i] = Convert.ToChar(0xE1); // ä
                else if (sb[i] == '¯') sb[i] = Convert.ToChar(0xE5); // å
                else if (sb[i] == '|') sb[i] = 'ö'; // ö

            }
            return sb.ToString();
        }
        private void tcpClient_MessageReceivedDelegate(string message)
        {
            if (serialPort.IsOpen)
                serialPort.Write(":" + message + "\r\n");

            

            if (lastTransmittedMessage == CROUZET_M3_GET_DISPLAY_CONTENTS_CMD)
            {
                string displayText = "";
                try
                {
                    int[] header;
                    int dataEndIndex = 0;
                    if (!message.ConvertFromByteAsciiHex(0, 6, out header))
                        dataEndIndex = 6 + (18 * 4 * 2);
                    else
                        dataEndIndex = header[2] * 2 - 6; // non simpilified form -> (header[2] - 6) * 2 + 6;
                    
                    if (message.ConvertFromByteAsciiHex(6, dataEndIndex, out displayText))
                    {
                        this.Invoke((System.Windows.Forms.MethodInvoker)(delegate()
                        {
                            if (displayText.TrimmedLength() != 0) // ignore the empty screen data
                            {
                                //txtBoxM3display.Text = displayText.Replace('{', 'ä');
                                textLcd.TextSetAll(ConvertFromM3CharTable_SpecialChars(displayText));
                                displayText = displayText.Insert(18 * 3, "\n");
                                displayText = displayText.Insert(18 * 2, "\n");
                                displayText = displayText.Insert(18 * 1, "\n");
                                rtxtLCD.Text = displayText;
                                //if (tcpServer.Listening)
                                //   tcpServer.Send("m3lcd " + displayText + "\r\n");
                                rtxtLog.AppendLine_s(true, true, message);
                            }
                            else
                            {

                                if (chkLogDontEmptyScreenChecked)
                                    rtxtLog.AppendLine_s(true, true, message);
                                else
                                    rtxtLog.AppendLine_s(true, true, "screen empty");

                                SendSocketMessage(CROUZET_M3_GET_DISPLAY_CONTENTS_CMD);
                            }
                            if (autoRefreshDisplay)
                            {
                                timerRefreshDisplay.Interval = Convert.ToInt32(numUpDownDisplayRefreshRate.Value)*100;
                                timerRefreshDisplay.Start();
                            }
                                
                        }));
                    }
                    else
                    {
                        rtxtLog.AppendLine_s(true, true, "ERROR converting displayText:" + displayText + "\nDataEndindex:" + dataEndIndex);
                    }
                }
                catch (Exception ex)
                {
                    rtxtLog.AppendLine_s(true, true, "ERROR CANNOT convert:" + message);
                }
            }
            else if (lastTransmittedMessage == CROUZET_M3_GET_SLOUT_25_32_CMD)
            {
                int[] values;
                if (message.ConvertFrom2ByteAsciiHex(6, 6 + (16*4), out values))
                {
                    string strList = "";
                    for (int i = 0; i < values.Length; i++)
                        strList += values[i] + "\n";

                    //if (tcpServer.Listening)
                    //    tcpServer.Send("m3slout " + strList + "\r\n");

                    this.Invoke((System.Windows.Forms.MethodInvoker)(delegate()
                        {
                            rtxtM3_SLOUT_values.Text = strList;
                        }));
                    
                        //rtxtM3_SLOUT_values.AppendText_Invoked(strList);//.AppendLine_s(true, true, values[i].ToString());
                }
                rtxtLog.AppendLine_s(true, true, message);
            }
            else if (lastTransmittedMessage == CROUZET_M3_GET_SLOUT_41_48_CMD)
            {
                int[] values;
                if (message.ConvertFrom2ByteAsciiHex(6, 6 + (16*4), out values))
                {
                    string strList = "";
                    for (int i = 0; i < values.Length; i++)
                        strList += values[i] + "\n";

                    //if (tcpServer.Listening)
                    //    tcpServer.Send("m3slout " + strList + "\r\n");

                    this.Invoke((System.Windows.Forms.MethodInvoker)(delegate()
                        {
                            rtxtM3_SLOUT_values.Text = strList;
                        }));
                    
                        //rtxtM3_SLOUT_values.AppendText_Invoked(strList);//.AppendLine_s(true, true, values[i].ToString());
                }
                rtxtLog.AppendLine_s(true, true, message);
            }
            else if (lastTransmittedMessage == CROUZET_M3_SET_BUTTON_STATE_CMD.Replace(CROUZET_M3_BTN_CHK_REPLACE_DEF, CROUZET_M3_BTNS_RELEASED_AND_CHK))
            {
                rtxtLog.AppendLine_s(true, true, "button release - ack");
                SendSocketMessage(CROUZET_M3_GET_DISPLAY_CONTENTS_CMD);
            }
            else
                rtxtLog.AppendLine_s(true, true, message);
            //else if (message == "011000006F4E0131")
            //    SendSocketMessage(CROUZET_M3_GET_DISPLAY_CONTENTS_CMD);

            if (showRxInAscii)
            {
                message.ConvertFromByteAsciiHex(6, message.Length - 8, out message);
            }
            
                
        }

        

        private void tcpClient_DataReceived(string data)
        {
            data = data.Replace("\r", "<cr>").Replace("\n", "<lf>");
            rtxtLog.AppendText_Invoked(data + "\r\n");
        }

        private void tcpClient_OnError(string message)
        {
            rtxtLog.AppendTextWithColor("tcpClient_OnError:" + message, true, Color.Pink, Color.Black, true, true);
        }

        private void tcpClient_OnWarning(string message)
        {
            rtxtLog.AppendTextWithColor(message, true, Color.LightYellow, Color.Black, true, true);
        }


        private void btnJustGetDisplay_Click(object sender, EventArgs e)
        {
            SendSocketMessage(CROUZET_M3_GET_DISPLAY_CONTENTS_CMD);
        }


        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (serialPort.IsOpen)
                serialPort.Close();
            DeRegisterAll_TcpServer_Events();
            
            tcpServer.Stop();
            if (tcpClient.Connected)
                tcpClient.Disconnect();

            if (!DEBUG_LOOPBACK_MODE)
            {
                iniSettingFile.Write("Port", txtTcpServer_Port.Text, "TcpServer");
                iniSettingFile.Write("Ip", txtTcpClient_Ip.Text, "TcpClient");
                iniSettingFile.Write("Port", txtTcpClient_Port.Text, "TcpClient");
            }

            iniSettingFile.Write("Width", this.Width.ToString(), "WindowSize");
            iniSettingFile.Write("Height", this.Height.ToString(), "WindowSize");
        }

        private void SendSocketMessage(string message)
        {
            lastTransmittedMessage = message;
            if (!tcpClient.Connected)
                return;

            if (AutoclearBeforeSend)
            {
                rtxtLog.Invoke((System.Windows.Forms.MethodInvoker)(delegate()
                {
                    rtxtLog.Clear();
                }));
            }
            tcpClient.SendMessage(message);
        }

        private void btnFont_Click(object sender, EventArgs e)
        {
            using (CustomFontDialog fd = new CustomFontDialog())
            {
                fd.SelectedFont = rtxtLog.Font;
                
                if (fd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    rtxtLog.Font = fd.SelectedFont;
                }
            }
        }

        private void btnClearLogOutput_Click(object sender, EventArgs e)
        {
            rtxtLog.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string stringToCheck = "This is";
            string stringStartsWith = "is ";
            rtxtLog.Clear();
            rtxtLog.AppendText("\"" + stringToCheck + "\".StartsWith(\"" + stringStartsWith + "\", 5)=" + stringToCheck.StartsWith(stringStartsWith, 5).ToString());
        }

        private void btnTcpClientDisconnect_Click(object sender, EventArgs e)
        {
            tcpClient.Disconnect();
        }

        private void btnTcpClientConnect_Click(object sender, EventArgs e)
        {
            tcpClient.Connect(txtTcpClient_Ip.Text, txtTcpClient_Port.Text);
        }

        private void btnSerialPortRefreshPorts_Click(object sender, EventArgs e)
        {
            RefreshSerialPorts();
            
        }

        private void RefreshSerialPorts()
        {
            cmbSerialPorts.Items.Clear();
            cmbSerialPorts.Items.AddRange(System.IO.Ports.SerialPort.GetPortNames());
            if (cmbSerialPorts.Items.Count != 0)
            {
                cmbSerialPorts.SelectedIndex = 0;
                btnSerialPortConnect.Enabled = true;
            }
            else
                btnSerialPortConnect.Enabled = false;
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            RefreshSerialPorts();
        }

        private void btnSerialPortConnect_Click(object sender, EventArgs e)
        {
            serialPort.PortName = cmbSerialPorts.Text;
            try
            {
                serialPort.Open();
                UpdateSerialPortConnectedState(serialPort.IsOpen);
            }
            catch (Exception ex)
            {
                rtxtLog.AppendText("Exception when trying to connect to serial port:\n" + ex.ToString() + "\n");
            }
        }

        private void UpdateSerialPortConnectedState(bool connected)
        {
            btnSerialPortConnect.Enabled = !connected;
            btnSerialPortDisconnect.Enabled = connected;
        }

        private void btnSerialPortDisconnect_Click(object sender, EventArgs e)
        {
            if (!serialPort.IsOpen)
            {
                UpdateSerialPortConnectedState(false);
                return;
            }
            try
            {
                serialPort.Close();
                UpdateSerialPortConnectedState(serialPort.IsOpen);
            }
            catch (Exception ex)
            {
                rtxtLog.AppendText("Exception when trying to disconnect from serial port:\n" + ex.ToString() + "\n");
            }
        }

        private void chkBoxAutoclearBeforeSend_CheckedChanged(object sender, EventArgs e)
        {
            AutoclearBeforeSend = chkBoxAutoclearBeforeSend.Checked;
        }

        private void btnTcpSend_Click(object sender, EventArgs e)
        {
            SendSocketMessage(txtBoxTcpRawSend.Text.Replace("\\r\\n", "\r\n"));
        }

        

        

        

        private void btnTcpSend2_Click(object sender, EventArgs e)
        {
            SendSocketMessage(txtBoxTcpRawSend2.Text.Replace("\\r\\n", "\r\n"));
        }

        private void btnPLC_btnX_MouseDown(object s, MouseEventArgs e)
        {
            Button btn = (s as Button);
            btn.ImageIndex++;
            Send_PLC_ButtonData(btn.Tag.ToString());
        }
        
        private void btnPLC_btnX_MouseUp(object s, MouseEventArgs e)
        {
            Button btn = (s as Button);
            btn.ImageIndex--;
            Send_PLC_ButtonData(CROUZET_M3_BTNS_RELEASED_AND_CHK);
        }
        
        private void Init_PLC_M3_buttons()
        {
            btnM3_btnEscOK.Tag = CROUZET_M3_BTN_ESCOK_AND_CHK;
            btnPLC_btnA.Tag = CROUZET_M3_BTN_A_AND_CHK;
            btnPLC_btnB.Tag = CROUZET_M3_BTN_B_AND_CHK;
            btnPLC_btnESC.Tag = CROUZET_M3_BTN_ESC_AND_CHK;
            btnPLC_btnMinus.Tag = CROUZET_M3_BTN_MINUS_AND_CHK;
            btnPLC_btnPlus.Tag = CROUZET_M3_BTN_PLUS_AND_CHK;
            btnPLC_btnOK.Tag = CROUZET_M3_BTN_OK_AND_CHK;
            
            btnM3_btnEscOK.MouseDown += btnPLC_btnX_MouseDown;
            btnPLC_btnA.MouseDown += btnPLC_btnX_MouseDown;
            btnPLC_btnB.MouseDown += btnPLC_btnX_MouseDown;
            btnPLC_btnESC.MouseDown += btnPLC_btnX_MouseDown;
            btnPLC_btnMinus.MouseDown += btnPLC_btnX_MouseDown;
            btnPLC_btnPlus.MouseDown += btnPLC_btnX_MouseDown;
            btnPLC_btnOK.MouseDown += btnPLC_btnX_MouseDown;
                
            btnM3_btnEscOK.MouseUp += btnPLC_btnX_MouseUp;
            btnPLC_btnA.MouseUp += btnPLC_btnX_MouseUp;
            btnPLC_btnB.MouseUp += btnPLC_btnX_MouseUp;
            btnPLC_btnESC.MouseUp += btnPLC_btnX_MouseUp;
            btnPLC_btnMinus.MouseUp += btnPLC_btnX_MouseUp;
            btnPLC_btnPlus.MouseUp += btnPLC_btnX_MouseUp;
            btnPLC_btnOK.MouseUp += btnPLC_btnX_MouseUp;
        }
        
        private void Send_PLC_ButtonData(string buttonAndCheckSum)
        {
            SendSocketMessage(CROUZET_M3_SET_BUTTON_STATE_CMD.Replace(CROUZET_M3_BTN_CHK_REPLACE_DEF, buttonAndCheckSum));
        }

        private void btnStopPLC_Click(object sender, EventArgs e)
        {
            SendSocketMessage(CROUZET_M3_STOP_CMD);
        }

        private void btnStartPLC_Click(object sender, EventArgs e)
        {
            SendSocketMessage(CROUZET_M3_START_CMD);
        }

        

        private void chkBoxDisplayAutoGet_CheckedChanged(object sender, EventArgs e)
        {
            autoRefreshDisplay = chkBoxDisplayAutoGet.Checked;
            
        }

        private void chkBoxShowModbusReceiveInAscii_CheckedChanged(object sender, EventArgs e)
        {
            showRxInAscii = chkBoxShowModbusReceiveInAscii.Checked;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        

        private void btnModbusRawPacketSender_Click(object sender, EventArgs e)
        {
            if (modbusForm == null)
            {
                modbusForm = new ModbusPacketCreatorForm();
                modbusForm.TopLevel = false;
                modbusForm.Parent = this;
                modbusForm.SendPacket = SendSocketMessage;
            }
            
            modbusForm.Show();
            modbusForm.BringToFront();
            modbusForm.WindowState = FormWindowState.Normal;
        }

        private void btnM3get_SLOUT_Click(object sender, EventArgs e)
        {
            SendSocketMessage(CROUZET_M3_GET_SLOUT_25_32_CMD);
        }

        private void btnStartServer_Click(object sender, EventArgs e)
        {
        	tcpServer.MessageStartIdentifier = txtTcpServerMessageStart_ID.Text;
        	tcpServer.MessageEndIdentifier = txtTcpServerMessageEnd_ID.Text;
        	
            tcpServer.StartListen(txtTcpServer_Port.Text);
        }

        private void btnStopServer_Click(object sender, EventArgs e)
        {
            tcpServer.Stop();
        }

        private void btnPLC_btnOK_Click(object sender, EventArgs e)
        {

        }

        private void btnPLC_btnPlus_Click(object sender, EventArgs e)
        {

        }

        
		void TxtTcpServerToSendKeyPress(object sender, KeyPressEventArgs e)
		{
			// (e.KeyChar == 
			//TcpServerSend
		}
		
		void TcpServerSend(string message)
		{
				
			tcpServer.SendToClients(message);
		}
		void TxtTcpServerToSendKeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyData == Keys.Enter)
				TcpServerSend(txtTcpServerToSend.Text);
		}
		void TextBox1TextChanged(object sender, EventArgs e)
		{
		
		}
		void BtnTcpServerSendClick(object sender, EventArgs e)
		{
			TcpServerSend(txtTcpServerToSend.Text);
		}
		void BtnM3get_SLOUT_41_48Click(object sender, EventArgs e)
		{
			SendSocketMessage(CROUZET_M3_GET_SLOUT_41_48_CMD);
		}

        private void button1_Click_1(object sender, EventArgs e)
        {
            textLcd.PrintCGROM = true;
        }
        bool chkLogDontEmptyScreenChecked = false;

        private void chkLogDontEmptyScreen_CheckedChanged(object sender, EventArgs e)
        {
            chkLogDontEmptyScreenChecked = chkLogDontEmptyScreen.Checked;
        }
    }
}
