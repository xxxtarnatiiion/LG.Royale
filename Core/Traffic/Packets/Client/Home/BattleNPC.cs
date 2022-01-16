using System;

using LG.Barbarian.Hype;

namespace LG.Barbarian.Traffic
{
    class BattleNPC
    {

        /// <summary>
        /// Packet's ID.
        /// </summary>
        public static int Identifier
        {
            get
            {
                return 14104;
            }
        }

        /// <summary>
        /// Packet's new instance.
        /// </summary>
        public BattleNPC()
        {
            this.Process();
        }

        /// <summary>
        /// Processes this instance.
        /// </summary>
        public void Process()
        {
            new AcceptNPC();
        }
    }
}
