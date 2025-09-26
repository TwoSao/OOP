# Диаграмма классов Snake Game

## Иерархия наследования

```
Object
├── Program (static)
├── Direction (enum)
├── Point
├── Figure (abstract)
│   ├── Snake
│   ├── HorizontalLine
│   └── VerticalLine
├── Player
├── Stats
├── Walls
├── FoodCreator
└── MusicManager (static)
```

## Взаимосвязи классов

### Program → Все классы
- **Использует**: Player, Walls, FoodCreator, MusicManager, Stats
- **Создает**: экземпляры всех игровых объектов
- **Управляет**: жизненным циклом игры

### Player → Snake, Stats
- **Содержит**: Snake (композиция)
- **Содержит**: Stats (композиция)
- **Связывает**: игрока с его змейкой и статистикой

### Snake → Figure, Point, Direction
- **Наследует**: Figure
- **Использует**: Point (для сегментов тела)
- **Использует**: Direction (для направления движения)

### Figure → Point
- **Содержит**: List<Point> (композиция)
- **Базовый класс** для всех фигур на поле

### Walls → Figure, HorizontalLine, VerticalLine
- **Содержит**: List<Figure> (композиция)
- **Создает**: HorizontalLine, VerticalLine

### FoodCreator → Point
- **Создает**: Point (еда)

### Stats → File System
- **Работает с**: stats.txt, leaderboard.txt

## Потоки данных

```
Program
  ↓ создает
Player (name) → Stats (name, score, length)
  ↓ содержит
Snake (points) → Figure (pList)
  ↓ наследует
Point (x, y, sym)

Program
  ↓ создает
Walls → HorizontalLine/VerticalLine → Figure → Point

Program
  ↓ создает  
FoodCreator → Point (food)

Program
  ↓ использует
MusicManager → Sound Files (.wav)
```

## Ключевые методы по классам

### Program
- `Main()` - точка входа
- `WriteGameOver()` - экран окончания
- `WriteText()` - вывод текста

### Point
- `Move()` - перемещение
- `Draw()` - отрисовка
- `Clear()` - очистка
- `IsHit()` - проверка столкновения

### Snake
- `Move()` - движение змейки
- `HandleKey()` - обработка клавиш
- `Eat()` - поедание еды
- `IsHitTail()` - проверка столкновения с хвостом

### Stats
- `UpdateScore()` - обновление очков
- `LoadStats()` / `SaveStats()` - работа с файлами
- `ShowLeaderboard()` - показ таблицы лидеров

### Walls
- `IsHit()` - проверка столкновения
- `AddObstacle()` - добавление препятствий

### MusicManager
- `PlayMenuMusic()` / `StopMenuMusic()` - фоновая музыка
- `PlayEatSound()` / `PlayLoseSound()` - звуковые эффекты