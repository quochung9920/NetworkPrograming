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

namespace ChatClientServer
{
    public partial class Server : Form
    {
        public Server()
        {
            InitializeComponent();

            CheckForIllegalCrossThreadCalls = false;
            Connect();
        }

        //Đóng kết nối
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Close();
        }


        //Gửi tin cho tất cả Client
        private void btnSend_Click(object sender, EventArgs e)
        {
            foreach (Socket item in clientList)
            {
                Send(item);
            }
            AddMessage(txbMessage.Text);
            txbMessage.Clear();
        }


        IPEndPoint IP;
        Socket server;

        List<Socket> clientList;

        //Kết nối tới Server
        void Connect()
        {
            clientList = new List<Socket>();

            IP = new IPEndPoint(IPAddress.Any, 9999);
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);

            server.Bind(IP);

            Thread Listen = new Thread(() => {
                try
                {
                    while (true)
                    {
                        server.Listen(100);
                        Socket client = server.Accept();
                        clientList.Add(client);

                        Thread receive = new Thread(Receice);
                        receive.IsBackground = true;
                        receive.Start(client);
                    }
                }
                catch
                {
                    //Khắc phục lỗi khi có client đóng kết nối khi server đang kết nối
                    IP = new IPEndPoint(IPAddress.Any, 9999);
                    server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
                }

            });
            Listen.IsBackground = true;
            Listen.Start();
        }


        //Đóng kết nối hiện thời
        void Close()
        {
            server.Close();
        }

        //Gửi tin
        void Send(Socket client)
        {
            //Nếu như trong textbox không rỗng thì gửi tin đi
            if (client != null && txbMessage.Text != string.Empty)
                client.Send(Serialize(txbMessage.Text));

        }

        //Nhận tin
        void Receice(object obj)
        {
            Socket client = obj as Socket;
            //Vượt qua ngưỡng nhận tin liên tục thì ngắt kết nối
            try
            {
                //Đưa vào vòng lặp để nhận tin liên tục
                while (true)
                {
                    byte[] data = new byte[1024 * 5000];
                    client.Receive(data);

                    //Đưa mảng byte về kiểu oblect sau đó ép thành string
                    string message = (string)Deserialize(data);

                    foreach (Socket item in clientList)
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
                clientList.Remove(client);
                client.Close();
            }

        }

        //Add nội dung vào listbox
        void AddMessage(string s)
        {
            lsvMessage.Items.Add(new ListViewItem() { Text = s });
        }

        //Phân mảnh
        byte[] Serialize(object obj)
        {
            MemoryStream stream = new MemoryStream();
            BinaryFormatter formater = new BinaryFormatter();

            //Phân mảnh, đưa obj từ object thành kiểu binary
            formater.Serialize(stream, obj);

            //Trả ra 1 dãy byte, phân thành từng mảng byte
            return stream.ToArray();
        }

        //Gom mảnh
        object Deserialize(byte[] data)
        {
            MemoryStream stream = new MemoryStream(data);
            BinaryFormatter formater = new BinaryFormatter();


            //Ngược lại từ mảng byte thành object
            return formater.Deserialize(stream);
        }
    }
}
