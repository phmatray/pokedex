using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Models;
using Type = System.Type;

namespace PokemonAPI.WebService.Services.ServicesAbstractions
{
    public interface IGendersService
    {
        Task<int> Count();
        Task<List<NamedAPIResource>> GetAll(int limit, int offset, Type controllerType);

        Task<List<NamedAPIResource>> GetAll(Expression<Func<EFGenders, bool>> predicate,
            int limit, int offset, Type controllerType);

        Task<Gender> Get(int id);
        Task<Gender> Get(string name);
        Task<Gender> Get(Expression<Func<EFGenders, bool>> predicate);
    }
}