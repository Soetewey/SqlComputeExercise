using SqlComputeExercise.ConsoleTools.Interface;
using System;

namespace SqlComputeExercise.ConsoleTools
{
    class Writer : IWriter
    {
        public void Write(string contentToWrite)
        {
            Console.WriteLine(contentToWrite);
        }

        public void WriteError(string contentToWrite)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine();
            Console.WriteLine(contentToWrite);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
