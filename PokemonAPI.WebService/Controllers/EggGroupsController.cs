using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Controllers.Base;
using PokemonAPI.WebService.Core;
using PokemonAPI.WebService.Models;

namespace PokemonAPI.WebService.Controllers
{
    [Route("api/v1/[controller]")]
    public class EggGroupsController : ApiController<EFEggGroups>
    {
        public EggGroupsController(VeekunContext context)
            : base(context, "EggGroups", "egg-groups")
        {
        }

        // GET api/v1/egggroups
        // GET api/v1/egggroups?skip=0&take=20
        [HttpGet]
        public async Task<IActionResult> GetAll(int limit = 20, int offset = 0)
        {
            return await base.GetAll(limit, offset);
        }

        // GET api/v1/egggroups/1
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var eggGroup = await MainDbSet
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
            return (await Context
                    .EggGroupProse
                    .Include(x => x.LocalLanguage)
                    .Where(x => x.EggGroupId == eggGroup.Id)
                    .ToListAsync())
                .Select(x => new Name(x.Name, x.LocalLanguage.ToNamedApiResource()))
                .ToList();
        }

        private async Task<List<NamedAPIResource>> GetPokemonSpecies(EFEggGroups eggGroup)
        {
            return (await Context
                    .PokemonSpecies
                    .Include(x => x.PokemonEggGroups)
                    .Where(x => x.PokemonEggGroups.Any(y => y.EggGroupId == eggGroup.Id))
                    .ToListAsync())
                .Select(x => x.ToNamedApiResource())
                .ToList();
        }
    }
}