namespace SnakeGameUl;

public class Figure
{
    protected List<Point> pList;
    public void Draw()
    {
        foreach (Point p in pList)
        {
            p.Draw();
        }
    }
}