using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoGUI
{
    internal class Karosszeria
    {
        public int KarosszeriaId { get; set; }
        public string KarosszeriaNev { get; set; }

        public Karosszeria(int id, string nev)
        {
            KarosszeriaId = id;
            KarosszeriaNev = nev;
        }
    }
}
