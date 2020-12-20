namespace SqlComputeExercise.Compute.Interface
{
    interface ICompute
    {
        string Name { get; }
        string Description { get; }
        public string GetName() { return Name; }
        public string GetDescription() { return Description;  }
        public string GetNameAndDescription() { return $"{Name} => {Description}"; }
        void Compute(string[] computeParams);
    }
}
