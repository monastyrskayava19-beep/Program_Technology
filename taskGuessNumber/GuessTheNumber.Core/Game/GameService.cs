using System;
using GuessTheNumber.Core.Difficulty;

namespace GuessTheNumber.Core.Game;

/// <summary>
/// Логика игры «Угадай число».
/// </summary>
public class GameService
{
    private readonly Random _random = new();

    // --- СОБЫТИЯ ---

    /// <summary>
    /// Событие: возникает, когда нужно показать игроку сообщение (подсказку или ошибку).
    /// </summary>
    public event Action<string>? OnMessage;

    /// <summary>
    /// Событие: возникает, когда игра заканчивается (победой или поражением).
    /// </summary>
    public event Action<GameResult>? OnGameEnded;


    // --- ЛОГИКА ---

    /// <summary>
    /// Запускает игру с выбранным уровнем сложности.
    /// </summary>
    public void Play(DifficultyLevel level)
    {
        int target = _random.Next(1, level.MaxNumber + 1);
        int attempts = 0;

        // Вместо Console.WriteLine вызываем событие
        OnMessage?.Invoke($"Я загадал число от 1 до {level.MaxNumber}. У вас есть {level.MaxAttempts} попыток.");

        while (attempts < level.MaxAttempts)
        {
            attempts++;
            OnMessage?.Invoke($"Попытка {attempts}/{level.MaxAttempts}. Введите число: ");

            if (!int.TryParse(Console.ReadLine(), out int guess))
            {
                OnMessage?.Invoke("Ошибка ввода. Введите целое число.");
                attempts--;
                continue;
            }

            if (guess < 1 || guess > level.MaxNumber)
            {
                OnMessage?.Invoke($"Число должно быть в диапазоне от 1 до {level.MaxNumber}.");
                attempts--;
                continue;
            }

            if (guess == target)
            {
                // Победа! Вызываем событие окончания игры
                OnGameEnded?.Invoke(new GameResult(attempts, true, target));
                return;
            }

            OnMessage?.Invoke(guess > target ? "Ваше число БОЛЬШЕ." : "Ваше число МЕНЬШЕ.");
        }

        // Если вышли из цикла - это поражение
        OnGameEnded?.Invoke(new GameResult(attempts, false, target));
    }
}