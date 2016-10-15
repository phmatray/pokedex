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
    [Route("api/v1/pokemon-species")]
    public class PokemonSpeciesController : ApiController
    {
        private readonly VeekunContext _context;

        public PokemonSpeciesController(VeekunContext context)
        {
            _context = context;
        }

        // GET api/v1/pokemonspecies
        // GET api/v1/pokemonspecies?skip=0&take=20
        [HttpGet]
        public async Task<IActionResult> GetAll(int limit = 20, int offset = 0)
        {
            return await base.GetAll(limit, offset, _context.PokemonSpecies, this.Segment());
        }

        // GET api/v1/pokemonspecies/1
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var species = await _context.PokemonSpecies
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
            return (await _context
                    .GrowthRates
                    .FirstOrDefaultAsync(x => x.Id == species.GrowthRateId))?
                .ToNamedApiResource(this.Segment());
        }

        private async Task<List<PokemonSpeciesDexEntry>> GetPokedexNumbers(EFPokemonSpecies species)
        {
            return (await _context
                    .PokemonDexNumbers
                    .Include(x => x.Pokedex)
                    .Where(x => x.SpeciesId == species.Id)
                    .ToListAsync())
                .Select(x => new PokemonSpeciesDexEntry(x.PokedexNumber, x.Pokedex.ToNamedApiResource(this.Segment())))
                .ToList();
        }

        private async Task<List<NamedAPIResource>> GetEggGroups(EFPokemonSpecies species)
        {
            return (await _context
                    .PokemonEggGroups
                    .Include(x => x.EggGroup)
                    .Where(x => x.SpeciesId == species.Id)
                    .ToListAsync())
                .Select(x =>
                    new NamedAPIResource
                    (
                        $"{Constants.SiteUrl}{Constants.BaseUrl}egggroups/{x.EggGroupId}/",
                        x.EggGroup.Identifier
                    ))
                .ToList();
        }

        private async Task<NamedAPIResource> GetColor(EFPokemonSpecies species)
        {
            return (await _context
                    .PokemonColors
                    .FirstOrDefaultAsync(x => x.Id == species.ColorId))?
                .ToNamedApiResource(this.Segment());
        }

        private async Task<NamedAPIResource> GetShape(EFPokemonSpecies species)
        {
            return (await _context
                    .PokemonShapes
                    .FirstOrDefaultAsync(x => x.Id == species.ShapeId))?
                .ToNamedApiResource(this.Segment());
        }

        private async Task<NamedAPIResource> GetEvolvesFromSpecies(EFPokemonSpecies species)
        {
            if (!species.EvolvesFromSpeciesId.HasValue)
                return null;

            return (await _context
                    .PokemonSpecies
                    .FirstOrDefaultAsync(x => x.Id == species.EvolvesFromSpeciesId.Value))?
                .ToNamedApiResource(this.Segment());
        }

        private async Task<APIResource> GetEvolutionChain(EFPokemonSpecies species)
        {
            if (!species.EvolutionChainId.HasValue)
                return null;

            return (await _context
                    .EvolutionChains
                    .FirstOrDefaultAsync(x => x.Id == species.EvolutionChainId.Value))?
                .ToApiResource(this.Segment());
        }

        private async Task<NamedAPIResource> GetHabitat(EFPokemonSpecies species)
        {
            if (!species.HabitatId.HasValue)
                return null;

            return (await _context
                    .PokemonHabitats
                    .FirstOrDefaultAsync(x => x.Id == species.HabitatId.Value))?
                .ToNamedApiResource(this.Segment());
        }

        private async Task<NamedAPIResource> GetGeneration(EFPokemonSpecies species)
        {
            if (!species.GenerationId.HasValue)
                return null;

            return (await _context
                    .Generations
                    .FirstOrDefaultAsync(x => x.Id == species.GenerationId.Value))?
                .ToNamedApiResource(this.Segment());
        }

        private async Task<List<Name>> GetNames(EFPokemonSpecies species)
        {
            return (await _context
                    .PokemonSpeciesNames
                    .Include(x => x.LocalLanguage)
                    .Where(x => x.PokemonSpeciesId == species.Id)
                    .ToListAsync())
                .Select(x => new Name(x.Name, x.LocalLanguage.ToNamedApiResource(this.Segment())))
                .ToList();
        }

        private async Task<List<PalParkEncounterArea>> GetPalParkEncounters(EFPokemonSpecies species)
        {
            return (await _context
                    .PalPark
                    .Include(x => x.Area)
                    .Where(x => x.SpeciesId == species.Id)
                    .ToListAsync())
                .Select(x => new PalParkEncounterArea(x.BaseScore, x.Rate, x.Area.ToNamedApiResource(this.Segment())))
                .ToList();
        }

        private async Task<List<FlavorText>> GetFlavorTextEntries(EFPokemonSpecies species)
        {
            return (await _context
                    .PokemonSpeciesFlavorText
                    .Include(x => x.Language)
                    .Include(x => x.Version)
                    .Where(x => x.SpeciesId == species.Id)
                    .ToListAsync())
                .Select(x => new FlavorText(x.FlavorText, x.Version.ToNamedApiResource(this.Segment()), x.Language.ToNamedApiResource(this.Segment())))
                .ToList();
        }

        private async Task<List<Description>> GetFormDescriptions(EFPokemonSpecies species)
        {
            return (await _context
                    .PokemonSpeciesFlavorSummaries
                    .Include(x => x.LocalLanguage)
                    .Where(x => x.PokemonSpeciesId == species.Id)
                    .ToListAsync())
                .Select(x => new Description(x.FlavorSummary, x.LocalLanguage.ToNamedApiResource(this.Segment())))
                .ToList();
        }

        private async Task<List<Genus>> GetGenera(EFPokemonSpecies species)
        {
            return (await _context
                    .PokemonSpeciesNames
                    .Include(x => x.LocalLanguage)
                    .Where(x => x.PokemonSpeciesId == species.Id)
                    .ToListAsync())
                .Select(x => new Genus(x.Genus, x.LocalLanguage.ToNamedApiResource(this.Segment())))
                .ToList();
        }

        private async Task<List<PokemonSpeciesVariety>> GetVarieties(EFPokemonSpecies species)
        {
            return (await _context
                    .Pokemon
                    .Where(x => x.SpeciesId == species.Id)
                    .ToListAsync())
                .Select(x => new PokemonSpeciesVariety(x.IsDefault, x.Species.ToNamedApiResource(this.Segment())))
                .ToList();
        }
    }
}