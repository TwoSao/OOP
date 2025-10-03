using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGameUl.Core
{
    // Baasklass kõikidele figuuridele (madu, seinad) - sisaldab punktide loendit
    class Figure
    {
        protected List<Point> pList; // Punktide loend, mis moodustavad figuuri

        // Joonistab kõik figuuri punktid ekraanile
        public void Draw()
        {
            foreach ( Point p in pList )
            {
                p.Draw();
            }
        }

        // Kontrollib, kas see figuur puutub kokku teise figuuriga
        internal bool IsHit( Figure figure )
        {
            foreach(var p in pList)
            {
                if ( figure.IsHit( p ) )
                    return true;
            }
            return false;
        }

        // Kontrollib, kas see figuur puutub kokku ühe punktiga
        private bool IsHit( Point point )
        {
            foreach(var p in pList)
            {
                if ( p.IsHit( point ) )
                    return true;
            }
            return false;
        }
    }
}