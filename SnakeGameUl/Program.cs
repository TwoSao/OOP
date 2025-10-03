using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using SnakeGameUl.Core;
using SnakeGameUl.Game;
using SnakeGameUl.Audio;
using SnakeGameUl.UI;

namespace SnakeGameUl
{
    class Program
    {
        // Peamine funktsioon - käivitab mängu ja haldab mängutsüklit
        static void Main(string[] args)
        {
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            MusicManager.Initialize(basePath);
            MusicManager.StartBackgroundMusic();

            while (true)
            {
                GameDisplay.ShowWelcome();
                Thread.Sleep(2000);

                int gameOffsetY = 5;

                Console.Clear();
                GameDisplay.ShowNamePrompt();
                string playerName = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(playerName))
                    playerName = "Mängija";

                Console.Clear();
                GameDisplay.ShowDifficultyMenu();

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
                        
                        if (player.Stats.LifeSystem.LoseLife())
                        {
                            MusicManager.PlayLifeSound();
                            player.Stats.LifeSystem.ShowLifeLostMessage();
                            player.Stats.ResetAfterDeath();
                            
                            Point newStartPoint = new Point(4, 5 + gameOffsetY, '*');
                            player.Snake = new Snake(newStartPoint, 4, Direction.RIGHT);
                            
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
                            MusicManager.PlayEndSound();
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

                GameDisplay.ShowGameOver();
                Stats.ShowLeaderboard();

                Console.WriteLine("\nKas soovid uuesti mängida? (j/e)");
                var answer = Console.ReadKey().KeyChar;
                if (answer == 'j' || answer == 'J')
                {
                    MusicManager.StartBackgroundMusic();
                }
                else
                {
                    MusicManager.Dispose();
                    break;
                }
            }
        }


    }
}
