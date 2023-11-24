using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tekstowa
{
    internal class Postac
    {
        public string Nazwa { get; set; }
        public int MaxHP { get; set; }
        public int CurrentHP { get; set; }
        public int AP { get; set; }
        public int MP { get; set; }
        public int Sila { get; set; }
        public int Wytrzymalosc { get; set; }
        public int Magia { get; set; }
        public int Szczescie { get; set; }
        public bool NormalneLeczenie { get; set; }
    }
}
