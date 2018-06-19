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
        public string CharacterName { get; set; }

        // Current area NPC is a Character class
        public NPC AreaNPC;

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

            //AreaName = areaName;

            AreaName = Utilities.NameGenerator("places", "locations");
            CharacterName = Utilities.NameGenerator("adjectives", "professions", "names");
            AreaNPC = new NPC(CharacterName, 20, 10, new Weapon("Smurffi"), new Armor("Nahkatakki"), 20, true);
            Console.WriteLine("Area: " + AreaName);
            Console.WriteLine("Char: " + CharacterName);
        }

        


    }
}
