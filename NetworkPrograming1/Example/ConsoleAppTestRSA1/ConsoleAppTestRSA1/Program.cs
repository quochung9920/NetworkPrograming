using System;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Serialization;

class RSACSPSample
{
    
   

 

    static void Main()
    {
        string publicKey;
        string privateKey;
        string mmmm;

        ASCIIEncoding ByteConverter = new ASCIIEncoding();
        //lets take a new CSP with a new 2048 bit rsa key pair
        RSACryptoServiceProvider csp = new RSACryptoServiceProvider(2048);
        //how to get the private key 1
        RSAParameters privKey = csp.ExportParameters(true);
        //and the public key ...
        RSAParameters pubKey = csp.ExportParameters(false);
        //converting the public key into a string representation
        string pubKeyString;
        {
            //we need some buffer
            var sw = new StringWriter();
            //we need a serializer
            var xs = new XmlSerializer(typeof(RSAParameters));
            //serialize the key into the stream
            xs.Serialize(sw, pubKey);

            pubKeyString = sw.ToString();
            publicKey = pubKeyString;
            //return pubKeyString;
        }
        string privKeyString;
        {
            //we need some buffer
            var sw = new StringWriter();
            //we need a serializer
            XmlSerializer xs = new XmlSerializer(typeof(RSAParameters));
            //serialize the key into the stream
            xs.Serialize(sw, privKey);
            //get the string from the stream
            privKeyString = sw.ToString();
            privateKey = privKeyString;
        }

        byte[] dataToEncrypt = ByteConverter.GetBytes("HAHA");
        using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(1024))
        {
            try
            {
                // client encrypting data with public key issued by server                    
                rsa.FromXmlString(publicKey.ToString());
                byte[] encryptedData = rsa.Encrypt(dataToEncrypt, true);
                string base64Encrypted = Convert.ToBase64String(encryptedData);
                mmmm = base64Encrypted;
                Console.WriteLine(mmmm);
            }
            finally
            {
                rsa.PersistKeyInCsp = false;
            }
        }

        using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(1024))
        {
            try
            {
                string base64Encrypted = mmmm;
                // server decrypting data with private key
                //rsa.ImportParameters(privateKey);
                rsa.FromXmlString(privateKey);
                byte[] resultBytes = Convert.FromBase64String(base64Encrypted);
                byte[] decryptedBytes = rsa.Decrypt(resultBytes, true);
                string decryptedData = ByteConverter.GetString(decryptedBytes);
                Console.WriteLine(decryptedData);
            }
            finally
            {
                rsa.PersistKeyInCsp = false;
            }
        }

    }
}