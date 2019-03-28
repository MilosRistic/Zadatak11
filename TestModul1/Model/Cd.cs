using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestModul1.Model
{
    public class Cd
    {
        private int brojachId = -1;
        private int id;
        private string nazivAlbuma;
        private string drzava;
        private string imeIzdavackeKuce;
        private double cena;
        private int godinaIzdavanja;
        private string izvodjacUmetnik;

        public int BrojachId { get => brojachId; set => brojachId = value; }
        public int Id { get => id; set => id = value; }
        public string NazivAlbuma { get => nazivAlbuma; set => nazivAlbuma = value; }
        public string Drzava { get => drzava; set => drzava = value; }
        public string ImeIzdavackeKuce { get => imeIzdavackeKuce; set => imeIzdavackeKuce = value; }
        public double Cena { get => cena; set => cena = value; }
        public int GodinaIzdavanja { get => godinaIzdavanja; set => godinaIzdavanja = value; }
        public string IzvodjacUmetnik { get => izvodjacUmetnik; set => izvodjacUmetnik = value; }

        public Cd() { }

        public Cd(string nazivAlbuma, string drzava, string imeIzdavackeKuce, double cena, int godinaIzdavanja, string izvodjacUmetnik, int id = -1)
        {
            if (id == -1)
            {
                id = ++BrojachId;
            }
            Id = id;
            NazivAlbuma = nazivAlbuma;
            Drzava = drzava;
            ImeIzdavackeKuce = imeIzdavackeKuce;
            Cena = cena;
            GodinaIzdavanja = godinaIzdavanja;
            IzvodjacUmetnik = izvodjacUmetnik;
        }

        public string Ispis()
        {
            StringBuilder sb = new StringBuilder(String.Format("Id: {0}, naziv albuma: {1}, država u kojoj je izdat : {2}, ime izdavačke kuce: {3}, cena: {4}, godina izdavanja: {5}", Id, NazivAlbuma, Drzava, ImeIzdavackeKuce, Cena, GodinaIzdavanja));

            return sb.ToString();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(String.Format("Id: {0}, naziv albuma: {1}, država u kojoj je izdat : {2}, ime izdavačke kuce: {3}, cena: {4}, godina izdavanja: {5}, izvođač: {6}", Id, NazivAlbuma, Drzava, ImeIzdavackeKuce, Cena, GodinaIzdavanja, IzvodjacUmetnik));
            return sb.ToString();
        }
    }
}
