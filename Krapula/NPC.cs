using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krapula
{
    class NPC : Character
    {
        public bool Evil { get; set; }
        
        public Character(string name, int gold, int maxHealth, Item equipped, Clothing clothes, int exp, bool evil) : base(name, gold, maxHealth, equipped, clothes, exp)
        {
            Name = name;
            Gold = gold;
            Health = maxHealth;
            MaxHealth = maxHealth;
            Equipped = equipped;
            Clothes = clothes;
            Exp = exp;
            Evil = evil;
        }
    }
}
