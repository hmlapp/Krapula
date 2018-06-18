using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krapula
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game("stuki");
            while (Game.IsPlayerAlive)
            {
                game.Turn();
            }
        }
    }
}
