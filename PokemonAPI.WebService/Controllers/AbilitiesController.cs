using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Controllers.Base;
using PokemonAPI.WebService.Models;

namespace PokemonAPI.WebService.Controllers
{
    [Route("api/v1/[controller]")]
    public class AbilitiesController : ApiController<EFAbilities>
    {
        public AbilitiesController(VeekunContext context)
            : base(context, "Abilities", "abilities")
        {
        }

        // GET api/v1/abilities
        // GET api/v1/abilities?skip=0&take=20
        [HttpGet]
        public async Task<IActionResult> GetAll(int limit = 20, int offset = 0)
        {
            return await base.GetAll(limit, offset);
        }

        // GET api/v1/abilities/1
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var ability = await MainDbSet
                    .FirstOrDefaultAsync(x => x.Id == id);

                var result = new Ability
                {
                    //Id             = ability.Id,
                    //Identifier     = ability.Identifier,
                    //Names          = await GetNames(ability),
                    //PokemonSpecies = await GetPokemonSpecies(ability)
                };

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}