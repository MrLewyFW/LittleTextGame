using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tekstowa
{
    internal abstract class Przeciwnik : Postac
    {
        public int AP { get; set; }
        public int ModAP { get; set; }
        public int MP { get; set; }
        public int Sila { get; set; }
        public int Wytrzymalosc { get; set; }
        public int Magia { get; set; }
        public int Szczescie { get; set; }
        public int Exp {  get; set; }

        public List<PrzedmiotUzytkowy> Przedmioty = new List<PrzedmiotUzytkowy>();
        public List<Przedmiot> Loot = new List<Przedmiot>();

    }
}
