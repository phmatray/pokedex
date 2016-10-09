using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PokemonAPI.Models.Resources;
using PokemonAPI.Models.SourceTypeEnums;
using PokemonAPI.WebService.Controllers.Base;
using PokemonAPI.WebService.Core;
using PokemonAPI.WebService.Models;

namespace PokemonAPI.WebService.Controllers
{
    [Route("api/v1/[controller]")]
    public class VersionGroupsController : ApiController<VersionGroups>
    {
        public VersionGroupsController(VeekunContext context) 
            : base(context)
        {
        }

        // GET api/v1/versiongroups
        // GET api/v1/versiongroups?skip=0&take=20
        [HttpGet]
        public async Task<IActionResult> GetAll(int limit = 20, int offset = 0)
        {
            return await base.GetAll(limit, offset);
        }

        // GET api/v1/versiongroups/1
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var versionGroup = await MainDbSet
                    .FirstOrDefaultAsync(x => x.Id == id);

                var result = new VersionGroupResource
                {
                    Id               = versionGroup.Id,
                    Identifier       = versionGroup.Identifier,
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

        private async Task<List<NamedAPIResource>> GetMoveLearnMethods(VersionGroups versionGroup)
        {
            return (await Context
                    .VersionGroupPokemonMoveMethods
                    .Include(x => x.PokemonMoveMethod)
                    .Where(x => x.VersionGroupId == versionGroup.Id)
                    .ToListAsync())
                .Select(x => x.ToNamedApiResource())
                .ToList();
        }

        private async Task<List<NamedAPIResource>> GetVersions(VersionGroups versionGroup)
        {
            return (await Context
                    .Versions
                    .Where(x => x.VersionGroupId == versionGroup.Id)
                    .ToListAsync())
                .Select(x => x.ToNamedApiResource())
                .ToList();
        }

        private async Task<NamedAPIResource> GetGeneration(VersionGroups versionGroup)
        {
            return (await Context
                    .Generations
                    .FirstOrDefaultAsync(x => x.Id == versionGroup.GenerationId))?
                .ToNamedApiResource();
        }

        private async Task<List<NamedAPIResource>> GetRegions(VersionGroups versionGroup)
        {
            return (await Context
                    .VersionGroupRegions
                    .Include(x => x.Region)
                    .Where(x => x.VersionGroupId == versionGroup.Id)
                    .ToListAsync())
                .Select(x => x.ToNamedApiResource(VersionGroupRegionSourceType.VersionGroup))
                .ToList();
        }

        private async Task<List<NamedAPIResource>> GetPokedexes(VersionGroups versionGroup)
        {
            return (await Context
                    .PokedexVersionGroups
                    .Include(x => x.Pokedex)
                    .Where(x => x.VersionGroupId == versionGroup.Id)
                    .ToListAsync())
                .Select(x => x.ToNamedApiResource(PokedexVersionGroupsSourceType.VersionGroup))
                .ToList();
        }
    }
}