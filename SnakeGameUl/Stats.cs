using System;
using System.Collections.Generic;

namespace SnakeGameUl
{
    class Stats
    {
        public string Name { get; set; }
        public int Score { get; set; }
        public int Length { get; set; }
        public int HighScore { get; set; }
        public int Level { get; set; }
        public LifeSystem LifeSystem { get; set; }
        
        public bool HasSpeedBoost { get; private set; }
        public bool HasScoreMultiplier { get; private set; }
        public bool HasSlowDown { get; private set; }
        public int ScoreMultiplier { get; private set; } = 1;

        public Stats()
        {
            Score = 0;
            Length = 4;
            ScoreMultiplier = 1;
            LifeSystem = new LifeSystem(3);
        }

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

        public void UpdateScore(int points = 10)
        {
            int oldScore = Score;
            Score += points * ScoreMultiplier;
            Length++;
            
            if (oldScore / 100 < Score / 100 && LifeSystem != null)
            {
                LifeSystem.GainLife();
                LifeSystem.ShowLifeGainedMessage();
            }
        }
        

        public void ApplySpeedBoost() => HasSpeedBoost = true;
        public void RemoveSpeedBoost() => HasSpeedBoost = false;
        
        public void ApplyScoreMultiplier() 
        { 
            HasScoreMultiplier = true;
            ScoreMultiplier = 2;
        }
        public void RemoveScoreMultiplier() 
        { 
            HasScoreMultiplier = false;
            ScoreMultiplier = 1;
        }
        
        public void ApplySlowDown() => HasSlowDown = true;
        public void RemoveSlowDown() => HasSlowDown = false;
        
        public void AddBonusPoints(int points)
        {
            Score += points;
        }
        
        public int GetSpeedModifier()
        {
            if (HasSpeedBoost) return -30;
            if (HasSlowDown) return 50;
            return 0;
        }
        
        public void ResetAfterDeath()
        {
            Length = 4;
        }
        
        public void UpdateLevel()
        {
            Level++;
        }
        
        public void UpdateHighScore()
        {
            if (Score > HighScore)
            {
                HighScore = Score;
            }
        }

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