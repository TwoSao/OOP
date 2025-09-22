namespace SoidukiteIideseRakendamine
{
    public class transp
    { 
        public string Mark;
        public int Kiirus;

        public void Liggu()
        {
            Console.WriteLine($"{Mark} liigub kiirusega {Kiirus} km/h");
        }
    }
}

