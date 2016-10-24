using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Core;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using PokemonAPI.WebService.Controllers._Base;

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
                var previous   = UrlHelpers.Previous(limit, offset, urlSegment);
                var next       = UrlHelpers.Next(limit, offset, count, urlSegment);

                var apiResults = (await dbset
                        .Skip(offset)
                        .Take(limit)
                        .ToListAsync())
                    .Select(x => x.ToApiResource())
                    .ToList();

                var results = new APIResourceList(count, previous, next, apiResults);

                return Ok(results);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // GET api/v1/machines?machineNumber=1&versionGroupId=1
        [HttpGet("{machineNumber}/{versionGroupId}")]
        public async Task<IActionResult> Get(int machineNumber, int versionGroupId)
        {
            try
            {
                var machine = await _context.Machines
                    .Include(x => x.Item)
                    .Include(x => x.Move)
                    .Include(x => x.VersionGroup)
                    .FirstOrDefaultAsync(x => x.MachineNumber == machineNumber &&
                    x.VersionGroupId == versionGroupId);

                var result = new Machine
                {
                    Id           = $"{machineNumber}/{versionGroupId}",
                    Item         = machine.Item.ToNamedApiResource(),
                    Move         = machine.Move.ToNamedApiResource(),
                    VersionGroup = machine.VersionGroup.ToNamedApiResource()
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