using System;
using System.Collections;
using System.Collections.Generic;

using System.Linq;
using System.Threading;
using System.Globalization;

using LG.Royale.Interface;

namespace LG.Royale.Hype
{
    class Packet
    {

        /// <summary>
        /// Fills the specified packet.
        /// </summary>
        /// <param name="Packet"></param>
        /// <param name="Length"></param>
        public static byte[] Fill(byte[] Packet, int Length)
        {
            byte[] Filled = new byte[Length];
            Array.Copy(Packet, Filled, Length);
            return Filled;
        }

        /// <summary>
        /// Gets the specified packet's ID.
        /// </summary>
        /// <param name="Packet"></param>
        /// <returns></returns>
        public static int GetIdentifier(byte[] Packet)
        {
            try
            {
                string[] Values = BitConverter.ToString(Packet).Split('-');
                return int.Parse(Values[0] + Values[1], NumberStyles.HexNumber);
            }

            catch (IndexOutOfRangeException)
            {
                Display.Log("Client disconnected.");
                Console.ReadKey(false);
                Environment.Exit(0);
                return 0;
            }       
        }
    }
}
