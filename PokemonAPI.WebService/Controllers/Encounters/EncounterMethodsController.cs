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
    [Route("api/v1/encounter-methods")]
    public class EncounterMethodsController : ApiController
    {
        private readonly VeekunContext _context;

        public EncounterMethodsController(VeekunContext context)
        {
            _context = context;
        }

        // GET api/v1/encounter-methods
        // GET api/v1/encounter-methods?skip=0&take=20
        [HttpGet]
        public async Task<IActionResult> GetAll(int limit = 20, int offset = 0)
        {
            return await base.GetAll(limit, offset,
                _context.EncounterMethods, this.Segment());
        }

        // GET api/v1/encounter-methods/1
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var encounterMethod = await _context.EncounterMethods
                    .Include(x => x.EncounterMethodProse).ThenInclude(x => x.LocalLanguage)
                    .FirstOrDefaultAsync(x => x.Id == id);

                var result = new EncounterMethod
                {
                    Id    = encounterMethod.Id,
                    Name  = encounterMethod.Identifier,
                    Order = encounterMethod.Order,
                    Names = GetNames(encounterMethod),
                };

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        private List<Name> GetNames(EFEncounterMethods encounterMethod)
        {
            return encounterMethod
                .EncounterMethodProse
                .Select(x => new Name(x.Name, x.LocalLanguage.ToNamedApiResource<LanguagesController>()))
                .ToList();
        }
    }
}