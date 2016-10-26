using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Core;
using PokemonAPI.WebService.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using PokemonAPI.WebService.Controllers._Base;

namespace PokemonAPI.WebService.Controllers
{
    [Route("api/v1/version-groups")]
    public class VersionGroupsController : ApiController
    {
        private readonly VeekunContext _context;

        public VersionGroupsController(VeekunContext context)
        {
            _context = context;
        }

        // GET api/v1/versiongroups
        // GET api/v1/versiongroups?skip=0&take=20
        [HttpGet]
        public async Task<IActionResult> GetAll(int limit = 20, int offset = 0)
            => await GetAll(limit, offset, _context.VersionGroups, GetType());

        // GET api/v1/versiongroups/1
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var versionGroup = await _context.VersionGroups
                    .AsNoTracking()
                    .Include(x => x.VersionGroupPokemonMoveMethods).ThenInclude(x => x.PokemonMoveMethod)
                    .Include(x => x.Versions)
                    .Include(x => x.Generation)
                    .Include(x => x.VersionGroupRegions).ThenInclude(x => x.Region)
                    .Include(x => x.PokedexVersionGroups).ThenInclude(x => x.Pokedex)
                    .FirstOrDefaultAsync(x => x.Id == id);

                var result = new VersionGroup
                {
                    Id               = versionGroup.Id,
                    Name             = versionGroup.Identifier,
                    Order            = versionGroup.Order,
                    MoveLearnMethods = GetMoveLearnMethods(versionGroup),
                    Versions         = GetVersions(versionGroup),
                    Generation       = GetGeneration(versionGroup),
                    Regions          = GetRegions(versionGroup),
                    Pokedexes        = GetPokedexes(versionGroup)
                };

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        private static List<NamedAPIResource> GetMoveLearnMethods(EFVersionGroups versionGroup)
        {
            return versionGroup
                .VersionGroupPokemonMoveMethods
                .Select(x => x.PokemonMoveMethod?.ToNamedApiResource())
                .ToList();
        }

        private static List<NamedAPIResource> GetVersions(EFVersionGroups versionGroup)
        {
            return versionGroup
                .Versions
                .Select(x => x.ToNamedApiResource())
                .ToList();
        }

        private static NamedAPIResource GetGeneration(EFVersionGroups versionGroup)
        {
            return versionGroup
                .Generation?
                .ToNamedApiResource();
        }

        private static List<NamedAPIResource> GetRegions(EFVersionGroups versionGroup)
        {
            return versionGroup
                .VersionGroupRegions
                .Select(x => x.Region?.ToNamedApiResource())
                .ToList();
        }

        private static List<NamedAPIResource> GetPokedexes(EFVersionGroups versionGroup)
        {
            return versionGroup
                .PokedexVersionGroups
                .Select(x => x.Pokedex?.ToNamedApiResource())
                .ToList();
        }
    }
}