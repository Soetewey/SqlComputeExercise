using Microsoft.EntityFrameworkCore;
using SqlComputeExercise.Data.Interface;
using SqlComputeExercise.Data.Model;

namespace SqlComputeExercise.Data
{
    class DataBaseContext : DbContext,IDataBaseContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Entry> Entries { get; set; }
        public DbSet<Ledger> Ledgers { get; set; }

        public DataBaseContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=C:\\sqllite\\BaseTest.db;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().ToTable("Account");
            modelBuilder.Entity<Entry>().ToTable("Entry");
            modelBuilder.Entity<Ledger>().ToTable("Ledger");
        }
    }
}
