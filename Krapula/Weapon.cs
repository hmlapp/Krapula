using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krapula
{
    //Riku
    public class Weapon : Item
    {
        public int Damage { get; set; }
        public int Durability { get; set; }

        public Weapon() : base()
        {
            Random rnd = new Random(DateTime.Now.Millisecond);

            Name = Utilities.RandomStringFrom("weapons.txt");
            Damage = rnd.Next(1,10);
            Durability = rnd.Next(1,10);
        }
    }
}
