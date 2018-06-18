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
            Random arm = new Random();
            DamageBlock = arm.Next(1, 6);
            Style = arm.Next(1, 3);

            Style = style;
            DamageBlock = damageBlock;
        }
    //    public defend{
    //    //Nostaa armorin määrän 2x 3 vuoroksi

    //return Equipped.Item.Armor.DamageBlock = Equipped.Item.Armor.DamageBlock * 2; 
    //        Durability = 3;
    //}
    //Vaatteiden nimiä = 
}
}
