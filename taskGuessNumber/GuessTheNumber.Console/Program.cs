using System;
using GuessTheNumber.Core.Difficulty;
using GuessTheNumber.Core.Game;

namespace GuessTheNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Добро пожаловать в игру 'Угадай число'!");

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

            // --- Создаем игру и ПОДПИСЫВАЕМСЯ на события ---
            var game = new GameService();

            // 1. Подписываемся на сообщения (подсказки)
            game.OnMessage += (message) =>
            {
                Console.WriteLine(message);
            };

            // 2. Подписываемся на окончание игры
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
            };

            // Запускаем игру
            game.Play(selectedLevel);

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}