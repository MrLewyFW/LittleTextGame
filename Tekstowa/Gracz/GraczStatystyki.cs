using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tekstowa
{
    internal class GraczStatystyki
    {
        private Gracz gracz;
        public GraczStatystyki(Gracz gracz)
        {
            this.gracz = gracz;
        }

        public void Wyswietl()
        {
            Console.Write($"Twoje Statystyki:\nSiła: {gracz.Sila}\nWytrzymałość: {gracz.Wytrzymalosc}\nMagia: {gracz.Magia}\nSzczęście: {gracz.Szczescie}\n");
        }

        public void ZwiekszSile()
        {
            gracz.Sila++;
            int dodatek = gracz.Sila / 10;
            gracz.AP = 10 + dodatek;
            gracz.IloscNextLvl--;
        }
        public void ZwiekszWytrzymalosc()
        {
            gracz.Wytrzymalosc++;
            gracz.MaxHP = gracz.Wytrzymalosc * 10;
            gracz.IloscNextLvl--;
        }
        public void ZwiekszMagie()
        {
            gracz.Magia++;
            gracz.MP = gracz.Magia * 5;
            gracz.IloscNextLvl--;
        }
        public bool ZwiekszSzczescie()
        {
            if(gracz.Szczescie<30)
            {
                gracz.Szczescie++;
                gracz.IloscNextLvl--;
                return true;
            }
            return false;
            
        }
    }
}
