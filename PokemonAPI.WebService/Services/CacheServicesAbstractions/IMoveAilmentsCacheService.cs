using System.Collections.Generic;
using System.Threading.Tasks;
using PokemonAPI.Models.Rsc;
using Type = System.Type;

namespace PokemonAPI.WebService.Services.CacheServicesAbstractions
{
    public interface IMoveAilmentsCacheService
    {
        Task<int> Count();
        Task<List<NamedAPIResource>> GetAll(int limit, int offset, Type controllerType);
        Task<MoveAilment> Get(int id);
        Task<MoveAilment> Get(string name);
    }
}