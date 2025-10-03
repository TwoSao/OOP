# Mao Mäng - Programmi käivitamine

## Käivitamine CMD kaudu

### Variant 1: dotnet run kaudu
```cmd
cd C:\Users\admin\RiderProjects\OOP\SnakeGameUl
dotnet run
```

### Variant 2: dotnet projekti määramisega
```cmd
dotnet run --project "C:\Users\admin\RiderProjects\OOP\SnakeGameUl\SnakeGameUl.csproj"
```

## Käivitamine EXE faili kaudu

### Otsene käivitamine
```cmd
cd C:\Users\admin\RiderProjects\OOP\SnakeGameUl\bin\Debug\net9.0
SnakeGameUl.exe
```

### Käivitamine suvalisest kaustast
```cmd
"C:\Users\admin\RiderProjects\OOP\SnakeGameUl\bin\Debug\net9.0\SnakeGameUl.exe"
```

## Nõuded
- .NET 9.0 Runtime
- Windows OS
- Konsool Unicode sümbolite toega

## Juhtimine
- ↑↓←→ - mao liigutamine
- Eesmärk: kogu toitu ($) ja väldi kokkupõrkeid
- Sul on 3 elu (♥)