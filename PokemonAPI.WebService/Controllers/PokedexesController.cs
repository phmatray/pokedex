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
    public class PokedexesController : ApiController<Pokedexes>
    {
        public PokedexesController(VeekunContext context)
            : base(context)
        {
        }

        // GET api/v1/pokedexes
        // GET api/v1/pokedexes?skip=0&take=20
        [HttpGet]
        public async Task<IActionResult> GetAll(int limit = 20, int offset = 0)
        {
            return await base.GetAll(limit, offset);
        }

        // GET api/v1/pokedexes/1
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var pokedex = await MainDbSet
                    .FirstOrDefaultAsync(x => x.Id == id);

                var result = new PokedexResource
                {
                    Id             = pokedex.Id,
                    Identifier     = pokedex.Identifier,
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

        private async Task<NamedAPIResource> GetRegion(Pokedexes pokedex)
        {
            return (await Context
                    .Regions
                    .FirstOrDefaultAsync(x => x.Id == pokedex.RegionId))?
                .ToNamedApiResource();
        }

        private async Task<List<NamedAPIResource>> GetVersionGroups(Pokedexes pokedex)
        {
            return (await Context
                    .PokedexVersionGroups
                    .Include(x => x.VersionGroup)
                    .Where(x => x.PokedexId == pokedex.Id)
                    .ToListAsync())
                .Select(x => x.ToNamedApiResource(PokedexVersionGroupsSourceType.Pokedex))
                .ToList();
        }

        private async Task<List<DescriptionResource>> GetDescriptions(Pokedexes pokedex)
        {
            return (await Context
                    .PokedexProse
                    .Include(x => x.LocalLanguage)
                    .Where(x => x.PokedexId == pokedex.Id)
                    .ToListAsync())
                .Select(x => x.ToDescriptionResource())
                .ToList();
        }

        private async Task<List<PokemonEntryResource>> GetEntries(Pokedexes pokedex)
        {
            return (await Context
                    .PokemonDexNumbers
                    .Include(x => x.Species)
                    .Where(x => x.PokedexId == pokedex.Id)
                    .OrderBy(x => x.PokedexNumber)
                    .ToListAsync())
                .Select(x => x.ToPokemonEntryResource())
                .ToList();
        }

        private async Task<List<NameResource>> GetNames(Pokedexes pokedex)
        {
            return (await Context
                    .PokedexProse
                    .Include(x => x.LocalLanguage)
                    .Where(x => x.PokedexId == pokedex.Id)
                    .ToListAsync())
                .Select(x => x.ToNameResource())
                .ToList();
        }
    }
}