using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PokedexG.Uwp.Data.Models;
using PokemonAPI.Models.Rsc;

namespace PokedexG.Uwp.Data.ServicesAbstractions
{
    public interface IVersionGroupsService
    {
        Task<int> Count();
        Task<List<NamedAPIResource>> GetAll(int limit, int offset);
        Task<List<NamedAPIResource>> GetAll(Expression<Func<EFVersionGroups, bool>> predicate, int limit, int offset);
        Task<VersionGroup> Get(int id);
        Task<VersionGroup> Get(string name);
        Task<VersionGroup> Get(Expression<Func<EFVersionGroups, bool>> predicate);
    }
}