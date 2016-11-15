using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PokedexG.Uwp.Data.Models;
using PokemonAPI.Models.Rsc;

namespace PokedexG.Uwp.Data.ServicesAbstractions
{
    public interface IMoveAilmentsService
    {
        Task<int> Count();
        Task<List<NamedAPIResource>> GetAll(int limit, int offset);
        Task<List<NamedAPIResource>> GetAll(Expression<Func<EFMoveMetaAilments, bool>> predicate, int limit, int offset);
        Task<MoveAilment> Get(int id);
        Task<MoveAilment> Get(string name);
        Task<MoveAilment> Get(Expression<Func<EFMoveMetaAilments, bool>> predicate);
    }
}