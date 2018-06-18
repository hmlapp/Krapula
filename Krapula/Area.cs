/* Ville 
 Direction class defines the directions a player can move towards. Choosing a direction will move 
 the player to a new area
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Krapula
{
    class Area
    {
        // Current area name
        public string AreaName { get; set; }

        // Current area NPC is a Character class
        Character areaNPC = new Character();

        // New surrounding areas
        List<object> surroundingAreas = new List<object>();

        Dictionary<string, int> newArea = new Dictionary<string, int>()
        {
            {"north", 0},
            {"east", 1 },
            {"south", 2 },
            {"west", 3 }
        };

        public Area(string areaName)
        {
            // Use area creator method to initialize surrounding areas

            AreaName = areaName;
        }


    }
}
