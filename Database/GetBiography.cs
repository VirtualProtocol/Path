using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Database
{
    public class GetBiography
    {
        private string _connectionString { get; set; }

        public GetBiography(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<string>> GetCharacterNames()
        {
            const string query = @"SELECT Name FROM dbo.Biography";

            using (var connection = new SqlConnection(_connectionString))
            {
                var results = await connection.QueryAsync<string>(query);

                return results.ToList();
            }
        }

        public async Task<string> GetCharacterName(int id)
        {
            const string query = @"SELECT Name FROM dbo.Biography WHERE Id = @id";

            using (var connection = new SqlConnection(_connectionString))
            {
                var result = await connection.QuerySingleAsync<string>(query, new { id });

                return result;
            }
        }
    }
}
