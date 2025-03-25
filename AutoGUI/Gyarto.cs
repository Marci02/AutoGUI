using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoGUI
{
    internal class Gyarto
    {
        public int GyartoId { get; set; }
        public string GyartoNev { get; set; }

        public Gyarto(int id, string nev)
        {
            GyartoId = id;
            GyartoNev = nev;
        }
    }
}
