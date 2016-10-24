using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Core;
using Microsoft.EntityFrameworkCore;
using PokemonAPI.WebService.Controllers._Base;
using PokemonAPI.WebService.Models;

namespace PokemonAPI.WebService.Controllers
{
    [Route("api/v1/stats")]
    public class StatsController : ApiController
    {
        private readonly VeekunContext _context;

        public StatsController(VeekunContext context)
        {
            _context = context;
        }

        // GET api/v1/stats
        // GET api/v1/stats?skip=0&take=20
        [HttpGet]
        public async Task<IActionResult> GetAll(int limit = 20, int offset = 0)
        {
            return await base.GetAll(limit, offset,
                _context.Stats, this.Segment());
        }

        // GET api/v1/stats/1
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var stat = await _context.Stats
                    .FirstOrDefaultAsync(x => x.Id == id);

                var result = new Stat
                {
                    Id               = stat.Id,
                    Name             = stat.Identifier,
                    GameIndex        = stat.GameIndex,
                    IsBattleOnly     = stat.IsBattleOnly,
                    AffectingMoves   = await GetAffectingMoves(stat),
                    AffectingNatures = await GetAffectingNatures(stat),
                    Characteristics  = await GetCharacteristics(stat),
                    MoveDamageClass  = await GetMoveDamageClass(stat),
                    Names            = await GetNames(stat)
                };

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        private async Task<MoveStatAffectSets> GetAffectingMoves(EFStats stat)
        {
            var moveMetaStatChanges = (await _context.MoveMetaStatChanges
                    .Include(x => x.Move)
                    .Where(x => x.StatId == stat.Id)
                    .ToListAsync())
                .Select(x => new MoveStatAffect
                {
                    Change = x.Change,
                    Move = x.Move.ToNamedApiResource()
                })
                .ToList();

            return new MoveStatAffectSets
            {
                Increase = moveMetaStatChanges
                    .Where(x => x.Change > 0)
                    .ToList(),
                Decrease = moveMetaStatChanges
                    .Where(x => x.Change < 0)
                    .ToList()
            };
        }

        private async Task<NatureStatAffectSets> GetAffectingNatures(EFStats stat)
        {
            return new NatureStatAffectSets
            {
                Increase = (await _context.Natures
                        .Where(x => x.IncreasedStatId == stat.Id && x.DecreasedStatId != stat.Id)
                        .ToListAsync())
                    .Select(x => x.ToNamedApiResource())
                    .ToList(),
                Decrease = (await _context.Natures
                        .Where(x => x.DecreasedStatId == stat.Id && x.IncreasedStatId != stat.Id)
                        .ToListAsync())
                    .Select(x => x.ToNamedApiResource())
                    .ToList()
            };
        }

        private async Task<List<APIResource>> GetCharacteristics(EFStats stat)
        {
            return (await _context
                    .Characteristics
                    .Where(x => x.StatId == stat.Id)
                    .ToListAsync())
                .Select(x => x.ToApiResource(typeof(CharacteristicsController).Segment()))
                .ToList();
        }

        private async Task<NamedAPIResource> GetMoveDamageClass(EFStats stat)
        {
            return (await _context
                    .MoveDamageClasses
                    .Where(x => x.Id == stat.DamageClassId)
                    .FirstOrDefaultAsync())?
                .ToNamedApiResource();
        }

        private async Task<List<Name>> GetNames(EFStats stat)
        {
            return (await _context
                    .StatNames
                    .Include(x => x.LocalLanguage)
                    .Where(x => x.StatId == stat.Id)
                    .ToListAsync())
                .Select(x => new Name(x.Name, 
                    x.LocalLanguage.ToNamedApiResource()))
                .ToList();
        }
    }
}