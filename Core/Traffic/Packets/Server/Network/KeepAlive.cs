using System;

using LG.Barbarian.Hype;
using LG.Barbarian.Network;

namespace LG.Barbarian.Traffic
{
    class KeepAlive
    {

        /// <summary>
        /// Packet's ID.
        /// </summary>
        public int Identifier
        {
            get
            {
                return 20108;
            }
        }

        /// <summary>
        /// Packet's node.
        /// </summary>
        public int Node
        {
            get
            {
                return 0;
            }
        }

        /// <summary>
        /// Packet's writer.
        /// </summary>
        public Writer Writer;

        /// <summary>
        /// Packet's new instance.
        /// </summary>
        public KeepAlive()
        {
            this.Writer = new Writer();
            this.Process();
        }

        /// <summary>
        /// Encodes this instance.
        /// </summary>
        public byte[] Encode()
        {
            return this.Writer.Write(this.Identifier, this.Node);
        }

        /// <summary>
        /// Processes this instance.
        /// </summary>
        public void Process()
        {
            Protocol.Throw(this.Encode());
        }
    }
}
