using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessNumber
{
    public class RandomNumberGenerator : INumberGenerator
    {
        private readonly IGameConfiguration _gameConfiguration;


        public RandomNumberGenerator(IGameConfiguration gameConfiguration)
        {
            _gameConfiguration = gameConfiguration;
        }

        public int GenerateNumber()
        {
            Random random = new Random();
            return random.Next(_gameConfiguration.MinRange, _gameConfiguration.MaxRange + 1);
        }
    }

    public class ConsoleInputReader : IInputReader
    {
        public int ReadInput()
        {
            return int.Parse(Console.ReadLine());
        }
    }


    public class ConsoleOutputWriter : IOutputWriter
    {
        public void WriteMessage(string message)
        {
            Console.WriteLine(message);
        }
    }


    public class Tracker : ITracker
    {
        public int Attempt { get; private set; }

        public void IncrementAttempt()
        {
            Attempt++;
        }
    }

    public class DefaultGameConfiguration : IGameConfiguration
    {
        public int MinRange { get; private set; }
        public int MaxRange { get; private set; }
        public int MaxAttempts { get; private set; }

        public DefaultGameConfiguration(int minRange, int maxRange, int maxAttempts)
        {
            MinRange = minRange;
            MaxRange = maxRange;
            MaxAttempts = maxAttempts;
        }
    }


    public class GuessTheNumberGame
    {
        private readonly INumberGenerator _numberGenerator;
        private readonly IInputReader _inputReader;
        private readonly IOutputWriter _outputWriter;
        private readonly IGameConfiguration _gameConfiguration;

        public GuessTheNumberGame(INumberGenerator numberGenerator, IInputReader inputReader, IOutputWriter outputWriter, IGameConfiguration gameConfiguration)
        {
            _numberGenerator = numberGenerator;
            _inputReader = inputReader;
            _outputWriter = outputWriter;
            _gameConfiguration = gameConfiguration;
        }

        public void Play()
        {
            int targetNumber = _numberGenerator.GenerateNumber();
            int attempts = 0; 
            bool hasGuessedCorrectly = false;



            while (!hasGuessedCorrectly && attempts < _gameConfiguration.MaxAttempts)
            {
                int guess = _inputReader.ReadInput();


                if (guess < targetNumber)
                {
                    _outputWriter.WriteMessage("Нужно побольше");
                }
                else if (guess > targetNumber)
                {
                    _outputWriter.WriteMessage("Нужно поменьше");
                }
                else
                {

                    _outputWriter.WriteMessage("Молодец");
                    hasGuessedCorrectly = true;
                }

                attempts++; 
            }

            if (!hasGuessedCorrectly)
                _outputWriter.WriteMessage("Попытки кончились");
        }
    }
}
