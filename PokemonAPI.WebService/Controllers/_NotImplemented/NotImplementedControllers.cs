using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PokemonAPI.WebService.Controllers.Base;

namespace PokemonAPI.WebService.Controllers
{
    [Route("api/v1/encounter-methods")]
    public class EncounterMethodsController : ApiController
    {
        private readonly VeekunContext _context;

        public EncounterMethodsController(VeekunContext context)
        {
            _context = context;
        }

        // GET api/v1/encounter-methods
        // GET api/v1/encounter-methods?skip=0&take=20
        [HttpGet]
        public async Task<IActionResult> GetAll(int limit = 20, int offset = 0)
        {
            throw new NotImplementedException();
            //return await base.GetAll(limit, offset,
            //    _context.Characteristics, this.Segment());
        }

        // GET api/v1/encounter-methods/1
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            throw new NotImplementedException();
        }
    }

    [Route("api/v1/encounter-condition-values")]
    public class EncounterConditionValuesController : ApiController
    {
        private readonly VeekunContext _context;

        public EncounterConditionValuesController(VeekunContext context)
        {
            _context = context;
        }

        // GET api/v1/encounter-condition-values
        // GET api/v1/encounter-condition-values?skip=0&take=20
        [HttpGet]
        public async Task<IActionResult> GetAll(int limit = 20, int offset = 0)
        {
            throw new NotImplementedException();
            //return await base.GetAll(limit, offset,
            //    _context.Characteristics, this.Segment());
        }

        // GET api/v1/encounter-condition-values/1
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            throw new NotImplementedException();
        }
    }

    [Route("api/v1/item-fling-effects")]
    public class ItemFlingEffectsController : ApiController
    {
        private readonly VeekunContext _context;

        public ItemFlingEffectsController(VeekunContext context)
        {
            _context = context;
        }

        // GET api/v1/item-fling-effects
        // GET api/v1/item-fling-effects?skip=0&take=20
        [HttpGet]
        public async Task<IActionResult> GetAll(int limit = 20, int offset = 0)
        {
            throw new NotImplementedException();
            //return await base.GetAll(limit, offset,
            //    _context.Characteristics, this.Segment());
        }

        // GET api/v1/item-fling-effects/1
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            throw new NotImplementedException();
        }
    }

    [Route("api/v1/item-attributes")]
    public class ItemAttributesController : ApiController
    {
        private readonly VeekunContext _context;

        public ItemAttributesController(VeekunContext context)
        {
            _context = context;
        }

        // GET api/v1/item-attributes
        // GET api/v1/item-attributes?skip=0&take=20
        [HttpGet]
        public async Task<IActionResult> GetAll(int limit = 20, int offset = 0)
        {
            throw new NotImplementedException();
            //return await base.GetAll(limit, offset,
            //    _context.Characteristics, this.Segment());
        }

        // GET api/v1/item-attributes/1
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            throw new NotImplementedException();
        }
    }

    [Route("api/v1/item-pockets")]
    public class ItemPocketsController : ApiController
    {
        private readonly VeekunContext _context;

        public ItemPocketsController(VeekunContext context)
        {
            _context = context;
        }

        // GET api/v1/item-pockets
        // GET api/v1/item-pockets?skip=0&take=20
        [HttpGet]
        public async Task<IActionResult> GetAll(int limit = 20, int offset = 0)
        {
            throw new NotImplementedException();
            //return await base.GetAll(limit, offset,
            //    _context.Characteristics, this.Segment());
        }

        // GET api/v1/item-pockets/1
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            throw new NotImplementedException();
        }
    }

    [Route("api/v1/item-categories")]
    public class ItemCategoriesController : ApiController
    {
        private readonly VeekunContext _context;

        public ItemCategoriesController(VeekunContext context)
        {
            _context = context;
        }

        // GET api/v1/item-categories
        // GET api/v1/item-categories?skip=0&take=20
        [HttpGet]
        public async Task<IActionResult> GetAll(int limit = 20, int offset = 0)
        {
            throw new NotImplementedException();
            //return await base.GetAll(limit, offset,
            //    _context.Characteristics, this.Segment());
        }

        // GET api/v1/item-categories/1
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}