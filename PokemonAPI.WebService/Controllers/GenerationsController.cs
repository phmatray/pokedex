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
    [Route("api/v1/[controller]")]
    public class GenerationsController : ApiController<EFGenerations>
    {
        public GenerationsController(VeekunContext context)
            : base(context, "Generations", "generations")
        {
        }

        // GET api/v1/generations
        // GET api/v1/generations?skip=0&take=20
        [HttpGet]
        public async Task<IActionResult> GetAll(int limit = 20, int offset = 0)
        {
            return await base.GetAll(limit, offset);
        }

        // GET api/v1/generations/1
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var generation = await MainDbSet
                    .FirstOrDefaultAsync(x => x.Id == id);

                var results = new Generation
                {
                    Id             = generation.Id,
                    Name           = generation.Identifier,
                    Abilities      = await GetAbilities(generation),
                    VersionGroups  = await GetVersionGroups(generation),
                    Names          = await GetNames(generation),
                    PokemonSpecies = await GetPokemonSpecies(generation),
                    Moves          = await GetMoves(generation),
                    MainRegion     = await GetMainRegion(generation),
                    Types          = await GetTypes(generation)
                };

                return Ok(results);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        private async Task<List<NamedAPIResource>> GetTypes(EFGenerations generation)
        {
            return (await Context
                    .Types
                    .Where(x => x.GenerationId == generation.Id && x.Id < 10000)
                    .ToListAsync())
                .Select(x => x.ToNamedApiResource())
                .ToList();
        }

        private async Task<NamedAPIResource> GetMainRegion(EFGenerations generation)
        {
            return (await Context
                    .Regions
                    .FirstOrDefaultAsync(x => x.Id == generation.MainRegionId))?
                .ToNamedApiResource();
        }

        private async Task<List<NamedAPIResource>> GetMoves(EFGenerations generation)
        {
            return (await Context
                    .Moves
                    .Where(x => x.GenerationId == generation.Id)
                    .ToListAsync())
                .Select(x => x.ToNamedApiResource())
                .ToList();
        }

        private async Task<List<NamedAPIResource>> GetPokemonSpecies(EFGenerations generation)
        {
            return (await Context
                    .PokemonSpecies
                    .Where(x => x.GenerationId == generation.Id)
                    .OrderBy(x => x.Id)
                    .ToListAsync())
                .Select(x => x.ToNamedApiResource())
                .ToList();
        }

        private async Task<List<Name>> GetNames(EFGenerations generation)
        {
            return (await Context
                    .GenerationNames
                    .Include(x => x.LocalLanguage)
                    .Where(x => x.GenerationId == generation.Id)
                    .ToListAsync())
                .Select(x => new Name(x.Name, x.Generation.ToNamedApiResource()))
                .ToList();
        }

        private async Task<List<NamedAPIResource>> GetVersionGroups(EFGenerations generation)
        {
            return (await Context
                    .VersionGroups
                    .Where(x => x.GenerationId == generation.Id)
                    .ToListAsync())
                .Select(x => x.ToNamedApiResource())
                .ToList();
        }

        private async Task<List<NamedAPIResource>> GetAbilities(EFGenerations generation)
        {
            return (await Context
                    .Abilities
                    .Where(x => x.GenerationId == generation.Id)
                    .ToListAsync())
                .Select(x => x.ToNamedApiResource())
                .ToList();
        }
    }
}