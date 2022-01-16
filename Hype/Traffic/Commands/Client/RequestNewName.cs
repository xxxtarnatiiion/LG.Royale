using System;

using LG.Royale.Hype;
using LG.Royale.Interface;

namespace LG.Royale.Packets
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
            this.Process();
        }

        /// <summary>
        /// Packet's component.
        /// </summary>
        string NewName;

        /// <summary>
        /// Decodes this instance.
        /// </summary>
        public void Decode()
        {
            NewName = this.Reader.ReadString();
        }

        /// <summary>
        /// Processes this instance.
        /// </summary>
        public void Process()
        {
            new NewNameOk(this.NewName);
            Display.Log("Client's name changed to: " + this.NewName);
        }
    }
}
