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
    [Route("api/v1/item-fling-effects")]
    public class ItemFlingEffectsController : ApiController
    {
        private readonly VeekunContext _context;

        public ItemFlingEffectsController(VeekunContext context)
        {
            _context = context;
        }

        // GET api/v1/item-fling-effects
        // GET api/v1/item-fling-effects?skip=0&take=20
        [HttpGet]
        public async Task<IActionResult> GetAll(int limit = 20, int offset = 0)
        {
            try
            {
                if (limit <= 0) throw new ArgumentOutOfRangeException(nameof(limit));
                if (offset < 0) throw new ArgumentOutOfRangeException(nameof(offset));

                var dbset      = _context.ItemFlingEffects;
                var urlSegment = typeof(ItemFlingEffectsController).Segment();

                var count      = await dbset.CountAsync();
                var previous   = UrlHelpers.Previous(limit, offset, urlSegment);
                var next       = UrlHelpers.Next(limit, offset, count, urlSegment);

                var apiResults = (await dbset
                        .OrderBy(x => x.Id)
                        .Skip(offset)
                        .Take(limit)
                        .ToListAsync())
                    .Select(x => new NamedAPIResource(x.Identifier, typeof(ItemFlingEffectsController).RscUrl(x.Id)))
                    .Cast<APIResource>()
                    .ToList();

                var results = new APIResourceList(count, previous, next, apiResults);

                return Ok(results);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // GET api/v1/item-fling-effects/1
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var itemFlingEffect = await _context.ItemFlingEffects
                    .Include(x => x.ItemFlingEffectProse).ThenInclude(x => x.LocalLanguage)
                    .Include(x => x.Items)
                    .FirstOrDefaultAsync(x => x.Id == id);

                var result = new ItemFlingEffect
                {
                    Id            = itemFlingEffect.Id,
                    Name          = itemFlingEffect.Identifier,
                    EffectEntries = GetEffectEntries(itemFlingEffect),
                    Items         = GetItems(itemFlingEffect),
                };

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        private List<Effect> GetEffectEntries(EFItemFlingEffects itemFlingEffect)
        {
            return itemFlingEffect
                .ItemFlingEffectProse
                .Select(x => new Effect
                {
                    EffectValue = x.Effect,
                    Language = x.LocalLanguage.ToNamedApiResource()
                })
                .ToList();
        }

        private List<NamedAPIResource> GetItems(EFItemFlingEffects itemFlingEffect)
        {
            return itemFlingEffect
                .Items
                .Select(x => x.ToNamedApiResource())
                .ToList();
        }
    }
}