namespace transport
{
    public class Jalgart : transp, ISõiduk
    {
        public int kilo_arv { get; set; }
        public double ArvutaKulu()
        {
            return 0;
        }
        public double ArvutaVahemaa()
        {
            return kilo_arv;
        }



    }
}

