using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Core;
using PokemonAPI.WebService.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using PokemonAPI.WebService.Controllers._Base;

namespace PokemonAPI.WebService.Controllers
{
    [Route("api/v1/growth-rates")]
    public class GrowthRatesController : ApiController
    {
        private readonly VeekunContext _context;

        public GrowthRatesController(VeekunContext context)
        {
            _context = context;
        }

        // GET api/v1/growthrates
        // GET api/v1/growthrates?skip=0&take=20
        [HttpGet]
        public async Task<IActionResult> GetAll(int limit = 20, int offset = 0)
            => await GetAll(limit, offset, _context.GrowthRates, GetType());

        // GET api/v1/growthrates/1
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var growthRate = await _context
                    .GrowthRates
                    .AsNoTracking()
                    .Include(x => x.GrowthRateProse).ThenInclude(x => x.LocalLanguage)
                    .Include(x => x.Experience)
                    .Include(x => x.PokemonSpecies)
                    .FirstOrDefaultAsync(x => x.Id == id);

                var result = new GrowthRate
                {
                    Id             = growthRate.Id,
                    Name           = growthRate.Identifier,
                    Formula        = growthRate.Formula,
                    Descriptions   = GetDescriptions(growthRate),
                    Levels         = GetLevels(growthRate),
                    PokemonSpecies = GetPokemonSpecies(growthRate)
                };

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        private static List<Description> GetDescriptions(EFGrowthRates growthRate)
        {
            return growthRate
                .GrowthRateProse
                .Select(x => new Description(x.Name, x.LocalLanguage.ToNamedApiResource()))
                .ToList();
        }

        private static List<GrowthRateExperienceLevel> GetLevels(EFGrowthRates growthRate)
        {
            return growthRate
                .Experience
                .Select(x => new GrowthRateExperienceLevel(x.Level, x.Experience1))
                .ToList();
        }

        private static List<NamedAPIResource> GetPokemonSpecies(EFGrowthRates growthRate)
        {
            return growthRate
                .PokemonSpecies
                .Select(x => x.ToNamedApiResource())
                .ToList();
        }
    }
}