using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PokedexG.Uwp.Data.Models;
using PokemonAPI.Models.Rsc;

namespace PokedexG.Uwp.Data.ServicesAbstractions
{
    public interface IRegionsService
    {
        Task<int> Count();
        Task<List<NamedAPIResource>> GetAll(int limit, int offset);
        Task<List<NamedAPIResource>> GetAll(Expression<Func<EFRegions, bool>> predicate, int limit, int offset);
        Task<Region> Get(int id);
        Task<Region> Get(string name);
        Task<Region> Get(Expression<Func<EFRegions, bool>> predicate);
    }
}