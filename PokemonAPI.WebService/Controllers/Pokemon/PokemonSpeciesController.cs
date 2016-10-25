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
            => await GetAll(limit, offset, _context.PokemonSpecies, GetType());

        // GET api/v1/pokemonspecies/1
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var species = await _context.PokemonSpecies
                    .Include(x => x.GrowthRate)
                    .Include(x => x.PokemonDexNumbers).ThenInclude(x => x.Pokedex)
                    .Include(x => x.PokemonEggGroups).ThenInclude(x => x.EggGroup)
                    .Include(x => x.Color)
                    .Include(x => x.Shape)
                    .Include(x => x.EvolvesFromSpecies)
                    .Include(x => x.EvolutionChain)
                    .Include(x => x.Habitat)
                    .Include(x => x.Generation)
                    .Include(x => x.PokemonSpeciesNames).ThenInclude(x => x.LocalLanguage)
                    .Include(x => x.PalPark).ThenInclude(x => x.Area)
                    .Include(x => x.PokemonSpeciesFlavorText).ThenInclude(x => x.Language)
                    .Include(x => x.PokemonSpeciesFlavorText).ThenInclude(x => x.Version)
                    .Include(x => x.PokemonSpeciesFlavorSummaries).ThenInclude(x => x.LocalLanguage)
                    .Include(x => x.PokemonSpeciesNames).ThenInclude(x => x.LocalLanguage)
                    .Include(x => x.Pokemon)
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
                    GrowthRate           = GetGrowthRate(species),
                    PokedexNumbers       = GetPokedexNumbers(species),
                    EggGroups            = GetEggGroups(species),
                    Color                = GetColor(species),
                    Shape                = GetShape(species),
                    EvolvesFromSpecies   = GetEvolvesFromSpecies(species),
                    EvolutionChain       = GetEvolutionChain(species),
                    Habitat              = GetHabitat(species),
                    Generation           = GetGeneration(species),
                    Names                = GetNames(species),
                    PalParkEncounter     = GetPalParkEncounter(species),
                    FlavorTextEntries    = GetFlavorTextEntries(species),
                    FormDescriptions     = GetFormDescriptions(species),
                    Genera               = GetGenera(species),
                    Varieties            = GetVarieties(species)
                };

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        private static NamedAPIResource GetGrowthRate(EFPokemonSpecies species)
        {
            return species
                .GrowthRate
                .ToNamedApiResource();
        }

        private static List<PokemonSpeciesDexEntry> GetPokedexNumbers(EFPokemonSpecies species)
        {
            return species
                .PokemonDexNumbers
                .Select(x => new PokemonSpeciesDexEntry(x.PokedexNumber, x.Pokedex.ToNamedApiResource()))
                .ToList();
        }

        private static List<NamedAPIResource> GetEggGroups(EFPokemonSpecies species)
        {
            return species
                .PokemonEggGroups
                .Select(x =>
                    new NamedAPIResource
                    (
                        x.EggGroup.Identifier,
                        typeof(EggGroupsController).RscUrl(x.EggGroupId)
                    ))
                .ToList();
        }

        private static NamedAPIResource GetColor(EFPokemonSpecies species)
        {
            return species
                .Color?
                .ToNamedApiResource();
        }

        private static NamedAPIResource GetShape(EFPokemonSpecies species)
        {
            return species
                .Shape?
                .ToNamedApiResource();
        }

        private static NamedAPIResource GetEvolvesFromSpecies(EFPokemonSpecies species)
        {
            return species
                .EvolvesFromSpecies?
                .ToNamedApiResource();
        }

        private static APIResource GetEvolutionChain(EFPokemonSpecies species)
        {
            return species
                .EvolutionChain?
                .ToApiResource(typeof(EvolutionChainsController));
        }

        private static NamedAPIResource GetHabitat(EFPokemonSpecies species)
        {
            return species
                .Habitat?
                .ToNamedApiResource();
        }

        private static NamedAPIResource GetGeneration(EFPokemonSpecies species)
        {
            return species
                .Generation?
                .ToNamedApiResource();
        }

        private static List<Name> GetNames(EFPokemonSpecies species)
        {
            return species
                .PokemonSpeciesNames
                .Select(x => new Name(x.Name, x.LocalLanguage.ToNamedApiResource()))
                .ToList();
        }

        private static PalParkEncounterArea GetPalParkEncounter(EFPokemonSpecies species)
        {
            var palPark = species.PalPark;
            return new PalParkEncounterArea(palPark.BaseScore, palPark.Rate, palPark.Area.ToNamedApiResource());
        }

        private static List<FlavorTextVersion> GetFlavorTextEntries(EFPokemonSpecies species)
        {
            return species
                .PokemonSpeciesFlavorText
                .Select(x => new FlavorTextVersion(x.FlavorText,
                    x.Language.ToNamedApiResource(), x.Version.ToNamedApiResource()))
                .ToList();
        }

        private static List<Description> GetFormDescriptions(EFPokemonSpecies species)
        {
            return species
                .PokemonSpeciesFlavorSummaries
                .Select(x => new Description(x.FlavorSummary, x.LocalLanguage.ToNamedApiResource()))
                .ToList();
        }

        private static List<Genus> GetGenera(EFPokemonSpecies species)
        {
            return species
                .PokemonSpeciesNames
                .Select(x => new Genus(x.Genus, x.LocalLanguage.ToNamedApiResource()))
                .ToList();
        }

        private static List<PokemonSpeciesVariety> GetVarieties(EFPokemonSpecies species)
        {
            return species
                .Pokemon
                .Select(x => new PokemonSpeciesVariety(x.IsDefault, x.Species.ToNamedApiResource()))
                .ToList();
        }
    }
}