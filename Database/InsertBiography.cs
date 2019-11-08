using Dapper;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Database
{
    public class InsertBiography
    {
        private string _connectionString { get; set; }

        public InsertBiography(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<int> InsertCharacterBiography(string name)
        {
            const string query = @"INSERT INTO dbo.Biography (Name) VALUES (@name)";

            using (var connection = new SqlConnection(_connectionString))
            {
                var result = await connection.ExecuteAsync(query, new { name });

                return result;
            }
        }
    }
}
