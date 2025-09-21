using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop
{
    public class Töötaja : Inimene
    {
        public string Ametikoht = "Keevitaja";
        public double Tunnitasu = 15.5;
        public int Tunnid { get; set; }
        
        public void Töötan()
        {
            Console.WriteLine($"{Nimi} töötan ametikohal {Ametikoht}.");
        }
        public override void Mida_teeb()
        {
            Console.WriteLine($"{Nimi} töötab ametikohal.");
        }

        public double ArvutaPalk()
        {
            return Tunnitasu * Tunnid;
        }
    }
}