using System;

namespace SnakeGameUl.UI
{
    public static class GameDisplay
    {
        // Näitab mängu alguse menüüd
        public static void ShowWelcome()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            WriteText("╔══════════════════════════════════════╗", 20, 8);
            WriteText("║            SNAKE GAME                ║", 20, 9);
            WriteText("╚══════════════════════════════════════╝", 20, 10);
            Console.ResetColor();
        }

        // Näitab mängu lõpu sõnumit
        public static void ShowGameOver()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            WriteText("╔══════════════════════════════════════╗", 20, 10);
            WriteText("║             MÄNG LÕPPENUD            ║", 20, 11);
            WriteText("╚══════════════════════════════════════╝", 20, 12);
            Console.ResetColor();
        }

        // Näitab raskusastme valiku menüüd
        public static void ShowDifficultyMenu()
        {
            Console.WriteLine("╔══════════════════════════════════════╗");
            Console.WriteLine("║          Vali raskusaste:            ║");
            Console.WriteLine("╠══════════════════════════════════════╣");
            Console.WriteLine("║ 1 - Lihtne (aeglane kiirus)          ║");
            Console.WriteLine("║ 2 - Keskmine (keskmine kiirus)       ║");
            Console.WriteLine("║ 3 - Raske (kiire kiirus + takistusi) ║");
            Console.WriteLine("╚══════════════════════════════════════╝");
        }

        // Näitab mängija nime küsimust
        public static void ShowNamePrompt()
        {
            Console.WriteLine("╔══════════════════════════════════════╗");
            Console.WriteLine("║         Sisesta oma nimi:            ║");
            Console.WriteLine("╚══════════════════════════════════════╝");
        }

        // Kuvab teksti määratud koordinaatides
        public static void WriteText(string text, int xOffset, int yOffset)
        {
            try
            {
                Console.SetCursorPosition(xOffset, yOffset);
                Console.WriteLine(text);
            }
            catch (ArgumentOutOfRangeException)
            {
                // Ignoreerime konsooli piiride ületamist
            }
        }
    }
}