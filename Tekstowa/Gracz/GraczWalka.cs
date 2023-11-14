using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tekstowa
{
    internal class GraczWalka
    {
        private Gracz gracz;
        private Random rand = new Random();
        public int ModAP { get; set; }
        public GraczWalka(Gracz gracz)
        {
            this.gracz = gracz;
            ResetModAP();
        }

        public void Wpierdol(int zaIleWpierdol)
        {
            gracz.CurrentHP -= zaIleWpierdol;
            Console.WriteLine($"Straciłeś {zaIleWpierdol} punktów życia.\nObecna ilość punktów życia to: {gracz.CurrentHP}/{gracz.MaxHP}");
        }

        public void Unik()
        {
            Console.WriteLine("Udało ci się zrobić unik!");
        }

        public void Bron()
        {
            ModAP += 10;
            Console.WriteLine("Przygotwujesz się na atak przeciwnika.");
        }

        public void ResetModAP()
        {
            ModAP = gracz.AP;
        }

        public int ObliczWartoscAtaku()
        {
            double dodatek = rand.NextDouble();
            if (rand.Next(0, 100) > gracz.Szczescie)
                dodatek /= 2;
            int wartoscAtaku = (int)(gracz.Sila + dodatek * gracz.Sila);
            return wartoscAtaku;
        }

        public void Reakcja(int wartoscAtaku)
        {
            int unik = rand.Next(0, 100);
            if (unik < gracz.Szczescie)
            {
                Unik();
            }
            else
            {
                Wpierdol(wartoscAtaku);
            }
        }
    }
}
