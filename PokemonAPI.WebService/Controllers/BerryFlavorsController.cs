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
    [Route("api/v1/berry-flavors")]
    public class BerryFlavorsController : ApiController
    {
        private readonly VeekunContext _context;

        public BerryFlavorsController(VeekunContext context)
        {
            _context = context;
        }

        // GET api/v1/berry-flavors
        // GET api/v1/berry-flavors?skip=0&take=20
        [HttpGet]
        public async Task<IActionResult> GetAll(int limit = 20, int offset = 0)
        {
            try
            {
                if (limit <= 0) throw new ArgumentOutOfRangeException(nameof(limit));
                if (offset < 0) throw new ArgumentOutOfRangeException(nameof(offset));

                var dbset = _context.ContestTypeNames;
                var urlSegment = typeof(BerryFlavorsController).Segment();

                var count = await dbset.Where(x => x.LocalLanguageId == 9).CountAsync();
                var previous = Previous(limit, offset, urlSegment);
                var next = Next(limit, offset, count, urlSegment);

                var apiResults = (await dbset
                        .Where(x => x.LocalLanguageId == 9)
                        .Skip(offset)
                        .Take(limit)
                        .ToListAsync())
                    .Select(x => new NamedAPIResource(x.Flavor.ToLower(),
                        $"{Constants.SiteUrl}{Constants.BaseUrl}{urlSegment}/{x.ContestTypeId}/"))
                    .Cast<APIResource>()
                    .ToList();

                var results = new APIResourceList
                {
                    Count = count,
                    Previous = previous,
                    Next = next,
                    Results = apiResults
                };

                return Ok(results);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // GET api/v1/berry-flavors/1
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var contestType = await _context
                    .ContestTypes
                    .Include(x => x.ContestTypeNames)
                    .Where(x => x.Id == id)
                    .FirstOrDefaultAsync();

                var result = new BerryFlavor
                {
                    Id          = contestType.Id,
                    Name        = GetName(contestType),
                    Berries     = await GetBerries(contestType),
                    ContestType = GetContestType(contestType),
                    Names       = await GetNames(contestType)
                };

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        private string GetName(EFContestTypes contestType)
        {
            return contestType
                .ContestTypeNames
                .FirstOrDefault(x => x.LocalLanguageId == 9)?
                .Flavor
                .ToLower();
        }

        private async Task<List<FlavorBerryMap>> GetBerries(EFContestTypes contestType)
        {
            return (await _context
                    .BerryFlavors
                    .Include(x => x.Berry)
                    .Include(x => x.Berry.Item)
                    .Where(x => x.ContestTypeId == contestType.Id && x.Flavor > 0)
                    .OrderBy(x => x.Flavor)
                    .ToListAsync())
                .Select(x => new FlavorBerryMap
                {
                    Potency = x.Flavor,
                    Berry = new NamedAPIResource
                    (
                        x.Berry.Item.Identifier.Replace("-berry", ""),
                        $"{Constants.SiteUrl}{Constants.BaseUrl}{typeof(BerriesController).Segment()}/{x.BerryId}" 
                    )
                })
                .ToList();
        }

        private NamedAPIResource GetContestType(EFContestTypes contestType)
        {
            return contestType.ToNamedApiResource(
                typeof(ContestTypesController).Segment());
        }

        private async Task<List<Name>> GetNames(EFContestTypes contestType)
        {
            return (await _context
                    .ContestTypeNames
                    .Include(x => x.LocalLanguage)
                    .Where(x => x.ContestTypeId == contestType.Id)
                    .ToListAsync())
                .Select(x => new Name
                (
                    x.Flavor,
                    x.LocalLanguage.ToNamedApiResource(typeof(LanguagesController).Segment())
                ))
                .ToList();
        }
    }
}