using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tekstowa
{
    internal class Fabula
    {
        private Stan stan;
        public Gracz gracz = new Gracz();
        public void Wprowadzenie()
        {
            ZmianaStanu(new Walka(this, gracz, new Zombie()));
        }

        public void ZmianaStanu(Stan stan)
        {
            this.stan = stan;
            this.stan.Opis();
        }

    }
}
