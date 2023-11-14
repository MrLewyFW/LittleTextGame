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
            switch(komenda)
            {
                case "Siła":
                    graczStatystyki.ZwiekszSile();
                    Opis();
                    break;
                case "Wytrzymałość":
                    graczStatystyki.ZwiekszWytrzymalosc();
                    Opis();
                    break;
                case "Magia":
                    graczStatystyki.ZwiekszMagie();
                    Opis();
                    break;
                case "Szczęście":
                    graczStatystyki.ZwiekszSzczescie();
                    Opis();
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
            graczStatystyki.Wyswietl();
            OczekujNaKomende();
        }
    }
}
