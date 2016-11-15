using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PokedexG.Uwp.Data.Models;
using PokemonAPI.Models.Rsc;

namespace PokedexG.Uwp.Data.ServicesAbstractions
{
    public interface IMoveLearnMethodsService
    {
        Task<int> Count();
        Task<List<NamedAPIResource>> GetAll(int limit, int offset);
        Task<List<NamedAPIResource>> GetAll(Expression<Func<EFPokemonMoveMethods, bool>> predicate, int limit, int offset);
        Task<MoveLearnMethod> Get(int id);
        Task<MoveLearnMethod> Get(string name);
        Task<MoveLearnMethod> Get(Expression<Func<EFPokemonMoveMethods, bool>> predicate);
    }
}