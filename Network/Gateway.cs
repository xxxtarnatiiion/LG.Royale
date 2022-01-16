using System;
using System.Net;
using System.Net.Sockets;

using LG.Barbarian.Hype;

namespace LG.Barbarian.Network
{
    class Gateway
    {

        /// <summary>
        /// Gateway's sockets.
        /// </summary>
        public static Socket Server, Client;

        /// <summary>
        /// Gateway's encryption tools.
        /// </summary>
        public static Rivest Encrypter, Decrypter;

        /// <summary>
        /// Listens to the specified address.
        /// </summary>
        /// <param name="IPAddress"></param>
        /// <param name="Port"></param>
        public static void Start(IPAddress IPAddress, int Port)
        {
            Encrypter = new Rivest();
            Decrypter = new Rivest();

            Server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            Server.Bind(new IPEndPoint(IPAddress, Port));
            Server.Listen(150);

            Program.Log("Socket has been started.", false);
            Program.Log("Server has been started.", false);
            Program.Log(null);
            
            while (true)
            {
                Client = Server.Accept();
                break;
            }

            Protocol.Follow();
        }
    }
}
