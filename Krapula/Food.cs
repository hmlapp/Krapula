using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krapula
{
    //Nina
    class Food: Item
    {
        public int Health { get; set; }

        public Food(string name, int value, int health) : base(name, value)
        {
            Health = health;
            Random food = new Random();
            Health = food.Next(1,6);
        } 
    }
}
