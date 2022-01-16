using System;
using System.Collections;
using System.Collections.Generic;

using System.Text;
using System.Linq;
using System.Globalization;

using LG.Royale.Network;

namespace LG.Royale.Hype
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
        /// Writes an hexadecimal-typed array.
        /// </summary>
        /// <param name="Value"></param>
        public void WriteHex(string Value)
        {
            if (!Value.Contains("-"))
            {
                Value = Value.Replace(' ', '-');
            }

            string[] Values = Value.Split('-');
            byte[] Bytes    = new byte[Values.Length];

            for (int i = 0; i < Bytes.Length; i++)
            {
                Bytes[i] = byte.Parse(Values[i], NumberStyles.HexNumber);
            }

            foreach (byte Byte in Bytes)
            {
                this.Stream.Add(Byte);
            }
        }

        /// <summary>
        /// Writes an integer-typed value.
        /// </summary>
        /// <param name="Value"></param>
        public void WriteInt(int Value)
        {
            byte[] Bytes = BitConverter.GetBytes(Value);
            Array.Reverse(Bytes);

            foreach (byte Byte in Bytes)
            {
                this.Stream.Add(Byte);
            }
        }

        /// <summary>
        /// Writes a string-typed value.
        /// </summary>
        /// <param name="Value"></param>
        public void WriteString(string Value)
        {
            this.WriteInt(Value.Length);

            byte[] Bytes = Encoding.UTF8.GetBytes(Value);

            foreach (byte Byte in Bytes)
            {
                this.Stream.Add(Byte);
            }
        }

        /// <summary>
        /// Writes a vinteger-typed value.
        /// </summary>
        /// <param name="Value"></param>
        public void WriteVInt(int Value)
        {
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
                                this.Stream.Add((byte)(Value & 0x3F | 0x80));
                                this.Stream.Add((byte)((Value >> 6) & 0x7F | 0x80));
                                this.Stream.Add((byte)((Value >> 13) & 0x7F | 0x80));
                                this.Stream.Add((byte)((Value >> 20) & 0x7F | 0x80));
                                this.Stream.Add((byte)((Value >> 27) & 0xF));

                                return;
                            }

                            this.Stream.Add((byte)(Value & 0x3F | 0x80));
                            this.Stream.Add((byte)((Value >> 6) & 0x7F | 0x80));
                            this.Stream.Add((byte)((Value >> 13) & 0x7F | 0x80));
                            this.Stream.Add((byte)((Value >> 20) & 0x7F));

                            return;
                        }

                        this.Stream.Add((byte)(Value & 0x3F | 0x80));
                        this.Stream.Add((byte)((Value >> 6) & 0x7F | 0x80));
                        this.Stream.Add((byte)((Value >> 13) & 0x7F));

                        return;
                    }

                    this.Stream.Add((byte)(Value & 0x3F | 0x80));
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
                                this.Stream.Add((byte)(Value & 0x3F | 0xC0));
                                this.Stream.Add((byte)((Value >> 6) & 0x7F | 0x80));
                                this.Stream.Add((byte)((Value >> 13) & 0x7F | 0x80));
                                this.Stream.Add((byte)((Value >> 20) & 0x7F | 0x80));
                                this.Stream.Add((byte)((Value >> 27) & 0xF));

                                return;
                            }

                            this.Stream.Add((byte)(Value & 0x3F | 0xC0));
                            this.Stream.Add((byte)((Value >> 6) & 0x7F | 0x80));
                            this.Stream.Add((byte)((Value >> 13) & 0x7F | 0x80));
                            this.Stream.Add((byte)((Value >> 20) & 0x7F));

                            return;
                        }

                        this.Stream.Add((byte)(Value & 0x3F | 0xC0));
                        this.Stream.Add((byte)((Value >> 6) & 0x7F | 0x80));
                        this.Stream.Add((byte)((Value >> 13) & 0x7F));

                        return;
                    }

                    this.Stream.Add((byte)(Value & 0x3F | 0xC0));
                    this.Stream.Add((byte)((Value >> 6) & 0x7F));

                    return;
                }

                this.Stream.Add((byte)(Value & 0x3F | 0x40));
            }
        }

        /// <summary>
        /// Writes a boolean-typed value.
        /// </summary>
        /// <param name="Value"></param>
        public void WriteBool(bool Value)
        {
            if (Value)
            {
                this.Stream.Add(0x01);
            }

            else
            {
                this.Stream.Add(0x00);
            }
        }

        /// <summary>
        /// Writes a list of bytes-typed value.
        /// </summary>
        /// <param name="Value"></param>
        public void WriteList(List<byte> Value)
        {
            foreach (byte Byte in Value)
            {
                this.Stream.Add(Byte);
            }
        }

        /// <summary>
        /// Writes a null vinteger-typed value.
        /// </summary>
        /// <param name="Count"></param>
        public void WriteNullVInt(int Count = 1)
        {
            for (int i = 0; i < Count; i++)
            {
                this.Stream.Add(0x7F);
            }
        }

        /// <summary>
        /// Patches the stream.
        /// </summary>
        public byte[] Patch(int Identifier, int Version)
        {
            byte[] Identifiers = BitConverter.GetBytes(Identifier);
            byte[] Lengths     = BitConverter.GetBytes(this.Stream.Count);
            byte[] Versions    = BitConverter.GetBytes(Version);

            List<byte> Encrypted = new List<byte>(Protocol.Encrypter.Encrypt(this.Stream.ToArray()));

            Encrypted.Insert(0, Versions[0]);
            Encrypted.Insert(0, Versions[1]);

            Encrypted.Insert(0, Lengths[0]);
            Encrypted.Insert(0, Lengths[1]);
            Encrypted.Insert(0, Lengths[2]);

            Encrypted.Insert(0, Identifiers[0]);
            Encrypted.Insert(0, Identifiers[1]);

            return Encrypted.ToArray();
        }
    }
}
