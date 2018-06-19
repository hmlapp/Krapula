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
            currentArea.SetArea();
            Console.WriteLine(currentArea.Name);
            pastAreas = new List<Area>();
            IsPlayerAlive = true;
            IsPlayerTurn = true;

            string Pl;
            string Pl2;
            Pl = Story.TransportationGenerator("movingaround");
            Pl2 = Story.NPCnGenerator("seeingthings");
            Console.WriteLine(Pl + " " + currentArea.Name);
            Console.WriteLine();
            Console.WriteLine(Pl2);
            Console.WriteLine(currentArea.AreaNPC.Name);

            Console.OutputEncoding = Encoding.UTF8;

            CommandList = new Dictionary<string, Func<string, string>>();

            CommandList.Add("go", Go);
            //CommandList.Add("look", Look);
            CommandList.Add("hit", Hit);
            //CommandList.Add("defend", Defend);
            //CommandList.Add("run", Run);
            CommandList.Add("take", Take);
            CommandList.Add("equip", Equip);
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
                        Console.WriteLine($"You got {player.Exp} points! Wow!");
                    }
                }

                IsPlayerTurn = true;
            }
        }

        public string Go(string direction)
        {
            // Go to new area
            if (currentArea.Direction.ContainsKey(direction))
            {
                int dir = currentArea.Direction[direction];
                pastAreas.Add(currentArea);
                Area temp = currentArea;
                currentArea = currentArea.SurroundingAreas[dir];
                if (dir + 2 > 3)
                {
                    dir -= 2;
                }
                else
                {
                    dir += 2;
                }
                currentArea.SetArea(temp, dir);
                return currentArea.Name;
            }
            else
            {
                return "Not a valid direction";
            }
        }
        public string Look(string item)
        {
            if (currentArea.Direction.ContainsKey(item))
            {
                int dir = currentArea.Direction[item];
                return currentArea.SurroundingAreas[dir].Name;
            }
            // Look towards an (surrounding) area to get information on that area
            // Looking at item gives information on the item
            // Looking around at your current area tells you what you see (NPC/items/treasures...)
            // Looking at NPC gives information
            throw new NotImplementedException();
        }
        public string Hit(string ok)
        {
            if (currentArea.AreaNPC == null)
            {
                return "nothing to hit";
            }
            currentArea.AreaNPC.Health -= player.WeaponEquipped.Damage;
            if (currentArea.AreaNPC.Health <= 0)
            {
                currentArea.Items = currentArea.AreaNPC.Dead();
                player.Exp += currentArea.AreaNPC.Exp;
                currentArea.AreaNPC = null;
                return "he ded and dropped his items";
            }
            IsPlayerTurn = false;
            return "you hit the mörkö for " + player.WeaponEquipped.Damage + " damage";
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

        private string Take(string name)
        {
            Item match = currentArea.Items.Where(item => item.Name.ToLower() == name.ToLower()).FirstOrDefault();
            if (match != null)
            {
                player.Inventory.Add(match);
                return "you pick up the item";
            }
            else
            {
                return "there is no item like that";
            }
        }

        public string Equip(string name)
        {
            Item match = player.Inventory.Where(item => item.Name.ToLower() == name.ToLower()).FirstOrDefault();
            Console.WriteLine(match.GetType());
            if (match.GetType() == typeof(Weapon))
            {
                player.Inventory.Add(player.WeaponEquipped);
                player.WeaponEquipped = (Weapon)match;
                player.Inventory.Remove(match);

                return "you equipped the weapon";
            }
            else if (match.GetType() == typeof(Armor))
            {
                player.Inventory.Add(player.ClothesEquipped);
                player.ClothesEquipped = (Armor)match;
                player.Inventory.Remove(match);

                return "you equipped the armor";
            }
            else
            {
                return "That doesn't make any sense";
            }
            //Console.WriteLine(Item.Name + " otettu käyttöön!");
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
