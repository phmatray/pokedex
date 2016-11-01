using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Models;
using Type = System.Type;

namespace PokemonAPI.WebService.Services.ServicesAbstractions
{
    public interface IMoveAilmentsService
    {
        Task<int> Count();
        Task<List<NamedAPIResource>> GetAll(int limit, int offset, Type controllerType);

        Task<List<NamedAPIResource>> GetAll(Expression<Func<EFMoveMetaAilments, bool>> predicate,
            int limit, int offset, Type controllerType);

        Task<MoveAilment> Get(int id);
        Task<MoveAilment> Get(string name);
        Task<MoveAilment> Get(Expression<Func<EFMoveMetaAilments, bool>> predicate);
    }
}