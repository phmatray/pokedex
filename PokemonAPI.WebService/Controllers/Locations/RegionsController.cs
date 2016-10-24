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
        {
            return await base.GetAll(limit, offset, _context.Regions, this.Segment());
        }

        // GET api/v1/regions/1
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var region = await _context.Regions
                    .FirstOrDefaultAsync(x => x.Id == id);

                var result = new Region
                {
                    Id             = region.Id,
                    Name           = region.Identifier,
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

        private async Task<List<NamedAPIResource>> GetLocations(EFRegions region)
        {
            return (await _context
                    .Locations
                    .Where(x => x.RegionId == region.Id)
                    .ToListAsync())
                .Select(x => x.ToNamedApiResource())
                .ToList();
        }

        private async Task<List<NamedAPIResource>> GetVersionGroups(EFRegions region)
        {
            return (await _context
                    .VersionGroupRegions
                    .Include(x => x.VersionGroup)
                    .Where(x => x.RegionId == region.Id)
                    .ToListAsync())
                .Select(x => new NamedAPIResource
                (
                    x.VersionGroup.Identifier,
                    $"{Constants.SiteUrl}{Constants.BaseUrl}{typeof(VersionGroupsController).Segment()}/{x.VersionGroupId}/"
                ))
                .ToList();
        }

        private async Task<List<Name>> GetNames(EFRegions region)
        {
            return (await _context
                    .RegionNames
                    .Include(x => x.LocalLanguage)
                    .Where(x => x.RegionId == region.Id)
                    .ToListAsync())
                .Select(x => new Name(x.Name,
                    x.LocalLanguage.ToNamedApiResource()))
                .ToList();
        }

        private async Task<NamedAPIResource> GetMainGeneration(EFRegions region)
        {
            return (await _context
                    .Generations
                    .FirstOrDefaultAsync(x => x.MainRegionId == region.Id))?
                .ToNamedApiResource();
        }

        private async Task<List<NamedAPIResource>> GetPokedexes(EFRegions region)
        {
            return (await _context
                    .Pokedexes
                    .Where(x => x.RegionId == region.Id)
                    .ToListAsync())
                .Select(x => x.ToNamedApiResource())
                .ToList();
        }
    }
}