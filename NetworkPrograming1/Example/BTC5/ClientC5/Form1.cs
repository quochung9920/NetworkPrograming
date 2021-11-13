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

namespace ClientC5
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

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Text = "Connecting...";
            Socket newsock = new Socket(AddressFamily.InterNetwork,
            SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint iep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9050);
            newsock.BeginConnect(iep, new AsyncCallback(Connected), newsock);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            byte[] message = Encoding.ASCII.GetBytes(textBox1.Text);
            textBox1.Clear();
            client.BeginSend(message, 0, message.Length, SocketFlags.None,
            new AsyncCallback(SendData), client);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            client.Close();
            textBox2.Text = "Disconnected";

        }

        void Connected(IAsyncResult iar)
        {
            client = (Socket)iar.AsyncState;
            try
            {
                client.EndConnect(iar);
                textBox2.Text = "Connected to: " + client.LocalEndPoint.ToString();
                client.BeginReceive(data, 0, size, SocketFlags.None,
                new AsyncCallback(ReceiveData), client);
            }
            catch (SocketException)
            {
                MessageBox.Show("Không thể kết nối đến Server");
               textBox2.Text = "Error connecting";

            }
        }
        void ReceiveData(IAsyncResult iar)
        {
            Socket remote = (Socket)iar.AsyncState;
            int recv = remote.EndReceive(iar);
            string stringData = Encoding.ASCII.GetString(data, 0, recv);
            listView1.Items.Add(stringData);
        }
        void SendData(IAsyncResult iar)
        {
            Socket remote = (Socket)iar.AsyncState;
            int sent = remote.EndSend(iar);
            remote.BeginReceive(data, 0, size, SocketFlags.None,
            new AsyncCallback(ReceiveData), remote);
        }

    }
}
