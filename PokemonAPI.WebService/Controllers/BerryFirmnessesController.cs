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
        {
            return await base.GetAll(limit, offset,
                _context.BerryFirmness, this.Segment());
        }

        // GET api/v1/berry-firmnesses/1
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var berryFirmness = await _context.BerryFirmness
                    .FirstOrDefaultAsync(x => x.Id == id);

                var result = new BerryFirmness
                {
                    Id      = berryFirmness.Id,
                    Name    = berryFirmness.Identifier,
                    Berries = await GetBerries(berryFirmness),
                    Names   = await GetNames(berryFirmness)
                };

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        private async Task<List<NamedAPIResource>> GetBerries(EFBerryFirmness berryFirmness)
        {
            return (await _context
                    .Berries
                    .Include(x => x.Item)
                    .Where(x => x.FirmnessId == berryFirmness.Id)
                    .ToListAsync())
                .Select(x => new NamedAPIResource
                (
                    x.Item.Identifier.Replace("-berry", ""),
                    $"{Constants.SiteUrl}{Constants.BaseUrl}{typeof(BerriesController).Segment()}/{x.Id}"
                ))
                .ToList();
        }

        private async Task<List<Name>> GetNames(EFBerryFirmness berryFirmness)
        {
            return (await _context
                    .BerryFirmnessNames
                    .Include(x => x.LocalLanguage)
                    .Where(x => x.BerryFirmnessId == berryFirmness.Id)
                    .ToListAsync())
                .Select(x => new Name
                (
                    x.Name,
                    x.LocalLanguage.ToNamedApiResource(typeof(LanguagesController).Segment())
                ))
                .ToList();
        }
    }
}