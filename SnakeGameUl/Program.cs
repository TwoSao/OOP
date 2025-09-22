namespace SnakeGameUl
{
    class Program
    {
        static void Main(string[] args)
        {
            int x1 = 1;
            int y1 = 3;
            string symb = "*";
            Draw(5, 5, "&");
            Console.SetCursorPosition(x1, y1);
            Console.WriteLine(symb);
            
            int x2 = 4;
            int y2 = 5;

            Console.SetCursorPosition(x2, y2);
            Console.WriteLine(symb);
        }

        static void Draw(int x, int y, string symb)
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine(symb);
            
        }
    }
}