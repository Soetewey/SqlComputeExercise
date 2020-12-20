using System;

namespace SqlComputeExercise.Exceptions
{
    class IncorrectWelcomeMenuInputException : IncorrectInputException
    {
        public IncorrectWelcomeMenuInputException() : base() { }
        public IncorrectWelcomeMenuInputException(string message) : base(message) { }
        public IncorrectWelcomeMenuInputException(string message, Exception innerException) : base(message, innerException) { }
    }
}
