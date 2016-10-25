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
    [Route("api/v1/natures")]
    public class NaturesController : ApiController
    {
        private readonly VeekunContext _context;

        public NaturesController(VeekunContext context)
        {
            _context = context;
        }

        // GET api/v1/natures
        // GET api/v1/natures?skip=0&take=20
        [HttpGet]
        public async Task<IActionResult> GetAll(int limit = 25, int offset = 0)
            => await GetAll(limit, offset, _context.Natures, GetType());

        // GET api/v1/natures/1
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var nature = await _context.Natures
                    .Include(x => x.DecreasedStat)
                    .Include(x => x.IncreasedStat)
                    .Include(x => x.HatesFlavor).ThenInclude(x => x.ContestTypeNames)
                    .Include(x => x.LikesFlavor).ThenInclude(x => x.ContestTypeNames)
                    .Include(x => x.NaturePokeathlonStats).ThenInclude(x => x.PokeathlonStat)
                    .Include(x => x.NatureBattleStylePreferences).ThenInclude(x => x.MoveBattleStyle)
                    .Include(x => x.NatureNames).ThenInclude(x => x.LocalLanguage)
                    .FirstOrDefaultAsync(x => x.Id == id);

                var result = new Nature
                {
                    Id                         = nature.Id,
                    Name                       = nature.Identifier,
                    DecreasedStat              = GetDecreasedStat(nature),
                    IncreasedStat              = GetIncreasedStat(nature),
                    HatesFlavor                = GetHatesFlavor(nature),
                    LikesFlavor                = GetLikesFlavor(nature),
                    PokeathlonStatChanges      = GetPokeathlonStatChanges(nature),
                    MoveBattleStylePreferences = GetMoveBattleStylePreferences(nature),
                    Names                      = GetNames(nature)
                };

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        private static NamedAPIResource GetDecreasedStat(EFNatures nature)
        {
            return nature
                .DecreasedStat
                .ToNamedApiResource();
        }

        private static NamedAPIResource GetIncreasedStat(EFNatures nature)
        {
            return nature
                .IncreasedStat
                .ToNamedApiResource();
        }

        private static NamedAPIResource GetHatesFlavor(EFNatures nature)
        {
            var flavor = nature
                .HatesFlavor
                .ContestTypeNames
                .FirstOrDefault(x => x.LocalLanguageId == 9);

            if (flavor == null)
                return null;

            return new NamedAPIResource
            (
                flavor.Flavor.ToLower(),
                typeof(BerryFlavorsController).RscUrl(flavor.ContestTypeId)
            );
        }

        private static NamedAPIResource GetLikesFlavor(EFNatures nature)
        {
            var flavor = nature
                .LikesFlavor
                .ContestTypeNames
                .FirstOrDefault(x => x.LocalLanguageId == 9);

            if (flavor == null)
                return null;

            return new NamedAPIResource
            (
                flavor.Flavor.ToLower(),
                typeof(BerryFlavorsController).RscUrl(flavor.ContestTypeId)
            );
        }

        private static List<NatureStatChange> GetPokeathlonStatChanges(EFNatures nature)
        {
            return nature
                .NaturePokeathlonStats
                .Select(x => new NatureStatChange
                {
                    MaxChange = x.MaxChange,
                    PokeathlonStat = x.PokeathlonStat.ToNamedApiResource()
                })
                .ToList();
        }

        private static List<MoveBattleStylePreference> GetMoveBattleStylePreferences(EFNatures nature)
        {
            return nature
                .NatureBattleStylePreferences
                .Select(x => new MoveBattleStylePreference
                {
                    HighHpPreference = x.HighHpPreference,
                    LowHpPreference = x.LowHpPreference,
                    MoveBattleStyle = x.MoveBattleStyle.ToNamedApiResource()
                })
                .ToList();
        }

        private static List<Name> GetNames(EFNatures nature)
        {
            return nature
                .NatureNames
                .Select(x => new Name(x.Name, x.LocalLanguage.ToNamedApiResource()))
                .ToList();
        }
    }
}