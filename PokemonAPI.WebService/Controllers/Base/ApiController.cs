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
                var previous = Previous(limit, offset, urlSegment);
                var next     = Next(limit, offset, count, urlSegment);

                var apiResults = (await dbset
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

        protected string Previous(int limit, int offset, string urlSegment)
        {
            return offset - limit >= 0
                ? $"{Constants.SiteUrl}{Constants.BaseUrl}{urlSegment}?limit={limit}&offset={offset - limit}"
                : null;
        }

        protected string Next(int limit, int offset, int count, string urlSegment)
        {
            return offset + limit < count
                ? $"{Constants.SiteUrl}{Constants.BaseUrl}{urlSegment}?limit={limit}&offset={offset + limit}"
                : null;
        }
    }
}