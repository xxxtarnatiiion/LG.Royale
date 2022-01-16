using System;
using System.Collections;
using System.Collections.Generic;

using LG.Royale.Hype;

namespace LG.Royale.Packets
{
    class EndClientTurn
    {

        /// <summary>
        /// Packet's ID.
        /// </summary>
        public static int Identifier
        {
            get
            {
                return 14102;
            }
        }

        /// <summary>
        /// Packet's reader.
        /// </summary>
        public Reader Reader;

        /// <summary>
        /// Packet's new instance.
        /// </summary>
        public EndClientTurn(byte[] Packet)
        {
            this.Reader = new Reader(Packet);

            this.Decode();
            this.Process();
        }

        /// <summary>
        /// Packet's components.
        /// </summary>
        public int Tick;
        public int Checksum;
        public int Count;
        public List<int> Commands;

        /// <summary>
        /// Decodes this instance.
        /// </summary>
        public void Decode()
        {
            Tick     = this.Reader.ReadVInt();
            Checksum = this.Reader.ReadVInt();
            Count    = this.Reader.ReadVInt();

            Commands = new List<int>();

            if (Count != 0)
            {
                if (Count == 1)
                {
                    Commands.Add(this.Reader.ReadVInt());
                }

                else
                {
                    for (int i = 0; i < Count; i++)
                    {
                        Commands.Add(this.Reader.ReadVInt());
                    }
                }
            }
            
            foreach (int Int in Commands)
            {
                Console.WriteLine(Int);
            }
        }

        /// <summary>
        /// Processes this instance.
        /// </summary>
        public void Process()
        {
            if (Commands.Count != 0)
            {
                if (Commands[0] == 509)
                {
                    new FreeChestOk();
                }

                if (Commands[0] == 516)
                {
                    new GiantChestOk();
                }
            }
        }
    }
}
