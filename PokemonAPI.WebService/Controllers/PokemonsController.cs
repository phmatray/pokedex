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
    [Route("api/v1/pokemons")]
    public class PokemonsController : ApiController
    {
        private readonly VeekunContext _context;

        public PokemonsController(VeekunContext context)
        {
            _context = context;
        }

        // GET api/v1/pokemons
        // GET api/v1/pokemons?skip=0&take=20
        [HttpGet]
        public async Task<IActionResult> GetAll(int limit = 20, int offset = 0)
        {
            return await base.GetAll(limit, offset, _context.Pokemon, this.Segment());
        }

        // GET api/v1/pokemons/1
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var pokemon = await _context.Pokemon
                    .FirstOrDefaultAsync(x => x.Id == id);

                var results = new Pokemon
                {
                    Id                     = pokemon.Id,
                    Name                   = pokemon.Identifier,
                    BaseExperience         = pokemon.BaseExperience,
                    Height                 = pokemon.Height,
                    IsDefault              = pokemon.IsDefault,
                    Order                  = pokemon.Order,
                    Weight                 = pokemon.Weight,
                    Abilities              = await GetAbilities(pokemon),
                    Forms                  = await GetForms(pokemon),
                    GameIndices            = await GetGameIndices(pokemon),
                    HeldItems              = await GetHeldItems(pokemon),
                    LocationAreaEncounters = GetLocationAreaEncounters(pokemon),
                    Moves                  = await GetMoves(pokemon),
                    Sprites                = GetSprites(pokemon),
                    Species                = await GetSpecies(pokemon),
                    Stats                  = await GetStats(pokemon),
                    Types                  = await GetTypes(pokemon)
                };

                return Ok(results);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // GET api/v1/pokemons/1/encounters
        [HttpGet("{id}/encounters")]
        public async Task<IActionResult> GetEncounters(int id)
        {
            try
            {
                var nonGroupedEncounters = await _context
                    .Encounters
                    .Include(x => x.LocationArea)
                    .Include(x => x.Version)
                    .Where(x => x.PokemonId == id)
                    .ToListAsync();

                var results = nonGroupedEncounters
                    .GroupBy(x => x.LocationArea, (g, elements) =>
                        new LocationAreaEncounter
                        {
                            LocationArea = g.ToNamedApiResource(this.Segment()),
                            VersionDetails = elements
                                .Select(z => new VersionEncounterDetail
                                {
                                    Version = z.Version.ToNamedApiResource(this.Segment()),
                                //MaxChance = 0,
                                //EncounterDetails = elements
                                //    .Select(e => new EncounterResource
                                //    {
                                //        MinLevel = e.MinLevel,
                                //        MaxLevel = e.MaxLevel,
                                //        ConditionValues = ,
                                //        Chance = ,
                                //        Method = 

                                //    })
                                //    .ToList()
                            })
                                .ToList()
                        })
                    .ToList();

                return Ok(results);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


        private async Task<List<PokemonAbility>> GetAbilities(EFPokemon pokemon)
        {
            return (await _context
                    .PokemonAbilities
                    .Include(x => x.Ability)
                    .Where(x => x.PokemonId == pokemon.Id)
                    .ToListAsync())
                .Select(x => new PokemonAbility
                {
                    IsHidden = x.IsHidden,
                    Slot = x.Slot,
                    Ability = x.Ability.ToNamedApiResource(typeof(AbilitiesController).Segment())
                })
                .ToList();
        }

        private async Task<List<NamedAPIResource>> GetForms(EFPokemon pokemon)
        {
            return (await _context
                    .PokemonForms
                    .Where(x => x.PokemonId == pokemon.Id)
                    .ToListAsync())
                .Select(x => x.ToNamedApiResource(typeof(PokemonFormsController).Segment()))
                .ToList();
        }

        private async Task<List<VersionGameIndex>> GetGameIndices(EFPokemon pokemon)
        {
            return (await _context
                    .PokemonGameIndices
                    .Include(x => x.Version)
                    .Where(x => x.PokemonId == pokemon.Id)
                    .ToListAsync())
                .Select(x => new VersionGameIndex
                {
                    GameIndex = x.GameIndex,
                    Version = x.Version.ToNamedApiResource(typeof(VersionsController).Segment())
                })
                .ToList();
        }

        private async Task<List<PokemonHeldItem>> GetHeldItems(EFPokemon pokemon)
        {
            var nonGroupedHeldItems = await _context
                .PokemonItems
                .Include(x => x.Item)
                .Include(x => x.Version)
                .Where(x => x.PokemonId == pokemon.Id)
                .ToListAsync();

            var heldItems = nonGroupedHeldItems
                .GroupBy(x => x.Item, (g, elements) =>
                    new PokemonHeldItem
                    {
                        Item = g.ToNamedApiResource(this.Segment()),
                        VersionDetails = elements
                            .Select(z => new PokemonHeldItemVersion
                            {
                                Rarity = z.Rarity,
                                Version = z.Version?.ToNamedApiResource(this.Segment())
                            })
                            .ToList()
                    })
                .ToList();

            return heldItems;
        }

        private string GetLocationAreaEncounters(EFPokemon pokemon)
        {
            return $"{Constants.SiteUrl}{Constants.BaseUrl}{typeof(PokemonsController).Segment()}/{pokemon.Id}/encounters";
        }

        private async Task<List<PokemonMove>> GetMoves(EFPokemon pokemon)
        {
            var nonGroupedPokemonMoves = await _context
                .PokemonMoves
                .Include(x => x.Move)
                .Include(x => x.VersionGroup)
                .Include(x => x.PokemonMoveMethod)
                .Where(x => x.PokemonId == pokemon.Id)
                .ToListAsync();

            return nonGroupedPokemonMoves
                .GroupBy(x => x.Move, (g, elements) =>
                    new PokemonMove
                    {
                        Move = g.ToNamedApiResource(typeof(MovesController).Segment()),
                        VersionGroupDetails = elements
                            .Select(z => new PokemonMoveVersion
                            {
                                MoveLearnMethod = z.PokemonMoveMethod.ToNamedApiResource(
                                    typeof(MoveLearnMethodsController).Segment()),
                                VersionGroup = z.VersionGroup.ToNamedApiResource(this.Segment()),
                                LevelLearnedAt = z.Level
                            })
                            .ToList()
                    })
                .ToList();
        }

        private PokemonSprites GetSprites(EFPokemon pokemon)
        {
            return null;
            //return new PokemonSprites
            //{
            //    FrontDefault = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/1.png",
            //    FrontShiny = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/shiny/1.png",
            //    FrontFemale = null,
            //    FrontShinyFemale = null,
            //    BackDefault = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/back/1.png",
            //    BackShiny = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/back/shiny/1.png",
            //    BackFemale = null,
            //    BackShinyFemale = null
            //};
        }

        private async Task<NamedAPIResource> GetSpecies(EFPokemon pokemon)
        {
            return (await _context
                    .PokemonSpecies
                    .Where(x => x.Id == pokemon.SpeciesId)
                    .FirstOrDefaultAsync())?
                .ToNamedApiResource(typeof(PokemonSpeciesController).Segment());
        }

        private async Task<List<PokemonStat>> GetStats(EFPokemon pokemon)
        {
            return (await _context
                    .PokemonStats
                    .Include(x => x.Stat)
                    .Where(x => x.PokemonId == pokemon.Id)
                    .ToListAsync())
                .Select(x => new PokemonStat
                {
                    Stat = x.Stat.ToNamedApiResource(typeof(StatsController).Segment()),
                    Effort = x.Effort,
                    BaseStat = x.BaseStat
                })
                .ToList();
        }

        private async Task<List<PokemonType>> GetTypes(EFPokemon pokemon)
        {
            return (await _context
                    .PokemonTypes
                    .Include(x => x.Type)
                    .Where(x => x.PokemonId == pokemon.Id)
                    .ToListAsync())
                .Select(x => new PokemonType
                {
                    Slot = x.Slot,
                    Type = x.Type.ToNamedApiResource(typeof(TypesController).Segment())
                })
                .ToList();
        }
    }
}