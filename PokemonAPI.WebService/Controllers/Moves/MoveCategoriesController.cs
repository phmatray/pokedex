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
    [Route("api/v1/move-categories")]
    public class MoveCategoriesController : ApiController
    {
        private readonly VeekunContext _context;

        public MoveCategoriesController(VeekunContext context)
        {
            _context = context;
        }

        // GET api/v1/move-categories
        // GET api/v1/move-categories?skip=0&take=20
        [HttpGet]
        public async Task<IActionResult> GetAll(int limit = 20, int offset = 0)
            => await GetAll(limit, offset, _context.MoveMetaCategories, GetType());

        // GET api/v1/move-categories/1
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var category = await _context
                    .MoveMetaCategories
                    .Include(x => x.MoveMeta).ThenInclude(x => x.Move)
                    .Include(x => x.MoveMetaCategoryProse).ThenInclude(x => x.LocalLanguage)
                    .FirstOrDefaultAsync(x => x.Id == id);

                var result = new MoveCategory
                {
                    Id           = category.Id,
                    Name         = category.Identifier,
                    Moves        = GetMoves(category),
                    Descriptions = GetDescriptions(category)
                };

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        private static List<NamedAPIResource> GetMoves(EFMoveMetaCategories category)
        {
            return category
                .MoveMeta
                .Select(x => x.Move.ToNamedApiResource())
                .ToList();
        }

        private static List<Description> GetDescriptions(EFMoveMetaCategories category)
        {
            return category
                .MoveMetaCategoryProse
                .Select(x => new Description(x.Description, x.LocalLanguage.ToNamedApiResource()))
                .ToList();
        }
    }
}