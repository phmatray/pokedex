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
        Task<int> Count();
        Task<List<NamedAPIResource>> GetAll(int limit, int offset);
        Task<List<NamedAPIResource>> GetAll(Expression<Func<EFPokemon, bool>> predicate, int limit, int offset);
        Task<Pokemon> Get(int id);
        Task<Pokemon> Get(string name);
        Task<Pokemon> Get(Expression<Func<EFPokemon, bool>> predicate);
        Task<List<LocationAreaEncounter>> GetEncounters(int pokemonId);
        Task<List<LocationAreaEncounter>> GetEncounters(string pokemonName);
        Task<List<LocationAreaEncounter>> GetEncounters(Expression<Func<EFEncounters, bool>> predicate);
    }
}