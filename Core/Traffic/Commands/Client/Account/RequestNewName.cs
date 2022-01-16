using System;

using LG.Barbarian.Hype;

namespace LG.Barbarian.Traffic
{
    class RequestNewName
    {

        /// <summary>
        /// Packet's ID.
        /// </summary>
        public static int Identifier
        {
            get
            {
                return 14600;
            }
        }

        /// <summary>
        /// Packet's reader.
        /// </summary>
        public Reader Reader;

        /// <summary>
        /// Packet's new instance.
        /// </summary>
        public RequestNewName(byte[] Packet)
        {
            this.Reader = new Reader(Packet);
            this.Decode();
        }

        /// <summary>
        /// Packet's components.
        /// </summary>
        public static string NewName;

        /// <summary>
        /// Decodes this instance.
        /// </summary>
        public void Decode()
        {
            NewName = this.Reader.ReadString();
            this.Process();
        }

        /// <summary>
        /// Processes this instance.
        /// </summary>
        public void Process()
        {
            new SetNewName();
        }
    }
}
