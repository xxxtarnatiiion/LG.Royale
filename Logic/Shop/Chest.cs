using System;
using System.Collections;
using System.Collections.Generic;

using LG.Barbarian.Hype;

namespace LG.Barbarian.Logic
{
    class Chest
    {

        /// <summary>
        /// Chest's types.
        /// </summary>
        public enum Type
        {
            Free = 2,
            Shop = 4
        }

        /// <summary>
        /// Chest's type.
        /// </summary>
        public Type ChestType
        {
            get;
            set;
        }

        /// <summary>
        /// Chest's writer.
        /// </summary>
        public Writer Writer;

        /// <summary>
        /// Chest's random.
        /// </summary>
        public Random Random;

        /// <summary>
        /// Chest's new instance.
        /// </summary>
        /// <param name="ChestType"></param>
        public Chest(Type ChestType)
        {
            this.Writer    = new Writer();
            this.Random    = new Random();
            this.ChestType = ChestType;
        }

        /// <summary>
        /// Encodes this instance.
        /// </summary>
        /// <returns></returns>
        public List<byte> Encode()
        {
            if (this.ChestType == Type.Free)
            {
                int Count = this.Random.Next(2, 4);

                this.Writer.WriteVInt(1);
                this.Writer.WriteBool(false);
                this.Writer.WriteVInt(Count);

                for (int i = 0; i < Count; i++)
                {
                    this.Writer.WriteList(new Card(Type.Free).Encode());
                }

                this.Writer.WriteVInt(0);
                this.Writer.WriteVInt(Random.Next(60, 90));
                this.Writer.WriteVInt(Random.Next(0, 3));

                this.Writer.WriteVInt(233);
                this.Writer.WriteVInt((int) this.ChestType);
                this.Writer.WriteVInt((int) this.ChestType);

                this.Writer.WriteHex("7F-7F");
                this.Writer.WriteVInt(0);
                this.Writer.WriteVInt(0);
                return this.Writer.Stream;
            }

            if (this.ChestType == Type.Shop)
            {
                this.Writer.WriteVInt(1);
                this.Writer.WriteBool(false);
                this.Writer.WriteVInt(7);

                for (int i = 0; i < 7; i++)
                {
                    this.Writer.WriteList(new Card(Type.Shop).Encode());
                }

                this.Writer.WriteVInt(0);
                this.Writer.WriteVInt(Random.Next(3000, 5000));
                this.Writer.WriteVInt(Random.Next(100, 150));

                this.Writer.WriteVInt(228);
                this.Writer.WriteVInt((int)this.ChestType);
                this.Writer.WriteVInt((int)this.ChestType);

                this.Writer.WriteHex("7F-7F");
                this.Writer.WriteVInt(0);
                this.Writer.WriteVInt(0);
                return this.Writer.Stream;
            }

            return null;
        }
    }
}
