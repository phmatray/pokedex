using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PokedexG.Uwp.Data.Models;
using PokemonAPI.Models.Rsc;
using Type = PokemonAPI.Models.Rsc.Type;

namespace PokedexG.Uwp.Data.ServicesAbstractions
{
    public interface ITypesService
    {
        Task<int> Count();
        Task<List<NamedAPIResource>> GetAll(int limit, int offset);
        Task<List<NamedAPIResource>> GetAll(Expression<Func<EFTypes, bool>> predicate, int limit, int offset);
        Task<Type> Get(int id);
        Task<Type> Get(string name);
        Task<Type> Get(Expression<Func<EFTypes, bool>> predicate);
    }
}