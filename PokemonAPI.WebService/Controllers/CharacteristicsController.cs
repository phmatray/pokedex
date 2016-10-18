using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PokemonAPI.WebService.Controllers.Base;
using PokemonAPI.WebService.Core;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PokemonAPI.Models.Rsc;
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

                var urlSegment = typeof(CharacteristicsController).Segment();
                var count = await _context.Characteristics.CountAsync();
                var previous = Previous(limit, offset, urlSegment);
                var next = Next(limit, offset, count, urlSegment);

                var apiResults = (await _context.Characteristics
                        .Skip(offset)
                        .Take(limit)
                        .ToListAsync())
                    .Select(x => x.ToApiResource(urlSegment))
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
                .ToNamedApiResource(typeof(StatsController).Segment());
        }

        private List<int> GetPossibleValues(EFCharacteristics characteristic)
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
                    x.LocalLanguage.ToNamedApiResource(typeof(LanguagesController).Segment())))
                .ToList();
        }
    }
}