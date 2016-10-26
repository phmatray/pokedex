using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Controllers._Base;
using PokemonAPI.WebService.Core;
using PokemonAPI.WebService.Models;

namespace PokemonAPI.WebService.Controllers
{
    [Route("api/v1/items")]
    public class ItemsController : ApiController
    {
        private readonly VeekunContext _context;

        public ItemsController(VeekunContext context)
        {
            _context = context;
        }

        // GET api/v1/items
        // GET api/v1/items?skip=0&take=20
        [HttpGet]
        public async Task<IActionResult> GetAll(int limit = 20, int offset = 0)
            => await GetAll(limit, offset, _context.Items, GetType());

        // GET api/v1/items/1
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var item = await _context.Items
                    .AsNoTracking()
                    .Include(x => x.FlingEffect)
                    .Include(x => x.ItemFlagMap).ThenInclude(x => x.ItemFlag)
                    .Include(x => x.Category).ThenInclude(x => x.Items)
                    .Include(x => x.Category).ThenInclude(x => x.ItemCategoryProse).ThenInclude(x => x.LocalLanguage)
                    .Include(x => x.Category).ThenInclude(x => x.Pocket)
                    .Include(x => x.ItemProse).ThenInclude(x => x.LocalLanguage)
                    .Include(x => x.ItemFlavorText).ThenInclude(x => x.Language)
                    .Include(x => x.ItemFlavorText).ThenInclude(x => x.VersionGroup)
                    .Include(x => x.ItemGameIndices).ThenInclude(x => x.Generation)
                    .Include(x => x.ItemNames).ThenInclude(x => x.LocalLanguage)
                    .Include(x => x.PokemonItems).ThenInclude(x => x.Pokemon)
                    .Include(x => x.PokemonItems).ThenInclude(x => x.Version)
                    .Include(x => x.Machines).ThenInclude(x => x.VersionGroup)
                    .FirstOrDefaultAsync(x => x.Id == id);

                var result = new Item
                {
                    Id                = item.Id,
                    Name              = item.Identifier,
                    Cost              = item.Cost,
                    FlingPower        = item.FlingPower,
                    FlingEffect       = GetFlingEffect(item),
                    Attributes        = GetAttributes(item),
                    Category          = GetCategory(item),
                    EffectEntries     = GetEffectEntries(item),
                    FlavorTextEntries = GetFlavorTextEntries(item),
                    GameIndices       = GetGameIndices(item),
                    Names             = GetNames(item),
                    Sprites           = null, //GetSprites(item),
                    HeldByPokemon     = GetHeldByPokemon(item),
                    BabyTriggerFor    = GetBabyTriggerFor(item),
                    Machines          = GetMachines(item)
                };

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        private static NamedAPIResource GetFlingEffect(EFItems item)
        {
            return item
                .FlingEffect?
                .ToNamedApiResource();
        }

        private static List<NamedAPIResource> GetAttributes(EFItems item)
        {
            return item
                .ItemFlagMap
                .Select(x => x.ItemFlag.ToNamedApiResource())
                .ToList();
        }

        private static NamedAPIResource GetCategory(EFItems item)
        {
            return item
                .Category?
                .ToNamedApiResource();
        }

        private static List<VerboseEffect> GetEffectEntries(EFItems item)
        {
            return item
                .ItemProse
                .Select(x => new VerboseEffect(x.Effect, x.ShortEffect, x.LocalLanguage.ToNamedApiResource()))
                .ToList();
        }

        private static List<VersionGroupFlavorText> GetFlavorTextEntries(EFItems item)
        {
            return item
                .ItemFlavorText
                .Select(x => new VersionGroupFlavorText(x.FlavorText,
                    x.Language.ToNamedApiResource(), x.VersionGroup.ToNamedApiResource()))
                .ToList();
        }

        private static List<GenerationGameIndex> GetGameIndices(EFItems item)
        {
            return item
                .ItemGameIndices
                .Select(x => new GenerationGameIndex(x.GameIndex, x.Generation.ToNamedApiResource()))
                .ToList();
        }

        private static List<Name> GetNames(EFItems item)
        {
            return item
                .ItemNames
                .Select(x => new Name(x.Name, x.LocalLanguage.ToNamedApiResource()))
                .ToList();
        }

        //private static ItemSprites GetSprites(EFItems item)
        //{
        //    return new ItemSprites
        //    {
        //        Default = null //TODO: Get Sprites
        //    };
        //}

        private static List<ItemHolderPokemon> GetHeldByPokemon(EFItems item)
        {
            return item
                .PokemonItems
                .GroupBy(x => x.PokemonId, (key, group) =>
                {
                    var efPokemonItemses = group as IList<EFPokemonItems> ?? group.ToList();

                    return new ItemHolderPokemon
                    {
                        Pokemon = efPokemonItemses
                            .FirstOrDefault()?
                            .Pokemon
                            .ToNamedApiResource(),
                        VersionDetails = efPokemonItemses
                            .Select(g => new ItemHolderPokemonVersionDetail
                            {
                                Rarity = g.Rarity,
                                Version = g.Version?.ToNamedApiResource()
                            })
                            .ToList()
                    };
                })
                .ToList();
        }

        private APIResource GetBabyTriggerFor(EFItems item)
        {
            return _context
                .EvolutionChains
                .SingleOrDefault(x => x.BabyTriggerItemId == item.Id)?
                .ToApiResource<EvolutionChainsController>();
        }

        private static List<MachineVersionDetail> GetMachines(EFItems item)
        {
            return item
                .Machines
                .Select(x => new MachineVersionDetail(x.ToApiResource(), x.VersionGroup.ToNamedApiResource()))
                .ToList();
        }
    }
}