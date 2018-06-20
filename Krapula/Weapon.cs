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
        public int MaxDamage { get; set; }
        public int MinDamage { get; set; }
        public int Durability { get; set; }

        public Weapon() : base()
        {
            Random rnd = new Random(DateTime.Now.Millisecond);

            Name = Utilities.RandomStringFrom("weapons");
            MaxDamage = rnd.Next(2, 10);
            MinDamage = rnd.Next(2, MaxDamage);
            Durability = rnd.Next(10);
        }
    }
}
