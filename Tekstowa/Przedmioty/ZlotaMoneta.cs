using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tekstowa
{
    internal class ZlotaMoneta : Przedmiot
    {
        public ZlotaMoneta()
        {
            ID = 1;
            Nazwa = "Złota moneta";
            Opis = "Błyszcząca, złota moneta. Chyba jedyna naprawdę wartościowa rzecz jaką tu zdobędziesz.";
        }
    }
}
