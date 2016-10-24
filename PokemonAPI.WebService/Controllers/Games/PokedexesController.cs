using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Controllers.Base;
using PokemonAPI.WebService.Core;
using PokemonAPI.WebService.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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
        {
            return await base.GetAll(limit, offset, _context.Pokedexes, this.Segment());
        }

        // GET api/v1/pokedexes/1
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var pokedex = await _context.Pokedexes
                    .FirstOrDefaultAsync(x => x.Id == id);

                var result = new Pokedex
                {
                    Id             = pokedex.Id,
                    Name           = pokedex.Identifier,
                    IsMainSeries   = pokedex.IsMainSeries,
                    Region         = await GetRegion(pokedex),
                    VersionGroups  = await GetVersionGroups(pokedex),
                    Descriptions   = await GetDescriptions(pokedex),
                    PokemonEntries = await GetEntries(pokedex),
                    Names          = await GetNames(pokedex)
                };

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        private async Task<NamedAPIResource> GetRegion(EFPokedexes pokedex)
        {
            return (await _context
                    .Regions
                    .FirstOrDefaultAsync(x => x.Id == pokedex.RegionId))?
                .ToNamedApiResource();
        }

        private async Task<List<NamedAPIResource>> GetVersionGroups(EFPokedexes pokedex)
        {
            return (await _context
                    .PokedexVersionGroups
                    .Include(x => x.VersionGroup)
                    .Where(x => x.PokedexId == pokedex.Id)
                    .ToListAsync())
                .Select(x =>
                    new NamedAPIResource
                    (
                        $"{Constants.SiteUrl}{Constants.BaseUrl}{typeof(VersionGroupsController).Segment()}/{x.VersionGroupId}/",
                        x.VersionGroup.Identifier
                    ))
                .ToList();
        }

        private async Task<List<Description>> GetDescriptions(EFPokedexes pokedex)
        {
            return (await _context
                    .PokedexProse
                    .Include(x => x.LocalLanguage)
                    .Where(x => x.PokedexId == pokedex.Id)
                    .ToListAsync())
                .Select(x => new Description(x.Description,
                    x.LocalLanguage.ToNamedApiResource()))
                .ToList();
        }

        private async Task<List<PokemonEntry>> GetEntries(EFPokedexes pokedex)
        {
            return (await _context
                    .PokemonDexNumbers
                    .Include(x => x.Species)
                    .Where(x => x.PokedexId == pokedex.Id)
                    .OrderBy(x => x.PokedexNumber)
                    .ToListAsync())
                .Select(x => new PokemonEntry(x.PokedexNumber,
                    x.Species.ToNamedApiResource()))
                .ToList();
        }

        private async Task<List<Name>> GetNames(EFPokedexes pokedex)
        {
            return (await _context
                    .PokedexProse
                    .Include(x => x.LocalLanguage)
                    .Where(x => x.PokedexId == pokedex.Id)
                    .ToListAsync())
                .Select(x => new Name(x.Name, 
                    x.LocalLanguage.ToNamedApiResource()))
                .ToList();
        }
    }
}