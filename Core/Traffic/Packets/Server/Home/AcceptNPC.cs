﻿using System;

using LG.Barbarian.Hype;
using LG.Barbarian.Network;

namespace LG.Barbarian.Traffic
{
    class AcceptNPC
    {

        /// <summary>
        /// Packet's ID.
        /// </summary>
        public int Identifier
        {
            get
            {
                return 21903;
            }
        }

        /// <summary>
        /// Packet's node.
        /// </summary>
        public int Node
        {
            get
            {
                return 0;
            }
        }

        /// <summary>
        /// Packet's writer.
        /// </summary>
        public Writer Writer;

        /// <summary>
        /// Packet's new instance.
        /// </summary>
        public AcceptNPC()
        {
            this.Writer = new Writer();
            this.Process();
        }

        /// <summary>
        /// Encodes this instance.
        /// </summary>
        public byte[] Encode()
        {
            this.Writer.WriteHex("01-80-03-00-00-78-9C-9D-92-BD-6B-54-41-14-C5-CF-9D-37-77-DE-7B-FB-15-D7-6C-36-E6-CE-24-6E-B2-9B-44-13-4C-E9-57-91-42-FC-47-04-53-04-C5-48-A2-20-68-58-41-90-25-C4-18-91-45-8B-F8-01-AE-B2-85-48-2C-8C-DB-C5-46-C1-5E-CB-20-88-60-63-95-C6-4E-9D-DD-BC-4D-04-6D-F4-0C-F3-B8-9C-39-BF-79-CC-DC-C1-70-35-8D-EF-DF-BE-1E-7B-FF-EE-43-8D-A9-EA-85-8E-E8-F1-28-7E-57-F4-47-D1-0E-29-F5-E2-13-75-A7-37-CC-A9-99-F9-73-67-2E-A4-36-2B-F7-F5-EB-4A-27-53-DA-A1-B2-4C-1B-27-58-BD-D4-1C-10-6B-70-E6-49-8E-B3-E0-1C-71-CF-6D-C3-C5-55-C3-03-EB-5B-0F-B7-89-25-66-07-1E-BC-59-FB-78-DA-73-CC-66-F3-10-87-75-C5-E9-12-17-22-B6-F1-0D-12-40-08-A2-20-01-44-43-18-62-20-21-24-82-C4-90-14-24-0D-C9-40-B2-90-1C-A4-07-B2-0F-92-87-EC-87-F4-42-0A-90-3E-48-11-D2-BF-44-72-00-32-00-91-65-12-0B-71-90-41-2D-43-90-83-90-12-64-04-52-1E-93-0A-64-34-2F-63-90-71-C8-61-C8-44-AF-4C-42-8E-C0-02-96-60-15-6C-00-AB-61-19-D6-C0-86-B0-11-6C-0C-9B-82-03-1C-C1-29-B8-00-4E-C3-31-9C-81-0B-E1-22-B8-18-2E-3D-ED-32-70-D9-11-20-56-43-F7-6E-CD-FA-93-A6-CF-CF-2D-94-2E-CE-5E-BA-7C-76-6E-E1-AE-AA-E7-D6-14-9A-A6-C5-57-36-28-20-BC-7A-24-58-3D-EE-53-4A-0D-F9-26-21-B9-EE-6E-1B-FC-5C-51-DB-8B-FE-FE-4D-99-92-81-B2-F7-FD-0A-31-98-58-71-C0-9A-39-CA-36-3E-D3-DA-4A-00-54-F1-E6-1A-D4-0E-1F-66-9F-1F-6D-CC-B4-BD-EB-1A-C9-BE-91-F7-F6-82-D4-0D-7A-7C-37-B9-4B-37-97-A9-35-95-98-5D-B5-7B-AC-16-35-29-13-A0-F3-A6-B8-63-57-13-F9-FD-3D-55-7B-DB-FD-C1-1E-A6-E9-AA-D2-26-F4-87-FE-1B-F6-8F-7A-36-8E-F5-4A-F2-6D-9D-44-73-BA-BB-D0-A0-06-FD-67-F9-93-28-0C-C2-5C-58-08-97-28-2C-EA-FE-30-AF-F0-23-28-99-29-2A-B2-D0-1D-8A-EA-A4-86-D1-E7-11-36-4A-69-45-41-02-1B-6F-C5-40-C6-97-0F-B6-BE-3C-55-98-C0-E4-2F-66-8A-76-40");
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
