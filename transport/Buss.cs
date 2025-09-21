namespace transport
{
    public class Buss : ISõiduk
    {
        public double KütusekuluLiitrites { get; set; }
        public double VahemaaKm { get; set; }
        public int ReisijateArv { get; set; }

        public Buss(double kütusekuluLiitrites, double vahemaaKm, int reisijateArv)
        {
            KütusekuluLiitrites = kütusekuluLiitrites;
            VahemaaKm = vahemaaKm;
            ReisijateArv = reisijateArv;
        }

        public double ArvutaKulu()
        {
            if (ReisijateArv == 0) return 0;
            return (VahemaaKm * KütusekuluLiitrites / 100) / ReisijateArv;
        }

        public double ArvutaVahemaa()
        {
            return VahemaaKm;
        }
    }
}

