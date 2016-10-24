using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Core;
using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Controllers.Base
{
    public abstract class ApiController : Controller
    {
        protected async Task<IActionResult> GetAll<TModel>(int limit, int offset,
            DbSet<TModel> dbset, string urlSegment)
            where TModel : class, IEFIdentifier
        {
            try
            {
                if (limit <= 0) throw new ArgumentOutOfRangeException(nameof(limit));
                if (offset < 0) throw new ArgumentOutOfRangeException(nameof(offset));
                if (dbset == null) throw new ArgumentNullException(nameof(dbset));
                if (string.IsNullOrWhiteSpace(urlSegment))
                    throw new ArgumentException("Value cannot be null or whitespace.", nameof(urlSegment));

                var count    = await dbset.CountAsync();
                var previous = UrlHelpers.Previous(limit, offset, urlSegment);
                var next     = UrlHelpers.Next(limit, offset, count, urlSegment);

                var apiResults = (await dbset
                        .OrderBy(x => x.Id)
                        .Skip(offset)
                        .Take(limit)
                        .ToListAsync())
                    .Select(x => x.ToNamedApiResource(urlSegment))
                    .Cast<APIResource>()
                    .ToList();

                var results = new APIResourceList(count, previous, next, apiResults);

                return Ok(results);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}