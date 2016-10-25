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
    [Route("api/v1/location-areas")]
    public class LocationAreasController : ApiController
    {
        private readonly VeekunContext _context;

        public LocationAreasController(VeekunContext context)
        {
            _context = context;
        }

        // GET api/v1/location-areas
        // GET api/v1/location-areas?skip=0&take=20
        [HttpGet]
        public async Task<IActionResult> GetAll(int limit = 20, int offset = 0)
            => await GetAll(limit, offset, _context.LocationAreas, GetType());

        // GET api/v1/location-areas/1
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var locationArea = await _context.LocationAreas
                    .Include(x => x.Location)
                    .Include(x => x.LocationAreaEncounterRates).ThenInclude(x => x.EncounterMethod)
                    .Include(x => x.LocationAreaEncounterRates).ThenInclude(x => x.Version)
                    .Include(x => x.LocationAreaProse).ThenInclude(x => x.LocalLanguage)
                    .Include(x => x.Encounters).ThenInclude(x => x.Pokemon)
                    .Include(x => x.Encounters).ThenInclude(x => x.Version)
                    .Include(x => x.Encounters).ThenInclude(x => x.Version)
                    .Include(x => x.Encounters).ThenInclude(x => x.EncounterSlot).ThenInclude(x => x.EncounterMethod)
                    .FirstOrDefaultAsync(x => x.Id == id);

                var result = new LocationArea
                {
                    Id                   = locationArea.Id,
                    Name                 = GetName(locationArea),
                    GameIndex            = locationArea.GameIndex,
                    EncounterMethodRates = GetEncounterMethodRates(locationArea),
                    Location             = GetLocation(locationArea),
                    Names                = GetNames(locationArea),
                    PokemonEncounters    = GetPokemonEncounters(locationArea)
                };

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        private static string GetName(EFLocationAreas locationArea)
        {
            return $"{locationArea.Location.Identifier}-{locationArea.Identifier ?? "area"}";
        }

        private static List<EncounterMethodRate> GetEncounterMethodRates(EFLocationAreas locationArea)
        {
            return locationArea
                .LocationAreaEncounterRates
                .GroupBy(x => x.EncounterMethodId,
                    (key, group) =>
                    {
                        var efLocationAreaEncounterRateses = group as IList<EFLocationAreaEncounterRates> ?? group.ToList();

                        var encounterMethod = efLocationAreaEncounterRateses
                            .FirstOrDefault()?
                            .EncounterMethod
                            .ToNamedApiResource();

                        var encounterVersionDetails = efLocationAreaEncounterRateses
                            .Select(g => new EncounterVersionDetails(g.Rate, g.Version.ToNamedApiResource()))
                            .ToList();

                        return new EncounterMethodRate(encounterMethod, encounterVersionDetails);
                    })
                .ToList();
        }

        private static NamedAPIResource GetLocation(EFLocationAreas locationArea)
        {
            return locationArea
                .Location
                .ToNamedApiResource();
        }

        private static List<Name> GetNames(EFLocationAreas locationArea)
        {
            return locationArea
                .LocationAreaProse
                .Select(x => new Name(x.Name, x.LocalLanguage.ToNamedApiResource()))
                .ToList();
        }

        private static List<PokemonEncounter> GetPokemonEncounters(EFLocationAreas locationArea)
        {
            return locationArea
                .Encounters
                .GroupBy(x => x.PokemonId,
                    (key, group) =>
                    {
                        var efEncounterses = group as IList<EFEncounters> ?? group.ToList();

                        var pokemon = efEncounterses
                            .FirstOrDefault()?
                            .Pokemon
                            .ToNamedApiResource();

                        var versionEncounterDetails = efEncounterses
                            .GroupBy(x2 => x2.Version.Id,
                                (key2, group2) =>
                                {
                                    var encounters = group2 as IList<EFEncounters> ?? group2.ToList();
                                    return GetVersionEncounterDetails(encounters);
                                })
                            .ToList();

                        return new PokemonEncounter(pokemon, versionEncounterDetails);
                    })
                .ToList();
        }

        private static VersionEncounterDetail GetVersionEncounterDetails(IList<EFEncounters> encounterses)
        {
            var version = encounterses
                .FirstOrDefault()?
                .Version
                .ToNamedApiResource();

            var maxChance = encounterses
                .Sum(encounters => encounters.EncounterSlot.Rarity ?? 0);

            var encounterDetails = encounterses
                .Select(encounters =>
                {
                    var conditionValues = encounters
                        .EncounterConditionValueMap
                        .Select(cv => cv.EncounterConditionValue.ToNamedApiResource())
                        .ToList();

                    var method = encounters
                        .EncounterSlot
                        .EncounterMethod
                        .ToNamedApiResource();

                    return new Encounter(encounters.MinLevel, encounters.MaxLevel, conditionValues,
                        encounters.EncounterSlot.Rarity, method);
                })
                .ToList();

            return new VersionEncounterDetail(version, maxChance, encounterDetails);
        }
    }
}