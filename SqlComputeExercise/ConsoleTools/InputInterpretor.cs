using SqlComputeExercise.Compute.Interface;
using SqlComputeExercise.ConsoleTools.Interface;
using SqlComputeExercise.Exceptions;
using System;
using System.Linq;
using Unity;

namespace SqlComputeExercise.ConsoleTools
{
    class InputInterpretor : IInputInterpretor
    {
        private readonly UnityContainer _iocContainer;
        private readonly IWriter _writer;
        public InputInterpretor(UnityContainer iocContainer, IWriter writer)
        {
            _iocContainer = iocContainer;
            _writer = writer;
        }
        public void InterpretMenuMessage(string menuMessage)
        {
            if (string.IsNullOrEmpty(menuMessage)) 
            {
                throw new IncorrectMainMenuInputException($"Read choice was empty");
            }
            string[] choiceAndParams = menuMessage.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string choice = choiceAndParams[0];
            if (!_iocContainer.IsRegistered<ICompute>(choice)) 
            {
                string possibleValues = string.Join(',', _iocContainer.ResolveAll<ICompute>().Select(c => c.GetName()).ToList());
                throw new IncorrectMainMenuInputException($"Possible values : {possibleValues}. Received value : {menuMessage}");
            }
            else
            {
                _iocContainer.Resolve<ICompute>(choice).Compute(choiceAndParams.Skip(1).ToArray());
            }
        }

        public bool InterpretOpeningMessage(string openingMessage)
        {
            switch (openingMessage)
            {
                case "C":
                    return true ;
                case "Q":
                    _writer.Write("Merci et à bientôt.");
                    return false;
                default:
                    throw new IncorrectWelcomeMenuInputException("Possible values : C, Q. Received value : " + openingMessage);
            }
        }
    }
}
