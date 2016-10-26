using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Core;
using PokemonAPI.WebService.Models.Interfaces;
using Type = System.Type;

namespace PokemonAPI.WebService.Controllers._Base
{
    public abstract class ApiController : Controller
    {
        protected async Task<IActionResult> GetAll<TModel>(int limit, int offset,
            DbSet<TModel> dbset, Type controllerType)
            where TModel : class, IEFIdentifier
        {
            try
            {
                if (limit <= 0) throw new ArgumentOutOfRangeException(nameof(limit));
                if (offset < 0) throw new ArgumentOutOfRangeException(nameof(offset));
                if (dbset == null) throw new ArgumentNullException(nameof(dbset));
                if (controllerType == null) throw new ArgumentNullException(nameof(controllerType));

                var count    = await dbset.CountAsync();
                var previous = controllerType.Previous(limit, offset);
                var next     = controllerType.Next(limit, offset, count);

                var apiResults = (await dbset
                        .AsNoTracking()
                        .OrderBy(x => x.Id)
                        .Skip(offset)
                        .Take(limit)
                        .ToListAsync())
                    .Select(x => x.ToNamedApiResource(controllerType))
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