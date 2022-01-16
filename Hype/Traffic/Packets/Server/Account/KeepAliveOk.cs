using System;

using LG.Royale.Hype;
using LG.Royale.Network;

namespace LG.Royale.Packets
{
    class KeepAliveOk
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
        /// Packet's version.
        /// </summary>
        public int Version
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
        public KeepAliveOk()
        {
            this.Writer = new Writer();
        }

        /// <summary>
        /// Encodes this instance.
        /// </summary>
        private byte[] Encode()
        {
            return this.Writer.Patch(this.Identifier, this.Version);
        }

        /// <summary>
        /// Sends this instance.
        /// </summary>
        public void Send()
        {
            Gateway.Send(this.Encode());
        }
    }
}
