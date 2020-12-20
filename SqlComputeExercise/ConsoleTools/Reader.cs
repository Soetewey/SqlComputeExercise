using SqlComputeExercise.ConsoleTools.Interface;
using System;

namespace SqlComputeExercise.ConsoleTools
{
    class Reader : IReader
    {
        public string Read()
        {
            return Console.ReadLine();
        }
    }
}
