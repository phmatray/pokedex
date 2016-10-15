using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PokemonAPI.WebService.Controllers.Base;
using PokemonAPI.WebService.Core;

namespace PokemonAPI.WebService.Controllers
{
    [Route("api/v1/moves")]
    public class MovesController : ApiController
    {
        private readonly VeekunContext _context;

        public MovesController(VeekunContext context)
        {
            _context = context;
        }

        // GET api/v1/moves
        // GET api/v1/moves?skip=0&take=20
        [HttpGet]
        public async Task<IActionResult> GetAll(int limit = 20, int offset = 0)
        {
            return await base.GetAll(limit, offset, 
                _context.Abilities, this.Segment());
        }

        // GET api/v1/moves/1
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            throw new NotImplementedException();
        }
    }

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

    [Route("api/v1/pokemon-shapes")]
    public class PokemonShapesController : ApiController
    {
        private readonly VeekunContext _context;

        public PokemonShapesController(VeekunContext context)
        {
            _context = context;
        }

        // GET api/v1/pokemon-shapes
        // GET api/v1/pokemon-shapes?skip=0&take=20
        [HttpGet]
        public async Task<IActionResult> GetAll(int limit = 20, int offset = 0)
        {
            return await base.GetAll(limit, offset, 
                _context.PokemonShapes, this.Segment());
        }

        // GET api/v1/pokemon-shapes/1
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            throw new NotImplementedException();
        }
    }

    [Route("api/v1/pokemon-habitats")]
    public class PokemonHabitatsController : ApiController
    {
        private readonly VeekunContext _context;

        public PokemonHabitatsController(VeekunContext context)
        {
            _context = context;
        }

        // GET api/v1/pokemon-habitats
        // GET api/v1/pokemon-habitats?skip=0&take=20
        [HttpGet]
        public async Task<IActionResult> GetAll(int limit = 20, int offset = 0)
        {
            return await base.GetAll(limit, offset, 
                _context.PokemonHabitats, this.Segment());
        }

        // GET api/v1/pokemon-habitats/1
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

    [Route("api/v1/pokemon-forms")]
    public class PokemonFormsController : ApiController
    {
        private readonly VeekunContext _context;

        public PokemonFormsController(VeekunContext context)
        {
            _context = context;
        }

        // GET api/v1/pokemon-forms
        // GET api/v1/pokemon-forms?skip=0&take=20
        [HttpGet]
        public async Task<IActionResult> GetAll(int limit = 20, int offset = 0)
        {
            return await base.GetAll(limit, offset, 
                _context.PokemonForms, this.Segment());
        }

        // GET api/v1/pokemon-forms/1
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            throw new NotImplementedException();
        }
    }

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
        {
            throw new NotImplementedException();
        }

        // GET api/v1/move-learn-methods/1
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            throw new NotImplementedException();
        }
    }

    [Route("api/v1/stats")]
    public class StatsController : ApiController
    {
        private readonly VeekunContext _context;

        public StatsController(VeekunContext context)
        {
            _context = context;
        }

        // GET api/v1/stats
        // GET api/v1/stats?skip=0&take=20
        [HttpGet]
        public async Task<IActionResult> GetAll(int limit = 20, int offset = 0)
        {
            return await base.GetAll(limit, offset,
                _context.Stats, this.Segment());
        }

        // GET api/v1/stats/1
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            throw new NotImplementedException();
        }
    }

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
                _context.Stats, this.Segment());
        }

        // GET api/v1/move-damage-classes/1
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            throw new NotImplementedException();
        }
    }



    
}