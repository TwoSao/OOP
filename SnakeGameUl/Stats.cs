using System;
using System.Collections.Generic;

namespace SnakeGameUl
{
    /// <summary>
    /// Класс для управления статистикой игрока
    /// Отвечает за:
    /// - Хранение текущих очков, длины змейки, рекорда
    /// - Сохранение/загрузку данных в файлы
    /// - Управление таблицей лидеров
    /// - Отображение статистики на экране
    /// </summary>
    class Stats
    {
        public string Name { get; set; }
        public int Score { get; set; }
        public int Length { get; set; }
        public int HighScore { get; set; }
        public int Level { get; set; }
        public LifeSystem LifeSystem { get; set; }
        
        // Бонусные эффекты
        public bool HasSpeedBoost { get; private set; }
        public bool HasScoreMultiplier { get; private set; }
        public bool HasSlowDown { get; private set; }
        public int ScoreMultiplier { get; private set; } = 1;

        public Stats()
        {
            Score = 0;
            Length = 4;
            ScoreMultiplier = 1;
            LifeSystem = new LifeSystem(3); // 3 жизни по умолчанию
        }

        public void PrintStats()
        {
            try
            {
                Console.SetCursorPosition(0, 0);
                string statsLine = $"Nimi: {Name,-15} Score: {Score,-6} Length: {Length,-4} HighScore: {HighScore,-6} Level: {Level}";
                Console.Write(statsLine.PadRight(Console.WindowWidth - 1));
                
                // Отображаем жизни
                LifeSystem?.DisplayLives();
            }
            catch (ArgumentOutOfRangeException)
            {
                // Игнорируем ошибки позиционирования курсора
            }
        }

        public void UpdateScore(int points = 10)
        {
            Score += points * ScoreMultiplier;
            Length++;
        }
        
        // Методы для бонусов
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
            if (HasSpeedBoost) return -30; // Ускорение
            if (HasSlowDown) return 50;    // Замедление
            return 0;
        }
        
        /// <summary>
        /// Сбрасывает статистику после потери жизни
        /// </summary>
        public void ResetAfterDeath()
        {
            Length = 4;
            // Очки не сбрасываются, чтобы сохранить прогресс
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
                // Игнорируем ошибки сохранения
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
                // Игнорируем ошибки сохранения
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