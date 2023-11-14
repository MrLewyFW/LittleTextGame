using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tekstowa
{
    internal abstract class Stan
    {
        public void OczekujNaKomende()
        {
            WykonanieKomendy(Console.ReadLine());
        }
        public abstract void WykonanieKomendy(string komenda);
        public abstract void Opis();
    }
}
