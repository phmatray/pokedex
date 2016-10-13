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
    public class PokemonsController : ApiController<EFPokemon>
    {
        public PokemonsController(VeekunContext context)
            : base(context, "Pokemon", "pokemons")
        {
        }

        // GET api/v1/pokemons
        // GET api/v1/pokemons?skip=0&take=20
        [HttpGet]
        public async Task<IActionResult> GetAll(int limit = 20, int offset = 0)
        {
            return await base.GetAll(limit, offset);
        }

        // GET api/v1/pokemons/1
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var pokemon = await MainDbSet
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
                var nonGroupedEncounters = await Context
                    .Encounters
                    .Include(x => x.LocationArea)
                    .Include(x => x.Version)
                    .Where(x => x.PokemonId == id)
                    .ToListAsync();

                var results = nonGroupedEncounters
                    .GroupBy(x => x.LocationArea, (g, elements) =>
                        new LocationAreaEncounter
                        {
                            LocationArea = g.ToNamedApiResource(),
                            VersionDetails = elements
                                .Select(z => new VersionEncounterDetail
                                {
                                    Version = z.Version.ToNamedApiResource(),
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
            return (await Context
                    .PokemonAbilities
                    .Include(x => x.Ability)
                    .Where(x => x.PokemonId == pokemon.Id)
                    .ToListAsync())
                .Select(x => new PokemonAbility
                {
                    IsHidden = x.IsHidden,
                    Slot = x.Slot,
                    Ability = x.Ability.ToNamedApiResource()
                })
                .ToList();
        }

        private async Task<List<NamedAPIResource>> GetForms(EFPokemon pokemon)
        {
            return (await Context
                    .PokemonForms
                    .Where(x => x.PokemonId == pokemon.Id)
                    .ToListAsync())
                .Select(x => x.ToNamedApiResource())
                .ToList();
        }

        private async Task<List<VersionGameIndex>> GetGameIndices(EFPokemon pokemon)
        {
            return (await Context
                    .PokemonGameIndices
                    .Include(x => x.Version)
                    .Where(x => x.PokemonId == pokemon.Id)
                    .ToListAsync())
                .Select(x => new VersionGameIndex
                {
                    GameIndex = x.GameIndex,
                    Version = x.Version.ToNamedApiResource()
                })
                .ToList();
        }

        private async Task<List<PokemonHeldItem>> GetHeldItems(EFPokemon pokemon)
        {
            var nonGroupedHeldItems = await Context
                .PokemonItems
                .Include(x => x.Item)
                .Include(x => x.Version)
                .Where(x => x.PokemonId == pokemon.Id)
                .ToListAsync();

            var heldItems = nonGroupedHeldItems
                .GroupBy(x => x.Item, (g, elements) =>
                    new PokemonHeldItem
                    {
                        Item = g.ToNamedApiResource(),
                        VersionDetails = elements
                            .Select(z => new PokemonHeldItemVersion
                            {
                                Rarity = z.Rarity,
                                Version = z.Version?.ToNamedApiResource()
                            })
                            .ToList()
                    })
                .ToList();

            return heldItems;
        }

        private string GetLocationAreaEncounters(EFPokemon pokemon)
        {
            return $"{Constants.SiteUrl}{Constants.BaseUrl}pokemons/{pokemon.Id}/encounters";
        }

        private async Task<List<PokemonMove>> GetMoves(EFPokemon pokemon)
        {
            var nonGroupedPokemonMoves = await Context
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
                        Move = g.ToNamedApiResource(),
                        VersionGroupDetails = elements
                            .Select(z => new PokemonMoveVersion
                            {
                                MoveLearnMethod = z.PokemonMoveMethod.ToNamedApiResource(),
                                VersionGroup = z.VersionGroup.ToNamedApiResource(),
                                LevelLearnedAt = z.Level
                            })
                            .ToList()
                    })
                .ToList();
        }

        private PokemonSprites GetSprites(EFPokemon pokemon)
        {
            return new PokemonSprites
            {
                FrontDefault = null,
                FrontShiny = null,
                FrontFemale = null,
                FrontShinyFemale = null,
                BackDefault = null,
                BackShiny = null,
                BackFemale = null,
                BackShinyFemale = null
            };
        }

        private async Task<NamedAPIResource> GetSpecies(EFPokemon pokemon)
        {
            return (await Context
                    .PokemonSpecies
                    .Where(x => x.Id == pokemon.SpeciesId)
                    .FirstOrDefaultAsync())?
                .ToNamedApiResource();
        }

        private async Task<List<PokemonStat>> GetStats(EFPokemon pokemon)
        {
            return (await Context
                    .PokemonStats
                    .Include(x => x.Stat)
                    .Where(x => x.PokemonId == pokemon.Id)
                    .ToListAsync())
                .Select(x => new PokemonStat
                {
                    Stat = x.Stat.ToNamedApiResource(),
                    Effort = x.Effort,
                    BaseStat = x.BaseStat
                })
                .ToList();
        }

        private async Task<List<PokemonType>> GetTypes(EFPokemon pokemon)
        {
            return (await Context
                    .PokemonTypes
                    .Include(x => x.Type)
                    .Where(x => x.PokemonId == pokemon.Id)
                    .ToListAsync())
                .Select(x => new PokemonType
                {
                    Slot = x.Slot,
                    Type = x.Type.ToNamedApiResource()
                })
                .ToList();
        }
    }
}