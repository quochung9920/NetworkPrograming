using System;
using System.Drawing;
using System.Net.Sockets;

namespace Scan_Port
{
    class Program
    {
        private static string IP = "";

        static void Main(string[] args)
        {
            UserInput();
            PortScan();
            Console.ReadKey();
        }

        private static void UserInput()
        {
            Console.WriteLine("IP Address:", Color.Lime);
            IP = Console.ReadLine();
        }

        private static void PortScan()
        {
            Console.Clear();
            int [] Ports = new int[] {80, 443, 20, 21, 22, 23, 25, 53, 67, 68 };
            //for(int i = 1; i < Ports.Length; i++)
            //{
            //    Ports[i] = i;
            //}
            foreach (int s in Ports)
            {
                using (TcpClient Scan = new TcpClient())
                {
                    try
                    {
                        Scan.Connect(IP, s);
                        Console.WriteLine($"[{s}] | OPEN", Color.Green);
                    }
                    catch
                    {
                        Console.WriteLine($"[{s}] | CLOSED", Color.Red);
                    }
                }
            }
        }

    }
}
