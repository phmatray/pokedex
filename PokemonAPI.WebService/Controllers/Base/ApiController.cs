using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PokemonAPI.Models.Resources;
using PokemonAPI.WebService.Core;
using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Controllers.Base
{
    public abstract class ApiController<TModel> : Controller
        where TModel: class, INamedModel
    {
        protected VeekunContext Context { get; }
        protected DbSet<TModel> MainDbSet { get; }

        protected string ControllerUrl
            => $"{Constants.SiteUrl}{Constants.BaseUrl}{UriSection}";

        protected string ControllerName
            => GetType().Name;

        protected string ModelName
            => GetType().Name.Replace("Controller", "");

        protected string UriSection
            => GetType().Name.Replace("Controller", "").ToLower();


        protected ApiController(VeekunContext context)
        {
            Context = context;
            MainDbSet = (DbSet<TModel>) GetValueByReflection(context, ModelName);
        }

        protected ApiController(VeekunContext context, string dbSetName)
        {
            Context = context;
            MainDbSet = (DbSet<TModel>) GetValueByReflection(context, dbSetName);
        }


        protected async Task<IActionResult> GetAll(int limit, int offset)
        {
            try
            {
                var count = await MainDbSet.CountAsync();
                var previous = Previous(limit, offset);
                var next = Next(limit, offset, count);

                var apiResults = (await MainDbSet
                        .Skip(offset)
                        .Take(limit)
                        .ToListAsync())
                    .Select(x => x.ToNamedApiResource())
                    .Cast<APIResourceBase>()
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