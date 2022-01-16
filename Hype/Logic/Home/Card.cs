using System;
using System.Collections;
using System.Collections.Generic;

using System.Linq;

using LG.Royale.Hype;
using LG.Royale.Logic;

namespace LG.Royale.Logic
{
    class Card
    {

        /// <summary>
        /// Card's location.
        /// </summary>
        public Deck.ChestType Type
        {
            get;
            set;
        }

        /// <summary>
        /// Card's ID.
        /// </summary>
        public int Identifier
        {
            get;
            set;
        }

        /// <summary>
        /// Card's amount.
        /// </summary>
        public int Amount
        {
            get;
            set;
        }

        /// <summary>
        /// Packet's writer.
        /// </summary>
        public Writer Writer = new Writer();

        /// <summary>
        /// Card's random.
        /// </summary>
        public static Random Random = new Random();

        /// <summary>
        /// Card's new instance.
        /// </summary>
        /// <param name="Type"></param>
        public Card(Deck.ChestType Type)
        {
            this.Type       = Type;
            this.Identifier = Random.Next(2, 59);

            if (this.Identifier == 51 || this.Identifier == 52 || 
                this.Identifier == 53 || this.Identifier == 54 ||
                this.Identifier == 55)
            {
                this.Identifier = 56;
            }

            Console.WriteLine(this.Identifier);
        }

        /// <summary>
        /// Gets the card's amount.
        /// </summary>
        /// <returns></returns>
        public int GetAmount()
        {
            if (this.Type == Deck.ChestType.Free)
            {
                if (Deck.Commons.Contains(this.Identifier))
                {
                    return Random.Next(8, 12);
                }

                if (Deck.Rares.Contains(this.Identifier))
                {
                    return Random.Next(1, 2);
                }

                if (Deck.Epics.Contains(this.Identifier))
                {
                    return 1;
                }

                if (Deck.Heroes.Contains(this.Identifier))
                {
                    return 0;
                }
            }

            if (this.Type == Deck.ChestType.Shop)
            {
                if (Deck.Commons.Contains(this.Identifier))
                {
                    return Random.Next(500, 550);
                }

                if (Deck.Rares.Contains(this.Identifier))
                {
                    return Random.Next(150, 200);
                }

                if (Deck.Epics.Contains(this.Identifier))
                {
                    return 10;
                }

                if (Deck.Heroes.Contains(this.Identifier))
                {
                    return 1;
                }
            }

            return 1;
        }

        /// <summary>
        /// Gets the maximum level the card can be.
        /// </summary>
        /// <returns></returns>
        public int GetLevel()
        {
            if (Deck.Commons.Contains(this.Identifier))
            {
                return 13;
            }

            if (Deck.Rares.Contains(this.Identifier))
            {
                return 11;
            }

            if (Deck.Epics.Contains(this.Identifier))
            {
                return 8;
            }

            else
            {
                return 5;
            }
        }

        /// <summary>
        /// Encodes this instance.
        /// </summary>
        /// <returns></returns>
        public List<byte> Encode()
        {
            this.Writer.WriteVInt(this.Identifier);
            this.Writer.WriteVInt(this.GetLevel());
            this.Writer.WriteVInt(0);

            this.Writer.WriteVInt(this.GetAmount());
            this.Writer.WriteVInt(0);
            this.Writer.WriteVInt(0);
            this.Writer.WriteVInt(2);

            return this.Writer.Stream;
        }
    }
}
