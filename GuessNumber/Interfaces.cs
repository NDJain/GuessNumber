using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessNumber
{
    public interface IGameConfiguration
    {
        int MinRange { get; }
        int MaxRange { get; }
        int MaxAttempts { get; }
    }
    public interface INumberGenerator
    {
        int GenerateNumber();
    }

    public interface IInputReader
    {
        int ReadInput();
    }

    public interface ITracker
    {
        int Attempt { get; }
        void IncrementAttempt();
    }

    public interface IOutputWriter
    {
        void WriteMessage(string message);
    }
}
