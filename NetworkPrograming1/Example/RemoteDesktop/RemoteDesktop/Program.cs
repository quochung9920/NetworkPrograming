using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Diagnostics;

namespace RemoteDesktop
{
    class Program
    {
        public static void Main()
        {
            byte[] data = new byte[1024];
            string input, stringData;

            IPEndPoint ipep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9050);
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            string welcome = "Hello, are you there?";
            data = Encoding.ASCII.GetBytes(welcome);
            server.SendTo(data, data.Length, SocketFlags.None, ipep);

            IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);
            EndPoint Remote = (EndPoint)sender;

            data = new byte[1024];
            int recv = server.ReceiveFrom(data, ref Remote);
            Console.WriteLine("Message received from {0}:", Remote.ToString());
            Console.WriteLine(Encoding.ASCII.GetString(data, 0, recv));

            while (true)
            {
                data = new byte[1024];
                recv = server.ReceiveFrom(data, ref Remote);
                stringData = Encoding.ASCII.GetString(data, 0, recv);
                Console.WriteLine(stringData);
                if (stringData == "exit")
                    break;
                if (stringData == "shutdown")
                {
                    Process.Start("shutdown.exe", "-s -f -t 1");
                }
                if (stringData == "restart")
                    Process.Start("shutdown.exe", "-r -f -t 1");
                if (stringData == "lock")
                    Process.Start(@"C:\Windows\system32\rundll32.exe",
                   "user32.dll,LockWorkStation");
                if (stringData == "log off")
                {
                    Process.Start("shutdown.exe", "-l");
                }
            }
            Console.WriteLine("Stopping client");
            server.Close();
        }
    }
}
