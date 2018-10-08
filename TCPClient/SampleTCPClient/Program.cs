using System;
using System.Net.Sockets;
using System.Text;

namespace SampleTCPClient
{
    public class Program
    {
        private const int portNum = 13;
        private static string hostName = Environment.MachineName.ToString();
        private static byte[] message1 = Encoding.ASCII.GetBytes("Command - What is the current date time?");

        public static int Main(string[] args)
        {
            Console.WriteLine("Starting Client...");
            try
            {
                TcpClient client = new TcpClient(hostName, portNum);
                client.SendTimeout = 60;
                NetworkStream ns = client.GetStream();
                Console.WriteLine("Started Client successfully.");
                
                //Send data to Server
                Console.WriteLine($"Sending message to Server...");
                ns.Write(message1, 0, message1.Length);

                //Receive data from Server
                var bytes = new byte[1024];
                var bytesRead = ns.Read(bytes, 0, bytes.Length);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Received message from Server: \n{Encoding.ASCII.GetString(bytes, 0, bytesRead)}");
                Console.ForegroundColor = ConsoleColor.White;
                ns.Close();
                client.Close();
            }
            catch (Exception e1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e1.ToString());
                Console.ForegroundColor = ConsoleColor.White;
            }
            return 0;
        }
    }
}
