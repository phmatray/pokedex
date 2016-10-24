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
                    .FirstOrDefaultAsync(x => x.Id == id);

                var result = new PokemonShape
                {
                    Id             = pokemonShape.Id,
                    Name           = pokemonShape.Identifier,
                    AwesomeNames   = await GetAwesomeNames(pokemonShape),
                    Descriptions   = await GetDescriptions(pokemonShape),
                    Names          = await GetNames(pokemonShape),
                    PokemonSpecies = await GetPokemonSpecies(pokemonShape)
                };

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        private async Task<List<AwesomeName>> GetAwesomeNames(EFPokemonShapes pokemonShape)
        {
            return (await _context
                    .PokemonShapeProse
                    .Include(x => x.LocalLanguage)
                    .Where(x => x.PokemonShapeId == pokemonShape.Id)
                    .ToListAsync())
                .Select(x => new AwesomeName(x.AwesomeName,
                    x.LocalLanguage.ToNamedApiResource()))
                .ToList();
        }

        private async Task<List<Description>> GetDescriptions(EFPokemonShapes pokemonShape)
        {
            return (await _context
                    .PokemonShapeProse
                    .Include(x => x.LocalLanguage)
                    .Where(x => x.PokemonShapeId == pokemonShape.Id)
                    .ToListAsync())
                .Select(x => new Description(x.Description,
                    x.LocalLanguage.ToNamedApiResource()))
                .ToList();
        }

        private async Task<List<Name>> GetNames(EFPokemonShapes pokemonShape)
        {
            return (await _context
                    .PokemonShapeProse
                    .Include(x => x.LocalLanguage)
                    .Where(x => x.PokemonShapeId == pokemonShape.Id)
                    .ToListAsync())
                .Select(x => new Name(x.Name,
                    x.LocalLanguage.ToNamedApiResource()))
                .ToList();
        }

        private async Task<List<NamedAPIResource>> GetPokemonSpecies(EFPokemonShapes pokemonShape)
        {
            return (await _context
                    .PokemonSpecies
                    .Where(x => x.ShapeId == pokemonShape.Id)
                    .ToListAsync())
                .Select(x => x.ToNamedApiResource())
                .ToList();
        }
    }
}