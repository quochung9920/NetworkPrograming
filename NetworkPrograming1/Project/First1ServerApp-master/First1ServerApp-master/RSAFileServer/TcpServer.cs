using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace RSAFileServer
{
    public class ControlerClient
    {
        private TcpClient client;
        private RSAAlgorithm rsa;
        private int PublicClientKeyE;
        private int PublicClientKeyN;

        private NetworkStream str;
        private string NameUserDirectory;
        public ControlerClient(TcpClient c)
        {
            client = c;
            str = client.GetStream();
            DirectoryInfo keys = new DirectoryInfo(".");
            rsa = new RSAAlgorithm(keys.FullName);
            SendKeys();//відсилаємо ключі кієнту
            ///////////отримуємо дані від клієнта [nameUser][publicKeyE][publicKeyN]
            FileInfo tempFile = new FileInfo("bufFileSaveKey.txt");
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
            byte[] dataFile = File.ReadAllBytes(tempFile.FullName);
            tempFile.Delete();
            dataFile = rsa.DecryptByte(dataFile);//розшифровуємо
            //витягуємо повідомлення
            byte[] mesFileInfo = new byte[1];
            StringBuilder builder = new StringBuilder();
            builder.Append(" ");
            int i = 0;
            while (builder[builder.Length - 1] != '/')
            {
                mesFileInfo[0] = dataFile[i++];
                builder.Append(Encoding.Default.GetString(mesFileInfo, 0, 1));
            }
            builder.Remove(builder.Length - 1, 1);
            builder.Remove(0, 1);
            string fileN = builder.ToString();
            string[] mesSplit = fileN.Split(' ');
            /////опрацьовуємо повідомлення 
            NameUserDirectory = mesSplit[0];
            DirectoryInfo dirInfo = new DirectoryInfo(NameUserDirectory);
            dirInfo.Create();
            FileInfo[] cryptKeyFile = dirInfo.GetFiles("cryptKey.crp");
            if (cryptKeyFile.Length == 0)//якщо такого файлу в деректорії не знайдено то він буде створений
            {
                PublicClientKeyE = Convert.ToInt32(mesSplit[1]);
                PublicClientKeyN = Convert.ToInt32(mesSplit[2]);
                FileStream fstrKey = Directory(ref dirInfo, "cryptKey.crp");
                byte[] mesInFile = Encoding.Default.GetBytes(fileN);
                fstrKey.Write(mesInFile,0,mesInFile.Length);
                fstrKey.Close();
            }
            else//якщо ж файл є то перевіряємо чи дані збігаються
            {
                //FileStream fstrKey = Directory(ref dirInfo, "cryptKey.crp");
                string[] keyInFile = File.ReadAllLines(cryptKeyFile[0].FullName);
                keyInFile = keyInFile[0].Split(' ');
                if (NameUserDirectory==keyInFile[0]&&mesSplit[1]==keyInFile[1]&&mesSplit[2]==keyInFile[2])
                {
                    PublicClientKeyE = Convert.ToInt32(mesSplit[1]);
                    PublicClientKeyN = Convert.ToInt32(mesSplit[2]);
                }
                else//якщо прислані ключі не збігаються з тими що на сервері скидаємо підключення
                {
                    str.Close();
                    client.Close();
                }
                //fstrKey.Close();

            }


        }
        public FileStream Directory(ref DirectoryInfo dirInfo, string nameFile)
        {
            FileInfo[] files = dirInfo.GetFiles(nameFile);
            if (files.Length==0)
            {
                FileInfo f = new FileInfo(dirInfo.FullName + "\\" + nameFile);
                
                FileStream s = f.Create();
                return s;
            }
            else
            {
                bool isThere = false;
                for(int i = 0; i < files.Length; ++i)
                {
                    if (files[i].Name==nameFile)
                    {
                        isThere = true;
                    }
                }
                if (isThere)
                {
                    FileInfo f1 = new FileInfo(nameFile + "1");
                    f1.MoveTo(dirInfo.FullName);
                    FileStream s1 = f1.Create();
                    return s1;
                }
                else
                {
                    FileInfo f2 = new FileInfo(nameFile);
                    f2.MoveTo(dirInfo.FullName);
                    FileStream s2 = f2.Create();
                    return s2;
                }
            }
        }
        public void ParserMessAndDoWork(string mes, byte[] file)//вибирає дію сервера за командою кієнта
        {
            //формат повідомлення [Імя користувача][команда][назва файлу(не обовязково може бути)]
            ///"SaveFile"-зберегти файл(зберігається у відповідну директорію)
            ///"GetDirectory"-отримати інформацію про каталог(відсилаються назви файлів)
            ///"SendFile"-відсилається файл клієнту
            ///"Delete"-видаляє файл за назвою
            string[] MesPars = mes.Split(' ');
            Console.WriteLine("Request "+ MesPars[1]+" User: "+MesPars[0]);
            if (MesPars[1]=="SaveFile")
            {
                SaveFile( MesPars[2]);
            }
            else if (MesPars[1] == "GetDirectory")
            {
                SendDirectoryInfo();
            }
            else if (MesPars[1] == "SendFile")
            {
                SendFile(MesPars[2]);
            }
            else if (MesPars[1] == "Delete")
            {
                DeleteFile( MesPars[2]);
            }
        }
        public void SendDirectoryInfo()//надсилає на запит клієнта список назв файлів у директорії клієнта
        {
            DirectoryInfo dir = new DirectoryInfo(NameUserDirectory);
            FileInfo[] arrFile = dir.GetFiles("*.*");
            string mes = "";
            for (int i=0;i<arrFile.Length;++i)
            {
                mes += arrFile[i].Name;
                if (i!=arrFile.Length-1)
                {
                    mes += " ";
                }
                else
                {
                    mes += "/";
                }
            }
            if (arrFile.Length == 0)
            {
                mes = "NoFoundFiles/";
            }
            byte[] mesArr = Encoding.Default.GetBytes(mes);
            mesArr = rsa.EncryptByte(mesArr,PublicClientKeyE, PublicClientKeyN);
            str.Write(mesArr,0,mesArr.Length);
        }
        public void SendKeys()//надсилає свої відкриті ключі
        {
            string mes = rsa.GetKeys(false)+"/";

            byte[] mesArr = Encoding.Default.GetBytes(mes);
            str.Write(mesArr, 0, mesArr.Length);
        }
        public void SendFile(string NameFile)//надсилає файл клієнту з заданою назвою
        {
            DirectoryInfo dir = new DirectoryInfo( NameUserDirectory);
            FileInfo[] arrFile = dir.GetFiles(NameFile);
            string mesNF = NameUserDirectory + " " + NameFile + "/";
            byte[] mesNFB = Encoding.Default.GetBytes(mesNF);
            mesNFB = rsa.EncryptByte(mesNFB, PublicClientKeyE, PublicClientKeyN);
            str.Write(mesNFB, 0, mesNFB.Length);
            //потрібно exception
            //...
            byte[] arr = File.ReadAllBytes(arrFile[0].FullName);
            arr = rsa.EncryptByte(arr, PublicClientKeyE, PublicClientKeyN);
            str.Write(arr, 0, arr.Length);
        }
        public void SaveFile(string NameFile)//зберігає файл клієнта у відповідній директорії та вказаною назвою
        {
            DirectoryInfo dir = new DirectoryInfo(NameUserDirectory);
            dir.Create();
            FileStream fstr = Directory(ref dir, NameFile);
            //fstr.Write(file, 0, file.Length);
             int bytes = 0;
             byte[] data = new byte[1048576];
             do
             {
                 bytes = str.Read(data, 0, data.Length);
                 fstr.Write(data, 0, bytes);
                Thread.Sleep(300);
             }
             while (str.DataAvailable);
            fstr.Close();
            data = File.ReadAllBytes(dir.FullName+"\\"+NameFile);
            data = rsa.DecryptByte(data);
            File.WriteAllBytes(dir.FullName + "\\" + NameFile, data);

        }
        public void DeleteFile(string NameFile)
        {
            DirectoryInfo dir = new DirectoryInfo(NameUserDirectory);
            FileInfo[] arrFile = dir.GetFiles(NameFile);
            for (int i=0;i<arrFile.Length;++i)
            {
                if (arrFile[i].Name==NameFile)
                {
                    arrFile[i].Delete();
                }
            }
        }
        public void Process()
        {
            try
            { 
                while (true)
                {
                    //для кожного потоку свій файл
                    DirectoryInfo dirInfo = new DirectoryInfo(".");
                    FileInfo[] fileInfo = dirInfo.GetFiles();
                    string nameBufFile = "bufFileSave.txt";
                    for (int j=0;j<fileInfo.Length;++j)
                    {
                        if (fileInfo[j].Name==nameBufFile)
                        {
                            nameBufFile += "1";
                            j = 0;
                        }
                    }
                    FileInfo tempFile = new FileInfo(nameBufFile);
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
                    byte[] dataFile = File.ReadAllBytes(tempFile.FullName);
                    tempFile.Delete();
                    dataFile = rsa.DecryptByte(dataFile);//розшифровуємо
                    //File.WriteAllBytes(tempFile.FullName, dataFile);
                    //витягуємо повідомлення
                    byte[] mesFileInfo = new byte[1];
                    StringBuilder builder = new StringBuilder();
                    builder.Append(" ");
                    int i = 0;
                    while (builder[builder.Length - 1] != '/')
                    {
                        mesFileInfo[0] = dataFile[i++];
                        builder.Append(Encoding.Default.GetString(mesFileInfo, 0, 1));
                    }
                    builder.Remove(builder.Length - 1, 1);
                    builder.Remove(0, 1);
                    string fileN = builder.ToString();
                    ParserMessAndDoWork(fileN, dataFile);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (str != null)
                    str.Close();
                if (client != null)
                    client.Close();
            }
        }
    }

    public class Server
    {
        private TcpListener server;
        private TcpClient client;
        public Server()
        {
            server = new TcpListener(8349);
        }
        public Server(int p)
        {
            server = new TcpListener(p);
        }
        public void DoWork()
        {
            try
            {
                server.Start();
                Console.WriteLine("Listening...");
                while (true)
                {
                    client = server.AcceptTcpClient();
                    Console.WriteLine("New client found");
                    ControlerClient controler = new ControlerClient(client);

                    Thread clientThread = new Thread(new ThreadStart(controler.Process));
                    clientThread.Start();
                }
            }
            catch
            {
                Console.WriteLine("Error server process");
            }
            finally
            {
                client.Close();
                server.Stop();
            }
        }
    }
}
