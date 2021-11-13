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


namespace Client_Sever
{
    public partial class Server : Form
    {
        public Server()
        {
            InitializeComponent();

            CheckForIllegalCrossThreadCalls = false;
            Connection();
        }

        private void bntSend_Click(object sender, EventArgs e)
        {
            foreach(Socket item in clientList)
            {
                Send(item);
            }
            AddMessage(txtMessaga.Text);
            txtMessaga.Clear();
            
        }
        IPEndPoint IP;
        Socket server;
        List<Socket> clientList;


        // kết nối
        void Connection()
        {
            clientList = new List<Socket>();
            // ip server
            IP = new IPEndPoint(IPAddress.Any, 9999);
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);

            server.Bind(IP);


            Thread Listen = new Thread(()=> {
                try
                {
                    while (true)
                    {
                        server.Listen(100);
                        Socket client = server.Accept();
                        clientList.Add(client);
                      
                        Thread receive = new Thread(Receive);
                        receive.IsBackground = true;
                        receive.Start(client);
                    }
                }
                catch
                {
                    IP = new IPEndPoint(IPAddress.Any, 9999);
                    server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
                }
            });
            Listen.IsBackground = true;
            Listen.Start();

        }
        // đóng kết nối
        void Close()
        {
            server.Close();
        }

        // gửi tin
        void Send(Socket client)
        {
            if (client!=null && txtMessaga.Text != string.Empty)
                client.Send(Serialize(txtMessaga.Text));
            
        }

        // nhận tin
        void Receive(object ojb)
        {
            Socket client = ojb as Socket;
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
                clientList.Remove(client);
                client.Close();
            }

        }
        void AddMessage(string s)
        {
            lsvMessage.Items.Add(new ListViewItem() { Text = s });
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

        private void Server_FormClosing(object sender, FormClosingEventArgs e)
        {
            Close();
        }
    }
}
