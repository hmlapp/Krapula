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

        public Player(string name, int gold, int maxHealth, Item equipped, Clothing clothes, int exp) 
            : base(name, gold, maxHealth, equipped, clothes, exp)
        {
            Inventory = new List<Item>();
            Name = name;
            Gold = gold;
            Health = maxHealth;
            MaxHealth = maxHealth;
            Equipped = equipped;
            Clothes = clothes;
            Exp = exp;
        }
    }
}
