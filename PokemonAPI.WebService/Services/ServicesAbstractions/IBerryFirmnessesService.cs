using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Models;
using Type = System.Type;

namespace PokemonAPI.WebService.Services.ServicesAbstractions
{
    public interface IBerryFirmnessesService
    {
        Task<int> Count();
        Task<List<NamedAPIResource>> GetAll(int limit, int offset, Type controllerType);

        Task<List<NamedAPIResource>> GetAll(Expression<Func<EFBerryFirmness, bool>> predicate, 
            int limit, int offset, Type controllerType);

        Task<BerryFirmness> Get(int id);
        Task<BerryFirmness> Get(string name);
        Task<BerryFirmness> Get(Expression<Func<EFBerryFirmness, bool>> predicate);
    }
}