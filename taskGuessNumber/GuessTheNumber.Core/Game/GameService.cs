using System;
using GuessTheNumber.Core.Difficulty;

namespace GuessTheNumber.Core.Game;

/// <summary>
/// Логика игры «Угадай число».
/// </summary>
public class GameService
{
    private readonly Random _random = new();

    /// <summary>
    /// Запускает игру с выбранным уровнем сложности.
    /// </summary>
    public void Play(DifficultyLevel level)
    {
        int target = _random.Next(1, level.MaxNumber + 1);
        int attempts = 0;

        Console.WriteLine($"Я загадал число от 1 до {level.MaxNumber}. У вас есть {level.MaxAttempts} попыток.");

        while (attempts < level.MaxAttempts)
        {
            attempts++;
            Console.Write($"Попытка {attempts}/{level.MaxAttempts}. Введите число: ");

            if (!int.TryParse(Console.ReadLine(), out int guess))
            {
                Console.WriteLine("Ошибка ввода. Введите целое число.");
                attempts--; // Не засчитываем попытку при ошибке ввода
                continue;
            }

            if (guess < 1 || guess > level.MaxNumber)
            {
                Console.WriteLine($"Число должно быть в диапазоне от 1 до {level.MaxNumber}.");
                attempts--;
                continue;
            }

            if (guess == target)
            {
                Console.WriteLine($"\nПоздравляю! Вы угадали число {target} за {attempts} попыток!");
                return; // Победа! Выходим из метода
            }

            Console.WriteLine(guess > target ? "Ваше число БОЛЬШЕ." : "Ваше число МЕНЬШЕ.");
        }

        // Если цикл закончился, а мы не вышли через return — значит попытки кончились
        Console.WriteLine($"\nУвы! Вы исчерпали все попытки. Загаданное число было: {target}");
    }
}