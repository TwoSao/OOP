namespace SnakeGameUl;

public class Point : Figure
{
    public int x;
    public int y;
    public char sym;

    public Point()
    {
        Console.WriteLine("Lisamine point");
        
    }
    
    public Point(int _x, int _y, char _sym)
    {
        x = _x;
        y = _y;
        sym = _sym;
    }

    public Point(Point p)
    {
        x = p.x;
        y = p.y;
        sym = p.sym;
    }
    
    public void Move(int offset, Direction direction)
    {
        if (direction == Direction.Right)
        {
            x += offset;
        }
        else if (direction == Direction.Left)
        {
            x -= offset;
        }
        else if (direction == Direction.Up)
        {
            y -= offset;
        }
        else if (direction == Direction.Down)
        {
            y += offset;
        }
    }
    public void Draw()
    {
        Console.SetCursorPosition(x, y);
        Console.Write(sym);
    }
    public void Clear()
    {
        sym = ' ';
        Draw();
    }
    
}