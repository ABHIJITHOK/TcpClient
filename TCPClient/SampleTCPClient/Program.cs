using System;
using System.Net.Sockets;
using System.Text;

namespace SampleTCPClient
{
    public class Program
    {
        private const int portNum = 123;
        private const string hostName = "time.windows.com";

        public static int Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            try
            {
                TcpClient client = new TcpClient(hostName, portNum);
                client.SendTimeout = 60;
                NetworkStream ns = client.GetStream();
                byte[] bytes = new byte[1024];
                int bytesRead = ns.Read(bytes, 0, bytes.Length);
                Console.WriteLine(Encoding.ASCII.GetString(bytes, 0, bytesRead));
                client.Close();
            }
            catch (Exception e1)
            {
                Console.WriteLine(e1.ToString());
            }
            return 0;
        }
    }
}
