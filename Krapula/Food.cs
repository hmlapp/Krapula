using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krapula
{
    
    class Food : Item
    {
        public int Energy { get; set; }
        
        public Food(string name, int value, int health) : base(name)
        {
            Energy = health;
            Random food = new Random(DateTime.Now.Millisecond);
            Energy = food.Next(1, 6);
        } 
    }
}
        

