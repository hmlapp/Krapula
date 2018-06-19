/* Ville 
 Utils class to hold methods that are used for mutltiple tasks*/
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krapula
{
   public class Utilities
    {

        // Name generator for area names
        public static string NameGenerator(string places, string nakkikiskat)
        {
            string nameString;
            string path1 = places + ".txt";
            string path2 = nakkikiskat + ".txt";
            
            string[] allLinesP1 = File.ReadAllLines(path1);
            string[] allLinesP2 = File.ReadAllLines(path2);

            Random rnd = new Random(DateTime.Now.Millisecond);
            nameString = allLinesP1[rnd.Next(allLinesP1.Length)] + " " + allLinesP2[rnd.Next(allLinesP2.Length)];

            return nameString;
        }

        // Name generator for Character names
        public static string NameGenerator(string adjectives, string professions, string names)
        {
            string nameString;
            string path1 = adjectives+ ".txt";
            string path2 = professions + ".txt";
            string path3 = names + ".txt";

            string[] allLinesP1 = File.ReadAllLines(path1);
            string[] allLinesP2 = File.ReadAllLines(path2);
            string[] allLinesP3 = File.ReadAllLines(path3);

            Random rnd = new Random(DateTime.Now.Millisecond);
            nameString = allLinesP1[rnd.Next(allLinesP1.Length)] + " " 
                + allLinesP2[rnd.Next(allLinesP2.Length)].ToLower() + " " 
                + allLinesP3[rnd.Next(allLinesP3.Length)];

            return nameString;
        }
    }
}
