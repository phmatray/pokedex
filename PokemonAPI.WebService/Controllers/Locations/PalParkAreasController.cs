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
    [Route("api/v1/pal-park-areas")]
    public class PalParkAreasController : ApiController
    {
        private readonly VeekunContext _context;

        public PalParkAreasController(VeekunContext context)
        {
            _context = context;
        }

        // GET api/v1/pal-park-areas
        // GET api/v1/pal-park-areas?skip=0&take=20
        [HttpGet]
        public async Task<IActionResult> GetAll(int limit = 20, int offset = 0)
        {
            return await base.GetAll(limit, offset, 
                _context.PalParkAreas, this.Segment());
        }

        // GET api/v1/pal-park-areas/1
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var palParkArea = await _context.PalParkAreas
                    .Include(x => x.PalParkAreaNames).ThenInclude(x => x.LocalLanguage)
                    .Include(x => x.PalPark).ThenInclude(x => x.Species)
                    .FirstOrDefaultAsync(x => x.Id == id);

                var result = new PalParkArea
                {
                    Id                = palParkArea.Id,
                    Name              = palParkArea.Identifier,
                    Names             = GetNames(palParkArea),
                    PokemonEncounters = GetPokemonEncounters(palParkArea)
                };

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        private List<Name> GetNames(EFPalParkAreas palParkArea)
        {
            return palParkArea
                .PalParkAreaNames
                .Select(x => new Name(x.Name, x.LocalLanguage.ToNamedApiResource()))
                .ToList();
        }

        private List<PalParkEncounterSpecies> GetPokemonEncounters(EFPalParkAreas palParkArea)
        {
            return palParkArea
                .PalPark
                .Select(x => new PalParkEncounterSpecies
                {
                    BaseScore      = x.BaseScore,
                    Rate           = x.Rate,
                    PokemonSpecies = x.Species.ToNamedApiResource()
                })
                .ToList();
        }
    }
}