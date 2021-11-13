using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace CSharp.Mok.WinSocket
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button button1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.TextBox txtIP;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;

		//My own Var
        private WSocket mySoc;
		private WSocket [] SocClient;
		private System.Windows.Forms.Label label5;
		private WSocket ListenSoc;
		private Thread serverThread;
		private int nSocRef;
		private System.Windows.Forms.Label txtSoc;
		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private const int MAX_SOCKET= 100;
		private System.Windows.Forms.TextBox txtPort;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.TextBox txtCPort;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label txtClose; 
		public static ManualResetEvent allDone = new ManualResetEvent(false);
		private System.Windows.Forms.TextBox txtFileName;
		private System.Windows.Forms.OpenFileDialog openFile;
		private System.Windows.Forms.Button butFileName;
		private System.Windows.Forms.Button bSendFile;
		private System.Windows.Forms.ProgressBar prgBar;
		private System.Windows.Forms.Label txtPer;
        
		//Close counter
		private int nClose;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
            nClose =0;
			nSocRef =0;
			SocClient = new WSocket[MAX_SOCKET];
			//serverThread = new Thread(new ThreadStart(startListen));
			//serverThread.Start();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.txtIP = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.txtSoc = new System.Windows.Forms.Label();
			this.listView1 = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.txtPort = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.button4 = new System.Windows.Forms.Button();
			this.txtCPort = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.txtClose = new System.Windows.Forms.Label();
			this.txtFileName = new System.Windows.Forms.TextBox();
			this.openFile = new System.Windows.Forms.OpenFileDialog();
			this.butFileName = new System.Windows.Forms.Button();
			this.bSendFile = new System.Windows.Forms.Button();
			this.prgBar = new System.Windows.Forms.ProgressBar();
			this.txtPer = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// textBox1
			// 
			this.textBox1.BackColor = System.Drawing.Color.SeaShell;
			this.textBox1.Location = new System.Drawing.Point(8, 24);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(224, 88);
			this.textBox1.TabIndex = 0;
			this.textBox1.Text = "";
			this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
			// 
			// button1
			// 
			this.button1.BackColor = System.Drawing.Color.SteelBlue;
			this.button1.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.button1.Location = new System.Drawing.Point(10, 246);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(96, 24);
			this.button1.TabIndex = 1;
			this.button1.Text = "Connect";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.BackColor = System.Drawing.Color.SteelBlue;
			this.button2.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.button2.Location = new System.Drawing.Point(138, 246);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(96, 24);
			this.button2.TabIndex = 2;
			this.button2.Text = "Disconnect";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button3
			// 
			this.button3.BackColor = System.Drawing.Color.SteelBlue;
			this.button3.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.button3.Location = new System.Drawing.Point(8, 120);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(224, 24);
			this.button3.TabIndex = 3;
			this.button3.Text = "Send";
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// listBox1
			// 
			this.listBox1.BackColor = System.Drawing.Color.AliceBlue;
			this.listBox1.Location = new System.Drawing.Point(240, 24);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(280, 277);
			this.listBox1.TabIndex = 6;
			// 
			// txtIP
			// 
			this.txtIP.BackColor = System.Drawing.Color.SeaShell;
			this.txtIP.Location = new System.Drawing.Point(10, 222);
			this.txtIP.Name = "txtIP";
			this.txtIP.Size = new System.Drawing.Size(144, 20);
			this.txtIP.TabIndex = 7;
			this.txtIP.Text = "";
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.SkyBlue;
			this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label1.ForeColor = System.Drawing.Color.IndianRed;
			this.label1.Location = new System.Drawing.Point(6, 370);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(654, 48);
			this.label1.TabIndex = 8;
			// 
			// label2
			// 
			this.label2.ForeColor = System.Drawing.SystemColors.Desktop;
			this.label2.Location = new System.Drawing.Point(10, 206);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(144, 16);
			this.label2.TabIndex = 9;
			this.label2.Text = "Hostname/Host IP Address";
			// 
			// label3
			// 
			this.label3.ForeColor = System.Drawing.SystemColors.Desktop;
			this.label3.Location = new System.Drawing.Point(8, 8);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(136, 14);
			this.label3.TabIndex = 10;
			this.label3.Text = "Type the Message here";
			// 
			// label4
			// 
			this.label4.ForeColor = System.Drawing.SystemColors.Desktop;
			this.label4.Location = new System.Drawing.Point(240, 8);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(136, 16);
			this.label4.TabIndex = 11;
			this.label4.Text = "Message List";
			// 
			// label5
			// 
			this.label5.ForeColor = System.Drawing.SystemColors.Desktop;
			this.label5.Location = new System.Drawing.Point(528, 8);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(128, 16);
			this.label5.TabIndex = 13;
			this.label5.Text = "Connected User";
			// 
			// txtSoc
			// 
			this.txtSoc.Location = new System.Drawing.Point(10, 278);
			this.txtSoc.Name = "txtSoc";
			this.txtSoc.Size = new System.Drawing.Size(224, 24);
			this.txtSoc.TabIndex = 14;
			// 
			// listView1
			// 
			this.listView1.BackColor = System.Drawing.Color.PowderBlue;
			this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						this.columnHeader1,
																						this.columnHeader2,
																						this.columnHeader3});
			this.listView1.ForeColor = System.Drawing.SystemColors.HotTrack;
			this.listView1.FullRowSelect = true;
			this.listView1.Location = new System.Drawing.Point(526, 52);
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(136, 248);
			this.listView1.TabIndex = 15;
			this.listView1.View = System.Windows.Forms.View.Details;
			this.listView1.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "RefNo";
			this.columnHeader1.Width = 20;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "IP";
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Name";
			// 
			// txtPort
			// 
			this.txtPort.Location = new System.Drawing.Point(152, 152);
			this.txtPort.Name = "txtPort";
			this.txtPort.Size = new System.Drawing.Size(80, 20);
			this.txtPort.TabIndex = 16;
			this.txtPort.Text = "998";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(70, 154);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(80, 16);
			this.label6.TabIndex = 17;
			this.label6.Text = "Listen on Port";
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(12, 150);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(52, 20);
			this.button4.TabIndex = 18;
			this.button4.Text = "Listen";
			this.button4.Click += new System.EventHandler(this.button4_Click_1);
			// 
			// txtCPort
			// 
			this.txtCPort.Location = new System.Drawing.Point(160, 222);
			this.txtCPort.Name = "txtCPort";
			this.txtCPort.Size = new System.Drawing.Size(72, 20);
			this.txtCPort.TabIndex = 19;
			this.txtCPort.Text = "999";
			// 
			// label7
			// 
			this.label7.ForeColor = System.Drawing.SystemColors.Desktop;
			this.label7.Location = new System.Drawing.Point(528, 26);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(128, 26);
			this.label7.TabIndex = 20;
			this.label7.Text = "Double click the user to disconnect it";
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(162, 208);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(66, 14);
			this.label8.TabIndex = 21;
			this.label8.Text = "Port No";
			// 
			// txtClose
			// 
			this.txtClose.Location = new System.Drawing.Point(16, 178);
			this.txtClose.Name = "txtClose";
			this.txtClose.Size = new System.Drawing.Size(136, 20);
			this.txtClose.TabIndex = 22;
			// 
			// txtFileName
			// 
			this.txtFileName.Location = new System.Drawing.Point(94, 316);
			this.txtFileName.Name = "txtFileName";
			this.txtFileName.Size = new System.Drawing.Size(426, 20);
			this.txtFileName.TabIndex = 23;
			this.txtFileName.Text = "";
			// 
			// butFileName
			// 
			this.butFileName.Location = new System.Drawing.Point(10, 316);
			this.butFileName.Name = "butFileName";
			this.butFileName.Size = new System.Drawing.Size(80, 22);
			this.butFileName.TabIndex = 24;
			this.butFileName.Text = "FileName";
			this.butFileName.Click += new System.EventHandler(this.butFileName_Click);
			// 
			// bSendFile
			// 
			this.bSendFile.Location = new System.Drawing.Point(528, 316);
			this.bSendFile.Name = "bSendFile";
			this.bSendFile.Size = new System.Drawing.Size(128, 22);
			this.bSendFile.TabIndex = 25;
			this.bSendFile.Text = "Send File";
			this.bSendFile.Click += new System.EventHandler(this.bSendFile_Click);
			// 
			// prgBar
			// 
			this.prgBar.Location = new System.Drawing.Point(94, 340);
			this.prgBar.Name = "prgBar";
			this.prgBar.Size = new System.Drawing.Size(426, 23);
			this.prgBar.Step = 1;
			this.prgBar.TabIndex = 26;
			// 
			// txtPer
			// 
			this.txtPer.Location = new System.Drawing.Point(524, 342);
			this.txtPer.Name = "txtPer";
			this.txtPer.Size = new System.Drawing.Size(66, 22);
			this.txtPer.TabIndex = 27;
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.Color.PaleTurquoise;
			this.ClientSize = new System.Drawing.Size(666, 423);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.txtPer,
																		  this.prgBar,
																		  this.bSendFile,
																		  this.butFileName,
																		  this.txtFileName,
																		  this.txtClose,
																		  this.label8,
																		  this.label7,
																		  this.txtCPort,
																		  this.button4,
																		  this.label6,
																		  this.txtPort,
																		  this.listView1,
																		  this.txtSoc,
																		  this.label5,
																		  this.label4,
																		  this.label3,
																		  this.label2,
																		  this.label1,
																		  this.txtIP,
																		  this.listBox1,
																		  this.button3,
																		  this.button2,
																		  this.button1,
																		  this.textBox1});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "Form1";
			this.Text = "Socket : Chat";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.Form1_Closing);
			this.Load += new System.EventHandler(this.Form1_Load);
			this.Closed += new System.EventHandler(this.Form1_Closed);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
			
			//InitSocket(ref mySoc);
		}

		public void startListen()
		{
			int nPort = Convert.ToInt32(txtPort.Text);
			
			IPEndPoint ipLocalEndPoint;
			try
			{
				IPAddress ipAddress = Dns.Resolve("localhost").AddressList[0];
				ipLocalEndPoint = new IPEndPoint(ipAddress, nPort); //Listen at Port 999
			}
			catch(SocketException socErr )
			{
				label1.Text=socErr.Message;
				return;
			}
           
			try
			{
				ListenSoc = new WSocket(AddressFamily.InterNetwork, SocketType.Stream,ProtocolType.Tcp );
				ListenSoc.Soc.Bind(ipLocalEndPoint);
				ListenSoc.Soc.Listen(100);
				while (true)
				{
					allDone.Reset();
					ListenSoc.Soc.BeginAccept(new AsyncCallback(AcceptCallback),ListenSoc);
					allDone.WaitOne();

				}

			}
			catch(Exception err) 
			{
				label1.Text =err.Message;
			}
		}

		public void AcceptCallback(IAsyncResult ar) 
		{
			try
			{
				allDone.Set();
				WSocket listener = (WSocket) ar.AsyncState;
				int nSoc = GetAvailbleSocket();
				SocClient[nSoc].Soc = (Socket)ListenSoc.Soc.EndAccept(ar);
				
				SocClient[nSoc].SockRefNo = nSocRef;
				SocClient[nSoc].RemoteUserName = txtIP.Text;
				SocClient[nSoc].OnConnected += new ConnectDelegate(OnConnected);
				SocClient[nSoc].OnDisconnected += new DisconnectDelegate(OnDisconnected);
				SocClient[nSoc].OnReadyReceive += new ReceiveDelegate(OnReceive);
				SocClient[nSoc].OnReadySend += new SendDelegate(OnReadySend);
				SocClient[nSoc].OnConnectClose += new CloseDelegate(OnCloseRemote);
                SocClient[nSoc].OnSockMessage += new MessageDelegate(OnSockMessage);
				SocClient[nSoc].OnSendingFile += new  SendingDelegate(OnSending);
                SocClient[nSoc].OnReceiveFile += new RecvFileDelegate(OnSending);

				SocClient[nSoc].ReceiveData();  
				ListViewItem item = new ListViewItem();
				item.Text = nSoc.ToString();
				item.SubItems.Add(SocClient[nSoc].Soc.RemoteEndPoint.ToString());
				item.SubItems.Add(txtIP.Text);
			  
				listView1.Items.Add(item);

			}
			catch(Exception err) 
			{
				
				label1.Text ="Accept :"+ err.Message +err.Source.ToString();
			}
		}



		private void InitSocket(ref WSocket Soc,int nSocRef)
		{
			try
			{
				Soc = new WSocket(AddressFamily.InterNetwork, SocketType.Stream,ProtocolType.Tcp );
				Soc.SockRefNo = nSocRef;
				Soc.RemoteUserName = txtIP.Text;
				Soc.OnConnected += new ConnectDelegate(OnConnected);
				Soc.OnDisconnected += new DisconnectDelegate(OnDisconnected);
				Soc.OnReadyReceive += new ReceiveDelegate(OnReceive);
				Soc.OnReadySend += new SendDelegate(OnReadySend);
				Soc.OnConnectClose += new CloseDelegate(OnCloseRemote);
				Soc.OnSocketError += new SockErrDelegate(OnSocketError);
				Soc.OnSockMessage += new MessageDelegate(OnSockMessage);
				Soc.OnSendingFile += new SendingDelegate(OnSending);
				Soc.OnReceiveFile += new RecvFileDelegate(OnSending);
			}
			catch(Exception err) 
			{
				label1.Text =err.Message;
			}
		}

		private void RomoveSocEvent(ref WSocket Soc)
		{
			try
			{
				Soc.OnConnected -= new ConnectDelegate(OnConnected);
				Soc.OnDisconnected -= new DisconnectDelegate(OnDisconnected);
				Soc.OnReadyReceive -= new ReceiveDelegate(OnReceive);
				Soc.OnReadySend -= new SendDelegate(OnReadySend);
				Soc.OnConnectClose -= new CloseDelegate(OnCloseRemote);
				Soc.OnSocketError -= new SockErrDelegate(OnSocketError);
				Soc.OnSockMessage -= new MessageDelegate(OnSockMessage);
				Soc.OnSendingFile -= new SendingDelegate(OnSending);
				Soc.OnReceiveFile -= new RecvFileDelegate(OnSending);
			}
			catch(Exception err) 
			{
				label1.Text =err.Message;
			}
		}
        
		private void button1_Click(object sender, System.EventArgs e)
		{
			int nPort = Convert.ToInt32(txtCPort.Text);
			IPEndPoint ipLocalEndPoint;
			try
			{
				IPAddress ipAddress = Dns.Resolve(txtIP.Text.ToString()).AddressList[0];
				ipLocalEndPoint = new IPEndPoint(ipAddress, nPort);
			}
			catch(SocketException socErr )
			{
				MessageBox.Show(socErr.Message);
				return;
			}
            int nSoc = GetAvailbleSocket();
            try
			{  
				
			    SocClient[nSoc].SockRefNo = nSoc;	
				if (SocClient[nSoc]==null)
					InitSocket(ref SocClient[nSoc],nSoc);

				if (!SocClient[nSoc].Soc.Connected)
					SocClient[nSoc].AsyConnectTCIP(ipLocalEndPoint);	
			}
			catch (Exception err) 
			{
				label1.Text="Connect Button :"+err.Message;
				InitSocket(ref SocClient[nSoc],nSoc);
			}
		 
		}

		private void OnConnected(object sender, SockEventArgs e)
		{
		   	label1.Text = "Connected";
			SocClient[e.SocketRef].ReceiveData();
			//listBox2.Items.Add(e.SocketRef.ToString()+SocClient[e.SocketRef].RemoteEndPoint.ToString());
			//listView1.Items.Add(
			ListViewItem item = new ListViewItem();
			  item.Text = e.SocketRef.ToString();
			  item.SubItems.Add(SocClient[e.SocketRef].Soc.RemoteEndPoint.ToString());
			  item.SubItems.Add(e.RemoteUserName);
			  
		    listView1.Items.Add(item);
		}

		private void OnDisconnected(object sender, SockEventArgs e)
		{
		    label1.Text = "Disconnected";
			RomoveSocEvent(ref SocClient[e.SocketRef]);
			
			 
		}

		private void OnSending(object sender, SockEventArgs e)
		{   
            double nSize = Convert.ToDouble(e.SockMsg);
			int Val =Convert.ToInt32((e.ByteSend/nSize)*100);
			txtPer.Text = Val.ToString()+" %";
			prgBar.Value= Val;
			//listBox1.Items.Add(e.SockMsg+ " "+e.ByteSend.ToString()+" = "+ Val.ToString() );
		}

		private void OnSockMessage(object sender, SockEventArgs e)
		{
			listBox1.Items.Add(txtIP.Text+" <<"+ e.SockMsg);
		}

		private void OnReceive(object sender, SockEventArgs e)
		{
			
			//listBox1.Items.Add(txtIP.Text+" <<"+ SocClient[e.SocketRef].response.ToString());
			//listBox1.SelectedIndex =listBox1.Items.Count;
			//SocClient[e.SocketRef].response.Remove(0,SocClient[e.SocketRef].response.Length);
		}

		private void OnReadySend(object sender, SockEventArgs e)
		{
			label1.Text = "Ready to send";
		}

		private void OnSocketError(object sender, SockEventArgs e)
		{
			label1.Text = e.SockMsg;
		}

		private void OnCloseRemote(object sender, SockEventArgs e)
		{
			
			label1.Text = "Remote Close";
			nClose +=1;
			txtClose.Text = nClose.ToString();  
			foreach (ListViewItem aa in listView1.Items)
			{
				if (aa.Text == e.SocketRef.ToString())
				{
					listView1.Items.Remove(aa);
					break;
				}
			}
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (mySoc!=null)
				{   
					if (mySoc.Soc.Connected)
						mySoc.DisConnectTCIP();
				}
			}
			catch (ObjectDisposedException err) 
			{
				MessageBox.Show(err.Message);
			}
		
		}

		private void button3_Click(object sender, System.EventArgs e)
		{
			SendMulText();
		}

		private void SendMsg(string str)
		{
			mySoc.SendData(str);
		}

		private void button4_Click(object sender, System.EventArgs e)
		{
			mySoc.ReceiveData();
		}

		private void textBox1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyValue==13)
			{
		        SendMulText();
			}
 
		}

		private void SendMulText()
		{
			string[] tempArray = new string [textBox1.Lines.Length];
			tempArray = textBox1.Lines;
 
			for(int counter=0; counter < tempArray.Length;counter++)
			{
				if (tempArray[counter].Length > 0)
				{
					//mySoc.SendData(tempArray[counter]);
					SendToAllConnectedUse(tempArray[counter]);
					
				}
				listBox1.Items.Add("Me >>"+ tempArray[counter]);
			}
			textBox1.Clear();
		}

		private void SendToAllConnectedUse(string data)
		{
          int nSoc;
			foreach (ListViewItem user in listView1.Items)
			{
				try
				{
					nSoc= Convert.ToInt32(user.SubItems[0].Text);
					if (SocClient[nSoc]!=null)
					{
						if (SocClient[nSoc].Soc.Connected)
							SocClient[nSoc].SendData(data);   
					}
				}
				catch (Exception err) 
				{
					label1.Text="GetSock :"+err.Message;
				}
			 
			}
		}

		private int GetAvailbleSocket()
		{
			int i=-1;
			for( i=0;i<MAX_SOCKET;i++)
			{
				try
           	    {
					if (SocClient[i]==null)
						break;
					else
 					{
					    if (!SocClient[i].Soc.Connected)
						    break;
					}
				}
			   catch (Exception err) 
			   {
			  	  label1.Text="GetSock :"+err.Message;
			   }

			}

          if ((i>-1)&& (i <MAX_SOCKET))  
			  InitSocket(ref SocClient[i],i);
          txtSoc.Text= "Select Socket is :"+i.ToString();
		  return i;
		}

		private void button4_Click_1(object sender, System.EventArgs e)
		{
			serverThread = new Thread(new ThreadStart(startListen));
			serverThread.Start();
			button4.Enabled=false;

		}

		private void Form1_Closed(object sender, System.EventArgs e)
		{
			
		}

		private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if (serverThread!=null)
			{
				if (serverThread.IsAlive)
				{
					if (ListenSoc.Soc.Connected)
					{
						ListenSoc.Soc.Shutdown(SocketShutdown.Both);
						ListenSoc.Soc.Close();
					}
					serverThread.Abort();
				}
			}
		}

		private void listView1_DoubleClick(object sender, System.EventArgs e)
		{	
			int pos = listView1.SelectedItems[0].Index; 
		    int nSoc = Convert.ToInt32(listView1.SelectedItems[0].SubItems[0].Text); 
			if (MessageBox.Show("Confirm to disconnect this user ?","Diconnect",MessageBoxButtons.YesNo)==DialogResult.Yes)
			{
				try
				{
					if (SocClient[nSoc]!=null)   	
					{
						if (SocClient[nSoc].Soc.Connected)
						{
							SocClient[nSoc].CloseSocket();
						}
					}
				}
				catch (Exception err) 
				{
					label1.Text="GetSock :"+err.Message;
				}
				
				
			}
		}

		private void butFileName_Click(object sender, System.EventArgs e)
		{
			if (openFile.ShowDialog(this)==DialogResult.OK)
			   txtFileName.Text = openFile.FileName;

		}

		private void bSendFile_Click(object sender, System.EventArgs e)
		{
			int nSoc;
			foreach (ListViewItem user in listView1.Items)
			{
				try
				{
					nSoc= Convert.ToInt32(user.SubItems[0].Text);
					if (SocClient[nSoc]!=null)
					{
						if (SocClient[nSoc].Soc.Connected)
							SocClient[nSoc].SendFile(txtFileName.Text);
					}
				}
				catch (Exception err) 
				{
					label1.Text="GetSock :"+err.Message;
				}
			 
			}
		}

	}
}
