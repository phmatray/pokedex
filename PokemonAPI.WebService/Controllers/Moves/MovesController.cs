using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Core;
using PokemonAPI.WebService.Models;
using System.Linq;
using PokemonAPI.WebService.Controllers._Base;

namespace PokemonAPI.WebService.Controllers
{
    [Route("api/v1/moves")]
    public class MovesController : ApiController
    {
        private readonly VeekunContext _context;

        public MovesController(VeekunContext context)
        {
            _context = context;
        }

        // GET api/v1/moves
        // GET api/v1/moves?skip=0&take=20
        [HttpGet]
        public async Task<IActionResult> GetAll(int limit = 20, int offset = 0)
            => await GetAll(limit, offset, _context.Moves, GetType());

        // GET api/v1/moves/1
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var move = await _context.Moves
                    .Include(x => x.ContestType)
                    .Include(x => x.ContestEffect)
                    .Include(x => x.DamageClass)
                    .Include(x => x.Generation)
                    .Include(x => x.SuperContestEffect)
                    .Include(x => x.Target)
                    .Include(x => x.Type)
                    .FirstOrDefaultAsync(x => x.Id == id);

                var result = new Move
                {
                    Id                 = move.Id,
                    Name               = move.Identifier,
                    Accuracy           = move.Accuracy,
                    EffectChance       = move.EffectChance,
                    Pp                 = move.Pp,
                    Priority           = move.Priority,
                    Power              = move.Power,
                    ContestCombos      = await GetContestCombos(move),
                    ContestType        = GetContestType(move),
                    ContestEffect      = GetContestEffect(move),
                    DamageClass        = GetDamageClass(move),
                    EffectEntries      = await GetEffectEntries(move),
                    EffectChanges      = await GetEffectChanges(move),
                    FlavorTextEntries  = await GetFlavorTextEntries(move),
                    Generation         = GetGeneration(move),
                    Machines           = await GetMachines(move),
                    Meta               = await GetMeta(move),
                    Names              = await GetNames(move),
                    PastValues         = await GetPastValues(move),
                    StatChanges        = await GetStatChanges(move),
                    SuperContestEffect = GetSuperContestEffect(move),
                    Target             = GetTarget(move),
                    Type               = GetType(move),
                };

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        private async Task<ContestComboSets> GetContestCombos(EFMoves move)
        {
            var normalUseBefore = (await _context
                    .ContestCombos
                    .Include(x => x.SecondMove)
                    .Where(x => x.FirstMoveId == move.Id)
                    .ToListAsync())
                .Select(x => x.SecondMove.ToNamedApiResource<MovesController>(x.SecondMoveId))
                .ToList();

            var normalUseAfter = (await _context
                    .ContestCombos
                    .Include(x => x.FirstMove)
                    .Where(x => x.SecondMoveId == move.Id)
                    .ToListAsync())
                .Select(x => x.FirstMove.ToNamedApiResource<MovesController>(x.FirstMoveId))
                .ToList();

            var superUseBefore = (await _context
                    .SuperContestCombos
                    .Include(x => x.SecondMove)
                    .Where(x => x.FirstMoveId == move.Id)
                    .ToListAsync())
                .Select(x => x.SecondMove.ToNamedApiResource<MovesController>(x.SecondMoveId))
                .ToList();

            var superUseAfter = (await _context
                    .SuperContestCombos
                    .Include(x => x.FirstMove)
                    .Where(x => x.SecondMoveId == move.Id)
                    .ToListAsync())
                .Select(x => x.FirstMove.ToNamedApiResource<MovesController>(x.FirstMoveId))
                .ToList();

            var fnua = normalUseAfter.Any();
            var fnub = normalUseBefore.Any();
            var fsua = superUseAfter.Any();
            var fsub = superUseBefore.Any();

            return fnua || fnub || fsua || fsub
                ? new ContestComboSets
                {
                    Normal = new ContestComboDetail
                    {
                        UseAfter = fnua ? normalUseAfter : null,
                        UseBefore = fnub ? normalUseBefore : null
                    },
                    Super = new ContestComboDetail
                    {
                        UseAfter = fsua ? superUseAfter : null,
                        UseBefore = fsub ? superUseBefore : null
                    }
                }
                : null;
        }

        private static NamedAPIResource GetContestType(EFMoves move)
        {
            return move.ContestType
                .ToNamedApiResource();
        }

        private static APIResource GetContestEffect(EFMoves move)
        {
            return move.ContestEffect
                .ToApiResource<ContestEffectsController>();
        }

        private static NamedAPIResource GetDamageClass(EFMoves move)
        {
            return move.DamageClass
                .ToNamedApiResource();
        }

        private async Task<List<VerboseEffect>> GetEffectEntries(EFMoves move)
        {
            return (await _context
                    .MoveEffectProse
                    .Include(x => x.LocalLanguage)
                    .Where(x => x.MoveEffectId == move.EffectId &&
                                x.ShortEffect != null && x.Effect != null)
                    .ToListAsync())
                .Select(x => new VerboseEffect(x.Effect, x.ShortEffect, x.LocalLanguage.ToNamedApiResource()))
                .ToList();
        }

        private async Task<List<AbilityEffectChange>> GetEffectChanges(EFMoves move)
        {
            var efMoveEffectChangelogs = await _context
                .MoveEffectChangelog
                .Include(x => x.MoveEffectChangelogProse).ThenInclude(x => x.LocalLanguage)
                .Include(x => x.ChangedInVersionGroup)
                .Where(x => x.EffectId == move.EffectId)
                .ToListAsync();

            return efMoveEffectChangelogs
                .Select(x =>
                {
                    var effectEntries = x.MoveEffectChangelogProse
                        .Select(y => new Effect(y.Effect, y.LocalLanguage.ToNamedApiResource()))
                        .ToList();

                    return new AbilityEffectChange(effectEntries, x.ChangedInVersionGroup.ToNamedApiResource());
                })
                .ToList();
        }

        private async Task<List<MoveFlavorText>> GetFlavorTextEntries(EFMoves move)
        {
            return (await _context
                    .MoveFlavorText
                    .Include(x => x.Language)
                    .Include(x => x.VersionGroup)
                    .Where(x => x.MoveId == move.Id)
                    .ToListAsync())
                .Select(x => new MoveFlavorText
                {
                    FlavorText   = x.FlavorText,
                    Language     = x.Language.ToNamedApiResource(),
                    VersionGroup = x.VersionGroup.ToNamedApiResource()
                })
                .ToList();
        }

        private static NamedAPIResource GetGeneration(EFMoves move)
        {
            return move.Generation
                .ToNamedApiResource();
        }

        private async Task<List<MachineVersionDetail>> GetMachines(EFMoves move)
        {
            var machines = await _context
                .Machines
                .Include(x => x.VersionGroup)
                .Where(x => x.MoveId == move.Id)
                .ToListAsync();

            return machines
                .Select(x => new MachineVersionDetail
                {
                    Machine = x.ToApiResource(),
                    VersionGroup = x.VersionGroup.ToNamedApiResource()
                })
                .ToList();
        }

        private async Task<MoveMetaData> GetMeta(EFMoves move)
        {
            var meta = await _context
                .MoveMeta
                .Include(x => x.MetaAilment)
                .Include(x => x.MetaCategory)
                .SingleAsync(x => x.MoveId == move.Id);

            return new MoveMetaData
            {
                Ailment       = meta.MetaAilment.ToNamedApiResource(),
                Category      = meta.MetaCategory.ToNamedApiResource(),
                MinHits       = meta.MinHits,
                MaxHits       = meta.MaxHits,
                MinTurns      = meta.MinTurns,
                MaxTurns      = meta.MaxTurns,
                Drain         = meta.Drain,
                Healing       = meta.Healing,
                CritRate      = meta.CritRate,
                AilmentChance = meta.AilmentChance,
                FlinchChance  = meta.FlinchChance,
                StatChance    = meta.StatChance
            };
        }

        private async Task<List<Name>> GetNames(EFMoves move)
        {
            return (await _context
                    .MoveNames
                    .Include(x => x.LocalLanguage)
                    .Where(x => x.MoveId == move.Id)
                    .ToListAsync())
                .Select(x => new Name
                (
                    x.Name,
                    x.LocalLanguage.ToNamedApiResource()
                ))
                .ToList();
        }

        private async Task<List<PastMoveStatValues>> GetPastValues(EFMoves move)
        {
            return (await _context
                    .MoveChangelog
                    .Include(x => x.Type)
                    .Include(x => x.ChangedInVersionGroup)
                    .Where(x => x.MoveId == move.Id)
                    .ToListAsync())
                .Select(x => new PastMoveStatValues
                {
                    Accuracy      = x.Accuracy,
                    EffectChance  = x.EffectChance,
                    Power         = x.Power,
                    Pp            = x.Pp,
                    EffectEntries = GetPastValuesEffectEntries(x),
                    Type          = x.Type?.ToNamedApiResource(),
                    VersionGroup  = x.ChangedInVersionGroup?.ToNamedApiResource()
                })
                .ToList();
        }

        private List<VerboseEffect> GetPastValuesEffectEntries(EFMoveChangelog moveChangelog)
        {
            return _context
                .MoveEffectProse
                .Include(x => x.LocalLanguage)
                .Where(x => moveChangelog.EffectId.HasValue &&
                            x.MoveEffectId == moveChangelog.EffectId &&
                            x.ShortEffect != null && x.Effect != null)
                .ToList()
                .Select(x => new VerboseEffect(x.Effect /*TODO: Parse this result*/, x.ShortEffect, x.LocalLanguage.ToNamedApiResource()))
                .ToList();
        }

        private async Task<List<MoveStatChange>> GetStatChanges(EFMoves move)
        {
            return (await _context
                    .MoveMetaStatChanges
                    .Include(x => x.Stat)
                    .Where(x => x.MoveId == move.Id)
                    .ToListAsync())
                .Select(x => new MoveStatChange
                {
                    Change = x.Change,
                    Stat = x.Stat.ToNamedApiResource()
                })
                .ToList();
        }

        private static APIResource GetSuperContestEffect(EFMoves move)
        {
            return move.SuperContestEffect
                .ToApiResource<SuperContestEffectsController>();
        }

        private static NamedAPIResource GetTarget(EFMoves move)
        {
            return move.Target
                .ToNamedApiResource();
        }

        private static NamedAPIResource GetType(EFMoves move)
        {
            return move.Type
                .ToNamedApiResource();
        }
    }
}