using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Models;
using Type = System.Type;

namespace PokemonAPI.WebService.Services.ServicesAbstractions
{
    public interface ICharacteristicsService
    {
        Task<int> Count();
        Task<List<APIResource>> GetAll(int limit, int offset, Type controllerType);

        Task<List<APIResource>> GetAll(Expression<Func<EFCharacteristics, bool>> predicate,
            int limit, int offset, Type controllerType);

        Task<Characteristic> Get(int id);
        Task<Characteristic> Get(Expression<Func<EFCharacteristics, bool>> predicate);
    }
}