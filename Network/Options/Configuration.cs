using System;
using System.Net;
using System.Net.Sockets;

namespace LG.Royale.Network
{
    class Configuration
    {

        /// <summary>
        /// Configuration's IP.
        /// </summary>
        public IPAddress IPAddress
        {
            get;
            set;
        }

        /// <summary>
        /// Configuration's port.
        /// </summary>
        public int Port
        {
            get;
            set;
        }

        /// <summary>
        /// Configuration's max allowed people number.
        /// </summary>
        public int MaxPeople
        {
            get;
            set;
        }

        /// <summary>
        /// Configuration's new instance.
        /// </summary>
        /// <param name="IPAddress"></param>
        /// <param name="Port"></param>
        /// <param name="MaxPeople"></param>
        public Configuration(IPAddress IPAddress, int Port)
        {
            this.IPAddress = IPAddress;
            this.Port      = Port;
            this.MaxPeople = 150;
        }
    }
}
