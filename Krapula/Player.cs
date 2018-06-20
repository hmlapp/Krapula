using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krapula
{
    public class Player : Character
    {
        public List<Item> Inventory { get; set; }

        public Player(string name) : base(name)
        {
            Inventory = new List<Item>() { new Weapon("Mora"), new Weapon("kola"), new Armor("mekko"), new Food("muikku", 2, 4) };
            Name = name;
            Gold = 0;
            Health = 20;
            MaxHealth = 20;
            WeaponEquipped = new Weapon("Moottorisaha");
            ClothesEquipped = new Armor("H&M Pillihuosut");
            Exp = 0;
        }
    }
}
