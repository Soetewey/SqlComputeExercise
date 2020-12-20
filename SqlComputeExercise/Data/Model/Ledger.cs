using System.ComponentModel.DataAnnotations.Schema;

namespace SqlComputeExercise.Data.Model
{
    class Ledger
    {
        public int Id { get; set; }
        public int? EntryId { get; set; }
        public int? AccountId { get; set; }
        public double? Amount { get; set; }

        [ForeignKey("EntryId")]
        public virtual Entry Entry { get; set; }
        [ForeignKey("AccountId")]
        public virtual Account Account { get; set; }
    }
}
