using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krapula
{
    class Game
    {
        public Player player;
        public Area currentArea;
        public List<Area> pastAreas;
        public static bool IsPlayerAlive;
        public static bool IsPlayerTurn;

        Dictionary<string, Func<string>> CommandList;

        public Game(string name)
        {
            player = new Player(name);
            currentArea = new Area();
            currentArea.SetArea();
            Console.WriteLine(currentArea.Name);
            pastAreas = new List<Area>();
            IsPlayerAlive = true;
            IsPlayerTurn = true;

            CommandList = new Dictionary<string, Func<string>>();

            CommandList.Add("go", Go);
            CommandList.Add("look", Look);
            CommandList.Add("hit", Hit);
            CommandList.Add("defend", Defend);
            CommandList.Add("run", Run);
            CommandList.Add("take", Take);
            CommandList.Add("equip", Equip);
            CommandList.Add("inventory", Inventory);
            CommandList.Add("consume", Consume);
            CommandList.Add("buy", Buy);
            CommandList.Add("sell", Sell);
        }

        public void Turn()
        {
            // Await command if it is currently the players turn
            if (IsPlayerTurn)
            {
                Console.WriteLine(player.Health);
                string readline = Console.ReadLine();
                string[] cmd = readline.Split(' ');
                if (!CommandList.ContainsKey(cmd[0]))
                {
                    Console.WriteLine("nope");

                }
                else 
                {
                    Console.WriteLine(CommandList[cmd[0]]());
                }
            }
            else
            {
                //if the enemy still exists, it executes an attack and then the turn is back to the player
                if (currentArea.AreaNPC != null)
                { 
                    currentArea.AreaNPC.Attack(player);

                    if (player.Health <= 0)
                    {
                        IsPlayerAlive = false;
                    }

                    IsPlayerTurn = true;
                }

                IsPlayerTurn = true;
            }
        }

        public string Go()
        {
            // Go to new area
            pastAreas.Add(currentArea);
            Area temp = currentArea;
            currentArea = currentArea.SurroundingAreas[1];
            currentArea.SetArea(temp, 1);
            return currentArea.Name;
        }
        public string Look()
        {
            // Look towards an (surrounding) area to get information on that area
            // Looking at item gives information on the item
            // Looking around at your current area tells you what you see (NPC/items/treasures...)
            // Looking at NPC gives information
            throw new NotImplementedException();
        }
        public string Hit()
        {
            if (currentArea.AreaNPC == null)
            {
                return "nothing to hit";
            }
            currentArea.AreaNPC.Health -= player.Equipped.Damage;
            if (currentArea.AreaNPC.Health <= 0)
            {
                currentArea.AreaNPC = null;
                return "he ded";
            }
            IsPlayerTurn = false;
            return "you hit the mörkö for " + player.Equipped.Damage + " damage";
            //Console.WriteLine("Tehty vahinkoa" + (Damage - Armor.DamageBlock + "pistettä");

        }
        public string Defend()
        {
            throw new NotImplementedException();
            //Nostaa armorin määrän 2x 3 vuoroksi

            //return Equipped.Item.Armor.DamageBlock = Equipped.Item.Armor.DamageBlock* 2; 
            //        Durability = 3;
        }
        public string Run()
        {
            // Default return true
            // Run away from mörkö. Back to previous area
            // Mörkö can prevent your escape -> return false

            // return true;
            throw new NotImplementedException();
        }

        private string Take()
        {
            throw new NotImplementedException();
        }

        public string Equip()
        {
            throw new NotImplementedException();
            //Console.WriteLine(Item.Name + " otettu käyttöön!");
        }

        public string Inventory()
        {
            // Tells the player what items he/she has
            throw new NotImplementedException();

        }
        public string Consume()
        {
            //Console.WriteLine("Ahmit " Food.Name + "ja terveytesi parani: " + Food.Energy + "verran!");
            throw new NotImplementedException();
        }
        public string Buy()
        {
            // Buy target item
            // Reduce player's money total by the value of item
            // Add item to player's inventory
            // Remove item from NPC inventory

            //return item;
            throw new NotImplementedException();
        }
        public string Sell()
        {
            // Sell target item
            // Add money to player's money total
            // Remove item from player inventory
            // Add item to NPC inventory
            throw new NotImplementedException();
        }
        //if(Health != MaxHealth){
        //public override int Health
        //{
        //    //return Health + Food.Energy;
        //}
        //if(Food.Name == "ES"){
        ////return Equipped.Item.Weapon.Damage = Equipped.Item.Weapon.Damage* 2;


    }
}
