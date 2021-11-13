using System;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Serialization;

namespace RSA
{
    public class RsaEncrypttion
    {
        private static RSACryptoServiceProvider csp = new RSACryptoServiceProvider(2048);
        private RSAParameters _privateKey;
        private RSAParameters _publicKey;

        public RsaEncrypttion()
        {
            _privateKey = csp.ExportParameters(true);
            _publicKey = csp.ExportParameters(false);
        }

        public string GetPublicKey()
        {
            var sw = new StringWriter();
            var xs = new XmlSerializer(typeof(RSAParameters));

            xs.Serialize(sw, _publicKey);
            return sw.ToString();
        }

        public string Encrypt(string plainText)
        {
            csp = new RSACryptoServiceProvider();
            csp.ImportParameters(_publicKey);
            Console.WriteLine();
            var data = Encoding.Unicode.GetBytes(plainText);

            Console.WriteLine(data[0]);
            var cypher = csp.Encrypt(data, false);

            Console.WriteLine(cypher[0]);
            return Convert.ToBase64String(cypher);
        }
        
        public string Decrypt(string cypherText)
        {
            var dataBytes = Convert.FromBase64String(cypherText);
            csp.ImportParameters(_privateKey);
            var plainText = csp.Decrypt(dataBytes, false);
            return Encoding.Unicode.GetString(plainText);
        }


    }
    class Program
    {
        static void Main(string[] args)
        {
            RsaEncrypttion rsa = new RsaEncrypttion();
            string cypher = string.Empty;

            Console.WriteLine($"Public key: {rsa.GetPublicKey()}\n");


            Console.WriteLine("Enter your text encrypt");
            var text = Console.ReadLine();
            if (!string.IsNullOrEmpty(text))
            {
                cypher = rsa.Encrypt(text);
                Console.WriteLine($"Encrypted Text: {cypher}");
            }

            Console.WriteLine("Press any key to decrypt text");
            Console.ReadLine();

            var plainText = rsa.Decrypt(cypher);

            Console.WriteLine($"Decrypt Message: {plainText}");

            Console.ReadLine();
        }
    }
}