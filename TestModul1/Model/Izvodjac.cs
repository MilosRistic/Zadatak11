using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestModul1.Model
{
    class Izvodjac
    {
        private int brojachId = -1;
        private int id;
        private string imePrezime;
        private string pol;
        private List<Cd> listaCd;


        public int Id { get => id; set => id = value; }
        public string ImePrezime { get => imePrezime; set => imePrezime = value; }
        public string Pol { get => pol; set => pol = value; }
        public int BrojachId { get => brojachId; set => brojachId = value; }
        public List<Cd> ListaCd { get => listaCd; set => listaCd = value; }

        public Izvodjac() { }

        public Izvodjac(string imePrezime, string pol, int id = -1)
        {
            if (id == -1)
            {
                id = ++BrojachId;
            }
            Id = id;
            ImePrezime = imePrezime;
            Pol = pol;
            ListaCd = new List<Cd>();
        }

        public string Ispis()
        {
            StringBuilder sb = new StringBuilder(String.Format("Id: {0}, ime i prezime izvođača: {1}, pol : {2}", Id, ImePrezime, Pol));
            return sb.ToString();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(String.Format("Id: {0}, ime i prezime izvođača: {1}, pol : {2}", Id, ImePrezime, Pol));
            sb.Append("\nLista albuma izvođača");
            foreach (Cd cd in ListaCd)
            {
                sb.Append("\n" + cd.Ispis());
            }
            return sb.ToString();
        }
    }
}
