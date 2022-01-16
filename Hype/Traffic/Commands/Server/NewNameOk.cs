using System;
using System.Collections;
using System.Collections.Generic;

using LG.Royale.Hype;
using LG.Royale.Network;

namespace LG.Royale.Packets
{
    class NewNameOk
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
        /// Packet's component.
        /// </summary>
        public string NewName;

        /// <summary>
        /// Packet's new instance.
        /// </summary>
        public NewNameOk(string NewName)
        {
            this.Writer  = new Writer();
            this.NewName = NewName;

            this.Process();
        }

        /// <summary>
        /// Encodes this instance.
        /// </summary>
        public byte[] Encode()
        {
            this.Writer.WriteVInt(201);
            this.Writer.WriteString(this.NewName);
            this.Writer.WriteInt(0);

            return this.Writer.Patch(this.Identifier, this.Version);
        }

        /// <summary>
        /// Processes this instance.
        /// </summary>
        public void Process()
        {
            Gateway.Send(this.Encode());
        }
    }
}
