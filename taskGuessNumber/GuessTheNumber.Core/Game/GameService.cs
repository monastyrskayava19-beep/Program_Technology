namespace GuessTheNumber.Core.Game;

/// <summary>
/// Простая логика игры «Угадай число».
/// </summary>
public class GameService
{
    private readonly Random _random = new();

    /// <summary>
    /// Запускает игру.
    /// </summary>
    /// <param name="maxNumber">Максимальное число диапазона.</param>
    public void Play(int maxNumber = 100)
    {
        int target = _random.Next(1, maxNumber + 1);
        Console.WriteLine($"Я загадал число от 1 до {maxNumber}.");

        while (true)
        {
            Console.Write("Введите число: ");
            if (!int.TryParse(Console.ReadLine(), out int guess))
            {
                Console.WriteLine("Ошибка ввода.");
                continue;
            }

            if (guess == target)
            {
                Console.WriteLine("Поздравляю! Вы угадали.");
                break;
            }

            Console.WriteLine(guess > target ? "Меньше." : "Больше.");
        }
    }
}