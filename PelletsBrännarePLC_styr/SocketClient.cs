/*
 * 
 * Most credits to Jayan Nair for providing this 
 * simple and working example using a socket client.
 * Date/time: 7/9/2004 2:27 PM
 * 
 * Later changed to standalone class with Action Delegates 
 * for simplier usage in current and future projects.
 * By Jannik Svensson (microsan84) SWEDEN
 * Date/time: 21/10/2015 22:47
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace Communication
{
    

    public class SocketClient
    {
        private enum MessageBoxType
        {
            Warning,
            Error
        }

        

        public class SocketPacket
        {
            //public System.Net.Sockets.Socket thisSocket;
            public byte[] dataBuffer;

            
            

            public SocketPacket(/*System.Net.Sockets.Socket Socket, */int dataBufferLength)
            {
                //this.thisSocket = Socket;
                dataBuffer = new byte[dataBufferLength];
                
            }

            
            public void Dispose()
            {
                //thisSocket = null;
                dataBuffer = null;

            }
        }

        //string instanceThread;
        //string receiveThread;

        public Action<bool> ConnectedStateChangedDelegate = null;
        public Action<string> DataReceivedDelegate = null;
        public Action<string> OnErrorDelegate = null;
        public Action<string> OnWarningDelegate = null;

        /// <summary> this is only used when the delegates are not registerd to any method.</summary>
        //public bool ShowWarningDialog = true;
        /// <summary> this is only used when the delegates are not registerd to any method.</summary>
        //public bool ShowErrorDialog = true;


        public string MessageStartIdentifier = null;
        public string MessageEndIdentifier = null;
        public Action<string> MessageReceivedDelegate = null;
        public StringBuilder sbReceiveMessageTemp = null;

        private int receiveDataBufferLength;
        private byte[] m_dataBuffer = null;
        private IAsyncResult m_result = null;

        private AsyncCallback m_pfnCallBack = null;
        private Socket m_clientSocket = null;

        private IPAddress currentDestinationIp = null;
        private int currentDestinationPort;

        public SocketError LastSocketError
        {
            get { return _lastSocketError; }
        }

        private SocketError _lastSocketError = SocketError.SocketError;

        public bool Connected
        {
            get { return (m_clientSocket != null); }
        }

        public SocketClient(int receiveDataBufferLength)
        {
            this.receiveDataBufferLength = receiveDataBufferLength;
            m_dataBuffer = new byte[receiveDataBufferLength];

            //instanceThread = System.Threading.Thread.CurrentThread.Name;
        }

        public void SetMessagePacketReceiveIdentifiers(string messageStartIdentifier, string messageEndIdentifier, Action<string> MessageReceivedEventHandler)
        {
            if (messageStartIdentifier.IsNullOrEmpty(true))
                this.MessageStartIdentifier = null;
            else
                this.MessageStartIdentifier = messageStartIdentifier;

            if (messageEndIdentifier.IsNullOrEmpty(false))
                this.MessageEndIdentifier = null;
            else
                this.MessageEndIdentifier = messageEndIdentifier;

            MessageReceivedDelegate = MessageReceivedEventHandler;
            DataReceivedDelegate = null;
        }

        public void Connect(string destAddress, string destPort)
        {
            // See if we have text on the IP and Port text fields
            if (destAddress.Trim() == "" || destPort.Trim() == "")
            {
                DebugWarning("IP Address and Port Number are required to connect to the Server\n");
                return;
            }
            // try get the remote IP address
            if (!IPAddress.TryParse(destAddress, out currentDestinationIp))
            {
                DebugWarning("IP Address (" +destAddress + ") parsing fail!\n");
                return;
            }
            if (!int.TryParse(destPort, out currentDestinationPort))
            {
                DebugWarning("IP Port (" +destAddress  +") parsing fail!\n");
                return;
            }
            try
            {
                SetConnectedState(false);
                // Create the socket instance
                m_clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                // Create the end point 
                IPEndPoint ipEnd = new IPEndPoint(currentDestinationIp, currentDestinationPort);
                
                // Connect to the remote host
                m_clientSocket.Connect(ipEnd);
                if (m_clientSocket.Connected)
                {
                    SetConnectedState(true);
                    //Wait for data asynchronously 
                    WaitForData(true);
                }
            }
            catch (SocketException se)
            {
                DebugError("\nConnection failed, is the server running?\n" + se.Message);

                SetConnectedState(false);
            }
        }

        public void Disconnect()
        {
            if (m_clientSocket != null)
            {
               
                m_clientSocket.Close();
                m_clientSocket = null;
                SetConnectedState(false);
            }
        }

        public void SendMessage(string message)
        {
            if (!m_clientSocket.Connected)
            {
                DebugWarning("Warning@SendMessage: you are not connected!!!");
                return;
            }
            if (message != null)
            {
                if (message.Length == 0)
                {
                    DebugWarning("Warning@SendMessage: the message length is zero!!!");
                    return;
                }
            }
            try
            {
                if (sbReceiveMessageTemp != null)
                    sbReceiveMessageTemp.Clear();

                byte[] byteData = System.Text.Encoding.ASCII.GetBytes(message);

                m_clientSocket.Send(byteData);
            }
            catch (SocketException se)
            {
                DebugError("SocketException: " + se.Message);
            }
            catch (Exception ex)
            {
                DebugError("unknown Exception: " + ex.ToString());
            }
        }

        private void WaitForData(bool firstCall)
        {
            
            try
            {
                if (m_pfnCallBack == null)
                {
                    m_pfnCallBack = new AsyncCallback(OnDataReceived);
                }
                SocketPacket theSocPkt = new SocketPacket(receiveDataBufferLength);

                // Start listening to the data asynchronously
                m_result = m_clientSocket.BeginReceive(theSocPkt.dataBuffer,
                                                        0, receiveDataBufferLength,
                                                        SocketFlags.None, out _lastSocketError,
                                                        m_pfnCallBack,
                                                        theSocPkt);
            }
            catch (SocketException se)
            {
                DebugError("\nSocketException while WaitForData: " + _lastSocketError.ToString() + "\n" + se.Message);
            }

        }

        public void OnDataReceived(IAsyncResult asyn)
        {
            SocketPacket theSocketPacket = (SocketPacket)asyn.AsyncState;

            if (m_clientSocket == null)
            {
                SetConnectedState(false);
                theSocketPacket.Dispose();
                theSocketPacket = null;
                asyn = null;
                return;
            }
            if (m_clientSocket.Connected != true)
            {
                SetConnectedState(false);
                theSocketPacket.Dispose();
                theSocketPacket = null;
                asyn = null;
                return;
            }
            
            try
            {
                int iRx = m_clientSocket.EndReceive(asyn, out _lastSocketError); // gets the amount of received data

                if (iRx == 0)
                {
                    SetConnectedState(false);
                    theSocketPacket.Dispose();
                    theSocketPacket = null;
                    asyn = null;
                    return;

                }

                if (sbReceiveMessageTemp == null)
                    sbReceiveMessageTemp = new StringBuilder(); // important that we create the instance in Receive Thread.

                if (DataReceivedDelegate != null)
                {
                    sbReceiveMessageTemp.Clear();
                    sbReceiveMessageTemp.AppendAsChars(theSocketPacket.dataBuffer, iRx, false, false, true);
                    DataReceivedDelegate(sbReceiveMessageTemp.ToString());
                }
                else if (MessageReceivedDelegate != null)
                {
                    sbReceiveMessageTemp.AppendAsChars(theSocketPacket.dataBuffer, iRx, false, false, true);
                    ParseCurrentReceivedData();
                }

                theSocketPacket.Dispose();
                theSocketPacket = null;
                asyn = null;

                WaitForData(false);
            }
            catch (ObjectDisposedException ode)
            {
                DebugWarning("\nOnDataReceived: Socket has been closed\n" + ode + "\n");
            }
            catch (SocketException se)
            {
                DebugError("SocketException while OnDataReceived: " + se.Message);
            }
        }

        private void ParseCurrentReceivedData()
        {

            if ((MessageStartIdentifier == null) || (MessageEndIdentifier == null)) // cannot work reliable without proper start and end of message identifiers.
            {
                DebugWarning("(MessageStartIdentifier == null) || (MessageEndIdentifier == null)");
                return;
            }

            int startIndexOf = -1;
            if (sbReceiveMessageTemp.Contains(MessageStartIdentifier, out startIndexOf))
            {
                //DebugWarning("test1:" + startIndexOf);
                if (startIndexOf != 0)
                {
                    //DebugWarning("test2:" + startIndexOf);
                    sbReceiveMessageTemp = sbReceiveMessageTemp.Remove(0, startIndexOf);
                   // MessageTemp = MessageTemp.Substring(startIndexOf);
                    startIndexOf = 0;
                }
            }
            int endIndexOf = -1;
            if (sbReceiveMessageTemp.Contains(MessageEndIdentifier, out endIndexOf))
            {
                //DebugWarning("test3");
                if (startIndexOf == 0)
                {
                    //DebugWarning("test4");
                    string MessageTemp = sbReceiveMessageTemp.ToString();

                    MessageReceivedDelegate(MessageTemp.Substring(MessageStartIdentifier.Length, endIndexOf - MessageStartIdentifier.Length));

                    sbReceiveMessageTemp = new StringBuilder(MessageTemp.Substring(endIndexOf + MessageEndIdentifier.Length));
                }
            }
        }

        private void SetConnectedState(bool connected)
        {
            if (ConnectedStateChangedDelegate != null)
                ConnectedStateChangedDelegate(connected);
        }

       /* private void DisplayMessageBox(string message, MessageBoxType msgtype)
        {
            message += "\n\nThis is the standard message that will show on warnings/errors\nto avoid this popping up either register on the Delegates or set the ShowWarningDialog and/or ShowErrorDialog properties to false.";
            if (msgtype == MessageBoxType.Warning)
                System.Windows.Forms.MessageBox.Show(message, "Warning", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
        }
        */
        private void DebugWarning(string message)
        {
            if (OnWarningDelegate != null)
                OnWarningDelegate(message);
            else
            {
                System.Console.ForegroundColor = ConsoleColor.DarkYellow;
                System.Console.WriteLine(message);
            }
           // else if (ShowWarningDialog)
           //     DisplayMessageBox(message, MessageBoxType.Warning);
        }

        private void DebugError(string message)
        {
            if (OnErrorDelegate != null)
                OnErrorDelegate(message);
            else
            {
                System.Console.ForegroundColor = ConsoleColor.DarkRed;
                System.Console.WriteLine(message);
            }
            //else if (ShowErrorDialog)
            //    DisplayMessageBox(message, MessageBoxType.Error);
        }
        
        
        
    }
}
