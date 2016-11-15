using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PokedexG.Uwp.Data.Models;
using PokemonAPI.Models.Rsc;

namespace PokedexG.Uwp.Data.ServicesAbstractions
{
    public interface INaturesService
    {
        Task<int> Count();
        Task<List<NamedAPIResource>> GetAll(int limit, int offset);
        Task<List<NamedAPIResource>> GetAll(Expression<Func<EFNatures, bool>> predicate, int limit, int offset);
        Task<Nature> Get(int id);
        Task<Nature> Get(string name);
        Task<Nature> Get(Expression<Func<EFNatures, bool>> predicate);
    }
}