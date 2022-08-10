using System.Data.SqlClient;
using Xunit.Abstractions;

namespace Databases
{
    public class Test_Databases
    {
        private ITestOutputHelper _output;
        private readonly string connectionString = "server=localhost\\test-sqlserver-2017,1401; user id=sa; password=cory@corytest; initial catalog=Test";

        public Test_Databases(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void Test_DB_Sync()
        {
            string sql = "Select @@VERSION";

            using SqlConnection sqlConnection = new(connectionString);
            sqlConnection.Open();

            using SqlCommand command = new(sql, sqlConnection);
            using SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                var data = reader[0].ToString();
                _output.WriteLine(data);
            }
        }

        // Using the Begin End Pattern
        [Fact]
        public void Test_DB_Async()
        {
            string sql = "Select @@VERSION";

            using SqlConnection sqlConnection = new(connectionString);
            sqlConnection.Open();

            using SqlCommand command = new(sql, sqlConnection);
            var callback = new AsyncCallback(DataAvailable);
            var ar = command.BeginExecuteReader(callback, command);

            ar.AsyncWaitHandle.WaitOne();
        }

        // Callback done in a background thread
        private void DataAvailable(IAsyncResult ar)
        {
            var sqlCommand = ar.AsyncState as SqlCommand;
            using (var reader = sqlCommand.EndExecuteReader(ar))
            {
                while (reader.Read())
                {
                    var data = reader[0].ToString();
                    _output.WriteLine(data);
                }
            }
        }

        [Fact]
        public void Test_DB_TaskAsync()
        {
            string sql = "Select @@VERSION";
            var data = string.Empty;
            using SqlConnection sqlConnection = new(connectionString);
            Task taskSqlConnection = sqlConnection.OpenAsync();
            taskSqlConnection.ContinueWith((Task tx, object state) =>
            {
                var command = new SqlCommand(sql, sqlConnection);
                Task<SqlDataReader> taskDataReader = command.ExecuteReaderAsync();
                Task taskProcessData = taskDataReader.ContinueWith((Task<SqlDataReader> tx) =>
                {
                    using (var reader = tx.Result)
                    {
                        while (reader.Read())
                        {
                            data = reader[0].ToString();
                        }
                    }
                },TaskContinuationOptions.OnlyOnRanToCompletion);
            }
            ,sqlConnection
            ,TaskContinuationOptions.OnlyOnRanToCompletion
            );

            _output.WriteLine("data from Test_DB_TaskAsync: {0}", data);
        }
        ManualResetEvent resetEvent = new(false);
    }
}