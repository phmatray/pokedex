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
    [Route("api/v1/move-battle-styles")]
    public class MoveBattleStylesController : ApiController
    {
        private readonly VeekunContext _context;

        public MoveBattleStylesController(VeekunContext context)
        {
            _context = context;
        }

        // GET api/v1/move-battle-styles
        // GET api/v1/move-battle-styles?skip=0&take=20
        [HttpGet]
        public async Task<IActionResult> GetAll(int limit = 20, int offset = 0)
        {
            return await base.GetAll(limit, offset,
                _context.MoveBattleStyles, this.Segment());
        }

        // GET api/v1/move-battle-styles/1
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var moveBattleStyle = await _context.MoveBattleStyles
                    .FirstOrDefaultAsync(x => x.Id == id);

                var result = new MoveBattleStyle
                {
                    Id    = moveBattleStyle.Id,
                    Name  = moveBattleStyle.Identifier,
                    Names = await GetNames(moveBattleStyle),
                };

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        private async Task<List<Name>> GetNames(EFMoveBattleStyles moveBattleStyle)
        {
            return (await _context
                    .MoveBattleStyleProse
                    .Include(x => x.LocalLanguage)
                    .Where(x => x.MoveBattleStyleId == moveBattleStyle.Id)
                    .ToListAsync())
                .Select(x => new Name(x.Name,
                    x.LocalLanguage.ToNamedApiResource()))
                .ToList();
        }
    }
}