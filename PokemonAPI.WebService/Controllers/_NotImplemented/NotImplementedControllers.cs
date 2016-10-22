using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PokemonAPI.WebService.Controllers.Base;
using PokemonAPI.WebService.Core;

namespace PokemonAPI.WebService.Controllers
{
    [Route("api/v1/evolution-chains")]
    public class EvolutionChainsController : ApiController
    {
        private readonly VeekunContext _context;

        public EvolutionChainsController(VeekunContext context)
        {
            _context = context;
        }

        // GET api/v1/evolution-chains
        // GET api/v1/evolution-chains?skip=0&take=20
        [HttpGet]
        public async Task<IActionResult> GetAll(int limit = 20, int offset = 0)
        {
            throw new NotImplementedException();
        }

        // GET api/v1/evolution-chains/1
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            throw new NotImplementedException();
        }
    }

    [Route("api/v1/locations")]
    public class LocationsController : ApiController
    {
        private readonly VeekunContext _context;

        public LocationsController(VeekunContext context)
        {
            _context = context;
        }

        // GET api/v1/locations
        // GET api/v1/locations?skip=0&take=20
        [HttpGet]
        public async Task<IActionResult> GetAll(int limit = 20, int offset = 0)
        {
            return await base.GetAll(limit, offset, 
                _context.Locations, this.Segment());
        }

        // GET api/v1/locations/1
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            throw new NotImplementedException();
        }
    }

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
            throw new NotImplementedException();
        }
    }

    [Route("api/v1/items")]
    public class ItemsController : ApiController
    {
        private readonly VeekunContext _context;

        public ItemsController(VeekunContext context)
        {
            _context = context;
        }

        // GET api/v1/items
        // GET api/v1/items?skip=0&take=20
        [HttpGet]
        public async Task<IActionResult> GetAll(int limit = 20, int offset = 0)
        {
            throw new NotImplementedException();
            //return await base.GetAll(limit, offset,
            //    _context.Characteristics, this.Segment());
        }

        // GET api/v1/items/1
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            throw new NotImplementedException();
        }
    }

    [Route("api/v1/contest-effects")]
    public class ContestEffectsController : ApiController
    {
        private readonly VeekunContext _context;

        public ContestEffectsController(VeekunContext context)
        {
            _context = context;
        }

        // GET api/v1/contest-effects
        // GET api/v1/contest-effects?skip=0&take=20
        [HttpGet]
        public async Task<IActionResult> GetAll(int limit = 20, int offset = 0)
        {
            throw new NotImplementedException();
            //return await base.GetAll(limit, offset,
            //    _context.Characteristics, this.Segment());
        }

        // GET api/v1/contest-effects/1
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            throw new NotImplementedException();
        }
    }

    [Route("api/v1/super-contest-effects")]
    public class SuperContestEffectsController : ApiController
    {
        private readonly VeekunContext _context;

        public SuperContestEffectsController(VeekunContext context)
        {
            _context = context;
        }

        // GET api/v1/super-contest-effects
        // GET api/v1/super-contest-effects?skip=0&take=20
        [HttpGet]
        public async Task<IActionResult> GetAll(int limit = 20, int offset = 0)
        {
            throw new NotImplementedException();
            //return await base.GetAll(limit, offset,
            //    _context.Characteristics, this.Segment());
        }

        // GET api/v1/super-contest-effects/1
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}