namespace SnakeGameUl
{
    class Program
    {
        static void Main(string[] args)
        {
            Point p1 = new Point(1, 1, '*');
            Point p2 = new Point(2, 2, '/');
            p2.Draw();
            HorizontaleLine upline = new HorizontaleLine(0,78,0,'+');
            upline.Draw();
            HorizontaleLine Hdownline = new HorizontaleLine(0,78,24,'+');
            Hdownline.Draw();
            VerticalLine left = new VerticalLine(0, 24, 0,'+');
            VerticalLine right = new VerticalLine(0, 24, 78,'+');
            left.Draw();
            right.Draw();
            
            Point p = new Point(4, 5, '*');
            Snake snake = new Snake(p, 4, Direction.Right);
            snake.Draw();
            snake.Move();
        }
        
        
    }
}