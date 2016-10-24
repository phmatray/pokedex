using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Core;
using Microsoft.EntityFrameworkCore;
using PokemonAPI.WebService.Models;
using System.Linq;
using PokemonAPI.WebService.Controllers._Base;

namespace PokemonAPI.WebService.Controllers
{
    [Route("api/v1/berry-firmnesses")]
    public class BerryFirmnessesController : ApiController
    {
        private readonly VeekunContext _context;

        public BerryFirmnessesController(VeekunContext context)
        {
            _context = context;
        }

        // GET api/v1/berry-firmnesses
        // GET api/v1/berry-firmnesses?skip=0&take=20
        [HttpGet]
        public async Task<IActionResult> GetAll(int limit = 20, int offset = 0)
            => await GetAll(limit, offset, _context.BerryFirmness, GetType());

        // GET api/v1/berry-firmnesses/1
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var berryFirmness = await _context.BerryFirmness
                    .Include(x => x.Berries).ThenInclude(x => x.Item)
                    .Include(x => x.BerryFirmnessNames).ThenInclude(x => x.LocalLanguage)
                    .FirstOrDefaultAsync(x => x.Id == id);

                var result = new BerryFirmness
                {
                    Id      = berryFirmness.Id,
                    Name    = berryFirmness.Identifier,
                    Berries = GetBerries(berryFirmness),
                    Names   = GetNames(berryFirmness)
                };

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        private static List<NamedAPIResource> GetBerries(EFBerryFirmness berryFirmness)
        {
            return berryFirmness
                .Berries
                .Select(x => new NamedAPIResource
                (
                    x.Item.Identifier.Replace("-berry", ""),
                    typeof(BerriesController).RscUrl(x.Id)
                ))
                .ToList();
        }

        private static List<Name> GetNames(EFBerryFirmness berryFirmness)
        {
            return berryFirmness
                .BerryFirmnessNames
                .Select(x => new Name(x.Name, x.LocalLanguage.ToNamedApiResource()))
                .ToList();
        }
    }
}