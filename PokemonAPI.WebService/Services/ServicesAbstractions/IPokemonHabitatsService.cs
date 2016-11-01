using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Models;
using Type = System.Type;

namespace PokemonAPI.WebService.Services.ServicesAbstractions
{
    public interface IPokemonHabitatsService
    {
        Task<int> Count();
        Task<List<NamedAPIResource>> GetAll(int limit, int offset, Type controllerType);

        Task<List<NamedAPIResource>> GetAll(Expression<Func<EFPokemonHabitats, bool>> predicate,
            int limit, int offset, Type controllerType);

        Task<PokemonHabitat> Get(int id);
        Task<PokemonHabitat> Get(string name);
        Task<PokemonHabitat> Get(Expression<Func<EFPokemonHabitats, bool>> predicate);
    }
}