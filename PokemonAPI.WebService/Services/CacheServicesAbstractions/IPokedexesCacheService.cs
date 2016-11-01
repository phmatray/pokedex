using System.Collections.Generic;
using System.Threading.Tasks;
using PokemonAPI.Models.Rsc;
using Type = System.Type;

namespace PokemonAPI.WebService.Services.CacheServicesAbstractions
{
    public interface IPokedexesCacheService
    {
        Task<int> Count();
        Task<List<NamedAPIResource>> GetAll(int limit, int offset, Type controllerType);
        Task<Pokedex> Get(int id);
        Task<Pokedex> Get(string name);
    }
}