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
                    .FirstOrDefaultAsync(x => x.Id == id);

                var result = new Nature
                {
                    Id                         = nature.Id,
                    Name                       = nature.Identifier,
                    DecreasedStat              = await GetDecreasedStat(nature),
                    IncreasedStat              = await GetIncreasedStat(nature),
                    HatesFlavor                = await GetHatesFlavor(nature),
                    LikesFlavor                = await GetLikesFlavor(nature),
                    PokeathlonStatChanges      = await GetPokeathlonStatChanges(nature),
                    MoveBattleStylePreferences = await GetMoveBattleStylePreferences(nature),
                    Names                      = await GetNames(nature)
                };

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        private async Task<NamedAPIResource> GetDecreasedStat(EFNatures nature)
        {
            return (await _context
                    .Stats
                    .Where(x => x.Id == nature.DecreasedStatId)
                    .FirstOrDefaultAsync())?
                .ToNamedApiResource();
        }

        private async Task<NamedAPIResource> GetIncreasedStat(EFNatures nature)
        {
            return (await _context
                    .Stats
                    .Where(x => x.Id == nature.IncreasedStatId)
                    .FirstOrDefaultAsync())?
                .ToNamedApiResource();
        }

        private async Task<NamedAPIResource> GetHatesFlavor(EFNatures nature)
        {
            var flavor = await _context
                .ContestTypeNames
                .Where(x => x.ContestTypeId == nature.HatesFlavorId
                            && x.LocalLanguageId == 9)
                .FirstOrDefaultAsync();

            return new NamedAPIResource(
                flavor.Flavor.ToLower(),
                typeof(BerryFlavorsController).RscUrl(flavor.ContestTypeId)
            );
        }

        private async Task<NamedAPIResource> GetLikesFlavor(EFNatures nature)
        {
            var flavor = await _context
                .ContestTypeNames
                .Where(x => x.ContestTypeId == nature.LikesFlavorId &&
                            x.LocalLanguageId == 9)
                .FirstOrDefaultAsync();

            return new NamedAPIResource(
                flavor.Flavor.ToLower(),
                typeof(BerryFlavorsController).RscUrl(flavor.ContestTypeId)
            );
        }

        private async Task<List<NatureStatChange>> GetPokeathlonStatChanges(EFNatures nature)
        {
            return (await _context
                    .NaturePokeathlonStats
                    .Include(x => x.PokeathlonStat)
                    .Where(x => x.NatureId == nature.Id)
                    .ToListAsync())
                .Select(x => new NatureStatChange
                {
                    MaxChange = x.MaxChange,
                    PokeathlonStat = x.PokeathlonStat.ToNamedApiResource()
                })
                .ToList();
        }

        private async Task<List<MoveBattleStylePreference>> GetMoveBattleStylePreferences(EFNatures nature)
        {
            return (await _context
                    .NatureBattleStylePreferences
                    .Include(x => x.MoveBattleStyle)
                    .Where(x => x.NatureId == nature.Id)
                    .ToListAsync())
                .Select(x => new MoveBattleStylePreference
                {
                    HighHpPreference = x.HighHpPreference,
                    LowHpPreference = x.LowHpPreference,
                    MoveBattleStyle = x.MoveBattleStyle.ToNamedApiResource()
                })
                .ToList();
        }

        private async Task<List<Name>> GetNames(EFNatures nature)
        {
            return (await _context
                    .NatureNames
                    .Include(x => x.LocalLanguage)
                    .Where(x => x.NatureId == nature.Id)
                    .ToListAsync())
                .Select(x => new Name(x.Name, x.LocalLanguage.ToNamedApiResource()))
                .ToList();
        }
    }
}