using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krapula
{//Riku ja Nina
    public class Item
    {
        public string Name { get; set; }
        public int Value { get; set; }

        public Item(string name)
        {
            Random r = new Random(DateTime.Now.Millisecond);
            Value = r.Next(1,1000);
            Name = name;
        }

    }
}
