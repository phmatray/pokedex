using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Models;
using Type = System.Type;

namespace PokemonAPI.WebService.Services.ServicesAbstractions
{
    public interface IBerryFlavorsService
    {
        Task<int> Count();
        Task<List<NamedAPIResource>> GetAll(int limit, int offset, Type controllerType);

        Task<List<NamedAPIResource>> GetAll(Expression<Func<EFContestTypeNames, bool>> predicate,
            int limit, int offset, Type controllerType);

        Task<BerryFlavor> Get(int id);
        Task<BerryFlavor> Get(string name);
        Task<BerryFlavor> Get(Expression<Func<EFContestTypes, bool>> predicate);
    }
}