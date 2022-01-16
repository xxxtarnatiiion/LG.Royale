using System;
using System.Collections;
using System.Collections.Generic;

using System.Text;
using System.Linq;

namespace LG.Royale.Hype
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
        /// Reader's offset.
        /// </summary>
        public int Offset
        {
            get
            {
                return 0;
            }
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
        /// Reads an integer-typed value.
        /// </summary>
        /// <returns></returns>
        public int ReadInt()
        {
            byte Stream = new List<byte>(this.Stream.Take(4).Reverse())[0];
            this.Stream.RemoveRange(this.Offset, 4);
            return Convert.ToInt32(Stream);
        }

        /// <summary>
        /// Reads a boolean-typed value.
        /// </summary>
        /// <returns></returns>
        public bool ReadBool()
        {
            byte Stream = new List<byte>(this.Stream.Take(1))[0];
            this.Stream.RemoveRange(this.Offset, 1);
            return Convert.ToBoolean(Stream);
        }

        /// <summary>
        /// Reads a byte-typed value.
        /// </summary>
        /// <returns></returns>
        public byte ReadByte()
        {
            byte Stream = new List<byte>(this.Stream.Take(1))[0];
            this.Stream.RemoveRange(this.Offset, 1);
            return Stream;
        }

        /// <summary>
        /// Reads a string-typed value.
        /// </summary>
        /// <returns></returns>
        public string ReadString()
        {
            int Length    = this.ReadInt();
            int BytesRead = 0;

            List<byte> Bytes = new List<byte>();

            while (BytesRead != Length)
            {
                Bytes.Add(this.ReadByte());
                BytesRead++;
            }

            return Encoding.UTF8.GetString(Bytes.ToArray());
        }

        /// <summary>
        /// Reads a vinteger-typed value.
        /// </summary>
        /// <returns></returns>
        public int ReadVInt()
        {
            int b, sign = ((b = ReadByte()) >> 6) & 1, i = b & 0x3F, offset = 6;

            for (var j = 0; j < 4 && (b & 0x80) != 0; j++, offset += 7)
                i |= ((b = ReadByte()) & 0x7F) << offset;

            return (b & 0x80) != 0 ? -1 : i | (sign == 1 && offset < 32 ? i | (int)(0xFFFFFFFF << offset) : i);
        }

        /// <summary>
        /// Skips values.
        /// </summary>
        /// <param name="Count"></param>
        public void Skip(int Count)
        {
            this.Stream.RemoveRange(0, Count);
        }
    }
}
