using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Controllers.Base;
using PokemonAPI.WebService.Core;
using Microsoft.EntityFrameworkCore;
using PokemonAPI.WebService.Models;
using System.Linq;

namespace PokemonAPI.WebService.Controllers
{
    [Route("api/v1/item-attributes")]
    public class ItemAttributesController : ApiController
    {
        private readonly VeekunContext _context;

        public ItemAttributesController(VeekunContext context)
        {
            _context = context;
        }

        // GET api/v1/item-attributes
        // GET api/v1/item-attributes?skip=0&take=20
        [HttpGet]
        public async Task<IActionResult> GetAll(int limit = 20, int offset = 0)
        {
            return await base.GetAll(limit, offset,
                _context.ItemFlags, this.Segment());
        }

        // GET api/v1/item-attributes/1
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var itemAttribute = await _context.ItemFlags
                    .Include(x => x.ItemFlagMap).ThenInclude(x => x.Item)
                    .Include(x => x.ItemFlagProse).ThenInclude(x => x.LocalLanguage)
                    .FirstOrDefaultAsync(x => x.Id == id);

                var result = new ItemAttribute
                {
                    Id           = itemAttribute.Id,
                    Name         = itemAttribute.Identifier,
                    Items        = GetItems(itemAttribute),
                    Names        = GetNames(itemAttribute),
                    Descriptions = GetDescriptions(itemAttribute)
                };

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        private List<NamedAPIResource> GetItems(EFItemFlags itemAttribute)
        {
            return itemAttribute
                .ItemFlagMap
                .Select(x => x.Item.ToNamedApiResource())
                .ToList();
        }

        private List<Name> GetNames(EFItemFlags itemAttribute)
        {
            return itemAttribute
                .ItemFlagProse
                .Where(x => x.Name != null)
                .Select(x => new Name(x.Name, x.LocalLanguage.ToNamedApiResource()))
                .ToList();
        }

        private List<Description> GetDescriptions(EFItemFlags itemAttribute)
        {
            return itemAttribute
                .ItemFlagProse
                .Where(x => x.Description != null)
                .Select(x => new Description(x.Description, x.LocalLanguage.ToNamedApiResource()))
                .ToList();
        }
    }
}