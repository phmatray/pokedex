using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Controllers.Base;
using PokemonAPI.WebService.Core;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using PokemonAPI.WebService.Models;

namespace PokemonAPI.WebService.Controllers
{
    [Route("api/v1/contest-effects")]
    public class ContestEffectsController : ApiController
    {
        private readonly VeekunContext _context;

        public ContestEffectsController(VeekunContext context)
        {
            _context = context;
        }

        // GET api/v1/contest-effects
        // GET api/v1/contest-effects?skip=0&take=20
        [HttpGet]
        public async Task<IActionResult> GetAll(int limit = 20, int offset = 0)
        {
            try
            {
                if (limit <= 0) throw new ArgumentOutOfRangeException(nameof(limit));
                if (offset < 0) throw new ArgumentOutOfRangeException(nameof(offset));

                var dbset      = _context.ContestEffects;
                var urlSegment = typeof(ContestEffectsController).Segment();

                var count      = await dbset.CountAsync();
                var previous   = UrlHelpers.Previous(limit, offset, urlSegment);
                var next       = UrlHelpers.Next(limit, offset, count, urlSegment);

                var apiResults = (await dbset
                        .OrderBy(x => x.Id)
                        .Skip(offset)
                        .Take(limit)
                        .ToListAsync())
                    .Select(x => x.ToApiResource(urlSegment))
                    .ToList();

                var results = new APIResourceList(count, previous, next, apiResults);

                return Ok(results);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // GET api/v1/contest-effects/1
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var contestEffect = await _context.ContestEffects
                    .Include(x => x.ContestEffectProse).ThenInclude(x => x.LocalLanguage)
                    .FirstOrDefaultAsync(x => x.Id == id);

                var result = new ContestEffect
                {
                    Id                = contestEffect.Id,
                    Appeal            = contestEffect.Appeal,
                    Jam               = contestEffect.Jam,
                    EffectEntries     = GetEffectEntries(contestEffect),
                    FlavorTextEntries = GetFlavorTextEntries(contestEffect)
                };

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        private List<Effect> GetEffectEntries(EFContestEffects contestEffect)
        {
            return contestEffect
                .ContestEffectProse
                .Select(x => new Effect
                {
                    EffectValue = x.Effect,
                    Language = x.LocalLanguage.ToNamedApiResource()
                })
                .ToList();
        }

        private List<FlavorText> GetFlavorTextEntries(EFContestEffects contestEffect)
        {
            return contestEffect
                .ContestEffectProse
                .Select(x => new FlavorText
                (
                    x.FlavorText,
                    x.LocalLanguage.ToNamedApiResource()
                ))
                .ToList();
        }
    }
}