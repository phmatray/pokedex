using System.Collections.Generic;
using System.Threading.Tasks;
using PokemonAPI.Models.Rsc;
using Type = System.Type;

namespace PokemonAPI.WebService.Services.CacheServicesAbstractions
{
    public interface ICharacteristicsCacheService
    {
        Task<int> Count();
        Task<List<APIResource>> GetAll(int limit, int offset, Type controllerType);
        Task<Characteristic> Get(int id);
    }
}