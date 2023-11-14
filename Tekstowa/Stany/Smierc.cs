using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tekstowa
{
    internal class Smierc : Stan
    {
        private Gracz gracz;
        private Fabula fabula;
        public Smierc(Fabula fabula, Gracz gracz)
        {
            this.fabula = fabula;
            this.gracz = gracz;
        }
        public override void Opis()
        {
            Console.WriteLine("Niestety przeciwnik okazał się silniejszy. Odczuwasz ogromny ból, który powoli niknie we wszechogarniającej cię ciemności. Umarłeś.");
            DodajExp();
            OczekujNaKomende();
        }

        public override void WykonanieKomendy(string komenda)
        {
            Console.WriteLine("koniec gry xD");
        }

        public void DodajExp()
        {
            gracz.Exp += gracz.CurrentExp;
            gracz.CurrentExp = 0;
            if(gracz.IloscNextLvl>0)
            {
                gracz.Lvl += gracz.IloscNextLvl;
                fabula.ZmianaStanu(new Levelowanie(gracz, fabula));
            }
        }
    }
}
