using Dapper;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Database
{
    public class DeleteBiography
    {
        private string _connectionString { get; set; }

        public DeleteBiography(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<int> DeleteCharacter(int id)
        {
            const string command = @"DELETE FROM dbo.Biography WHERE Id = @id";

            using (var connection = new SqlConnection(_connectionString))
            {
                var result = await connection.ExecuteAsync(command, new { id });

                return result;
            }
        }
    }
}
