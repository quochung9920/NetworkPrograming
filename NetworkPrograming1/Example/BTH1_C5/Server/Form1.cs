using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    public partial class Form1 : Form
    {
        private Socket client;
        private byte[] data = new byte[1024];
        private int size = 1024;
        public Form1()
        {
            InitializeComponent();

        }
        private void btnConnect_Click(object sender, EventArgs e)
        {
            conStatus.Text = "Connecting...";
            Socket newsock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint iep = new IPEndPoint(IPAddress.Any, 9050);
            newsock.Bind(iep);
            newsock.Listen(100);
            newsock.BeginConnect(iep, new AsyncCallback(Connected), newsock);
        }
        private void btnSend_Click(object sender, EventArgs e)
        {
            byte[] message = Encoding.ASCII.GetBytes(newText.Text);
            newText.Clear();
            client.BeginSend(message, 0, message.Length, SocketFlags.None,
            new AsyncCallback(SendData), client);
        }
        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            client.Close();
            conStatus.Text = "Disconnected";
        }
        void Connected(IAsyncResult iar)
        {
            client = (Socket)iar.AsyncState;
            try
            {
                client.EndConnect(iar);
                conStatus.Text = "Connected to: " + client.RemoteEndPoint.ToString();
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
            results.Items.Add(stringData);
        }
        void SendData(IAsyncResult iar)
        {
            Socket remote = (Socket)iar.AsyncState;
            int sent = remote.EndSend(iar);
            remote.BeginReceive(data, 0, size, SocketFlags.None, new AsyncCallback(ReceiveData), remote);
        }

    }
}
