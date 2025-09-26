using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace SnakeGameUl
{
    /// <summary>
    /// Главный класс приложения - точка входа и управление игровым процессом
    /// Отвечает за:
    /// - Инициализацию игры
    /// - Основной игровой цикл
    /// - Обработку пользовательского ввода
    /// - Управление сложностью игры
    /// </summary>
    class Program
    {
        /// <summary>
        /// Главная функция приложения
        /// Управляет полным жизненным циклом игры:
        /// 1. Инициализация звуков
        /// 2. Ввод имени игрока
        /// 3. Выбор сложности
        /// 4. Создание игровых объектов
        /// 5. Основной игровой цикл
        /// 6. Обработка окончания игры
        /// </summary>
        static void Main(string[] args)
        {
            // Инициализация звуковой системы
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            MusicManager.Initialize(basePath);
            MusicManager.PlayMenuMusic();

            // Основной цикл игры (можно перезапускать)
            while (true)
            {
                Console.Clear();

                int gameOffsetY = 5; // Отступ сверху для статистики

                // Ввод имени игрока
                Console.WriteLine("Sisesta nimi: ");
                string playerName = Console.ReadLine();

                Console.Clear();

                // Выбор уровня сложности
                Console.WriteLine("Vali raskusaste:");
                Console.WriteLine("1 - Lihtne (aeglane)");
                Console.WriteLine("2 - Keskmine (keskmine kiirus)");
                Console.WriteLine("3 - Raske (kiire + rohkem seinu)");

                int difficulty = 1;
                while (true)
                {
                    var key = Console.ReadKey(true);
                    if (key.KeyChar >= '1' && key.KeyChar <= '3')
                    {
                        difficulty = key.KeyChar - '0';
                        break;
                    }
                }

                // Остановка меню музыки при старте игры
                MusicManager.StopMenuMusic();

                Console.Clear();

                // Настройка скорости в зависимости от сложности
                int baseSpeed = difficulty == 1 ? 200 : difficulty == 2 ? 120 : 80;

                // Создание игрока и змейки
                Point startPoint = new Point(4, 5 + gameOffsetY, '*');
                Player player = new Player(playerName, startPoint, Direction.RIGHT);
                player.Stats.Level = difficulty;

                // Загрузка и отображение статистики
                player.Stats.LoadStats();
                player.Stats.PrintStats();

                // Создание стен и препятствий
                Walls walls = new Walls(80, 25, gameOffsetY);

                // Добавление препятствий на сложном уровне
                if (difficulty == 3)
                {
                    walls.AddObstacle(20, 8 + gameOffsetY, 7);
                    walls.AddObstacle(40, 10 + gameOffsetY, 5);
                    walls.AddObstacle(60, 8 + gameOffsetY, 7);
                }

                // Отрисовка начального состояния игры
                walls.Draw();
                player.Snake.Draw();

                // Создание и отображение первой еды
                FoodCreator foodCreator = new FoodCreator(80, 25, '$', gameOffsetY);
                Point food = foodCreator.CreateFood();
                food.Draw();

                // Основной игровой цикл
                while (true)
                {
                    // Проверка столкновений (со стенами или с собой)
                    if (walls.IsHit(player.Snake) || player.Snake.IsHitTail())
                    {
                        MusicManager.PlayLoseSound();
                        player.Stats.SaveStats();
                        player.Stats.SaveToLeaderboard();
                        break;
                    }
                    // Проверка поедания еды
                    if (player.Snake.Eat(food))
                    {
                        MusicManager.PlayEatSound();
                        player.Stats.UpdateScore();
                        player.Stats.UpdateHighScore();
                        player.Stats.PrintStats();
                        food = foodCreator.CreateFood();
                        food.Draw();
                    }
                    else
                    {
                        // Обычное движение змейки
                        player.Snake.Move();
                    }

                    // Управление скоростью (ускорение по мере роста)
                    int currentSpeed = Math.Max(30, baseSpeed - (player.Stats.Length - 4) * 3);
                    Thread.Sleep(currentSpeed);
                    
                    // Обработка нажатий клавиш
                    if (Console.KeyAvailable)
                    {
                        ConsoleKeyInfo key = Console.ReadKey(true);
                        player.Snake.HandleKey(key.Key);
                    }
                }

                // Отображение экрана окончания игры
                WriteGameOver();
                Stats.ShowLeaderboard();

                // Предложение повторить игру
                Console.WriteLine("\nKas soovite uuesti mängida? (y/n)");
                var answer = Console.ReadKey().KeyChar;
                if (answer == 'y' || answer == 'Y')
                {
                    // Возвращаем музыку меню
                    MusicManager.PlayMenuMusic();
                }
                else
                {
                    MusicManager.StopMenuMusic();
                    break;
                }
            }
        }

        /// <summary>
        /// Отображение экрана окончания игры
        /// Очищает экран и выводит сообщение "GAME OVER"
        /// </summary>
        static void WriteGameOver()
        {
            int xOffset = 25;
            int yOffset = 11;
            Console.Clear();
            Console.SetCursorPosition(xOffset, yOffset++);
            WriteText("!-----------------!", xOffset, yOffset++);
            WriteText("GAME OVER", xOffset + 1, yOffset++);
            yOffset++;
            WriteText("!-----------------!", xOffset, yOffset++);
        }

        /// <summary>
        /// Вспомогательный метод для вывода текста в заданной позиции
        /// </summary>
        /// <param name="text">Текст для вывода</param>
        /// <param name="xOffset">Позиция по X</param>
        /// <param name="yOffset">Позиция по Y</param>
        static void WriteText(String text, int xOffset, int yOffset)
        {
            Console.SetCursorPosition(xOffset, yOffset);
            Console.WriteLine(text);
        }
    }
}
