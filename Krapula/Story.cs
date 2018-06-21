using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Krapula
{//Nina ja Riku
    public class Story
    {
       
        
       public static string Beginning()
      {
            BeginningStories.Starts();

            Console.WriteLine("Kasaa ajatuksesi ja kerro nimesi.. muistatko mikä se on?");
            Console.WriteLine();
            string nimi = Utilities.ReadLine();
            while (nimi == null || nimi == "")
            {
                Console.WriteLine("Herätys! Ei toi voi olla sun nimi!");
                Console.WriteLine("Yritä uudelleen");
                Console.WriteLine();
                nimi = Utilities.ReadLine();
            }
            Console.Clear();
            return nimi.Trim();
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
            Console.Clear();
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

            string param = $"?score={styyli.ToString()}&name={name}&weapon={player.WeaponEquipped?.Name}&clothes={player.ClothesEquipped.Name}";

            string url = ConfigurationManager.AppSettings["wspalveluurl"].ToString();
            var client = new RestClient(url + param);
            var request = new RestRequest(Method.POST);
            //request.AddHeader("Postman-Token", "a3c8870a-8a2d-4090-9059-bb31c2b60bcf");
            request.AddHeader("Cache-Control", "no-cache");
            try
            {
                IRestResponse response = client.Execute(request);
            }
            catch (Exception e)
            {

                throw e;
            }

            System.Threading.Thread.Sleep(3000);

            Console.WriteLine("Haluatko pelata uudelleen? (Kyllä/Ei)");
            Loppu:
            string vastaus = Console.ReadLine().ToLower();      
            switch (vastaus)
            {
                case string s when (vastaus == "kyllä" || vastaus == "yes" || vastaus == "k"):
                    Console.WriteLine("Toivottavasti pärjäät paremmin tällä kertaa!");
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
