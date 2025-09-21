namespace oop

{
    public interface ITööline
    {
        double ArvutaPalk();
        
    }
    public class Pank
    {
        private double saldo;
        
        public double Saldo
        {
            get { return saldo; }
            set
            {
                if (value > 0)
                {
                    saldo = value;
                }
            }
        }

        

        public void LisaRaha(double summa)
        {
            if (summa > 0)
            {
                saldo += summa;
            }

            Console.WriteLine($"Teie kontol on {saldo} eurot");
        }
        public void VõtaRaha(double summa)
        {
            if (summa > 0 && summa <= saldo)
            {
                saldo -= summa;
            }
            else
            {
                Console.WriteLine("Võta raha ei saa teha");
            }
            Console.WriteLine($"Teie kontol on {saldo} eurot");
        }
    }
}

