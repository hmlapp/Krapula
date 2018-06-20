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
        public Random rand;
        
        public NPC() : base()
        {
            rand = new Random();
            Name = Utilities.NameGenerator("adjectives", "professions", "names");
            Gold = rand.Next(100);
            MaxHealth = rand.Next(30);
            Health = MaxHealth;
            WeaponEquipped = new Weapon();
            ClothesEquipped = new Armor();
            Exp = rand.Next(100);
            Evil = true;
        }

        public string Attack(Player player)
        {
            int damage = rand.Next(WeaponEquipped.MaxDamage - WeaponEquipped.MinDamage);
            damage += WeaponEquipped.MinDamage;
            int block = player.ClothesEquipped.DamageBlock;

            if (player.IsDefending)
            {
                block *= 2;
            }

            damage -= block;

            if (damage < 0)
            {
                damage = 0;
            }

            player.Health -= damage;
            return Utilities.FirstCharToUpper(Name) + " hyökkäsi ja aiheutti " + damage + " vahinkoa";
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
