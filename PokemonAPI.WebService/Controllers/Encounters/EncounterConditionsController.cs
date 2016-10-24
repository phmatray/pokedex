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
    [Route("api/v1/encounter-conditions")]
    public class EncounterConditionsController : ApiController
    {
        private readonly VeekunContext _context;

        public EncounterConditionsController(VeekunContext context)
        {
            _context = context;
        }

        // GET api/v1/encounter-conditions
        // GET api/v1/encounter-conditions?skip=0&take=20
        [HttpGet]
        public async Task<IActionResult> GetAll(int limit = 20, int offset = 0)
        {
            return await base.GetAll(limit, offset,
                _context.EncounterConditions, this.Segment());
        }

        // GET api/v1/encounter-conditions/1
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var encounterCondition = await _context.EncounterConditions
                    .Include(x => x.EncounterConditionProse).ThenInclude(x => x.LocalLanguage)
                    .Include(x => x.EncounterConditionValues)
                    .FirstOrDefaultAsync(x => x.Id == id);

                var result = new EncounterCondition
                {
                    Id     = encounterCondition.Id,
                    Name   = encounterCondition.Identifier,
                    Names  = GetNames(encounterCondition),
                    Values = GetValues(encounterCondition)
                };

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        private List<Name> GetNames(EFEncounterConditions encounterCondition)
        {
            return encounterCondition
                .EncounterConditionProse
                .Select(x => new Name(x.Name, x.LocalLanguage.ToNamedApiResource()))
                .ToList();
        }

        private List<NamedAPIResource> GetValues(EFEncounterConditions encounterCondition)
        {
            return encounterCondition
                .EncounterConditionValues
                .Select(x => x.ToNamedApiResource())
                .ToList();
        }
    }
}