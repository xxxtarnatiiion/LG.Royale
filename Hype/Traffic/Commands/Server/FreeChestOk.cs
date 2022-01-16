using System;
using System.Collections;
using System.Collections.Generic;

using LG.Royale.Hype;
using LG.Royale.Logic;
using LG.Royale.Network;

namespace LG.Royale.Packets
{
    class FreeChestOk
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
        public FreeChestOk()
        {
            this.Writer = new Writer();
            this.Process();
        }

        /// <summary>
        /// Encodes this instance.
        /// </summary>
        public byte[] Encode()
        {
            int Count = Card.Random.Next(2, 3);

            this.Writer.WriteVInt(210);

            this.Writer.WriteVInt(1);
            this.Writer.WriteBool(false);
            this.Writer.WriteVInt(Count);

            for (int i = 0; i < Count; i++)
            {
                Card Card = new Card(Deck.ChestType.Free);
                this.Writer.WriteList(Card.Encode());
            }

            this.Writer.WriteVInt(0);
            this.Writer.WriteVInt(new Random().Next(30, 60));
            this.Writer.WriteVInt(new Random().Next(0, 5));

            this.Writer.WriteVInt(233);
            this.Writer.WriteVInt((int)Deck.ChestType.Free);
            this.Writer.WriteVInt((int)Deck.ChestType.Free);

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
