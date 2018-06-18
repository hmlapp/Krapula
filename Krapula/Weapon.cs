using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krapula
{
    //Riku
    class Weapon : Item
    {
        public int Damage { get; set; }
        public int Durability { get; set; }


        public Weapon(string name, int value, int damage, int durability) : base(name, value)
        {


            Random rnd = new Random();
            Damage = rnd.Next(1, 11);
            Durability = rnd.Next(1, 11);

            Damage = damage;
            Durability = durability;
        }

        //public void hit()
        //{
        //    Console.WriteLine("Tehty vahinkoa" + (Damage-Armor.DamageBlock + "pistettä");

        //}

        //public override int Health
        //{
        //    return Health - (BaseDamage? +Weapon.damage - Armor.damageBlock );
        //}

    }
}
