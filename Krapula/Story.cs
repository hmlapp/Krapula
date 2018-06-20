using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krapula
{//Nina ja Riku
    public class Story
    {
       
        
       public static string Beginning()
      {
            
            Console.WriteLine("Heräät juhannuksen jälkeen kaameassa krapulassa.");
           // System.Threading.Thread.Sleep(3000);
            Console.WriteLine("Suusi on tahmea, päähän sattuu ja jossain haisee oksennus."  );
          //  System.Threading.Thread.Sleep(3000);
            Console.WriteLine("Joka paikkaa särkee, mutta kotiin pitäisi päästä..");
           // System.Threading.Thread.Sleep(3000);
            Console.WriteLine("Kasaa ajatuksesi ja kerro nimesi.. muistatko mikä se on?: ");
            string nimi = Console.ReadLine();
            Console.Clear();
            return nimi;
        }
        

        public static string TransportationGenerator(string place)
        {
            string path =  "movingaround.txt";
            return Utilities.RandomStringFrom(path).Trim() + " " + place;
        }

        public static string NPCGenerator(string npc)
        {
          
            string path = "seeingthings.txt";

            return Utilities.RandomStringFrom(path).Trim() + " " + npc;
        }
        public static void Ending(Player player, Armor armor) 
        {
            Console.WriteLine("Paha mörkö voitti sinut..snif.");
            System.Threading.Thread.Sleep(3000);
            Console.WriteLine("Mutta ei hätää. Seikkailit tyylikkäillä vaatteilla, taistelit parhaasi mukaan ja sait pelistäsi tyylipisteitä: "+player.ClothesEquipped.Style);
            Console.WriteLine("Lopullinen varustuksesi oli: " +player.ClothesEquipped.Name+ " ja aseenasi oli " + player.WeaponEquipped.Name);
            System.Threading.Thread.Sleep(3000);
            Console.WriteLine();
            Console.Write("Takataskussasi kuolinhetkelläsi olivat seuraavat tavarat: ");
            foreach (var i in player.Inventory)
            {
               
                Console.Write("\n{0}\t", i.Name);
            }
            Console.WriteLine();
         

            int pisteet = player.Exp;
            switch (pisteet)
            {
                case int n when (pisteet > 80):
                    Console.WriteLine("Wau. Huipputulos!! Oletko yrittänyt selvitä kotiin aiemminkin?");
                    break;
                case int n when (pisteet < 79 && pisteet >= 30):
                    Console.WriteLine("Pelasit hyvin.. ish.");
                    break;
                case int n when (pisteet < 29 && pisteet >= 0):
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
            Console.WriteLine("Tyyli- ja tappopisteet yhteensä: "+styyli);
            Console.WriteLine();
             System.Threading.Thread.Sleep(3000);

            Console.WriteLine("Haluatko pelata uudelleen? (Kyllä/Ei)");
            string vastaus = Console.ReadLine().ToLower();
            switch (vastaus)
            {
                case string s when (vastaus == "kyllä" || vastaus == "yes" || vastaus == "k"):
                    Console.WriteLine("Valitse Ei!");                
                    break;
                case string s when (vastaus == "ei" || vastaus == "no" || vastaus == "e"):
                    Console.WriteLine("Fiksu päätös.");
                    break;
                default:
                    Console.WriteLine("Anna kunnollinen vastaus");
                    break;
            }

        }
    }
}
