using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Models;
using Type = System.Type;

namespace PokemonAPI.WebService.Services.ServicesAbstractions
{
    public interface IPokemonsService : IService
    {
        Task<int> Count();
        Task<List<NamedAPIResource>> GetAll(int limit, int offset, Type controllerType);

        Task<List<NamedAPIResource>> GetAll(Expression<Func<EFPokemon, bool>> predicate,
            int limit, int offset, Type controllerType);

        Task<Pokemon> Get(int id);
        Task<Pokemon> Get(string name);
        Task<Pokemon> Get(Expression<Func<EFPokemon, bool>> predicate);
        Task<List<LocationAreaEncounter>> GetEncounters(int pokemonId);
        Task<List<LocationAreaEncounter>> GetEncounters(string pokemonName);
        Task<List<LocationAreaEncounter>> GetEncounters(Expression<Func<EFEncounters, bool>> predicate);
    }
}