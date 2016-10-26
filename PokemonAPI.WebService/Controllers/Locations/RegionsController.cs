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
    [Route("api/v1/regions")]
    public class RegionsController : ApiController
    {
        private readonly VeekunContext _context;

        public RegionsController(VeekunContext context)
        {
            _context = context;
        }

        // GET api/v1/regions
        // GET api/v1/regions?skip=0&take=20
        [HttpGet]
        public async Task<IActionResult> GetAll(int limit = 20, int offset = 0)
            => await GetAll(limit, offset, _context.Regions, GetType());

        // GET api/v1/regions/1
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var region = await _context.Regions
                    .AsNoTracking()
                    .Include(x => x.Locations)
                    .Include(x => x.VersionGroupRegions).ThenInclude(x => x.VersionGroup)
                    .Include(x => x.RegionNames).ThenInclude(x => x.LocalLanguage)
                    .Include(x => x.Generations)
                    .Include(x => x.Pokedexes)
                    .FirstOrDefaultAsync(x => x.Id == id);

                var result = new Region
                {
                    Id             = region.Id,
                    Name           = region.Identifier,
                    Locations      = GetLocations(region),
                    VersionGroups  = GetVersionGroups(region),
                    Names          = GetNames(region),
                    MainGeneration = GetMainGeneration(region),
                    Pokedexes      = GetPokedexes(region)
                };

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        private static List<NamedAPIResource> GetLocations(EFRegions region)
        {
            return region
                .Locations
                .Select(x => x.ToNamedApiResource())
                .ToList();
        }

        private static List<NamedAPIResource> GetVersionGroups(EFRegions region)
        {
            return region
                .VersionGroupRegions
                .Select(x => x.VersionGroup.ToNamedApiResource())
                .ToList();
        }

        private static List<Name> GetNames(EFRegions region)
        {
            return region
                .RegionNames
                .Select(x => new Name(x.Name, x.LocalLanguage.ToNamedApiResource()))
                .ToList();
        }

        private static NamedAPIResource GetMainGeneration(EFRegions region)
        {
            return region
                .Generations
                .FirstOrDefault(x => x.MainRegionId == region.Id)?
                .ToNamedApiResource();
        }

        private static List<NamedAPIResource> GetPokedexes(EFRegions region)
        {
            return region
                .Pokedexes
                .Select(x => x.ToNamedApiResource())
                .ToList();
        }
    }
}