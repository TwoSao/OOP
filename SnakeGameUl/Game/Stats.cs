using System;
using System.Collections.Generic;

namespace SnakeGameUl.Game
{
    // Statistika klass - haldab skoori, pikkust, rekordeid ja elusid
    class Stats
    {
        public string Name { get; set; }        // Mängija nimi
        public int Score { get; set; }          // Praegune skoor
        public int Length { get; set; }         // Mao pikkus
        public int HighScore { get; set; }      // Kõrgeim skoor
        public int Level { get; set; }          // Raskusaste
        public LifeSystem LifeSystem { get; set; } // Elude süsteem
        


        // Konstruktor - seadistab algsed väärtused
        public Stats()
        {
            Score = 0;
            Length = 4;
            LifeSystem = new LifeSystem(3);
        }

        // Kuvab statistika ekraani ülaosas
        public void PrintStats()
        {
            try
            {
                Console.SetCursorPosition(0, 0);
                string statsLine = $"Nimi: {Name,-15} Skoor: {Score,-6} Pikkus: {Length,-4} Rekord: {HighScore,-6} Tase: {Level}";
                Console.Write(statsLine.PadRight(Console.WindowWidth - 1));
                
                LifeSystem?.DisplayLives();
            }
            catch (ArgumentOutOfRangeException)
            {
            }
        }

        // Uuendab skoori ja kontrollib lisaelu saamist
        public void UpdateScore(int points = 10)
        {
            int oldScore = Score;
            Score += points;
            Length++;
            
            if (oldScore / 100 < Score / 100 && LifeSystem != null)
            {
                LifeSystem.GainLife();
                LifeSystem.ShowLifeGainedMessage();
            }
        }

        
        // Lähtestab statistika pärast surma
        public void ResetAfterDeath()
        {
            Length = 4;
        }
        
        // Tõstab raskusastet
        public void UpdateLevel()
        {
            Level++;
        }
        
        // Uuendab kõrgeimat skoori kui vaja
        public void UpdateHighScore()
        {
            if (Score > HighScore)
            {
                HighScore = Score;
            }
        }

        // Laadib salvestatud statistika failist
        public void LoadStats()
        {
            try
            {
                if (System.IO.File.Exists("stats.txt"))
                {
                    string[] lines = System.IO.File.ReadAllLines("stats.txt");
                    if (lines.Length >= 4)
                    {
                        HighScore = int.Parse(lines[3]);
                    }
                }
            }
            catch
            {
                HighScore = 0;
            }
        }
        // Salvestab statistika faili
        public void SaveStats()
        {
            if (Score > HighScore)
            {
                HighScore = Score;
            }

            try
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter("stats.txt", false))
                {
                    file.WriteLine(Name);
                    file.WriteLine(Score);
                    file.WriteLine(Length);
                    file.WriteLine(HighScore);
                    file.WriteLine(Level);
                }
            }
            catch
            {
            }
        }

        // Lisab tulemuse edetabelisse
        public void SaveToLeaderboard()
        {
            try
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter("leaderboard.txt", true))
                {
                    file.WriteLine($"{Name},{Score}");
                }
            }
            catch
            {
            }
        }

        // Kuvab edetabeli (parimad 5 tulemust)
        public static void ShowLeaderboard()
        {
            try
            {
                if (System.IO.File.Exists("leaderboard.txt"))
                {
                    var lines = System.IO.File.ReadAllLines("leaderboard.txt");
                    var scores = new List<(string name, int score)>();
                    
                    foreach (var line in lines)
                    {
                        var parts = line.Split(',');
                        if (parts.Length == 2 && int.TryParse(parts[1], out int score))
                        {
                            scores.Add((parts[0], score));
                        }
                    }
                    
                    scores.Sort((a, b) => b.score.CompareTo(a.score));
                    
                    Console.WriteLine("\n=== EDETABEL ===");
                    for (int i = 0; i < Math.Min(5, scores.Count); i++)
                    {
                        Console.WriteLine($"{i + 1}. {scores[i].name} - {scores[i].score}");
                    }
                }
                else
                {
                    Console.WriteLine("\nEdetabel on tühi");
                }
            }
            catch
            {
                Console.WriteLine("\nEdetabeli laadimisel tekkis viga");
            }
        }
    }
}