using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tekstowa
{
    internal class KratkaWalka : Kratka
    {
        private Random rand = new Random();
        private Przeciwnik przeciwnik;
        private bool CzyJuzTuByles = false;

        public KratkaWalka(Fabula fabula)
        {
            this.fabula = fabula;
            mapa = fabula.mapa;
            przeciwnik = WyborPrzeciwnika();
        }
        public override void Dzialanie()
        {
            if(CzyJuzTuByles)
            {
                JuzTuByles();
            }
            else
            {
                CzyJuzTuByles = true;
                ZacznijWalke();
            }
            
        }

        public Przeciwnik WyborPrzeciwnika()
        {
            if(mapa.MozliwiPrzeciwnicy.Count==1)
            {
                return mapa.MozliwiPrzeciwnicy[0];
            }
            else
            {
                return mapa.MozliwiPrzeciwnicy[rand.Next(0, mapa.MozliwiPrzeciwnicy.Count - 1)];
            }
        }

        public void JuzTuByles()
        {
            Console.WriteLine("Jak przez mgłe pamiętasz stoczoną tutaj walkę. Wtedy to było bardzo ważne, teraz już wiesz, że tak naprawdę to nie było nic wielkiego.");
            fabula.ZmianaStanu(new ZmianaKratki(fabula));
        }

        public void ZacznijWalke()
        {
            mapa.fabula.ZmianaStanu(new Walka(mapa.fabula, mapa.fabula.gracz, WyborPrzeciwnika()));
        }
    }
}
