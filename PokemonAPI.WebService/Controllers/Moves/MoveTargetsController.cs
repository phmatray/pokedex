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
    [Route("api/v1/move-targets")]
    public class MoveTargetsController : ApiController
    {
        private readonly VeekunContext _context;

        public MoveTargetsController(VeekunContext context)
        {
            _context = context;
        }

        // GET api/v1/move-targets
        // GET api/v1/move-targets?skip=0&take=20
        [HttpGet]
        public async Task<IActionResult> GetAll(int limit = 20, int offset = 0)
            => await GetAll(limit, offset, _context.MoveTargets, GetType());

        // GET api/v1/move-targets/1
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var moveTarget = await _context.MoveTargets
                    .Include(x => x.MoveTargetProse).ThenInclude(x => x.LocalLanguage)
                    .Include(x => x.Moves)
                    .FirstOrDefaultAsync(x => x.Id == id);

                var result = new MoveTarget
                {
                    Id           = moveTarget.Id,
                    Name         = moveTarget.Identifier,
                    Descriptions = GetDescriptions(moveTarget),
                    Moves        = GetMoves(moveTarget),
                    Names        = GetNames(moveTarget)
                };

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        private static List<Description> GetDescriptions(EFMoveTargets moveTarget)
        {
            return moveTarget
                .MoveTargetProse
                .Select(x => new Description(x.Description, x.LocalLanguage.ToNamedApiResource()))
                .ToList();
        }

        private static List<NamedAPIResource> GetMoves(EFMoveTargets moveTarget)
        {
            return moveTarget
                .Moves
                .Select(x => x.ToNamedApiResource())
                .ToList();
        }

        private static List<Name> GetNames(EFMoveTargets moveTarget)
        {
            return moveTarget
                .MoveTargetProse
                .Select(x => new Name(x.Name, x.LocalLanguage.ToNamedApiResource()))
                .ToList();
        }
    }
}