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
            StringBuilder sb = new StringBuilder();
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

            sb.AppendLine(Utilities.FirstCharToUpper(Name) + " hyökkäsi ja aiheutti " + damage + " vahinkoa").AppendLine();
            sb.AppendLine("Aiotko kääntää toista poskea, tai tehdä jotain?");
            return sb.ToString();
        }

        public List<Item> Dead()
        {
            return new List<Item> { WeaponEquipped, ClothesEquipped };
        }
    }
}
