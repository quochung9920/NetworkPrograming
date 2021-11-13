using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Xml;

namespace RSAFileServer
{
    public class CoreRSA
    {
        private RSACryptoServiceProvider Crypt;
        public CoreRSA()
        {
            Crypt = new RSACryptoServiceProvider();
        }
        public CoreRSA(string XMLString)
        {
            Crypt = new RSACryptoServiceProvider();
            Crypt.FromXmlString(XMLString);
        }
        public string ToXmlString(bool privateMember)
        {
            return Crypt.ToXmlString(privateMember);
        }
        public Byte[] Encrypt(Byte[] a)
        {
            return Crypt.Encrypt(a, true);
        }
        public Byte[] Decrypt(Byte[] a)
        {
            return Crypt.Decrypt(a, true);
        }
    }
}
