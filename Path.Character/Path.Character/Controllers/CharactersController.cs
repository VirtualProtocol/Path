using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Paramore.Brighter;
using Paramore.Darker;

namespace Path.Character.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharactersController : ControllerBase
    {
        private readonly IAmACommandProcessor _commandProvider;

        private readonly IQueryProcessor _queryProvider;

        public CharactersController(IQueryProcessor queryProcessor, IAmACommandProcessor commandProcessor)
        {
            _commandProvider = commandProcessor;
            _queryProvider = queryProcessor;
        }

        // GET: api/Character
        [HttpGet]
        public async Task<IEnumerable<string>> Get()
        {
            var results = await _queryProvider.ExecuteAsync<IEnumerable<string>>(new GetCharacters)
            return new string[] { "value1", "value2" };
        }

        // GET: api/Character/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Character
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Character/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
