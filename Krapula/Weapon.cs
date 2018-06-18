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


        public Weapon(string name, int value, int damage, int durability) :base(name, value)
        {
            

            Random rnd = new Random(1 - 10);
            Damage = rnd.Next();
            Durability = rnd.Next();

            Damage = damage;
            Durability = durability;
        }

        //public void Attack()
        //{
        //    Console.WriteLine("Tehty vahinkoa" + Damage + "pistettä" );
        //}

        
    }
}
