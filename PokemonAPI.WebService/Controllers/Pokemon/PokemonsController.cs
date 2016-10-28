using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PokemonAPI.WebService.Controllers._Base;

namespace PokemonAPI.WebService.Controllers
{
    [Route("api/v1/pokemons")]
    [ResponseCache(Duration = 30)]
    public class PokemonsController : ApiController
    {
        private readonly IPokemonsService _pokemonsService;

        public PokemonsController(IPokemonsService pokemonsService)
        {
            _pokemonsService = pokemonsService;
        }

        // GET api/v1/pokemons
        // GET api/v1/pokemons?limit=0&offset=20
        [HttpGet]
        public async Task<IActionResult> GetAll(int limit = 20, int offset = 0)
        {
            var pokemons = await _pokemonsService.GetAll(limit, offset);
            if (pokemons == null)
                return NotFound($"Not found with {limit} {offset}");

            return Ok(pokemons);
        }

        // GET api/v1/pokemons/1
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var pokemon = await _pokemonsService.Get(id);
            if (pokemon == null)
                return NotFound(id);

            return Ok(pokemon);
        }

        // GET api/v1/pokemons/pikachu
        [HttpGet("{name}")]
        public async Task<IActionResult> Get(string name)
        {
            var pokemon = await _pokemonsService.Get(name);
            if (pokemon == null)
                return NotFound(name);

            return Ok(pokemon);
        }

        // GET api/v1/pokemons/1/encounters
        [HttpGet("{id:int}/encounters")]
        public async Task<IActionResult> GetEncounters(int id)
        {
            var encounters = await _pokemonsService.GetEncounters(id);
            if (encounters == null || encounters.Count == 0)
                return NotFound(id);

            return Ok(encounters);
        }

        // GET api/v1/pokemons/1/encounters
        [HttpGet("{name}/encounters")]
        public async Task<IActionResult> GetEncounters(string name)
        {
            var encounters = await _pokemonsService.GetEncounters(name);
            if (encounters == null || encounters.Count == 0)
                return NotFound(name);

            return Ok(encounters);
        }
    }
}