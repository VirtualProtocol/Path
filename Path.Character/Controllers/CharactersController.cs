using Database;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Path.Character.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharactersController : ControllerBase
    {
        private readonly string _connectionString;

        public CharactersController(string connectionString)
        {
            _connectionString = connectionString;
        }

        // GET: api/Character
        [HttpGet]
        public async Task<IEnumerable<string>> GetNamesAsync()
        {
            var biographyTable = new GetBiography(_connectionString);
            var results = await biographyTable.GetCharacterNames();
            
            return results;
        }

        // GET: api/Character/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<string> GetNameAsync(int id)
        {
            var biographyTable = new GetBiography(_connectionString);
            var result = await biographyTable.GetCharacterName(id);
            
            return result;
        }

        // POST: api/Character
        [HttpPost("/Create")]
        public async Task<int> PostNameAsync([FromBody] string value)
        {
            var biographyTable = new InsertBiography(_connectionString);
            var result = await biographyTable.InsertCharacterBiography(value);

            return result;
        }

        // PUT: api/Character/5
        [HttpPut("{id}")]
        public async Task<int> PutNameAsync(int id, [FromBody] string value)
        {
            var biographyTable = new UpdateBiography(_connectionString);
            var result = await biographyTable.UpdateCharacterName(id, value);

            return result;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}/Remove")]
        public async Task<int> DeleteNameAsync(int id)
        {
            var biographyTable = new DeleteBiography(_connectionString);
            var result = await biographyTable.DeleteCharacter(id);

            return result;
        }
    }
}
