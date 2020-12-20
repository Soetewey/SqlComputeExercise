using Microsoft.EntityFrameworkCore;
using SqlComputeExercise.Compute.Interface;
using SqlComputeExercise.ConsoleTools.Interface;
using System.Data.Common;

namespace SqlComputeExercise.Compute
{
    class SqlCompute : ICompute
    {
        public string Name => "Sql";
        public string Description => @"Permets d'executer une requête SQL";

        private readonly DbContext _dataBaseContext;
        private readonly IWriter _writer;

        public SqlCompute(DbContext dataBaseContext, IWriter writer)
        {
            _dataBaseContext = dataBaseContext;
            _writer = writer;
        }

        public void Compute(string[] computeParams)
        {
            string request = @"SELECT total.ID,total.Code,total.Name, 
                (case when total.sum > 0 THEN 'KO.U' ELSE case WHEN total.sum < 0 THEN 'KO.D' ELSE 'OK' END END)Status
               FROM(
                SELECT e.ID, e.Code, e.Name, SUM(l.Amount)SUM FROM ENTRY e, LEDGER l
                 WHERE e.id = l.EntryId
                 GROUP BY e.id)total";
            using DbCommand command = _dataBaseContext.Database.GetDbConnection().CreateCommand();
            command.CommandText = request;
            _dataBaseContext.Database.OpenConnection();
            using DbDataReader reader = command.ExecuteReader();
            _writer.Write("Id\tCode\tName\tStatus");
            if (reader.HasRows)
                while (reader.Read())
                    _writer.Write($"{reader.GetInt32(0)}\t{reader.GetString(1)}\t{reader.GetString(2)}\t{reader.GetString(3)}");
            else
                _writer.Write("No rows found.");
            reader.Close();
            _dataBaseContext.Database.CloseConnection();
        }
    }
}
