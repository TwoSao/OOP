namespace SnakeGameUl
{
    class Player
    {
        public string Name { get; set; }
        public Stats Stats { get; set; }
        public Snake Snake { get; set; }
        
        public Player(string name, Point startPosition, Direction direction)
        {
            Name = name;
            Stats = new Stats { Name = name };
            Snake = new Snake(startPosition, 4, direction);
        }
    }
}