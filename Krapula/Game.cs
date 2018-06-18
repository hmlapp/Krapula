using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krapula
{
    class Game
    {
        public Player player;
        public Area currentArea;
        
        public Game(string name)
        {
            player = new Player(name);
            currentArea = new Area("Sörkän alepa");
        }
    }
}
