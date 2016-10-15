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
    [Route("api/v1/generations")]
    public class GenerationsController : ApiController
    {
        private readonly VeekunContext _context;

        public GenerationsController(VeekunContext context)
        {
            _context = context;
        }

        // GET api/v1/generations
        // GET api/v1/generations?skip=0&take=20
        [HttpGet]
        public async Task<IActionResult> GetAll(int limit = 20, int offset = 0)
        {
            return await base.GetAll(limit, offset, _context.Generations, this.Segment());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="400">If the is is equals or lower than 0.</response>
        // GET api/v1/generations/1
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(int), 400)]
        public async Task<IActionResult> Get(int id)
        {
            if (id <= 0) return BadRequest();

            try
            {
                var generation = await _context.Generations
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
            return (await _context
                    .Types
                    .Where(x => x.GenerationId == generation.Id && x.Id < 10000)
                    .ToListAsync())
                .Select(x => x.ToNamedApiResource(typeof(TypesController).Segment()))
                .ToList();
        }

        private async Task<NamedAPIResource> GetMainRegion(EFGenerations generation)
        {
            return (await _context
                    .Regions
                    .FirstOrDefaultAsync(x => x.Id == generation.MainRegionId))?
                .ToNamedApiResource(typeof(RegionsController).Segment());
        }

        private async Task<List<NamedAPIResource>> GetMoves(EFGenerations generation)
        {
            return (await _context
                    .Moves
                    .Where(x => x.GenerationId == generation.Id)
                    .ToListAsync())
                .Select(x => x.ToNamedApiResource())
                //.Select(x => x.ToNamedApiResource(typeof(MoveController).Segment()))
                .ToList();
        }

        private async Task<List<NamedAPIResource>> GetPokemonSpecies(EFGenerations generation)
        {
            return (await _context
                    .PokemonSpecies
                    .Where(x => x.GenerationId == generation.Id)
                    .OrderBy(x => x.Id)
                    .ToListAsync())
                .Select(x => x.ToNamedApiResource(typeof(PokemonSpeciesController).Segment()))
                .ToList();
        }

        private async Task<List<Name>> GetNames(EFGenerations generation)
        {
            return (await _context
                    .GenerationNames
                    .Include(x => x.LocalLanguage)
                    .Where(x => x.GenerationId == generation.Id)
                    .ToListAsync())
                .Select(x => new Name(x.Name,
                    x.LocalLanguage.ToNamedApiResource(typeof(LanguagesController).Segment())))
                .ToList();
        }

        private async Task<List<NamedAPIResource>> GetVersionGroups(EFGenerations generation)
        {
            return (await _context
                    .VersionGroups
                    .Where(x => x.GenerationId == generation.Id)
                    .ToListAsync())
                .Select(x => x.ToNamedApiResource(typeof(VersionGroupsController).Segment()))
                .ToList();
        }

        private async Task<List<NamedAPIResource>> GetAbilities(EFGenerations generation)
        {
            return (await _context
                    .Abilities
                    .Where(x => x.GenerationId == generation.Id)
                    .ToListAsync())
                .Select(x => x.ToNamedApiResource(typeof(AbilitiesController).Segment()))
                .ToList();
        }
    }
}