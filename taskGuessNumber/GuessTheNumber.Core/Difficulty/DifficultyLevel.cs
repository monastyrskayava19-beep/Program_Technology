namespace GuessTheNumber.Core.Difficulty;

/// <summary>
/// Описывает уровень сложности игры.
/// </summary>
public class DifficultyLevel
{
    /// <summary>Название уровня (например, «Лёгкий»).</summary>
    public string Name { get; }

    /// <summary>Максимальное загадываемое число (диапазон от 1 до MaxNumber).</summary>
    public int MaxNumber { get; }

    /// <summary>Максимальное количество попыток.</summary>
    public int MaxAttempts { get; }

    public DifficultyLevel(string name, int maxNumber, int maxAttempts)
    {
        Name = name;
        MaxNumber = maxNumber;
        MaxAttempts = maxAttempts;
    }
}