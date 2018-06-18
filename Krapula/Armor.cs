using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krapula
{
    //Riku
    class Armor:Item
    {
        public int DamageBlock { get; set; }
        public int Style { get; set; }
        public Armor(string name, int value, int damageBlock, int style) :base(name, value)
        {
            Random arm = new Random(1 - 5);
            DamageBlock = arm.Next();
            Style = arm.Next();

            Style = style;
            DamageBlock = damageBlock;
        }

        //Vaatteiden nimiä = 
    }
}
