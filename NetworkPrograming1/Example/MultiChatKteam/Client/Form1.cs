using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;

namespace Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //Sử lý đụng độ dữ liệu
            CheckForIllegalCrossThreadCalls = false;
            Connect();
        }

        //Gửi tin đi
        private void btnSend_Click(object sender, EventArgs e)
        {
            Send();

            //Gửi xong hiển thị lên khung chát của mình
            AddMessage(txbMessage.Text);
        }

        IPEndPoint IP;
        Socket client;

        //Kết nối tới Server
        void Connect()
        {
            IP = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9999);
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            try
            {
                client.Connect(IP);
            }
            catch
            {
                MessageBox.Show("Không thể kết nối đến Server !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Thread listen = new Thread(Receice);
            listen.IsBackground = true;
            listen.Start();
        }


        //Đóng kết nối hiện thời
        void Close()
        {
            client.Close();
        }

        //Gửi tin
        void Send()
        {
            //Nếu như trong textbox không rỗng thì gửi tin đi
            if(txbMessage.Text != string.Empty)
                client.Send(Serialize(txbMessage.Text));

        }

        //Nhận tin
        void Receice()
        {

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


                    AddMessage(message);
                }
            }
            catch
            {
                Close();
            } 
            
        }

        //Add nội dung vào listbox
        void AddMessage(string s)
        {
            lsvMessage.Items.Add(new ListViewItem() { Text = s });
            //Gửi xong xoá nội dung đi
            txbMessage.Clear();
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

        //Đóng kết nối khi đóng form
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Close();
        }
    }
}
