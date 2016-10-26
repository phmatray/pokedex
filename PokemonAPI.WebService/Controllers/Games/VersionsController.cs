using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Core;
using PokemonAPI.WebService.Models;
using Version = PokemonAPI.Models.Rsc.Version;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using PokemonAPI.WebService.Controllers._Base;

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
            => await GetAll(limit, offset, _context.Versions, GetType());

        // GET api/v1/versions/1
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var version = await _context.Versions
                    .AsNoTracking()
                    .Include(x => x.VersionNames).ThenInclude(x => x.LocalLanguage)
                    .Include(x => x.VersionGroup)
                    .FirstOrDefaultAsync(x => x.Id == id);

                var result = new Version
                {
                    Id           = version.Id,
                    Name         = version.Identifier,
                    Names        = GetNames(version),
                    VersionGroup = GetVersionGroup(version)
                };

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        private static List<Name> GetNames(EFVersions version)
        {
            return version
                .VersionNames
                .Select(x => new Name(x.Name, x.LocalLanguage.ToNamedApiResource()))
                .ToList();
        }

        private static NamedAPIResource GetVersionGroup(EFVersions version)
        {
            return version
                .VersionGroup?
                .ToNamedApiResource();
        }
    }
}