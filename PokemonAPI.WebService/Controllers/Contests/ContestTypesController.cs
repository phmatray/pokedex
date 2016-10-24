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
    [Route("api/v1/contest-types")]
    public class ContestTypesController : ApiController
    {
        private readonly VeekunContext _context;

        public ContestTypesController(VeekunContext context)
        {
            _context = context;
        }

        // GET api/v1/contest-types
        // GET api/v1/contest-types?skip=0&take=20
        [HttpGet]
        public async Task<IActionResult> GetAll(int limit = 20, int offset = 0) 
            => await GetAll(limit, offset, _context.ContestTypes, GetType());

        // GET api/v1/contest-types/1
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var contestType = await _context.ContestTypes
                    .Include(x => x.BerryFlavors)
                    .FirstOrDefaultAsync(x => x.Id == id);

                var result = new ContestType
                {
                    Id          = contestType.Id,
                    Name        = contestType.Identifier,
                    BerryFlavor = await GetBerryFlavor(contestType),
                    Names       = await GetNames(contestType)
                };

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        private async Task<NamedAPIResource> GetBerryFlavor(EFContestTypes contestType)
        {
            var contestTypeName = await _context
                .ContestTypeNames
                .SingleAsync(x => x.ContestTypeId == contestType.Id &&
                                  x.LocalLanguageId == 9);

            return new NamedAPIResource
            (
                contestTypeName.Flavor.ToLower(),
                typeof(BerryFlavorsController).RscUrl(contestTypeName.ContestTypeId)
            );
        }

        private async Task<List<ContestName>> GetNames(EFContestTypes contestType)
        {
            return (await _context
                    .ContestTypeNames
                    .Include(x => x.LocalLanguage)
                    .Where(x => x.ContestTypeId == contestType.Id &&
                                x.Color != null)
                    .ToListAsync())
                .Select(x => new ContestName
                (
                    x.Name,
                    x.Color,
                    x.LocalLanguage.ToNamedApiResource()
                ))
                .ToList();
        }
    }
}