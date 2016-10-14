using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Core;
using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Controllers.Base
{
    public abstract class ApiController<TModel> : Controller
        where TModel: class, IEFIdentifier
    {
        protected VeekunContext Context { get; }
        protected DbSet<TModel> MainDbSet { get; }
        protected string UriSection { get; }

        protected string ControllerUrl
            => $"{Constants.SiteUrl}{Constants.BaseUrl}{UriSection}";

        protected string ControllerName
            => GetType().Name;

        protected string ModelName
            => GetType().Name.Replace("Controller", "");


        protected ApiController(VeekunContext context, string dbSetName, string uriSection)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));
            if (string.IsNullOrWhiteSpace(dbSetName))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(dbSetName));
            if (string.IsNullOrWhiteSpace(uriSection))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(uriSection));

            Context = context;
            MainDbSet = (DbSet<TModel>) GetValueByReflection(context, dbSetName);
            UriSection = uriSection;
        }


        protected async Task<IActionResult> GetAll(int limit, int offset)
        {
            try
            {
                if (limit <= 0) throw new ArgumentOutOfRangeException(nameof(limit));
                if (offset < 0) throw new ArgumentOutOfRangeException(nameof(offset));

                var count = await MainDbSet.CountAsync();
                var previous = Previous(limit, offset);
                var next = Next(limit, offset, count);

                var apiResults = (await MainDbSet
                        .Skip(offset)
                        .Take(limit)
                        .ToListAsync())
                    .Select(x => x.ToNamedApiResource())
                    .Cast<APIResource>()
                    .ToList();

                var results = new APIResourceList
                {
                    Count = count,
                    Previous = previous,
                    Next = next,
                    Results = apiResults
                };

                return Ok(results);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        private object GetValueByReflection(object obj, string propertyName)
        {
            return obj.GetType().GetProperty(propertyName).GetValue(obj);
        }

        private string Previous(int limit, int offset)
        {
            return offset - limit > 0
                ? $"{ControllerUrl}?limit={limit}&offset={offset - limit}"
                : null;
        }

        private string Next(int limit, int offset, int count)
        {
            return offset + limit < count
                ? $"{ControllerUrl}?limit={limit}&offset={offset + limit}"
                : null;
        }
    }
}