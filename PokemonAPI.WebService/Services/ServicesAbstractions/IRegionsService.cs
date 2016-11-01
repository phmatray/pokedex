using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Models;
using Type = System.Type;

namespace PokemonAPI.WebService.Services.ServicesAbstractions
{
    public interface IRegionsService
    {
        Task<int> Count();
        Task<List<NamedAPIResource>> GetAll(int limit, int offset, Type controllerType);

        Task<List<NamedAPIResource>> GetAll(Expression<Func<EFRegions, bool>> predicate,
            int limit, int offset, Type controllerType);

        Task<Region> Get(int id);
        Task<Region> Get(string name);
        Task<Region> Get(Expression<Func<EFRegions, bool>> predicate);
    }
}