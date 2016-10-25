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
    [Route("api/v1/pokemon-shapes")]
    public class PokemonShapesController : ApiController
    {
        private readonly VeekunContext _context;

        public PokemonShapesController(VeekunContext context)
        {
            _context = context;
        }

        // GET api/v1/pokemon-shapes
        // GET api/v1/pokemon-shapes?skip=0&take=20
        [HttpGet]
        public async Task<IActionResult> GetAll(int limit = 20, int offset = 0)
            => await GetAll(limit, offset, _context.PokemonShapes, GetType());

        // GET api/v1/pokemon-shapes/1
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var pokemonShape = await _context.PokemonShapes
                    .Include(x => x.PokemonShapeProse).ThenInclude(x => x.LocalLanguage)
                    .Include(x => x.PokemonSpecies)
                    .FirstOrDefaultAsync(x => x.Id == id);

                var result = new PokemonShape
                {
                    Id             = pokemonShape.Id,
                    Name           = pokemonShape.Identifier,
                    AwesomeNames   = GetAwesomeNames(pokemonShape),
                    Descriptions   = GetDescriptions(pokemonShape),
                    Names          = GetNames(pokemonShape),
                    PokemonSpecies = GetPokemonSpecies(pokemonShape)
                };

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        private static List<AwesomeName> GetAwesomeNames(EFPokemonShapes pokemonShape)
        {
            return pokemonShape
                .PokemonShapeProse
                .Select(x => new AwesomeName(x.AwesomeName, x.LocalLanguage.ToNamedApiResource()))
                .ToList();
        }

        private static List<Description> GetDescriptions(EFPokemonShapes pokemonShape)
        {
            return pokemonShape
                .PokemonShapeProse
                .Select(x => new Description(x.Description, x.LocalLanguage.ToNamedApiResource()))
                .ToList();
        }

        private static List<Name> GetNames(EFPokemonShapes pokemonShape)
        {
            return pokemonShape
                .PokemonShapeProse
                .Select(x => new Name(x.Name, x.LocalLanguage.ToNamedApiResource()))
                .ToList();
        }

        private static List<NamedAPIResource> GetPokemonSpecies(EFPokemonShapes pokemonShape)
        {
            return pokemonShape
                .PokemonSpecies
                .Select(x => x.ToNamedApiResource())
                .ToList();
        }
    }
}