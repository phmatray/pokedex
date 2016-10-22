using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Controllers.Base;
using PokemonAPI.WebService.Core;
using PokemonAPI.WebService.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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
        {
            return await base.GetAll(limit, offset, _context.VersionGroups, this.Segment());
        }

        // GET api/v1/versiongroups/1
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var versionGroup = await _context.VersionGroups
                    .FirstOrDefaultAsync(x => x.Id == id);

                var result = new VersionGroup
                {
                    Id               = versionGroup.Id,
                    Name             = versionGroup.Identifier,
                    Order            = versionGroup.Order,
                    MoveLearnMethods = await GetMoveLearnMethods(versionGroup),
                    Versions         = await GetVersions(versionGroup),
                    Generation       = await GetGeneration(versionGroup),
                    Regions          = await GetRegions(versionGroup),
                    Pokedexes        = await GetPokedexes(versionGroup)
                };

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        private async Task<List<NamedAPIResource>> GetMoveLearnMethods(EFVersionGroups versionGroup)
        {
            return (await _context
                    .VersionGroupPokemonMoveMethods
                    .Include(x => x.PokemonMoveMethod)
                    .Where(x => x.VersionGroupId == versionGroup.Id)
                    .ToListAsync())
                .Select(x => new NamedAPIResource
                (
                    x.PokemonMoveMethod.Identifier,
                    $"{Constants.SiteUrl}{Constants.BaseUrl}{typeof(MoveLearnMethodsController).Segment()}/{x.PokemonMoveMethodId}/"
                ))
                .ToList();
        }

        private async Task<List<NamedAPIResource>> GetVersions(EFVersionGroups versionGroup)
        {
            return (await _context
                    .Versions
                    .Where(x => x.VersionGroupId == versionGroup.Id)
                    .ToListAsync())
                .Select(x => x.ToNamedApiResource(typeof(VersionsController).Segment()))
                .ToList();
        }

        private async Task<NamedAPIResource> GetGeneration(EFVersionGroups versionGroup)
        {
            return (await _context
                    .Generations
                    .FirstOrDefaultAsync(x => x.Id == versionGroup.GenerationId))?
                .ToNamedApiResource(typeof(GenerationsController).Segment());
        }

        private async Task<List<NamedAPIResource>> GetRegions(EFVersionGroups versionGroup)
        {
            return (await _context
                    .VersionGroupRegions
                    .Include(x => x.Region)
                    .Where(x => x.VersionGroupId == versionGroup.Id)
                    .ToListAsync())
                .Select(x => new NamedAPIResource
                (
                    x.Region.Identifier,
                    $"{Constants.SiteUrl}{Constants.BaseUrl}{typeof(RegionsController).Segment()}/{x.RegionId}/"
                ))
                .ToList();
        }

        private async Task<List<NamedAPIResource>> GetPokedexes(EFVersionGroups versionGroup)
        {
            return (await _context
                    .PokedexVersionGroups
                    .Include(x => x.Pokedex)
                    .Where(x => x.VersionGroupId == versionGroup.Id)
                    .ToListAsync())
                .Select(x => new NamedAPIResource
                (
                    x.Pokedex.Identifier,
                    $"{Constants.SiteUrl}{Constants.BaseUrl}{typeof(PokemonsController).Segment()}/{x.PokedexId}/"
                ))
                .ToList();
        }
    }
}