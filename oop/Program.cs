namespace oop
{
    public class Program
    {
        static void Main(string[] args)
        {
            
            //Inimene inimene1 = new Inimene();

            Õpilane inimene1 = new Õpilane();
            inimene1.Nimi = "Juku";
            inimene1.Vanus = 12;
            inimene1.Tervita();

            Õpilane inimene2 = new Õpilane("Kati", 28);
            inimene2.Mida_teeb();

            Töötaja töötaja1 = new Töötaja();
            töötaja1.Nimi = "Mati";
            töötaja1.Vanus = 45;
            töötaja1.Ametikoht = "Autojuht";
            töötaja1.Tervita();
            töötaja1.Töötan();
            töötaja1.Tunnid = 160;
            double palk = töötaja1.ArvutaPalk();
            
            //1 ülesanne
            //3- Tee ise vähemalt 2 alamklassi ja kasuta neid siin
            //4.5- Tee enda põhiklass ja 2 alamklassi ning kasuta neid siin
            //2 ülesanne
            /*- Tee enda põhiklass(Loom) ja 2-3 alamklassi(Kass, Koer, Lehm)
            ning kasuta abstraktset meetodit*/

            double saldo = töötaja1.Konto.Saldo;
            töötaja1.Konto.LisaRaha(200);
            Console.WriteLine($"Algne konto {töötaja1.Konto.Saldo} eurot");
            saldo += palk;
            Console.WriteLine($"Alge konto {saldo}");
            

        }
    }
}
