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

namespace Clientthang
{
    public partial class Form1 : Form
    {
        RsaEnc rs = new RsaEnc();
        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            Connect(); // Ket noi ngay khi bat dau, khong dung button connect
        }

        void SendMesseage()
        {
            string text = textBoxRequest.Text;
            byte[] request = Serialize(textBoxRequest.Text);
            if (request != null)
            {
                clientthang.Send(request);
            }
        }
        void SendKey() //Send Public Key
        {
            string Key = txtPublickey.Text;
            byte[] request = Serialize(Key);
            if (request != null)
            {
                clientthang.Send(Serialize(Key));
            }
        }

        void Goitin1()
        {
            string text = textBoxRequest.Text;
            if (textBoxRequest.Text != null)
            {
                clientthang.Send(Serialize(textBoxRequest.Text));
            }
        }
        void SendRSA()
        {
            string text = textBoxRequest.Text;
            plaintext = ByteConverter.GetBytes(text);
            string txtsend = Encryption(text);
            byte[] request = Serialize(txtsend);
            if (request != null)
            {
                clientthang.Send(Serialize(txtsend));
            }
            txtboxshow.AppendText(text);
            txtboxshow.AppendText(": ");
            AddMesseage(txtsend);
        }
        //Using RsaENC
        /*
        void SendRSA()
        {
            string text = textBoxRequest.Text;
            string txtsend = rs.Encrypt(text);
            byte[] request = Serialize(txtsend);
            if (request != null)
            {
                clientthang.Send(Serialize(txtsend));
            }
            txtboxshow.AppendText(text);
            txtboxshow.AppendText(": ");
            AddMesseage(txtsend);
        }
        */
        void Nhantin()
        {
            try
            {
                while (true)
                {
                    byte[] data = new byte[1024 * 5000];
                    clientthang.Receive(data);
                    string messeage = (string)Derserialize(data);
                    AddMesseage(messeage); // nhận tin từ Server về, chuyển thành 1 chuỗi và add chuỗi vào trong  tin nhắn
                }
            }
            catch
            {
                Close();
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
        Socket clientthang;
        void Connect()
        {
            //IP: Địa chỉ của Server
            IP = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9999);
            clientthang = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                clientthang.Connect(IP);
            }
            catch
            {
                MessageBox.Show("Cannot connect to server", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Thread listen = new Thread(Nhantin);
            listen.IsBackground = true;
            listen.Start();
        }
        void AddMesseage(string s)
        {
            //txtboxshow.AppendText(s + Environment.NewLine);
            txtboxshow.AppendText(s);
            textBoxRequest.Clear();
        }
        private void TextBoxRequest_TextChanged(object sender, EventArgs e)
        {

        }
        private void ButtonConnect_Click(object sender, EventArgs e)
        {
            Connect();
        }
        private void ButtonDisconnect_Click(object sender, EventArgs e)
        {
            clientthang.Disconnect(true);
        }
        private void lvsMesseage_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        UnicodeEncoding ByteConverter = new UnicodeEncoding();
        RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
        byte[] plaintext;
        byte[] encryptedtext;

        /* //Ham Coppy tu Microsoft
        public static byte[] Encryption(byte[] DataToEncrypt, RSAParameters RSAKeyInfo, bool DoOAEPPadding)
        {
            try
            {
                byte[] encryptedData;
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                {
                    RSA.ImportParameters(RSAKeyInfo);
                    string str = RSA.ToXmlString(false);  
                    string abc = RSA.KeyExchangeAlgorithm;
                    encryptedData = RSA.Encrypt(DataToEncrypt, DoOAEPPadding);
                }
                return encryptedData;
            }
            catch (CryptographicException e)
            {
                return null;
            }
        }
        */
        //Ham tu viet
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
        private string UsingPrivateKey()
        {
            string ClientPrivateKey = txtPrivatekey.Text;
            return ClientPrivateKey;
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
        private string GetPublicKey()
        {
            string KeyfromServer = txtboxshow.Text;
            return KeyfromServer;
        }
        void AddMesseagePublickey(string s)
        {
            //txtPublickey.AppendText(s + Environment.NewLine);
            txtPublickey.Text = s;
            textBoxRequest.Clear();
        }
        void AddMesseagePrivatekey(string s)
        {
            //txtPrivatekey.AppendText(s + Environment.NewLine);
            txtPrivatekey.Text = s;
            textBoxRequest.Clear();
        }

        private void BtClear_Click(object sender, EventArgs e)
        {
            txtboxshow.Clear();
            //txtPublickey.Clear();
            //txtPrivatekey.Clear();
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == "RSA")
            {
                //MessageBox.Show("The selected plan is RSA");
                label1.Visible = true;
                label3.Visible = true;
                txtPublickey.Visible = true;
                txtPrivatekey.Visible = true;
                BtPublickey.Visible = true;
                btDecrypt.Visible = true;
            }
        }
        private void BtPublickey_Click(object sender, EventArgs e)
        {
            CreateNewKeys();
            SendKey();
        }
        private void Clear()
        {
            txtboxshow.Clear();
        }
        private void ButtonSendRequest_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != "RSA")
            {
                MessageBox.Show("NOT Encrypt");
                SendMesseage();
                textBoxRequest.Clear();
            }
            else if (comboBox1.SelectedItem == "RSA")
            {
                MessageBox.Show("RSA");
                {
                    SendRSA();
                }
                AddMesseage(textBoxRequest.Text);
                txtboxshow.Clear();
            }
            }
        private void btDecrypt_Click(object sender, EventArgs e)
        {
            string output = Decryption(txtboxshow.Text);
            MessageBox.Show("The result is: " + output);
            txtboxshow.Clear();
        }
    }
    //Using for try another way. Not for this Form. Доан Конг тханг
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



