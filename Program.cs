using System;
using System.Net;
using System.Net.Sockets;

using System.Drawing;

using Console = Colorful.Console;

using LG.Barbarian.Network;

namespace LG.Barbarian
{
    class Program
    {

        /// <summary>
        /// Application's entry point.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.Title = "[LG] Barbarian - © " + DateTime.Now.Year;

            #region ASCII
            Console.WriteWithGradient(
                @"
                                    ____             __               _           
                                   / __ )____ ______/ /_  ____ ______(_)___ _____ 
                                  / __  / __ `/ ___/ __ \/ __ `/ ___/ / __ `/ __ \
                                 / /_/ / /_/ / /  / /_/ / /_/ / /  / / /_/ / / / /
                                /_____/\__,_/_/  /_.___/\__,_/_/  /_/\__,_/_/ /_/ 
                        

                ", Color.Blue, Color.Magenta);
            #endregion

            Program.Log("LonelyGamers isn't affiliated with Supercell, and it won't ever be.");
            Program.Log("LonelyGamers does not own Clash Royale, Clash of Clans or anything.");
            Program.Log("Barbarian has been initialized, packets have been stored in memory.");
            Program.Log("Barbarian 1.0 - Build 1.0 - Game 1.9");
            Program.Log(null);

            Gateway.Start(IPAddress.Any, 9339);
        }

        /// <summary>
        /// Logs text on the console.
        /// </summary>
        /// <param name="Value"></param>
        /// <param name="IsCentered"></param>
        public static void Log(string Value, bool IsCentered = true)
        {
            if (Value != null)
            {
                if (IsCentered)
                {
                    Console.SetCursorPosition((Console.WindowWidth - Value.Length) / 2, Console.CursorTop);
                    Console.WriteLine(Value);
                }

                else
                {
                    Console.WriteLine(" [{0}] {1}", DateTime.Now.ToShortTimeString(), Value);
                }
            }

            else
            {
                Console.WriteLine();
            }    
        }
    }
}
