using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace RSAFileServer
{
    public class UdpServer
    {
        private UdpClient udp;
        public UdpServer(string host, int port)
        {
            udp = new UdpClient(host, port);
        }
        public void Send(string mes)
        {
            byte[] m = Encoding.Unicode.GetBytes(mes);
            udp.Send(m, m.Length);
            //udp.Close();
        }
        public void Close()
        {
            udp.Close();
        }
    }
}
