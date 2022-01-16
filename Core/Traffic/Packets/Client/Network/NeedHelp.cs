using System;

using LG.Barbarian.Hype;

namespace LG.Barbarian.Traffic
{
    class NeedHelp
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
        public NeedHelp()
        {
            this.Process();
        }

        /// <summary>
        /// Processes this instance.
        /// </summary>
        public void Process()
        {
            new KeepAlive();
        }
    }
}
