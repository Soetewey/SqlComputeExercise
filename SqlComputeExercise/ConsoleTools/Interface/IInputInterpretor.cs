namespace SqlComputeExercise.ConsoleTools.Interface
{
    interface IInputInterpretor
    {
        bool InterpretOpeningMessage(string openingMessage);
        void InterpretMenuMessage(string menuMessage);
    }
}
