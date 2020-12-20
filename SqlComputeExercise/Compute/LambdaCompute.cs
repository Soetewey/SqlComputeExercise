using SqlComputeExercise.Compute.Interface;
using SqlComputeExercise.ConsoleTools.Interface;
using SqlComputeExercise.Data.Interface;
using SqlComputeExercise.Data.Model;
using System.Collections.Generic;
using System.Linq;

namespace SqlComputeExercise.Compute
{
    class LambdaCompute : ICompute
    {
        public string Name  => "Lambda";
        public string Description => "Permets d'executer une lambda";

        private readonly IDataBaseContext _dataBaseContext;
        private readonly IWriter _writer;

        public LambdaCompute(IDataBaseContext dataBaseContext, IWriter writer) 
        {
            _dataBaseContext = dataBaseContext;
            _writer = writer;
        }
        public void Compute(string[] computeParams)
        {
            List<EntryNameAndAccountCount> entryNameAndAccountCounts =
                _dataBaseContext.Entries.Join(_dataBaseContext.Ledgers,
                                              entry => entry.Id, ledger => ledger.EntryId,
                                              (entry, ledger) => new { entries = entry, ledgers = ledger })
                .GroupBy(entry_ledger => entry_ledger.entries.Name)
                .Select(result => new EntryNameAndAccountCount { Name = result.Key, Count = result.Select(ledger => ledger.ledgers.AccountId).Distinct().Count()})
                .ToList();
            _writer.Write("Name  |  Count");
            foreach (EntryNameAndAccountCount entryNameAndAccountCount in entryNameAndAccountCounts)
            {
                _writer.Write($"{entryNameAndAccountCount.Name}  |  {entryNameAndAccountCount.Count}");
            }
        }
    }
}
