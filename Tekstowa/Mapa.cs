using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tekstowa;

namespace Tekstowa
{
    internal abstract class Mapa
    {
        private Random rand = new Random();
        private int limit = 3;
        private int eventLimit = 3;
        public int Wymiar {  get; set; }
        public int ID { get; set; }
        public Fabula fabula;
        public int IloscMozliwychPrzeciwnikow {  get; set; }
        public Kratka[,] Rozklad;
        public List<Przeciwnik> MozliwiPrzeciwnicy = new List<Przeciwnik>();
        public Kratka[] MozliweKratkiLosowanie;

        public abstract void WejsciePierwsze();
        public abstract void WejscieNastepne();
        public abstract void WyjsciePierwsze();
        public abstract void WyjscieNastepne();
        public void WylosujRozklad()
        {
            int srodek = (int)(Wymiar / 2);
            for (int i = 0; i < Wymiar; i++)
            {
                for (int j = 0; j < Wymiar; j++)
                {
                    if (i == j && i == srodek)
                    {
                        Rozklad[i, j] = new KratkaSpawn(fabula);
                    }
                    else if (i == Wymiar - 1 && j == Wymiar - 1 && limit==3)
                    {
                        Rozklad[i, j] = new KratkaWyjscie(fabula);
                    }
                    else
                    {
                        int index = rand.Next(0, limit);
                        switch(index)
                        {
                            case 0:
                                Rozklad[i, j] = new KratkaWalka(fabula);
                                break;
                            case 1:
                                if(eventLimit!=0)
                                {
                                    Rozklad[i, j] = new KratkaEvent(fabula);
                                    eventLimit--;
                                }
                                else
                                {
                                    Rozklad[i, j] = new KratkaWalka(fabula);
                                }
                                break;
                            case 2:
                                Rozklad[i, j] = new KratkaWyjscie(fabula);
                                limit--;
                                break;

                        }
                    }
                }
            }
        }
        public abstract void Dzialanie();
    }
}
