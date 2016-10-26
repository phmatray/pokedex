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
    [Route("api/v1/encounter-condition-values")]
    public class EncounterConditionValuesController : ApiController
    {
        private readonly VeekunContext _context;

        public EncounterConditionValuesController(VeekunContext context)
        {
            _context = context;
        }

        // GET api/v1/encounter-condition-values
        // GET api/v1/encounter-condition-values?skip=0&take=20
        [HttpGet]
        public async Task<IActionResult> GetAll(int limit = 20, int offset = 0)
            => await GetAll(limit, offset, _context.EncounterConditionValues, GetType());

        // GET api/v1/encounter-condition-values/1
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var encounterConditionValue = await _context.EncounterConditionValues
                    .AsNoTracking()
                    .Include(x => x.EncounterCondition)
                    .Include(x => x.EncounterConditionValueProse).ThenInclude(x => x.LocalLanguage)
                    .FirstOrDefaultAsync(x => x.Id == id);

                var result = new EncounterConditionValue
                {
                    Id        = encounterConditionValue.Id,
                    Name      = encounterConditionValue.Identifier,
                    Condition = GetCondition(encounterConditionValue),
                    Names     = GetNames(encounterConditionValue),
                };

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        private static NamedAPIResource GetCondition(EFEncounterConditionValues encounterConditionValue)
        {
            return encounterConditionValue
                .EncounterCondition
                .ToNamedApiResource();
        }

        private static List<Name> GetNames(EFEncounterConditionValues encounterConditionValue)
        {
            return encounterConditionValue
                .EncounterConditionValueProse
                .Select(x => new Name(x.Name, x.LocalLanguage.ToNamedApiResource()))
                .ToList();
        }
    }
}