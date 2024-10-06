using GuessNumber;
using System;

namespace GuessingGame
{
    class Game
    {

    }
    class Program
    {
        static void Main(string[] args)
        {
            IInputReader inputReader = new ConsoleInputReader();
            IOutputWriter outputWriter = new ConsoleOutputWriter();
            outputWriter.WriteMessage("Попробуешь угадать число?");
            outputWriter.WriteMessage("Сколько попыток тебе потребуется?");
            int attempts = inputReader.ReadInput();
            outputWriter.WriteMessage("Введи минимальное значение диапазона");
            int min = inputReader.ReadInput();
            outputWriter.WriteMessage("Введи максимальное значение диапазона");
            int max = inputReader.ReadInput();

            IGameConfiguration gameConfiguration = new DefaultGameConfiguration(min, max, attempts);
            INumberGenerator numberGenerator = new RandomNumberGenerator(gameConfiguration);

            GuessTheNumberGame game = new GuessTheNumberGame(numberGenerator, inputReader, outputWriter, gameConfiguration);
            game.Play();
        }
    }
}