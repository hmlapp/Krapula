using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Krapula
{//Nina ja Riku
    public class Story
    {
       
        
       public static string Beginning()
      {
            BeginningStories.Starts();
          //  Console.WriteLine("Heräät juhannuksen jälkeen kaameassa krapulassa.");
          // System.Threading.Thread.Sleep(3000);
          //  Console.WriteLine("Suusi on tahmea, päähän sattuu ja jossain haisee oksennus."  );
          //  System.Threading.Thread.Sleep(3000);
          //  Console.WriteLine("Joka paikkaa särkee, mutta kotiin pitäisi päästä..");
          // System.Threading.Thread.Sleep(3000);
            Console.WriteLine("Kasaa ajatuksesi ja kerro nimesi.. muistatko mikä se on?: ");
            string nimi = Console.ReadLine();
            Console.Clear();
            return nimi;
        }
        

        public static string TransportationGenerator(string place)
        {
            string path =  "movingaround";
            return Utilities.RandomStringFrom(path).Trim() + " " + place;
        }

        public static string NPCGenerator(string npc)
        {
          
            string path = "seeingthings";

            return Utilities.RandomStringFrom(path).Trim() + " " + npc;
        }
        public static bool Ending(Player player, Armor armor) 
        {
            string name = Utilities.NameGenerator("adjectives", "professions").ToLower() + " " + player.Name;
            Console.WriteLine("Paha mörkö voitti sinut..snif.");
            Console.WriteLine();
            Console.WriteLine("Olit suuri ja mahtava " + name);
            System.Threading.Thread.Sleep(3000);
            Console.WriteLine();
            Console.WriteLine("Mutta ei hätää. Seikkailit tyylikkäillä vaatteilla, taistelit parhaasi mukaan ja sait pelistäsi tyylipisteitä: "+player.ClothesEquipped.Style);
            if (player.WeaponEquipped == null)
            {
                Console.WriteLine("Lopullinen varustuksesi oli: " + player.ClothesEquipped.Name);
            }
            else
            {
                Console.WriteLine("Lopullinen varustuksesi oli: " +player.ClothesEquipped.Name+ " ja aseenasi oli " + player.WeaponEquipped.Name);
            }
            System.Threading.Thread.Sleep(3000);
            Console.WriteLine();
            if (player.Inventory.Count >= 1)
            {
                Console.Write("Takataskussasi kuolinhetkelläsi olivat seuraavat tavarat: ");
                foreach (var i in player.Inventory)
                {
                    Console.WriteLine();
                    Console.Write("\n{0}\t", i.Name);
                }
            }
            else
            {
                Console.WriteLine("Kuolinsyyntutkija löysi takataskuistasi vain nöyhtää.");
            }
            Console.WriteLine();
         

            int pisteet = player.Exp;
            switch (pisteet)
            {
                case int n when (pisteet >= 500):
                    Console.WriteLine("Wau. Huipputulos!! Oletko yrittänyt selvitä kotiin aiemminkin?");
                    break;
                case int n when (pisteet < 500 && pisteet >= 150):
                    Console.WriteLine("Pelasit hyvin.. ish.");
                    break;
                case int n when (pisteet < 150 && pisteet >= 0):
                    Console.WriteLine("Höh, et oikein pärjännyt tällä kertaa. Muista nesteyttää itseäsi ennen peliä ja yritä uudelleen!");
                    break;
                default:
                    Console.WriteLine("Pelasit sitten meidän peliä.");
                    break;
            }
            Console.WriteLine();
            int styyli = player.ClothesEquipped.Style * player.Exp;

            if (player.Exp == 0)
            {
                styyli = player.ClothesEquipped.Style;
            }           
            Console.WriteLine("Tyyli- ja tappopisteet yhteensä: " + styyli);
            Console.WriteLine();


            using (var wb = new WebClient())
            {
                var data = new NameValueCollection();
                data["score"] = styyli.ToString();
                data["name"] = player.Name;

                var response = wb.UploadValues("http://localhost:3000", "POST", data);
                string responseInString = Encoding.UTF8.GetString(response);
            }

            System.Threading.Thread.Sleep(3000);

            Console.WriteLine("Haluatko pelata uudelleen? (Kyllä/Ei)");
            Loppu:
            string vastaus = Console.ReadLine().ToLower();      
            switch (vastaus)
            {
                case string s when (vastaus == "kyllä" || vastaus == "yes" || vastaus == "k"):
                    Console.WriteLine("Toivottavasti pärjäät paremmin nyt!");
                    return true;
                case string s when (vastaus == "ei" || vastaus == "no" || vastaus == "e"):
                    Console.WriteLine("Fiksu päätös.");
                    return false;
                default:
                    Console.WriteLine("Anna kunnollinen vastaus");
                    goto Loppu;
                    
            }
        }
    }
}
