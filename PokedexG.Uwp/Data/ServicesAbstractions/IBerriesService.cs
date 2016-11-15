using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PokedexG.Uwp.Data.Models;
using PokemonAPI.Models.Rsc;

namespace PokedexG.Uwp.Data.ServicesAbstractions
{
    public interface IBerriesService
    {
        Task<int> Count();
        Task<List<NamedAPIResource>> GetAll(int limit, int offset);
        Task<List<NamedAPIResource>> GetAll(Expression<Func<EFBerries, bool>> predicate, int limit, int offset);
        Task<Berry> Get(int id);
        Task<Berry> Get(string name);
        Task<Berry> Get(Expression<Func<EFBerries, bool>> predicate);
    }
}