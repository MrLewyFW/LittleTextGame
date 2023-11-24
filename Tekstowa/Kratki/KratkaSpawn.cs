using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tekstowa
{
    internal class KratkaSpawn : Kratka
    {
        private Gracz gracz;

        public KratkaSpawn(Fabula fabula)
        {
            this.fabula = fabula;
            mapa = fabula.mapa;
            gracz = fabula.gracz;
        }
        public override void Dzialanie()
        {
            if (gracz.TuBylemWejscie[mapa.ID] == 0)
            {
                mapa.WejsciePierwsze();
                gracz.TuBylemWejscie[mapa.ID] = 1;
            }
            else
            {
                mapa.WejscieNastepne();
            }
            fabula.ZmianaStanu(new ZmianaKratki(fabula));
        }
    }
}
