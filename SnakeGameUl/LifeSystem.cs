using System;

namespace SnakeGameUl
{
    /// <summary>
    /// Система жизней - управляет количеством жизней игрока
    /// Позволяет продолжить игру после столкновения
    /// </summary>
    public class LifeSystem
    {
        public int Lives { get; private set; }
        public int MaxLives { get; private set; }
        private int mapWidth, mapHeight, offsetY;

        public LifeSystem(int initialLives = 3)
        {
            Lives = initialLives;
            MaxLives = initialLives;
        }

        /// <summary>
        /// Отнимает одну жизнь
        /// </summary>
        /// <returns>true если жизни еще есть, false если игра окончена</returns>
        public bool LoseLife()
        {
            Lives--;
            return Lives > 0;
        }

        /// <summary>
        /// Добавляет одну жизнь (максимум до MaxLives)
        /// </summary>
        public void GainLife()
        {
            if (Lives < MaxLives)
                Lives++;
        }

        /// <summary>
        /// Проверяет, есть ли еще жизни
        /// </summary>
        public bool HasLives() => Lives > 0;

        /// <summary>
        /// Отображает количество жизней на экране
        /// </summary>
        public void DisplayLives()
        {
            Console.SetCursorPosition(60, 1);
            Console.Write($"Elud: ");
            
            // Отображаем жизни как сердечки
            for (int i = 0; i < MaxLives; i++)
            {
                if (i < Lives)
                    Console.Write("♥ ");
                else
                    Console.Write("♡ ");
            }
            Console.Write("   "); // Очищаем остаток
        }

        /// <summary>
        /// Показывает сообщение о потере жизни
        /// </summary>
        public void ShowLifeLostMessage()
        {
            Console.SetCursorPosition(25, 12);
            Console.Write($"KAOTASID ELU! Jäänud: {Lives}");
            System.Threading.Thread.Sleep(1500);
            
            // Очищаем сообщение
            Console.SetCursorPosition(25, 12);
            Console.Write(new string(' ', 30));
        }

        /// <summary>
        /// Показывает сообщение о получении дополнительной жизни
        /// </summary>
        public void ShowLifeGainedMessage()
        {
            Console.SetCursorPosition(25, 12);
            Console.Write("LISAELU SAADUD!");
            System.Threading.Thread.Sleep(1000);
            
            // Очищаем сообщение
            Console.SetCursorPosition(25, 12);
            Console.Write(new string(' ', 20));
        }

        /// <summary>
        /// Сбрасывает жизни до максимального значения
        /// </summary>
        public void Reset()
        {
            Lives = MaxLives;
        }
    }
}