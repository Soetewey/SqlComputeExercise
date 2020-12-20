using System;

namespace SqlComputeExercise.Exceptions
{
    class IncorrectMainMenuInputException : IncorrectInputException
    {
        public IncorrectMainMenuInputException() : base() { }
        public IncorrectMainMenuInputException(string message) : base(message) { }
        public IncorrectMainMenuInputException(string message, Exception innerException) : base(message, innerException) { }
    }
}
