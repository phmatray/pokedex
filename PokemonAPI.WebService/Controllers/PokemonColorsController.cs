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
    public class PokemonColorsController : ApiController<EFPokemonColors>
    {
        public PokemonColorsController(VeekunContext context)
            : base(context, "PokemonColors", "pokemon-colors")
        {
        }

        // GET api/v1/pokemoncolors
        // GET api/v1/pokemoncolors?skip=0&take=20
        [HttpGet]
        public async Task<IActionResult> GetAll(int limit = 20, int offset = 0)
        {
            return await base.GetAll(limit, offset);
        }

        // GET api/v1/pokemoncolors/1
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var pokemonColor = await MainDbSet
                    .FirstOrDefaultAsync(x => x.Id == id);

                var result = new PokemonColor
                {
                    Id             = pokemonColor.Id,
                    Name           = pokemonColor.Identifier,
                    Names          = await GetNames(pokemonColor),
                    PokemonSpecies = await GetPokemonSpecies(pokemonColor)
                };

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        private async Task<List<Name>> GetNames(EFPokemonColors pokemonColor)
        {
            return (await Context
                    .PokemonColorNames
                    .Include(x => x.LocalLanguage)
                    .Where(x => x.PokemonColorId == pokemonColor.Id)
                    .ToListAsync())
                .Select(x => new Name(x.Name, x.LocalLanguage.ToNamedApiResource()))
                .ToList();
        }

        private async Task<List<NamedAPIResource>> GetPokemonSpecies(EFPokemonColors pokemonColor)
        {
            return (await Context
                    .PokemonSpecies
                    .Where(x => x.ColorId == pokemonColor.Id)
                    .ToListAsync())
                .Select(x => x.ToNamedApiResource())
                .ToList();
        }
    }
}