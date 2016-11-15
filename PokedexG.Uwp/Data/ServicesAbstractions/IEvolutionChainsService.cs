using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PokedexG.Uwp.Data.Models;
using PokemonAPI.Models.Rsc;

namespace PokedexG.Uwp.Data.ServicesAbstractions
{
    public interface IEvolutionChainsService
    {
        Task<int> Count();
        Task<List<APIResource>> GetAll(int limit, int offset);
        Task<List<APIResource>> GetAll(Expression<Func<EFEvolutionChains, bool>> predicate, int limit, int offset);
        Task<EvolutionChain> Get(int id);
        Task<EvolutionChain> Get(Expression<Func<EFEvolutionChains, bool>> predicate);
    }
}