using Dapper;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Database
{
    public class UpdateBiography
    {
        private string _connectionString { get; set; }

        public UpdateBiography(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<int> UpdateCharacterName(int id, string name)
        {
            const string command = @"UPDATE dbo.Biography SET Name = @name WHERE Id = @id";

            using (var connection = new SqlConnection(_connectionString))
            {
                var result = await connection.ExecuteAsync(command, new { id, name });

                return result;
            }
        }
    }
}
