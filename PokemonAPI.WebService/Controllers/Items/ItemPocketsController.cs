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
    [Route("api/v1/item-pockets")]
    public class ItemPocketsController : ApiController
    {
        private readonly VeekunContext _context;

        public ItemPocketsController(VeekunContext context)
        {
            _context = context;
        }

        // GET api/v1/item-pockets
        // GET api/v1/item-pockets?skip=0&take=20
        [HttpGet]
        public async Task<IActionResult> GetAll(int limit = 20, int offset = 0)
            => await GetAll(limit, offset, _context.ItemPockets, GetType());

        // GET api/v1/item-pockets/1
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var itemPocket = await _context.ItemPockets
                    .AsNoTracking()
                    .Include(x => x.ItemCategories)
                    .Include(x => x.ItemPocketNames).ThenInclude(x => x.LocalLanguage)
                    .FirstOrDefaultAsync(x => x.Id == id);

                var result = new ItemPocket
                {
                    Id         = itemPocket.Id,
                    Name       = itemPocket.Identifier,
                    Categories = GetCategories(itemPocket),
                    Names      = GetNames(itemPocket),
                };

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        private static List<NamedAPIResource> GetCategories(EFItemPockets itemPocket)
        {
            return itemPocket
                .ItemCategories
                .Select(x => x.ToNamedApiResource())
                .ToList();
        }

        private static List<Name> GetNames(EFItemPockets itemPocket)
        {
            return itemPocket
                .ItemPocketNames
                .Select(x => new Name(x.Name, x.LocalLanguage.ToNamedApiResource()))
                .ToList();
        }
    }
}