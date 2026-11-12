using System;
using System.IO;
using System.Text.Json;

namespace GuessTheNumber.Core.Stats;

/// <summary>
/// Сервис статистики, сохраняющий данные в JSON-файл.
/// </summary>
public class FileStatisticsService : IStatisticsService
{
    private readonly string _filePath;
    private GameStats _stats;

    public FileStatisticsService(string filePath = "stats.json")
    {
        _filePath = filePath;
        _stats = LoadStats();
    }

    public GameStats GetStats() => _stats;

    public void RecordGame(int attempts, bool isWin)
    {
        _stats.TotalGames++;

        if (isWin)
        {
            _stats.Wins++;
            if (attempts < _stats.MinAttempts) _stats.MinAttempts = attempts;
            if (attempts > _stats.MaxAttempts) _stats.MaxAttempts = attempts;

            // Пересчитываем среднее значение
            double totalWinAttempts = _stats.AverageAttempts * (_stats.Wins - 1) + attempts;
            _stats.AverageAttempts = totalWinAttempts / _stats.Wins;
        }
        else
        {
            _stats.Losses++;
        }

        SaveStats();
    }

    private GameStats LoadStats()
    {
        if (!File.Exists(_filePath))
            return new GameStats();

        try
        {
            string json = File.ReadAllText(_filePath);
            return JsonSerializer.Deserialize<GameStats>(json) ?? new GameStats();
        }
        catch
        {
            // Если файл поврежден, начинаем с чистого листа
            return new GameStats();
        }
    }

    private void SaveStats()
    {
        string json = JsonSerializer.Serialize(_stats, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(_filePath, json);
    }
}