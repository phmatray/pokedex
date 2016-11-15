using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PokedexG.Uwp.Data.Models;
using PokemonAPI.Models.Rsc;

namespace PokedexG.Uwp.Data.ServicesAbstractions
{
    public interface IMoveCategoriesService
    {
        Task<int> Count();
        Task<List<NamedAPIResource>> GetAll(int limit, int offset);
        Task<List<NamedAPIResource>> GetAll(Expression<Func<EFMoveMetaCategories, bool>> predicate, int limit, int offset);
        Task<MoveCategory> Get(int id);
        Task<MoveCategory> Get(string name);
        Task<MoveCategory> Get(Expression<Func<EFMoveMetaCategories, bool>> predicate);
    }
}