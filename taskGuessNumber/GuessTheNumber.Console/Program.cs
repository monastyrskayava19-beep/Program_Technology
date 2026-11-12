using System;
using GuessTheNumber.Core.Difficulty;
using GuessTheNumber.Core.Game;
using GuessTheNumber.Core.Stats; //  ДОБАВИЛИ ЭТУ СТРОКУ

namespace GuessTheNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Добро пожаловать в игру 'Угадай число'!");

            // --- ИНИЦИАЛИЗИРУЕМ СТАТИСТИКУ ---
            IStatisticsService statsService = new FileStatisticsService();
            GameStats currentStats = statsService.GetStats();

            // Показываем сохраненную статистику при запуске
            if (currentStats.TotalGames > 0)
            {
                Console.WriteLine($"\n[Статистика] Игр: {currentStats.TotalGames} | Побед: {currentStats.Wins} | Поражений: {currentStats.Losses}");
            }

            IDifficultyProvider provider = new DefaultDifficultyProvider();
            IReadOnlyList<DifficultyLevel> levels = provider.GetLevels();

            Console.WriteLine("\nВыберите уровень сложности:");
            for (int i = 0; i < levels.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {levels[i].Name} (1–{levels[i].MaxNumber}, {levels[i].MaxAttempts} попыток)");
            }
            Console.Write("Ваш выбор: ");

            int chosenIndex = 0;
            if (int.TryParse(Console.ReadLine(), out int input) && input >= 1 && input <= levels.Count)
            {
                chosenIndex = input - 1;
            }
            else
            {
                Console.WriteLine("Неверный выбор. Используем лёгкий уровень.");
            }

            DifficultyLevel selectedLevel = levels[chosenIndex];

            var game = new GameService();

            game.OnMessage += (message) =>
            {
                Console.WriteLine(message);
            };

            // --- ОБНОВЛЕННАЯ ПОДПИСКА НА ОКОНЧАНИЕ ИГРЫ ---
            game.OnGameEnded += (result) =>
            {
                if (result.IsWin)
                {
                    Console.WriteLine($"\nПоздравляю! Вы угадали число {result.TargetNumber} за {result.Attempts} попыток!");
                }
                else
                {
                    Console.WriteLine($"\nУвы! Вы исчерпали все попытки. Загаданное число было: {result.TargetNumber}");
                }

                // СОХРАНЯЕМ РЕЗУЛЬТАТ В СТАТИСТИКУ
                statsService.RecordGame(result.Attempts, result.IsWin);
                Console.WriteLine("[Статистика сохранена в файл]");
            };

            game.Play(selectedLevel);

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}