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
            switch (komenda)
            {
                case "atak":
                    przeciwnikWalka.Wpierdol();
                    if (przeciwnik.CurrentHP <= 0)
                    {
                        fabula.ZmianaStanu(new KoniecWalki(fabula, gracz, przeciwnik));
                    }
                    else
                    {
                        Console.WriteLine($"Teraz {przeciwnik.Nazwa} wykonuje ruch!");
                        przeciwnikWalka.WyliczSzanse();
                        SprawdzCzySmierc();
                    }  
                    break;
                case "bron":
                    graczWalka.Bron();
                    przeciwnikWalka.WyliczSzanse();
                    SprawdzCzySmierc();
                    break;
                case "ekwipunek":
                    graczEkwipunek.WyswietlEkwipunek();
                    OczekujNaKomende();
                    break;
                case "przedmiot":
                    Console.WriteLine("Wpisz nazwę przedmiotu, którego chcesz użyć:");
                    int returned = graczEkwipunek.UzyjPrzedmiotu(Console.ReadLine());
                    if (returned==1)
                    {
                        przeciwnikWalka.WyliczSzanse();
                        SprawdzCzySmierc();
                    }
                    else if(returned==2)
                    {
                        OczekujNaKomende();
                    }
                    else
                    {
                        WykonanieKomendy("przedmiot");
                    }
                    break;
                case "komendy":
                    Console.WriteLine("Aktualne dostępne komendy to: atak, bron, ekwipunek, przedmiot, komendy");
                    OczekujNaKomende();
                    break;
                default:
                    Console.WriteLine($"Nie znam takiej komendy jak {komenda}, wpisz 'komendy' aby poznać dostępne komendy");
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
                fabula.ZmianaStanu(new Smierc(fabula, gracz));
            else
            {
                graczWalka.ResetModAP();
                OczekujNaKomende();
            }
                
        }
    }
}
