using System;

namespace SnakeGameUl
{
    public class LifeSystem
    {
        public int Lives { get; private set; }
        public int MaxLives { get; private set; }

        public LifeSystem(int initialLives = 3)
        {
            Lives = initialLives;
            MaxLives = initialLives;
        }

        public bool LoseLife()
        {
            Lives--;
            return Lives > 0;
        }

        public void GainLife()
        {
            if (Lives < MaxLives)
                Lives++;
        }

        public bool HasLives() => Lives > 0;

        public void DisplayLives()
        {
            Console.SetCursorPosition(60, 1);
            Console.Write($"Elud: ");
            
            for (int i = 0; i < MaxLives; i++)
            {
                if (i < Lives)
                    Console.Write("♥ ");
                else
                    Console.Write("♡ ");
            }
            Console.Write("   ");
        }

        public void ShowLifeLostMessage()
        {
            Console.SetCursorPosition(25, 12);
            Console.Write($"KAOTASID ELU! Jäänud elusid: {Lives}");
            System.Threading.Thread.Sleep(1500);
            
            Console.SetCursorPosition(25, 12);
            Console.Write(new string(' ', 35));
        }

        public void ShowLifeGainedMessage()
        {
            Console.SetCursorPosition(25, 12);
            Console.Write("LISAELU SAADUD!");
            System.Threading.Thread.Sleep(1000);
            
            Console.SetCursorPosition(25, 12);
            Console.Write(new string(' ', 20));
        }

        public void Reset()
        {
            Lives = MaxLives;
        }
    }
}