using System.Collections.Generic;
using System.Threading.Tasks;
using PokemonAPI.Models.Rsc;
using Type = PokemonAPI.Models.Rsc.Type;

namespace PokemonAPI.WebService.Services.CacheServicesAbstractions
{
    public interface ITypesCacheService
    {
        Task<int> Count();
        Task<List<NamedAPIResource>> GetAll(int limit, int offset, System.Type controllerType);
        Task<Type> Get(int id);
        Task<Type> Get(string name);
    }
}