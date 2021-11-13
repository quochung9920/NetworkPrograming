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

namespace BTH1_C5
{
    public partial class Form1 : Form
    {
        // Tạo bộ đệm
        private byte[] data = new byte[1024];
        // Tạo biến kích thước
        private int size = 1024;
        // Tạo Socket Server
        private Socket server;

        public Form1()
        {
            InitializeComponent();

            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            // Server lắng nghe các kết nối TCP
            IPEndPoint iep = new IPEndPoint(IPAddress.Any, 9050);
            server.Bind(iep);
            // Cho phép kết nối tối đa 5 client cùng lúc TCP
            server.Listen(5);
            // Bắt đầu quá trình bất đồng bộ Async
            server.BeginAccept(new AsyncCallback(AcceptConn), server);
        }
        private void btnStop_Click(object sender, EventArgs e)
        {
            Close();
        }
        

        // IAsyncResult này để cho biết đây là hoạt động bất đồng bộ
        void AcceptConn(IAsyncResult iar)
        {
            // Tạo đối tượng đủ điều kiện hoặc chứa thông tin về bất đồng bộ Async
            Socket oldserver = (Socket)iar.AsyncState;
            // Chấp nhận kết nối Async
            Socket client = oldserver.EndAccept(iar);
            conStatus.Text = "Connected to: " + client.RemoteEndPoint.ToString();
            string stringData = "Welcome to my server";
            byte[] message1 = Encoding.ASCII.GetBytes(stringData);
            // Gửi dữ liệu đi Async
            client.BeginSend(message1, 0, message1.Length, SocketFlags.None, new AsyncCallback(SendData), client);
        }
        void SendData(IAsyncResult iar)
        {
            // Tạo đối tượng đủ điều kiện hoặc chứa thông tin về bất đồng bộ Async
            Socket client = (Socket)iar.AsyncState;

            int sent = client.EndSend(iar);
            client.BeginReceive(data, 0, size, SocketFlags.None, new AsyncCallback(ReceiveData), client);
        }
        void ReceiveData(IAsyncResult iar)
        {
            Socket client = (Socket)iar.AsyncState;
            int recv = client.EndReceive(iar);
            if (recv == 0)
            {
                client.Close();
                conStatus.Text = "Waiting for client...";
                server.BeginAccept(new AsyncCallback(AcceptConn), server);
                return;
            }
            string receivedData = Encoding.ASCII.GetString(data, 0, recv);
            results.Items.Add(receivedData);
            byte[] message2 = Encoding.ASCII.GetBytes(receivedData);
            client.BeginSend(message2, 0, message2.Length, SocketFlags.None, new AsyncCallback(SendData), client);
        }


    }
}
