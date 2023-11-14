using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tekstowa
{
    internal class PrzeciwnikEkwipunek
    {
        Random rand = new Random();
        private Przeciwnik przeciwnik;

        public PrzeciwnikEkwipunek(Przeciwnik przeciwnik)
        {
            this.przeciwnik = przeciwnik;
        }
        public void UzyjPrzedmiotu()
        {
            int wyborPrzedmiotu;
            if (przeciwnik.Przedmioty.Count == 1)
            {
                wyborPrzedmiotu = 0;
            }
            else
            {
                wyborPrzedmiotu = rand.Next(0, przeciwnik.Przedmioty.Count - 1);
            }
            przeciwnik.Przedmioty[wyborPrzedmiotu].Ulecz(przeciwnik);
            przeciwnik.Przedmioty.RemoveAt(wyborPrzedmiotu);
        }
        public List<Przedmiot> PrzekazPrzedmiot()
        {
            List<Przedmiot> przedmioty = new List<Przedmiot>();
            for (int i = 0; i < przeciwnik.Loot.Count; i++)
            {
                if (rand.Next(0, 100) < 50)
                {
                    przedmioty.Add(przeciwnik.Loot[i]);
                }
            }
            return przedmioty;
        }
    }
}
