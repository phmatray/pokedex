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
    [Route("api/v1/item-categories")]
    public class ItemCategoriesController : ApiController
    {
        private readonly VeekunContext _context;

        public ItemCategoriesController(VeekunContext context)
        {
            _context = context;
        }

        // GET api/v1/item-categories
        // GET api/v1/item-categories?skip=0&take=20
        [HttpGet]
        public async Task<IActionResult> GetAll(int limit = 20, int offset = 0)
            => await GetAll(limit, offset, _context.ItemCategories, GetType());

        // GET api/v1/item-categories/1
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var itemCategory = await _context.ItemCategories
                    .Include(x => x.Items)
                    .Include(x => x.ItemCategoryProse).ThenInclude(x => x.LocalLanguage)
                    .Include(x => x.Pocket)
                    .FirstOrDefaultAsync(x => x.Id == id);

                var result = new ItemCategory
                {
                    Id     = itemCategory.Id,
                    Name   = itemCategory.Identifier,
                    Items  = GetItems(itemCategory),
                    Names  = GetNames(itemCategory),
                    Pocket = GetPocket(itemCategory)
                };

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        private static List<NamedAPIResource> GetItems(EFItemCategories itemCategory)
        {
            return itemCategory
                .Items
                .Select(x => x.ToNamedApiResource())
                .ToList();
        }

        private static List<Name> GetNames(EFItemCategories itemCategory)
        {
            return itemCategory
                .ItemCategoryProse
                .Select(x => new Name(x.Name, x.LocalLanguage.ToNamedApiResource()))
                .ToList();
        }

        private static NamedAPIResource GetPocket(EFItemCategories itemCategory)
        {
            return itemCategory
                .Pocket?
                .ToNamedApiResource();
        }
    }
}