using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tekstowa
{
    internal class KratkaEvent : Kratka
    {
        private bool CzyJuzTuByles = false;
        public KratkaEvent(Fabula fabula)
        {
            this.fabula = fabula;
            mapa = fabula.mapa;
        }
        public override void Dzialanie()
        {
            if(CzyJuzTuByles)
            {
                JuzTuByles();
            }
            else
            {
                Console.WriteLine("Tu jest event xD");
                CzyJuzTuByles = true;
            }
            fabula.ZmianaStanu(new ZmianaKratki(fabula));
        }
        public void JuzTuByles()
        {
            Console.WriteLine("Ty był event, ale już go nie ma xD");
        }
    }
}
