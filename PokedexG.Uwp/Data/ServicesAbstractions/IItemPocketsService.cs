using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PokedexG.Uwp.Data.Models;
using PokemonAPI.Models.Rsc;

namespace PokedexG.Uwp.Data.ServicesAbstractions
{
    public interface IItemPocketsService
    {
        Task<int> Count();
        Task<List<NamedAPIResource>> GetAll(int limit, int offset);
        Task<List<NamedAPIResource>> GetAll(Expression<Func<EFItemPockets, bool>> predicate, int limit, int offset);
        Task<ItemPocket> Get(int id);
        Task<ItemPocket> Get(string name);
        Task<ItemPocket> Get(Expression<Func<EFItemPockets, bool>> predicate);
    }
}