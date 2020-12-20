using SqlComputeExercise.Compute.Interface;
using SqlComputeExercise.Menu.Interface;

namespace SqlComputeExercise.Compute
{
    class PreviousCompute : ICompute
    {
        public string Name => "P";
        public string Description => "Permets de retourner au premier menu";

        private readonly IMenuComponent _menuComponent;

        public PreviousCompute(IMenuComponent menuComponent)
        {
            _menuComponent = menuComponent;
        }

        public void Compute(string[] computeParams)
        {
            _menuComponent.ManageWelcomeMenu();
        }
    }
}
