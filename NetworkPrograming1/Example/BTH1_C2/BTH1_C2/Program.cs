using System;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
class SimpleTcpSrvr
{

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
    public static void Main()
    {
       

        int recv;
        byte[] data = new byte[1024];
        IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 9050);
        Socket newsock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        newsock.Bind(ipep);
        newsock.Listen(10);

        Console.WriteLine("Waiting for a client...");
        Socket client = newsock.Accept();
        IPEndPoint clientep = (IPEndPoint)client.RemoteEndPoint;
        Console.WriteLine("Connected with {0} at port {1}", clientep.Address, clientep.Port);

        string welcome = "Welcome to my test server";

        using (Bob bob = new Bob())
        {
            using (RSACryptoServiceProvider rsaKey = new RSACryptoServiceProvider())
            {
                // Get Bob's public key
                rsaKey.ImportCspBlob(bob.key);
                byte[] encryptedSessionKey = null;
                byte[] encryptedMessage = null;
                byte[] iv = null;
                Send(rsaKey, welcome, out iv, out encryptedSessionKey, out encryptedMessage);
                client.Send(iv, iv.Length, SocketFlags.None);
                client.Send(encryptedSessionKey, encryptedSessionKey.Length, SocketFlags.None);
                //client.Send(encryptedMessage, encryptedMessage.Length, SocketFlags.None);
            }
        }

        Console.WriteLine("Disconnected from {0}",
        clientep.Address);
        client.Close();
        newsock.Close();
    }
}
public class Bob : IDisposable
{
    public byte[] key;
    private RSACryptoServiceProvider rsaKey = new RSACryptoServiceProvider();
    public Bob()
    {
        key = rsaKey.ExportCspBlob(false);
    }
    public void Dispose()
    {
        rsaKey.Dispose();
    }
}