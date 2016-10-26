using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Core;
using PokemonAPI.WebService.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using PokemonAPI.WebService.Controllers._Base;

namespace PokemonAPI.WebService.Controllers
{
    public class VeekunPokemon
    {
        public string Name { get; set; }
    }

    [Route("api/v1/veekun")]
    public class VeekunController : ApiController
    {
        private readonly VeekunContext _context;

        public VeekunController(VeekunContext context)
        {
            _context = context;
        }

        // GET api/v1/veekun
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var results = await _context
                    .Pokemon
                    .Select(x => new VeekunPokemon
                    {
                        Name = x.Identifier
                    })
                    .ToListAsync();

                return Ok(results);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}