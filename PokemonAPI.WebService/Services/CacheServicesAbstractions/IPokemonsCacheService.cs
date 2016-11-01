using System.Collections.Generic;
using System.Threading.Tasks;
using PokemonAPI.Models.Rsc;
using Type = System.Type;

namespace PokemonAPI.WebService.Services.CacheServicesAbstractions
{
    public interface IPokemonsCacheService : IService
    {
        Task<int> Count();
        Task<List<NamedAPIResource>> GetAll(int limit, int offset, Type controllerType);
        Task<Pokemon> Get(int id);
        Task<Pokemon> Get(string name);
        Task<List<LocationAreaEncounter>> GetEncounters(int pokemonId);
        Task<List<LocationAreaEncounter>> GetEncounters(string pokemonName);
    }
}