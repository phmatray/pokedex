using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Models;
using Type = System.Type;

namespace PokemonAPI.WebService.Services.ServicesAbstractions
{
    public interface ILocationsService
    {
        Task<int> Count();
        Task<List<NamedAPIResource>> GetAll(int limit, int offset, Type controllerType);

        Task<List<NamedAPIResource>> GetAll(Expression<Func<EFLocations, bool>> predicate,
            int limit, int offset, Type controllerType);

        Task<Location> Get(int id);
        Task<Location> Get(string name);
        Task<Location> Get(Expression<Func<EFLocations, bool>> predicate);
    }
}