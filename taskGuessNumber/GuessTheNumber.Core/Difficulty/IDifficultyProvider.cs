namespace GuessTheNumber.Core.Difficulty;

/// <summary>
/// Поставщик доступных уровней сложности.
/// </summary>
public interface IDifficultyProvider
{
    IReadOnlyList<DifficultyLevel> GetLevels();
}