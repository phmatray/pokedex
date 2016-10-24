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
    [Route("api/v1/languages")]
    public class LanguagesController : ApiController
    {
        private readonly VeekunContext _context;

        public LanguagesController(VeekunContext context)
        {
            _context = context;
        }

        // GET api/v1/languages
        // GET api/v1/languages?skip=0&take=20
        [HttpGet]
        public async Task<IActionResult> GetAll(int limit = 20, int offset = 0)
        {
            return await GetAll(limit, offset, _context.Languages, this.Segment());
        }

        // GET api/v1/languages/1
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var language = await _context.Languages
                    .Include(x => x.LanguageNamesLanguage).ThenInclude(x => x.LocalLanguage)
                    .FirstOrDefaultAsync(x => x.Id == id);

                var result = new Language
                {
                    Id         = language.Id,
                    Name       = language.Identifier,
                    Iso639     = language.Iso639,
                    Iso3166    = language.Iso3166,
                    Official   = language.Official,
                    Names      = GetNames(language)
                };

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        private static List<Name> GetNames(EFLanguages language)
        {
            return language.LanguageNamesLanguage
                .Select(x => new Name(x.Name, x.LocalLanguage.ToNamedApiResource()))
                .ToList();
        }
    }
}