using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLib;
using System.Net.Sockets;
using System.IO;

namespace TCPClient
{
    class Client
    {
        public void Start()
        {
            var car = new Car();

            car.Color = "Toyota";
            car.Model = "Hybrid";
            car.RegNo = "1234DCF";


            using (TcpClient client = new TcpClient("Localhost", 1001))
            using (NetworkStream ns = client.GetStream())
            using (StreamReader sr = new StreamReader(ns))
            using (StreamWriter sw = new StreamWriter(ns))
            {
                sw.WriteLine(car.ToString());
                sw.Flush();

                String incomingString = sr.ReadLine();
                Console.WriteLine("Ekko er modtaget" + incomingString);
            }

            

                      
        }
    }
}
