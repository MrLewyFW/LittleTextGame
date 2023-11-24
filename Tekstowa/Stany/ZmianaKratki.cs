using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tekstowa
{
    internal class ZmianaKratki : Stan
    {
        private Fabula fabula;
        private Gracz gracz;
        private GraczEkwipunek graczEkwipunek;
        private Mapa mapa;
        public ZmianaKratki(Fabula fabula)
        {
            this.fabula = fabula;
            gracz = fabula.gracz;
            graczEkwipunek = new GraczEkwipunek(gracz);
            mapa = fabula.mapa;
        }
        public override void Opis()
        {
            Console.WriteLine("Zrobiłeś tutaj już wszystko co mogłeś, pora ruszać. Przed tobą wybór kierunku, ale spokojnie, są tylko cztery. Góra, dół, lewo i prawo. Gdzie chciałbyś pójść?");
            OczekujNaKomende();
        }

        public override void WykonanieKomendy(string komenda)
        {
            switch(komenda.ToLower())
            {
                case "góra":
                    Gora();
                    break;
                case "dół":
                    Dol();
                    break;
                case "lewo":
                    Lewo();
                    break;
                case "prawo":
                    Prawo();
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
                    Console.WriteLine("Aktualne dostępne akcje to: góra, dół, lewo, prawo, ekwipunek, przedmiot, akcje");
                    OczekujNaKomende();
                    break;
                default:
                    Console.WriteLine($"Nie znam takiej akcji jak {komenda}, wpisz 'akcje' aby poznać dostępne komendy");
                    OczekujNaKomende();
                    break;
            }
        }

        public void Ekwipunek()
        {
            graczEkwipunek.WyswietlEkwipunek();
        }
        public void PrzedmiotRezultat()
        {
            int returned = graczEkwipunek.UzyjPrzedmiotu(Console.ReadLine());
            if (returned == 1||returned == 2)
            {
                OczekujNaKomende();
            }
            else
            {
                WykonanieKomendy("przedmiot");
            }
        }

        public void Gora()
        {
            gracz.AktualnyWiersz--;
            SprawdzCzyPozaMapa();
            Zmiana();
        }
        public void Dol()
        {
            gracz.AktualnyWiersz++;
            SprawdzCzyPozaMapa();
            Zmiana();
        }
        public void Lewo()
        {
            gracz.AktualnaKolumna--;
            SprawdzCzyPozaMapa();
            Zmiana();
        }
        public void Prawo()
        {
            gracz.AktualnaKolumna++;
            SprawdzCzyPozaMapa();
            Zmiana();
        }

        public void SprawdzCzyPozaMapa()
        {
            if(gracz.AktualnyWiersz == mapa.Wymiar)
            {
                gracz.AktualnyWiersz = 0;
            }
            if (gracz.AktualnyWiersz < 0)
            {
                gracz.AktualnyWiersz = mapa.Wymiar-1;
            }
            if (gracz.AktualnaKolumna == mapa.Wymiar)
            {
                gracz.AktualnaKolumna = 0;
            }
            if (gracz.AktualnaKolumna < 0)
            {
                gracz.AktualnaKolumna = mapa.Wymiar-1;
            }
        }

        public void Zmiana()
        {
            mapa.Rozklad[gracz.AktualnyWiersz, gracz.AktualnaKolumna].Dzialanie();
        }
    }
}
