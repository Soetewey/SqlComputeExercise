using Microsoft.EntityFrameworkCore;
using SqlComputeExercise.Data.Model;

namespace SqlComputeExercise.Data.Interface
{
    interface IDataBaseContext
    {
        DbSet<Account> Accounts { get; set; }
        DbSet<Entry> Entries { get; set; }
        DbSet<Ledger> Ledgers { get; set; }
    }
}
