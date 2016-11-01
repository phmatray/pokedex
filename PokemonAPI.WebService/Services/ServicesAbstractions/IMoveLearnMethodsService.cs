using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Models;
using Type = System.Type;

namespace PokemonAPI.WebService.Services.ServicesAbstractions
{
    public interface IMoveLearnMethodsService
    {
        Task<int> Count();
        Task<List<NamedAPIResource>> GetAll(int limit, int offset, Type controllerType);

        Task<List<NamedAPIResource>> GetAll(Expression<Func<EFPokemonMoveMethods, bool>> predicate,
            int limit, int offset, Type controllerType);

        Task<MoveLearnMethod> Get(int id);
        Task<MoveLearnMethod> Get(string name);
        Task<MoveLearnMethod> Get(Expression<Func<EFPokemonMoveMethods, bool>> predicate);
    }
}