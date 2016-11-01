using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Models;
using Type = System.Type;

namespace PokemonAPI.WebService.Services.ServicesAbstractions
{
    public interface IItemFlingEffectsService
    {
        Task<int> Count();
        Task<List<NamedAPIResource>> GetAll(int limit, int offset, Type controllerType);

        Task<List<NamedAPIResource>> GetAll(Expression<Func<EFItemFlingEffects, bool>> predicate,
            int limit, int offset, Type controllerType);

        Task<ItemFlingEffect> Get(int id);
        Task<ItemFlingEffect> Get(string name);
        Task<ItemFlingEffect> Get(Expression<Func<EFItemFlingEffects, bool>> predicate);
    }
}