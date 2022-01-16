using System;

using LG.Barbarian.Hype;

namespace LG.Barbarian.Traffic
{
    class EndClient
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
        public EndClient(byte[] Packet)
        {
            this.Reader = new Reader(Packet);
            this.Decode();
        }

        public int Type;

        /// <summary>
        /// Decodes this instance.
        /// </summary>
        public void Decode()
        {
            this.Reader.ReadVInt();
            this.Reader.ReadVInt();
            this.Reader.ReadVInt();

            Type = this.Reader.ReadVInt();
            this.Process();
        }

        /// <summary>
        /// Processes this instance.
        /// </summary>
        public void Process()
        {
            if (Type == 509)
            {
                new SendFreeChest();
            }

            if (Type == 516)
            {
                new SendSuperChest();
            }
        }
    }
}
