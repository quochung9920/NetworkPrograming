using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace Client
{
    public partial class Client : Form
    {
        private bool connected = false;
        private Thread client = null;
        private struct MyClient
        {
            public string username;
            public string key;
            public TcpClient client;
            public NetworkStream stream;
            public byte[] buffer;
            public StringBuilder data;
            public EventWaitHandle handle;
        };
        // Object lưu trữ thông tin kết nối
        private MyClient obj;
        private Task send = null;
        private bool exit = false;
        private string publicKey;
        ASCIIEncoding ByteConverter = new ASCIIEncoding();
        public Client()
        {
            InitializeComponent();
            checkedListBox.Hide();
            createGroupButton.Hide();
        }

        private void Log(string msg = "") // clear the log if message is not supplied or is empty
        {
            if (!exit)
            {
                logTextBox.Invoke((MethodInvoker)delegate
                {
                    if (msg.Length > 0)
                    {
                        logTextBox.AppendText(string.Format("[ {0} ] {1}{2}", DateTime.Now.ToString("HH:mm"), msg, Environment.NewLine));
                    }
                    else
                    {
                        logTextBox.Clear();
                    }
                });
            }
        }


        private string ErrorMsg(string msg)
        {
            return string.Format("ERROR: {0}", msg);
        }

        private string SystemMsg(string msg)
        {
            return string.Format("SYSTEM: {0}", msg);
        }

        private void AddToGrid(string name)
        {
            // Tạo luồng để thêm Client vào khung GribView
            clientsDataGridView.Invoke((MethodInvoker)delegate
            {
                string[] row = new string[] { name };
                clientsDataGridView.Rows.Add(row);
            });
        }

        private void RemoveFromGrid(string name)
        {
            clientsDataGridView.Invoke((MethodInvoker)delegate
            {
                foreach (DataGridViewRow row in clientsDataGridView.Rows) // Duyệt để xoá Client
                {
                    if (String.Compare(row.Cells[0].Value.ToString().Trim(), name.Trim(), true) == 0)
                    {
                        clientsDataGridView.Rows.RemoveAt(row.Index);
                        break;
                    }
                }
            });
        }

        private void AddToGridGroupChat(string id, string name)
        {
            // Tạo luồng để thêm Client vào khung GribView
            groupChatDataGribView.Invoke((MethodInvoker)delegate
            {
                string[] row = new string[] { id, name };
                groupChatDataGribView.Rows.Add(row);
            });
        }

        private void Connected(bool status)
        {
            if (!exit)
            {
                connectButton.Invoke((MethodInvoker)delegate
                {
                    connected = status;
                    if (status)
                    {
                        addrTextBox.Enabled = false;
                        portTextBox.Enabled = false;
                        usernameTextBox.Enabled = false;
                        keyTextBox.Enabled = false;
                        connectButton.Text = "Disconnect";
                        Log(SystemMsg("You are now connected"));
                    }
                    else
                    {
                        addrTextBox.Enabled = true;
                        portTextBox.Enabled = true;
                        usernameTextBox.Enabled = true;
                        keyTextBox.Enabled = true;
                        connectButton.Text = "Connect";
                        Log(SystemMsg("You are now disconnected"));

                        clientsDataGridView.Invoke((MethodInvoker)delegate
                        {
                            foreach (DataGridViewRow row in clientsDataGridView.Rows) // Duyệt để xoá Client
                            {
                                clientsDataGridView.Rows.RemoveAt(row.Index);
                            }
                        });

                    }
                });
            }
        }

        private void LogGroupChat(string msg)
        {
            logGroupChat.Invoke((MethodInvoker)delegate
            {
                if (msg.Length > 0)
                {
                    logGroupChat.AppendText(string.Format("[ {0} ] {1}{2}", DateTime.Now.ToString("HH:mm"), msg, Environment.NewLine));
                }
                else
                {
                    logGroupChat.Clear();
                }
            });
        }

        private void GroupingMessages(string msg)
        {
            string[] vs = msg.Split(':');
            if (String.Compare(vs[0], "SYSTEM", true) == 0 &&
              String.Compare(vs[1], "GroupChat", true) == 0)
            {
                AddToGridGroupChat(vs[2], vs[3]);
            }
            else if (String.Compare(vs[1], "Message", true) == 0)
            {
                Log(msg);
                foreach (DataGridViewRow row in groupChatDataGribView.Rows)
                {
                    if (row.Selected == true)
                    {
                        if (String.Compare(row.Cells[0].Value.ToString(), vs[2], true) == 0)
                        {
                            string mess = vs[0] + ":";
                            for (int i = 3; i < vs.Length; i++)
                            {
                                mess += vs[i];
                            }
                            LogGroupChat(mess);
                        }
                    }
                }
            }
            else if (String.Compare(vs[1], "LoadGroupChat", true) == 0)
            {
                try
                {
                    if (String.Compare(vs[2], "FINISH", true) != 0)
                    {
                        AddToGridGroupChat(vs[2], vs[3]);
                        Send("ReloadGroupChat");
                    }
                    else if (String.Compare(vs[2], "FINISH", true) == 0 && groupChatDataGribView.Rows.Count > 0)
                    {
                        if (String.Compare(usernameTextBox.Text, vs[3], true) == 0)
                        {
                            Send("ReloadMessage");
                            Log("ReloadMessage");
                        }
                    }
                }
                catch(Exception ex)
                {
                    Log(ex.Message + " Load Group Chat");
                }
            }
            else if (String.Compare(vs[1].Trim(), "ReloadMessage", true) == 0)
            {
                Log(msg);
            }
            else
            {
                Log(vs[1]);
            }
        }
        private void Read(IAsyncResult result)
        {
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
                        obj.stream.BeginRead(obj.buffer, 0, obj.buffer.Length, new AsyncCallback(Read), null);
                    }
                    else
                    {
                        if(String.Compare(obj.data[0].ToString(), "$", true) == 0)
                        {
                            string[] listName = obj.data.ToString().Split('$');
                            if(clientsDataGridView.Rows.Count > 0)
                            {
                                foreach (string name in listName)
                                {
                                    int count = 0;
                                    if (name != "")
                                    {
                                        foreach (DataGridViewRow row in clientsDataGridView.Rows)
                                        {
                                            if (String.Compare(row.Cells[0].Value.ToString(), name, false) == 0)
                                            {
                                                count++;
                                            }
                                        }
                                        if (count == 0)
                                        {
                                            AddToGrid(name);
                                        }
                                    }
                                }
                            }
                            else
                            {
                                foreach (string name in listName)
                                {
                                    if (name != "")
                                    {
                                            AddToGrid(name);
                                    }
                                }
                                Send("ReloadGroupChat");
                            }
                        }
                        else if(String.Compare(obj.data[0].ToString(), " ", true) == 0)
                        {
                            string[] listName = obj.data.ToString().Split(' ');
                            RemoveFromGrid(listName[1]);
                        }
                        else
                        {
                            //Log(obj.data.ToString());
                            GroupingMessages(obj.data.ToString());
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

        private void ReadAuth(IAsyncResult result)
        {
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
                        obj.stream.BeginRead(obj.buffer, 0, obj.buffer.Length, new AsyncCallback(ReadAuth), null);
                    }
                    else
                    {
                        JavaScriptSerializer json = new JavaScriptSerializer(); 
                        Dictionary<string, string> data = json.Deserialize<Dictionary<string, string>>(obj.data.ToString());
                        if (data.ContainsKey("status"))
                        {
                            //Log(data["status"].ToString());
                            //Log(data["name"]);
                            Connected(true);
                            //publicKey = data["publicKey"];
                            //Log(publicKey);
                        }
                        //Connected(true);
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

        private bool Authorize()
        {
            bool success = false;

            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("username", obj.username);
            data.Add("key", obj.key);
            JavaScriptSerializer json = new JavaScriptSerializer(); 
            Send(json.Serialize(data));

            while (obj.client.Connected)
            {
                try
                {
                    obj.stream.BeginRead(obj.buffer, 0, obj.buffer.Length, new AsyncCallback(ReadAuth), null);
                    obj.handle.WaitOne();
                    if (connected)
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
            if (!connected)
            {
                Log(SystemMsg("Unauthorized"));
            }
            return success;
        }

        // Hàm kết nối đến Server
        private void Connection(IPAddress ip, int port, string username, string key)
        {
            try
            {
                // Khởi tạo object Client và gán giá trị
                obj = new MyClient(); 
                obj.username = username;
                obj.key = key;
                obj.client = new TcpClient(); // Cung cấp kết nối Tcp
                obj.client.Connect(ip, port); // Gửi yêu cầu kết nối đến Server
                obj.stream = obj.client.GetStream(); // NetworkStream gửi và nhận dữ liệu
                obj.buffer = new byte[obj.client.ReceiveBufferSize]; // Nhận và đặt kích thước bộ đệm
                obj.data = new StringBuilder();
                obj.handle = new EventWaitHandle(false, EventResetMode.AutoReset); // Chỉ định tự động xử lý kết nối
                
                if (Authorize())
                {
                    while (obj.client.Connected)
                    {
                        try
                        {
                            obj.stream.BeginRead(obj.buffer, 0, obj.buffer.Length, new AsyncCallback(Read), null);
                            obj.handle.WaitOne();
                        }
                        catch (Exception ex)
                        {
                            Log(ErrorMsg(ex.Message));
                        }
                    }
                    obj.client.Close();
                    Connected(false);
                }
            }
            catch (Exception ex)
            {
                Log(ErrorMsg(ex.Message));
            }
        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {
            if (connected)
            {
                obj.client.Close();
            }
            else if (client == null || !client.IsAlive) // Kiểm tra xem Clietn đã kết nối hay chưa
            {
                // Lấy thông tin IP, Port và username từ form
                string address = addrTextBox.Text.Trim();
                string number = portTextBox.Text.Trim();
                string username = usernameTextBox.Text.Trim();

                // Tạo biến để kiểm tra lỗi nhập từ form
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
                else if (!int.TryParse(number, out port)) // Chuyển đổi number từ chuỗi sang sô nguyên và gán vào biến port
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

                if (!error) // Nếu không có lỗi nhập thông tin thì thực hiện kết nối đến Server
                {
                    // Tạo luồng để kết nối đến Server
                    client = new Thread(() => Connection(ip, port, username, keyTextBox.Text))
                    {
                        IsBackground = true
                    };
                    client.Start();
                }
            }
        }

        private void Write(IAsyncResult result)
        {
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

        private void BeginWrite(string msg)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(msg);
            if (obj.client.Connected)
            {
                try
                {
                    obj.stream.BeginWrite(buffer, 0, buffer.Length, new AsyncCallback(Write), null);
                }
                catch (Exception ex)
                {
                    Log(ErrorMsg(ex.Message));
                }
            }
        }

        private void Send(string msg)
        {
            if (send == null || send.IsCompleted)
            {
                send = Task.Factory.StartNew(() => BeginWrite(msg));
            }
            else
            {
                send.ContinueWith(antecendent => BeginWrite(msg));
            }
        }

        public string Encryption(string strText)
        {
            //Import Key from Server
            string pubKey = publicKey;
            //byte[] testData = Encoding.UTF8.GetBytes(strText);
            byte[] dataToEncrypt = ByteConverter.GetBytes(strText);
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(1024))
            {
                try
                {
                    // client encrypting data with public key issued by server                    
                    rsa.FromXmlString(pubKey.ToString());
                    byte[] encryptedData = rsa.Encrypt(dataToEncrypt, true);
                    string base64Encrypted = Convert.ToBase64String(encryptedData);
                    return base64Encrypted;
                }
                finally
                {
                    rsa.PersistKeyInCsp = false;
                }
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
                    string msg = "";
                    foreach (DataGridViewRow row in groupChatDataGribView.Rows)
                    {
                        if(row.Selected == true)
                        {
                            msg = "Message:" + row.Cells[0].Value.ToString() + ":" + sendTextBox.Text;
                        }
                    }
                    sendTextBox.Clear();
                    //Log(string.Format("{0} (You):{1}", obj.username, msg));
                    if (connected)
                    {
                        Send(msg);
                    }
                }
            }
        }

        private void Client_FormClosing(object sender, FormClosingEventArgs e)
        {
            exit = true;
            if (connected)
            {
                obj.client.Close();
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


        private void clientsDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            string msg = "";
            string str = "[" + usernameTextBox.Text + "]";
            foreach (DataGridViewRow row in clientsDataGridView.Rows)
            {
                if (row.Selected == true)
                {
                    if (String.Compare(row.Cells[0].Value.ToString(), usernameTextBox.Text, true) != 0)
                    {
                        str += "[" + row.Cells[0].Value.ToString() + "]";
                        msg = "CreateGroupChat:[" + row.Cells[0].Value.ToString() + "]+:" + " join group chat";
                        //Log(string.Format("{0} (You):{1}", obj.username, msg));
                    }
                }
            }
            if (groupChatDataGribView.Rows.Count > 0)
            {
                int count = 0;
                int count2 = 0;
                foreach (DataGridViewRow rowGroupChat in groupChatDataGribView.Rows)
                {
                    if (string.Compare(str, rowGroupChat.Cells[1].Value.ToString(), true) == 0)
                    {
                        count++;
                    }
                    else
                    {
                        string[] rgc = rowGroupChat.Cells[1].Value.ToString().Split(']');
                        string[] s = str.Split(']');
                        if (rgc.Length == s.Length)
                        {
                            foreach (string c in rgc)
                            {
                                foreach (string s2 in s)
                                {
                                    if (String.Compare(c, s2, true) == 0)
                                    {
                                        count2++;
                                    }
                                }
                            }
                        }
                    }
                }
                if (count == 0 && count2 != 5)
                {
                    Send(msg);
                }
            }
            else
            {
                Send(msg);
            }
        }

        private void GroupingMessages2(string nameGroup)
        {
            string logText = logTextBox.Text;
            string[] lineLogText = logText.Split('\n');
            logGroupChat.Clear();
            for (int i = 0; i < lineLogText.Length - 1; i++)
            {
                //LogGroupChat(lineLogText[i]);

                if (lineLogText[i] != null)
                {
                    string contentLineLogText = lineLogText[i].Substring(10);
                    string[] e = contentLineLogText.Split(':');
                    if (String.Compare(e[0], "SYSTEM", true) != 0)
                    {
                        if (String.Compare(e[0].Trim(), "ReloadMessage", true) != 0)
                        {

                            try
                            {
                                if (String.Compare(e[2], nameGroup, true) == 0)
                                {
                                    string mess = e[0] + ":";
                                    for (int j = 3; j < e.Length; j++)
                                    {
                                        mess += e[j];
                                    }
                                    LogGroupChat(mess);
                                }

                            }
                            catch (Exception ex)
                            {
                                Log(ex.Message);
                            }

                        }
                    }

                }

            }

        }
        private void groupChatDataGribView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
                for (int i = 0; i < groupChatDataGribView.Rows.Count; i++)
                {
                    DataGridViewRow row = groupChatDataGribView.Rows[i];
                    if (row.Selected == true)
                    {
                        row.DefaultCellStyle.SelectionBackColor = Color.Pink;
                        logLabel.Hide();
                        logTextBox.Hide();
                        logGroupChat.Show();
                        GroupingMessages2(row.Cells[0].Value.ToString());
                    }
                }
        }

        private void toolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(String.Compare(toolStripMenuItem.Text, "Chat", true) == 0)
            {
                logLabel.Hide();
                logTextBox.Hide();
                logGroupChat.Show();
                toolStripMenuItem.Text = "Log";
            }
            else
            {
                logLabel.Show();
                logTextBox.Show();
                logGroupChat.Hide();
                toolStripMenuItem.Text = "Chat";
            }
        }

        private void AddClientSelectionList()
        {
            foreach(DataGridViewRow row in clientsDataGridView.Rows)
            {
                if(String.Compare(row.Cells[0].Value.ToString(), usernameTextBox.Text, true) != 0)
                {
                    checkedListBox.Items.Add(row.Cells[0].Value.ToString());
                }
            }
        }
        private void createGroupChatButton_Click(object sender, EventArgs e)
        {
            if(String.Compare(createGroupChatButton.Text, "Create Group Chat", true) == 0)
            {
                createGroupChatButton.Text = "List Client";
                clientsDataGridView.Hide();
                checkedListBox.Show();
                AddClientSelectionList();
                createGroupButton.Show();
            }
            else
            {
                createGroupChatButton.Text = "Create Group Chat";
                clientsDataGridView.Show();
                checkedListBox.Hide();
                checkedListBox.Items.Clear();
                createGroupButton.Hide();
            }
        }

        private void createGroupButton_Click(object sender, EventArgs e)
        {
            string str = "";
            foreach (var i in checkedListBox.CheckedItems)
            {
                str += "[" + i.ToString() + "]+";
            }
            if(str.Length > 0)
            {
                string msg = "CreateGroupChat:" + str + ":join group chat";
                Send(msg);
            }
        }

        private void Client_Load(object sender, EventArgs e)
        {

        }
    }
}
