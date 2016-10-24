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

                var dbset      = _context.ContestTypeNames;
                var controller = typeof(BerryFlavorsController);
                var count      = await dbset.Where(x => x.LocalLanguageId == 9).CountAsync();
                var previous   = controller.Previous(limit, offset);
                var next       = controller.Next(limit, offset, count);

                var apiResults = (await dbset
                        .Where(x => x.LocalLanguageId == 9)
                        .Skip(offset)
                        .Take(limit)
                        .ToListAsync())
                    .Select(x => new NamedAPIResource(x.Flavor.ToLower(),
                        $"{Constants.SiteUrl}{Constants.BaseUrl}{controller}/{x.ContestTypeId}/"))
                    .Cast<APIResource>()
                    .ToList();

                var results = new APIResourceList(count, previous, next, apiResults);

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
                    .Include(x => x.ContestTypeNames).ThenInclude(x => x.LocalLanguage)
                    .Include(x => x.BerryFlavors).ThenInclude(x => x.Berry).ThenInclude(x => x.Item)
                    .Where(x => x.Id == id)
                    .FirstOrDefaultAsync();

                var result = new BerryFlavor
                {
                    Id          = contestType.Id,
                    Name        = GetName(contestType),
                    Berries     = GetBerries(contestType),
                    ContestType = GetContestType(contestType),
                    Names       = GetNames(contestType)
                };

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        private static string GetName(EFContestTypes contestType)
        {
            return contestType
                .ContestTypeNames
                .FirstOrDefault(x => x.LocalLanguageId == 9)?
                .Flavor
                .ToLower();
        }

        private static List<FlavorBerryMap> GetBerries(EFContestTypes contestType)
        {
            return contestType
                .BerryFlavors
                .Where(x => x.Flavor > 0)
                .OrderBy(x => x.Flavor)
                .Select(x => new FlavorBerryMap
                {
                    Potency = x.Flavor,
                    Berry = new NamedAPIResource
                    (
                        x.Berry.Item.Identifier.Replace("-berry", ""),
                        typeof(BerriesController).RscUrl(x.BerryId)
                    )
                })
                .ToList();
        }

        private static NamedAPIResource GetContestType(EFContestTypes contestType)
        {
            return contestType.ToNamedApiResource();
        }

        private static List<Name> GetNames(EFContestTypes contestType)
        {
            return contestType
                .ContestTypeNames
                .Select(x => new Name(x.Flavor, x.LocalLanguage.ToNamedApiResource()))
                .ToList();
        }
    }
}