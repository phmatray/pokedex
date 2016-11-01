using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Models;
using Type = System.Type;

namespace PokemonAPI.WebService.Services.ServicesAbstractions
{
    public interface INaturesService
    {
        Task<int> Count();
        Task<List<NamedAPIResource>> GetAll(int limit, int offset, Type controllerType);

        Task<List<NamedAPIResource>> GetAll(Expression<Func<EFNatures, bool>> predicate,
            int limit, int offset, Type controllerType);

        Task<Nature> Get(int id);
        Task<Nature> Get(string name);
        Task<Nature> Get(Expression<Func<EFNatures, bool>> predicate);
    }
}