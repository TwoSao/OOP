using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace oop
{
    public class Õpilane: Inimene
    {
        public string Rühm_Klass;
        public string Kool;
        public Õpilane()
        {

        }
        public Õpilane(string nimi, int vanus)
        {
            Nimi = "Juku";
            Vanus = 12;
        }
        public override void Mida_teeb()
        {
            Console.WriteLine($"{Nimi} õpib koolis.");
        }
    }
}