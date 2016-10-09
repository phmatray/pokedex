using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PokemonAPI.Models.Resources;
using PokemonAPI.WebService.Controllers.Base;
using PokemonAPI.WebService.Core;
using PokemonAPI.WebService.Models;

namespace PokemonAPI.WebService.Controllers
{
    [Route("api/v1/[controller]")]
    public class LanguagesController : ApiController<Languages>
    {
        public LanguagesController(VeekunContext context)
            : base(context)
        {
        }

        // GET api/v1/languages
        // GET api/v1/languages?skip=0&take=20
        [HttpGet]
        public async Task<IActionResult> GetAll(int limit = 20, int offset = 0)
        {
            return await base.GetAll(limit, offset);
        }

        // GET api/v1/languages/1
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var language = await MainDbSet
                    .FirstOrDefaultAsync(x => x.Id == id);

                var result = new LanguageResource
                {
                    Id         = language.Id,
                    Identifier = language.Identifier,
                    Iso639     = language.Iso639,
                    Iso3166    = language.Iso3166,
                    Official   = language.Official,
                    Names      = await GetNames(language)
                };

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        private async Task<List<NameResource>> GetNames(Languages language)
        {
            return (await Context
                    .LanguageNames
                    .Include(x => x.LocalLanguage)
                    .Where(x => x.LanguageId == language.Id)
                    .ToListAsync())
                .Select(x => x.ToNameResource())
                .ToList();
        }
    }
}