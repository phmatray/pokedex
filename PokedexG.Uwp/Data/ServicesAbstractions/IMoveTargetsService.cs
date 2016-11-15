using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PokedexG.Uwp.Data.Models;
using PokemonAPI.Models.Rsc;

namespace PokedexG.Uwp.Data.ServicesAbstractions
{
    public interface IMoveTargetsService
    {
        Task<int> Count();
        Task<List<NamedAPIResource>> GetAll(int limit, int offset);
        Task<List<NamedAPIResource>> GetAll(Expression<Func<EFMoveTargets, bool>> predicate, int limit, int offset);
        Task<MoveTarget> Get(int id);
        Task<MoveTarget> Get(string name);
        Task<MoveTarget> Get(Expression<Func<EFMoveTargets, bool>> predicate);
    }
}