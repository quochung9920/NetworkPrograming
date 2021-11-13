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

namespace Client_Client
{
    public partial class Client : Form
    {
        public Client()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            Connection();
        }

        private void bntSend_Click(object sender, EventArgs e)
        {
            Send();
            AddMessage(txtMessaga.Text);
        }
        IPEndPoint IP;
        Socket client;



        // kết nối
        void Connection()
        {
            // ip server
            IP = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9999);
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);

            try
            {
                client.Connect(IP);
            }
            catch
            {
                MessageBox.Show("Không thể kết nối server!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Thread listen = new Thread(Receive);
            listen.IsBackground = true;
            listen.Start();

        }
        // đóng kết nối
        void Close()
        {
            client.Close();
        }

        // gửi tin
        void Send()
        {
            if (txtMessaga.Text != string.Empty)
                client.Send(Serialize(txtMessaga.Text));
        }

        // nhận tin
        void Receive()
        {
            try
            {
                while (true)
                {


                    byte[] data = new byte[1024 * 5000];
                    client.Receive(data);

                    string message = (string)Deserialize(data);
                    AddMessage(message);
                }
            }
            catch
            {
                Close();
            }

        }
        void AddMessage(string s)
        {
            lsvMessage.Items.Add(new ListViewItem() { Text = s });
            txtMessaga.Clear();
        }

        // phân mảnh

        byte[] Serialize(object ojb)
        {
            MemoryStream stream = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();

            formatter.Serialize(stream, ojb);

            return stream.ToArray();

        }

        // gom mảnh

        object Deserialize(byte[] data)
        {
            MemoryStream stream = new MemoryStream(data);
            BinaryFormatter formatter = new BinaryFormatter();

            return formatter.Deserialize(stream);


        }

        private void frmClient_FormClosed(object sender, FormClosedEventArgs e)
        {
            Close();
        }
    }
}
