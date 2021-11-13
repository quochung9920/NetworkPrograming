using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Windows.Forms;

namespace Cient
{
    public partial class Client : Form
    {
        IPEndPoint IP; 
        Socket client;


        public Client()
        {
            InitializeComponent();
            // Xử lí đụng độ dữ liệu
            CheckForIllegalCrossThreadCalls = false;
            Connect();
        }

        // Gửi tin đi
        private void btnSend_Click(object sender, EventArgs e)
        {
            Send();
            // Thêm tin nhắn vào khung chat của mình
            AddMessage(txbMessage.Text);
        }

        // Kết nối đến Server
        void Connect()
        {
            // IP Server
            IP = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9999);
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);

            try
            {
                // Kết nối đến Server
                client.Connect(IP);
            }
            catch
            {
                // In ra thông báo lỗi và ngắt chương trình
                MessageBox.Show("Không thể kết nối Server!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Tạo ra luồng lắng nghe để nhận tin
            Thread listen = new Thread(Receive);
            // Set bằng true để khi chương trình đóng thì luồng cũng đóng
            listen.IsBackground = true; 
            listen.Start();
        }

        // Đóng kết nối hiện thời
        void Close()
        {
            client.Close();
        }

        // Gửi tin
        void Send()
        {
            // Nếu như textbox message không rỗng thì gửi dữ liệu
            if (txbMessage.Text != string.Empty)
            {
                client.Send(Serialize(txbMessage.Text));
            }
        }

        // Nhận tin
        void Receive()
        {
            try
            {

                // Nhận tin
                while (true)
                {
                    byte[] data = new byte[1024 * 5000];
                    client.Receive(data);

                    // Ép data về khiểu object sau đó ép thành kiểu string
                    string message = (string)Deserialize(data);

                    AddMessage(message);
                }
            }
            catch
            {
                Close();
            }
        }

        // Thêm message vào khung chat
        void AddMessage(string s)
        {
            lsvMessage.Items.Add(new ListViewItem() { Text = s });
            // Sau khi thêm vào khung chat thì xoá nội dung dưới khung tin nhắn của mình
            txbMessage.Clear();
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

        // Đóng kết nối khi đóng form
        private void Client_FormClosed(object sender, FormClosedEventArgs e)
        {
            Close();
        }
    }
}
