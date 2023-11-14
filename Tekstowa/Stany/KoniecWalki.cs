using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Tekstowa
{
    internal class KoniecWalki : Stan
    {
        private GraczEkwipunek graczEkwipunek;
        private Gracz gracz;
        private PrzeciwnikEkwipunek przeciwnikEkwipunek;
        private Przeciwnik przeciwnik;
        private Fabula fabula;
        public KoniecWalki(Fabula fabula, Gracz gracz, Przeciwnik przeciwnik)
        {
            this.fabula = fabula;
            graczEkwipunek = new GraczEkwipunek(gracz);
            this.gracz = gracz;
            przeciwnikEkwipunek = new PrzeciwnikEkwipunek(przeciwnik);
            this.przeciwnik = przeciwnik;

        }
        public override void Opis()
        {
            Console.WriteLine("Twój przeciwnik jest już tylko wspomnieniem, zniknął tak szybko jak się pojawił. A może nigdy nie istniał?");
            Loot();
            OczekujNaKomende();
        }

        public override void WykonanieKomendy(string komenda)
        {
            fabula.ZmianaStanu(new Walka(fabula, gracz, new Zombie()));
        }

        public void Loot()
        {
            gracz.CurrentExp += przeciwnik.Exp;
            Console.WriteLine($"Zdobyłeś {przeciwnik.Exp} punktów doświadczenia.");
            if(gracz.Exp+gracz.CurrentExp>=gracz.NextLvl)
            {
                gracz.IloscNextLvl++;
                gracz.NextLvl += gracz.NextLvl+(int)(0.2 * gracz.NextLvl);
            }
            Console.WriteLine($"Twój poziom: {gracz.Lvl}. Ilość poziomów, które zdobędziesz po śmierci: {gracz.IloscNextLvl}. Ilość doświadczenia do następnego poziomu: {gracz.NextLvl-(gracz.Exp+gracz.CurrentExp)}.");
            List<Przedmiot> nowePrzedmioty = przeciwnikEkwipunek.PrzekazPrzedmiot();
            if (nowePrzedmioty.Count>0)
            {
                Console.WriteLine("Przeciwnik zostawił po sobie kilka przedmiotów. Postanowiłeś je zebrać.");
                graczEkwipunek.DodajPrzedmioty(nowePrzedmioty);
                for(int i=0; i<nowePrzedmioty.Count; i++)
                {
                    
                    Console.WriteLine($"{nowePrzedmioty[i].Nazwa} - {nowePrzedmioty[i].Opis}");
                }
            }
            else
            {
                Console.WriteLine("Przeciwnik nic po sobie nie zostawił.");
            }
        }
    }
}
