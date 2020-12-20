using SqlComputeExercise.Compute.Interface;
using SqlComputeExercise.ConsoleTools.Interface;
using SqlComputeExercise.Data.Interface;
using SqlComputeExercise.Data.Model;
using System.Collections.Generic;
using System.Linq;

namespace SqlComputeExercise.Compute
{
    class LinqCompute : ICompute
    {
        public string Name => "Linq";
        public string Description => "Permets d'executer une LinqToSql affichant pour chaque compte son nom et la somme de ses montants absolues associé.";


        private readonly IDataBaseContext _dataBaseContext;
        private readonly IWriter _writer;
        public LinqCompute(IDataBaseContext dataBaseContext, IWriter writer)
        {
            _dataBaseContext = dataBaseContext;
            _writer = writer;
        }
        public void Compute(string[] computeParams)
        {
            List<AccountNameAndLedgerSum> accountNameAndLedgerSums =
                (from accounts in _dataBaseContext.Accounts
                      join ledgers in _dataBaseContext.Ledgers on accounts.Id equals ledgers.AccountId
                      group new { accounts, ledgers } by accounts.Name into accounts_ledgers
                      select new AccountNameAndLedgerSum { Name = accounts_ledgers.Key, Amount = accounts_ledgers.Sum(al=>al.ledgers.Amount) })
                      .ToList();

            _writer.Write("Name  |  Sum");
            foreach (AccountNameAndLedgerSum accountNameAndLedgerSum in accountNameAndLedgerSums) 
            {
                _writer.Write($"{accountNameAndLedgerSum.Name}  |  {accountNameAndLedgerSum.Amount}");
            }
        }
    }
}
