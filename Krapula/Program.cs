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
            Alku:
            Game game = new Game(Story.Beginning());
            while (Game.IsPlayerAlive)
            {
                game.Turn();

            }
        }   
    }
}
