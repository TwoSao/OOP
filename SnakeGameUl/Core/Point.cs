using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGameUl.Core
{
    /// <summary>
    /// Базовый класс для представления точки на игровом поле
    /// Содержит координаты (x, y) и символ для отображения
    /// Используется для создания всех игровых объектов: змейка, еда, стены
    /// </summary>
    class Point
    {
        public int x;
        public int y;
        public char sym;

        // Tühi konstruktor - loob punkti ilma väärtusteta
        public Point()
        {
        }

        // Konstruktor koordinaatide ja sümboliga - loob punkti määratud asukohas
        public Point(int x, int y, char sym)
        {
            this.x = x;
            this.y = y;
            this.sym = sym;
        }

        // Koopia konstruktor - loob uue punkti olemasoleva põhjal
        public Point(Point p)
        {
            x = p.x;
            y = p.y;
            sym = p.sym;
        }

        // Liigutab punkti määratud suunas ja kaugusel
        public void Move(int offset, Direction direction)
        {
            if(direction == Direction.RIGHT)
            {
                x = x + offset;
            }
            else if(direction == Direction.LEFT)
            {
                x = x - offset;
            }
            else if(direction == Direction.UP)
            {
                y = y - offset;
            }
            else if(direction == Direction.DOWN)
            {
                y = y + offset;
            }
        }

        // Kontrollib, kas kaks punkti on samas kohas (kokkupõrge)
        public bool IsHit(Point p)
        {
            return p.x == this.x && p.y == this.y;
        }

        // Joonistab punkti konsooli ekraanile
        public void Draw()
        {
            try
            {
                if (x >= 0 && y >= 0 && x < Console.WindowWidth && y < Console.WindowHeight)
                {
                    Console.SetCursorPosition( x, y );
                    Console.Write( sym );
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                // Игнорируем попытки рисования за границами консоли
            }
        }

        // Kustutab punkti ekraanilt (asendab tühikuga)
        public void Clear()
        {
            try
            {
                if (x >= 0 && y >= 0 && x < Console.WindowWidth && y < Console.WindowHeight)
                {
                    Console.SetCursorPosition( x, y );
                    Console.Write( ' ' );
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                // Игнорируем попытки очистки за границами консоли
            }
        }

        // Tagastab punkti info tekstina (x, y, sümbol)
        public override string ToString()
        {
            return x + ", " + y + ", " + sym;
        }
    }
}