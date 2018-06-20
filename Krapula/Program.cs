using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krapula
{
    class Program
    {
        static void Main()
        {
            Console.WindowHeight = 36;
            Console.BufferHeight = 36;
            Console.WindowWidth = 120;
            Console.BufferWidth = 120;

            Console.OutputEncoding = Encoding.UTF8;

            Game game = new Game(Story.Beginning());

            while (Game.IsPlayerAlive)
            {
                game.Turn();
            }

            if (Game.Restart)
            {
                Console.Clear();
                Main();
            }
        }   
    }
}
