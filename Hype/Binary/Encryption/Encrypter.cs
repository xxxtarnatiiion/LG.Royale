using System;
using System.Collections;
using System.Collections.Generic;

using System.Linq;

namespace LG.Royale.Hype
{
    class Encrypter
    {

        /// Author:
        /// https://github.com/BerkanYildiz/

        /// <summary>
        /// Encrypter's bytes.
        /// </summary>
        private byte I;
        private byte J;

        /// <summary>
        /// Encrypter's key.
        /// </summary>
        private byte[] Key;

        /// <summary>
        /// Encrypter's new instance.
        /// </summary>
        public Encrypter()
        {
            this.InitState("fhsd6f86f67rt8fw78fw789we78r9789wer6re", "nonce");
        }

        /// <summary>
        /// Initializes the encrypter.
        /// </summary>
        /// <param name="Key"></param>
        /// <param name="Nonce"></param>
        private void InitState(string Key, string Nonce)
        {
            string Rc4Key = Key + Nonce;

            this.I = 0;
            this.J = 0;
            this.Key = new byte[256];

            for (int K = 0; K < 256; K++)
            {
                this.Key[K] = (byte)K;
            }

            byte J = 0;
            byte SwapTemp;

            for (int K = 0; K < 256; K++)
            {
                J = (byte)((J + this.Key[K] + Rc4Key[K % Rc4Key.Length]) % 256);

                SwapTemp = this.Key[K];
                this.Key[K] = this.Key[J];
                this.Key[J] = SwapTemp;
            }

            for (int K = Rc4Key.Length; K > 0; K--)
            {
                this.I = (byte)(this.I + 1);
                this.J = (byte)(this.J + this.Key[this.I]);

                SwapTemp = this.Key[this.I];

                this.Key[this.I] = this.Key[this.J];
                this.Key[this.J] = SwapTemp;
            }
        }

        /// <summary>
        /// Decrypts the specified packet.
        /// </summary>
        /// <param name="Packet"></param>
        /// <returns></returns>
        public byte[] Decrypt(byte[] Packet)
        {
            if (Packet.Length > 0)
            {
                for (int K = 0; K < Packet.Length; K++)
                {
                    this.I = (byte)(this.I + 1);
                    this.J = (byte)(this.J + this.Key[this.I]);

                    byte SwapTemp = this.Key[this.I];

                    this.Key[this.I] = this.Key[this.J];
                    this.Key[this.J] = SwapTemp;

                    Packet[K] ^= this.Key[(this.Key[this.I] + this.Key[this.J]) % 256];
                }
            }

            return Packet;
        }

        /// <summary>
        /// Encrypts the specified packet.
        /// </summary>
        /// <param name="Packet"></param>
        /// <returns></returns>
        public byte[] Encrypt(byte[] Packet)
        {
            if (Packet.Length > 0)
            {
                for (int K = 0; K < Packet.Length; K++)
                {
                    this.I = (byte)(this.I + 1);
                    this.J = (byte)(this.J + this.Key[this.I]);

                    byte SwapTemp = this.Key[this.I];

                    this.Key[this.I] = this.Key[this.J];
                    this.Key[this.J] = SwapTemp;

                    Packet[K] ^= this.Key[(this.Key[this.I] + this.Key[this.J]) % 256];
                }
            }

            return Packet;
        }

        /// <summary>
        /// Processes the specified packet.
        /// </summary>
        /// <param name="Packet"></param>
        /// <param name="Encrypter"></param>
        /// <returns></returns>
        public byte[] Process(byte[] Packet, Encrypter Encrypter)
        {
            List<byte> Header    = new List<byte>(Packet.Take(7).Reverse());
            List<byte> Processed = new List<byte>(Encrypter.Decrypt(Packet.Skip(7).ToArray()));

            foreach (byte Byte in Header)
            {
                Processed.Insert(0, Byte);
            }

            return Processed.ToArray();
        }
    }
}
