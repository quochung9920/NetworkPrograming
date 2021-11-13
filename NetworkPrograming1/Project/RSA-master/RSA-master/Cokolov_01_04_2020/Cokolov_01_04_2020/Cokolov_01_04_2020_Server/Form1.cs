using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using System.Security;
using System.Threading.Tasks;
using System.Threading;
using System.Security.Cryptography;
using Microsoft.VisualBasic;
using System.Xml;

namespace Serverthang
{
    public partial class Form1 : Form
    {
        RsaEnc rs = new RsaEnc();
        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            Connect();
        }
        private void ButtonStartServer_Click(object sender, EventArgs e)
        {
            
        }
        private void ButtonStopServer_Click(object sender, EventArgs e)
        {

        }
        private void ButtonSendRequest_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != "RSA")
            {
                MessageBox.Show("Not encrypted");
                foreach (Socket item in clientList)
                {
                    SendMesseage(item);
                }
                AddMesseage(textBox1.Text);
                textBox1.Clear();
            }
            else if (comboBox1.SelectedItem == "RSA")
            {
                MessageBox.Show("RSA");
                foreach (Socket item in clientList)
                {
                    SendRSA(item);
                }
                AddMesseage(textBox1.Text);
            }
        }
        //Using RsaENC
        /*
        void SendRSA(Socket client)
        {
            string text = textBox1.Text;
            rs.Encrypt(text);
            string txtsend = rs.Encrypt(text);
            byte[] request = Serialize(txtsend);
            if (request != null)
            {
                client.Send(Serialize(txtsend));
            }
            txtshow.AppendText(text);
            txtshow.AppendText(": ");
            AddMesseage(txtsend);
        }
        */
        void SendRSA(Socket client)
        {
            string text = textBox1.Text;
            plaintext = ByteConverter.GetBytes(text);
            string txtsend = Encryption(text);
            byte[] request = Serialize(txtsend);
            if (request != null)
            {
                client.Send(Serialize(txtsend));
                //serverthang.Send(request);
            }
            txtshow.AppendText(text);
            txtshow.AppendText(": ");
            AddMesseage(txtsend);
        }

        //Using RsaENC
        void SendKey1(Socket client)
        {
            //string Key = rs.PublicKeyString();
            byte[] request = Serialize(rs.PublicKeyString());
            if (request != null)
            {
                client.Send(Serialize(rs.PublicKeyString()));
                //serverthang.Send(request);
            }
        }
        void Goitin(Socket clientthang)
        {
            string text = textBox1.Text;
            if (textBox1.Text != null)
            {
                serverthang.Send(Serialize(textBox1.Text));
            }
        }
        void SendMesseage(Socket client)
        {
            //string text = textBox1.Text;
            byte[] request = Serialize(textBox1.Text);
            if (request != null)
            {
                client.Send(Serialize(textBox1.Text));
                //serverthang.Send(request);
            }
        }

        //Using Internal CreateNewKeys()
        void SendKey(Socket client)
        {
            string Key = txtPublickey.Text;
            byte[] request = Serialize(Key);
            if (request != null)
            {
                client.Send(Serialize(Key));
            }
        }
        void ReceiveMesseage(object obj)
        {
            Socket client = obj as Socket;
            try
            {
                while (true)
                {
                    byte[] data = new byte[1024 * 5000];
                    client.Receive(data);
                    //string messeage = Encoding.UTF8.GetString(data);
                    string messeage = (string)Derserialize(data);
                    foreach (Socket item in clientList)
                    {
                        if (item != null)
                        {
                            item.Send(Serialize(messeage));
                        }
                    }
                    AddMesseage(messeage);
                }
            }
            catch
            {
                clientList.Remove(client);
                client.Close();
            }
        }

        byte[] Serialize(object obj)
        {
            MemoryStream stream = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, obj);
            return stream.ToArray();
        }
        object Derserialize(byte[] data)
        {
            MemoryStream stream = new MemoryStream(data);
            BinaryFormatter formatter = new BinaryFormatter();
            return formatter.Deserialize(stream);
            return stream.ToArray();
        }

        IPEndPoint IP;
        Socket serverthang;
        List<Socket> clientList;
        void Connect()  //Giong ham StarServer
        {
            clientList = new List<Socket>();
            IP = new IPEndPoint(IPAddress.Any, 9999);
            serverthang = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            serverthang.Bind(IP);   //Sever make connect, therefore it's waitting //Server tao ra ket noi cho nen no phai ngoi doi
            Thread Listen = new Thread(() => {
                try
                {
                    while (true)
                    {
                        serverthang.Listen(100); //Waitting 100 in stack //Doi 100 dua trong hang cho, doi 100 Stack
                        Socket client = serverthang.Accept();
                        clientList.Add(client);
                        Thread Nhan = new Thread(ReceiveMesseage);
                        Nhan.IsBackground = true;
                        Nhan.Start(client);
                    }
                }
                catch
                {
                    IP = new IPEndPoint(IPAddress.Any, 9999);
                    serverthang = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
                }
            });
            Listen.IsBackground = true;
            Listen.Start();
        }

        void AddMesseage(string s)
        {
            //lsvMesseage.Items.Add(new ListViewItem() { Text = s });
            //textBox1.Clear();
            txtshow.AppendText(s + Environment.NewLine);
            textBox1.Clear();
        }
        void AddMesseagePublickey(string s)
        {
            //txtPublickey.AppendText(s + Environment.NewLine);
            txtPublickey.Text = s;
            textBox1.Clear();
        }
        void AddMesseagePrivatekey(string s)
        {
            //txtPrivatekey.AppendText(s + Environment.NewLine);
            txtPrivatekey.Text = s;
            textBox1.Clear();
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == "RSA")
            {
                //MessageBox.Show("The selected plan is RSA");
                label1.Visible =true;
                label3.Visible = true;
                txtPublickey.Visible = true;
                txtPrivatekey.Visible = true;
                BtPublickey.Visible = true;
                btDecrypt.Visible = true;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        /* //Code from Microsoft 
        UnicodeEncoding ByteConverter = new UnicodeEncoding();
        RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
        byte[] plaintext;
        byte[] encryptedtext;
        static public byte[] RSAEncrypt(byte[] DataToEncrypt, RSAParameters RSAKeyInfo, bool DoOAEPPadding)
        {
            try
            {
                RSACryptoServiceProvider RSAalg = new RSACryptoServiceProvider(2048);
                RSAalg.ImportParameters(RSAKeyInfo);
                return RSAalg.Encrypt(DataToEncrypt, DoOAEPPadding);
            }
            catch (CryptographicException e)
            {
                return null;
            }
        }
        */

        /* //Code from Microsoft 
        static public byte[] RSADecrypt(byte[] DataToDecrypt, RSAParameters RSAKeyInfo, bool DoOAEPPadding)
        {
            try
            {
                RSACryptoServiceProvider RSAalg = new RSACryptoServiceProvider(2048);
                RSAalg.ImportParameters(RSAKeyInfo);
                return RSAalg.Decrypt(DataToDecrypt, DoOAEPPadding);
            }
            catch (CryptographicException e)
            {
                return null;
            }
        }
        */
        UnicodeEncoding ByteConverter = new UnicodeEncoding();
        RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
        byte[] plaintext;
        byte[] encryptedtext;
        public string Encryption(string strText)
        {
            //Import Key from Server
            var publicKey = GetPublicKey();
            var testData = Encoding.UTF8.GetBytes(strText);
            using (var rsa = new RSACryptoServiceProvider(1024))
            {
                try
                {
                    // client encrypting data with public key issued by server                    
                    rsa.FromXmlString(publicKey.ToString());
                    var encryptedData = rsa.Encrypt(testData, true);
                    var base64Encrypted = Convert.ToBase64String(encryptedData);
                    return base64Encrypted;
                }
                finally
                {
                    rsa.PersistKeyInCsp = false;
                }
            }
        }
        public string Decryption(string strText)
        {

            var privateKey = UsingPrivateKey();
            var testData = Encoding.UTF8.GetBytes(strText);
            using (var rsa = new RSACryptoServiceProvider(1024))
            {
                try
                {
                    var base64Encrypted = strText;
                    // server decrypting data with private key                    
                    rsa.FromXmlString(privateKey);
                    var resultBytes = Convert.FromBase64String(base64Encrypted);
                    var decryptedBytes = rsa.Decrypt(resultBytes, true);
                    var decryptedData = Encoding.UTF8.GetString(decryptedBytes);
                    return decryptedData.ToString();
                }
                finally
                {
                    rsa.PersistKeyInCsp = false;
                }
            }
        }
        private string GetPublicKey()
        {
            string KeyfromClient = txtshow.Text;
            return KeyfromClient;
        }
        private string UsingPrivateKey()
        {
            string ServerPrivateKey = txtPrivatekey.Text;
            return ServerPrivateKey;
        }
        ///*
        private void CreateNewKeys()
        {
            //lets take a new CSP with a new 2048 bit rsa key pair
            RSACryptoServiceProvider csp = new RSACryptoServiceProvider(2048);
            //how to get the private key
            RSAParameters privKey = csp.ExportParameters(true);
            //and the public key ...
            RSAParameters pubKey = csp.ExportParameters(false);
            //converting the public key into a string representation
            string pubKeyString;
            {
                //we need some buffer
                var sw = new StringWriter();
                //we need a serializer
                var xs = new System.Xml.Serialization.XmlSerializer(typeof(RSAParameters));
                //serialize the key into the stream
                xs.Serialize(sw, pubKey);
                //get the string from the stream
                pubKeyString = sw.ToString();                   //right
                AddMesseagePublickey(pubKeyString);             //right
                //return pubKeyString;
            }
            string privKeyString;
            {
                //we need some buffer
                var sw = new StringWriter();
                //we need a serializer
                var xs = new System.Xml.Serialization.XmlSerializer(typeof(RSAParameters));
                //serialize the key into the stream
                xs.Serialize(sw, privKey);
                //get the string from the stream
                privKeyString = sw.ToString();
                AddMesseagePrivatekey(privKeyString);
            }
        }
        //*/
        private void BtPublickey_Click(object sender, EventArgs e)
        {
            CreateNewKeys();
            foreach (Socket item in clientList)
            {
                SendKey(item);
            }
        }

        private void BtClear_Click(object sender, EventArgs e)
        {
            txtshow.Clear();
            txtPublickey.Clear();
            txtPrivatekey.Clear();
        }

        private void btDecrypt_Click(object sender, EventArgs e)
        {
            string output = Decryption(txtshow.Text);
            MessageBox.Show("The result is: " + output);
            txtshow.Clear();
        }
    }
    //Using for try another way. Not using in this Form Доан Конг Тханг
    public class RsaEnc 
    {
        private static RSACryptoServiceProvider csp = new RSACryptoServiceProvider(2048);
        RSAParameters _PrivateKey;
        RSAParameters _PublicKey;
        public RsaEnc()
        {
            _PrivateKey = csp.ExportParameters(true);
            _PublicKey = csp.ExportParameters(false);
        }
        public string PublicKeyString()
        {
            var sw = new StringWriter();
            var xs = new System.Xml.Serialization.XmlSerializer(typeof(RSAParameters));
            xs.Serialize(sw, _PublicKey);
            return sw.ToString();
        }
        public string Encrypt(string plainText)
        {
            RSACryptoServiceProvider csp = new RSACryptoServiceProvider();
            csp.ImportParameters(_PrivateKey);
            var data = Encoding.Unicode.GetBytes(plainText);
            var cypher = csp.Encrypt(data, false);
            return Convert.ToBase64String(cypher);
        }
        public string Decrypt(string cypherText)
        {
            var dataBytes = Convert.FromBase64String(cypherText);
            csp.ImportParameters(_PrivateKey);
            var plainnext = csp.Decrypt(dataBytes, false);
            return Encoding.Unicode.GetString(plainnext);
        }
    }
}
