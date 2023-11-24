using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tekstowa
{
    internal class Gracz : Postac
    {
        public int Lvl { get; set; }
        public int NextLvl { get; set; }
        public int Exp {  get; set; }
        public int IloscNextLvl { get; set; }
        public int CurrentExp { get; set; }
        public int[] TuBylemWejscie { get; set; } = { 0, 0, 0, 0, 0 };
        public int[] TuBylemWyjscie { get; set; } = { 0, 0, 0, 0, 0 };
        public int AktualnyWiersz { get; set; }
        public int AktualnaKolumna { get; set; }

        public List<Przedmiot> Ekwipunek = new List<Przedmiot>();

        public Gracz()
        {
            Nazwa = "Cień";
            NormalneLeczenie = true;
            Exp = 99;
            Lvl = 0;
            NextLvl = 100;
            IloscNextLvl = 0;
            Wytrzymalosc = 10;
            MaxHP = Wytrzymalosc*10;
            CurrentHP = MaxHP;
            AP = 10;
            Magia = 1;
            MP = Magia*5;
            Sila = 100;
            Szczescie = 5;
            Ekwipunek.Add(new ZgnileMieso());
            Ekwipunek.Add(new ZgnileMieso());
            Ekwipunek.Add(new ZgnileMieso());
            Ekwipunek.Add(new ZgnileMieso());
            Ekwipunek.Add(new ZgnileMieso());
            Ekwipunek.Add(new ZgnileMieso());
            Ekwipunek.Add(new ZgnileMieso());
            Ekwipunek.Add(new ZgnileMieso());
            Ekwipunek.Add(new ZgnileMieso());
            Ekwipunek.Add(new ZgnileMieso());
        }

        

        
        
    }
}
