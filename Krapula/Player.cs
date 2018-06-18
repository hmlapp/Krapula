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
            Inventory = new List<Item>();
            Name = name;
            Gold = 0;
            Health = 20;
            MaxHealth = 20;
            Equipped = new Weapon("Moottorisaha");
            Clothes = new Armor("H&M Pillihuosut");
            Exp = 0;
        }

        //public string Look(currentArea)
        //{
        //    // Look towards an (surrounding) area to get information on that area
        //    // Looking at item gives information on the item
        //    // Looking around at your current area tells you what you see (NPC/items/treasures...)
        //    // Looking at NPC gives information
        //    throw new NotImplementedException();
        //}

        //public Item Buy()
        //{
        //    // Buy target item
        //    // Reduce player's money total by the value of item
        //    // Add item to player's inventory
        //    // Remove item from NPC inventory

        //    //return item;
        //    throw new NotImplementedException();
        //}
        //public void Sell(Item)
        //{
        //    // Sell target item
        //    // Add money to player's money total
        //    // Remove item from player inventory
        //    // Add item to NPC inventory
        //    throw new NotImplementedException();
        //}

        //public bool Run()
        //{
        //    // Default return true
        //    // Run away from mörkö. Back to previous area
        //    // Mörkö can prevent your escape -> return false

        //    // return true;
        //    throw new NotImplementedException();
        //}
        //public void Go(direction)
        //{
        //    // Go to new area
        //    throw new NotImplementedException();
        //}

        //public string Inventory()
        //{
        //    // Tells the player what items he/she has
        //    throw new NotImplementedException();

        //}
        

    }
}
