using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace Async
{
    public partial class Form1 : Form
    {
        private AsyncCallback OnResolved;
        public Form1()
        {

            InitializeComponent();
            OnResolved = new AsyncCallback(Resolved);

        }
        private void btnResolve_Click(object sender, EventArgs e)
        {
            results.Items.Clear();
            string addr = address.Text;
            Object state = new Object();
            Dns.BeginResolve(addr, OnResolved, state);
        }
        private void Resolved(IAsyncResult ar)
        {
            string buffer;
            IPHostEntry iphe = Dns.EndResolve(ar);
            buffer = "Host name: " + iphe.HostName;
            results.Items.Add(buffer);
            foreach (string alias in iphe.Aliases)
            {
                buffer = "Alias: " + alias;
                results.Items.Add(buffer);
            }
            foreach (IPAddress addrs in iphe.AddressList)
            {
                buffer = "Address: " + addrs.ToString();
                results.Items.Add(buffer);
            }

        }
    }
} 
