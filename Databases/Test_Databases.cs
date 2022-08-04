using System.Data.SqlClient;
using Xunit.Abstractions;

namespace Databases
{
    public class Test_Databases
    {
        private readonly ITestOutputHelper _output;
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
    }
}