using System;
using System.IO;
using NAudio.Wave;

namespace SnakeGameUl.Audio
{
    // Muusika ja helide haldur - kasutab NAudio teeki
    public static class MusicManager
    {
        private static WaveOutEvent backgroundPlayer;  // Taustamuusika mängija
        private static WaveOutEvent effectPlayer;      // Efektide mängija
        private static WaveOutEvent endPlayer;         // Lõpu heli mängija
        private static WaveOutEvent lifePlayer;        // Elu heli mängija
        private static AudioFileReader backgroundMusic; // Taustamuusika fail
        private static string eatSoundPath;            // Söömise heli tee
        private static string endSoundPath;            // Lõpu heli tee
        private static string lifeSoundPath;           // Elu heli tee

        // Initsialiseerib kõik helimängijad ja laadib helifailid
        public static void Initialize(string basePath)
        {
            string backgroundSound = Path.Combine(basePath, "assets", "background.wav");
            eatSoundPath = Path.Combine(basePath, "assets", "eat.wav");
            endSoundPath = Path.Combine(basePath, "assets", "end.wav");
            lifeSoundPath = Path.Combine(basePath, "assets", "life.wav");

            backgroundPlayer = new WaveOutEvent();
            effectPlayer = new WaveOutEvent();
            endPlayer = new WaveOutEvent();
            lifePlayer = new WaveOutEvent();

            if (File.Exists(backgroundSound))
            {
                backgroundMusic = new AudioFileReader(backgroundSound);
                backgroundMusic.Volume = 0.5f;
                backgroundPlayer.Init(backgroundMusic);
                backgroundPlayer.PlaybackStopped += (s, e) => RestartBackgroundMusic();
            }
        }

        // Taaskäivitab taustamuusika (kordab lõputult)
        private static void RestartBackgroundMusic()
        {
            if (backgroundMusic != null)
            {
                backgroundMusic.Position = 0;
                backgroundPlayer?.Play();
            }
        }

        // Käivitab taustamuusika esitamise
        public static void StartBackgroundMusic()
        {
            try
            {
                if (backgroundMusic != null)
                {
                    backgroundMusic.Volume = 0.5f;
                    backgroundPlayer?.Play();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка воспроизведения фоновой музыки: " + ex.Message);
            }
        }

        // Mängib söömise heli
        public static void PlayEatSound()
        {
            try
            {
                if (File.Exists(eatSoundPath))
                {
                    effectPlayer?.Stop();
                    using (var audioFile = new AudioFileReader(eatSoundPath))
                    {
                        effectPlayer.Init(audioFile);
                        effectPlayer.Play();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка воспроизведения звука еды: " + ex.Message);
            }
        }

        // Mängib mängu lõpu heli ja peatab taustamuusika
        public static void PlayEndSound()
        {
            try
            {
                backgroundPlayer?.Stop();
                if (File.Exists(endSoundPath))
                {
                    using (var audioFile = new AudioFileReader(endSoundPath))
                    {
                        endPlayer.Init(audioFile);
                        endPlayer.Play();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка воспроизведения звука смерти: " + ex.Message);
            }
        }

        // Mängib elu kaotamise heli
        public static void PlayLifeSound()
        {
            try
            {
                if (File.Exists(lifeSoundPath))
                {
                    lifePlayer?.Stop();
                    using (var audioFile = new AudioFileReader(lifeSoundPath))
                    {
                        lifePlayer.Init(audioFile);
                        lifePlayer.Play();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка воспроизведения звука возрождения: " + ex.Message);
            }
        }

        // Vabastab kõik heliressursid mälu koristamiseks
        public static void Dispose()
        {
            backgroundPlayer?.Dispose();
            effectPlayer?.Dispose();
            endPlayer?.Dispose();
            lifePlayer?.Dispose();
            backgroundMusic?.Dispose();
        }
    }
}