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
        public NPC NPC;
        // New surrounding areas
        public List<Area> SurroundingAreas;
        public List<Item> Items;


        public Dictionary<string, int> Direction = new Dictionary<string, int>()
        {
            {"pohjoiseen", 0},
            {"itään", 1 },
            {"etelään", 2 },
            {"länteen", 3 }
        };

        public Area()
        {
            // Use area creator method to initialize surrounding areas
            Random rand = new Random();

            SurroundingAreas = new List<Area>();
            Items = new List<Item>();
            if (rand.Next() % 2 == 0)
            {
                Items.Add(new Food());
            }
            Name = Utilities.NameGenerator("places", "locations");
            NPC = new NPC();
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
