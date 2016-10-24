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
    [Route("api/v1/super-contest-effects")]
    public class SuperContestEffectsController : ApiController
    {
        private readonly VeekunContext _context;

        public SuperContestEffectsController(VeekunContext context)
        {
            _context = context;
        }

        // GET api/v1/super-contest-effects
        // GET api/v1/super-contest-effects?skip=0&take=20
        [HttpGet]
        public async Task<IActionResult> GetAll(int limit = 20, int offset = 0)
        {
            try
            {
                if (limit <= 0) throw new ArgumentOutOfRangeException(nameof(limit));
                if (offset < 0) throw new ArgumentOutOfRangeException(nameof(offset));

                var dbset      = _context.SuperContestEffects;
                var urlSegment = typeof(SuperContestEffectsController).Segment();

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

        // GET api/v1/super-contest-effects/1
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var superContestEffect = await _context.SuperContestEffects
                    .Include(x => x.SuperContestEffectProse).ThenInclude(x => x.LocalLanguage)
                    .Include(x => x.Moves)
                    .FirstOrDefaultAsync(x => x.Id == id);

                var result = new SuperContestEffect
                {
                    Id                = superContestEffect.Id,
                    Appeal            = superContestEffect.Appeal,
                    FlavorTextEntries = GetFlavorTextEntries(superContestEffect),
                    Moves             = GetMoves(superContestEffect)
                };

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        private List<FlavorText> GetFlavorTextEntries(EFSuperContestEffects superContestEffect)
        {
            return superContestEffect
                .SuperContestEffectProse
                .Select(x => new FlavorText
                (
                    x.FlavorText,
                    x.LocalLanguage.ToNamedApiResource()
                ))
                .ToList();
        }

        private List<NamedAPIResource> GetMoves(EFSuperContestEffects superContestEffect)
        {
            return superContestEffect
                .Moves
                .Select(x => x.ToNamedApiResource())
                .ToList();
        }
    }
}