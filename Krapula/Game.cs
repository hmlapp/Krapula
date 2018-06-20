using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krapula
{
    class Game
    {
        public Armor armor;
        public Player player;
        public Area currentArea;
        public List<Area> pastAreas;
        public static bool IsPlayerAlive;
        public static bool IsPlayerTurn;
        public static bool Restart;
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
            Restart = false;
            rand = new Random();

 

            Console.WriteLine(Story.TransportationGenerator(currentArea.Name));
            Console.WriteLine(Story.NPCGenerator(currentArea.NPC.Name));
            Console.WriteLine();
            Console.WriteLine("Mitä teet?");

            Console.OutputEncoding = Encoding.UTF8;

            CommandList = new Dictionary<string, Func<string, string>>();

            CommandList.Add("mene", Go);
            CommandList.Add("katso", Look);
            CommandList.Add("hyökkää", Attack);
            CommandList.Add("puolusta", Defend);
            CommandList.Add("pakene", Run);
            CommandList.Add("ota", Take);
            CommandList.Add("käytä", Equip);
            CommandList.Add("takatasku", Inventory);
            CommandList.Add("nauti", Consume);
            //CommandList.Add("buy", Buy);
            //CommandList.Add("sell", Sell);
            CommandList.Add("apua", Help);
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
                            Console.WriteLine("Ei ole oikea komento. Kirjoita 'apua' saadaksesi listan komennoista.");
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
                            Console.WriteLine("Ei ole oikea komento. Kirjoita 'apua' saadaksesi listan komennoista.");
                            Console.WriteLine();
                        }
                        else
                        {
                            //Console.WriteLine(CommandList[cmd[0]](cmd[1])) ;
                            StringBuilder itemFullName = new StringBuilder();
                            for (int i = 1; i < cmd.Length; i++)
                            {
                                
                                itemFullName.Append(cmd[i]);
                                if (i < cmd.Length-1)
                                {
                                    itemFullName.Append(" ");
                                }
                            }
                            Console.WriteLine(CommandList[cmd[0]](itemFullName.ToString()));
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
                        //Console.WriteLine($"Sait {player.Exp} pistettä! Wow!");
                       // public int pisteet = player.Exp;
                        Restart = Story.Ending(player, armor);
                        
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
                return $"{Utilities.FirstCharToUpper(currentArea.NPC.Name)} ottaa sinut kiinni ja hyökkää";
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
                sb.AppendLine("Mitä teet?");
                
                return sb.ToString();
            }
            else
            {
                return "Et voi liikkua tähän suuntaan";
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
                        sb.AppendLine("Vaikka eilinen onkin verrattavissa andromedan kokoiseen mustaan aukkoon ja päässäsi jyskyttää big bang -teoria, tunnet olevasi elämäsi kunnossa!"); // jotain parempaa pitäisi keksiä ;D
                        break;
                    case float i when i < 1.0f && i >= 0.5f:
                        sb.AppendLine("Tunnet, kuinka energiavarastosi hupenevat. Pitäisi löytää jotain ravitsevaa darraruokaa ja pian..."); // jotain parempaa pitäisi keksiä ;D
                        break;
                    case float i when i < 0.5f && i > 0.0f:
                        sb.AppendLine("Mieltäsi kalvaa ihan hirvee morkkis! Kuinka paha olo voi pienellä ihmisellä olla...?"); // jotain parempaa pitäisi keksiä ;D
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
                        sb.AppendLine("Mörkö näyttää voivan hyvin. Perkele."); // jotain parempaa pitäisi keksiä ;D
                        break;
                    case float i when i < 1.0f && i >= 0.5f:
                        sb.AppendLine("Mörkö alkaa selkeästi väsyä."); // jotain parempaa pitäisi keksiä ;D
                        break;
                    case float i when i < 0.5f && i > 0.0f:
                        sb.AppendLine("Pahis on kuolemaisillaan!"); // jotain parempaa pitäisi keksiä ;D
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
            if (player.WeaponEquipped == null && player.Inventory.Count == 0)
            {
                Console.WriteLine("Kätesi ovat aseettomat ja huomaat, ettei takataskussaikaan ole mitään taisteluun kelpaavaa!");
                Console.WriteLine();
                Restart = Story.Ending(player, armor);
            }
            if (player.WeaponEquipped.Durability == 0)
            {
                string weaponBrokenText = String.Format("Kädessäsi oleva {0} on äärimmilleen ruhjoutunut, jonka takia hyökkäyksesi epäonnistuu kriittisesti." +
                    " Otat 1 pisteen vahinkoa, kun kädessäsi oleva {0} räjähtää tuhannen %&#!#? päreiksi.", player.WeaponEquipped.Name);
                player.Health -= 1;
                player.WeaponEquipped = null;
                IsPlayerTurn = false;
                return weaponBrokenText;
            }
            if (currentArea.NPC == null)
            {
                return "Pyörähdät vinhasti, kuten torakka blenderissä, mutta lähistölläsi ei ole ketään";
            }

            string currentAreaNPCName = currentArea.NPC.Name;
            int damage = rand.Next(player.WeaponEquipped.MaxDamage - player.WeaponEquipped.MinDamage);
            player.WeaponEquipped.Durability -= 1;
            damage += player.WeaponEquipped.MinDamage;
            damage -= (currentArea.NPC.ClothesEquipped.DamageBlock / 2);
            
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
                string npcDeadText = String.Format("Flegmaattinen hyökkäyksesi osuu kuin parkinsonintautia kärsivän kirurgin veitsi ja {0} putoaa maahan elottoman näköisenä.", currentArea.NPC.Name);
                currentArea.NPC = null;
                return npcDeadText;
            }
            IsPlayerTurn = false;
            string attackText = String.Format("Ketterästi pyörähtäen silpaiset ja {0} ottaa " + damage + " pistettä vahinkoa", currentAreaNPCName);
            return attackText;

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
                    sb.AppendLine($"Paetessasi {currentArea.NPC.Name} hyökkäsi!");
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
            if (name.Equals("kaikki"))
            {
                foreach (Item item in currentArea.Items)
                {
                    player.Inventory.Add(item);
                }
                return "Näet kasapain helyjä. Rohmuat kaiken syliisi ja sullot ne takataskuihisi";
            }
            Item match = currentArea.Items.Where(item => item.Name.ToLower() == name.ToLower()).FirstOrDefault();
            if (match != null)
            {
                player.Inventory.Add(match);
                string pickUpItem = String.Format("Nostat maasta jotain kimaltavaa. Kädessäsi on {0}. Sujautat sen takataskuusi.", match.Name);
                currentArea.Items.Remove(match);
                return pickUpItem;
            }
            else
            {
                return "Lähistölläsi ei ole kyseistä tavaraa.";
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

                return String.Format("Kädessäsi on {0} ja olet valmiina taistoon!", player.WeaponEquipped.Name);
            }

            else if (match?.GetType() == typeof(Armor))
            {
                player.Inventory.Add(player.ClothesEquipped);
                player.ClothesEquipped = (Armor)match;
                player.Inventory.Remove(match);

                IsPlayerTurn = false;

                return String.Format("Nyt päälläsi säkenöi uudenkarhea {0}. Mahtavaa!", player.ClothesEquipped.Name);
            }
            else
            {
                return "Tuossahan ei ole mitään järkeä!";
            }
        }

        // Ville
        public string Inventory(string ok)
        {
            List<Food> foods = new List<Food>();
            List<Weapon> weapons = new List<Weapon>();
            List<Armor> clothes = new List<Armor>();
            StringBuilder sb = new StringBuilder();

            // Add equipped items to output
            if (player.WeaponEquipped != null && player.ClothesEquipped != null)
            {
                sb.AppendLine("").AppendLine("Päälläsi olevat varusteet:");
                sb.AppendLine(String.Format("{0, -15} {1, 15} {2 ,15} {3, 15} {4, 15} {5, 15}", "Nimi:", "Vahinko", "Kestävyys", "Vahingoensto:", "Tyylipisteet:", "Arvo:"));
                sb.AppendLine(String.Format("{0, -15} {1, 15} {2, 15} {3, 15} {4, 15} {5, 15}", player.ClothesEquipped.Name, "", "", player.ClothesEquipped.DamageBlock, player.ClothesEquipped.Style, player.ClothesEquipped.Value + "€"));
                sb.AppendLine(String.Format("{0, -15} {1, 15} {2, 15} {3, 15} {4, 15} {5, 15}", player.WeaponEquipped.Name,
                    player.WeaponEquipped.MinDamage.ToString() + " - " + player.WeaponEquipped.MaxDamage.ToString(), player.WeaponEquipped.Durability, "", "", ""));
            }
            else if (player.WeaponEquipped == null)
            {
                Console.WriteLine("Katsot käsiäsi ja huomaat olevasi täysin aseeton.");
            }
            else if (player.ClothesEquipped == null)
            {
                Console.WriteLine("Katsot itseäsi ja huomaat olevasi täysin alasti. Laita nyt edes jotain yllesi!");
            }
            if (player.Inventory.Count() == 0)
            {
                sb.AppendLine("").AppendLine("Takataskusi ovat tyhjää täynnä. Ei edes nöyhtää!");
            }
            else
            {
                // Tells the player what items he/she has
                foreach (var item in player.Inventory)
                {
                    if (item.GetType() == null)
                    {
                        continue;
                    }
                    else if (item.GetType() == (typeof(Food)))
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

                sb.AppendLine("");
                sb.AppendLine("Takataskussasi olevat tavarat:");
                sb.AppendLine(String.Format("{0, -15} {1,15} {2, 15} {3, 15}", "Kledju:", "Vahingonesto:", "Tyylipisteet:", "Arvo:"));

                for (int i = 0; i < clothes.Count(); i++)
                {
                    sb.AppendLine(String.Format("{0,-15} {1,15} {2, 15} {3, 15}", clothes[i].Name, clothes[i].DamageBlock, clothes[i].Style, clothes[i].Value + "€"));
                }

                sb.AppendLine("").AppendLine(String.Format("{0, -15} {1, 15} {2, 15}", "Ruoka:", "Energia:", "Arvo:"));
                for (int i = 0; i < foods.Count(); i++)
                {
                    sb.AppendLine(String.Format("{0,-15} {1,15} {2, 15}", foods[i].Name, foods[i].Energy, foods[i].Value + "€"));
                }
                sb.AppendLine("").AppendLine(String.Format("{0, -15} {1,15} {2, 15}", "Ase:", "Vahinko:", "Kestävyys"));
                for (int i = 0; i < weapons.Count(); i++)
                {
                    sb.AppendLine(String.Format("{0,-15} {1,15} {2, 15}", weapons[i].Name, weapons[i].MinDamage.ToString() + " - " + weapons[i].MaxDamage.ToString(), weapons[i].Durability));
                }

               
            }
            return sb.ToString();
        }
        public string Consume(string item)
        {
            StringBuilder sb = new StringBuilder();
            Food match = (Food)player.Inventory.Where(i => i.Name == item).FirstOrDefault();

            player.Health += match.Energy;
            if (player.Health > player.MaxHealth)
            {
                player.Health = player.MaxHealth;
            }
            player.Inventory.Remove(match);

            sb.AppendLine("Ahmit " + match.Name);
            sb.AppendLine();
            switch ((float)player.Health / (float)player.MaxHealth)
            {
                case 1:
                    sb.AppendLine("Tuntuu siltä et voisit vaikka valloittaa koko maailman!"); // jotain parempaa pitäisi keksiä ;D
                    break;
                case float i when i < 1.0f && i >= 0.5f:
                    sb.AppendLine("Ruoka maistui ja tunnet energiasi palautuvan."); // jotain parempaa pitäisi keksiä ;D
                    break;
                case float i when i < 0.5f && i > 0.0f:
                    sb.AppendLine("Hirvee nälkä vielä..."); // jotain parempaa pitäisi keksiä ;D
                    break;
            }

            return sb.ToString();
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
            sb.Append("Käytettävissä olevat komennot: ");
            foreach (KeyValuePair<string, Func<string, string>> entry in CommandList)
            {
                sb.Append(entry.Key + ", ");
            }

            sb.Remove(sb.Length - 2, 2);
            return sb.ToString();
        }


    }
}
