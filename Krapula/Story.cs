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
       

       public static void Beginning()
      {
         
            Console.WriteLine("Heräät juhannuksen jälkeen kaameassa krapulassa.");
            System.Threading.Thread.Sleep(3000);
            Console.WriteLine("Suusi on tahmea, päähän sattuu ja jossain haisee oksennus."  );
            System.Threading.Thread.Sleep(3000);
            Console.WriteLine("Joka paikkaa särkee, mutta kotiin pitäisi päästä..");
            System.Threading.Thread.Sleep(3000);
            Console.WriteLine("Paina 'ENTER' jatkaaksesi");
            Console.ReadLine();
            Console.Clear();

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
        public static void Ending()
        {
            Console.WriteLine("Paha mörkö voitti sinut.. snif.");
            System.Threading.Thread.Sleep(3000);
            Console.WriteLine("Mutta ei hätää. Seikkailit tyylikkäillä vaatteilla, taistelit parhaasi mukaan ja päällesi jäi: ");  //equippedarmor);
            System.Threading.Thread.Sleep(3000);
            Console.WriteLine("");
            System.Threading.Thread.Sleep(3000);

            int pisteet = 50;
            switch (pisteet)
            {
                case int n when (n >= 60):
                    Console.WriteLine("Wau. Huipputulos!! Oletko harjoitellut kotiin selviämistä aiemminkin? ");

                    break;
                case int n when (n < 59 && n >= 30):
                    Console.WriteLine("Pelasit hyvin.. ish.");
                    break;
                case int n when (n < 29 && n >= 0):
                    Console.WriteLine("Höh, et oikein pärjännyt tällä kertaa. Muista nesteyttää itseäsi ennen peliä ja yritä uudelleen! ");
                    break;
                default:
                    Console.WriteLine("Pelasit sitten meidän peliä.");
                    break;
            }

                   Console.WriteLine("Haluatko pelata uudelleen? (Kyllä/Ei)");
            string vastaus= Console.ReadLine().ToLower();
            switch (vastaus)
            {
                case string s when (vastaus == "kyllä" || vastaus == "yes" || vastaus == "k"):
                    Console.WriteLine("Jee uudestaan.");
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
