using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tekstowa
{
    internal abstract class Przeciwnik : Postac
    {
        public int Exp {  get; set; }

        public List<PrzedmiotUzytkowy> Przedmioty = new List<PrzedmiotUzytkowy>();
        public List<Przedmiot> Loot = new List<Przedmiot>();

    }
}
