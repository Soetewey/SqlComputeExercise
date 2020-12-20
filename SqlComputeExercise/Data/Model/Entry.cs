using System.Collections.Generic;

namespace SqlComputeExercise.Data.Model
{
    class Entry
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

        public virtual List<Ledger> Ledger { get; set; }
    }
}
