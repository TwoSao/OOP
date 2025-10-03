using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SnakeGameUl.Core;

namespace SnakeGameUl.UI
{
    // Horisontaalne joon - loob rida punkte vasakult paremale
    class HorizontalLine : Figure
    {
        // Konstruktor - loob horisontaalse joone kahe punkti vahel
        public HorizontalLine(int xLeft, int xRight, int y, char sym)
        {
            pList = new List<Point>();
            for(int x = xLeft; x <= xRight; x++)
            {
                Point p = new Point( x, y, sym );
                pList.Add( p );
            }			
        }
    }
}