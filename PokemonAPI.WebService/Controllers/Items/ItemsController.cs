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
        {
            return await base.GetAll(limit, offset,
                _context.Items, this.Segment());
        }

        // GET api/v1/items/1
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var item = await _context.Items
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
                    Sprites           = GetSprites(item),
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

        private NamedAPIResource GetFlingEffect(EFItems item)
        {
            if (item.FlingEffectId != null)
            {
                return new NamedAPIResource
                (
                    item.FlingEffect.Identifier,
                    typeof(ItemFlingEffectsController).RscUrl(item.FlingEffectId.Value)
                );
            }

            return null;
        }

        private List<NamedAPIResource> GetAttributes(EFItems item)
        {
            return item
                .ItemFlagMap
                .Select(x => x.ItemFlag.ToNamedApiResource<ItemAttributesController>())
                .ToList();
        }

        private NamedAPIResource GetCategory(EFItems item)
        {
            return item.Category
                .ToNamedApiResource<ItemCategoriesController>();

            //var cat = item.Category;

            //return new ItemCategory
            //{
            //    Id = cat.Id,
            //    Name = cat.Identifier,
            //    Items = cat.Items.Select(x => x.ToNamedApiResource<ItemsController>()).ToList(),
            //    Names = cat
            //        .ItemCategoryProse
            //        .Select(x => new Name
            //        (
            //            x.Name,
            //            x.LocalLanguage.ToNamedApiResource<LanguagesController>()
            //        ))
            //        .ToList(),
            //    Pocket = cat.Pocket.ToNamedApiResource<ItemPocketsController>()
            //};
        }

        private List<VerboseEffect> GetEffectEntries(EFItems item)
        {
            return item
                .ItemProse
                .Select(x => new VerboseEffect
                {
                    Effect = x.Effect,
                    ShortEffect = x.ShortEffect,
                    Language = x.LocalLanguage.ToNamedApiResource<LanguagesController>()
                })
                .ToList();
        }

        private List<VersionGroupFlavorText> GetFlavorTextEntries(EFItems item)
        {
            return item
                .ItemFlavorText
                .Select(x => new VersionGroupFlavorText
                {
                    Text = x.FlavorText,
                    Language = x.Language.ToNamedApiResource<LanguagesController>(),
                    VersionGroup = x.VersionGroup.ToNamedApiResource<VersionGroupsController>()
                })
                .ToList();
        }

        private List<GenerationGameIndex> GetGameIndices(EFItems item)
        {
            return item
                .ItemGameIndices
                .Select(x => new GenerationGameIndex
                {
                    GameIndex = x.GameIndex,
                    Generation = x.Generation.ToNamedApiResource<GenerationsController>()
                })
                .ToList();
        }

        private List<Name> GetNames(EFItems item)
        {
            return item
                .ItemNames
                .Select(x => new Name
                (
                    x.Name,
                    x.LocalLanguage.ToNamedApiResource<LanguagesController>()
                ))
                .ToList();
        }

        private ItemSprites GetSprites(EFItems item)
        {
            return new ItemSprites
            {
                Default = null //TODO: Get Sprites
            };
        }

        private List<ItemHolderPokemon> GetHeldByPokemon(EFItems item)
        {
            return item
                .PokemonItems
                .GroupBy(x => x.PokemonId, (key, group) => new ItemHolderPokemon
                {
                    Pokemon = group
                        .FirstOrDefault()?
                        .Pokemon
                        .ToNamedApiResource<PokemonsController>(),
                    VersionDetails = group
                        .Select(g => new ItemHolderPokemonVersionDetail
                        {
                            Rarity = g.Rarity,
                            Version = g.Version.ToNamedApiResource<VersionsController>()
                        })
                        .ToList()
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

        private List<MachineVersionDetail> GetMachines(EFItems item)
        {
            return item
                .Machines
                .Select(x => new MachineVersionDetail
                {
                    Machine = new APIResource(
                        $"{Constants.SiteUrl}{Constants.BaseUrl}{typeof(MachinesController).Segment()}/{x.MachineNumber}/{x.VersionGroupId}/"),
                    VersionGroup = x.VersionGroup.ToNamedApiResource<VersionGroupsController>()
                })
                .ToList();
        }
    }
}