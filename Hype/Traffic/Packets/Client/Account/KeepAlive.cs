using System;

namespace LG.Royale.Packets
{
    class KeepAlive
    {

        /// <summary>
        /// Packet's ID.
        /// </summary>
        public static int Identifier
        {
            get
            {
                return 10108;
            }
        }

        /// <summary>
        /// Packet's new instance.
        /// </summary>
        public KeepAlive()
        {
            this.Process();
        }

        /// <summary>
        /// Processes this instance.
        /// </summary>
        public void Process()
        {
            new KeepAliveOk().Send();
        }
    }
}
