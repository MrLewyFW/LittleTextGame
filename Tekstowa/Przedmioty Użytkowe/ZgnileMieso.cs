using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tekstowa
{
    internal class ZgnileMieso : PrzedmiotUzytkowy
    {
        public ZgnileMieso()
        {
            ID = 0;
            Nazwa = "Zgniłe mięso";
            IleOdnawia = -10;
            Opis = "Kawałek zgniłego mięsa. Lekko daje trupem.";
        }
    }
}
