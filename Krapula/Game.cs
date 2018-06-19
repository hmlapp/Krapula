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
        public static bool IsPlayerAlive;
        public static bool IsPlayerTurn;
        
        public Game(string name)
        {
            player = new Player(name);
            currentArea = new Area("Sörkän alepa");
            IsPlayerAlive = true;
        }

        Dictionary<string, Func<string>> CommandList = new Dictionary<string, Func<string>>();

        public void Turn()
        {
            // Await command if it is currently the players turn
            if (IsPlayerTurn)
            {
                string cmd = Console.ReadLine();
                Console.WriteLine(cmd.Split(' ')[0]);
                IsPlayerTurn = false;
            }
            else
            {
                //if the enemy still exists, it executes an attack and then the turn is back to the player
                if (currentArea.AreaNPC != null)
                { 
                    //currentArea.AreaNPC.Attack(player);

                    if (player.Health <= 0)
                    {
                        IsPlayerAlive = false;
                    }

                    IsPlayerTurn = true;
                }

                IsPlayerTurn = true;
            }
        }
    }
}
