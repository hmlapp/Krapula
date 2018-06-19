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
        

        public static string TransportationGenerator(string movingaround)
        {
            string path =  movingaround + ".txt";
            return Utilities.RandomStringFrom(path).Trim();
        }

        public static string NPCnGenerator(string seeingthings)
        {
          
            string path = seeingthings + ".txt";

            return Utilities.RandomStringFrom(path).Trim();
        }

    }
}
