namespace GuessTheNumber.Core.Difficulty;

/// <summary>
/// Стандартный набор уровней сложности игры.
/// </summary>
public class DefaultDifficultyProvider : IDifficultyProvider
{
    private readonly List<DifficultyLevel> _levels = new()
    {
        new DifficultyLevel("Лёгкий",  100,  10),
        new DifficultyLevel("Средний", 500,   7),
        new DifficultyLevel("Сложный", 1000,  5),
    };

    public IReadOnlyList<DifficultyLevel> GetLevels() => _levels;
}