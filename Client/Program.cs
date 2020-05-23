using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamWriter streamWriter;
            StreamReader streamReader;
            NetworkStream networkStream;
            TcpListener tcpListener = new TcpListener(3333);
            tcpListener.Start();
            Console.WriteLine("Server Started. Waiting for Client Connection at port 3333");
            Socket serverSocket = tcpListener.AcceptSocket();
            try
            {
                if (serverSocket.Connected)
                {
                    while (true)
                    {
                        Console.WriteLine("Client Connected at port 3333");
                        networkStream = new NetworkStream(serverSocket);
                        streamWriter = new StreamWriter(networkStream);
                        streamReader = new StreamReader(networkStream);
                        Console.WriteLine(streamReader.ReadLine() + "Yasser");
                    }
                }
                if (serverSocket.Connected)
                    serverSocket.Close();
                Console.Read();
            }
            catch (SocketException ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
