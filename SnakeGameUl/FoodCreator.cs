using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGameUl
{
    class FoodCreator
    {
        int mapWidth;
        int mapHeight;
        char sym;
        int offsetY;

        Random random = new Random( );

        public FoodCreator(int mapWidth, int mapHeight, char sym, int offsetY = 0)
        {
            this.mapWidth = mapWidth;
            this.mapHeight = mapHeight;
            this.sym = sym;
            this.offsetY = offsetY;
        }

        public Point CreateFood()
        {
            int x = random.Next( 2, mapWidth - 2 );
            int y = random.Next( 2 + offsetY, mapHeight - 2 + offsetY );
            return new Point( x, y, sym );
        }
    }
}