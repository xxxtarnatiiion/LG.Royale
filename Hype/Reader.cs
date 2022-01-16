using System;
using System.Collections;
using System.Collections.Generic;

using System.Text;
using System.Linq;

namespace LG.Barbarian.Hype
{
    class Reader
    {

        /// <summary>
        /// Reader's stream.
        /// </summary>
        public List<byte> Stream
        {
            get;
            set;
        }

        /// <summary>
        /// Reader's new instance.
        /// </summary>
        /// <param name="Packet"></param>
        public Reader(byte[] Packet)
        {
            this.Stream = new List<byte>(Packet.Skip(7));
        }

        /// <summary>
        /// Skips bytes.
        /// </summary>
        /// <param name="Count"></param>
        public void Skip(int Count)
        {
            this.Stream.RemoveRange(0, Count);
        }

        /// <summary>
        /// Reads an integer.
        /// </summary>
        /// <returns></returns>
        public int ReadInt()
        {
            int Value = Convert.ToInt32(this.Stream.Take(4).Reverse().ToArray()[0]);
            this.Stream.RemoveRange(0, 4);
            return Value;
        }

        /// <summary>
        /// Reads a variable length integer.
        /// </summary>
        /// <returns></returns>
        public int ReadVInt()
        {

            /// Author:
            /// https://github.com/retroroyale/
            
            int b, sign = ((b = this.ReadByte()) >> 6) & 1, i = b & 0x3F, offset = 6;

            for (var j = 0; j < 4 && (b & 0x80) != 0; j++, offset += 7)
                i |= ((b = this.ReadByte()) & 0x7F) << offset;

            return (b & 0x80) != 0 ? -1 : i | (sign == 1 && offset < 32 ? i | (int)(0xFFFFFFFF << offset) : i);
        }

        /// <summary>
        /// Reads a boolean.
        /// </summary>
        /// <returns></returns>
        public bool ReadBool()
        {
            bool Value = Convert.ToBoolean(this.Stream.Take(1).ToArray()[0]);
            this.Stream.RemoveRange(0, 1);
            return Value;
        }

        /// <summary>
        /// Reads a byte.
        /// </summary>
        /// <returns></returns>
        public byte ReadByte()
        {
            try
            {
                byte Value = this.Stream.Take(1).ToArray()[0];
                this.Stream.RemoveRange(0, 1);
                return Value;
            }

            catch (IndexOutOfRangeException)
            {
                return 0x00;
            }  
        }

        /// <summary>
        /// Reads a string.
        /// </summary>
        /// <returns></returns>
        public string ReadString()
        {
            byte[] Bytes = new byte[this.ReadInt()];

            for (int i = 0; i < Bytes.Length; i++)
            {
                Bytes[i] = this.ReadByte();
            }

            return Encoding.UTF8.GetString(Bytes);
        }
    }
}
