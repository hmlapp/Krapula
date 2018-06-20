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

            Random rnd = new Random(DateTime.Now.Millisecond);
            nameString = RandomStringFrom(places) + " " + RandomStringFrom(nakkikiskat);

            return nameString;
        }

        // Name generator for Character names
        public static string NameGenerator(string adjectives, string professions, string names)
        {
            string nameString;

            Random rnd = new Random(DateTime.Now.Millisecond);
            nameString = RandomStringFrom(adjectives).ToLower() + " " 
                + RandomStringFrom(professions).ToLower() + " " 
                + RandomStringFrom(names);

            return nameString;
        }

        public static string RandomStringFrom(string file)
        {

            Random rnd = new Random(DateTime.Now.Millisecond);
            string[] lines = File.ReadAllLines("resources/" + file + ".txt", Encoding.UTF8);
            return lines[rnd.Next(lines.Length)];
        }

        public static string FirstCharToUpper(string input)
        {
            return input.First().ToString().ToUpper() + input.Substring(1);
        }
    }
}
