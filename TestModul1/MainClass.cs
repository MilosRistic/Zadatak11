using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestModul1.Utility;
using TestModul1.UserInterface;
using System.IO;

namespace TestModul1
{
    class MainClass
    {
        public static SqlConnection conn;
        public static string putanjaXml;
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Putanja();
            Konekcija();
            MeniOpcije();
            Console.ReadLine();
        }

        public static void Putanja()
        {
           
            putanjaXml = new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName + "//data//cd_catalog.xml";
            
        }

        public static void Meni()
        {
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("1.Pregled svih CD-ova");
            Console.WriteLine("2.Pregled svih izvođača");
            Console.WriteLine("3.Dodavanje novog CD-a");
            Console.WriteLine("4.Ucitaj iz XML dokumenta u bazu podataka");
            Console.WriteLine("0.Izlaz iz programa");
            Console.WriteLine("-----------------------------------------------------");
        }

        public static void MeniOpcije()
        {
            int odluka;
            do
            {
                Meni();
                odluka = PomocnaKlasa.UnosBroj();
                switch (odluka)
                {
                    case 1:
                        CdUI.GetAll(conn);
                        break;
                    case 2:
                        IzvodjacUI.GetAll(conn);
                        break;
                    case 3:
                        CdUI.Unos(conn);
                        break;
                    case 4:
                        IzvodjacUI.LoadXML(putanjaXml,conn);
                        break;
                    case 0:
                        break;
                    default:
                        Console.WriteLine("Nepoznata opcija");
                        break;
                }

            } while (odluka != 0);
        }

        public static void Konekcija()
        {
            try
            {
                //string Sql = "Data Source=(local)\\MSSQLLocalDB;Initial Catalog=ZaTestiranje;Integrated Security=True;MultipleActiveResultSets=True";
                string Sql = "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=ZaTestiranje;Integrated Security=True;MultipleActiveResultSets=True";
                conn = new SqlConnection(Sql);
                conn.Open();
            }
            catch (Exception e)
            {

                Console.WriteLine(e.ToString());
            }
            
        }
    }
}
