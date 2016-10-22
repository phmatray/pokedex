using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Controllers.Base;
using PokemonAPI.WebService.Core;
using PokemonAPI.WebService.Models;
using Version = PokemonAPI.Models.Rsc.Version;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace PokemonAPI.WebService.Controllers
{
    [Route("api/v1/versions")]
    public class VersionsController : ApiController
    {
        private readonly VeekunContext _context;

        public VersionsController(VeekunContext context)
        {
            _context = context;
        }

        // GET api/v1/versions
        // GET api/v1/versions?skip=0&take=20
        [HttpGet]
        public async Task<IActionResult> GetAll(int limit = 20, int offset = 0)
        {
            return await base.GetAll(limit, offset, _context.Versions, this.Segment());
        }

        // GET api/v1/versions/1
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var version = await _context.Versions
                    .FirstOrDefaultAsync(x => x.Id == id);

                var result = new Version
                {
                    Id           = version.Id,
                    Name         = version.Identifier,
                    Names        = await GetNames(version),
                    VersionGroup = await GetVersionGroup(version)
                };

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        private async Task<List<Name>> GetNames(EFVersions version)
        {
            return (await _context
                    .VersionNames
                    .Include(x => x.LocalLanguage)
                    .Where(x => x.VersionId == version.Id)
                    .ToListAsync())
                .Select(x => new Name(x.Name,
                    x.LocalLanguage.ToNamedApiResource(typeof(LanguagesController).Segment())))
                .ToList();
        }

        private async Task<NamedAPIResource> GetVersionGroup(EFVersions version)
        {
            return (await _context
                    .VersionGroups
                    .Where(x => x.Id == version.VersionGroupId)
                    .FirstOrDefaultAsync())
                .ToNamedApiResource(typeof(VersionGroupsController).Segment());
        }
    }
}