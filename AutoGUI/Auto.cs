using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoGUI
{
    internal class Auto
    {
        public int Azonosito { get; set; }
        public int Evjarat { get; set; }
        public Gyarto Gyarto { get; set; }
        public string Modell { get; set; }

        public int Km { get; set; }
        public Karosszeria Karosszeria { get; set; }
        public int Henger { get; set; }
        public Valto Valto { get; set; }
        public string KulsoSzin { get; set; }
        public string BelsoSzin { get; set; }
        public int Szemelyek { get; set; }
        public int Ajtok { get; set; }
        public double Varos { get; set; }
        public double Palya { get; set; }
        public int Ar { get; set; }

        public override string ToString()
        {
            return $"{Azonosito}. autó: \n\t Gyártó - modell: {Gyarto.GyartoNev} - {Modell}\n\t Fogyasztás: {(Varos + Palya) / 2:00}/100 km\n\t Kilométer állása: {Km}\n\t Váltó típusa: {Valto.ValtoNev}\n\t Ára (CAD): {Ar}";
        }

        public static List<Auto> LoadFromCsv(string fileName)
        {
            List<Auto> autok = new List<Auto>();
            using (StreamReader sr = new StreamReader($@"..\..\..\src\{fileName}", Encoding.UTF8))
            {
                sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    string[] sor = sr.ReadLine().Split(';');
                    int id = int.Parse(sor[0]);
                    int evjarat = int.Parse(sor[1]);
                    Gyarto gyarto = new Gyarto(int.Parse(sor[2]), sor[3]);
                    string modell = sor[4];
                    int km = int.Parse(sor[5]);
                    Karosszeria karosszeria = new Karosszeria(int.Parse(sor[6]), sor[7]);
                    int henger = int.Parse(sor[8]);
                    Valto valto = new Valto(int.Parse(sor[9]), sor[10]);
                    string kulsoSzin = sor[11];
                    string belsoSzin = sor[12];
                    int szemelyek = int.Parse(sor[13]);
                    int ajtok = int.Parse(sor[14]);
                    double varos = double.Parse(sor[15]);
                    double palya = double.Parse(sor[16]);
                    int ar = int.Parse(sor[17]);
                    autok.Add(new Auto(id, evjarat, gyarto, modell, km, karosszeria, henger, valto, kulsoSzin, belsoSzin, szemelyek, ajtok, varos, palya, ar));
                }
            }

            return autok;
        }

        public Auto(int id, int evjarat, Gyarto gyarto, string modell, int km, Karosszeria karosszeria, int henger, Valto valto, string kulszin, string belszin, int szemelyek, int ajtok, double varos, double palya, int ar)
        {
            Azonosito = id;
            Evjarat = evjarat;
            Gyarto = gyarto;
            Modell = modell;
            Km = km;
            Karosszeria = karosszeria;
            Henger = henger;
            Valto = valto;
            KulsoSzin = kulszin;
            BelsoSzin = belszin;
            Szemelyek = szemelyek;
            Ajtok = ajtok;
            Varos = varos;
            Palya = palya;
            Ar = ar;
        }
    }
}
