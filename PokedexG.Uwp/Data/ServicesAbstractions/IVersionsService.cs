using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PokedexG.Uwp.Data.Models;
using PokemonAPI.Models.Rsc;
using Version = PokemonAPI.Models.Rsc.Version;

namespace PokedexG.Uwp.Data.ServicesAbstractions
{
    public interface IVersionsService
    {
        Task<int> Count();
        Task<List<NamedAPIResource>> GetAll(int limit, int offset);
        Task<List<NamedAPIResource>> GetAll(Expression<Func<EFVersions, bool>> predicate, int limit, int offset);
        Task<Version> Get(int id);
        Task<Version> Get(string name);
        Task<Version> Get(Expression<Func<EFVersions, bool>> predicate);
    }
}