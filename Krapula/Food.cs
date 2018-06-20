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
        
        public Food() : base()
        {
            Name = Utilities.RandomStringFrom("food");
            Random rand = new Random(DateTime.Now.Millisecond);
            Energy = rand.Next(1, 6);
            Value = Energy * 10;
        } 
    }
}
        

