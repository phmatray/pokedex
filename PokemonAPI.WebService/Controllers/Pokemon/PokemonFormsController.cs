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
    [Route("api/v1/pokemon-forms")]
    public class PokemonFormsController : ApiController
    {
        private readonly VeekunContext _context;

        public PokemonFormsController(VeekunContext context)
        {
            _context = context;
        }

        // GET api/v1/pokemon-forms
        // GET api/v1/pokemon-forms?skip=0&take=20
        [HttpGet]
        public async Task<IActionResult> GetAll(int limit = 20, int offset = 0)
            => await GetAll(limit, offset, _context.PokemonForms, GetType());

        // GET api/v1/pokemon-forms/1
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var pokemonForm = await _context.PokemonForms
                    .Include(x => x.Pokemon)
                    .Include(x => x.IntroducedInVersionGroup)
                    .Include(x => x.PokemonFormNames).ThenInclude(x => x.LocalLanguage)
                    .FirstOrDefaultAsync(x => x.Id == id);

                var result = new PokemonForm
                {
                    Id           = pokemonForm.Id,
                    Name         = pokemonForm.Identifier,
                    Order        = pokemonForm.Order,
                    FormOrder    = pokemonForm.FormOrder,
                    IsDefault    = pokemonForm.IsDefault,
                    IsBattleOnly = pokemonForm.IsBattleOnly,
                    IsMega       = pokemonForm.IsMega,
                    FormName     = pokemonForm.FormIdentifier,
                    Pokemon      = GetPokemon(pokemonForm),
                    Sprites      = null,//GetSprites(pokemonForm),
                    VersionGroup = GetVersionGroup(pokemonForm),
                    Names        = GetNames(pokemonForm),
                    FormNames    = GetFormNames(pokemonForm)
                };

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        private static NamedAPIResource GetPokemon(EFPokemonForms pokemonForm)
        {
            return pokemonForm
                .Pokemon
                .ToNamedApiResource();
        }

        //private static PokemonFormSprites GetSprites(EFPokemonForms pokemonForm)
        //{
        //    var spriteUrlBase = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/";

        //    return new PokemonFormSprites
        //    {
        //        BackDefault = null, // $"{spriteUrlBase}back/{pokemonForm.Id}.png",
        //        BackShiny = null, // $"{spriteUrlBase}back/shiny/{pokemonForm.Id}.png",
        //        FrontDefault = null, // $"{spriteUrlBase}{pokemonForm.Id}.png",
        //        FrontShiny = null  // $"{spriteUrlBase}shiny/{pokemonForm.Id}.png"
        //    };
        //}

        private static NamedAPIResource GetVersionGroup(EFPokemonForms pokemonForm)
        {
            return pokemonForm
                .IntroducedInVersionGroup
                .ToNamedApiResource();
        }

        private static List<Name> GetNames(EFPokemonForms pokemonForm)
        {
            return pokemonForm
                .PokemonFormNames
                .Where(x => x.PokemonName != null)
                .Select(x => new Name(x.PokemonName, x.LocalLanguage.ToNamedApiResource()))
                .ToList();
        }

        private static List<Name> GetFormNames(EFPokemonForms pokemonForm)
        {
            return pokemonForm
                .PokemonFormNames
                .Select(x => new Name(x.FormName, x.LocalLanguage.ToNamedApiResource()))
                .ToList();
        }
    }
}