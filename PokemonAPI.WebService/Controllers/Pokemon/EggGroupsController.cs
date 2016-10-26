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
    [Route("api/v1/egg-groups")]
    public class EggGroupsController : ApiController
    {
        private readonly VeekunContext _context;

        public EggGroupsController(VeekunContext context)
        {
            _context = context;
        }

        // GET api/v1/egggroups
        // GET api/v1/egggroups?skip=0&take=20
        [HttpGet]
        public async Task<IActionResult> GetAll(int limit = 20, int offset = 0)
            => await GetAll(limit, offset, _context.EggGroups, GetType());

        // GET api/v1/egggroups/1
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var eggGroup = await _context
                    .EggGroups
                    .AsNoTracking()
                    .Include(x => x.EggGroupProse).ThenInclude(x => x.LocalLanguage)
                    .Include(x => x.PokemonEggGroups).ThenInclude(x => x.Species)
                    .FirstOrDefaultAsync(x => x.Id == id);

                var result = new EggGroup
                {
                    Id             = eggGroup.Id,
                    Name           = eggGroup.Identifier,
                    Names          = GetNames(eggGroup),
                    PokemonSpecies = GetPokemonSpecies(eggGroup)
                };

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        private static List<Name> GetNames(EFEggGroups eggGroup)
        {
            return eggGroup
                .EggGroupProse
                .Select(x => new Name(x.Name, x.LocalLanguage.ToNamedApiResource()))
                .ToList();
        }

        private static List<NamedAPIResource> GetPokemonSpecies(EFEggGroups eggGroup)
        {
            return eggGroup
                .PokemonEggGroups
                .Select(x => x.Species.ToNamedApiResource())
                .ToList();
        }
    }
}