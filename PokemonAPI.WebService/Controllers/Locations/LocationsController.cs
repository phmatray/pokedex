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
    [Route("api/v1/locations")]
    public class LocationsController : ApiController
    {
        private readonly VeekunContext _context;

        public LocationsController(VeekunContext context)
        {
            _context = context;
        }

        // GET api/v1/locations
        // GET api/v1/locations?skip=0&take=20
        [HttpGet]
        public async Task<IActionResult> GetAll(int limit = 20, int offset = 0)
        {
            return await base.GetAll(limit, offset, 
                _context.Locations, this.Segment());
        }

        // GET api/v1/locations/1
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var location = await _context.Locations
                    .Include(x => x.Region)
                    .Include(x => x.LocationNames).ThenInclude(x => x.LocalLanguage)
                    .Include(x => x.LocationGameIndices).ThenInclude(x => x.Generation)
                    .Include(x => x.LocationAreas)
                    .FirstOrDefaultAsync(x => x.Id == id);

                var result = new Location
                {
                    Id          = location.Id,
                    Name        = location.Identifier,
                    Region      = GetRegion(location),
                    Names       = GetNames(location),
                    GameIndices = GetGameIndices(location),
                    Areas       = GetAreas(location)
                };

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        private static NamedAPIResource GetRegion(EFLocations location)
        {
            return location.Region
                .ToNamedApiResource();
        }

        private static List<Name> GetNames(EFLocations location)
        {
            return location
                .LocationNames
                .Select(x => new Name
                (
                    x.Name,
                    x.LocalLanguage.ToNamedApiResource()
                ))
                .ToList();
        }

        private static List<GenerationGameIndex> GetGameIndices(EFLocations location)
        {
            return location
                .LocationGameIndices
                .Select(x => new GenerationGameIndex
                {
                    GameIndex = x.GameIndex,
                    Generation = x.Generation.ToNamedApiResource()
                })
                .ToList();
        }

        private static List<NamedAPIResource> GetAreas(EFLocations location)
        {
            return location
                .LocationAreas
                .Select(x => new NamedAPIResource($"{location.Identifier}-{x.Identifier ?? "area"}",
                    typeof(LocationAreasController).RscUrl(x.Id)))
                .ToList();
        }
    }
}