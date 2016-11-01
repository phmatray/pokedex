using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Models;
using Type = System.Type;

namespace PokemonAPI.WebService.Services.ServicesAbstractions
{
    public interface IPokemonShapesService
    {
        Task<int> Count();
        Task<List<NamedAPIResource>> GetAll(int limit, int offset, Type controllerType);

        Task<List<NamedAPIResource>> GetAll(Expression<Func<EFPokemonShapes, bool>> predicate,
            int limit, int offset, Type controllerType);

        Task<PokemonShape> Get(int id);
        Task<PokemonShape> Get(string name);
        Task<PokemonShape> Get(Expression<Func<EFPokemonShapes, bool>> predicate);
    }
}