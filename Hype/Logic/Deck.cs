using System;

namespace LG.Royale.Logic
{
    class Deck
    {

        public enum ChestType
        {
            Free = 2,
            Shop = 4
        }

        /// <summary>
        /// Common's cards list.
        /// </summary>
        public static int[] Commons = new int[]
        {
            2, 3, 4, 7, 10, 12, 15, 21, 24, 26, 32, 33, 43, 45, 51, 58
        };

        /// <summary>
        /// Rare's cards list.
        /// </summary>
        public static int[] Rares = new int[]
        {
            5, 13, 16, 19, 20, 23, 30, 38, 40, 41, 42, 59
        };

        /// <summary>
        /// Epic's cards list.
        /// </summary>
        public static int[] Epics = new int[]
        {
            6, 8, 9, 11, 14, 17, 18, 22, 27, 29, 36, 47, 56
        };

        /// <summary>
        /// Hero's cards list.
        /// </summary>
        public static int[] Heroes = new int[]
        {
            25, 28, 31, 35, 37, 39, 44, 48, 50, 57
        };
    }
}
