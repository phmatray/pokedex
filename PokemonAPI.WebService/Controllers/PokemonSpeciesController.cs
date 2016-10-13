using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PokemonAPI.Models.Rsc;
using PokemonAPI.Models.SourceTypeEnums;
using PokemonAPI.WebService.Controllers.Base;
using PokemonAPI.WebService.Core;
using PokemonAPI.WebService.Models;

namespace PokemonAPI.WebService.Controllers
{
    [Route("api/v1/[controller]")]
    public class PokemonSpeciesController : ApiController<EFPokemonSpecies>
    {
        public PokemonSpeciesController(VeekunContext context)
            : base(context, "PokemonSpecies", "pokemon-species")
        {
        }

        // GET api/v1/pokemonspecies
        // GET api/v1/pokemonspecies?skip=0&take=20
        [HttpGet]
        public async Task<IActionResult> GetAll(int limit = 20, int offset = 0)
        {
            return await base.GetAll(limit, offset);
        }

        // GET api/v1/pokemonspecies/1
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var species = await MainDbSet
                    .FirstOrDefaultAsync(x => x.Id == id);

                var result = new PokemonSpecies
                {
                    Id                   = species.Id,
                    Name                 = species.Identifier,
                    Order                = species.Order,
                    GenderRate           = species.GenderRate,
                    CaptureRate          = species.CaptureRate,
                    BaseHappiness        = species.BaseHappiness,
                    IsBaby               = species.IsBaby,
                    HatchCounter         = species.HatchCounter,
                    HasGenderDifferences = species.HasGenderDifferences,
                    FormsSwitchable      = species.FormsSwitchable,
                    GrowthRate           = await GetGrowthRate(species),
                    PokedexNumbers       = await GetPokedexNumbers(species),
                    EggGroups            = await GetEggGroups(species),
                    Color                = await GetColor(species),
                    Shape                = await GetShape(species),
                    EvolvesFromSpecies   = await GetEvolvesFromSpecies(species),
                    EvolutionChain       = await GetEvolutionChain(species),
                    Habitat              = await GetHabitat(species),
                    Generation           = await GetGeneration(species),
                    Names                = await GetNames(species),
                    PalParkEncounters    = await GetPalParkEncounters(species),
                    FlavorTextEntries    = await GetFlavorTextEntries(species),
                    FormDescriptions     = await GetFormDescriptions(species),
                    Genera               = await GetGenera(species),
                    Varieties            = await GetVarieties(species)
                };

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        private async Task<NamedAPIResource> GetGrowthRate(EFPokemonSpecies species)
        {
            return (await Context
                    .GrowthRates
                    .FirstOrDefaultAsync(x => x.Id == species.GrowthRateId))?
                .ToNamedApiResource();
        }

        private async Task<List<PokemonSpeciesDexEntry>> GetPokedexNumbers(EFPokemonSpecies species)
        {
            return (await Context
                    .PokemonDexNumbers
                    .Include(x => x.Pokedex)
                    .Where(x => x.SpeciesId == species.Id)
                    .ToListAsync())
                .Select(x => x.ToPokemonSpeciesDexEntryResource())
                .ToList();
        }

        private async Task<List<NamedAPIResource>> GetEggGroups(EFPokemonSpecies species)
        {
            return (await Context
                    .PokemonEggGroups
                    .Include(x => x.EggGroup)
                    .Where(x => x.SpeciesId == species.Id)
                    .ToListAsync())
                .Select(x => x.ToNamedApiResource(PokemonEggGroupsSourceType.Species))
                .ToList();
        }

        private async Task<NamedAPIResource> GetColor(EFPokemonSpecies species)
        {
            return (await Context
                    .PokemonColors
                    .FirstOrDefaultAsync(x => x.Id == species.ColorId))?
                .ToNamedApiResource();
        }

        private async Task<NamedAPIResource> GetShape(EFPokemonSpecies species)
        {
            return (await Context
                    .PokemonShapes
                    .FirstOrDefaultAsync(x => x.Id == species.ShapeId))?
                .ToNamedApiResource();
        }

        private async Task<NamedAPIResource> GetEvolvesFromSpecies(EFPokemonSpecies species)
        {
            if (!species.EvolvesFromSpeciesId.HasValue)
                return null;

            return (await Context
                    .PokemonSpecies
                    .FirstOrDefaultAsync(x => x.Id == species.EvolvesFromSpeciesId.Value))?
                .ToNamedApiResource();
        }

        private async Task<APIResource> GetEvolutionChain(EFPokemonSpecies species)
        {
            if (!species.EvolutionChainId.HasValue)
                return null;

            return (await Context
                    .EvolutionChains
                    .FirstOrDefaultAsync(x => x.Id == species.EvolutionChainId.Value))?
                .ToApiResource();
        }

        private async Task<NamedAPIResource> GetHabitat(EFPokemonSpecies species)
        {
            if (!species.HabitatId.HasValue)
                return null;

            return (await Context
                    .PokemonHabitats
                    .FirstOrDefaultAsync(x => x.Id == species.HabitatId.Value))?
                .ToNamedApiResource();
        }

        private async Task<NamedAPIResource> GetGeneration(EFPokemonSpecies species)
        {
            if (!species.GenerationId.HasValue)
                return null;

            return (await Context
                    .Generations
                    .FirstOrDefaultAsync(x => x.Id == species.GenerationId.Value))?
                .ToNamedApiResource();
        }

        private async Task<List<Name>> GetNames(EFPokemonSpecies species)
        {
            return (await Context
                    .PokemonSpeciesNames
                    .Include(x => x.LocalLanguage)
                    .Where(x => x.PokemonSpeciesId == species.Id)
                    .ToListAsync())
                .Select(x => new Name(x.Name, x.LocalLanguage.ToNamedApiResource()))
                .ToList();
        }

        private async Task<List<PalParkEncounterArea>> GetPalParkEncounters(EFPokemonSpecies species)
        {
            return (await Context
                    .PalPark
                    .Include(x => x.Area)
                    .Where(x => x.SpeciesId == species.Id)
                    .ToListAsync())
                .Select(x => x.ToPalParkEncounterAreaResource())
                .ToList();
        }

        private async Task<List<FlavorText>> GetFlavorTextEntries(EFPokemonSpecies species)
        {
            return (await Context
                    .PokemonSpeciesFlavorText
                    .Include(x => x.Language)
                    .Include(x => x.Version)
                    .Where(x => x.SpeciesId == species.Id)
                    .ToListAsync())
                .Select(x => x.ToFlavorTextResource())
                .ToList();
        }

        private async Task<List<Description>> GetFormDescriptions(EFPokemonSpecies species)
        {
            return (await Context
                    .PokemonSpeciesFlavorSummaries
                    .Include(x => x.LocalLanguage)
                    .Where(x => x.PokemonSpeciesId == species.Id)
                    .ToListAsync())
                .Select(x => new Description(x.FlavorSummary, x.LocalLanguage.ToNamedApiResource()))
                .ToList();
        }

        private async Task<List<Genus>> GetGenera(EFPokemonSpecies species)
        {
            return (await Context
                    .PokemonSpeciesNames
                    .Include(x => x.LocalLanguage)
                    .Where(x => x.PokemonSpeciesId == species.Id)
                    .ToListAsync())
                .Select(x => new Genus(x.Genus, x.LocalLanguage.ToNamedApiResource()))
                .ToList();
        }

        private async Task<List<PokemonSpeciesVariety>> GetVarieties(EFPokemonSpecies species)
        {
            return (await Context
                    .Pokemon
                    .Where(x => x.SpeciesId == species.Id)
                    .ToListAsync())
                .Select(x => x.ToPokemonSpeciesVarietyResource())
                .ToList();
        }
    }
}