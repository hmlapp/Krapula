using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krapula
{
    public class Character
    {
        public string Name { get; set; }
        public int Gold { get; set; }
        public int Health { get; set; }
        public int MaxHealth { get; set; }
        public List<Item> Inventory { get; set; }
        public int Exp { get; set; }
        public bool Evil { get; set; }

        public Character(string name, int gold, int maxHealth, List<Item> inventory, int exp, bool evil)
        {
            Name = name;
            Gold = gold;
            Health = maxHealth;
            MaxHealth = maxHealth;
            Inventory = inventory;
            Exp = exp;
            Evil = evil;
        }
        //public void Equipped()
        //{
        //    Console.WriteLine(Item.Name+" otettu käyttöön!");
       // }
    }
}
