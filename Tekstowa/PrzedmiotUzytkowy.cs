using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tekstowa
{
    internal abstract class PrzedmiotUzytkowy : Przedmiot
    {
        public int IleOdnawia { get; set; }

        public void Ulecz(Postac postac)
        {
            if(postac.Nazwa=="Zombie")
            {
                int minusIleOdnawia = IleOdnawia * -1;
                postac.CurrentHP += minusIleOdnawia;
                if(postac.CurrentHP>postac.MaxHP)
                {
                    postac.CurrentHP = postac.MaxHP;
                }
                Console.WriteLine($"{postac.Nazwa} używa przedmiotu: {Nazwa} odnawiając {minusIleOdnawia} HP. {postac.CurrentHP}/{postac.MaxHP}");
            }
            else
            {
                postac.CurrentHP += IleOdnawia;
                if (postac.CurrentHP > postac.MaxHP)
                {
                    postac.CurrentHP = postac.MaxHP;
                }
                Console.WriteLine($"{postac.Nazwa} używa przedmiotu: {Nazwa} odnawiając {IleOdnawia} HP. {postac.CurrentHP}/{postac.MaxHP}");
            }
            
        }

    }
}
