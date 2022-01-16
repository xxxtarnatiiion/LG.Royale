using System;
using System.Collections;
using System.Collections.Generic;

using System.Linq;

using LG.Barbarian.Hype;

namespace LG.Barbarian.Logic
{
    class Card
    {

        /// <summary>
        /// Card's ID.
        /// </summary>
        public int Identifier
        {
            get;
            set;
        }

        /// <summary>
        /// Card's chest.
        /// </summary>
        public Chest.Type ChestType
        {
            get;
            set;
        }

        public int Amount
        {
            get;
            set;
        }

        public int Level
        {
            get;
            set;
        }

        /// <summary>
        /// Card's random.
        /// </summary>
        public static Random Random = new Random();

        /// <summary>
        /// Card's writer.
        /// </summary>
        public Writer Writer;

        /// <summary>
        /// Card's new instance.
        /// </summary>
        public Card(Chest.Type ChestType)
        {
            this.Writer     = new Writer();
            this.Identifier = Collections.All[Random.Next(Collections.All.Length)];
            this.ChestType  = ChestType;
            this.Amount     = this.GetAmount();
            this.Level      = this.GetLevel();
        }

        /// <summary>
        /// Gets the card's amount.
        /// </summary>
        /// <returns></returns>
        public int GetAmount()
        {
            if (this.ChestType == Chest.Type.Free)
            {
                if (Collections.Commons.Contains(this.Identifier))
                {
                    
                    return Random.Next(8, 12);
                }

                if (Collections.Rares.Contains(this.Identifier))
                {
                    return Random.Next(2, 4);
                }

                else
                {
                    return 1;
                }
            }

            if (this.ChestType == Chest.Type.Shop)
            {
                if (Collections.Commons.Contains(this.Identifier))
                {

                    return Random.Next(400, 600);
                }

                if (Collections.Rares.Contains(this.Identifier))
                {
                    return Random.Next(150, 250);
                }

                if (Collections.Epics.Contains(this.Identifier))
                {
                    return Random.Next(10, 15);
                }

                else
                {
                    return 2;
                }
            }

            else
                return 0;
        }

        /// <summary>
        /// Gets the card's level.
        /// </summary>
        /// <returns></returns>
        public int GetLevel()
        {
            if (this.ChestType == Chest.Type.Free || this.ChestType == Chest.Type.Shop)
            {
                if (Collections.Commons.Contains(this.Identifier))
                {
                    return 13;
                }

                if (Collections.Rares.Contains(this.Identifier))
                {
                    return 11;
                }

                if (Collections.Epics.Contains(this.Identifier))
                {
                    return 8;
                }

                else
                {
                    return 5;
                }
            }

            else
            {
                return 0;
            }  
        }

        /// <summary>
        /// Encodes this instance.
        /// </summary>
        /// <returns></returns>
        public List<byte> Encode()
        {
            this.Writer.WriteVInt(this.Identifier);
            this.Writer.WriteVInt(this.Level);
            this.Writer.WriteVInt(0);

            this.Writer.WriteVInt(this.Amount);
            this.Writer.WriteVInt(0);
            this.Writer.WriteVInt(0);
            this.Writer.WriteVInt(2);
            return this.Writer.Stream;
        }
    }

    class Collections
    {

        /// <summary>
        /// Common cards list.
        /// </summary>
        public static int[] Commons = new int[]
        {
            1, 2, 3, 6, 9, 11, 14, 20, 23, 25, 31, 32, 42, 44, 50, 57
        };

        /// <summary>
        /// Rare cards list.
        /// </summary>
        public static int[] Rares = new int[]
        {
            4, 12, 18, 19, 22, 29, 37, 39, 40, 41, 58
        };

        /// <summary>
        /// Epic cards list.
        /// </summary>
        public static int[] Epics = new int[]
        {
            5, 7, 8, 10, 13, 16, 17, 21, 26, 28, 35, 46, 55
        };

        /// <summary>
        /// Legendary cards list.
        /// </summary>
        public static int[] Legendaries = new int[]
        {
            24, 27, 30, 33, 34, 36, 38, 43, 47, 49, 56
        };

        /// <summary>
        /// All cards list.
        /// </summary>
        public static int[] All = new int[]
        {
            1, 2, 3, 6, 9, 11, 14, 20, 23, 25, 31, 32, 42, 44, 50, 57,
            4, 12, 18, 19, 22, 29, 37, 39, 40, 41, 58,
            5, 7, 8, 10, 13, 16, 17, 21, 26, 28, 35, 46, 55,
            24, 27, 30, 33, 34, 36, 38, 43, 47, 49, 56
        };
    }
}
