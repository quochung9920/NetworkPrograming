using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;
using System.Xml;
using System.Net.Sockets;
using System.Net;

namespace RSAFileServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Server serv = new Server();
            serv.DoWork();
            Console.WriteLine("//////");
            Console.ReadKey();
        }
    }
}
