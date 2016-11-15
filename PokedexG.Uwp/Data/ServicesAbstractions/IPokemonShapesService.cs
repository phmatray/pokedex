using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PokedexG.Uwp.Data.Models;
using PokemonAPI.Models.Rsc;

namespace PokedexG.Uwp.Data.ServicesAbstractions
{
    public interface IPokemonShapesService
    {
        Task<int> Count();
        Task<List<NamedAPIResource>> GetAll(int limit, int offset);
        Task<List<NamedAPIResource>> GetAll(Expression<Func<EFPokemonShapes, bool>> predicate, int limit, int offset);
        Task<PokemonShape> Get(int id);
        Task<PokemonShape> Get(string name);
        Task<PokemonShape> Get(Expression<Func<EFPokemonShapes, bool>> predicate);
    }
}