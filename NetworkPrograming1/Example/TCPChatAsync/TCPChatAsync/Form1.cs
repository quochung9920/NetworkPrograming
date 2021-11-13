using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
namespace AcSyncTcpSrv
{
    public partial class Form1 : Form
    {
        private byte[] data = new byte[1024];
        private int size = 1024;
        private Socket server;

        public Form1()
        {
            InitializeComponent();
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint iep = new IPEndPoint(IPAddress.Any, 9050);
            server.Bind(iep);
            server.Listen(5);
        }

         private void bthStart_Click(object sender, EventArgs e)
        {
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint iep = new IPEndPoint(IPAddress.Any, 9050);
            server.Bind(iep);
            server.Listen(5);
            
        }

        void AcceptConn(IAsyncResult iar)
        {
            Socket oldserver = (Socket)iar.AsyncState;
            Socket client = oldserver.EndAccept(iar);

            Invoke(new Action(() =>
            {
                conStatus.Text = "Connected to: " + client.RemoteEndPoint.ToString();
            }));

            string s = newText.Text;
            byte[] message1 = Encoding.ASCII.GetBytes(s);
            client.BeginSend(message1, 0, message1.Length, SocketFlags.None, new AsyncCallback(SendData), client);
        }

        void AcceptConn2(IAsyncResult iar)
        {
            Socket oldserver = (Socket)iar.AsyncState;
            Socket client = oldserver.EndAccept(iar);

            Invoke(new Action(() =>
            {
                conStatus.Text = "Connected to: " + client.RemoteEndPoint.ToString();
            }));

            string s = newText.Text;
            byte[] message1 = Encoding.ASCII.GetBytes(s);
            client.BeginSend(message1, 0, message1.Length, SocketFlags.None, new AsyncCallback(SendData), client);
        }
        void SendData(IAsyncResult iar)
        {
            Socket client = (Socket)iar.AsyncState;
            int sent = client.EndSend(iar);
            
            client.BeginReceive(data, 0, size, SocketFlags.None, new AsyncCallback(ReceiveData), client);
        }

        void ReceiveData(IAsyncResult iar)
        {
            Socket client = (Socket)iar.AsyncState;
            int recv = client.EndReceive(iar);
            string receivedData = Encoding.ASCII.GetString(data, 0, recv);
            if (recv == 0)
            {
                client.Close();
                conStatus.Text = "Waiting for client...";
                server.BeginAccept(new AsyncCallback(AcceptConn), server);
                return;
            }
            Invoke(new Action(() =>
            {
                results.Items.Add(receivedData);
            }));
            byte[] message2 = Encoding.ASCII.GetBytes(receivedData);
            client.BeginSend(message2, 0, message2.Length, SocketFlags.None, new AsyncCallback(SendData), client);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bthSend_Click(object sender, EventArgs e)
        {


            server.BeginAccept(new AsyncCallback(AcceptConn), server);
            newText.Clear();

        }

       
    }
}