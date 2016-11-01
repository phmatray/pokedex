using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Models;
using Type = System.Type;

namespace PokemonAPI.WebService.Services.ServicesAbstractions
{
    public interface IEvolutionChainsService
    {
        Task<int> Count();
        Task<List<APIResource>> GetAll(int limit, int offset, Type controllerType);

        Task<List<APIResource>> GetAll(Expression<Func<EFEvolutionChains, bool>> predicate,
            int limit, int offset, Type controllerType);

        Task<EvolutionChain> Get(int id);
        Task<EvolutionChain> Get(Expression<Func<EFEvolutionChains, bool>> predicate);
    }
}