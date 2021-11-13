using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    public partial class Server : Form
    {

        IPEndPoint IP;
        Socket server;

        // Danh sách lưu trữ tất cả Client kết nối đến Server
        List<Socket> clientList;
        public Server()
        {
            InitializeComponent();

            // Xử lí đụng độ dữ liệu
            CheckForIllegalCrossThreadCalls = false;
            Connect();
        }

        // Gửi tin cho tất cả client
        private void btnSend_Click(object sender, EventArgs e)
        {
            // Gửi đến tất cả Client trong clienList
            foreach (Socket item in clientList)
            {
                Send(item);
            }

            AddMessage(txbMessage.Text);
            // Xoá nội dung trong khung tin nhắn của mình sau khi gửi
            txbMessage.Clear();
        }

        // Kết nối đến các client
        void Connect()
        {

            clientList = new List<Socket>();

            // IP Server
            IP = new IPEndPoint(IPAddress.Any, 9999);
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            // Đợi IP của bất cứ client kết nối tới
            server.Bind(IP);

            // Luồng để đợi Client kết nối tới
            Thread Listen = new Thread(() => {
                try
                {
                    while (true)
                    {
                        // Cho phép tối đa 100 client kết nối cùng lúc
                        server.Listen(100);

                        Socket client = server.Accept();
                        // Khi đã kết nối, thêm client vào clientList
                        clientList.Add(client);

                        // Tạ luồng để nhận tin từ client
                        Thread receive = new Thread(Receive);
                        receive.IsBackground = true;
                        receive.Start(client);
                    }
                }
                catch
                {
                    // Khởi tạo lại khi đang kết nối có client thoát ra, để tránh trường hợp lặp vô tận
                    IP = new IPEndPoint(IPAddress.Any, 9999);
                    server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
                }
            });
            Listen.IsBackground = true;
            Listen.Start();
        }

        // Đóng kết nối hiện thời
        void Close()
        {
            server.Close();
        }

        // Gửi tin cho 1 client
        void Send(Socket client)
        {
            // Nếu như textbox message không rỗng thì gửi dữ liệu
            if (client != null && txbMessage.Text != string.Empty)
            {
                client.Send(Serialize(txbMessage.Text));
            }
        }

        // Nhận tin từu 1 client
        void Receive(object obj)
        {
            Socket client = obj as Socket;

            try
            {

                // Nhận tin
                while (true)
                {
                    byte[] data = new byte[1024 * 5000];
                    client.Receive(data);

                    // Ép data về khiểu object sau đó ép thành kiểu string
                    string message = (string)Deserialize(data);

                    foreach(Socket item in clientList)
                    {
                        if (item != null && item != client)
                        {
                            item.Send(Serialize(message)); 
                        }
                    }
                    AddMessage(message);
                }
            }
            catch
            {
                // Xử lí khi có 1 client đóng form
                clientList.Remove(client);
                client.Close();
            }
        }

        // Thêm message vào khung chat
        void AddMessage(string s)
        {
            lsvMessage.Items.Add(new ListViewItem() { Text = s });
        }

        // Phân mảnh dữ liệu thành dạng mảng byte để gửi đi
        byte[] Serialize(object obj)
        {
            MemoryStream stream = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();

            // Phân mảnh dữ liệu gán vào stream
            formatter.Serialize(stream, obj);

            // Chuyển dữ liệu thành mảng byte
            return stream.ToArray();
        }

        // Gom mảnh lại khi nhận tin
        object Deserialize(byte[] data)
        {
            MemoryStream stream = new MemoryStream(data);
            BinaryFormatter formatter = new BinaryFormatter();

            return formatter.Deserialize(stream);
        }

        // Đóng kết nối khi form đóng
        private void Server_FormClosed(object sender, FormClosedEventArgs e)
        {
            Close();
        }

        
    }
}
