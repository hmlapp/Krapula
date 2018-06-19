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
        
        public NPC(string name, int gold, int maxHealth, Weapon equipped, Armor clothes, int exp, bool evil) : base(name)
        {
            Name = name;
            Gold = gold;
            Health = maxHealth;
            MaxHealth = maxHealth;
            WeaponEquipped = equipped;
            ClothesEquipped = clothes;
            Exp = exp;
            Evil = evil;
        }

        public string Attack(Player player)
        {
            player.Health -= WeaponEquipped.Damage;
            return Name + " hyökkäsi ja aiheutti " + WeaponEquipped.Damage + " vahinkoa";
        }

        public List<Item> Dead()
        {
            if (Health <= 0)
            {
                return new List<Item> { WeaponEquipped, ClothesEquipped };
            }
            else
            {
                return new List<Item>();
            }
        }
    }
}
