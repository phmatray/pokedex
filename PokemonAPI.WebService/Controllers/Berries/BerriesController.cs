using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Core;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using PokemonAPI.WebService.Controllers._Base;
using PokemonAPI.WebService.Models;

namespace PokemonAPI.WebService.Controllers
{
    [Route("api/v1/berries")]
    public class BerriesController : ApiController
    {
        private readonly VeekunContext _context;

        public BerriesController(VeekunContext context)
        {
            _context = context;
        }

        // GET api/v1/berries
        // GET api/v1/berries?skip=0&take=20
        [HttpGet]
        public async Task<IActionResult> GetAll(int limit = 20, int offset = 0)
        {
            try
            {
                if (limit <= 0) throw new ArgumentOutOfRangeException(nameof(limit));
                if (offset < 0) throw new ArgumentOutOfRangeException(nameof(offset));

                var dbset      = _context.Berries;
                var controller = typeof(BerriesController);
                var count      = await dbset.CountAsync();
                var previous   = controller.Previous(limit, offset);
                var next       = controller.Next(limit, offset, count);

                var apiResults = (await dbset
                        .Include(x => x.Item)
                        .Skip(offset)
                        .Take(limit)
                        .ToListAsync())
                    .Select(x => new NamedAPIResource
                    (
                        x.Item.Identifier.Replace("-berry", ""),
                        controller.RscUrl(x.Id)
                    ))
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

        // GET api/v1/berries/1
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var berry = await _context.Berries
                    .Include(x => x.Firmness)
                    .Include(x => x.BerryFlavors).ThenInclude(x => x.ContestType).ThenInclude(x => x.ContestTypeNames)
                    .Include(x => x.Item)
                    .Include(x => x.NaturalGiftType)
                    .FirstOrDefaultAsync(x => x.Id == id);

                var result = new Berry
                {
                    Id               = berry.Id,
                    Name             = berry.Item.Identifier.Replace("-berry", ""),
                    GrowthTime       = berry.GrowthTime,
                    MaxHarvest       = berry.MaxHarvest,
                    NaturalGiftPower = berry.NaturalGiftPower,
                    Size             = berry.Size,
                    Smoothness       = berry.Smoothness,
                    SoilDryness      = berry.SoilDryness,
                    Firmness         = GetFirmness(berry),
                    Flavors          = GetFlavors(berry),
                    Item             = GetItem(berry),
                    NaturalGiftType  = GetNaturalGiftType(berry)
                };

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        private static NamedAPIResource GetFirmness(EFBerries berry)
        {
            return berry.Firmness
                .ToNamedApiResource();
        }

        private static List<BerryFlavorMap> GetFlavors(EFBerries berry)
        {
            return berry
                .BerryFlavors
                .Select(x => new BerryFlavorMap
                {
                    Potency = x.Flavor,
                    Flavor = new NamedAPIResource
                    (
                        x.ContestType.ContestTypeNames.Single(y => y.LocalLanguageId == 9).Flavor.ToLower(),
                        typeof(BerryFlavorsController).RscUrl(x.ContestTypeId)
                    )
                })
                .ToList();
        }

        private static NamedAPIResource GetItem(EFBerries berry)
        {
            return berry.Item
                .ToNamedApiResource();
        }

        private static NamedAPIResource GetNaturalGiftType(EFBerries berry)
        {
            return berry.NaturalGiftType
                .ToNamedApiResource();
        }
    }
}