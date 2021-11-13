using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Text;
using System.Timers;


namespace CSharp.Mok.WinSocket
{
	public delegate void ConnectDelegate(object sender, SockEventArgs e);
	public delegate void DisconnectDelegate(object sender,SockEventArgs e);
	public delegate void SendDelegate(object sender, SockEventArgs e);
	public delegate void ReceiveDelegate(object sender, SockEventArgs e);
	public delegate void CloseDelegate(object sender, SockEventArgs e);
	public delegate void SockErrDelegate(object sender, SockEventArgs e);
	public delegate void MessageDelegate(object sender, SockEventArgs e);
	public delegate void SendingDelegate(object sender, SockEventArgs e);
	public delegate void RecvFileDelegate(object sender, SockEventArgs e);
    
	public class SockEventArgs:EventArgs
	{
		private string msg;
		private double bytesend;
		private string UserName;
		private int SockRef;
	   
		public SockEventArgs(string msg):base()
		{
			this.msg = msg;
		} 
		
		public string RemoteUserName
		{
			get {return UserName;}
			set {UserName=value;}
		}

		public string SockMsg 
		{
			get {return msg;}
			set {msg=value;}  
		}

		public double ByteSend 
		{
			get {return bytesend;}
			set {bytesend =value;}  
		}

		public int SocketRef 
		{
			get {return SockRef;}
			set {SockRef=value;}
		}
       
	}
	
	class WSocket
	{  
		public class StateObject
		{
			public Socket workSocket=null;
			public const int BufferSize = 256;
			public byte[] buffer= new byte[BufferSize];
			public StringBuilder sb = new StringBuilder();
		}
		public Socket Soc; 
		//Events Defination
		public event ConnectDelegate OnConnected;
		public event DisconnectDelegate OnDisconnected;
		public event SendDelegate OnReadySend;
		public event ReceiveDelegate OnReadyReceive;
		public event CloseDelegate OnConnectClose;
		public event SockErrDelegate OnSocketError;
		public event MessageDelegate OnSockMessage;
		public event SendingDelegate OnSendingFile;
		public event RecvFileDelegate OnReceiveFile;

		//Socket Event message Classs
		private SockEventArgs sockArgs = new SockEventArgs("");
		//Variable
		private AddressFamily addressFamily;
		private SocketType socketType;
		private ProtocolType protocolType;
		private EndPoint remoteEP;
		private int nRefNo;
		private string UserName;

		//Status Var
		private bool lSocketClosed;


		//Socket Var
		public StringBuilder response = new StringBuilder();

		//Check Command Var
		
		//Sending File
		private FileStream SentFile;
		private int  nTtlByteSend; 
		private bool bSendFile;
		private System.Timers.Timer SendfileTimer;

        //Receiving file
		private FileStream RecvFile;
		private int nRecFileSize;
		private int nWritebyte;
		private bool bRecvFile;
		private bool bClosedRecvFile;
		private string RecvFilename;
		private System.Timers.Timer RecvfileTimer;
		//private int RecvCallbackLoop;

		public WSocket(AddressFamily addressFamily, SocketType socketType,ProtocolType protocolType)
		{
			Soc = new Socket(addressFamily,socketType,protocolType);
			this.addressFamily = addressFamily;
			this.socketType    = socketType;
			this.protocolType  = protocolType;   
			
			bRecvFile =false;
		}
        
		public int SockRefNo
		{
			get {return nRefNo;}
			set {nRefNo=value;}
		}

		public string RemoteUserName
		{
			get {return UserName;}
			set {UserName=value;}
		}
		
		public void AsyConnectTCIP(EndPoint remoteEP)
		{
			this.remoteEP =remoteEP;
			AsyncCallback beginConnectCallback = new AsyncCallback(ConnectCallBack);		
			Soc.BeginConnect(remoteEP,beginConnectCallback,Soc);
		}

		private  void ConnectCallBack(IAsyncResult ar)
		{
			try
			{  
				Socket soc = (Socket)ar.AsyncState;
				soc.EndConnect(ar);      
				if (soc.Connected)
				{   
					sockArgs.SocketRef=SockRefNo;
					sockArgs.RemoteUserName = RemoteUserName;
					lSocketClosed = false;
					if (OnConnected!=null)
						OnConnected(this, sockArgs);
				}
				else
				{
					if (OnDisconnected!=null)
						OnDisconnected(this,sockArgs );
				}
			}
			catch (Exception e)
			{
				RaiseSockErrEvent("Connect : "+e.Message);
				CloseSocket();
			}
		}

		
		public void DisConnectTCIP()
		{  
			try
			{ 
				CloseSocket();
				if (OnDisconnected!=null)
					OnDisconnected(this, sockArgs);
			}
			catch(Exception e)
			{
				RaiseSockErrEvent("Disconnect : "+e.Message);
				CloseSocket();
			    
			}
		}

		public void SendData(string data)
		{
			try
			{
				byte[] byteData = Encoding.ASCII.GetBytes(data);
				Soc.BeginSend(byteData,0,byteData.Length,SocketFlags.None, 
					new AsyncCallback(SendCallback),Soc);
			}
			catch(Exception e)
			{
				//MessageBox.Show(e.Message);
				RaiseSockErrEvent("Send : "+e.Message);
				CloseSocket();
			}

		}
		
		private void SendCallback(IAsyncResult ar)
		{
			try
			{
				Socket soc = (Socket)ar.AsyncState;
				int byteSend = soc.EndSend(ar);
				if (OnReadySend!=null)
					OnReadySend(this, sockArgs);
			}
			catch(Exception e)
			{
				RaiseSockErrEvent("Send : "+e.Message);
				CloseSocket();
			}
		}

		public void ReceiveData()
		{
			try
			{
				StateObject state = new StateObject();
				state.workSocket = Soc;
				Soc.BeginReceive(state.buffer,0,StateObject.BufferSize,SocketFlags.None,
					new AsyncCallback(ReceiveCallback),state);
			}
			catch(Exception e)
			{
				RaiseSockErrEvent("Receive : "+e.Message);
				CloseSocket();
			}
		}

		private void ReceiveCallback(IAsyncResult ar)
		{
			try
			{
				StateObject state = (StateObject)ar.AsyncState;
				Socket soc = state.workSocket;
				int byteRead = soc.EndReceive(ar);
				if (byteRead > 0)
				{
					if(bRecvFile)
					{ 
					   //RecvCallbackLoop +=1;	 
					   StoreToRecvFile(state.buffer,byteRead);
					}
					else
					{
						response.Append(Encoding.ASCII.GetString(state.buffer,0,byteRead));
						CheckCommand();
						if (OnReadyReceive!=null)
							OnReadyReceive(this,sockArgs);
					}
					
					soc.BeginReceive(state.buffer,0,StateObject.BufferSize,SocketFlags.None,
						new AsyncCallback(ReceiveCallback),state);
				}
				else CloseSocket();
				
			}
			catch(Exception e)
			{
				RaiseSockErrEvent("Receive : "+e.Message);
				CloseSocket();
			}
		}
		public void CloseSocket()
		{
			//Socket is closed, need not to closed again
			//cause if will raised the OnConnectClose event again

			//if the sent file still opening Close it.
			//cause the connection is down.
			if (bSendFile)
				CloseSendFile();

			if (bRecvFile)
			    CloseRecvFile();

			if (lSocketClosed)
				return;

			try
			{  
				lSocketClosed = true;
				if (Soc!=null)
				{
					if (Soc.Connected)
					{
						Soc.Shutdown(SocketShutdown.Both); 
						Soc.Close(); 
					}
				}
               
			}
			catch (ObjectDisposedException err) 
			{
				RaiseSockErrEvent("Close : "+err.Message);
			}
			
			if (OnConnectClose!=null)
				OnConnectClose(this,sockArgs);
			
		}
 
		private void RaiseSockErrEvent(string errMsg)
		{
			sockArgs.SockMsg = errMsg;
			sockArgs.SocketRef=SockRefNo;
			if (OnSocketError!=null)
				OnSocketError(this,sockArgs);
		}

		//Raise event -set the user define Args
		private void RaiseMessageEvent(string Msg)
		{
			SockEventArgs Args = new SockEventArgs("");
			Args.SockMsg = Msg;
			Args.SocketRef=SockRefNo;
			if (OnSockMessage!=null)
				OnSockMessage(this,Args);
		}

		private void RaiseSendingFileEvent(string Msg,int byteSend)
		{
			//SockEventArgs Args = new SockEventArgs("");
			sockArgs.SockMsg = Msg;
			sockArgs.ByteSend = (double)byteSend;
			sockArgs.SocketRef=SockRefNo;
			if (OnSendingFile!=null)
				OnSendingFile(this,sockArgs);
		}

		private void RaiseReceivingEvent(string Msg,int byteSend)
		{
			//SockEventArgs Args = new SockEventArgs("");
			sockArgs.SockMsg = Msg;
			sockArgs.ByteSend = (double)byteSend;
			sockArgs.SocketRef=SockRefNo;
			if (OnReceiveFile!=null)
				OnReceiveFile(this,sockArgs);
		}

		//................................................
		//      Sending File function 
		//................................................
		public void SendFile(string filename)
		{
			try
			{
				SentFile = new FileStream(filename, FileMode.Open, FileAccess.Read); 
				int nPos = filename.LastIndexOf("\\");
				if (nPos > -1)
					filename = filename.Substring(nPos+1);
				string fileinfo;
				fileinfo="\x01\x53"+SentFile.Length.ToString()+"\x03"+filename+"\x04";
				bSendFile = true;
				SendData(fileinfo);
				SetSendFileTimer();
			}
			catch(Exception err)
			{
				CloseSendFile();
				RaiseSockErrEvent("File : "+filename+" Error:"+err.Message);
				return;
			}
		}

		private void SetSendFileTimer()
		{
		    SendfileTimer = new System.Timers.Timer();
			SendfileTimer.Elapsed+=new ElapsedEventHandler(OnSendFileTimedEvent);
			SendfileTimer.Interval=30000; //30 seconds
			SendfileTimer.Enabled=true;
		}

		private void OnStartSendFileTimer()
		{
		   SendfileTimer.Start();
           //RaiseMessageEvent("Timer Start");
		}

		private void OnStopSendFileTimer()
		{
			SendfileTimer.Stop();
			//RaiseMessageEvent("Timer Stop");
		}

		private void OnCloseSendFileTimer()
		{
			SendfileTimer.Close();
			//RaiseMessageEvent("Timer Closed");
		}

		private void OnSendFileTimedEvent(object source, ElapsedEventArgs e)
		{
            //no response after 30 seconds...
    		//so we just close the file and communication
            OnStopSendFileTimer();
			SendfileTimer.Close();
			RaiseSockErrEvent("Sending : Time-out for sending, Task cancel and connection closed");
			CloseSocket();
		}


		private void CloseSendFile()
		{
			try
			{  
				if (SendfileTimer!=null)
					OnCloseSendFileTimer();

				bSendFile = false;
				if (SentFile !=null)
				{
					SentFile.Close();
				    RaiseMessageEvent("File is Closed");
				}
			}
			catch(Exception err)
			{
			   RaiseMessageEvent(err.Message);
			}
		}

		private void SendbyteData(byte[] data,int dataLen)
		{
			try
			{
				Soc.BeginSend(data,0,dataLen,SocketFlags.None, 
					new AsyncCallback(SendFileCallback),Soc);
			}
			catch(Exception e)
			{
		
				RaiseSockErrEvent("Send : "+e.Message);
				CloseSocket();
			}

		}
		
		private void SendFileCallback(IAsyncResult ar)
		{
			try
			{
				Socket soc = (Socket)ar.AsyncState;
				int byteSend = soc.EndSend(ar);
				nTtlByteSend += byteSend;
				RaiseSendingFileEvent(SentFile.Length.ToString(),nTtlByteSend);
				
				//Finish Sending a block, stop Timer
				OnStopSendFileTimer();
				if( SentFile.Length!=SentFile.Position)
					StartSendFile();
				else
				{
				   CloseSendFile();
				}
				
			}
			catch(Exception e)
			{
				RaiseSockErrEvent("Send : "+e.Message);
			}
		}

		private void StartSendFile()
		{
			byte[] buff= new byte[513];
			try
			{
				if( SentFile.Length!=SentFile.Position)
				{
					OnStartSendFileTimer();
					int nRead= SentFile.Read(buff,0,512);
					if (nRead > 0)
						SendbyteData(buff,nRead);
				}
			}
			catch(Exception err)
			{
				RaiseSockErrEvent("Send File: Error:"+err.Message);
			}
	  	}

		//................................................
		//         Check Command 
		//................................................
		private void CheckCommand()
		{
			int nPos1;
			string strCmd = response.ToString();
            
			//Sending file status
			if ((nPos1=strCmd.IndexOf("\x02\x06"))>-1)
			{
				SentFileStatus(strCmd,nPos1) ;
				return;
			}

			//File is comming..file info
			if ((nPos1=strCmd.IndexOf("\x01\x53"))>-1)
			{
				IncommingFileInfo(strCmd,nPos1) ;
				return;
			}

            //normal chating message
            response.Remove(0,strCmd.Length);
			RaiseMessageEvent(strCmd);
           
		}

		private void SentFileStatus(string strCmd,int nPos)
		{
			int nPos2=strCmd.IndexOf("\x03");
			int nCommand; 
			
			if (nPos2>-1)
				nCommand = Convert.ToInt32(strCmd.Substring(nPos+2,nPos2-nPos-2));
			else return; //back, cause the command string not fully received yet
            
			//Need to stop the timer, cause the sending response is back
			OnStopSendFileTimer();

			switch(nCommand)
			{
				case 2101:
					RaiseMessageEvent("File is send.. ");
					break;
				case 3100:
					nTtlByteSend =0;
					StartSendFile();
					break;
				case 3103:
				case 3104: 
					if (SentFile!=null)
					{
						RaiseMessageEvent("Fail to send file "+SentFile.Name);
						SentFile.Close();//Remote PC reject this file, so close it.
					}
					break;
			} 
 	
			if (nPos2 > 1)
				response.Remove(nPos,nPos2-nPos+1);
		}
		
		//Receiveing File
		private void IncommingFileInfo(string strCmd,int nPos1) 
		{
          int nPos2=strCmd.IndexOf("\x03");
		  int nPos3=strCmd.IndexOf("\x04");
          string cmd;
            
		    if ((nPos2==-1) || (nPos3==-1)) return;
			response.Remove(nPos1,nPos3-nPos1+1);
	        
			RecvFilename = Directory.GetCurrentDirectory()+@"\"+strCmd.Substring(nPos2+1,nPos3-nPos2-1); 		  
			nRecFileSize =Convert.ToInt32(strCmd.Substring(nPos1+2,nPos2-nPos1-2));
			RaiseMessageEvent(RecvFilename); 
            
			if (nRecFileSize==0)
			{
				cmd="\x02\x06\x33\x31\x30\x33\x03";
				SendData(cmd);
				return ;
			}
			try
			{
				RecvFile = new FileStream(RecvFilename, FileMode.Create, FileAccess.Write,FileShare.None); 
			}
			catch(Exception err)
			{
				cmd="\x02\x06\x33\x31\x30\x33\x03";
				SendData(cmd);
				RaiseMessageEvent("RecvFile  : "+RecvFilename+" Error:"+err.Message);
				return;
			}
			cmd="\x02\x06\x33\x31\x30\x30\x03";
			SendData(cmd); 
			//Set the timer, if no response in 60 second, stop the receiving process
			SetRecvFileTimer();

			bClosedRecvFile = false;
			bRecvFile       = true;
			nWritebyte      = 0;
		}

		private void StoreToRecvFile(byte[] data,int nLen)
		{
			nWritebyte +=nLen;
			try
			{
				OnStopRecvFileTimer();
				RecvFile.BeginWrite(data,0,nLen,new AsyncCallback(FileWriteCallback),RecvFile);
			}
			catch(Exception err)
			{
				RaiseMessageEvent("Recv BFile: Error:"+err.Message);
			}
		}

		private void FileWriteCallback(IAsyncResult ar)
		{
			try
			{   
				FileStream file =(FileStream)ar.AsyncState;
				file.EndWrite(ar);
				OnStartRecvFileTimer();
				RaiseReceivingEvent(nRecFileSize.ToString(),nWritebyte);
				if (nWritebyte >=nRecFileSize)
				{  
					bRecvFile  = false;
				   	CloseRecvFile();
				}
			}
			catch(Exception err)
			{
				RaiseMessageEvent("Recv File2: Error:"+err.Message);
			}
		}
		private void CloseRecvFile()
		{
			if (bClosedRecvFile) return;
			try
			{  
				OnCloseRecvFileTimer();
				bRecvFile  = false;
				nWritebyte = 0;
				nRecFileSize=0;
		        RecvFilename="";
			    bClosedRecvFile = true;	
				if (RecvFile !=null)
				{
					RecvFile.Close();
			        RaiseMessageEvent("Recv File is Closed.");
			
				}

			    SendData("\x02\x06\x32\x31\x30\x31\x03");
               
			}
			catch(Exception err)
			{
				RaiseMessageEvent(err.Message);
			}
		}

		private void SetRecvFileTimer()
		{
			RecvfileTimer = new System.Timers.Timer();
			RecvfileTimer.Elapsed+=new ElapsedEventHandler(OnRecvFileTimedEvent);
			RecvfileTimer.Interval=60000; //60 seconds
			RecvfileTimer.Enabled=true;
		}
		private void OnStartRecvFileTimer()
		{
			RecvfileTimer.Start();
			RaiseMessageEvent("Timer Start");
		}

		private void OnStopRecvFileTimer()
		{
			RecvfileTimer.Stop();
			RaiseMessageEvent("Timer Stop");
		}

		private void OnCloseRecvFileTimer()
		{
			RecvfileTimer.Close();
			RaiseMessageEvent("Timer Closed");
		}

		private void OnRecvFileTimedEvent(object source, ElapsedEventArgs e)
		{
			OnStopRecvFileTimer();
			RecvfileTimer.Close();
			RaiseSockErrEvent("Receiving: Time-out for file receiving, Task cancel and connection closed");
			CloseRecvFile();
		}

	} //end WSocket Class
   
	

	
}
