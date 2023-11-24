using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Tekstowa
{
    internal class Walka : Stan
    {
        private Gracz gracz;
        private GraczWalka graczWalka;
        private GraczEkwipunek graczEkwipunek;
        private PrzeciwnikWalka przeciwnikWalka;
        private Fabula fabula;
        private Przeciwnik przeciwnik;

        public Walka(Fabula fabula, Gracz gracz, Przeciwnik przeciwnik)
        {
            this.fabula = fabula;
            this.gracz = gracz;
            graczWalka = new GraczWalka(gracz);
            graczEkwipunek = new GraczEkwipunek(gracz);
            this.przeciwnik = przeciwnik;
            przeciwnikWalka = new PrzeciwnikWalka(przeciwnik, graczWalka);

        }
        public override void WykonanieKomendy(string komenda)
        {
            switch (komenda.ToLower())
            {
                case "atak":
                    Atak();
                    SprawdzCzyKoniecWalki();
                    break;
                case "obrona":
                    Obrona();
                    PrzeciwnikTura();
                    SprawdzCzySmierc();
                    break;
                case "ekwipunek":
                    Ekwipunek();
                    OczekujNaKomende();
                    break;
                case "przedmiot":
                    Console.WriteLine("Wpisz nazwę przedmiotu, którego chcesz użyć:");
                    PrzedmiotRezultat();
                    break;
                case "akcje":
                    Console.WriteLine("Aktualne dostępne akcje to: atak, obrona, ekwipunek, przedmiot, akcje");
                    OczekujNaKomende();
                    break;
                default:
                    Console.WriteLine($"Nie znam takiej akcji jak {komenda}, wpisz 'akcje' aby poznać dostępne komendy");
                    OczekujNaKomende();
                    break;

            }
        }

        public override void Opis()
        {
            Console.WriteLine($"Nagle jak spod ziemi wyłania się przed tobą {przeciwnik.Nazwa}. Musisz walczyć by przetrwać!");
            OczekujNaKomende();
        }

        public void SprawdzCzySmierc()
        {
            if (gracz.CurrentHP <= 0)
            {
                Smierc();
            }
            else
            {
                ResetMod();
                OczekujNaKomende();
            }
                
        }

        public void SprawdzCzyKoniecWalki()
        {
            if (przeciwnik.CurrentHP <= 0 || przeciwnikWalka.CzyUciekl)
            {
                ResetMod();
                KoniecWalki();
            }
            else
            {
                PrzeciwnikTura();
                SprawdzCzySmierc();
            }
        }

        public void PrzedmiotRezultat()
        {
            int returned = graczEkwipunek.UzyjPrzedmiotu(Console.ReadLine());
            if (returned == 1)
            {
                SprawdzCzySmierc();
                PrzeciwnikTura();
                SprawdzCzySmierc();
            }
            else if (returned == 2)
            {
                OczekujNaKomende();
            }
            else
            {
                WykonanieKomendy("przedmiot");
            }
        }

        public void PrzeciwnikTura()
        {
            Console.WriteLine($"Teraz {przeciwnik.Nazwa} wykonuje ruch!");
            przeciwnikWalka.WyliczSzanse();
        }

        public void KoniecWalki()
        {
            fabula.ZmianaStanu(new KoniecWalki(fabula, gracz, przeciwnik, przeciwnikWalka.CzyUciekl));
        }

        public void Smierc()
        {
            fabula.ZmianaStanu(new Smierc(fabula, gracz));
        }

        public void Obrona()
        {
            graczWalka.Bron();
        }
        
        public void Atak()
        {
            przeciwnikWalka.Wpierdol();
        }

        public void Ekwipunek()
        {
            graczEkwipunek.WyswietlEkwipunek();
        }
        public void ResetMod()
        {
            graczWalka.ResetModAP();
        }
    }
}
