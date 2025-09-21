namespace Geomeetriliste
{
    public class Program
    {
        public static void Main()
        {
            List<IKujund> kujundid = new List<IKujund>();

            while (true)
            {
                Console.WriteLine("\nVali kujund: 1=Ruut, 2=Ring, 3=Kolmnurk, 0=Välju");
                string valik = Console.ReadLine();

                if (valik == "0") break;

                switch (valik)
                {
                    case "1":
                        Console.Write("Sisesta küljepikkus: ");
                        double külg = double.Parse(Console.ReadLine());
                        kujundid.Add(new Ruut(külg));
                        break;

                    case "2":
                        Console.Write("Sisesta raadius: ");
                        double r = double.Parse(Console.ReadLine());
                        kujundid.Add(new Ring(r));
                        break;

                    case "3":
                        Console.Write("Sisesta kolm külge (A B C): ");
                        string[] osad = Console.ReadLine().Split();
                        double a = double.Parse(osad[0]);
                        double b = double.Parse(osad[1]);
                        double c = double.Parse(osad[2]);
                        kujundid.Add(new Kolmnurk(a, b, c));
                        break;

                    default:
                        Console.WriteLine("Tundmatu valik.");
                        break;
                }
            }

            Console.WriteLine("\n--- Kujundite tulemused ---");
            foreach (var kujund in kujundid)
            {
                Console.WriteLine($"Pindala: {kujund.ArvutaPindala():F2}, Ümbermõõt: {kujund.ArvutaÜmbermõõt():F2}");
            }
        }
    }
}