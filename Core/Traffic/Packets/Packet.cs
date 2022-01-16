using System;
using System.Collections;
using System.Collections.Generic;

using System.Linq;
using System.Threading;
using System.Globalization;

using LG.Barbarian.Hype;

namespace LG.Barbarian.Core
{
    class Packet
    {

        /// <summary>
        /// Identifies the specified packet.
        /// </summary>
        /// <param name="Packet"></param>
        /// <returns></returns>
        public static int Identify(byte[] Packet)
        {
            try
            {
                string[] Bytes = BitConverter.ToString(Packet).Split('-');
                return int.Parse(Bytes[0] + Bytes[1], NumberStyles.HexNumber);
            }

            catch (IndexOutOfRangeException)
            {
                Program.Log("Minion's king has disconnected.", false);
                Thread.Sleep(2500);
                Environment.Exit(0);
            }

            return 0; 
        }

        /// <summary>
        /// Patches the specified packet.
        /// </summary>
        /// <param name="Packet"></param>
        /// <param name="Decrypter"></param>
        /// <returns></returns>
        public static byte[] Patch(byte[] Packet, Rivest Decrypter)
        {
            List<byte> Header    = new List<byte>(Packet.Take(7).Reverse());
            List<byte> Decrypted = new List<byte>(Decrypter.Decrypt(Packet.Skip(7).ToArray()));

            foreach (byte Byte in Header)
            {
                Decrypted.Insert(0, Byte);
            }

            return Decrypted.ToArray();
        }
    }
}
