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
        public Item Equipped { get; set; }
        public Clothing Clothes { get; set; }
        public int Exp { get; set; }

        public Character(string name, int gold, int maxHealth, Item equipped, Clothing clothes, int exp)
        {
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
