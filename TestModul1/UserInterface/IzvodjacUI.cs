using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TestModul1.Model;

namespace TestModul1.UserInterface
{
    class IzvodjacUI
    {
        // public static List<Izvodjac> listaIzvodjaca = new List<Izvodjac>();

        public static List<Izvodjac> GetAll(SqlConnection conn)
        {
            List<Izvodjac> listaIzvodjaca = new List<Izvodjac>();

            try
            {
                string komandaString = "Select * FROM Izvodjac";
                SqlCommand komanda = new SqlCommand(komandaString, conn);
                SqlDataReader dr = komanda.ExecuteReader();
                while (dr.Read())
                {
                    Izvodjac izvodjac = new Izvodjac();
                    Cd cd = new Cd();
                    List<Cd> listaCd = new List<Cd>();

                    int id = (int)dr["id"];
                    string imePrezime = (string)dr["imePrezime"];
                    string pol = (string)dr["pol"];

                    string komandaString2 = "SELECT * FROM Cd WHERE izvodjacUmetnik = @imePrezime;";
                    SqlCommand komanda2 = new SqlCommand(komandaString2, conn);
                    komanda2.Parameters.AddWithValue("@imePrezime", imePrezime);
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
                    izvodjac.Id = id;
                    izvodjac.ImePrezime = imePrezime;
                    izvodjac.Pol = pol;
                    if (listaCd != null)
                    {
                        izvodjac.ListaCd = listaCd;
                    }
                    listaIzvodjaca.Add(izvodjac);
                }
                dr.Close();
            }
            catch (Exception e)
            {

                Console.WriteLine(e.ToString());
            }

            foreach (Izvodjac izvodjac2 in listaIzvodjaca)
            {
                Console.WriteLine(izvodjac2);
            }

            return listaIzvodjaca;
        }

        public static bool PronadjiImePrezime(string imePrezime, SqlConnection conn)
        {
            string komandaString4 = "Select * FROM Izvodjac WHERE imePrezime = @imePrezime";
            SqlCommand komanda4 = new SqlCommand(komandaString4, conn);
            komanda4.Parameters.AddWithValue("@imePrezime", imePrezime);
            SqlDataReader dr3 = komanda4.ExecuteReader();
            int provera = -1;
            while (dr3.Read())
            {
                provera = (int)dr3["id"];
            }
            dr3.Close();

            if (provera == -1)
            {
                return false;
            }

            return true;
        }

        public static void NoviIzvodjac(Izvodjac izvodjac, SqlConnection conn)
        {
            try
            {
                string komandaString6 = "INSERT INTO Izvodjac(imePrezime,pol) Values" +
                "(@imePrezime,@pol);";
                SqlCommand komanda6 = new SqlCommand(komandaString6, conn);
                komanda6.Parameters.AddWithValue("@imePrezime", izvodjac.ImePrezime);
                komanda6.Parameters.AddWithValue("@pol", izvodjac.Pol);
                
                komanda6.ExecuteNonQuery();
            }
            catch (Exception e)
            {

                Console.WriteLine(e.ToString());
            }

        }

        public static void LoadXML(string putanja, SqlConnection conn)
        {
            XDocument xmlDokument = XDocument.Load(putanja);
            List<Izvodjac> listaIzvodjac = (from predmet in xmlDokument.Element("CATALOG").Elements("CD")
                                       select new Izvodjac
                                       {
                                           ImePrezime = predmet.Element("ARTIST").Element("NAME").Value + " " + predmet.Element("ARTIST").Element("SURNAME").Value,
                                           Pol = predmet.Element("ARTIST").Element("GENDER").Value

                                       }).ToList();

            List<Cd> listaCd = (from predmet in xmlDokument.Element("CATALOG").Elements("CD")
                           select new Cd
                           {
                               NazivAlbuma = predmet.Element("TITLE").Value,
                               Drzava = predmet.Element("COUNTRY").Value,
                               ImeIzdavackeKuce = predmet.Element("COMPANY").Value,
                               Cena = Double.Parse(predmet.Element("PRICE").Value),
                               GodinaIzdavanja = Int32.Parse(predmet.Element("YEAR").Value),
                               IzvodjacUmetnik = predmet.Element("ARTIST").Element("NAME").Value + " " + predmet.Element("ARTIST").Element("SURNAME").Value,

                           }).ToList();

            foreach (Izvodjac izvodjac in listaIzvodjac)
            {
                NoviIzvodjac(izvodjac,conn);
            }

            foreach (Cd cd in listaCd)
            {
                CdUI.NoviCd(cd,conn);
            }
        }
    }
}
