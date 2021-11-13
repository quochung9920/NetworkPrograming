using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Server
{
    public partial class Server : Form
    {
        private bool active = false; // Biến kiểm tra kết nối
        private Thread listener = null; // Luồng lắng nghe kết nối Client
        private long id = 0;
        private struct MyClient // Struct thông tin và kết nối
        {
            public long id;
            public StringBuilder username;
            public TcpClient client;
            public NetworkStream stream;
            public byte[] buffer;
            public StringBuilder data;
            public EventWaitHandle handle;
        };

        // Tạo cặp giá trị an toàn theo luông có thể cho nhiều luồng truy cập đồng thời ( Khoá phòng)
        private ConcurrentDictionary<long, MyClient> clients = new ConcurrentDictionary<long, MyClient>();
        private Task send = null; // Task gưi dữ liệu
        private Thread disconnect = null;
        private bool exit = false;
        private string publicKey;
        private string privateKey;



        public Server()
        {
            InitializeComponent();
        }

        // Hiển thị nội dung vào khung Log
        private void Log(string msg = "")
        {
            
            if (!exit)
            {
                // Tạo luồng để thực thi thêm thông báo vào khung Log
                logTextBox.Invoke((MethodInvoker)delegate
                {
                    // Nếu chuỗi có dữ liệu thì mới thực hiện
                    if (msg.Length > 0)
                    {
                        // Hiển thị thời gian, nội dung chuỗi thông báo và tạo dòng mới (xuống dòng)
                        logTextBox.AppendText(string.Format("[ {0} ] {1}{2}", DateTime.Now.ToString("HH:mm"), msg, Environment.NewLine));
                    }
                    else
                    {
                        // Nếu không có dữ liệu thì xoá dòng lỗi đi
                        logTextBox.Clear();
                    }
                });
            }
        }

        // Tạo chuỗi thông báo lỗi
        private string ErrorMsg(string msg)
        {
            return string.Format("ERROR:{0}", msg);
        }

        // Tạo chuỗi nội dung của hệ thống
        private string SystemMsg(string msg)
        {
            return string.Format("SYSTEM:{0}", msg);
        }

        private void Active(bool status)
        {
            if (!exit)
            {
                startButton.Invoke((MethodInvoker)delegate
                {
                    active = status;
                    if (status)
                    {
                        addrTextBox.Enabled = false;
                        portTextBox.Enabled = false;
                        usernameTextBox.Enabled = false;
                        keyTextBox.Enabled = false;
                        startButton.Text = "Stop";
                        Log(SystemMsg("Server has started"));
                    }
                    else
                    {
                        addrTextBox.Enabled = true;
                        portTextBox.Enabled = true;
                        usernameTextBox.Enabled = true;
                        keyTextBox.Enabled = true;
                        startButton.Text = "Start";
                        Log(SystemMsg("Server has stopped"));
                    }
                });
            }
        }

        // Thêm Client vào GribView
        private void AddToGrid(long id, string name)
        {
            if (!exit)
            {
                // Tạo luồng để thêm Client vào khung GribView
                clientsDataGridView.Invoke((MethodInvoker)delegate
                {
                    string[] row = new string[] { id.ToString(), name };
                    clientsDataGridView.Rows.Add(row);
                    totalLabel.Text = string.Format("Total clients: {0}", clientsDataGridView.Rows.Count);
                });
            }
        }

        // Xoá Client ra khỏi GibView
        private void RemoveFromGrid(long id)
        {
            if (!exit)
            {
                clientsDataGridView.Invoke((MethodInvoker)delegate
                {
                    foreach (DataGridViewRow row in clientsDataGridView.Rows) // Duyệt để xoá Client
                    {
                        if (row.Cells["identifier"].Value.ToString() == id.ToString())
                        {
                            clientsDataGridView.Rows.RemoveAt(row.Index);
                            break;
                        }
                    }
                    totalLabel.Text = string.Format("Total clients: {0}", clientsDataGridView.Rows.Count);
                });
            }
        }

        private void AddToGridGroupChat(long id, string name)
        {
            // Tạo luồng để thêm Client vào khung GribView
            groupChatDataGribView.Invoke((MethodInvoker)delegate
            {
                string[] row = new string[] { id.ToString(),name };
                groupChatDataGribView.Rows.Add(row);
            });
        }

        ASCIIEncoding ByteConverter = new ASCIIEncoding();
        public string Decryption(string strText)
        {

            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(1024))
            {
                try
                {
                    // server decrypting data with private key
                    //rsa.ImportParameters(privateKey);
                    Log(privateKey);
                    rsa.FromXmlString(privateKey);
                    byte[] resultBytes = Convert.FromBase64String(strText);
                    byte[] decryptedBytes = rsa.Decrypt(resultBytes, true);
                    string decryptedData = ByteConverter.GetString(decryptedBytes);
                    return decryptedData.ToString();
                }
                finally
                {
                    rsa.PersistKeyInCsp = false;
                }
            }
        }

        int countGroupChat = 0;
        int countMessage = 0;
        private void GroupingMessages(string msg, long id)
        {
            string[] mess = msg.Split(':');
            if (String.Compare(mess[1], "CreateGroupChat", true) == 0)
            {
                Log(msg);
                string nameGroupChat = '[' + mess[0] + ']';
                string[] listNameClient = mess[2].Split('+');
                string ident = "";
                foreach (string name in listNameClient)
                {
                    if (String.Compare(name, " ", true) != 0)
                    {
                        nameGroupChat += name;
                    }
                }

                AddToGridGroupChat(groupChatDataGribView.Rows.Count, nameGroupChat);
                foreach (DataGridViewRow row in clientsDataGridView.Rows)
                {
                    string str = '[' + row.Cells[1].Value.ToString().Trim() + ']';
                    foreach (string name in listNameClient)
                    {
                        if (String.Compare(name, str, true) == 0)
                        {
                            foreach (DataGridViewRow rowgr in groupChatDataGribView.Rows)
                            {
                                // Ở đây có lỗi nghiêm trọng nhưng chưa biết sửa :))
                                if (String.Compare(nameGroupChat, rowgr.Cells[1].Value.ToString(), true) == 0)
                                {
                                    SendGroupChat(SystemMsg("GroupChat:" + rowgr.Cells[0].Value.ToString() + ":" + nameGroupChat), long.Parse(row.Cells[0].Value.ToString()));
                                    ident = rowgr.Cells[0].Value.ToString();
                                }

                            }
                        }
                    }
                }
                SendGroupChat(SystemMsg("GroupChat:" + ident + ":" + nameGroupChat), id);
            }
            else if (String.Compare(mess[1], "Message", true) == 0)
            {
                Log(msg);
                foreach (DataGridViewRow row in groupChatDataGribView.Rows)
                {
                    if (string.Compare(mess[2], row.Cells[0].Value.ToString(), true) == 0)
                    {
                        string client = row.Cells[1].Value.ToString();
                        string[] listClient = client.Split('[');
                        foreach (string clientGroup in listClient)
                        {
                            string[] vs = clientGroup.Split(']');
                            foreach (DataGridViewRow rowClient in clientsDataGridView.Rows)
                            {
                                if (String.Compare(vs[0], rowClient.Cells[1].Value.ToString(), true) == 0)
                                {
                                    SendGroupChat(msg, long.Parse(rowClient.Cells[0].Value.ToString()));
                                }
                            }
                        }
                    }
                }
            }
            else if (String.Compare(mess[1], "ReloadGroupChat", true) == 0)
            {
                if(groupChatDataGribView.Rows.Count > 0)
                {
                    if(countGroupChat < groupChatDataGribView.Rows.Count)
                    {
                        int n = -1;
                        string loadGroupChat = SystemMsg("LoadGroupChat:");
                        foreach (DataGridViewRow dataGridViewRow in clientsDataGridView.Rows)
                        {
                            if (String.Compare(dataGridViewRow.Cells[1].Value.ToString(), mess[0], true) == 0)
                            {
                                for(int i = countGroupChat; i < groupChatDataGribView.Rows.Count; i++)
                                {
                                    string listClient = groupChatDataGribView.Rows[i].Cells[1].Value.ToString();
                                    string[] clientGroup = listClient.Split('[');
                                    for (int j = 1; j < clientGroup.Length; j++)
                                    {
                                        if (String.Compare(clientGroup[j], mess[0] + "]", true) == 0)
                                        {
                                            n = i;
                                        }
                                    }
                                    if (n != -1)
                                    {
                                        loadGroupChat +=
                                                groupChatDataGribView.Rows[i].Cells[0].Value.ToString() + ":" +
                                                groupChatDataGribView.Rows[i].Cells[1].Value.ToString();
                                        SendGroupChat(loadGroupChat, long.Parse(dataGridViewRow.Cells[0].Value.ToString()));
                                        Log(loadGroupChat);
                                        countGroupChat = n + 1;
                                        break;
                                    }
                                    if(i == groupChatDataGribView.Rows.Count - 1 && n == -1)
                                    {
                                        Send(SystemMsg("LoadGroupChat:FINISH:") + mess[0]);
                                        Log(SystemMsg("LoadGroupChat:FINISH:") + mess[0]);
                                        countGroupChat = n + 1;
                                    }
                                }
                            }
                        }
                    } 
                    else
                    {
                        countGroupChat = 0;
                        foreach (DataGridViewRow dataGridViewRow in clientsDataGridView.Rows)
                        {
                            if (String.Compare(dataGridViewRow.Cells[1].Value.ToString(), mess[0], true) == 0)
                            {
                                SendGroupChat(SystemMsg("LoadGroupChat:FINISH:" + mess[0]), long.Parse(dataGridViewRow.Cells[0].Value.ToString()));
                                Log(SystemMsg("LoadGroupChat:FINISH:" + mess[0]));
                            }
                        }
                    }
                }
                else
                {
                    foreach (DataGridViewRow dataGridViewRow in clientsDataGridView.Rows)
                    {
                        if (String.Compare(dataGridViewRow.Cells[1].Value.ToString(), mess[0], true) == 0)
                        {
                            SendGroupChat(SystemMsg("LoadGroupChat:FINISH:" + mess[0]), long.Parse(dataGridViewRow.Cells[0].Value.ToString()));
                            Log(SystemMsg("LoadGroupChat:FINISH:" + mess[0]));
                        }
                    }
                }

            }
            else if (String.Compare(mess[1], "ReloadMessage", true) == 0)
            {
                Log(msg);
                string logMessage = logTextBox.Text;
                string[] lineMessage = logMessage.Split('\n');
                foreach (DataGridViewRow dataGridViewRow in clientsDataGridView.Rows)
                {
                    if (String.Compare(dataGridViewRow.Cells[1].Value.ToString(), mess[0], true) == 0)
                    {
                        for (int i = 0; i < lineMessage.Length - 1; i++)
                        {
                            string line = lineMessage[i].Substring(10);
                            string[] name = line.Split(':');
                            if (String.Compare(name[0], "SYSTEM", true) != 0)
                            {
                                if (String.Compare(name[1].Trim(), "Message", true) == 0 && String.Compare(name[0].Trim(), mess[0].Trim(), true) == 0)
                                {
                                    string str = name[0] + ":ReloadMessage";
                                    for (int j = 2; j < name.Length; j++)
                                    {
                                        str += ":" + name[j];
                                    }
                                    SendGroupChat(str, long.Parse(dataGridViewRow.Cells[0].Value.ToString()));
                                    Log(str);
                                }
                                if (String.Compare(name[1].Trim(), "Message", true) == 0 && String.Compare(name[0].Trim(), mess[0].Trim(), true) != 0)
                                { 
                                    foreach(DataGridViewRow row in groupChatDataGribView.Rows)
                                    {
                                        if(String.Compare(name[2], row.Cells[0].Value.ToString(), true) == 0)
                                        {
                                            string nameGroup = row.Cells[1].Value.ToString();
                                            string[] nameClient = nameGroup.Split(']');
                                            for (int j = 0; j < nameClient.Length - 1; j++)
                                            {
                                                if (String.Compare(nameClient[j], "[" + name[0], true) == 0)
                                                {
                                                    string str = name[0] + ":ReloadMessage";
                                                    for (int k = 2; k < name.Length; k++)
                                                    {
                                                        str += ":" + name[k];
                                                    }
                                                    SendGroupChat(str, long.Parse(dataGridViewRow.Cells[0].Value.ToString()));
                                                    Log(str);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                Log("sai");
            }
        }

        private void Read(IAsyncResult result)
        {
            MyClient obj = (MyClient)result.AsyncState;
            int bytes = 0;
            if (obj.client.Connected)
            {
                try
                {
                    bytes = obj.stream.EndRead(result);
                }
                catch (Exception ex)
                {
                    Log(ErrorMsg(ex.Message));
                }
            }
            if (bytes > 0)
            {
                obj.data.AppendFormat("{0}", Encoding.UTF8.GetString(obj.buffer, 0, bytes));
                try
                {
                    if (obj.stream.DataAvailable)
                    {
                        obj.stream.BeginRead(obj.buffer, 0, obj.buffer.Length, new AsyncCallback(Read), obj);
                    }
                    else
                    {
                        ///
                        string msg = string.Format("{0}:{1}", obj.username, obj.data.ToString());
                        string[] mess = msg.Split(':');
                        //Log(msg);

                        GroupingMessages(msg, obj.id);
                        obj.data.Clear();
                        obj.handle.Set();
                    }
                }
                catch (Exception ex)
                {
                    obj.data.Clear();
                    Log(ErrorMsg(ex.Message));
                    obj.handle.Set();
                }
            }
            else
            {
                obj.client.Close();
                obj.handle.Set();
            }
        }

        private void ReadAuth(IAsyncResult result)
        {
            MyClient obj = (MyClient)result.AsyncState;

            int bytes = 0;
            if (obj.client.Connected) // Kiểm tra client đã kết nối đến hay chưa
            {
                try
                {
                    bytes = obj.stream.EndRead(result); // Số byte đọc được từ NetworkStream
                }
                catch (Exception ex)
                {
                    Log(ErrorMsg(ex.Message));
                }
            } 
            if (bytes > 0)
            {
                // Nối tiếp dữ liệu vào thuộc tính data
                obj.data.AppendFormat("{0}", Encoding.UTF8.GetString(obj.buffer, 0, bytes));

                try
                {
                    if (obj.stream.DataAvailable) // Dữ liệu trên NetworkStream đã có sẵn để đọc
                    {
                        // Đọc dữ liệu còn
                        obj.stream.BeginRead(obj.buffer, 0, obj.buffer.Length, new AsyncCallback(ReadAuth), obj);
                    }
                    else
                    {
                        JavaScriptSerializer json = new JavaScriptSerializer(); 
                        Dictionary<string, string> data = json.Deserialize<Dictionary<string, string>>(obj.data.ToString());

                        // Kiểm tra sự tồn tại của username, key và chúng có rỗng hay không
                        if (!data.ContainsKey("username") || data["username"].Length < 1 || !data.ContainsKey("key") || !data["key"].Equals(keyTextBox.Text))
                        {
                            obj.client.Close();
                        }
                        else
                        {
                            // data["username"].Length > 200 ? data["username"].Substring(0, 200) : data["username"]
                            obj.username.Append(data["username"]); // Coppy data["username"] vào obj.username

                            //CreateNewKeys();
                            //if(publicKey.Length > 0)
                            //{
                            //    //Dictionary<string, string> data1 = new Dictionary<string, string>();
                            //    //data1.Add("publicKey", "hahaha");
                            //    //JavaScriptSerializer json1 = new JavaScriptSerializer();
                            //    //Send(json1.Serialize(data1));
                            //    //Send("{\"status\": \"authorized\"}", obj);
                            //    //Send("{\"publicKey\": \"" + publicKey + "\"}", obj);
                            //    data.Add("publicKey", publicKey);
                            //    JavaScriptSerializer json2 = new JavaScriptSerializer();
                            //    Send(json2.Serialize(data));
                            //}
                            Send("{\"status\": \"authorized\"}", obj);
                            Log("4");
                        }

                        obj.data.Clear();
                        obj.handle.Set();
                    }
                }
                catch (Exception ex)
                {
                    obj.data.Clear();
                    Log(ErrorMsg(ex.Message));
                    obj.handle.Set();
                }
            }
            else
            {
                obj.client.Close();
                obj.handle.Set();
            }
        }

        private bool Authorize(MyClient obj)
        {
            bool success = false;
            while (obj.client.Connected)
            {
                try
                {
                    obj.stream.BeginRead(obj.buffer, 0, obj.buffer.Length, new AsyncCallback(ReadAuth), obj);
                    obj.handle.WaitOne();
                    if (obj.username.Length > 0)
                    {
                        success = true;
                        break;
                    }
                }
                catch (Exception ex)
                {
                    Log(ErrorMsg(ex.Message));
                }
            }
            return success;
        }

        private void Connection(MyClient obj)
        {
            if (Authorize(obj)) // Đọc và gửi dữ liệu thành công
            {
                clients.TryAdd(obj.id, obj);
                AddToGrid(obj.id, obj.username.ToString()); // Thêm Client đã được kết nối vào GribView
                string msg = string.Format("{0} has connected", obj.username); // Gán username vào chuỗi
                string name = null;
                Log(SystemMsg(msg)); // Hiển thị thông báo
                foreach (DataGridViewRow row in clientsDataGridView.Rows) // Duyệt để xoá Client
                {
                    name += "$" + row.Cells[1].Value.ToString();
                }
                Send(name, -1);

                //foreach (DataGridViewRow row in groupChatDataGribView.Rows)
                //{
                //    string nameGroup = row.Cells[1].Value.ToString();
                //    string[] listNameClientGroup = nameGroup.Split('[');
                //    foreach (string clientGroup in listNameClientGroup)
                //    {
                //        string[] nameClient = clientGroup.Split(']');
                //        if (String.Compare(nameClient[0], obj.username.ToString(), true) == 0)
                //        {
                //            SendGroupChat(SystemMsg("GroupChat:" + row.Cells[0].Value.ToString() + ":" + nameGroup), obj.id);
                //        }
                //    }
                //}
                while (obj.client.Connected)
                {
                    try
                    {
                        obj.stream.BeginRead(obj.buffer, 0, obj.buffer.Length, new AsyncCallback(Read), obj);
                        obj.handle.WaitOne();
                    }
                    catch (Exception ex)
                    {
                        Log(ErrorMsg(ex.Message));
                    }
                }
                obj.client.Close();

                clients.TryRemove(obj.id, out MyClient tmp); // Xoá Client ra khỏi ConcurrentDictionary
                RemoveFromGrid(tmp.id); // Xoá Client ra khỏi GribView

                msg = string.Format(" {0} has disconnected", tmp.username);
                Log(SystemMsg(msg));
                Send(msg, tmp.id); // Gửi tin nhắn đến tất cả
            }
        }

        // Hàm lắng nghe Client kết nối đến
        private void Listener(IPAddress ip, int port)
        {
            // Tạo biến để lắng nghe các kết nối từ Client mạng Tcp
            TcpListener listener = null;

            try
            {
                listener = new TcpListener(ip, port);
                listener.Start();

                // Khoá nội dung form, chuyển đổi chức năng của Start Button
                Active(true);

                while (active) 
                {
                    if (listener.Pending()) // Kiểm tra xem có yêu cầu kết nối đang chờ xử lí hay không
                    {
                        try
                        {
                            MyClient obj = new MyClient();
                            obj.id = id;
                            obj.username = new StringBuilder();
                            obj.client = listener.AcceptTcpClient(); // Chấp nhận yêu cầu kết nối đang chờ xử lý
                            obj.stream = obj.client.GetStream(); // NetworkStream gửi và nhận dữ liệu
                            obj.buffer = new byte[obj.client.ReceiveBufferSize]; // Nhận và đặt kích thước bộ đêm
                            obj.data = new StringBuilder();
                            obj.handle = new EventWaitHandle(false, EventResetMode.AutoReset); // Chỉ định tự động xử lý kết nối
                            Log("1");
                            // Tạo luồng kết nối với Client
                            Thread thread = new Thread(() => Connection(obj))
                            {
                                IsBackground = true
                            };  
                            thread.Start();
                            id++;
                        }
                        catch (Exception ex)
                        {
                            Log(ErrorMsg(ex.Message));
                        }
                    }
                    else
                    {
                        Thread.Sleep(500);
                    }
                }
                Active(false);
            }
            catch (Exception ex)
            {
                Log(ErrorMsg(ex.Message));
            }
            finally
            {
                if (listener != null)
                {
                    listener.Server.Close();
                }
            }
        }

        // Button mở lắng nghe client
        private void StartButton_Click(object sender, EventArgs e)
        {
            // Kiểm tra kết nối đến Client
            if (active)
            {
                active = false;
            }
            else if (listener == null || !listener.IsAlive) // Kiểm tra xem luồng lắng nghe đã kết nối hay chưa
            {
                // Nhận giá trị IP, Port, Username từ Form xuống
                string address = addrTextBox.Text.Trim();
                string number = portTextBox.Text.Trim();
                string username = usernameTextBox.Text.Trim();

                // Tạo biến để kiểm tra lỗi nhập lỗi dữ liệu nhập từ form
                bool error = false;
                // Tạo địa chỉ IP
                IPAddress ip = null;

                if (address.Length < 1) // Nếu IP rỗng thì thông báo lỗi
                {
                    error = true;
                    Log(SystemMsg("Address is required"));
                }
                else
                {
                    try
                    {
                        // Tạo lớp chứa thông tin địa chỉ máy chủ
                        ip = Dns.Resolve(address).AddressList[0];
                        //Log(SystemMsg(ip.ToString()));
                    }
                    catch
                    {
                        error = true;
                        Log(SystemMsg("Address is not valid"));
                    }
                }

                int port = -1;
                if (number.Length < 1) // Nếu Port rỗng thì thông báo lỗi
                {
                    error = true;
                    Log(SystemMsg("Port number is required"));
                }
                else if (!int.TryParse(number, out port)) // Chuyển đổi number từ chuỗi thành số nguyên và gán vào biến port
                {
                    error = true;
                    Log(SystemMsg("Port number is not valid"));
                }
                else if (port < 0 || port > 65535) // Kiểm tra port có hợp lệ hay không
                {
                    error = true;
                    Log(SystemMsg("Port number is out of range"));
                }

                if (username.Length < 1) // Nếu username rỗng thì thông báo lỗi
                {
                    error = true;
                    Log(SystemMsg("Username is required"));
                }

                if (!error) // Nếu không có lỗi thì thực hiện lắng nghe kết nối
                {
                    // Tạo luồng để lắng nghe Client kết nối đến
                    listener = new Thread(() => Listener(ip, port))
                    {
                        IsBackground = true
                    };
                    listener.Start();
                }
            }
        }

        private void Write(IAsyncResult result)
        {
            MyClient obj = (MyClient)result.AsyncState;
            if (obj.client.Connected)
            {
                try
                {
                    obj.stream.EndWrite(result);
                }
                catch (Exception ex)
                {
                    Log(ErrorMsg(ex.Message));
                }
            }
        }

        // Hàm bắt đầu gửi tin nhắn
        private void BeginWrite(string msg, MyClient obj)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(msg);
            if (obj.client.Connected) // Kiểm tra Client đã kết nối hay chưa
            {
                try
                {
                    // Bắt đầu gửi dữ liệu
                    obj.stream.BeginWrite(buffer, 0, buffer.Length, new AsyncCallback(Write), obj);
                }
                catch (Exception ex)
                {
                    Log(ErrorMsg(ex.Message));
                }
            }
        }

        // Gửi tin nhắn cho tất cả mọi người
        private void BeginWrite(string msg, long id = -1)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(msg);
            foreach (KeyValuePair<long, MyClient> obj in clients) // Định nghĩa thêm 1 thuộc tính cho MyClient
            {
                if (id != obj.Value.id && obj.Value.client.Connected)
                {
                    try
                    {
                        obj.Value.stream.BeginWrite(buffer, 0, buffer.Length, new AsyncCallback(Write), obj.Value);
                    }
                    catch (Exception ex)
                    {
                        Log(ErrorMsg(ex.Message));
                    }
                }
            }
        }

        private void BeginWriteGroupChat(string msg, long id = -1)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(msg);
            foreach (KeyValuePair<long, MyClient> obj in clients) // Định nghĩa thêm 1 thuộc tính cho MyClient
            {
                if (id == obj.Value.id && obj.Value.client.Connected)
                {
                    try
                    {
                        obj.Value.stream.BeginWrite(buffer, 0, buffer.Length, new AsyncCallback(Write), obj.Value);
                    }
                    catch (Exception ex)
                    {
                        Log(ErrorMsg(ex.Message));
                    }
                }
            }
        }
        private void Send(string msg, MyClient obj)
        {
            if (send == null || send.IsCompleted) // Kiểm tra xem đã gửi dữ liệu đi chưa
            {
                // Khởi tạo và bắt đầu luông gửi dữ liệu
                send = Task.Factory.StartNew(() => BeginWrite(msg, obj)); 
            }
            else
            {

                send.ContinueWith(antecendent => BeginWrite(msg, obj));
            }
        }

        private void Send(string msg, long id = -1)
        {
            if (send == null || send.IsCompleted)
            {
                send = Task.Factory.StartNew(() => BeginWrite(msg, id));
            }
            else
            {
                send.ContinueWith(antecendent => BeginWrite(msg, id));
            }
        }

        private void SendGroupChat(string msg, long id = -1)
        {
            if (send == null || send.IsCompleted)
            {
                send = Task.Factory.StartNew(() => BeginWriteGroupChat(msg, id));
                Task.WaitAll();
            }
            else
            {
                send.ContinueWith(antecendent => BeginWriteGroupChat(msg, id));
            }
        }

        private void SendTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                if (sendTextBox.Text.Length > 0)
                {
                    string msg = sendTextBox.Text;
                    sendTextBox.Clear();
                    Log(string.Format("{0} (You): {1}", usernameTextBox.Text.Trim(), msg));
                    Send(string.Format("{0}: {1}", usernameTextBox.Text.Trim(), msg, -1));
                }
            }
        }

        private void CreateNewKeys()
        {
            //lets take a new CSP with a new 2048 bit rsa key pair
            RSACryptoServiceProvider csp = new RSACryptoServiceProvider(2048);
            //how to get the private key
            RSAParameters privKey = csp.ExportParameters(true);
            //and the public key ...
            RSAParameters pubKey = csp.ExportParameters(false);
            //converting the public key into a string representation
            {
                //we need some buffer
                var sw = new StringWriter();
                //we need a serializer
                var xs = new XmlSerializer(typeof(RSAParameters));
                //serialize the key into the stream
                xs.Serialize(sw, pubKey);
                publicKey = sw.ToString();
                Log(publicKey);
            }
            {
                //we need some buffer
                var sw = new StringWriter();
                //we need a serializer
                XmlSerializer xs = new XmlSerializer(typeof(RSAParameters));
                //serialize the key into the stream
                xs.Serialize(sw, privKey);
                //get the string from the stream
                privateKey = sw.ToString();
            }
        }

        private void Disconnect(long id = -1)
        {
            if (disconnect == null || !disconnect.IsAlive)
            {
                disconnect = new Thread(() =>
                {
                    if (id >= 0)
                    {
                        clients.TryGetValue(id, out MyClient obj);
                        obj.client.Close();
                        RemoveFromGrid(obj.id);
                    }
                    else
                    {
                        foreach (KeyValuePair<long, MyClient> obj in clients)
                        {
                            obj.Value.client.Close();
                            RemoveFromGrid(obj.Value.id);
                        }
                    }
                })
                {
                    IsBackground = true
                };
                disconnect.Start();
            }
        }

        private void DisconnectButton_Click(object sender, EventArgs e)
        {
            Disconnect();
        }

        private void Server_FormClosing(object sender, FormClosingEventArgs e)
        {
            exit = true;
            active = false;
            Disconnect();
        }

        private void ClientsDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == clientsDataGridView.Columns["dc"].Index)
            {
                long.TryParse(clientsDataGridView.Rows[e.RowIndex].Cells["identifier"].Value.ToString(), out long id);
                Disconnect(id);
            }
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            Log();
        }

        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (keyTextBox.PasswordChar == '*')
            {
                keyTextBox.PasswordChar = '\0';
            }
            else
            {
                keyTextBox.PasswordChar = '*';
            }
        }

        private void groupChatDataGribView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Log("hahaha");
        }
    }
}