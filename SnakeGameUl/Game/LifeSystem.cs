using System;

namespace SnakeGameUl.Game
{
    // Elude süsteem - haldab mängija elusid ja nende kuvamist
    public class LifeSystem
    {
        public int Lives { get; private set; }    // Praegused elud
        public int MaxLives { get; private set; } // Maksimaalsed elud

        // Konstruktor - seadistab algse elude arvu
        public LifeSystem(int initialLives = 3)
        {
            Lives = initialLives;
            MaxLives = initialLives;
        }

        // Kaotab ühe elu ja tagastab, kas mäng jätkub
        public bool LoseLife()
        {
            if (Lives > 0)
                Lives--;
            return Lives > 0;
        }

        // Lisab ühe elu ja uuendab maksimumi
        public void GainLife()
        {
            Lives++;
            if (Lives > MaxLives)
                MaxLives = Lives;
        }

        // Kontrollib, kas on veel elusid alles
        public bool HasLives() => Lives > 0;

        // Kuvab elud südamete kujul ekraani ülaosas
        public void DisplayLives()
        {
            try
            {
                Console.SetCursorPosition(60, 1);
                Console.Write($"Elud: ");
                
                // Näitame kõiki teenitud elusid
                for (int i = 0; i < MaxLives; i++)
                {
                    if (i < Lives)
                        Console.Write("♥ ");
                    else
                        Console.Write("♡ ");
                }
                Console.Write($" ({Lives}/{MaxLives})   ");
            }
            catch (ArgumentOutOfRangeException)
            {
                // Ignoreeri konsooliakna piiride ületamist
            }
        }

        // Kuvab elu kaotamise sõnumi ajutiselt
        public void ShowLifeLostMessage()
        {
            Console.SetCursorPosition(25, 12);
            Console.Write($"KAOTASID ELU! Jäänud elusid: {Lives}");
            System.Threading.Thread.Sleep(1500);
            
            Console.SetCursorPosition(25, 12);
            Console.Write(new string(' ', 35));
        }

        // Kuvab lisaelu saamise sõnumi ajutiselt
        public void ShowLifeGainedMessage()
        {
            Console.SetCursorPosition(25, 12);
            Console.Write("LISAELU SAADUD!");
            System.Threading.Thread.Sleep(1000);
            
            Console.SetCursorPosition(25, 12);
            Console.Write(new string(' ', 20));
        }

        // Lähtestab elud maksimaalse väärtuseni
        public void Reset()
        {
            Lives = MaxLives;
        }
    }
}