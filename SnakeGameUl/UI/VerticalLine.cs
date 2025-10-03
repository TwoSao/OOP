using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SnakeGameUl.Core;

namespace SnakeGameUl.UI
{
    // Vertikaalne joon - loob rida punkte ülalt alla
    class VerticalLine : Figure
    {
        // Konstruktor - loob vertikaalse joone kahe punkti vahel
        public VerticalLine( int yUp, int yDown, int x, char sym )
        {
            pList = new List<Point>();
            for(int y = yUp; y <= yDown; y++)
            {
                Point p = new Point( x, y, sym );
                pList.Add( p );
            }			
        }
    }
}