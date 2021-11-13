using System;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
namespace AcsyncTcpClients
{
    public partial class Form1 : Form
    {
        private Socket client;
        private byte[] data = new byte[1024];
        private int size = 1024;
        public Form1()
        {
            InitializeComponent();
            Socket newsock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint iep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9050);
            newsock.BeginConnect(iep, new AsyncCallback(Connect), newsock);
        }
        private void btnConnect_Click(object sender, EventArgs e)
        {
            Socket newsock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint iep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9050);
            newsock.BeginConnect(iep, new AsyncCallback(Connect), newsock);
        }
        private void btnSend_Click(object sender, EventArgs e)
        {
            byte[] message = Encoding.ASCII.GetBytes(newText.Text);
            newText.Clear();
            client.BeginSend(message, 0, message.Length, SocketFlags.None, new AsyncCallback(SendData), client);
        }
        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            client.Close();
            conStatus.Text = "Disconnected";
        }
        void Connect(IAsyncResult iar)
        {
            client = (Socket)iar.AsyncState;
            try
            {
                client.EndConnect(iar);

                Invoke(new Action(() =>
                {
                    conStatus.Text = "Connected to: " + client.RemoteEndPoint.ToString();
                }));

                client.BeginReceive(data, 0, size, SocketFlags.None, new AsyncCallback(ReceiveData), client);
            }
            catch (SocketException)
            {
                MessageBox.Show("Không thể kết nối đến Server");
                conStatus.Text = "Error connecting";
            }
        }
        void ReceiveData(IAsyncResult iar)
        {
            Socket remote = (Socket)iar.AsyncState;
            int recv = remote.EndReceive(iar);
            string stringData = Encoding.ASCII.GetString(data, 0, recv);
            Invoke(new Action(() =>
            {
                results.Items.Add(stringData);
            }));
        }
        void SendData(IAsyncResult iar)
        {
            Socket remote = (Socket)iar.AsyncState;
            int sent = remote.EndSend(iar);
            remote.BeginReceive(data, 0, size, SocketFlags.None, new AsyncCallback(ReceiveData), remote);
        }
    }
}