using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PokemonAPI.Models.Resources;
using PokemonAPI.WebService.Controllers.Base;
using PokemonAPI.WebService.Core;
using PokemonAPI.WebService.Models;

namespace PokemonAPI.WebService.Controllers
{
    [Route("api/v1/[controller]")]
    public class GrowthRatesController : ApiController<GrowthRates>
    {
        public GrowthRatesController(VeekunContext context)
            : base(context)
        {
        }

        // GET api/v1/growthrates
        // GET api/v1/growthrates?skip=0&take=20
        [HttpGet]
        public async Task<IActionResult> GetAll(int limit = 20, int offset = 0)
        {
            return await base.GetAll(limit, offset);
        }

        // GET api/v1/growthrates/1
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var growthRate = await MainDbSet
                    .FirstOrDefaultAsync(x => x.Id == id);

                var result = new GrowthRateResource
                {
                    Id             = growthRate.Id,
                    Identifier     = growthRate.Identifier,
                    Formula        = growthRate.Formula,
                    Descriptions   = await GetDescriptions(growthRate),
                    Levels         = await GetLevels(growthRate),
                    PokemonSpecies = await GetPokemonSpecies(growthRate)
                };

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        private async Task<List<DescriptionResource>> GetDescriptions(GrowthRates growthRate)
        {
            return (await Context
                    .GrowthRateProse
                    .Include(x => x.LocalLanguage)
                    .Where(x => x.GrowthRateId == growthRate.Id)
                    .ToListAsync())
                .Select(x => x.ToDescriptionResource())
                .ToList();
        }

        private async Task<List<GrowthRateExperienceLevelResource>> GetLevels(GrowthRates growthRate)
        {
            return (await Context
                    .Experience
                    .Where(x => x.GrowthRateId == growthRate.Id)
                    .ToListAsync())
                .Select(x => x.ToGrowthRateExperienceLevelResource())
                .ToList();
        }

        private async Task<List<NamedAPIResource>> GetPokemonSpecies(GrowthRates growthRate)
        {
            return (await Context
                    .PokemonSpecies
                    .Where(x => x.GrowthRateId == growthRate.Id)
                    .ToListAsync())
                .Select(x => x.ToNamedApiResource())
                .ToList();
        }
    }
}