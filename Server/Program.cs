using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpClient tcpClient;
            NetworkStream networkStream;
            StreamReader streamReader;
            StreamWriter streamWriter;
            try
            {
                tcpClient = new TcpClient("localhost", 3333);
                networkStream = tcpClient.GetStream();
                streamReader = new StreamReader(networkStream);
                streamWriter = new StreamWriter(networkStream);
                streamWriter.WriteLine("Client connected at port 3333");
                streamWriter.Flush();
            }
            catch (SocketException ex)
            {
                Console.WriteLine(ex);
            }
            Console.Read();
        }
    }
}
