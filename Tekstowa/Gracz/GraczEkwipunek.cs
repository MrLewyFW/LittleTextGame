using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tekstowa
{
    internal class GraczEkwipunek
    {
        private Gracz gracz;
        public GraczEkwipunek(Gracz gracz)
        {
            this.gracz = gracz;
        }

        public void WyswietlEkwipunek()
        {
            List<Przedmiot> pojedynczePrzedmioty = new List<Przedmiot>();
            Console.WriteLine("Oto twoje przedmioty:");
            foreach(Przedmiot przedmiot in gracz.Ekwipunek.DistinctBy(przedmiot => przedmiot.ID))
            {
                int liczba = 0;
                foreach(Przedmiot przedmiot2 in gracz.Ekwipunek)
                {
                    if (przedmiot.ID == przedmiot2.ID)
                        liczba++;
                }

                Console.WriteLine($"{liczba}x {przedmiot.Nazwa} - {przedmiot.Opis}");
            }
        }

        public int UzyjPrzedmiotu(string nazwa)
        {
            if (nazwa == "wróć")
                return 2;
            foreach(PrzedmiotUzytkowy przedmiot in gracz.Ekwipunek)
            {
                if(przedmiot.Nazwa == nazwa)
                {
                    przedmiot.Ulecz(gracz);
                    gracz.Ekwipunek.Remove(przedmiot);
                    return 1;
                }
            }
            Console.WriteLine($"Nie masz takiego przedmiotu jak: {nazwa}");
            return 0;
        }

        public void DodajPrzedmioty(List<Przedmiot> przedmioty)
        {
            for(int i=0; i<przedmioty.Count; i++)
            {
                gracz.Ekwipunek.Add(przedmioty[i]);
            }
        }
    }
}
