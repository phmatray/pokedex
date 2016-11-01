using System.Collections.Generic;
using System.Threading.Tasks;
using PokemonAPI.Models.Rsc;
using Type = System.Type;

namespace PokemonAPI.WebService.Services.CacheServicesAbstractions
{
    public interface IEncounterConditionsCacheService
    {
        Task<int> Count();
        Task<List<NamedAPIResource>> GetAll(int limit, int offset, Type controllerType);
        Task<EncounterCondition> Get(int id);
        Task<EncounterCondition> Get(string name);
    }
}