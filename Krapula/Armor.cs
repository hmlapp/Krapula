using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krapula
{
    //Riku
    public class Armor : Item
    {
        public int DamageBlock { get; set; }
        public int Style { get; set; }
        public Armor() : base()
        {
            Random rand = new Random(DateTime.Now.Millisecond);
            Name = Utilities.RandomStringFrom("clothes");
            DamageBlock = rand.Next(5);
            Style = rand.Next(10);
            Value = (int)(DamageBlock * Style * rand.Next(50,55));
        }
    }
}
