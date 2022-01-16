using System;
using System.Diagnostics;

using LG.Barbarian.Core;
using LG.Barbarian.Traffic;

namespace LG.Barbarian.Network
{
    class Protocol
    {

        /// <summary>
        /// Follows the protocol.
        /// </summary>
        public static void Follow()
        {
            Program.Log("Minion's king has connected.", false);
            
            while (true)
            {
                byte[] Incoming = Protocol.Catch();
                int Identifier  = Packet.Identify(Incoming);

                #region Packets
                if (Identifier == ClientHello.Identifier)
                {
                    new ClientHello();
                }

                if (Identifier == NeedHelp.Identifier)
                {
                    new NeedHelp();
                }
                #endregion
                #region Commands
                if (Identifier == 14600)
                {
                    new RequestNewName(Incoming);
                }

                if (Identifier == 14102)
                {
                    new EndClient(Incoming);
                }

                if (Identifier == BattleNPC.Identifier)
                {
                    new BattleNPC();
                }

                if (Identifier == 14101)
                {
                    new GetHomeData();
                }
                #endregion
            }
        }

        /// <summary>
        /// Catches an incoming packet.
        /// </summary>
        public static byte[] Catch()
        {
            byte[] Draft = new byte[2048];
            int Length   = Gateway.Client.Receive(Draft);

            byte[] Packet = new byte[Length];
            Array.Copy(Draft, Packet, Length);

            byte[] Patched = Core.Packet.Patch(Packet, Gateway.Decrypter);
            Debug.WriteLine("[<] " + Core.Packet.Identify(Packet));
            return Patched;
        }

        /// <summary>
        /// Throws a specified packet.
        /// </summary>
        /// <param name="Packet"></param>
        public static void Throw(byte[] Packet)
        {
            Gateway.Client.Send(Packet);
            Debug.WriteLine("[>] " + Core.Packet.Identify(Packet));
        }
    }
}
