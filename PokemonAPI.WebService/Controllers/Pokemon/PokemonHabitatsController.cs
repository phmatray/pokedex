using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Controllers._Base;
using PokemonAPI.WebService.Core;
using PokemonAPI.WebService.Models;

namespace PokemonAPI.WebService.Controllers
{
    [Route("api/v1/pokemon-habitats")]
    public class PokemonHabitatsController : ApiController
    {
        private readonly VeekunContext _context;

        public PokemonHabitatsController(VeekunContext context)
        {
            _context = context;
        }

        // GET api/v1/pokemon-habitats
        // GET api/v1/pokemon-habitats?skip=0&take=20
        [HttpGet]
        public async Task<IActionResult> GetAll(int limit = 20, int offset = 0)
            => await GetAll(limit, offset, _context.PokemonHabitats, GetType());

        // GET api/v1/pokemon-habitats/1
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var pokemonHabitat = await _context
                    .PokemonHabitats
                    .AsNoTracking()
                    .Include(x => x.PokemonHabitatNames).ThenInclude(x => x.LocalLanguage)
                    .Include(x => x.PokemonSpecies)
                    .FirstOrDefaultAsync(x => x.Id == id);

                var result = new PokemonHabitat
                {
                    Id             = pokemonHabitat.Id,
                    Name           = pokemonHabitat.Identifier,
                    Names          = GetNames(pokemonHabitat),
                    PokemonSpecies = GetPokemonSpecies(pokemonHabitat)
                };

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        private static List<Name> GetNames(EFPokemonHabitats pokemonHabitat)
        {
            return pokemonHabitat
                .PokemonHabitatNames
                .Select(x => new Name(x.Name, x.LocalLanguage.ToNamedApiResource()))
                .ToList();
        }

        private static List<NamedAPIResource> GetPokemonSpecies(EFPokemonHabitats pokemonHabitat)
        {
            return pokemonHabitat
                .PokemonSpecies
                .Select(x => x.ToNamedApiResource())
                .ToList();
        }
    }
}