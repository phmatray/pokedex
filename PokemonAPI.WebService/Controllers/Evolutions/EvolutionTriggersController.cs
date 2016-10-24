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
    [Route("api/v1/evolution-triggers")]
    public class EvolutionTriggersController : ApiController
    {
        private readonly VeekunContext _context;

        public EvolutionTriggersController(VeekunContext context)
        {
            _context = context;
        }

        // GET api/v1/evolution-triggers
        // GET api/v1/evolution-triggers?skip=0&take=20
        [HttpGet]
        public async Task<IActionResult> GetAll(int limit = 20, int offset = 0)
            => await GetAll(limit, offset, _context.EvolutionTriggers, GetType());

        // GET api/v1/evolution-triggers/1
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var evolutionTrigger = await _context.EvolutionTriggers
                    .Include(x => x.EvolutionTriggerProse).ThenInclude(x => x.LocalLanguage)
                    .Include(x => x.PokemonEvolution).ThenInclude(x => x.EvolvedSpecies)
                    .FirstOrDefaultAsync(x => x.Id == id);

                var result = new EvolutionTrigger
                {
                    Id             = evolutionTrigger.Id,
                    Name           = evolutionTrigger.Identifier,
                    Names          = GetNames(evolutionTrigger),
                    PokemonSpecies = GetPokemonSpecies(evolutionTrigger)
                };

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        private static List<Name> GetNames(EFEvolutionTriggers evolutionTrigger)
        {
            return evolutionTrigger
                .EvolutionTriggerProse
                .Select(x => new Name
                (
                    x.Name,
                    x.LocalLanguage.ToNamedApiResource()
                ))
                .ToList();
        }

        private static List<NamedAPIResource> GetPokemonSpecies(EFEvolutionTriggers evolutionTrigger)
        {
            return evolutionTrigger
                .PokemonEvolution
                .Select(x => x.EvolvedSpecies.ToNamedApiResource())
                .ToList();
        }
    }
}