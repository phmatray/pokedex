using System.Collections.Generic;
using System.Threading.Tasks;
using PokemonAPI.Models.Rsc;

namespace PokemonAPI.WebService.Controllers
{
    public interface IPokemonsService
    {
        Task<NamedAPIResourceList> GetAll(int limit, int offset);
        Task<Pokemon> Get(int id);
        Task<List<LocationAreaEncounter>> GetEncounters(int pokemonId);
    }

    public interface IPokemonsCacheService : IPokemonsService
    {
    }
}