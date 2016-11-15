using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PokedexG.Uwp.Data.Models;
using PokemonAPI.Models.Rsc;

namespace PokedexG.Uwp.Data.ServicesAbstractions
{
    public interface IEggGroupsService
    {
        Task<int> Count();
        Task<List<NamedAPIResource>> GetAll(int limit, int offset);
        Task<List<NamedAPIResource>> GetAll(Expression<Func<EFEggGroups, bool>> predicate, int limit, int offset);
        Task<EggGroup> Get(int id);
        Task<EggGroup> Get(string name);
        Task<EggGroup> Get(Expression<Func<EFEggGroups, bool>> predicate);
    }
}