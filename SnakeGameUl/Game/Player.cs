using SnakeGameUl.Core;

namespace SnakeGameUl.Game
{
    // Mängija klass - ühendab mängija nime, statistika ja mao
    class Player
    {
        public string Name { get; set; }    // Mängija nimi
        public Stats Stats { get; set; }    // Mängija statistika
        public Snake Snake { get; set; }    // Mängija madu
        
        // Konstruktor - loob uue mängija koos mao ja statistikaga
        public Player(string name, Point startPosition, Direction direction)
        {
            Name = name;
            Stats = new Stats { Name = name };
            Snake = new Snake(startPosition, 4, direction);
        }
    }
}