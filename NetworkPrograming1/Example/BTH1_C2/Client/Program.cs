using System;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
class SimpleTcpClient
{
    public static void Main()
    {
        byte[] data = new byte[1024];
        string input, stringData;
        IPEndPoint ipep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9050);
        Socket server = new Socket(AddressFamily.InterNetwork,SocketType.Stream, ProtocolType.Tcp);
        try
        {
            server.Connect(ipep);
        }
        catch (SocketException e)
        {
            Console.WriteLine("Unable to connect to server.");
            Console.WriteLine(e.ToString());
            return;
        }

        using (Bob bob = new Bob())
        {
            using (RSACryptoServiceProvider rsaKey = new RSACryptoServiceProvider())
            {
                server.Receive(data);
                byte[] iv = data;
                server.Receive(data);
                byte[] encryptedSessionKey = data;
                server.Receive(data);
                byte[] encryptedMessage = data;
                // Get Bob's public key
                rsaKey.ImportCspBlob(bob.key);
                bob.Receive(iv, encryptedSessionKey, encryptedMessage);

                Console.ReadKey();
            }
        }

        Console.ReadKey();  
        Console.WriteLine("Disconnecting from server...");
        server.Shutdown(SocketShutdown.Both);
        server.Close();
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