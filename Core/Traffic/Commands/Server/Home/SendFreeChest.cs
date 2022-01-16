using System;
using System.Collections;
using System.Collections.Generic;

using LG.Barbarian.Hype;
using LG.Barbarian.Logic;

namespace LG.Barbarian.Traffic
{
    class SendFreeChest
    {

        /// <summary>
        /// Packet's type.
        /// </summary>
        public int Type
        {
            get
            {
                return 210;
            }
        }

        /// <summary>
        /// Packet's writer.
        /// </summary>
        public Writer Writer;

        /// <summary>
        /// Packet's new instance.
        /// </summary>
        public SendFreeChest()
        {
            this.Writer = new Writer();
            this.Process();
        }

        /// <summary>
        /// Encodes this instance.
        /// </summary>
        public List<byte> Encode()
        {
            this.Writer.WriteList(new Chest(Chest.Type.Free).Encode());
            return this.Writer.Stream;
        }

        /// <summary>
        /// Processes this instance.
        /// </summary>
        public void Process()
        {
            new Command(this.Type, this.Encode());
        }
    }
}
