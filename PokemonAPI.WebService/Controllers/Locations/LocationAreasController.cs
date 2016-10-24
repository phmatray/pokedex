using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Controllers.Base;
using PokemonAPI.WebService.Core;
using PokemonAPI.WebService.Models;
using System.Linq;

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
        {
            return await base.GetAll(limit, offset,
                _context.LocationAreas, this.Segment());
        }

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

        private string GetName(EFLocationAreas locationArea)
        {
            return $"{locationArea.Location.Identifier}-{locationArea.Identifier ?? "area"}";
        }

        private List<EncounterMethodRate> GetEncounterMethodRates(EFLocationAreas locationArea)
        {
            return locationArea
                .LocationAreaEncounterRates
                .GroupBy(x => x.EncounterMethodId,
                    (key, group) => new EncounterMethodRate
                    {
                        EncounterMethod = group
                            .FirstOrDefault()?
                            .EncounterMethod
                            .ToNamedApiResource(),
                        VersionDetails = group
                            .Select(g => new EncounterVersionDetails
                            {
                                Rate = g.Rate,
                                Version = g.Version.ToNamedApiResource()
                            })
                            .ToList()
                    })
                .ToList();
        }

        private NamedAPIResource GetLocation(EFLocationAreas locationArea)
        {
            return locationArea
                .Location
                .ToNamedApiResource();
        }

        private List<Name> GetNames(EFLocationAreas locationArea)
        {
            return locationArea
                .LocationAreaProse
                .Select(x => new Name(x.Name, x.LocalLanguage.ToNamedApiResource()))
                .ToList();
        }

        private List<PokemonEncounter> GetPokemonEncounters(EFLocationAreas locationArea)
        {
            return locationArea
                .Encounters
                .GroupBy(x => x.PokemonId,
                    (key, group) => new PokemonEncounter
                    {
                        Pokemon = group
                            .FirstOrDefault()?
                            .Pokemon
                            .ToNamedApiResource(),
                        VersionDetails = group
                            .GroupBy(x2 => x2.Version.Id,
                                (key2, group2) => new VersionEncounterDetail
                                {
                                    Version = group2
                                        .FirstOrDefault()?
                                        .Version
                                        .ToNamedApiResource(),
                                    MaxChance = group2.Sum(g2 => g2.EncounterSlot.Rarity ?? 0),
                                    EncounterDetails = group2
                                        .Select(g2 => new Encounter
                                        {
                                            MinLevel = g2.MinLevel,
                                            MaxLevel = g2.MaxLevel,
                                            ConditionValues = g2
                                                .EncounterConditionValueMap
                                                .Select(cv => cv.EncounterConditionValue
                                                    .ToNamedApiResource())
                                                .ToList(),
                                            Chance = g2.EncounterSlot.Rarity,
                                            Method = g2
                                                .EncounterSlot
                                                .EncounterMethod
                                                .ToNamedApiResource()
                                        })
                                        .ToList()
                                })
                            .ToList()
                    })
                .ToList();
        }
    }
}