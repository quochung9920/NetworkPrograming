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

namespace Client
{
    public partial class Form1 : Form
    {

        private Socket client;
        private byte[] data = new byte[1024];
        private int size = 1024;

        Socket newsock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        IPEndPoint iep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9050);
        public Form1()
        {
            InitializeComponent();
            newsock.BeginConnect(iep, new AsyncCallback(Connect), newsock);
        }
        void Connect(IAsyncResult iar)
        {
            
            client = (Socket)iar.AsyncState;
            client.EndConnect(iar);
            for (int i = 0; i < 5; i++)
            {
                client.BeginReceive(data, 0, size, SocketFlags.None, new AsyncCallback(ReceiveData), client);
            }
        }
        void ReceiveData(IAsyncResult iar)
        {
            Socket remote = (Socket)iar.AsyncState;
            int recv = remote.EndReceive(iar);
            string stringData = Encoding.ASCII.GetString(data, 0, recv);
            if(recv != 0)
            {
                newsock.BeginConnect(iep, new AsyncCallback(Connect), newsock);
                return;
            }    
            Invoke(new Action(() =>
            {
                results.Items.Add(stringData); 
            }));

        }
    }
}
