namespace transport;

public class Scooter : transp, ISõiduk
{
    public double BatteriMahtuvus; 
    public double EnergiaKulu;
    public int kilomeetrit;

    public void Laadi()
    {
        Console.WriteLine($"{Mark} laeb");
    }

    public double ArvutaKulu()
    {
        return EnergiaKulu * kilomeetrit / 100;
    }

    public double ArvutaVahemaa()
    {
        return kilomeetrit;
    }
}