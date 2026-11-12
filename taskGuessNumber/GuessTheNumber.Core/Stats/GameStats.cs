namespace GuessTheNumber.Core.Stats;

/// <summary>
/// Совокупная статистика игрока.
/// </summary>
public class GameStats
{
    /// <summary>Всего сыгранных игр.</summary>
    public int TotalGames { get; set; }

    /// <summary>Количество побед.</summary>
    public int Wins { get; set; }

    /// <summary>Количество поражений.</summary>
    public int Losses { get; set; }

    /// <summary>Минимальное число попыток при победе.</summary>
    public int MinAttempts { get; set; } = int.MaxValue;

    /// <summary>Максимальное число попыток при победе.</summary>
    public int MaxAttempts { get; set; }

    /// <summary>Среднее число попыток при победе.</summary>
    public double AverageAttempts { get; set; }
}