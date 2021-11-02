/*
 * Created by SharpDevelop.
 * User: GTAtester
 * Date: 2010-05-28
 * Time: 13:54
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Threading;
using System.Net;
using System.Text;


namespace Communication
{
    public class Threaded_TcpServerClient
    {
        public Action<Threaded_TcpServerClient, string> DebugError_Delegate;
        public Action<Threaded_TcpServerClient, string> DebugWarning_Delegate;

        public Action<Threaded_TcpServerClient> Connected_Delegate;
        public Action<Threaded_TcpServerClient> Disposed_Delegate;

        public Action<Threaded_TcpServerClient, string> MessageReceived_Delegate;

        public Thread thread;
        public TcpClient tcpClient;
        public NetworkStream clientStream;
        public bool Connected = false;

        public string MessageStartIdentifier = null;
        public string MessageEndIdentifier = null;


        public StringBuilder sbRxTemp;
        private string messageRxTemp = "";
        public int indexOfStartIdentifier = -1;
        public int indexOfEndIdentifier = -1;

        private string CreateNewExceptionMessageStart = "Exception when creating new Threaded_TcpServerClient: ";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="newTcpClient"></param>
        /// <param name="MessageStartIdentifier"> this don't have to be set (non-empty or non-null)/param>
        /// <param name="MessageEndIdentifier">if this is "not set"(empty or null) the message parts is returned raw directly.</param>
        /// <param name="DebugError_Handler"></param>
        /// <param name="DebugWarning_Handler"></param>
        /// <param name="Connected_Handler"></param>
        /// <param name="Disposed_Handler"></param>
        /// <param name="MessageReceived_Handler"></param>
        public Threaded_TcpServerClient(TcpClient newTcpClient,
                                        string MessageStartIdentifier,
                                        string MessageEndIdentifier,
                                        Action<Threaded_TcpServerClient, string> DebugError_Handler,
                                        Action<Threaded_TcpServerClient, string> DebugWarning_Handler,
                                        Action<Threaded_TcpServerClient> Connected_Handler,
                                        Action<Threaded_TcpServerClient> Disposed_Handler,
                                        Action<Threaded_TcpServerClient, string> MessageReceived_Handler)
        {
            if (MessageReceived_Handler == null)
                throw new Exception(CreateNewExceptionMessageStart + "MessageReceived_Handler cannot be null");
            if (Connected_Handler == null)
                throw new Exception(CreateNewExceptionMessageStart + "Connected_Handler cannot be null");
            if (DebugError_Handler == null)
                throw new Exception(CreateNewExceptionMessageStart + "DebugError_Handler cannot be null");
            if (Disposed_Handler == null)
                throw new Exception(CreateNewExceptionMessageStart + "Disposed_Handler cannot be null");

            this.tcpClient = newTcpClient;
            this.MessageStartIdentifier = MessageStartIdentifier;
            this.MessageEndIdentifier = MessageEndIdentifier;
            DebugError_Delegate = DebugError_Handler;
            DebugWarning_Delegate = DebugWarning_Handler;
            Connected_Delegate = Connected_Handler;

            MessageReceived_Delegate = MessageReceived_Handler;

            

            thread = new Thread(HandleClientComm);
            thread.Start();
        }

        public bool Send(string Message)
        {
            if (Connected)
            {
                ASCIIEncoding encoder = new ASCIIEncoding();
                byte[] buffer = encoder.GetBytes(Message);

                clientStream.Write(buffer, 0, buffer.Length);
                clientStream.Flush();
                return true;
            }
            return false;
        }

        public void Close()
        {
            Connected = false;
            Dispose();
            
        }

        private void HandleClientComm()
        {
            sbRxTemp = new StringBuilder(); // to be effective it need to be created in same thread as used.

           // tcpClient = (TcpClient)client;
            clientStream = tcpClient.GetStream();
            byte[] message = new byte[4096];
            int bytesRead;

            Connected = true;

            while (Connected)
            {
                bytesRead = 0;

                try
                {
                    //blocks until a client sends a message
                    bytesRead = clientStream.Read(message, 0, 4096);
                }
                catch (System.IO.IOException ioex)
                {
                	if (DebugWarning_Delegate != null)
                    	DebugWarning_Delegate(this, "System.IO.IOException:\n" + ioex.ToString());

                }
                catch (SocketException sex)
                {
                	if (DebugWarning_Delegate == null)
                		return;
                    if (sex.SocketErrorCode == SocketError.ConnectionReset)
                        DebugWarning_Delegate(this, "The Connection was closed");
                    else
                        DebugWarning_Delegate(this, "Unknown SocketErrorCode: " + sex.SocketErrorCode.ToString());
                    break;
                }
                /*catch (Exception ex)
                {
                    //a socket error has occured
                    if (DebugError_Delegate != null)
                        DebugError_Delegate(this, "Error while clientStream.Read(message, 0, 4096);\r\n" + ex.ToString());
                    break;
                }*/

                if (bytesRead == 0)
                {
                    Connected = false;
                    //the client has disconnected from the server
                    break;
                }

                //message has successfully been received
                ASCIIEncoding encoder = new ASCIIEncoding();
                messageRxTemp = encoder.GetString(message, 0, bytesRead);
                
                if (MessageReceived_Delegate == null)
                {
                	System.Windows.Forms.MessageBox.Show(messageRxTemp, "TCP server - client message received (unhandled set the MessageReceived_Delegate to avoid this dialog!)");
                	break;
                }
                if (MessageEndIdentifier.IsNullOrEmpty(false)) // dosent matter if StartIdentifier is set
                    MessageReceived_Delegate(this, messageRxTemp); // raw receive
                else 
                {
                    sbRxTemp.Append(messageRxTemp);
                    if (MessageStartIdentifier.IsNullOrEmpty(true))
                    {
                        if (sbRxTemp.TryGetSubstringTo(MessageEndIdentifier, out messageRxTemp))
                            MessageReceived_Delegate(this, messageRxTemp);
                    }
                    else
                    {
                        if (sbRxTemp.TryGetSubstringBetween(MessageStartIdentifier, MessageEndIdentifier, out messageRxTemp))
                        {
                            MessageReceived_Delegate(this, messageRxTemp);
                        }
                    }
                }
                
            }
            Dispose();
        }
        /// <summary>
        /// This also closes the tcpClient connection if active.
        /// </summary>
        private void Dispose()
        {
            if (tcpClient != null)
            {
                try { tcpClient.Close(); }
                catch { }
                tcpClient = null;
            }
            
            if (clientStream != null)
            {
                try { clientStream.Flush(); }
                catch { }
                try { clientStream.Close(); }
                catch { }
                try { clientStream.Dispose(); }
                catch { }
                clientStream = null;
            }
            if (sbRxTemp != null)
            {
                sbRxTemp.Clear();
                sbRxTemp = null;
            }
            MessageReceived_Delegate = null;
            DebugError_Delegate = null;
            Connected_Delegate = null;
            DebugWarning_Delegate = null;
            if (Disposed_Delegate != null)
            {
                Disposed_Delegate(this);
                Disposed_Delegate = null;
            }
        }

    }

	public class TCP_Server
	{
        public delegate void DebugErrorMessageEventHandler(string text);
        public event DebugErrorMessageEventHandler DebugErrorMessageEvent = null;

        public delegate void DebugWarningMessageEventHandler(string text);
        public event DebugWarningMessageEventHandler DebugWarningMessageEvent = null;

        public Action ListeningStarted = null;
        public Action ListeningStopped = null;
        public Action<Threaded_TcpServerClient> ClientConnected = null;

		private TcpListener tcpListener;
    	private Thread listenThread;

        public List<Threaded_TcpServerClient> threadedTcpClients;

        public string MessageStartIdentifier = null;
        public string MessageEndIdentifier = null;

    	public bool Listening = false;

        public delegate void MessageReceivedEventHandler(string text);
        public event MessageReceivedEventHandler MessageReceived = null;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="MessageStartIdentifier">this don't have to be set (non-empty or non-null)</param>
        /// <param name="MessageEndIdentifier">if this is "not set"(empty or null) the message parts is returned raw directly.</param>
        public TCP_Server(string MessageStartIdentifier, string MessageEndIdentifier)
		{
            threadedTcpClients = new List<Threaded_TcpServerClient>(8);
            this.MessageStartIdentifier = MessageStartIdentifier;
            this.MessageEndIdentifier = MessageEndIdentifier;		
		}
        
        public void SendToClients(string message)
        {
        	message = message.Replace("\\r", "\r").Replace("\\n", "\n");
        	for (int i = 0; i < threadedTcpClients.Count; i++)
        	{
        		threadedTcpClients[i].Send(message);
        	}
        }

        private void DebugError(string text)
        {
            if (DebugErrorMessageEvent == null)
                return;
            DebugErrorMessageEvent("TCP_Server Error:" + text);
        }

        private void DebugWarning(string text)
        {
            if (DebugWarningMessageEvent == null)
                return;
            DebugWarningMessageEvent("TCP_Server Warning:" + text);
        }

		public void StartListen(string port)
		{
			if (port.StartsWith("TCP"))
			{
				port = port.Substring(3);
			}
            try
            {
                this.tcpListener = new TcpListener(IPAddress.Any, Convert.ToInt32(port));
                
                this.listenThread = new Thread(new ThreadStart(ListenForClients));
                this.listenThread.Start();
            }
            catch (Exception ex)
            {
                DebugError("exception while StartListen(" + port + ")\n" + ex.ToString());
            }
		}
		public void Stop()
		{
            if (tcpListener == null)
                return;
            Listening = false;
            try
            {
                tcpListener.Stop();
            }
            catch (Exception ex)
            {
                DebugError("exception while StopListen()\n" + ex.ToString());
            }
            for (int i = 0; i < threadedTcpClients.Count; i++)
            {
            	if (threadedTcpClients[i] != null)
            		threadedTcpClients[i].Close();
            }
		}

        private void ThreadedTcpServerClient_DebugError(Threaded_TcpServerClient ttsc, string message)
        {
            DebugError(message);
        }

        private void ThreadedTcpServerClient_DebugWarning(Threaded_TcpServerClient ttsc, string message)
        {
            DebugWarning(message);
        }

        private void ThreadedTcpServerClient_MessageReceived(Threaded_TcpServerClient ttsc, string message)
        {
            MessageReceived(message);
        }

        private void ThreadedTcpServerClient_Connected(Threaded_TcpServerClient ttsc)
        {
        	if (ClientConnected != null)
        		ClientConnected(ttsc);
        	else
            	DebugWarning("new tcp client connected @ " + ttsc.tcpClient.Client.LocalEndPoint.ToString());
        }

        private void ThreadedTcpServerClient_Disposed(Threaded_TcpServerClient ttsc)
        {
            threadedTcpClients.Remove(ttsc);
            ttsc = null;
            DebugWarning("ThreadedTcpServerClient_Disposed"); 
        }

		private void ListenForClients()
		{
			try
            {
			    this.tcpListener.Start();
			    Listening = true;

                if (ListeningStarted != null)
                    ListeningStarted();
			}
            catch (SocketException sEx)
            {
				Listening = false;
                DebugError("ListenForClients this.tcpListener.Start(); fail\n" + sEx.ToString());
                return;
			}
            TcpClient newClient;

            while (Listening && Try_AcceptNewTcpClient(out newClient))
			{
                
                try
                {
                    threadedTcpClients.Add(
                         new Threaded_TcpServerClient(newClient,
                                                       MessageStartIdentifier,
                                                       MessageEndIdentifier,
                                                       ThreadedTcpServerClient_DebugError,
                                                       ThreadedTcpServerClient_DebugWarning,
                                                       ThreadedTcpServerClient_Connected,
                                                       ThreadedTcpServerClient_Disposed,
                                                       ThreadedTcpServerClient_MessageReceived));
                }
                catch (Exception ex)
                {
                    DebugError("exception while create new Threaded_TcpServerClient:\n" + ex.ToString());
                }
			}
            
            if (ListeningStopped != null)
                ListeningStopped();

            Do_StopListening_Cleanup();

		}
        private bool Try_AcceptNewTcpClient(out TcpClient newTcpClient)
        {
            newTcpClient = null;
            try
            {
                //blocks until a client has connected to the server
                newTcpClient = this.tcpListener.AcceptTcpClient();
                return true;
            }
            catch (SocketException sEx)
            {
                if (newTcpClient != null)
                    DebugError("(newTcpClient != null) @ Try_AcceptNewTcpClient exception!!!");

                if (sEx.SocketErrorCode == SocketError.Interrupted)
                {
                    DebugWarning("The tcpListener has been closed!");
                    if (Listening == false)
                        DebugWarning("  because of Listening was stopped");
                }
                else
                {
                    DebugError("@this.tcpListener.AcceptTcpClient() throwed unhandled SocketException\n" + sEx);
                }
            }
            catch (InvalidOperationException ivoEx)
            {
                DebugError("@this.tcpListener.AcceptTcpClient() throwed InvalidOperationException\n" + ivoEx);
            }
            return false;
        }
        private void Do_StopListening_Cleanup()
        {
            tcpListener = null;
            for (int i = 0; i < threadedTcpClients.Count; i++)
            {
                threadedTcpClients[i].Close(); // only need to do this
            }
            
        }
		
	}

}
