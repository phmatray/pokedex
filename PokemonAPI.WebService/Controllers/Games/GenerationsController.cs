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
                    .Include(x => x.MainRegion)
                    .Include(x => x.GenerationNames).ThenInclude(x => x.LocalLanguage)
                    .Include(x => x.VersionGroups)
                    .Include(x => x.PokemonSpecies)
                    .Include(x => x.Moves)
                    .Include(x => x.Types)
                    .Include(x => x.Abilities)
                    .FirstOrDefaultAsync(x => x.Id == id);

                var results = new Generation
                {
                    Id             = generation.Id,
                    Name           = generation.Identifier,
                    Abilities      = GetAbilities(generation),
                    VersionGroups  = GetVersionGroups(generation),
                    Names          = GetNames(generation),
                    PokemonSpecies = GetPokemonSpecies(generation),
                    Moves          = GetMoves(generation),
                    MainRegion     = GetMainRegion(generation),
                    Types          = GetTypes(generation)
                };

                return Ok(results);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        private static List<NamedAPIResource> GetTypes(EFGenerations generation)
        {
            return generation
                .Types
                .Where(x => x.GenerationId == generation.Id && x.Id < 10000)
                .Select(x => x.ToNamedApiResource())
                .ToList();
        }

        private static NamedAPIResource GetMainRegion(EFGenerations generation)
        {
            return generation.MainRegion
                .ToNamedApiResource();
        }

        private static List<NamedAPIResource> GetMoves(EFGenerations generation)
        {
            return generation
                .Moves
                .Select(x => x.ToNamedApiResource())
                .ToList();
        }

        private static List<NamedAPIResource> GetPokemonSpecies(EFGenerations generation)
        {
            return generation
                .PokemonSpecies
                .OrderBy(x => x.Id)
                .Select(x => x.ToNamedApiResource())
                .ToList();
        }

        private static List<Name> GetNames(EFGenerations generation)
        {
            return generation
                .GenerationNames
                .Select(x => new Name(x.Name, x.LocalLanguage.ToNamedApiResource()))
                .ToList();
        }

        private static List<NamedAPIResource> GetVersionGroups(EFGenerations generation)
        {
            return generation
                .VersionGroups
                .Select(x => x.ToNamedApiResource())
                .ToList();
        }

        private static List<NamedAPIResource> GetAbilities(EFGenerations generation)
        {
            return generation
                .Abilities
                .Select(x => x.ToNamedApiResource())
                .ToList();
        }
    }
}