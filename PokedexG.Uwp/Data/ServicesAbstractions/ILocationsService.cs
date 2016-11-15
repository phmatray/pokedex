using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PokedexG.Uwp.Data.Models;
using PokemonAPI.Models.Rsc;

namespace PokedexG.Uwp.Data.ServicesAbstractions
{
    public interface ILocationsService
    {
        Task<int> Count();
        Task<List<NamedAPIResource>> GetAll(int limit, int offset);
        Task<List<NamedAPIResource>> GetAll(Expression<Func<EFLocations, bool>> predicate, int limit, int offset);
        Task<Location> Get(int id);
        Task<Location> Get(string name);
        Task<Location> Get(Expression<Func<EFLocations, bool>> predicate);
    }
}