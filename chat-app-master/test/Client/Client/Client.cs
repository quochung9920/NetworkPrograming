﻿using System;
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

        public Client()
        {
            InitializeComponent();
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
                    }
                });
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
                        Log(obj.data.ToString());
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
                        if (data.ContainsKey("status") && data["status"].Equals("authorized"))
                        {
                            Log(data["status"].ToString());
                            Connected(true);
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

            byte[] buffer = Encoding.ASCII.GetBytes(msg);
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

        private static void Send(RSA key, string secretMessage, out byte[] iv, out byte[] encryptedSessionKey, out byte[] encryptedMessage)
        {
            using (Aes aes = new AesCryptoServiceProvider())
            {
                iv = aes.IV; // Khởi tạo Vector đối xứng

                // Encrypt the session key
                // Tạo dữ liệu trao đổi khoá mã hoá không đối xứng RSA
                RSAOAEPKeyExchangeFormatter keyFormatter = new RSAOAEPKeyExchangeFormatter(key);
                // Tạo key trao đổi dữ liệu được gửi đến người nhận
                encryptedSessionKey = keyFormatter.CreateKeyExchange(aes.Key, typeof(Aes));

                // Encrypt the message
                using (MemoryStream ciphertext = new MemoryStream())
                using (CryptoStream cs = new CryptoStream(ciphertext, aes.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    byte[] plaintextMessage = Encoding.UTF8.GetBytes(secretMessage);
                    cs.Write(plaintextMessage, 0, plaintextMessage.Length);
                    cs.Close();

                    encryptedMessage = ciphertext.ToArray();
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

        private void SendTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                if (sendTextBox.Text.Length > 0)
                {
                    string msg = sendTextBox.Text;

                    byte[] encryptedSessionKey = null;
                    byte[] encryptedMessage = null;
                    byte[] iv = null;
                    byte[] publicKey = null;

                    Dictionary<string, byte[]> data = new Dictionary<string, byte[]>();
                    Bob bob = new Bob();
                    {
                        using (RSACryptoServiceProvider rsaKey = new RSACryptoServiceProvider())
                        {
                            // Get Bob's public key

                            publicKey = bob.key;
                            rsaKey.ImportCspBlob(publicKey);
                            Send(rsaKey, msg, out iv, out encryptedSessionKey, out encryptedMessage);
                        }
                        
                    }
                    data.Add("bob", bob);
                    data.Add("publicKey", publicKey);
                    data.Add("iv", iv);
                    data.Add("encryptedSessionKey", encryptedSessionKey);
                    data.Add("encryptedMessage", encryptedMessage);
                    JavaScriptSerializer json = new JavaScriptSerializer();
                    Log(json.Serialize(data));
                    sendTextBox.Clear();
                    Log(string.Format("{0} (You): {1}", obj.username, msg));
                    if (connected)
                    {
                        Send(json.Serialize(data));
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
    }
}
public class Bob : IDisposable
{
    public byte[] key;
    private RSACryptoServiceProvider rsaKey = new RSACryptoServiceProvider();
    public Bob()
    {
        key = rsaKey.ExportCspBlob(true);
    }
    public void Receive(byte[] iv, byte[] encryptedSessionKey, byte[] encryptedMessage)
    {

        using (Aes aes = new AesCryptoServiceProvider())
        {
            aes.IV = iv;

            // Decrypt the session key
            RSAOAEPKeyExchangeDeformatter keyDeformatter = new RSAOAEPKeyExchangeDeformatter(rsaKey);
            aes.Key = keyDeformatter.DecryptKeyExchange(encryptedSessionKey);

            // Decrypt the message
            using (MemoryStream plaintext = new MemoryStream())
            using (CryptoStream cs = new CryptoStream(plaintext, aes.CreateDecryptor(), CryptoStreamMode.Write))
            {
                cs.Write(encryptedMessage, 0, encryptedMessage.Length);
                cs.Close();

                string message = Encoding.UTF8.GetString(plaintext.ToArray());
                Console.WriteLine(message);
            }
        }
    }
    public void Dispose()
    {
        rsaKey.Dispose();
    }
}