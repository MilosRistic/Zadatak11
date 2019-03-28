using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestModul1.Model;
using TestModul1.Utility;

namespace TestModul1.UserInterface
{
    class CdUI
    {
        public static List<Cd> listaCd = new List<Cd>();

        public static List<Cd> GetAll(SqlConnection conn)
        {
           
            Cd cd = new Cd();

            try
            {
                string komandaString2 = "SELECT * FROM Cd";
                SqlCommand komanda2 = new SqlCommand(komandaString2, conn);
                SqlDataReader dr2 = komanda2.ExecuteReader();
                while (dr2.Read())
                {
                    int id2 = (int)dr2["id"];
                    string nazivAlbuma = (string)dr2["nazivAlbuma"];
                    string drzava = (string)dr2["drzava"];
                    string imeIzdavackeKuce = (string)dr2["imeIzdavackeKuce"];
                    double cena = (double)dr2["cena"];
                    int godinaIzdavanja = (int)dr2["godinaIzdavanja"];
                    string izvodjacUmetnik = (string)dr2["izvodjacUmetnik"];

                    cd = new Cd(nazivAlbuma, drzava, imeIzdavackeKuce, cena, godinaIzdavanja, izvodjacUmetnik, id2);
                    listaCd.Add(cd);
                }
                dr2.Close();

            }
            catch (Exception e)
            {

                Console.WriteLine(e.ToString());
            }

            foreach (Cd cd2 in listaCd)
            {
                Console.WriteLine(cd2);
            }

            return listaCd;
        }

        public static void NoviCd(Cd cd,SqlConnection conn)
        {
            try
            {
                string komandaString3 = "INSERT INTO Cd(nazivAlbuma,drzava,imeIzdavackeKuce,cena,godinaIzdavanja,izvodjacUmetnik) Values" +
                "(@nazivAlbuma,@drzava,@imeIzdavackeKuce,@cena,@godinaIzdavanja,@izvodjacUmetnik);";
                SqlCommand komanda3 = new SqlCommand(komandaString3, conn);
                komanda3.Parameters.AddWithValue("@nazivAlbuma", cd.NazivAlbuma);
                komanda3.Parameters.AddWithValue("@drzava", cd.Drzava);
                komanda3.Parameters.AddWithValue("@imeIzdavackeKuce", cd.ImeIzdavackeKuce);
                komanda3.Parameters.AddWithValue("@cena", cd.Cena);
                komanda3.Parameters.AddWithValue("@godinaIzdavanja", cd.GodinaIzdavanja);
                komanda3.Parameters.AddWithValue("@izvodjacUmetnik", cd.IzvodjacUmetnik);
                komanda3.ExecuteNonQuery();
            }
            catch (Exception e)
            {

                Console.WriteLine(e.ToString());
            }
            
        }

        public static void Unos(SqlConnection conn)
        {
            Console.WriteLine("Unesite ime vec postojeceg izvodjaca");
            string izvodjacUmetnik = PomocnaKlasa.UnosString();
            
            if (IzvodjacUI.PronadjiImePrezime(izvodjacUmetnik, conn))
            {
                Console.WriteLine("Unesite naziv albuma");
                string nazivAlbuma = PomocnaKlasa.UnosString();
                Console.WriteLine("Unesite naziv drzave gde je album izdat");
                string drzava = PomocnaKlasa.UnosString();
                Console.WriteLine("Unesite ime izdavacke kuce");
                string imeIzdavackeKuce = PomocnaKlasa.UnosString();
                Console.WriteLine("Unesite cenu albuma");
                double cena = PomocnaKlasa.UnosFloat();
                Console.WriteLine("Unesite godinu izdavanja");
                int godinaIzdavanja = PomocnaKlasa.UnosBroj();

                Cd cd = new Cd(nazivAlbuma,drzava,imeIzdavackeKuce,cena,godinaIzdavanja,izvodjacUmetnik);
                NoviCd(cd, conn);

            }

            else
            {
                Console.WriteLine("Izvodjac ne postoji");
                Console.ReadLine();
            }
            
            
        }
    }
}

