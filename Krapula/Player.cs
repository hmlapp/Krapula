using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krapula
{
    public class Player : Character
    {
        public List<Item> Inventory { get; set; }

        public Player(string name) : base(name)
        {
            Inventory = new List<Item>();
            Name = name;
            Gold = 0;
            Health = 20;
            MaxHealth = 20;
            Equipped = new Weapon("Moottorisaha");
            Clothes = new Armor("H&M Pillihuosut");
            Exp = 0;
        }
    }
}
