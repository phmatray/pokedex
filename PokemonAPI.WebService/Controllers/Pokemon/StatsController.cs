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
            => await GetAll(limit, offset, _context.Stats, GetType());

        // GET api/v1/stats/1
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var stat = await _context.Stats
                    .Include(x => x.MoveMetaStatChanges).ThenInclude(x => x.Move)
                    .Include(x => x.NaturesIncreasedStat)
                    .Include(x => x.NaturesDecreasedStat)
                    .Include(x => x.Characteristics)
                    .Include(x => x.DamageClass)
                    .Include(x => x.StatNames).ThenInclude(x => x.LocalLanguage)
                    .FirstOrDefaultAsync(x => x.Id == id);

                var result = new Stat
                {
                    Id               = stat.Id,
                    Name             = stat.Identifier,
                    GameIndex        = stat.GameIndex,
                    IsBattleOnly     = stat.IsBattleOnly,
                    AffectingMoves   = GetAffectingMoves(stat),
                    AffectingNatures = GetAffectingNatures(stat),
                    Characteristics  = GetCharacteristics(stat),
                    MoveDamageClass  = GetMoveDamageClass(stat),
                    Names            = GetNames(stat)
                };

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        private static MoveStatAffectSets GetAffectingMoves(EFStats stat)
        {
            var moveMetaStatChanges = stat
                .MoveMetaStatChanges
                .Select(x => new MoveStatAffect(x.Change, x.Move.ToNamedApiResource()))
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

        private static NatureStatAffectSets GetAffectingNatures(EFStats stat)
        {
            return new NatureStatAffectSets
            {
                Increase = stat
                    .NaturesIncreasedStat
                    .Where(x => x.DecreasedStatId != stat.Id)
                    .Select(x => x.ToNamedApiResource())
                    .ToList(),
                Decrease = stat
                    .NaturesDecreasedStat
                    .Where(x => x.IncreasedStatId != stat.Id)
                    .Select(x => x.ToNamedApiResource())
                    .ToList()
            };
        }

        private static List<APIResource> GetCharacteristics(EFStats stat)
        {
            return stat
                .Characteristics
                .Select(x => x.ToApiResource())
                .ToList();
        }

        private static NamedAPIResource GetMoveDamageClass(EFStats stat)
        {
            return stat
                .DamageClass?
                .ToNamedApiResource();
        }

        private static List<Name> GetNames(EFStats stat)
        {
            return stat
                .StatNames
                .Select(x => new Name(x.Name, x.LocalLanguage.ToNamedApiResource()))
                .ToList();
        }
    }
}