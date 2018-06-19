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
        public Weapon WeaponEquipped { get; set; }
        public Armor ClothesEquipped { get; set; }
        public int Exp { get; set; }

        public Character(string name)
        {
            Random rand = new Random(DateTime.Now.Millisecond);
            Name = name;
            Gold = rand.Next(0,100);
            MaxHealth = rand.Next(0, 100);
            Health = MaxHealth;
            WeaponEquipped = new Weapon("Moi");
            ClothesEquipped = new Armor("tere");
            Exp = rand.Next(0, 100);
        }
    }
}
