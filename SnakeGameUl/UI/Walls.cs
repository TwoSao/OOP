using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SnakeGameUl.Core;

namespace SnakeGameUl.UI
{
    // Seinte klass - loob ja haldab mänguvälja piire ja takistusi
    class Walls
    {
        List<Figure> wallList; // Kõikide seinte loend

        // Konstruktor - loob mänguvälja ümber raamistiku
        public Walls( int mapWidth, int mapHeight, int offsetY = 0 )
        {
            wallList = new List<Figure>();

            // Отрисовка рамочки
            HorizontalLine upLine = new HorizontalLine( 0, mapWidth - 2, offsetY, '+' );
            HorizontalLine downLine = new HorizontalLine( 0, mapWidth - 2, mapHeight - 1 + offsetY, '+' );
            VerticalLine leftLine = new VerticalLine( offsetY, mapHeight - 1 + offsetY, 0, '+' );
            VerticalLine rightLine = new VerticalLine( offsetY, mapHeight - 1 + offsetY, mapWidth - 2, '+' );

            wallList.Add( upLine );
            wallList.Add( downLine );
            wallList.Add( leftLine );
            wallList.Add( rightLine );
        }

        // Kontrollib, kas figuur puutub kokku mõne seinaga
        internal bool IsHit( Figure figure )
        {
            foreach(var wall in wallList)
            {
                if(wall.IsHit(figure))
                {
                    return true;
                }
            }
            return false;
        }

        // Joonistab kõik seinad ekraanile
        public void Draw()
        {
            foreach ( var wall in wallList )
            {
                wall.Draw();
            }
        }

        // Lisab vertikaalse takistuse määratud kohta
        public void AddObstacle(int x, int y, int height)
        {
            VerticalLine obstacle = new VerticalLine(y, y + height - 1, x, '#');
            wallList.Add(obstacle);
        }
    }
}