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
            => await GetAll(limit, offset, _context.Abilities, GetType());

        // GET api/v1/abilities/1
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var ability = await _context.Abilities
                    .Include(x => x.Generation)
                    .Include(x => x.AbilityNames).ThenInclude(x => x.LocalLanguage)
                    .Include(x => x.AbilityProse).ThenInclude(x => x.LocalLanguage)
                    .Include(x => x.AbilityChangelog).ThenInclude(x => x.AbilityChangelogProse)
                    .Include(x => x.AbilityChangelog).ThenInclude(x => x.ChangedInVersionGroup)
                    .Include(x => x.AbilityFlavorText).ThenInclude(x => x.Language)
                    .Include(x => x.AbilityFlavorText).ThenInclude(x => x.VersionGroup)
                    .Include(x=> x.PokemonAbilities).ThenInclude(x => x.Pokemon)
                    .FirstOrDefaultAsync(x => x.Id == id);

                var result = new Ability
                {
                    Id                = ability.Id,
                    Name              = ability.Identifier,
                    IsMainSeries      = ability.IsMainSeries,
                    Generation        = GetGeneration(ability),
                    Names             = GetNames(ability),
                    EffectEntries     = GetEffectEntries(ability),
                    EffectChanges     = GetEffectChanges(ability),
                    FlavorTextEntries = GetFlavorTextEntries(ability),
                    Pokemon           = GetPokemon(ability)
                };

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        private static NamedAPIResource GetGeneration(EFAbilities ability)
        {
            return ability
                .Generation?
                .ToNamedApiResource();
        }

        private static List<Name> GetNames(EFAbilities ability)
        {
            return ability
                .AbilityNames
                .Select(x => new Name(x.Name, x.LocalLanguage.ToNamedApiResource()))
                .ToList();
        }

        private static List<VerboseEffect> GetEffectEntries(EFAbilities ability)
        {
            return ability
                .AbilityProse
                .Select(x => new VerboseEffect(x.Effect, x.ShortEffect, x.LocalLanguage.ToNamedApiResource()))
                .ToList();
        }

        private static List<AbilityEffectChange> GetEffectChanges(EFAbilities ability)
        {
            return ability
                .AbilityChangelog
                .Select(x =>
                {
                    var effectEntries = x.AbilityChangelogProse
                        .Select(y => new Effect(y.Effect, y.LocalLanguage.ToNamedApiResource()))
                        .ToList();

                    return new AbilityEffectChange(effectEntries, x.ChangedInVersionGroup.ToNamedApiResource());
                })
                .ToList();
        }

        private static List<AbilityFlavorText> GetFlavorTextEntries(EFAbilities ability)
        {
            return ability
                .AbilityFlavorText
                .Select(x => new AbilityFlavorText(x.FlavorText,
                    x.Language.ToNamedApiResource(), x.VersionGroup.ToNamedApiResource()))
                .ToList();
        }

        private static List<AbilityPokemon> GetPokemon(EFAbilities ability)
        {
            return ability
                .PokemonAbilities
                .Select(x => new AbilityPokemon(x.IsHidden, x.Slot, x.Pokemon.ToNamedApiResource()))
                .ToList();
        }
    }
}