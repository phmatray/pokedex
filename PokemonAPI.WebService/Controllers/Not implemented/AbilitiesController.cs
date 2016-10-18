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
    [Route("api/v1/abilities")]
    public class AbilitiesController : ApiController
    {
        private readonly VeekunContext _context;

        public AbilitiesController(VeekunContext context)
        {
            _context = context;
        }

        // GET api/v1/abilities
        // GET api/v1/abilities?skip=0&take=20
        [HttpGet]
        public async Task<IActionResult> GetAll(int limit = 20, int offset = 0)
        {
            return await base.GetAll(limit, offset, 
                _context.Abilities, this.Segment());
        }

        // GET api/v1/abilities/1
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var ability = await _context.Abilities
                    .FirstOrDefaultAsync(x => x.Id == id);

                var result = new Ability
                {
                    Id                = ability.Id,
                    Name              = ability.Identifier,
                    IsMainSeries      = ability.IsMainSeries,
                    Generation        = await GetGeneration(ability),
                    Names             = await GetNames(ability),
                    EffectEntries     = await GetEffectEntries(ability),
                    EffectChanges     = await GetEffectChanges(ability),
                    FlavorTextEntries = await GetFlavorTextEntries(ability),
                    Pokemon           = await GetPokemon(ability)
                };

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        private async Task<NamedAPIResource> GetGeneration(EFAbilities ability)
        {
            return (await _context
                    .Generations
                    .FirstOrDefaultAsync(x => x.Id == ability.GenerationId))
                .ToNamedApiResource(typeof(GenerationsController).Segment());
        }

        private async Task<List<Name>> GetNames(EFAbilities ability)
        {
            throw new NotImplementedException();
        }

        private async Task<List<VerboseEffect>> GetEffectEntries(EFAbilities ability)
        {
            throw new NotImplementedException();
        }

        private async Task<List<AbilityEffectChange>> GetEffectChanges(EFAbilities ability)
        {
            throw new NotImplementedException();
        }

        private async Task<List<AbilityFlavorText>> GetFlavorTextEntries(EFAbilities ability)
        {
            throw new NotImplementedException();
        }

        private async Task<List<AbilityPokemon>> GetPokemon(EFAbilities ability)
        {
            //_context.PokemonAbilities.Where()
            throw new NotImplementedException();
        }
    }
}