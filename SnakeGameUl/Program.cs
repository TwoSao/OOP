using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace SnakeGameUl
{
    class Program
    {
        static void Main(string[] args)
        {
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            MusicManager.Initialize(basePath);
            MusicManager.PlayMenuMusic();

            while (true)
            {
                Console.Clear();

                int gameOffsetY = 5;

                Console.WriteLine("Sisesta oma nimi: ");
                string playerName = Console.ReadLine();

                Console.Clear();

                Console.WriteLine("Vali raskusaste:");
                Console.WriteLine("1 - Lihtne (aeglane kiirus)");
                Console.WriteLine("2 - Keskmine (keskmine kiirus)");
                Console.WriteLine("3 - Raske (kiire kiirus + rohkem takistusi)");

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

                int baseSpeed = difficulty == 1 ? 200 : difficulty == 2 ? 120 : 80;

                Point startPoint = new Point(4, 5 + gameOffsetY, '*');
                Player player = new Player(playerName, startPoint, Direction.RIGHT);
                player.Stats.Level = difficulty;
                player.Stats.LifeSystem = new LifeSystem(3);

                player.Stats.LoadStats();
                player.Stats.PrintStats();

                Walls walls = new Walls(80, 25, gameOffsetY);

                if (difficulty == 3)
                {
                    walls.AddObstacle(20, 8 + gameOffsetY, 7);
                    walls.AddObstacle(40, 10 + gameOffsetY, 5);
                    walls.AddObstacle(60, 8 + gameOffsetY, 7);
                }

                walls.Draw();
                player.Snake.Draw();

                FoodCreator foodCreator = new FoodCreator(80, 25, '$', gameOffsetY);
                Point food = foodCreator.CreateFood();
                food.Draw();

                while (true)
                {
                    if (walls.IsHit(player.Snake) || player.Snake.IsHitTail())
                    {
                        MusicManager.PlayLoseSound();
                        
                        if (player.Stats.LifeSystem.LoseLife())
                        {
                            player.Stats.LifeSystem.ShowLifeLostMessage();
                            player.Stats.ResetAfterDeath();
                            
                            startPoint = new Point(4, 5 + gameOffsetY, '*');
                            player.Snake = new Snake(startPoint, 4, Direction.RIGHT);
                            
                            Console.Clear();
                            player.Stats.PrintStats();
                            walls.Draw();
                            player.Snake.Draw();
                            food = foodCreator.CreateFood();
                            food.Draw();
                            
                            continue;
                        }
                        else
                        {
                            player.Stats.SaveStats();
                            player.Stats.SaveToLeaderboard();
                            break;
                        }
                    }
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
                        player.Snake.Move();
                    }

                    int currentSpeed = Math.Max(30, baseSpeed - (player.Stats.Length - 4) * 3);
                    Thread.Sleep(currentSpeed);
                    
                    if (Console.KeyAvailable)
                    {
                        ConsoleKeyInfo key = Console.ReadKey(true);
                        player.Snake.HandleKey(key.Key);
                    }
                }

                WriteGameOver();
                Stats.ShowLeaderboard();

                Console.WriteLine("\nKas soovid uuesti mängida? (j/e)");
                var answer = Console.ReadKey().KeyChar;
                if (answer == 'j' || answer == 'J')
                {
                    MusicManager.PlayMenuMusic();
                }
                else
                {
                    MusicManager.StopMenuMusic();
                    break;
                }
            }
        }

        static void WriteGameOver()
        {
            int xOffset = 25;
            int yOffset = 11;
            Console.Clear();
            Console.SetCursorPosition(xOffset, yOffset++);
            WriteText("!-----------------!", xOffset, yOffset++);
            WriteText("MÄNG LÕPPENUD", xOffset + 1, yOffset++);
            yOffset++;
            WriteText("!-----------------!", xOffset, yOffset++);
        }

        static void WriteText(String text, int xOffset, int yOffset)
        {
            Console.SetCursorPosition(xOffset, yOffset);
            Console.WriteLine(text);
        }
    }
}
