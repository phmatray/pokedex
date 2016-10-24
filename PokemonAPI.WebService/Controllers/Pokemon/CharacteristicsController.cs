using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PokemonAPI.WebService.Core;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Controllers._Base;
using PokemonAPI.WebService.Models;

namespace PokemonAPI.WebService.Controllers
{
    [Route("api/v1/characteristics")]
    public class CharacteristicsController : ApiController
    {
        private readonly VeekunContext _context;

        public CharacteristicsController(VeekunContext context)
        {
            _context = context;
        }

        // GET api/v1/characteristics
        // GET api/v1/characteristics?skip=0&take=20
        [HttpGet]
        public async Task<IActionResult> GetAll(int limit = 30, int offset = 0)
        {
            try
            {
                if (limit <= 0) throw new ArgumentOutOfRangeException(nameof(limit));
                if (offset < 0) throw new ArgumentOutOfRangeException(nameof(offset));

                var dbSet      = _context.Characteristics;
                var controller = typeof(CharacteristicsController);
                var count      = await dbSet.CountAsync();
                var previous   = controller.Previous(limit, offset);
                var next       = controller.Next(limit, offset, count);

                var apiResults = (await dbSet
                        .Skip(offset)
                        .Take(limit)
                        .ToListAsync())
                    .Select(x => x.ToApiResource(controller))
                    .ToList();

                var results = new APIResourceList(count, previous, next, apiResults);

                return Ok(results);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // GET api/v1/characteristics/1
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var characteristic = await _context.Characteristics
                    .FirstOrDefaultAsync(x => x.Id == id);

                var result = new Characteristic
                {
                    Id             = characteristic.Id,
                    GeneModulo     = characteristic.GeneMod5,
                    HighestStat    = await GetHighestStat(characteristic),
                    PossibleValues = GetPossibleValues(characteristic),
                    Descriptions   = await GetDescriptions(characteristic)
                };

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        private async Task<NamedAPIResource> GetHighestStat(EFCharacteristics characteristic)
        {
            return (await _context
                    .Stats
                    .FirstOrDefaultAsync(x => x.Id == characteristic.StatId))?
                .ToNamedApiResource();
        }

        private static List<int> GetPossibleValues(EFCharacteristics characteristic)
        {
            switch (characteristic.GeneMod5)
            {
                case 0: return new List<int> {0, 5, 10, 15, 20, 25, 30};
                case 1: return new List<int> {1, 6, 11, 16, 21, 26, 31};
                case 2: return new List<int> {2, 7, 12, 17, 22, 27};
                case 3: return new List<int> {3, 8, 13, 18, 23, 28};
                case 4: return new List<int> {4, 9, 14, 19, 24, 29};
                default:
                    return null;
            }
        }

        private async Task<List<Description>> GetDescriptions(EFCharacteristics characteristic)
        {
            return (await _context
                    .CharacteristicText
                    .Include(x => x.LocalLanguage)
                    .Where(x => x.CharacteristicId == characteristic.Id)
                    .ToListAsync())
                .Select(x => new Description(x.Message,
                    x.LocalLanguage.ToNamedApiResource()))
                .ToList();
        }
    }
}