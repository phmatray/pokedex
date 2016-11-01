using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Models;
using Type = System.Type;

namespace PokemonAPI.WebService.Services.ServicesAbstractions
{
    public interface IBerriesService
    {
        Task<int> Count();
        Task<List<NamedAPIResource>> GetAll(int limit, int offset, Type controllerType);

        Task<List<NamedAPIResource>> GetAll(Expression<Func<EFBerries, bool>> predicate,
            int limit, int offset, Type controllerType);

        Task<Berry> Get(int id);
        Task<Berry> Get(string name);
        Task<Berry> Get(Expression<Func<EFBerries, bool>> predicate);
    }
}