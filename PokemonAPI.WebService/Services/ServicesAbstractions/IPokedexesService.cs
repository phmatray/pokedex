using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Models;
using Type = System.Type;

namespace PokemonAPI.WebService.Services.ServicesAbstractions
{
    public interface IPokedexesService
    {
        Task<int> Count();
        Task<List<NamedAPIResource>> GetAll(int limit, int offset, Type controllerType);

        Task<List<NamedAPIResource>> GetAll(Expression<Func<EFPokedexes, bool>> predicate,
            int limit, int offset, Type controllerType);

        Task<Pokedex> Get(int id);
        Task<Pokedex> Get(string name);
        Task<Pokedex> Get(Expression<Func<EFPokedexes, bool>> predicate);
    }
}