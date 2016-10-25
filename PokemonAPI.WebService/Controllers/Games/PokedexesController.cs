using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Core;
using PokemonAPI.WebService.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using PokemonAPI.WebService.Controllers._Base;

namespace PokemonAPI.WebService.Controllers
{
    [Route("api/v1/pokedexes")]
    public class PokedexesController : ApiController
    {
        private readonly VeekunContext _context;

        public PokedexesController(VeekunContext context)
        {
            _context = context;
        }

        // GET api/v1/pokedexes
        // GET api/v1/pokedexes?skip=0&take=20
        [HttpGet]
        public async Task<IActionResult> GetAll(int limit = 20, int offset = 0)
            => await GetAll(limit, offset, _context.Pokedexes, GetType());

        // GET api/v1/pokedexes/1
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var pokedex = await _context.Pokedexes
                    .Include(x => x.Region)
                    .Include(x => x.PokedexVersionGroups).ThenInclude(x => x.VersionGroup)
                    .Include(x => x.PokedexProse).ThenInclude(x => x.LocalLanguage)
                    .Include(x => x.PokemonDexNumbers).ThenInclude(x => x.Species)
                    .FirstOrDefaultAsync(x => x.Id == id);

                var result = new Pokedex
                {
                    Id             = pokedex.Id,
                    Name           = pokedex.Identifier,
                    IsMainSeries   = pokedex.IsMainSeries,
                    Region         = GetRegion(pokedex),
                    VersionGroups  = GetVersionGroups(pokedex),
                    Descriptions   = GetDescriptions(pokedex),
                    PokemonEntries = GetEntries(pokedex),
                    Names          = GetNames(pokedex)
                };

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        private static NamedAPIResource GetRegion(EFPokedexes pokedex)
        {
            return pokedex
                .Region?
                .ToNamedApiResource();
        }

        private static List<NamedAPIResource> GetVersionGroups(EFPokedexes pokedex)
        {
            return pokedex
                .PokedexVersionGroups
                .Select(x => x.VersionGroup.ToNamedApiResource())
                .ToList();
        }

        private static List<Description> GetDescriptions(EFPokedexes pokedex)
        {
            return pokedex
                .PokedexProse
                .Select(x => new Description(x.Description, x.LocalLanguage.ToNamedApiResource()))
                .ToList();
        }

        private static List<PokemonEntry> GetEntries(EFPokedexes pokedex)
        {
            return pokedex
                .PokemonDexNumbers
                .OrderBy(x => x.PokedexNumber)
                .Select(x => new PokemonEntry(x.PokedexNumber, x.Species.ToNamedApiResource()))
                .ToList();
        }

        private static List<Name> GetNames(EFPokedexes pokedex)
        {
            return pokedex
                .PokedexProse
                .Select(x => new Name(x.Name, x.LocalLanguage.ToNamedApiResource()))
                .ToList();
        }
    }
}