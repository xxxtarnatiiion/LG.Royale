using System;
using System.Collections;
using System.Collections.Generic;

using System.Text;
using System.Linq;
using System.Globalization;

using LG.Barbarian.Network;

namespace LG.Barbarian.Hype
{
    class Writer
    {

        /// <summary>
        /// Writer's stream.
        /// </summary>
        public List<byte> Stream
        {
            get;
            set;
        }

        /// <summary>
        /// Writer's new instance.
        /// </summary>
        public Writer()
        {
            this.Stream = new List<byte>();
        }

        /// <summary>
        /// Writes the packet.
        /// </summary>
        /// <param name="Identifier"></param>
        /// <param name="Node"></param>
        public byte[] Write(int Identifier, int Node)
        {
            byte[] Identifiers = BitConverter.GetBytes(Identifier);
            byte[] Lengths     = BitConverter.GetBytes(this.Stream.Count);
            byte[] Nodes       = BitConverter.GetBytes(Node);

            List<byte> Encrypted = new List<byte>(Gateway.Encrypter.Encrypt(this.Stream.ToArray()));

            Encrypted.Insert(0, Nodes[0]);
            Encrypted.Insert(0, Nodes[1]);

            Encrypted.Insert(0, Lengths[0]);
            Encrypted.Insert(0, Lengths[1]);
            Encrypted.Insert(0, Lengths[2]);

            Encrypted.Insert(0, Identifiers[0]);
            Encrypted.Insert(0, Identifiers[1]);

            return Encrypted.ToArray();
        }

        /// <summary>
        /// Writes an integer.
        /// </summary>
        /// <param name="Value"></param>
        public void WriteInt(int Value)
        {
            foreach (byte Byte in BitConverter.GetBytes(Value).Reverse())
            {
                this.Stream.Add(Byte);
            }
        }

        /// <summary>
        /// Writes a variable length integer.
        /// </summary>
        /// <param name="Value"></param>
        public void WriteVInt(int Value)
        {

            /// Author:
            /// https://github.com/BerkanYildiz/
            
            if (Value >= 0)
            {
                if (Value >= 64)
                {
                    if (Value >= 0x2000)
                    {
                        if (Value >= 0x100000)
                        {
                            if (Value >= 0x8000000)
                            {
                                this.Stream.Add((byte)(Value         & 0x3F | 0x80));
                                this.Stream.Add((byte)((Value >> 6)  & 0x7F | 0x80));
                                this.Stream.Add((byte)((Value >> 13) & 0x7F | 0x80));
                                this.Stream.Add((byte)((Value >> 20) & 0x7F | 0x80));
                                this.Stream.Add((byte)((Value >> 27) & 0xF));

                                return;
                            }

                            this.Stream.Add((byte)(Value         & 0x3F | 0x80));
                            this.Stream.Add((byte)((Value >> 6)  & 0x7F | 0x80));
                            this.Stream.Add((byte)((Value >> 13) & 0x7F | 0x80));
                            this.Stream.Add((byte)((Value >> 20) & 0x7F));

                            return;
                        }

                        this.Stream.Add((byte)(Value         & 0x3F | 0x80));
                        this.Stream.Add((byte)((Value >> 6)  & 0x7F | 0x80));
                        this.Stream.Add((byte)((Value >> 13) & 0x7F));

                        return;
                    }

                    this.Stream.Add((byte)(Value        & 0x3F | 0x80));
                    this.Stream.Add((byte)((Value >> 6) & 0x7F));

                    return;
                }

                this.Stream.Add((byte)(Value & 0x3F));
            }
            else
            {
                if (Value <= -0x40)
                {
                    if (Value <= -0x2000)
                    {
                        if (Value <= -0x100000)
                        {
                            if (Value <= -0x8000000)
                            {
                                this.Stream.Add((byte)(Value         & 0x3F | 0xC0));
                                this.Stream.Add((byte)((Value >> 6)  & 0x7F | 0x80));
                                this.Stream.Add((byte)((Value >> 13) & 0x7F | 0x80));
                                this.Stream.Add((byte)((Value >> 20) & 0x7F | 0x80));
                                this.Stream.Add((byte)((Value >> 27) & 0xF));

                                return;
                            }

                            this.Stream.Add((byte)(Value         & 0x3F | 0xC0));
                            this.Stream.Add((byte)((Value >> 6)  & 0x7F | 0x80));
                            this.Stream.Add((byte)((Value >> 13) & 0x7F | 0x80));
                            this.Stream.Add((byte)((Value >> 20) & 0x7F));

                            return;
                        }

                        this.Stream.Add((byte)(Value         & 0x3F | 0xC0));
                        this.Stream.Add((byte)((Value >> 6)  & 0x7F | 0x80));
                        this.Stream.Add((byte)((Value >> 13) & 0x7F));

                        return;
                    }

                    this.Stream.Add((byte)(Value        & 0x3F | 0xC0));
                    this.Stream.Add((byte)((Value >> 6) & 0x7F));

                    return;
                }

                this.Stream.Add((byte)(Value & 0x3F | 0x40));
            }
        }

        /// <summary>
        /// Writes a boolean.
        /// </summary>
        /// <param name="Value"></param>
        public void WriteBool(bool Value)
        {
            if (Value)
                this.Stream.Add(0x01);

            else
                this.Stream.Add(0x00);
        }

        /// <summary>
        /// Writes an hexadecimal array.
        /// </summary>
        /// <param name="Value"></param>
        public void WriteHex(string Value)
        {
            if (!Value.Contains("-"))
                Value = Value.Replace(' ', '-');

            string[] Values = Value.Split('-');

            for (int i = 0; i < Values.Length; i++)
            {
                this.Stream.Add(byte.Parse(Values[i], NumberStyles.HexNumber));
            }
        }

        /// <summary>
        /// Writes a string.
        /// </summary>
        /// <param name="Value"></param>
        public void WriteString(string Value)
        {
            this.WriteInt(Value.Length);

            foreach (byte Byte in Encoding.UTF8.GetBytes(Value))
            {
                this.Stream.Add(Byte);
            }
        }

        /// <summary>
        /// Writes a list.
        /// </summary>
        /// <param name="Value"></param>
        public void WriteList(List<byte> Value)
        {
            foreach (byte Byte in Value)
            {
                this.Stream.Add(Byte);
            }
        }
    }
}
