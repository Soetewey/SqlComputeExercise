using System;

namespace SqlComputeExercise.Exceptions
{
    class IncorrectInputException : Exception
    {
        static string incorrectInputMessage = "Your input is not correct. ";
        public IncorrectInputException() : base(incorrectInputMessage) { }
        public IncorrectInputException(string message) : base(incorrectInputMessage + message) { }
        public IncorrectInputException(string message, Exception innerException) : base(incorrectInputMessage + message, innerException) { }
    }
}
