using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SnakeGameUl.Core;

namespace SnakeGameUl.Game
{
    // Toidu loomise klass - genereerib juhuslikult toitu mänguväljale
    class FoodCreator
    {
        int mapWidth;   // Kaardi laius
        int mapHeight;  // Kaardi kõrgus
        char sym;       // Toidu sümbol
        int offsetY;    // Vertikaalne nihe

        Random random = new Random( ); // Juhuslike numbrite generaator

        // Konstruktor - seadistab kaardi suuruse ja toidu sümboli
        public FoodCreator(int mapWidth, int mapHeight, char sym, int offsetY = 0)
        {
            this.mapWidth = mapWidth;
            this.mapHeight = mapHeight;
            this.sym = sym;
            this.offsetY = offsetY;
        }

        // Loob uue toidu juhuslikus kohas (vältides seinu)
        public Point CreateFood()
        {
            int x = random.Next( 2, mapWidth - 2 );
            int y = random.Next( 2 + offsetY, mapHeight - 2 + offsetY );
            return new Point( x, y, sym );
        }
    }
}