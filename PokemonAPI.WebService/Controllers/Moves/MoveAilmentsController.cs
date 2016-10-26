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
    [Route("api/v1/move-ailments")]
    public class MoveAilmentsController : ApiController
    {
        private readonly VeekunContext _context;

        public MoveAilmentsController(VeekunContext context)
        {
            _context = context;
        }

        // GET api/v1/move-ailments
        // GET api/v1/move-ailments?skip=0&take=20
        [HttpGet]
        public async Task<IActionResult> GetAll(int limit = 20, int offset = 0) 
            => await GetAll(limit, offset, _context.MoveMetaAilments, GetType());

        // GET api/v1/move-ailments/1
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var ailment = await _context
                    .MoveMetaAilments
                    .AsNoTracking()
                    .Include(x => x.MoveMeta).ThenInclude(x => x.Move)
                    .Include(x => x.MoveMetaAilmentNames).ThenInclude(x => x.LocalLanguage)
                    .FirstOrDefaultAsync(x => x.Id == id);

                var result = new MoveAilment
                {
                    Id    = ailment.Id,
                    Name  = ailment.Identifier,
                    Moves = GetMoves(ailment),
                    Names = GetNames(ailment)
                };

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        private static List<NamedAPIResource> GetMoves(EFMoveMetaAilments ailment)
        {
            return ailment
                .MoveMeta
                .Select(x => x.Move.ToNamedApiResource())
                .ToList();
        }

        private static List<Name> GetNames(EFMoveMetaAilments ailment)
        {
            return ailment
                .MoveMetaAilmentNames
                .Select(x => new Name(x.Name, x.LocalLanguage.ToNamedApiResource()))
                .ToList();
        }
    }
}