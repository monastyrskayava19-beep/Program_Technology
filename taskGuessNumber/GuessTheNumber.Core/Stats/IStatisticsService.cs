namespace GuessTheNumber.Core.Stats;

/// <summary>
/// Сервис для работы со статистикой.
/// </summary>
public interface IStatisticsService
{
    /// <summary>
    /// Возвращает текущую статистику.
    /// </summary>
    GameStats GetStats();

    /// <summary>
    /// Записывает результат новой игры.
    /// </summary>
    void RecordGame(int attempts, bool isWin);
}