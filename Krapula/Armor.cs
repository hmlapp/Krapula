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
        public Armor(string name) :base(name)
        {
            Random arm = new Random(DateTime.Now.Millisecond);
            DamageBlock = arm.Next(1,5);
            Style = arm.Next(1,5);
        }
    }
}
