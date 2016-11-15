using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PokedexG.Uwp.Data.Models;
using PokemonAPI.Models.Rsc;

namespace PokedexG.Uwp.Data.ServicesAbstractions
{
    public interface IContestTypesService
    {
        Task<int> Count();
        Task<List<NamedAPIResource>> GetAll(int limit, int offset);
        Task<List<NamedAPIResource>> GetAll(Expression<Func<EFContestTypes, bool>> predicate, int limit, int offset);
        Task<ContestType> Get(int id);
        Task<ContestType> Get(string name);
        Task<ContestType> Get(Expression<Func<EFContestTypes, bool>> predicate);
    }
}