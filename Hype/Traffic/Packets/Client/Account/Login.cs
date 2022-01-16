using System;

using LG.Royale.Hype;

namespace LG.Royale.Packets
{
    class Login
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
        public Login()
        {
            this.Process();
        }

        /// <summary>
        /// Processes this instance.
        /// </summary>
        public void Process()
        {
            new LoginOk().Send();
            new OwnHome().Send();
        }
    }
}
