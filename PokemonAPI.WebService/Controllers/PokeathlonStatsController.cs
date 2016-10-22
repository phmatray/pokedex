using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Controllers.Base;
using PokemonAPI.WebService.Core;
using PokemonAPI.WebService.Models;
using System.Linq;

namespace PokemonAPI.WebService.Controllers
{
    [Route("api/v1/pokeathlon-stats")]
    public class PokeathlonStatsController : ApiController
    {
        private readonly VeekunContext _context;

        public PokeathlonStatsController(VeekunContext context)
        {
            _context = context;
        }

        // GET api/v1/pokeathlon-stats
        // GET api/v1/pokeathlon-stats?skip=0&take=20
        [HttpGet]
        public async Task<IActionResult> GetAll(int limit = 20, int offset = 0)
        {
            return await base.GetAll(limit, offset,
                _context.PokeathlonStats, this.Segment());
        }

        // GET api/v1/pokeathlon-stats/1
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var pokeathlonStat = await _context.PokeathlonStats
                    .Include(x => x.NaturePokeathlonStats).ThenInclude(x => x.Nature)
                    .Include(x => x.PokeathlonStatNames).ThenInclude(x => x.LocalLanguage)
                    .FirstOrDefaultAsync(x => x.Id == id);

                var result = new PokeathlonStat
                {
                    Id               = pokeathlonStat.Id,
                    Name             = pokeathlonStat.Identifier,
                    Names            = GetNames(pokeathlonStat),
                    AffectingNatures = GetAffectingNatures(pokeathlonStat)
                };

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        private List<Name> GetNames(EFPokeathlonStats pokeathlonStat)
        {
            return pokeathlonStat
                .PokeathlonStatNames
                .Select(x => new Name
                (
                    x.Name,
                    x.LocalLanguage.ToNamedApiResource<LanguagesController>()
                ))
                .ToList();
        }

        private NaturePokeathlonStatAffectSets GetAffectingNatures(EFPokeathlonStats pokeathlonStat)
        {
            return new NaturePokeathlonStatAffectSets
            {
                Increase = pokeathlonStat
                    .NaturePokeathlonStats
                    .Where(x => x.MaxChange > 0)
                    .Select(x => new NaturePokeathlonStatAffect
                    {
                        MaxChange = x.MaxChange,
                        Nature = x.Nature.ToNamedApiResource<NaturesController>()
                    })
                    .ToList(),
                Decrease = pokeathlonStat
                    .NaturePokeathlonStats
                    .Where(x => x.MaxChange < 0)
                    .Select(x => new NaturePokeathlonStatAffect
                    {
                        MaxChange = x.MaxChange,
                        Nature = x.Nature.ToNamedApiResource<NaturesController>()
                    })
                    .ToList()
            };
        }
    }
}