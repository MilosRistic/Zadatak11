using System;
using System.Data.SqlClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestModul1;
using TestModul1.UserInterface;
using TestModul1.Model;

namespace TestProjekta
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void NoviCd()
        {
            try
            {
                Cd cd = new Cd();
                string Sql = "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=ZaTestiranje;Integrated Security=True;MultipleActiveResultSets=True";
                SqlConnection conn = new SqlConnection(Sql);
                conn.Open();
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
    }
}
