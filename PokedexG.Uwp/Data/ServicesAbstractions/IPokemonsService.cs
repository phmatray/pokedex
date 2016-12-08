using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PokedexG.Uwp.Data.Models;
using PokemonAPI.Models.Rsc;

namespace PokedexG.Uwp.Data.ServicesAbstractions
{
    public interface IPokemonsService
    {
        Task<int> CountAsync();
        Task<List<NamedAPIResource>> GetAllAsync(int limit, int offset);
        Task<List<NamedAPIResource>> GetAllAsync(Expression<Func<EFPokemon, bool>> predicate, int limit, int offset);
        Task<Pokemon> GetAsync(int id);
        Task<Pokemon> GetAsync(string name);
        Task<Pokemon> GetAsync(Expression<Func<EFPokemon, bool>> predicate);
        Task<List<LocationAreaEncounter>> GetEncountersAsync(int pokemonId);
        Task<List<LocationAreaEncounter>> GetEncountersAsync(string pokemonName);
        Task<List<LocationAreaEncounter>> GetEncountersAsync(Expression<Func<EFEncounters, bool>> predicate);
    }
}