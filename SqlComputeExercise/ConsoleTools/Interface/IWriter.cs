namespace SqlComputeExercise.ConsoleTools.Interface
{
    interface IWriter
    {
        void Write(string contentToWrite);
        void WriteError(string contentToWrite);
    }
}
