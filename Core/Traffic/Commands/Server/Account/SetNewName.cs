using System;
using System.Collections;
using System.Collections.Generic;

using LG.Barbarian.Hype;

namespace LG.Barbarian.Traffic
{
    class SetNewName
    {

        /// <summary>
        /// Packet's type.
        /// </summary>
        public int Type
        {
            get
            {
                return 201;
            }
        }

        /// <summary>
        /// Packet's writer.
        /// </summary>
        public Writer Writer;

        /// <summary>
        /// Packet's new instance.
        /// </summary>
        public SetNewName()
        {
            this.Writer = new Writer();
            this.Process();
        }

        /// <summary>
        /// Encodes this instance.
        /// </summary>
        public List<byte> Encode()
        {
            this.Writer.WriteString(RequestNewName.NewName);
            this.Writer.WriteVInt(0);
            this.Writer.WriteBool(true);
            return this.Writer.Stream;
        }

        /// <summary>
        /// Processes this instance.
        /// </summary>
        public void Process()
        {
            new Command(this.Type, this.Encode());
        }
    }
}
