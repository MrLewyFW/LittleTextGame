using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tekstowa
{
    internal class PrzeciwnikWalka
    {
        private Przeciwnik przeciwnik;
        private PrzeciwnikEkwipunek przeciwnikEkwipunek;
        private GraczWalka graczWalka;
        private Random rand = new Random();
        public bool CzyUciekl { get; set; }
        public int ModAP { get; set; }
        public int AtakProcent { get; set; }
        public int ObronaProcent { get; set; }
        public int PrzedmiotProcent { get; set; }
        public int UciekajProcent { get; set; }

        public PrzeciwnikWalka(Przeciwnik przeciwnik, GraczWalka graczWalka)
        {
            this.przeciwnik = przeciwnik;
            this.graczWalka = graczWalka;
            przeciwnikEkwipunek = new PrzeciwnikEkwipunek(przeciwnik);
            ResetModAP();
        }

        public void Atakuj(double dodatek)
        {
            int wartoscAtaku = (int)(przeciwnik.Sila + przeciwnik.Sila * dodatek) - graczWalka.ModAP;
            if (wartoscAtaku < 0)
                wartoscAtaku = 0;
            Console.WriteLine($"{przeciwnik.Nazwa} atakuje zadając {wartoscAtaku} punktów obrażeń");
            GraczReakcja(wartoscAtaku);
        }

        public void Bron()
        {
            ModAP += 5;
            Console.WriteLine($"{przeciwnik.Nazwa} przygotowuje się na twój atak!");
        }

        public void Uciekaj()
        {
            Console.WriteLine($"{przeciwnik.Nazwa} próbuje uciec!");
            int ucieczka = rand.Next(0, 100);
            if (ucieczka < przeciwnik.Szczescie)
            {
                Console.WriteLine($"{przeciwnik.Nazwa} udało się uciec!");
                CzyUciekl = true;
            }
            else
            {
                Console.WriteLine($"{przeciwnik.Nazwa} nie udało się uciec!");
            }
        }

        public void Unik()
        {
            Console.WriteLine($"Niestety {przeciwnik.Nazwa} robi unik.");
        }

        public void Wpierdol()
        {
            
            int wartoscAtaku = GraczObliczWartoscAtaku() - ModAP;
            if (wartoscAtaku < 0)
                wartoscAtaku = 0;
            Console.WriteLine($"Atakujesz {przeciwnik.Nazwa} zadając {wartoscAtaku} obrażeń.");
            if (rand.Next(0, 100) < przeciwnik.Szczescie)
            {
                Unik();
            }
            else
            {
                przeciwnik.CurrentHP -= wartoscAtaku;
                Console.WriteLine($"Pozostałe życie {przeciwnik.Nazwa}: {przeciwnik.CurrentHP}/{przeciwnik.MaxHP}");
            }
        }

        public void WyliczSzanse()
        {
            ResetModAP();
            if (przeciwnik.CurrentHP == przeciwnik.MaxHP)
            {
                ObronaProcent = 10;
                PrzedmiotProcent = 0;
                AtakProcent = 90;
                UciekajProcent = 0;
            }
            else if (przeciwnik.CurrentHP < przeciwnik.MaxHP && przeciwnik.CurrentHP > przeciwnik.MaxHP / 2)
            {
                if (przeciwnik.Przedmioty.Count > 0)
                {
                    ObronaProcent = 20;
                    PrzedmiotProcent = 10;
                    AtakProcent = 70;
                    UciekajProcent = 0;
                }
                else
                {
                    ObronaProcent = 25;
                    PrzedmiotProcent = 0;
                    AtakProcent = 75;
                    UciekajProcent = 0;
                }
            }
            else if (przeciwnik.CurrentHP < przeciwnik.MaxHP / 2 && przeciwnik.CurrentHP > przeciwnik.MaxHP * 0.1)
            {
                if (przeciwnik.Przedmioty.Count > 0)
                {
                    ObronaProcent = 25;
                    PrzedmiotProcent = 20;
                    AtakProcent = 50;
                    UciekajProcent = 5;
                }
                else
                {
                    ObronaProcent = 35;
                    PrzedmiotProcent = 0;
                    AtakProcent = 60;
                    UciekajProcent = 5;
                }
            }
            else
            {
                if (przeciwnik.Przedmioty.Count > 0)
                {
                    UciekajProcent = 30;
                    PrzedmiotProcent = 30;
                    AtakProcent = 25;
                    ObronaProcent = 15;
                }
                else
                {
                    UciekajProcent = 30;
                    PrzedmiotProcent = 0;
                    AtakProcent = 40;
                    ObronaProcent = 30;
                }
            }
            int wybor = rand.Next(1, 101);
            int czyPomoc = rand.Next(1, 101);
            double luckyX = rand.NextDouble();
            if (wybor > 0 && wybor <= AtakProcent)
            {
                if (czyPomoc < przeciwnik.Szczescie)
                    Atakuj(luckyX);
                else
                    Atakuj(luckyX / 2);
            }
            else if (wybor > AtakProcent && wybor <= AtakProcent + ObronaProcent)
            {
                Bron();
            }
            else if (wybor > AtakProcent + ObronaProcent && wybor <= AtakProcent + ObronaProcent + UciekajProcent)
            {
                Uciekaj();
            }
            else
            {
                UzyjPrzedmiotu();
            }
        }

        public void ResetModAP()
        {
            ModAP = przeciwnik.AP;
        }

        public void GraczReakcja(int wartoscAtaku)
        {
            graczWalka.Reakcja(wartoscAtaku);
        }

        public void UzyjPrzedmiotu()
        {
            przeciwnikEkwipunek.UzyjPrzedmiotu();
        }
        public int GraczObliczWartoscAtaku()
        {
            return graczWalka.ObliczWartoscAtaku();
        }
    }
}
