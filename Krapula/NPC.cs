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
        
        public NPC(string name, int gold, int maxHealth, Item equipped, Armor clothes, int exp, bool evil) : base(name)
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
