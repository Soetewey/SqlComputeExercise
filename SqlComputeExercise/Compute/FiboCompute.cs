using SqlComputeExercise.Compute.Interface;
using SqlComputeExercise.ConsoleTools.Interface;
using SqlComputeExercise.Exceptions;
using System;

namespace SqlComputeExercise.Compute
{
    class FiboCompute : ICompute
    {
        public string Name => "Fibo";
        public string Description => "Permets de résoudre la suite de Fibonacci. Passer un entier en arguments.";

        private readonly IWriter _writer;

        public FiboCompute(IWriter writer) 
        {
            _writer = writer;
        }

        public void Compute(string[] computeParams)
        {
            if (computeParams == null || computeParams.Length < 1)
                throw new IncorrectParamsException("No params set");
            if (!Int32.TryParse(computeParams[0], out int fiboParameter)) 
                throw new IncorrectParamsException($"{computeParams[0]} is not a valid integer");
            if (fiboParameter < 0)
                throw new IncorrectParamsException($"{fiboParameter} is < 0. Please enter a positive value");
            if (fiboParameter > 45)
                throw new IncorrectParamsException($"{fiboParameter} is > 45, so result would be higher than max int.");
            _writer.Write($"Fibo({fiboParameter}) = {Fibo(fiboParameter)}");
        }

        private int Fibo(int iterations) 
        {
            return (iterations < 2) ? iterations : Fibo(iterations - 2) + Fibo(iterations - 1);
        }
    }
}
