using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PokemonAPI.Models.Resources;
using PokemonAPI.Models.SourceTypeEnums;
using PokemonAPI.WebService.Controllers.Base;
using PokemonAPI.WebService.Core;
using PokemonAPI.WebService.Models;

namespace PokemonAPI.WebService.Controllers
{
    [Route("api/v1/[controller]")]
    public class RegionsController : ApiController<Regions>
    {
        public RegionsController(VeekunContext context)
            : base(context)
        {
        }

        // GET api/v1/regions
        // GET api/v1/regions?skip=0&take=20
        [HttpGet]
        public async Task<IActionResult> GetAll(int limit = 20, int offset = 0)
        {
            return await base.GetAll(limit, offset);
        }

        // GET api/v1/regions/1
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var region = await MainDbSet
                    .FirstOrDefaultAsync(x => x.Id == id);

                var result = new RegionResource
                {
                    Id             = region.Id,
                    Identifier     = region.Identifier,
                    Locations      = await GetLocations(region),
                    VersionGroups  = await GetVersionGroups(region),
                    Names          = await GetNames(region),
                    MainGeneration = await GetMainGeneration(region),
                    Pokedexes      = await GetPokedexes(region)
                };

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        private async Task<List<NamedAPIResource>> GetLocations(Regions region)
        {
            return (await Context
                    .Locations
                    .Where(x => x.RegionId == region.Id)
                    .ToListAsync())
                .Select(x => x.ToNamedApiResource())
                .ToList();
        }

        private async Task<List<NamedAPIResource>> GetVersionGroups(Regions region)
        {
            return (await Context
                    .VersionGroupRegions
                    .Include(x => x.VersionGroup)
                    .Where(x => x.RegionId == region.Id)
                    .ToListAsync())
                .Select(x => x.ToNamedApiResource(VersionGroupRegionSourceType.Region))
                .ToList();
        }

        private async Task<List<NameResource>> GetNames(Regions region)
        {
            return (await Context
                    .RegionNames
                    .Include(x => x.LocalLanguage)
                    .Where(x => x.RegionId == region.Id)
                    .ToListAsync())
                .Select(x => x.ToNameResource())
                .ToList();
        }

        private async Task<NamedAPIResource> GetMainGeneration(Regions region)
        {
            return (await Context
                    .Generations
                    .FirstOrDefaultAsync(x => x.MainRegionId == region.Id))?
                .ToNamedApiResource();
        }

        private async Task<List<NamedAPIResource>> GetPokedexes(Regions region)
        {
            return (await Context
                    .Pokedexes
                    .Where(x => x.RegionId == region.Id)
                    .ToListAsync())
                .Select(x => x.ToNamedApiResource())
                .ToList();
        }
    }
}