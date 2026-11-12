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

            // Получаем список уровней сложности
            IDifficultyProvider provider = new DefaultDifficultyProvider();
            IReadOnlyList<DifficultyLevel> levels = provider.GetLevels();

            // Показываем меню
            Console.WriteLine("\nВыберите уровень сложности:");
            for (int i = 0; i < levels.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {levels[i].Name} (1–{levels[i].MaxNumber}, {levels[i].MaxAttempts} попыток)");
            }
            Console.Write("Ваш выбор: ");

            // Читаем выбор пользователя
            int chosenIndex = 0;
            if (int.TryParse(Console.ReadLine(), out int input) && input >= 1 && input <= levels.Count)
            {
                chosenIndex = input - 1; // Массивы начинаются с 0, а пользователь вводит с 1
            }
            else
            {
                Console.WriteLine("Неверный выбор. Используем лёгкий уровень.");
            }

            DifficultyLevel selectedLevel = levels[chosenIndex];

            // Запускаем игру
            var game = new GameService();
            game.Play(selectedLevel);

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}