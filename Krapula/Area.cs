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
        public string Name { get; set; }
        // Area's character name
        public string CharacterName { get; set; }

        // Current area NPC is a Character class
        public NPC AreaNPC;
        // New surrounding areas
        public List<Area> SurroundingAreas;
        public List<Item> Items;


        public Dictionary<string, int> Direction = new Dictionary<string, int>()
        {
            {"north", 0},
            {"east", 1 },
            {"south", 2 },
            {"west", 3 }
        };

        public Area()
        {
            // Use area creator method to initialize surrounding areas
            SurroundingAreas = new List<Area>();
            Name = Utilities.NameGenerator("places", "locations");
            CharacterName = Utilities.NameGenerator("adjectives", "professions", "names");
            AreaNPC = new NPC(CharacterName, 20, 10, new Weapon("Smurffi"), new Armor("Nahkatakki"), 20, true);
            //Console.WriteLine("Area: " + Name);
            //Console.WriteLine("Char: " + CharacterName);
        }

        public void SetArea()
        {
            // Maximum possible directions of movement
            int possibleDirections = 4;
            for (int i = 0; i < possibleDirections; i++)
            {
                SurroundingAreas.Add(new Area());   
            }
        }
        // Overload to add previous area to the list
        public void SetArea(Area oldArea, int direction)
        {
            int possibleDirections = 4;
            for (int i = 0; i < possibleDirections; i++)
            {
                if (i == direction)
                {
                    SurroundingAreas.Add(oldArea);
                }
                else
                {
                    SurroundingAreas.Add(new Area());
                }
            }
        }


    }
}
