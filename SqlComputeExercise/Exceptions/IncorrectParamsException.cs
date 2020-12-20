using System;

namespace SqlComputeExercise.Exceptions
{
    class IncorrectParamsException : Exception
    {
        static string incorrectParamsMessage = "Your input params are not correct. ";
        public IncorrectParamsException() : base(incorrectParamsMessage) { }
        public IncorrectParamsException(string message) : base(incorrectParamsMessage + message) { }
        public IncorrectParamsException(string message, Exception innerException) : base(incorrectParamsMessage + message, innerException) { }
    }
}
