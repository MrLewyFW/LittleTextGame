using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tekstowa
{
    internal class KratkaWyjscie : Kratka
    {
        private Gracz gracz;
        public KratkaWyjscie(Fabula fabula)
        {
            this.fabula = fabula;
            mapa = fabula.mapa;
            gracz = fabula.gracz;
        }
        public override void Dzialanie()
        {
            if (gracz.TuBylemWyjscie[mapa.ID]==0)
            {
                mapa.WyjsciePierwsze();
                gracz.TuBylemWyjscie[mapa.ID] = 1;
            }
            else
            {
                mapa.WyjscieNastepne();
            }
            //tutaj walka z bosem inny stan trzeba zmienic
            fabula.ZmianaStanu(new ZmianaKratki(fabula));
        }
    }
}
