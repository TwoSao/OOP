namespace ul2;

abstract class Instrument
{
    private string nimi;
    public string Nimi
    {
        get { return nimi; }
        set { nimi = value; }
    }

    public Instrument(String nimi)
    {
        Nimi = nimi;
    }

    public abstract string Play();


}