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
        public Random rand;
        int turnsDefended;
        
        Dictionary<string, Func<string, string>> CommandList;

        public Game(string name)
        {
            player = new Player(name);
            currentArea = new Area();
            currentArea.SetArea();
            pastAreas = new List<Area>();
            IsPlayerAlive = true;
            IsPlayerTurn = true;
            rand = new Random();

            //Story.Beginning();

            Console.WriteLine(Story.TransportationGenerator(currentArea.Name));
            Console.WriteLine(Story.NPCGenerator(currentArea.NPC.Name));
            Console.WriteLine();
            Console.WriteLine();

            Console.OutputEncoding = Encoding.UTF8;

            CommandList = new Dictionary<string, Func<string, string>>();

            CommandList.Add("go", Go);
            CommandList.Add("look", Look);
            CommandList.Add("attack", Attack);
            CommandList.Add("defend", Defend);
            CommandList.Add("run", Run);
            CommandList.Add("take", Take);
            CommandList.Add("equip", Equip);
            //CommandList.Add("inventory", Inventory);
            //CommandList.Add("consume", Consume);
            //CommandList.Add("buy", Buy);
            //CommandList.Add("sell", Sell);
            CommandList.Add("help", Help);
        }

        public void Turn()
        {
            // Await command if it is currently the players turn
            if (IsPlayerTurn)
            {
                if (!player.IsDefending)
                {
                    turnsDefended = 0;
                }
                else
                {
                    if (turnsDefended > 1)
                    {
                        player.IsDefending = false;
                    }
                    else
                    {
                        turnsDefended++;
                    }
                }

                string readline = Console.ReadLine().ToLower();
                Console.WriteLine();
                string[] cmd = readline.Split(' ');
                switch (cmd.Length)
                {
                    case 0:
                        break;
                    case 1:
                        if (!CommandList.ContainsKey(cmd[0]))
                        {
                            Console.WriteLine("Not valid command. Type 'help' to get a list of available commands");
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.WriteLine(CommandList[cmd[0]](" "));
                        }
                        break;
                    default:
                        if (!CommandList.ContainsKey(cmd[0]))
                        {
                            Console.WriteLine("Not valid command. Type 'help' to get a list of available commands");
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.WriteLine(CommandList[cmd[0]](cmd[1]));
                        }
                        break;
                }
            }
            else
            {
                //if the enemy still exists, it executes an attack and then the turn is back to the player
                if (currentArea.NPC != null)
                {
                    Console.WriteLine(currentArea.NPC.Attack(player));
                    Console.WriteLine();

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
            if (currentArea.NPC != null)
            {
                IsPlayerTurn = false;
                return $"{Utilities.FirstCharToUpper(currentArea.NPC.Name)} ottaa sinut kiinni, ja hyökkää";
            }
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
                Console.Clear();
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(Story.TransportationGenerator(currentArea.Name));
                if (currentArea.NPC != null)
                {
                    sb.AppendLine(Story.NPCGenerator(currentArea.NPC.Name));
                }
                else
                {
                    sb.AppendLine("Tämä paikka näyttää tutulta ja tunnet olevasi turvassa");
                }
                sb.AppendLine();
                return sb.ToString();
            }
            else
            {
                return "Not a valid direction";
            }
        }
        public string Look(string item)
        {
            Console.Clear();
            StringBuilder sb = new StringBuilder();
            if (currentArea.NPC == null)
            {
                sb.AppendLine("Olet yksin alueella... Toistaiseksi");
                sb.AppendLine();
                switch ((float)player.Health / (float)player.MaxHealth)
                {
                    case 1:
                        sb.AppendLine("Voit hyvin"); // jotain parempaa pitäisi keksiä ;D
                        break;
                    case float i when i < 1.0f && i >= 0.5f:
                        sb.AppendLine("Alkaa väsyttää..."); // jotain parempaa pitäisi keksiä ;D
                        break;
                    case float i when i < 0.5f && i > 0.0f:
                        sb.AppendLine("Hirvee morkkis..."); // jotain parempaa pitäisi keksiä ;D
                        break;
                }
                sb.AppendLine();
                sb.AppendLine("Maasta löytyy: ");
                sb.AppendLine();
                foreach (Item i in currentArea.Items)
                {
                    sb.AppendLine("\t" + i.Name);
                }
                sb.AppendLine();
                sb.AppendLine("Pohjoisesta löydät " + currentArea.SurroundingAreas[0].Name.Split(' ')[0]);
                sb.AppendLine("Idästä löydät " + currentArea.SurroundingAreas[1].Name.Split(' ')[0]);
                sb.AppendLine("Etelästä löydät " + currentArea.SurroundingAreas[2].Name.Split(' ')[0]);
                sb.AppendLine("Lännestä löydät " + currentArea.SurroundingAreas[3].Name.Split(' ')[0]);
            }
            else
            {
                sb.AppendLine("Edessäsi seisoo " + currentArea.NPC.Name);

                switch ((float)currentArea.NPC.Health / (float)currentArea.NPC.MaxHealth)
                {
                    case 1:
                        sb.AppendLine("Näyttää voivan hyvin"); // jotain parempaa pitäisi keksiä ;D
                        break;
                    case float i when i < 1.0f && i >= 0.5f:
                        sb.AppendLine("Näyttäisi siltä että hän olisi vähän väsynyt"); // jotain parempaa pitäisi keksiä ;D
                        break;
                    case float i when i < 0.5f && i > 0.0f:
                        sb.AppendLine("Hän pelkää sinua"); // jotain parempaa pitäisi keksiä ;D
                        break;
                }

                sb.AppendLine();
                sb.AppendLine("Pohjoisesta löydät " + currentArea.SurroundingAreas[0].Name.Split(' ')[0]);
                sb.AppendLine("Idästä löydät " + currentArea.SurroundingAreas[1].Name.Split(' ')[0]);
                sb.AppendLine("Etelästä löydät " + currentArea.SurroundingAreas[2].Name.Split(' ')[0]);
                sb.AppendLine("Lännestä löydät " + currentArea.SurroundingAreas[3].Name.Split(' ')[0]);

                IsPlayerTurn = false;
            }
            return sb.ToString();
            // Look towards an (surrounding) area to get information on that area
            // Looking at item gives information on the item
            // Looking around at your current area tells you what you see (NPC/items/treasures...)
            // Looking at NPC gives information
            //throw new NotImplementedException();
        }
        public string Attack(string ok)
        {
            Console.Clear();
            if (currentArea.NPC == null)
            {
                return "nothing to hit";
            }

            int damage = rand.Next(player.WeaponEquipped.MaxDamage - player.WeaponEquipped.MinDamage);
            damage += player.WeaponEquipped.MinDamage;
            damage -= currentArea.NPC.ClothesEquipped.DamageBlock;
            
            if (damage < 0)
            {
                damage = 0;
            }

            currentArea.NPC.Health -= damage;
            if (currentArea.NPC.Health <= 0)
            {
                foreach (Item item in currentArea.NPC.Dead())
                {
                    currentArea.Items.Add(item);
                }
                player.Exp += currentArea.NPC.Exp;
                player.Gold += currentArea.NPC.Gold;
                currentArea.NPC = null;
                return "he ded and dropped his items";
            }
            IsPlayerTurn = false;
            return "you hit the mörkö for " + damage + " damage";

        }
        public string Defend(string ok)
        {
            player.IsDefending = true;
            IsPlayerTurn = false;
            return "Puolustat";
        }
        public string Run(string ok)
        {
            StringBuilder sb = new StringBuilder();
            if (pastAreas.Count > 0)
            {
                sb.AppendLine($"Pakenit turvaan, takaisin {pastAreas.Last().Name}!");

                if (rand.Next() % 3 == 0)
                {
                    sb.AppendLine($"Pakenessasi {currentArea.NPC.Name} hyökkäsi!");
                    sb.AppendLine(currentArea.NPC.Attack(player));
                }

                currentArea = pastAreas.Last();
            }
            else
            {
                sb.AppendLine($"Et tiedä mihin pakenisit, ja panikoit. {Utilities.FirstCharToUpper(currentArea.NPC.Name)} käytti paniikkiasi hyödyksi ja hyökkäsi!");
                IsPlayerTurn = false;
            }
            
            return sb.ToString();
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
            if (match?.GetType() == typeof(Weapon))
            {
                player.Inventory.Add(player.WeaponEquipped);
                player.WeaponEquipped = (Weapon)match;
                player.Inventory.Remove(match);

                IsPlayerTurn = false;

                return "you equipped the weapon";
            }

            else if (match?.GetType() == typeof(Armor))
            {
                player.Inventory.Add(player.ClothesEquipped);
                player.ClothesEquipped = (Armor)match;
                player.Inventory.Remove(match);

                IsPlayerTurn = false;

                return "you equipped the armor";
            }
            else
            {
                return "That doesn't make any sense";
            }
        }

        public string Inventory()
        {
            List<Food> foods = new List<Food>();
            List<Weapon> weapons = new List<Weapon>();
            List<Armor> clothes = new List<Armor>();

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
                        foods.Add((Food)item);
                    }
                    else if (item.GetType() == (typeof(Weapon)))
                    {
                        weapons.Add((Weapon)item);
                    }
                    else if (item.GetType() == (typeof(Armor)))
                    {
                        clothes.Add((Armor)item);
                    }
                }
                Console.WriteLine();
                Console.WriteLine("{0, -15} {1,15} {2, 15} {3, 15}", "Kledju:", "Vahingoensto:", "Arvo:", "Tyylipisteet:");
                for (int i = 0; i < clothes.Count(); i++)
                {
                    Console.WriteLine("{0,-15} {1,15} {2, 15} {3, 15}", clothes[i].Name, clothes[i].DamageBlock, clothes[i].Value + "€", "2");
                }
                Console.WriteLine();
                Console.WriteLine("Takataskussasi olevat tavarat:");
                Console.WriteLine("{0, -15} {1, 15} {2, 15}", "Ruoka:", "Energia:", "Arvo:");
                for (int i = 0; i < foods.Count(); i++)
                {
                    Console.WriteLine("{0,-15} {1,15} {2, 15}", foods[i].Name, foods[i].Energy, foods[i].Value + "€");
                }
                Console.WriteLine();
                Console.WriteLine("{0, -15} {1,15}", "Ase:", "Vahinko:");
                for (int i = 0; i < weapons.Count(); i++)
                {
                    Console.WriteLine("{0,-15} {1,15}", weapons[i].Name, weapons[i].MaxDamage);
                }
            }
            return "Inventaario tehty";
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
        public string Help(string ok)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine();
            sb.Append("Available commands: ");
            foreach (KeyValuePair<string, Func<string, string>> entry in CommandList)
            {
                sb.Append(entry.Key + ", ");
            }

            sb.Remove(sb.Length - 2, 2);
            return sb.ToString();
        }


    }
}
