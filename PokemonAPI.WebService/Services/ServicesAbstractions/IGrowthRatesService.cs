using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Models;
using Type = System.Type;

namespace PokemonAPI.WebService.Services.ServicesAbstractions
{
    public interface IGrowthRatesService
    {
        Task<int> Count();
        Task<List<NamedAPIResource>> GetAll(int limit, int offset, Type controllerType);

        Task<List<NamedAPIResource>> GetAll(Expression<Func<EFGrowthRates, bool>> predicate,
            int limit, int offset, Type controllerType);

        Task<GrowthRate> Get(int id);
        Task<GrowthRate> Get(string name);
        Task<GrowthRate> Get(Expression<Func<EFGrowthRates, bool>> predicate);
    }
}