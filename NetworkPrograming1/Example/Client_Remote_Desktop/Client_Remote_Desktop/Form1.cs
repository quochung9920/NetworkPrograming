using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net.Sockets;
using System.Drawing.Imaging;
using System.Runtime.Serialization.Formatters.Binary;

namespace Client_Remote_Desktop
{
    public partial class Form1 : Form
    {

        private readonly TcpClient client = new TcpClient();
        private NetworkStream mainStream;
        private int portNumber;

        private static Image GrabDesktop()
        {
            Rectangle bound = Screen.PrimaryScreen.Bounds;
            Bitmap screenshot = new Bitmap(bound.Width, bound.Height, PixelFormat.Format32bppArgb);
            Graphics graphics = Graphics.FromImage(screenshot);
            graphics.CopyFromScreen(bound.X, bound.Y, 0, 0, bound.Size, CopyPixelOperation.SourceCopy);

            return screenshot;
        }

        private void SendDesktopImage()
        {
            BinaryFormatter binFormatter = new BinaryFormatter();
            mainStream = client.GetStream();
            binFormatter.Serialize(mainStream, GrabDesktop());
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnShare.Enabled = false;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            portNumber = int.Parse(txtPort.Text);
            try
            {
                client.Connect(txtIP.Text, portNumber);
                btnConnect.Text = "Connected";
                MessageBox.Show("Connected");
                btnConnect.Enabled = false;
                btnShare.Enabled = true;
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to connect");
                btnConnect.Text = "Not connected";
            }
        }

        private void btnShare_Click(object sender, EventArgs e)
        {
            if (btnShare.Text.StartsWith("Share"))
            {
                timer1.Start();
                btnShare.Text = "Stop sharing"; 
            }
            else
            {
                timer1.Stop();
                btnShare.Text = "Share My Screen";
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            SendDesktopImage();
        }
    }
}
