using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Controllers.Base;
using PokemonAPI.WebService.Core;
using PokemonAPI.WebService.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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
        {
            return await base.GetAll(limit, offset, _context.EggGroups, this.Segment());
        }

        // GET api/v1/egggroups/1
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var eggGroup = await _context.EggGroups
                    .FirstOrDefaultAsync(x => x.Id == id);

                var result = new EggGroup
                {
                    Id             = eggGroup.Id,
                    Name           = eggGroup.Identifier,
                    Names          = await GetNames(eggGroup),
                    PokemonSpecies = await GetPokemonSpecies(eggGroup)
                };

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        private async Task<List<Name>> GetNames(EFEggGroups eggGroup)
        {
            return (await _context
                    .EggGroupProse
                    .Include(x => x.LocalLanguage)
                    .Where(x => x.EggGroupId == eggGroup.Id)
                    .ToListAsync())
                .Select(x => new Name(x.Name, 
                    x.LocalLanguage.ToNamedApiResource()))
                .ToList();
        }

        private async Task<List<NamedAPIResource>> GetPokemonSpecies(EFEggGroups eggGroup)
        {
            return (await _context
                    .PokemonSpecies
                    .Include(x => x.PokemonEggGroups)
                    .Where(x => x.PokemonEggGroups.Any(y => y.EggGroupId == eggGroup.Id))
                    .ToListAsync())
                .Select(x => x.ToNamedApiResource())
                .ToList();
        }
    }
}