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
            Health = health;
            Random food = new Random(DateTime.Now.Millisecond);
            Health = food.Next(1,6);
        } 
    }

    //public void eat()
    //{
    //    Console.WriteLine("Ahmit " Food.Name + "ja terveytesi parani: " + Food.Energy + "verran!");
    //}
    //public void drink()
    //{
    //    Console.WriteLine("Juotuasi: " Food.Name + " ja terveytesi parani: " + Food.Energy + "verran!");


    //}
    //if(Health != MaxHealth){
    //public override int Health
    //{
    //    return Health + Food.Energy;
    //}
    //if(Food.Name == "ES"){
    //return Equipped.Item.Weapon.Damage = Equipped.Item.Weapon.Damage* 2;

}
        

