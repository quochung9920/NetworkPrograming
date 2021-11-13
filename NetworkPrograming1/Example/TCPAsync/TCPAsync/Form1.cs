using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TCPAsync
{
    public partial class Form1 : Form
    {
        private byte[] data = new byte[1024];
        private int size = 1024;
        private Socket server =new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        IPEndPoint iep = new IPEndPoint(IPAddress.Any, 9050);
        public Form1()
        {
            InitializeComponent();
            server.Bind(iep);
            server.Listen(5);
            server.BeginAccept(new AsyncCallback(AcceptConn), server);
        }
        void AcceptConn(IAsyncResult iar)
        {
            Socket oldserver = (Socket)iar.AsyncState;
            Socket client = oldserver.EndAccept(iar);
            SendStart(client, "Welcome to my test server");
        }

        void AcceptConn2(IAsyncResult iar)
        {
            Socket oldserver = (Socket)iar.AsyncState;
            Socket client = oldserver.EndAccept(iar);

            SendStart(client, newText.Text);
            newText.Clear();
        }
        void SendStart(Socket client, string s)
        {

            for (int i = 0; i < 5; i++)
            {
                byte[] message1 = Encoding.ASCII.GetBytes(s);
                client.BeginSend(message1, 0, message1.Length, SocketFlags.None, new AsyncCallback(SendData), client);
            }
        }


        void SendData(IAsyncResult iar)
        {
            Socket client = (Socket)iar.AsyncState;
            client.EndSend(iar);
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            //server.BeginAccept(new AsyncCallback(AcceptConn), server);
            //Socket client = server.Accept();
            //SendStart(client, newText.Text);
            server.BeginAccept(new AsyncCallback(AcceptConn2), server);
        }
    }
}
