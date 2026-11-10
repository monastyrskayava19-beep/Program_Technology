using System;
using GuessTheNumber.Core.Game;

namespace GuessTheNumber.Console;

internal class Program
{
    static void Main(string[] args)
    {
        var game = new GameService();
        game.Play();
    }
}