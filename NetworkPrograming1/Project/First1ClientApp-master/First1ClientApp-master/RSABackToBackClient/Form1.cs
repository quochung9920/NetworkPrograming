using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;
using System.IO;
using System.Management;

namespace RSABackToBackClient
{
    public partial class Form1 : Form
    {
        private string NameOfUser;
        private RSAAlgorithm rsa;
        private NetWorkClass net;
        private FileInfo fileInfo;
        private List<string> serverFile;
        private byte[] dataByteFile;

        public Form1()
        {
            InitializeComponent();
            NameOfUser = SystemInformation.UserName;//ініціалізуємо назву клієнта як назва користувача компютера

            DirectoryInfo tempDirInfo = new DirectoryInfo(".");
            rsa = new RSAAlgorithm(tempDirInfo.FullName);
            txtUserName.Text = NameOfUser;
            txtClientKeyE.Text = rsa.publicKeyE.ToString();
            txtClientKeyN.Text = rsa.publicKeyN.ToString();
            try
            {
                net = new NetWorkClass(NameOfUser, rsa);//ініціалізовуємо клас для роботи з мережею, за замовчуванням локальна мережа
                txtServerKeyE.Text=net.publicServerKeyE.ToString();
                txtServerKeyN.Text = net.publicServerKeyN.ToString();
                txtHost.Text = net.host;
                txtPort.Text = net.port.ToString();
                txtServerStatus.Text = "Connect";
                txtServerStatus.ForeColor = Color.Green;
            }
            catch(System.Net.Sockets.SocketException exp)
            {
                //net = null;
                txtServerStatus.Text = "NoConnection";
                txtServerStatus.ForeColor = Color.Red;
                txtHost.Text = "";
                txtPort.Text = "";
                btnDeleteFile.Enabled = false;
                btnDownloadFile.Enabled = false;
                btnRefreshFileList.Enabled = false;
                btnSendToServer.Enabled = false;
            }
            
            serverFile = new List<string>();//зберігає колекцію назв файлів на сервері
        }

        private void hostPortToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HostAndPort f = new HostAndPort();
            f.Owner = this;
            f.ShowDialog();
        }
        
        private void refreshListFile()
        {
            net.Send(NameOfUser, "GetDirectory");
            string mes=net.ListenMesString();
            serverFile.Clear();
            string[] tempFile = mes.Split(' ');
            for (int i=0;i<tempFile.Length;++i)
            {
                serverFile.Add(tempFile[i]);
            }
            listBox1.Items.Clear();
            listBox1.Items.AddRange(serverFile.ToArray());
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            fileInfo = new FileInfo(openFileDialog1.FileName);
            dataByteFile = File.ReadAllBytes(fileInfo.FullName);
            txtFileName.Text = fileInfo.Name;
            txtDirectoryName.Text = fileInfo.DirectoryName;
            txtSizeLabel.Text = ((double)((fileInfo.Length) / 1024)).ToString()+" Kb";
            txtStatusLabel.Text = "No";
            txtStatusLabel.ForeColor = Color.Red;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            fileInfo = new FileInfo(openFileDialog1.FileName);
            txtFileName.Text = fileInfo.Name;
            txtDirectoryName.Text = fileInfo.DirectoryName;
            txtSizeLabel.Text = ((double)((fileInfo.Length) / 1024)).ToString() + " Kb";
            txtStatusLabel.Text = "NoEncrypt";
            txtStatusLabel.ForeColor = Color.Red;
        }

        private void btnEncryptFile_Click(object sender, EventArgs e)
        {
            byte[] tempFileB = File.ReadAllBytes(fileInfo.FullName);
            string s = Encoding.Default.GetString(tempFileB);
            dataByteFile = rsa.EncryptByte(tempFileB, rsa.publicKeyE, rsa.publicKeyN);//шифруємо файл своїм власним відкритим ключем(для безпечного зберігання на сервері)
            txtStatusLabel.Text = "Encrypt";
            string[] nameFileEncrypt = fileInfo.Name.Split('.');
            nameFileEncrypt[0] += "Encrypt";
            for (int i=1;i<nameFileEncrypt.Length;++i)
            {
                if (i != nameFileEncrypt.Length - 1)
                {
                    nameFileEncrypt[0] += nameFileEncrypt[i];
                }
                else
                {
                    nameFileEncrypt[0] += "." + nameFileEncrypt[i];
                }
            }
            txtFileName.Text = nameFileEncrypt[0];
            txtStatusLabel.ForeColor = Color.Green;
        }

        private void btnSendToServer_Click(object sender, EventArgs e)
        {

            net.Send(NameOfUser, txtFileName.Text, dataByteFile);
            txtStatusLabel.Text = "Send";
            txtStatusLabel.ForeColor = Color.Green;
        }

        private void btnDecryptFile_Click(object sender, EventArgs e)
        {
            dataByteFile = rsa.DecryptByte(dataByteFile);
            txtStatusLabel.Text = "Decrypt";
            StringBuilder nameFileDecrypt = new StringBuilder( txtFileName.Text);
            nameFileDecrypt.Replace("Encrypt", "Decrypt");
            
            txtFileName.Text = nameFileDecrypt.ToString();
            txtStatusLabel.ForeColor = Color.Green;
         
        }

        private void btnSaveFile_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
            File.WriteAllBytes(saveFileDialog1.FileName,dataByteFile);
            txtStatusLabel.Text = "Save";
            txtStatusLabel.ForeColor = Color.Green;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Program was written by Andrii Malchevkyi");
        }

        private void btnRefreshFileList_Click(object sender, EventArgs e)
        {
            refreshListFile();
        }

        private void btnDeleteFile_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex>-1)
            {
                net.Send(NameOfUser, "Delete", serverFile[listBox1.SelectedIndex]);
            }
            //refreshListFile();
        }

        private void btnDownloadFile_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex > -1)
            {
                net.Send(NameOfUser, "SendFile", serverFile[listBox1.SelectedIndex]);
                string fileInfo=net.ListenMesByte(ref dataByteFile);
                string[] fName = fileInfo.Split(' ');
                txtFileName.Text = fName[1];
                txtStatusLabel.Text = "Download";
                txtStatusLabel.ForeColor = Color.Green;
            }
        }

        private void btnConnectServer_Click(object sender, EventArgs e)
        {
            try
            {
                net = new NetWorkClass(NameOfUser,rsa,txtHost.Text, Convert.ToInt32(txtPort.Text));
                txtServerStatus.Text = "Connect";
                txtServerStatus.ForeColor = Color.Green;
                txtServerKeyE.Text = net.publicServerKeyE.ToString();
                txtServerKeyN.Text = net.publicServerKeyN.ToString();
                btnDeleteFile.Enabled = true;
                btnDownloadFile.Enabled = true;
                btnRefreshFileList.Enabled = true;
                btnSendToServer.Enabled = true;
            }
            catch (System.Net.Sockets.SocketException exp)
            {
                net = null;
                txtServerStatus.Text = "NoConnection";
                txtServerStatus.ForeColor = Color.Red;
                btnDeleteFile.Enabled = false;
                btnDownloadFile.Enabled = false;
                btnRefreshFileList.Enabled = false;
                btnSendToServer.Enabled = false;
            }
        }


    }
}
