using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Controllers.Base;
using PokemonAPI.WebService.Core;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace PokemonAPI.WebService.Controllers
{
    [Route("api/v1/machines")]
    public class MachinesController : ApiController
    {
        private readonly VeekunContext _context;

        public MachinesController(VeekunContext context)
        {
            _context = context;
        }

        // GET api/v1/machines
        // GET api/v1/machines?skip=0&take=20
        [HttpGet]
        public async Task<IActionResult> GetAll(int limit = 20, int offset = 0)
        {
            try
            {
                if (limit <= 0) throw new ArgumentOutOfRangeException(nameof(limit));
                if (offset < 0) throw new ArgumentOutOfRangeException(nameof(offset));

                var dbset      = _context.Machines;
                var urlSegment = typeof(MachinesController).Segment();

                var count      = await dbset.CountAsync();
                var previous   = Previous(limit, offset, urlSegment);
                var next       = Next(limit, offset, count, urlSegment);

                var apiResults = (await dbset
                        .Skip(offset)
                        .Take(limit)
                        .ToListAsync())
                    .Select((x, i) => (i + offset + 1).ToApiResource<MachinesController>())
                    .ToList();

                var results = new APIResourceList(count, previous, next, apiResults);

                return Ok(results);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // GET api/v1/machines/1
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var skip = id - 1;
                var machines = await _context.Machines
                    .OrderBy(x => x.MachineNumber)
                    .Skip(skip)
                    .Take(1)
                    .Include(x => x.Item)
                    .Include(x => x.Move)
                    .Include(x => x.VersionGroup)
                    .ToListAsync();

                var machine = machines.FirstOrDefault();

                var result = new Machine
                {
                    Id           = id,
                    Item         = machine.Item.ToNamedApiResource<ItemsController>(),
                    Move         = machine.Move.ToNamedApiResource<MovesController>(),
                    VersionGroup = machine.VersionGroup.ToNamedApiResource<VersionGroupsController>()
                };

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}