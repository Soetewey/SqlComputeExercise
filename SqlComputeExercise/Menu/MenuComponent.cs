using SqlComputeExercise.Compute.Interface;
using SqlComputeExercise.ConsoleTools.Interface;
using SqlComputeExercise.Exceptions;
using SqlComputeExercise.Menu.Interface;
using System;
using System.Linq;
using Unity;

namespace SqlComputeExercise.Menu
{
    class MenuComponent : IMenuComponent
    {
        private readonly UnityContainer _iocContainer;
        private readonly IReader _reader;
        private readonly IWriter _writer;
        private readonly IInputInterpretor _inputInterpretor;
        public MenuComponent(UnityContainer iocContainer, IReader reader, IWriter writer, IInputInterpretor inputInterpretor) 
        {
            _iocContainer = iocContainer;
            _reader = reader;
            _writer = writer;
            _inputInterpretor = inputInterpretor;
        }
        public void ManageMainMenu()
        {
            try
            {
                _writer.Write("Selectionnez une option : ");
                _writer.Write(string.Join('\n', _iocContainer.ResolveAll<ICompute>().Select(c => c.GetNameAndDescription()).ToList()));
                _inputInterpretor.InterpretMenuMessage(_reader.Read());
                ManageWelcomeMenu();
            }
            catch (IncorrectMainMenuInputException incorrectMainMenuInputException) 
            {
                _writer.WriteError(incorrectMainMenuInputException.Message);
                ManageMainMenu();
            }
            catch (IncorrectParamsException incorrectParamsException)
            {
                _writer.WriteError(incorrectParamsException.Message);
                ManageMainMenu();
            }
        }

        public void ManageWelcomeMenu()
        {
            try
            {
                _writer.Write("Voulez - vous effectuer des calculs ou quitter l’application ? (C pour les calculs / Q pour quitter)");
                if (_inputInterpretor.InterpretOpeningMessage(_reader.Read()))
                    ManageMainMenu();
                Environment.Exit(0);
            }
            catch (IncorrectWelcomeMenuInputException incorrectWelcomeMenuInputException)
            {
                _writer.WriteError(incorrectWelcomeMenuInputException.Message);
                ManageWelcomeMenu();
            }
        }
    }
}
