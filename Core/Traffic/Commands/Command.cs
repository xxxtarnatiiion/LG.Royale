using System;
using System.Collections;
using System.Collections.Generic;

using LG.Barbarian.Hype;
using LG.Barbarian.Network;

namespace LG.Barbarian.Traffic
{
    class Command
    {

        /// <summary>
        /// Packet's ID.
        /// </summary>
        public int Identifier
        {
            get
            {
                return 24111;
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
        /// Packet's component.
        /// </summary>
        public int Type;

        /// <summary>
        /// Packet's writer.
        /// </summary>
        public Writer Writer;
        public List<byte> Stream;

        /// <summary>
        /// Packet's new instance.
        /// </summary>
        public Command(int Type, List<byte> Stream)
        {
            this.Writer = new Writer();
            this.Stream = Stream;
            this.Type   = Type;
            this.Process();
        }

        /// <summary>
        /// Encodes this instance.
        /// </summary>
        public byte[] Encode()
        {
            this.Writer.WriteVInt(this.Type);
            this.Writer.WriteList(this.Stream);
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
