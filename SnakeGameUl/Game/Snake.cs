using System;
using System.Collections.Generic;
using System.Linq;
using SnakeGameUl.Core;

namespace SnakeGameUl.Game
{
    // Mao klass - haldab mao liikumist, kasvu ja kokkupõrkeid
    class Snake : Figure
    {
        Direction direction; // Mao praegune liikumissuund

        // Konstruktor - loob mao määratud pikkuse ja suunaga
        public Snake( Point tail, int length, Direction _direction )
        {
            direction = _direction;
            pList = new List<Point>();
            for ( int i = 0; i < length; i++ )
            {
                Point p = new Point( tail );
                p.Move( i, direction );
                pList.Add( p );
            }
        }

        // Liigutab madu ühe sammu võrra (eemaldab saba, lisab uue pea)
        public void Move()
        {
            if (pList == null || pList.Count == 0)
                return;
                
            Point tail = pList.First();			
            pList.Remove( tail );
            Point head = GetNextPoint();
            pList.Add( head );

            tail.Clear();
            head.Draw();
        }

        // Arvutab järgmise sammu pea asukoha
        public Point GetNextPoint()
        {
            Point head = pList.Last();
            Point nextPoint = new Point( head );
            nextPoint.Move( 1, direction );
            return nextPoint;
        }

        // Kontrollib, kas mao pea puutub kokku oma sabaga
        public bool IsHitTail()
        {
            if (pList == null || pList.Count < 3)
                return false;
                
            var head = pList.Last();
            for(int i = 0; i < pList.Count - 2; i++ )
            {
                if ( head.IsHit( pList[ i ] ) )
                    return true;
            }
            return false;
        }

        // Töötleb klaviatuuri sisestust suuna muutmiseks
        public void HandleKey(ConsoleKey key)
        {
            Direction newDirection = direction;
            
            if ( key == ConsoleKey.LeftArrow && direction != Direction.RIGHT )
                newDirection = Direction.LEFT;
            else if ( key == ConsoleKey.RightArrow && direction != Direction.LEFT )
                newDirection = Direction.RIGHT;
            else if ( key == ConsoleKey.DownArrow && direction != Direction.UP )
                newDirection = Direction.DOWN;
            else if ( key == ConsoleKey.UpArrow && direction != Direction.DOWN )
                newDirection = Direction.UP;
                
            direction = newDirection;
        }

        // Kontrollib ja sööb toitu (kasvatab madu)
        public bool Eat( Point food )
        {
            Point head = GetNextPoint();
            if ( head.IsHit( food ) )
            {
                Point newHead = new Point(food.x, food.y, head.sym);
                pList.Add( newHead );
                return true;
            }
            else
                return false;
        }
    }
}