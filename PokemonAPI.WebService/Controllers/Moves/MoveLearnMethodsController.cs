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
    [Route("api/v1/move-learn-methods")]
    public class MoveLearnMethodsController : ApiController
    {
        private readonly VeekunContext _context;

        public MoveLearnMethodsController(VeekunContext context)
        {
            _context = context;
        }

        // GET api/v1/move-learn-methods
        // GET api/v1/move-learn-methods?skip=0&take=20
        [HttpGet]
        public async Task<IActionResult> GetAll(int limit = 20, int offset = 0)
            => await GetAll(limit, offset, _context.PokemonMoveMethods, GetType());

        // GET api/v1/move-learn-methods/1
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var moveMethod = await _context
                    .PokemonMoveMethods
                    .AsNoTracking()
                    .Include(x => x.PokemonMoveMethodProse).ThenInclude(x => x.LocalLanguage)
                    .Include(x => x.VersionGroupPokemonMoveMethods).ThenInclude(x => x.VersionGroup)
                    .FirstOrDefaultAsync(x => x.Id == id);

                var result = new MoveLearnMethod
                {
                    Id            = moveMethod.Id,
                    Name          = moveMethod.Identifier,
                    Descriptions  = GetDescriptions(moveMethod),
                    Names         = GetNames(moveMethod),
                    VersionGroups = GetVersionGroups(moveMethod)
                };

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        private static List<Description> GetDescriptions(EFPokemonMoveMethods moveMethod)
        {
            return moveMethod
                .PokemonMoveMethodProse
                .Select(x => new Description(x.Description, x.LocalLanguage.ToNamedApiResource()))
                .ToList();
        }

        private static List<Name> GetNames(EFPokemonMoveMethods moveMethod)
        {
            return moveMethod
                .PokemonMoveMethodProse
                .Select(x => new Name(x.Name, x.LocalLanguage.ToNamedApiResource()))
                .ToList();
        }

        private static List<NamedAPIResource> GetVersionGroups(EFPokemonMoveMethods moveMethod)
        {
            return moveMethod
                .VersionGroupPokemonMoveMethods
                .Select(x => x.VersionGroup.ToNamedApiResource())
                .ToList();
        }
    }
}