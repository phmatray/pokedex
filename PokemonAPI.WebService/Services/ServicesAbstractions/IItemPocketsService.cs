using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Models;
using Type = System.Type;

namespace PokemonAPI.WebService.Services.ServicesAbstractions
{
    public interface IItemPocketsService
    {
        Task<int> Count();
        Task<List<NamedAPIResource>> GetAll(int limit, int offset, Type controllerType);

        Task<List<NamedAPIResource>> GetAll(Expression<Func<EFItemPockets, bool>> predicate,
            int limit, int offset, Type controllerType);

        Task<ItemPocket> Get(int id);
        Task<ItemPocket> Get(string name);
        Task<ItemPocket> Get(Expression<Func<EFItemPockets, bool>> predicate);
    }
}