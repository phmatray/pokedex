using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PokedexG.Uwp.Data.Models;
using PokemonAPI.Models.Rsc;

namespace PokedexG.Uwp.Data.ServicesAbstractions
{
    public interface IPokemonHabitatsService
    {
        Task<int> Count();
        Task<List<NamedAPIResource>> GetAll(int limit, int offset);
        Task<List<NamedAPIResource>> GetAll(Expression<Func<EFPokemonHabitats, bool>> predicate, int limit, int offset);
        Task<PokemonHabitat> Get(int id);
        Task<PokemonHabitat> Get(string name);
        Task<PokemonHabitat> Get(Expression<Func<EFPokemonHabitats, bool>> predicate);
    }
}