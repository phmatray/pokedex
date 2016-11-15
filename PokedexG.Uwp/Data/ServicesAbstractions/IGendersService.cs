using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PokedexG.Uwp.Data.Models;
using PokemonAPI.Models.Rsc;

namespace PokedexG.Uwp.Data.ServicesAbstractions
{
    public interface IGendersService
    {
        Task<int> Count();
        Task<List<NamedAPIResource>> GetAll(int limit, int offset);
        Task<List<NamedAPIResource>> GetAll(Expression<Func<EFGenders, bool>> predicate, int limit, int offset);
        Task<Gender> Get(int id);
        Task<Gender> Get(string name);
        Task<Gender> Get(Expression<Func<EFGenders, bool>> predicate);
    }
}