using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Controllers.Base;
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
        {
            return await base.GetAll(limit, offset, 
                _context.PokemonHabitats, this.Segment());
        }

        // GET api/v1/pokemon-habitats/1
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var pokemonHabitat = await _context.PokemonHabitats
                    .FirstOrDefaultAsync(x => x.Id == id);

                var result = new PokemonHabitat
                {
                    Id             = pokemonHabitat.Id,
                    Name           = pokemonHabitat.Identifier,
                    Names          = await GetNames(pokemonHabitat),
                    PokemonSpecies = await GetPokemonSpecies(pokemonHabitat)
                };

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        private async Task<List<Name>> GetNames(EFPokemonHabitats pokemonHabitat)
        {
            return (await _context
                    .PokemonHabitatNames
                    .Include(x => x.LocalLanguage)
                    .Where(x => x.PokemonHabitatId == pokemonHabitat.Id)
                    .ToListAsync())
                .Select(x => new Name(x.Name,
                    x.LocalLanguage.ToNamedApiResource(typeof(LanguagesController).Segment())))
                .ToList();
        }

        private async Task<List<NamedAPIResource>> GetPokemonSpecies(EFPokemonHabitats pokemonHabitat)
        {
            return (await _context
                    .PokemonSpecies
                    .Where(x => x.HabitatId == pokemonHabitat.Id)
                    .ToListAsync())
                .Select(x => x.ToNamedApiResource(typeof(PokemonSpeciesController).Segment()))
                .ToList();
        }
    }
}