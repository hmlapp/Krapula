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

            Random rnd = new Random(DateTime.Now.Millisecond);
            nameString = RandomStringFrom(path1) + " " + RandomStringFrom(path2);

            return nameString;
        }

        // Name generator for Character names
        public static string NameGenerator(string adjectives, string professions, string names)
        {
            string nameString;
            string path1 = adjectives+ ".txt";
            string path2 = professions + ".txt";
            string path3 = names + ".txt";

            Random rnd = new Random(DateTime.Now.Millisecond);
            nameString = RandomStringFrom(path1).ToLower() + " " 
                + RandomStringFrom(path2).ToLower() + " " 
                + RandomStringFrom(path3);

            return nameString;
        }

        public static string RandomStringFrom(string file)
        {
            Random rnd = new Random(DateTime.Now.Millisecond);
            string[] lines = File.ReadAllLines(file);
            return lines[rnd.Next(lines.Length)];
        }
    }
}
