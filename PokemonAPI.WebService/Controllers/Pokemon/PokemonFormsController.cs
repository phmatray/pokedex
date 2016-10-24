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
                    Pokemon      = await GetPokemon(pokemonForm),
                    Sprites      = null,//GetSprites(pokemonForm),
                    VersionGroup = await GetVersionGroup(pokemonForm),
                    Names        = await GetNames(pokemonForm),
                    FormNames    = await GetFormNames(pokemonForm)
                };

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        private async Task<NamedAPIResource> GetPokemon(EFPokemonForms pokemonForm)
        {
            return (await _context
                    .Pokemon
                    .FirstOrDefaultAsync(x => x.Id == pokemonForm.PokemonId))
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

        private async Task<NamedAPIResource> GetVersionGroup(EFPokemonForms pokemonForm)
        {
            return (await _context
                    .VersionGroups
                    .FirstOrDefaultAsync(x => x.Id == pokemonForm.IntroducedInVersionGroupId))
                .ToNamedApiResource();
        }

        private async Task<List<Name>> GetNames(EFPokemonForms pokemonForm)
        {
            return (await _context
                    .PokemonFormNames
                    .Include(x => x.LocalLanguage)
                    .Where(x => x.PokemonFormId == pokemonForm.Id && x.PokemonName != null)
                    .ToListAsync())
                .Select(x => new Name(x.PokemonName,
                    x.LocalLanguage.ToNamedApiResource()))
                .ToList();
        }

        private async Task<List<Name>> GetFormNames(EFPokemonForms pokemonForm)
        {
            return (await _context
                    .PokemonFormNames
                    .Include(x => x.LocalLanguage)
                    .Where(x => x.PokemonFormId == pokemonForm.Id)
                    .ToListAsync())
                .Select(x => new Name(x.FormName,
                    x.LocalLanguage.ToNamedApiResource()))
                .ToList();
        }
    }
}