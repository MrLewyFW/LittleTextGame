using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tekstowa;

namespace Tekstowa
{
    internal class Polany : Mapa
    {
        private Random rand = new Random();
        public Polany(Fabula fabula) 
        {
            ID = 0;
            this.fabula = fabula;
            Wymiar = 5;
            IloscMozliwychPrzeciwnikow = 1;
            Rozklad = new Kratka[Wymiar, Wymiar];
            MozliwiPrzeciwnicy.Add(new Zombie());
            
        }

        public override void Dzialanie()
        {
            MozliweKratki();
            WylosujRozklad();
            Start();
        }

        public override void WejscieNastepne()
        {
            Console.WriteLine("Jesteś tu znowu.");
        }

        public override void WejsciePierwsze()
        {
            Console.WriteLine("Pierwszy raz tu jesteś.");
        }

        public override void WyjscieNastepne()
        {
            Console.WriteLine("Idziesz na bossa, znowu.");
        }

        public override void WyjsciePierwsze()
        {
            Console.WriteLine("Pierwszy raz idziesz na bossa.");
        }

        public void Start()
        {
            int srodek = (int)(Wymiar / 2);
            fabula.gracz.AktualnyWiersz = srodek;
            fabula.gracz.AktualnaKolumna = srodek;
            Rozklad[srodek, srodek].Dzialanie();
        }

        public void MozliweKratki()
        {
            MozliweKratkiLosowanie = new Kratka[] { new KratkaWalka(fabula), new KratkaEvent(fabula), new KratkaWyjscie(fabula) };
        }
    }
}
