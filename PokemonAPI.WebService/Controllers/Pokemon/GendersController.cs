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
    [Route("api/v1/genders")]
    public class GendersController : ApiController
    {
        private readonly VeekunContext _context;

        public GendersController(VeekunContext context)
        {
            _context = context;
        }

        // GET api/v1/genders
        // GET api/v1/genders?skip=0&take=20
        [HttpGet]
        public async Task<IActionResult> GetAll(int limit = 20, int offset = 0)
        {
            return await base.GetAll(limit, offset,
                _context.Genders, this.Segment());
        }

        // GET api/v1/genders/1
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var gender = await _context.Genders
                    .Include(x => x.PokemonEvolution).ThenInclude(x => x.EvolvedSpecies)
                    .FirstOrDefaultAsync(x => x.Id == id);

                var result = new Gender
                {
                    Id                    = gender.Id,
                    Name                  = gender.Identifier,
                    PokemonSpeciesDetails = await GetPokemonSpeciesDetails(gender),
                    RequiredForEvolution  = GetRequiredForEvolution(gender) 
                };

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        private async Task<List<PokemonSpeciesGender>> GetPokemonSpeciesDetails(EFGenders gender)
        {
            var pokemonSpecies = new List<EFPokemonSpecies>();
            switch (gender.Identifier)
            {
                case "female":
                    pokemonSpecies = await _context.PokemonSpecies
                        .Where(x => x.GenderRate >= 1 && x.GenderRate <= 8)
                        .ToListAsync();
                    break;
                case "male":
                    pokemonSpecies = await _context.PokemonSpecies
                        .Where(x => x.GenderRate >= 0 && x.GenderRate <= 7)
                        .ToListAsync();
                    break;
                case "genderless":
                    pokemonSpecies = await _context.PokemonSpecies
                        .Where(x => x.GenderRate == -1)
                        .ToListAsync();
                    break;
            }

            return pokemonSpecies
                .Select(x => new PokemonSpeciesGender
                {
                    Rate = x.GenderRate,
                    PokemonSpecies = x.ToNamedApiResource()
                })
                .ToList();
        }

        private List<NamedAPIResource> GetRequiredForEvolution(EFGenders gender)
        {
            return gender
                .PokemonEvolution
                .Select(x => x.EvolvedSpecies.ToNamedApiResource())
                .ToList();
        }
    }
}