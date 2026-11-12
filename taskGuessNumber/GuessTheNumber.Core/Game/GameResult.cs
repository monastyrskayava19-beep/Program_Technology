namespace GuessTheNumber.Core.Game;

/// <summary>
/// Результат завершенной игры.
/// </summary>
public class GameResult
{
    /// <summary>Количество затраченных попыток.</summary>
    public int Attempts { get; }

    /// <summary>Флаг победы (true - выиграл, false - проиграл).</summary>
    public bool IsWin { get; }

    /// <summary>Загаданное число.</summary>
    public int TargetNumber { get; }

    public GameResult(int attempts, bool isWin, int targetNumber)
    {
        Attempts = attempts;
        IsWin = isWin;
        TargetNumber = targetNumber;
    }
}