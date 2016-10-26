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
                    .AsNoTracking()
                    .Include(x => x.ContestTypeNames).ThenInclude(x => x.LocalLanguage)
                    .Include(x => x.BerryFlavors)
                    .FirstOrDefaultAsync(x => x.Id == id);

                var result = new ContestType
                {
                    Id          = contestType.Id,
                    Name        = contestType.Identifier,
                    BerryFlavor = GetBerryFlavor(contestType),
                    Names       = GetNames(contestType)
                };

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        private static NamedAPIResource GetBerryFlavor(EFContestTypes contestType)
        {
            return contestType
                .ContestTypeNames
                .SingleOrDefault(x => x.LocalLanguageId == 9)
                .ToNamedApiResource();
        }

        private static List<ContestName> GetNames(EFContestTypes contestType)
        {
            return contestType
                .ContestTypeNames
                .Where(x => x.Color != null)
                .Select(x => new ContestName(x.Name, x.Color, x.LocalLanguage.ToNamedApiResource()))
                .ToList();
        }
    }
}