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
       public void Beginning()
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
            string transportationName;
            string path1 =  movingaround+ ".txt";
           
          

            string[] allLinesP1 = File.ReadAllLines(path1);
            //string[] allLinesP2 = File.ReadAllLines(path2);
          

            Random rnd = new Random(DateTime.Now.Millisecond);
            transportationName = allLinesP1[rnd.Next(allLinesP1.Length)];
          //  npcthing= allLinesP2[rnd.Next(allLinesP2.Length)].ToLower();
              

            return transportationName;
        }

        public static string NPCnGenerator(string seeingthings)
        {
          
            string npcthing;
            string path2 = seeingthings + ".txt";


            //string[] allLinesP1 = File.ReadAllLines(path1);
            string[] allLinesP2 = File.ReadAllLines(path2);


            Random rnd = new Random(DateTime.Now.Millisecond);
            npcthing = allLinesP2[rnd.Next(allLinesP2.Length)];


            return npcthing;
        }

    }
}
