using System;
using System.IO;
using System.Media;

namespace SnakeGameUl
{
    public static class MusicManager
    {
        private static SoundPlayer menuPlayer;
        private static SoundPlayer eatPlayer;
        private static SoundPlayer losePlayer;

        public static void Initialize(string basePath)
        {
            string menuSound = Path.Combine(basePath, "assets", "background.wav");
            string eatSound = Path.Combine(basePath, "assets", "eat.wav");
            string loseSound = Path.Combine(basePath, "assets", "death.wav");

            menuPlayer = new SoundPlayer(menuSound);
            eatPlayer = new SoundPlayer(eatSound);
            losePlayer = new SoundPlayer(loseSound);
        }

        // --- Фоновая музыка ---
        public static void PlayMenuMusic()
        {
            try
            {
                menuPlayer?.PlayLooping();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Не удалось воспроизвести музыку меню: " + ex.Message);
            }
        }

        public static void StopMenuMusic()
        {
            try
            {
                menuPlayer?.Stop();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка при остановке музыки меню: " + ex.Message);
            }
        }

        // --- Эффекты ---
        public static void PlayEatSound()
        {
            try
            {
                eatPlayer?.Play();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка воспроизведения звука еды: " + ex.Message);
            }
        }

        public static void PlayLoseSound()
        {
            try
            {
                losePlayer?.Play();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка воспроизведения звука поражения: " + ex.Message);
            }
        }
    }
}