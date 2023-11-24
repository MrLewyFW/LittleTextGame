using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tekstowa
{
    internal class Levelowanie : Stan
    {
        private Gracz gracz;
        private GraczStatystyki graczStatystyki;
        private Fabula fabula;
        public Levelowanie(Gracz gracz, Fabula fabula)
        {
            this.gracz = gracz;
            graczStatystyki = new GraczStatystyki(gracz);
            this.fabula = fabula;
        }
        public override void Opis()
        {
            if (gracz.IloscNextLvl > 0)
            {
                Punkty();
            }   
        }

        public override void WykonanieKomendy(string komenda)
        {
            switch(komenda.ToLower())
            {
                case "siła":
                    ZwiekszSile();
                    Opis();
                    break;
                case "wytrzymałość":
                    ZwiekszWytrzymalosc();
                    Opis();
                    break;
                case "magia":
                    ZwiekszMagie();
                    Opis();
                    break;
                case "szczęście":
                    if (ZwiekszSczescie())
                    {
                        Opis();
                    }
                    else
                    {
                        Console.WriteLine("Nie możesz już bardziej rozwinąć swojego szczęścia");
                        OczekujNaKomende();
                    }
                    break;
                default:
                    Console.WriteLine($"Nie ma tekiej statystyki jak: {komenda}");
                    OczekujNaKomende();
                    break;
            }
        }

        public void Punkty()
        {
            Console.WriteLine("Czujesz, że wraz z nowym doświadczeniem stałeś się lepszy.");
            Console.WriteLine($"Ilość punktów umiejętności do rozdysponowania: {gracz.IloscNextLvl}");
            WyswietlStatystyki();
            OczekujNaKomende();
        }

        public void WyswietlStatystyki()
        {
            graczStatystyki.Wyswietl();
        }
        public void ZwiekszSile()
        {
            graczStatystyki.ZwiekszSile();
        }
        public void ZwiekszWytrzymalosc()
        {
            graczStatystyki.ZwiekszWytrzymalosc();
        }
        public void ZwiekszMagie()
        {
            graczStatystyki.ZwiekszMagie();
        }
        public bool ZwiekszSczescie()
        {
            return graczStatystyki.ZwiekszSzczescie();
        }
    }
}
