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
        public Mapa mapa;
        public Gracz gracz = new Gracz();
        public void Wprowadzenie()
        {
            ZmianaMapy(new Polany(this));
            //ZmianaStanu(new Walka(this, gracz, new Zombie()));
        }

        public void ZmianaStanu(Stan stan)
        {
            this.stan = stan;
            this.stan.Opis();
        }

        public void ZmianaMapy(Mapa mapa)
        {
            this.mapa = mapa;
            mapa.Dzialanie();
        }

    }
}
