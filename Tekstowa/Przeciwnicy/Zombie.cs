using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Tekstowa
{
    internal class Zombie : Przeciwnik
    {
        public Zombie()
        {
            Nazwa = "Zombie";
            NormalneLeczenie = false;
            Exp = 100;
            MaxHP = 40;
            CurrentHP = MaxHP;
            AP = 10;
            MP = 0;
            Sila = 10;
            Wytrzymalosc = 5;
            Magia = 0;
            Szczescie = 5;
            Loot.Add(new ZgnileMieso()); Loot.Add(new ZlotaMoneta());
            Przedmioty.Add(new ZgnileMieso()); Przedmioty.Add(new ZgnileMieso());
        }
    }
}
