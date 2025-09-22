namespace transport;

public class autos : transp, ISõiduk
{
    public double tarbimist;
    public int kilomeetrit;
    

    public void Parkla()
    {
        Console.WriteLine($"{Mark} parkib garaazhis");
    }
    public double ArvutaKulu()
    {
        return tarbimist * kilomeetrit / 100;
    }
    public double ArvutaVahemaa()
    {
        return kilomeetrit;
    }

}