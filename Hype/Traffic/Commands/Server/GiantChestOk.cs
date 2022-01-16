using System;
using System.Collections;
using System.Collections.Generic;

using LG.Royale.Hype;
using LG.Royale.Logic;
using LG.Royale.Network;

namespace LG.Royale.Packets
{
    class GiantChestOk
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
        /// Packet's new instance.
        /// </summary>
        public GiantChestOk()
        {
            this.Writer = new Writer();
            this.Process();
        }

        /// <summary>
        /// Encodes this instance.
        /// </summary>
        public byte[] Encode()
        {
            int Count = Card.Random.Next(7, 8);

            this.Writer.WriteVInt(210);

            this.Writer.WriteVInt(1);
            this.Writer.WriteBool(false);
            this.Writer.WriteVInt(Count);

            for (int i = 0; i < Count; i++)
            {
                Card Card = new Card(Deck.ChestType.Shop);
                this.Writer.WriteList(Card.Encode());
            }

            this.Writer.WriteVInt(0);
            this.Writer.WriteVInt(new Random().Next(3000, 4500));
            this.Writer.WriteVInt(0);

            this.Writer.WriteVInt(228);
            this.Writer.WriteVInt((int) Deck.ChestType.Shop);
            this.Writer.WriteVInt((int) Deck.ChestType.Shop);

            this.Writer.WriteNullVInt(2);
            this.Writer.WriteVInt(0);
            this.Writer.WriteVInt(0);

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
