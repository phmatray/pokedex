using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PokedexG.Uwp.Data.Models;
using PokemonAPI.Models.Rsc;

namespace PokedexG.Uwp.Data.ServicesAbstractions
{
    public interface IGrowthRatesService
    {
        Task<int> Count();
        Task<List<NamedAPIResource>> GetAll(int limit, int offset);
        Task<List<NamedAPIResource>> GetAll(Expression<Func<EFGrowthRates, bool>> predicate, int limit, int offset);
        Task<GrowthRate> Get(int id);
        Task<GrowthRate> Get(string name);
        Task<GrowthRate> Get(Expression<Func<EFGrowthRates, bool>> predicate);
    }
}