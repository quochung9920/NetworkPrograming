using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.IO;

namespace RSABackToBackClient
{
    public class NetWorkClass
    {
        private TcpClient MyClient;
        private NetworkStream str;
        private RSAAlgorithm rsa;
        public int publicServerKeyE;
        public int publicServerKeyN;
        public string host;
        public int port;
        public NetWorkClass(string nameUser,RSAAlgorithm r)
        {
            MyClient = new TcpClient("localhost",8349);
            str = MyClient.GetStream();
            rsa = r;
            ///очікуємо відкриті ключі від сервера [publicKeyE][publicKeyN]
            string mesFromServerKey = ListenMesString(false);
            string[] keys = mesFromServerKey.Split(' ');
            publicServerKeyE = Convert.ToInt32(keys[0]);
            publicServerKeyN = Convert.ToInt32(keys[1]);
            Send(nameUser, rsa.GetKeys(false)+"/");//відправляємо дані(імя, відкриті ключі)
            host = "localhost";
            port = 8349;
        }
        public NetWorkClass(string nameUser, RSAAlgorithm r, string h, int p)
        {
            MyClient = new TcpClient(h, p);
            str = MyClient.GetStream();
            rsa = r;
            ///очікуємо відкриті ключі від сервера [publicKeyE][publicKeyN]
            string mesFromServerKey = ListenMesString(false);
            string[] keys = mesFromServerKey.Split(' ');
            publicServerKeyE = Convert.ToInt32(keys[0]);
            publicServerKeyN = Convert.ToInt32(keys[1]);
            Send(nameUser,rsa.GetKeys(false)+"/");
            host = h;
            port = p;
        }
        public void Send(string name, string file, int[] data)
        {
            string mesNF = name + " " + file + "/";
            byte[] mesNFB = Encoding.Default.GetBytes(mesNF);
            ///шифруємо повідомлення
            mesNFB = rsa.EncryptByte(mesNFB, publicServerKeyE, publicServerKeyN);
            str.Write(mesNFB,0,mesNFB.Length);//відправляємо повідомлення

            byte[] arr = new byte[data.Length*4];
            for (int i=0;i<data.Length;++i)
            {
                byte[] t = BitConverter.GetBytes(data[i]);
                for (int j=0;j<t.Length;++j)
                {
                    arr[4 * i + j] = t[j];
                }
            }
            ///шифруємо файл
            arr = rsa.EncryptByte(arr, publicServerKeyE, publicServerKeyN);
            str.Write(arr, 0, arr.Length);//відправляємо файл
            //str.Close();
        }
        public void Send(string name, string file, byte[] data)
        {
            string mesNF = name + " "+ "SaveFile" + " " + file + "/";
            byte[] mesNFB = Encoding.Default.GetBytes(mesNF);
            mesNFB = rsa.EncryptByte(mesNFB, publicServerKeyE, publicServerKeyN);
            str.Write(mesNFB, 0, mesNFB.Length);

            //encrypt file
            data = rsa.EncryptByte(data, publicServerKeyE, publicServerKeyN);
            str.Write(data,0,data.Length);
        }
        public void Send(string nameUser, string comand)
        {
            string mesNF = nameUser + " " + comand+ "/";
            byte[] mesNFB = Encoding.Default.GetBytes(mesNF);
            mesNFB = rsa.EncryptByte(mesNFB, publicServerKeyE, publicServerKeyN);
            str.Write(mesNFB, 0, mesNFB.Length);
        }
        public void Send(string nameUser, string comand, string file)
        {
            string mesNF = nameUser + " " + comand +" "+file+ "/";
            byte[] mesNFB = Encoding.Default.GetBytes(mesNF);
            mesNFB = rsa.EncryptByte(mesNFB, publicServerKeyE, publicServerKeyN);
            str.Write(mesNFB, 0, mesNFB.Length);
        }
        public string ListenMesString(bool DoDecrypt=true)
        {
            FileInfo tempFile = new FileInfo("bufFileSaveMes.txt");
            FileStream fstr = tempFile.Create();
            int bytes = 0;
            byte[] data = new byte[64];
            do
            {
                bytes = str.Read(data, 0, data.Length);
                fstr.Write(data, 0, bytes);
            }
            while (str.DataAvailable);
            fstr.Close();
            data = File.ReadAllBytes(tempFile.FullName);
            tempFile.Delete();
            if(DoDecrypt)
                data = rsa.DecryptByte(data);//декодуємо повідомлення

            byte[] mesFileInfo = new byte[1];
            StringBuilder builder = new StringBuilder();
            builder.Append(" ");
            int i = 0;
            while (builder[builder.Length - 1] != '/')
            {
                mesFileInfo[0]=data[i++];
                builder.Append(Encoding.Default.GetString(mesFileInfo, 0, 1));
            }
            builder.Remove(builder.Length - 1, 1);
            builder.Remove(0, 1);
            string fileN = builder.ToString();

            return fileN;
        }
        public string ListenMesByte(ref byte[] dataFile ,bool DoDecrypt=true)//отримуємо повідомлення та одразу записуємо файл
        {
            FileInfo tempFile = new FileInfo("bufFileSaveMes.txt");
            FileStream fstr = tempFile.Create();
            int bytes = 0;
            byte[] data = new byte[64];
            do
            {
                bytes = str.Read(data, 0, data.Length);
                fstr.Write(data, 0, bytes);
            }
            while (str.DataAvailable);
            fstr.Close();
            data = File.ReadAllBytes(tempFile.FullName);
            tempFile.Delete();
            if (DoDecrypt)
                data = rsa.DecryptByte(data);//декодуємо повідомлення

            byte[] mesFileInfo = new byte[1];
            StringBuilder builder = new StringBuilder();
            builder.Append(" ");
            int i = 0;
            while (builder[builder.Length - 1] != '/')
            {
                mesFileInfo[0] = data[i++];
                builder.Append(Encoding.Default.GetString(mesFileInfo, 0, 1));
            }
            builder.Remove(builder.Length - 1, 1);
            builder.Remove(0, 1);
            string fileN = builder.ToString();

            /////////////////////file
            tempFile = new FileInfo("bufFileSaveMes.txt");
            fstr = tempFile.Create();
            bytes = 0;
            data = new byte[1048576];
            do
            {
                bytes = str.Read(data, 0, data.Length);
                fstr.Write(data, 0, bytes);
                Thread.Sleep(300);
            }
            while (str.DataAvailable);
            fstr.Close();
            data = File.ReadAllBytes(tempFile.FullName);
            tempFile.Delete();
            if (DoDecrypt)
                data = rsa.DecryptByte(data);//декодуємо повідомлення

            ///////////
            dataFile = data;

            return fileN;
        }
    }
}
