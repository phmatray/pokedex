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
    [Route("api/v1/move-damage-classes")]
    public class MoveDamageClassesController : ApiController
    {
        private readonly VeekunContext _context;

        public MoveDamageClassesController(VeekunContext context)
        {
            _context = context;
        }

        // GET api/v1/move-damage-classes
        // GET api/v1/move-damage-classes?skip=0&take=20
        [HttpGet]
        public async Task<IActionResult> GetAll(int limit = 20, int offset = 0)
        {
            return await base.GetAll(limit, offset,
                _context.MoveDamageClasses, this.Segment());
        }

        // GET api/v1/move-damage-classes/1
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var moveDamageClass = await _context.MoveDamageClasses
                    .Include(x => x.MoveDamageClassProse).ThenInclude(x => x.LocalLanguage)
                    .Include(x => x.Moves)
                    .FirstOrDefaultAsync(x => x.Id == id);

                var result = new MoveDamageClass
                {
                    Id           = moveDamageClass.Id,
                    Name         = moveDamageClass.Identifier,
                    Descriptions = GetDescriptions(moveDamageClass),
                    Moves        = GetMoves(moveDamageClass),
                    Names        = GetNames(moveDamageClass)
                };

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        private List<Description> GetDescriptions(EFMoveDamageClasses moveDamageClass)
        {
            return moveDamageClass
                .MoveDamageClassProse
                .Select(x => new Description
                (
                    x.Description,
                    x.LocalLanguage.ToNamedApiResource()
                ))
                .ToList();
        }

        private List<NamedAPIResource> GetMoves(EFMoveDamageClasses moveDamageClass)
        {
            return moveDamageClass
                .Moves
                .Select(x => x.ToNamedApiResource())
                .ToList();
        }

        private List<Name> GetNames(EFMoveDamageClasses moveDamageClass)
        {
            return moveDamageClass
                .MoveDamageClassProse
                .Select(x => new Name
                (
                    x.Name,
                    x.LocalLanguage.ToNamedApiResource()
                ))
                .ToList();
        }
    }
}