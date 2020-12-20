using System.Collections.Generic;

namespace SqlComputeExercise.Data.Model
{
    class Account
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string Name { get; set; }

        public virtual List<Ledger> Ledger { get; set; }
    }
}
