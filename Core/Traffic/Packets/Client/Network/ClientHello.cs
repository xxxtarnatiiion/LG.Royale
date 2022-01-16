using System;

using LG.Barbarian.Hype;

namespace LG.Barbarian.Traffic
{
    class ClientHello
    {

        /// <summary>
        /// Packet's ID.
        /// </summary>
        public static int Identifier
        {
            get
            {
                return 10101;
            }
        }

        /// <summary>
        /// Packet's new instance.
        /// </summary>
        public ClientHello()
        {
            this.Process();
        }

        /// <summary>
        /// Processes this instance.
        /// </summary>
        public void Process()
        {
            new ServerHello();
            new GetHomeData();
        }
    }
}
