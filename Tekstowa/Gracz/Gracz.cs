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
        public int AP { get; set; }
        public int MP { get; set; }
        public int Sila { get; set; }
        public int Wytrzymalosc { get; set; }
        public int Magia { get; set; }
        public int Szczescie { get; set; }
        public List<Przedmiot> Ekwipunek = new List<Przedmiot>();

        public Gracz()
        {
            Nazwa = "Cień";
            Exp = 99;
            Lvl = 0;
            NextLvl = 100;
            IloscNextLvl = 0;
            MaxHP = 100;
            CurrentHP = MaxHP;
            AP = 10;
            MP = 5;
            Sila = 100;
            Wytrzymalosc = 10;
            Magia = 1;
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
