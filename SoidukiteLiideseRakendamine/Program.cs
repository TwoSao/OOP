namespace SoidukiteIideseRakendamine
{
    public class Programm
    {
        static void Main(string[] args)
        {
            List<ISõiduk> list = new List<ISõiduk>();

            while (true)
            {
                Console.WriteLine("Sisesta number: \n 1 - Auto \n 2 - Jalgart \n 3 - Buss \n 4 - Tõukeratas \n 0 - Exit");
                string number = Console.ReadLine();
                if (number == "0")
                {
                    break;
                }
                else if (number == "1")
                {
                    try
                    {
                        autos auto = new autos();
                        Console.WriteLine("Sisesta auto mark: ");
                        auto.Mark = Console.ReadLine();
                        Console.WriteLine("Sisesta tarbimist: ");
                        auto.tarbimist = double.Parse(Console.ReadLine());
                        Console.WriteLine("Sisesta auto kilometrit: ");
                        auto.kilomeetrit = Convert.ToInt32(Console.ReadLine());
                        
                        list.Add(auto);
                    }
                    catch
                    {
                        Console.WriteLine("Viga andmete sisestamisel!");
                    }
                }
                else if (number == "2")
                {
                    try
                    {
                        Jalgart jalgart = new Jalgart();
                        Console.WriteLine("Sisesta jalgat mark: ");
                        jalgart.Mark = Console.ReadLine();
                        Console.WriteLine("Sisesta kilo_arv: ");
                        jalgart.kilo_arv = Int32.Parse(Console.ReadLine());
                        list.Add(jalgart);
                    }
                    catch
                    {
                        Console.WriteLine("Viga andmete sisestamisel!");
                    }
                }
                
                else if (number == "3")
                {
                    try
                    {
                        Console.WriteLine("Sisesta KütusekuluLiitrites: ");
                        double KütusekuluLiitrites = double.Parse(Console.ReadLine());
                        Console.WriteLine("Sisesta VahemaaKm: ");
                        double VahemaaKm = double.Parse(Console.ReadLine());
                        Console.WriteLine("Sisesta ReisijateArv: ");
                        int ReisijateArv = int.Parse(Console.ReadLine());
                        list.Add(new Buss(KütusekuluLiitrites, VahemaaKm, ReisijateArv));
                    }
                    catch
                    {
                        Console.WriteLine("Viga andmete sisestamisel!");
                    }
                }
                else if (number == "4")
                {
                    try
                    {
                        Scooter scooter = new Scooter();
                        Console.WriteLine("Sisesta tõukeratta mark: ");
                        scooter.Mark = Console.ReadLine();
                        Console.WriteLine("Sisesta aku mahtuvus (kWh): ");
                        scooter.BatteriMahtuvus = double.Parse(Console.ReadLine());
                        Console.WriteLine("Sisesta energia kulu (kWh/100km): ");
                        scooter.EnergiaKulu = double.Parse(Console.ReadLine());
                        Console.WriteLine("Sisesta kilomeetrit: ");
                        scooter.kilomeetrit = Convert.ToInt32(Console.ReadLine());
                        
                        list.Add(scooter);
                    }
                    catch
                    {
                        Console.WriteLine("Viga andmete sisestamisel!");
                    }
                }
                

            }

            Console.WriteLine("\n-- Transport tulemused --");
            foreach (var k in list)
            {
                Console.WriteLine($"Transport: {k.GetType().Name}, ArvutaVahemaa: {k.ArvutaVahemaa():F2}, ArvutaKulu: {k.ArvutaKulu():F2}");
            }
        }
    }
}