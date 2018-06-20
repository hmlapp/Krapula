using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krapula
{//RIku ja NIna
    class BeginningStories
    {
        public static string Starts()
        {
            Random rnd = new Random();
            int tarina = rnd.Next(1, 8);

            switch (tarina)
            {
                case 1:
                    Console.WriteLine("Heräät juhannuksen jälkeen kaameassa krapulassa.");
                    System.Threading.Thread.Sleep(3000);
                    Console.WriteLine("Huomaat, että olet joskus voinut paremminkin..");
                    System.Threading.Thread.Sleep(3000);
                    Console.WriteLine("Kotiin kai pitäisi päästä, joten... ei kun ulos.");
                    System.Threading.Thread.Sleep(3000);
                    break;

                case 2:
                    Console.WriteLine("Heräät juhannuksen jälkeen kaameassa krapulassa.");
                    System.Threading.Thread.Sleep(3000);
                    Console.WriteLine("Tuli vissiin suhlittua vähän reippaammin ja sen huomaa.");
                    System.Threading.Thread.Sleep(3000);
                    Console.WriteLine("Oksennat näppäimistölle ja päätät lähteä raahautumaan kotia kohti.");
                    System.Threading.Thread.Sleep(3000);
                    break;

                case 3:
                    Console.WriteLine("Heräät juhannuksen jälkeen kaameassa krapulassa.");
                    System.Threading.Thread.Sleep(3000);
                    Console.WriteLine("Uhhhh... pääsi tuntuu räjähtävän ja näytät kamalalta.. Tätä krapula pahimmillaan on.");
                    System.Threading.Thread.Sleep(3000);
                    Console.WriteLine("Onneksi ei ole koulupäivä. Kotona olisi tasoittava olut, lähdet sitä kohti..");
                    System.Threading.Thread.Sleep(3000);
                    break;

                case 4:
                    Console.WriteLine("Heräät juhannuksen jälkeen kaameassa krapulassa.");
                    System.Threading.Thread.Sleep(3000);
                    Console.WriteLine("Olet jossain.. missä? Ei mitään käryä..");
                    System.Threading.Thread.Sleep(3000);
                    Console.WriteLine("Katsot ikkunasta ulos ja päätät uskaltaa liikkua ihmisten ilmoille..");
                    System.Threading.Thread.Sleep(3000);
                    break;

                case 5:
                    Console.WriteLine("Heräät juhannuksen jälkeen kaameassa krapulassa.");
                    System.Threading.Thread.Sleep(3000);
                    Console.WriteLine("Ei saakeli, mitähän tuli tehtyä.. No, jos sitä ei muista, se ei tapahtunut!");
                    System.Threading.Thread.Sleep(3000);
                    Console.WriteLine("Vielä kun tietäisit miten pääsee kotiin.. Päätät ottaa riskin ja yrittää.");
                    System.Threading.Thread.Sleep(3000);
                    break;

                case 6:
                    Console.WriteLine("Heräät juhannuksen jälkeen kaameassa krapulassa.");
                    System.Threading.Thread.Sleep(3000);
                    Console.WriteLine("Olo tuntuu tahmealta. Suihku olisi aika jees. Joku outo maku suussa.. krapula vissiin.");
                    System.Threading.Thread.Sleep(3000);
                    Console.WriteLine("Pari koulukaveria näkyy nukkuvan lähettyvillä, jätät heille heippalapun ja lähden horjuen liikkeelle.");
                    System.Threading.Thread.Sleep(3000);
                    break;


                case 7:
                    Console.WriteLine("Heräät juhannuksen jälkeen kaameassa krapulassa.");
                    System.Threading.Thread.Sleep(3000);
                    Console.WriteLine("AHISTAA!!! IHAN KAMALA OLO! Et juo enää koskaan, näin vannot..");
                    System.Threading.Thread.Sleep(3000);
                    Console.WriteLine("Hävettää, muttei tarpeeksi. Lähdet siis pihalle ja päätät mennä kotiin.");
                    System.Threading.Thread.Sleep(3000);
                    break;

                default:
                    Console.WriteLine("Heräät juhannuksen jälkeen kaameassa krapulassa.");
                    System.Threading.Thread.Sleep(3000);
                    Console.WriteLine("Suusi on tahmea, päähän sattuu ja jossain haisee oksennus.");
                    System.Threading.Thread.Sleep(3000);
                    Console.WriteLine("Joka paikkaa särkee, mutta kotiin pitäisi päästä..");
                    System.Threading.Thread.Sleep(3000);
                    Console.WriteLine("Kasaa ajatuksesi ja kerro nimesi.. muistatko mikä se on?: ");
                    break;
            }
            return tarina.ToString(); 
        }
    }

}