using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoGUI
{
    internal class Valto
    {
        public int ValtoId { get; set; }
        public string ValtoNev { get; set; }
        public Valto(int id, string nev)
        {
            ValtoId = id;
            ValtoNev = nev;
        }
    }
}
