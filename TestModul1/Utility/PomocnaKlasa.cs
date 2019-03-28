using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestModul1.Utility
{
    class PomocnaKlasa
    {
        public static int UnosBroj()
        {
            int broj;
            while (Int32.TryParse(Console.ReadLine(), out broj) == false)
            {
                Console.WriteLine("Broj je nepravilno unet, ponovite unos");
            }
            return broj;
        }

        public static string UnosString()
        {
            string unos="";
            while ( (unos==null) || (unos.Equals("")))
            {
                unos = Console.ReadLine();
            }
            return unos;
        }

        public static float UnosFloat()
        {
            float broj;
            while ( Single.TryParse(Console.ReadLine(), out broj) == false)
            {
                Console.WriteLine("Broj je nepravilno unet, ponovite unos");
            }
            return broj;
        }
    }
}
