using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.IO;

namespace RSAFileServer
{
    public class RSAAlgorithm
    {
        public int publicKeyE;
        public int publicKeyN;
        private int privateKeyD;
        /*public RSAAlgorithm()
        {
            int p, q, fn;
            p = Algorithm.RNPG(10, 100);//для прикладу взяті маленькі значення p i q
            q = Algorithm.RNPG(10, 100);//
            while (p==q||Algorithm.Gcd(p,q)!=1)
            {
                p = Algorithm.RNPG(10, 100);
                q = Algorithm.RNPG(10, 100);
            }
            publicKeyN = p * q;
            fn = (p-1) * (q-1);
            publicKeyE = Algorithm.RNPG(2, fn-1);
            while (Algorithm.Gcd(publicKeyE, fn) != 1)
            {
                publicKeyE = Algorithm.RNPG(2, fn-1);
            }
            privateKeyD = Algorithm.ExpGcd(publicKeyE, fn);

        }*/
        public RSAAlgorithm(string fullNameDirectory)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(fullNameDirectory);
            FileInfo[] filesInDir = dirInfo.GetFiles("key.crp");
            if (filesInDir.Length==0)
            {
                int p, q, fn;
                p = Algorithm.RNPG(10, 100);//для прикладу взяті маленькі значення p i q
                q = Algorithm.RNPG(10, 100);//
                while (p == q || Algorithm.Gcd(p, q) != 1)
                {
                    p = Algorithm.RNPG(10, 100);
                    q = Algorithm.RNPG(10, 100);
                }
                publicKeyN = p * q;
                fn = (p - 1) * (q - 1);
                publicKeyE = Algorithm.RNPG(2, fn - 1);
                while (Algorithm.Gcd(publicKeyE, fn) != 1)
                {
                    publicKeyE = Algorithm.RNPG(2, fn - 1);
                }
                privateKeyD = Algorithm.ExpGcd(publicKeyE, fn);

                FileInfo createFileKey = new FileInfo("key.crp");
                FileStream strFile= createFileKey.Create();
                byte[] keysByte = Encoding.Default.GetBytes(GetKeys(true));
                strFile.Write(keysByte,0,keysByte.Length);
                strFile.Close();
                //File.WriteAllText(createFileKey.FullName, GetKeys(true));
            }
            else
            {
                string[] tempKeyText = File.ReadAllLines(filesInDir[0].FullName);
                tempKeyText = tempKeyText[0].Split(' ');
                privateKeyD = Convert.ToInt32(tempKeyText[0]);
                publicKeyE = Convert.ToInt32(tempKeyText[1]);
                publicKeyN = Convert.ToInt32(tempKeyText[2]);
            }
        }
        public int Encrypt(int m, int pKeyE, int pKeyN)
        {
            return Algorithm.Pow(m, pKeyE, pKeyN);
        }
        public int[] Encrypt(int[] m, int pKeyE, int pKeyN)
        {
            int[] data = new int[m.Length];
            for (int i=0;i<m.Length;++i)
            {
                data[i] = Encrypt(m[i], pKeyE, pKeyN);
            }
            return data;
        }
        public int Decrypt(int m)
        {
            return Algorithm.Pow(m, privateKeyD, publicKeyN);
        }
        public int[] Decrypt(int[] m)
        {
            int[] res = new int[m.Length];
            for (int i=0;i<m.Length;++i)
            {
                res[i]= Algorithm.Pow(m[i], privateKeyD, publicKeyN);
            }
            return res;
        }
        public byte[] DecryptByte(byte[] m)
        {
  
          int[] data = new int[m.Length / 4];
            for (int i=0;i<data.Length;++i)
            {
                byte[] tempBuf = new byte[4];
                for (int j=i*4;j<i*4+4;++j) {
                    tempBuf[j - i * 4] = m[j];
                }
                data[i] = BitConverter.ToInt32(tempBuf,0);
            }
            data = Decrypt(data);
            byte[] res = new byte[data.Length];
            for (int i = 0; i < data.Length; i++)
            {
                res[i] = (byte)data[i];
            }
            return res;
        }
        public byte[] EncryptByte(byte[] m, int pKeyE, int pKeyN)
        {
            int[] data = new int[m.Length];
            for (int i = 0; i < m.Length; ++i)
            {
                data[i] = Encrypt(m[i], pKeyE, pKeyN);
            }
            byte[] res = new byte[data.Length*4];
            for (int i=0;i<data.Length;i++)
            {
                byte[] temp = BitConverter.GetBytes(data[i]);
                for (int j=i*4; j<i*4+4;++j)
                {
                    res[j] = temp[j - i * 4];
                }
            }
            return res;
        }
        public string GetKeys(bool withPrivate)
        {
            string mes = "";
            if (withPrivate)
            {
                mes = privateKeyD.ToString() + " " + publicKeyE.ToString() + " " + publicKeyN.ToString();
            }
            else
            {
                mes = publicKeyE.ToString() + " " + publicKeyN.ToString();
            }
            return mes;
        }
    }
}
