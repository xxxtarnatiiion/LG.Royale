﻿using System;

using LG.Barbarian.Hype;
using LG.Barbarian.Network;

namespace LG.Barbarian.Traffic
{
    class ServerHello
    {

        /// <summary>
        /// Packet's ID.
        /// </summary>
        public int Identifier
        {
            get
            {
                return 20104;
            }
        }

        /// <summary>
        /// Packet's node.
        /// </summary>
        public int Node
        {
            get
            {
                return 1;
            }
        }

        /// <summary>
        /// Packet's writer.
        /// </summary>
        public Writer Writer;

        /// <summary>
        /// Packet's new instance.
        /// </summary>
        public ServerHello()
        {
            this.Writer = new Writer();
            this.Process();
        }

        /// <summary>
        /// Encodes this instance.
        /// </summary>
        public byte[] Encode()
        {
            this.Writer.WriteHex("00-00-00-02-00-00-37-EE-00-00-00-02-00-00-37-EE-00-00-00-28-68-77-38-72-37-32-78-66-6B-6D-6E-67-65-72-39-6A-72-77-6E-74-77-6B-77-68-61-33-6B-73-61-73-32-79-77-72-62-63-61-66-77-6A-00-00-00-0F-32-32-32-31-37-34-33-32-31-34-35-36-39-34-31-00-00-00-0B-47-3A-33-32-35-33-37-38-36-37-31-03-B9-05-B9-05-03-00-00-00-04-70-72-6F-64-8E-16-91-9E-3F-8E-08-00-00-00-10-31-34-37-35-32-36-38-37-38-36-31-31-32-34-33-33-00-00-00-0D-31-34-39-37-34-37-34-36-35-36-32-38-31-00-00-00-0D-31-34-35-31-39-39-36-37-37-38-30-30-30-00-00-00-00-15-31-30-33-34-31-39-33-37-30-32-37-34-34-31-31-32-39-36-37-32-30-FF-FF-FF-FF-FF-FF-FF-FF-00-00-00-02-46-52-00-00-00-0E-56-61-75-78-2D-6C-65-2D-70-C3-A9-6E-69-6C-00-00-00-50-68-74-74-70-3A-2F-2F-37-31-36-36-30-34-36-62-31-34-32-34-38-32-65-36-37-62-33-30-2D-32-61-36-33-66-34-34-33-36-63-39-36-37-61-61-37-64-33-35-35-30-36-31-62-64-30-64-39-32-34-61-31-2E-72-36-35-2E-63-66-31-2E-72-61-63-6B-63-64-6E-2E-63-6F-6D-00-00-00-24-68-74-74-70-73-3A-2F-2F-65-76-65-6E-74-2D-61-73-73-65-74-73-2E-63-6C-61-73-68-72-6F-79-61-6C-65-2E-63-6F-6D-02");
            return this.Writer.Write(this.Identifier, this.Node);
        }

        /// <summary>
        /// Processes this instance.
        /// </summary>
        public void Process()
        {
            Protocol.Throw(this.Encode());
        }
    }
}
