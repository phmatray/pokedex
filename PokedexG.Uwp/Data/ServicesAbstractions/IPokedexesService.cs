using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PokedexG.Uwp.Data.Models;
using PokemonAPI.Models.Rsc;

namespace PokedexG.Uwp.Data.ServicesAbstractions
{
    public interface IPokedexesService
    {
        Task<int> Count();
        Task<List<NamedAPIResource>> GetAll(int limit, int offset);
        Task<List<NamedAPIResource>> GetAll(Expression<Func<EFPokedexes, bool>> predicate, int limit, int offset);
        Task<Pokedex> Get(int id);
        Task<Pokedex> Get(string name);
        Task<Pokedex> Get(Expression<Func<EFPokedexes, bool>> predicate);
    }
}