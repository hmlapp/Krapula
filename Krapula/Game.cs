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

        Dictionary<string, Func<string, string>> CommandList;

        public Game(string name)
        {
            player = new Player(name);
            currentArea = new Area();
            pastAreas = new List<Area>();
            IsPlayerAlive = true;
            IsPlayerTurn = true;

            CommandList = new Dictionary<string, Func<string, string>>();

            CommandList.Add("go", Go);
            //CommandList.Add("look", Look);
            //CommandList.Add("hit", Hit);
            //CommandList.Add("defend", Defend);
            //CommandList.Add("run", Run);
            //CommandList.Add("take", Take);
            //CommandList.Add("equip", Equip);
            //CommandList.Add("inventory", Inventory);
            //CommandList.Add("consume", Consume);
            //CommandList.Add("buy", Buy);
            //CommandList.Add("sell", Sell);
        }

        public void Turn()
        {
            // Await command if it is currently the players turn
            if (IsPlayerTurn)
            {
                Console.WriteLine(player.Health);
                Inventory();
                string readline = Console.ReadLine();
                string[] cmd = readline.Split(' ');
                if (!CommandList.ContainsKey(cmd[0]))
                {
                    Console.WriteLine("nope");

                }
                else 
                {
                    Console.WriteLine(CommandList[cmd[0]](cmd[1]));
                }
                
                IsPlayerTurn = false;
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

        public string Go(string direction)
        {
            // Go to new area
            if (currentArea.Direction.ContainsKey(direction))
            {
                int go = currentArea.Direction[direction];
                pastAreas.Add(currentArea);
                Area temp = currentArea;
                currentArea = currentArea.SurroundingAreas[go];
                if (go + 2 > 3)
                {
                    go -= 2;
                }
                else
                {
                    go += 2;
                }
                currentArea.SetArea(temp, go);
                return currentArea.Name;
            }
            else
            {
                return "Not a valid direction";
            }
        }
        public string Look()
        {
            // Look towards an (surrounding) area to get information on that area
            // Looking at item gives information on the item
            // Looking around at your current area tells you what you see (NPC/items/treasures...)
            // Looking at NPC gives information
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

        public string Run()
        {
            // Default return true
            // Run away from mörkö. Back to previous area
            // Mörkö can prevent your escape -> return false

            // return true;
            throw new NotImplementedException();
        }

        public string Inventory()
        {
            List<Item> foods = new List<Item>();
            List<Item> weapons = new List<Item>();
            List<Item> clothes = new List<Item>();


            if (player.Inventory.Count() == 0)
            {
                Console.WriteLine("Takataskusi ovat tyhjää täynnä. Ei edes nöyhtää!");
            }
            else
            {
                // Tells the player what items he/she has
                foreach (var item in player.Inventory)
                {
                    if (item.GetType() == (typeof(Food)))
                    {
                        foods.Add(item);
                    }
                    else if (item.GetType() == (typeof(Weapon)))
                    {
                        weapons.Add(item);
                    }
                    else if (item.GetType() == (typeof(Armor)))
                    {
                        clothes.Add(item);
                    }
                }


                Console.WriteLine();
                Console.WriteLine("Takataskussasi olevat ruoka-aineet:");
                foreach (var item in foods)
                {
                    Console.WriteLine(item.Name + " Arvo: " + item.Value);
                }
                Console.WriteLine();
                Console.WriteLine("Takataskussasi olevat aseet:");
                foreach (var item in weapons)
                {
                    Console.WriteLine(item.Name + " Arvo: " + item.Value);
                }
                Console.WriteLine();
                Console.WriteLine("Takataskussasi olevat kledjut:");
                foreach (var item in clothes)
                {
                    Console.WriteLine(item.Name + " Arvo: " + item.Value);
                }


            }   

            return "jou";
        }

        public string Consume()
        {
            //Console.WriteLine("Ahmit " Food.Name + "ja terveytesi parani: " + Food.Energy + "verran!");
            throw new NotImplementedException();
        }
        public string Drink()
        {
            //Console.WriteLine("Juotuasi: " Food.Name + " ja terveytesi parani: " + Food.Energy + "verran!");
            throw new NotImplementedException();
        }
        //if(Health != MaxHealth){
        //public override int Health
        //{
        //    //return Health + Food.Energy;
        //}
        //if(Food.Name == "ES"){
        ////return Equipped.Item.Weapon.Damage = Equipped.Item.Weapon.Damage* 2;

        public string Equip()
        {
            throw new NotImplementedException();
            //Console.WriteLine(Item.Name + " otettu käyttöön!");
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

        public void Take(Item item)
        {
            player.Inventory.Add(item);
            Console.WriteLine("Poimit eeppiset lootit ja takataskussai on nyt {0}", item);
        }
    }
}
