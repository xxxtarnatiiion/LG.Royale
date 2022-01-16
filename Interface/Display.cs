using System;
using System.Drawing;

using Console = Colorful.Console;

namespace LG.Royale.Interface
{
    class Display
    {

        /// <summary>
        /// Loads the UI.
        /// </summary>
        public static void Load()
        {
            Console.Title = "[LG] Royale - © 2019";
            #region ASCII
            Console.WriteWithGradient(@"
                            __                     __      ______                              
                           / /   ____  ____  ___  / /_  __/ ____/___ _____ ___  ___  __________
                          / /   / __ \/ __ \/ _ \/ / / / / / __/ __ `/ __ `__ \/ _ \/ ___/ ___/
                         / /___/ /_/ / / / /  __/ / /_/ / /_/ / /_/ / / / / / /  __/ /  (__  ) 
                        /_____/\____/_/ /_/\___/_/\__, /\____/\__,_/_/ /_/ /_/\___/_/  /____/  
                                                 /____/                                        
            
            ", Color.Blue, Color.Magenta, 16);
            Console.ReplaceAllColorsWithDefaults();
            #endregion

            Display.Log("Our team isn't affiliated with Supercell, and won't ever be.", true);
            Display.Log("Our team doesn't own Clash Royale, Clash of Clans or else.", true);
            Display.Log("This work is protected by our policies, available nowhere.", true);
            Display.Log("Server 1.0 - Build 1.0 - Game 1.9", true);
            Display.Log(null);
        }

        /// <summary>
        /// Logs text on the console.
        /// </summary>
        /// <param name="Value"></param>
        public static void Log(string Value, bool Centered = false)
        {
            if (Value != null)
            {
                if (Centered)
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
                Console.WriteLine("");
            }
            
        }
    }
}
