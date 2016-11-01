using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Models;
using Type = System.Type;

namespace PokemonAPI.WebService.Services.ServicesAbstractions
{
    public interface IPokemonSpeciesService
    {
        Task<int> Count();
        Task<List<NamedAPIResource>> GetAll(int limit, int offset, Type controllerType);

        Task<List<NamedAPIResource>> GetAll(Expression<Func<EFPokemonSpecies, bool>> predicate,
            int limit, int offset, Type controllerType);

        Task<PokemonSpecies> Get(int id);
        Task<PokemonSpecies> Get(string name);
        Task<PokemonSpecies> Get(Expression<Func<EFPokemonSpecies, bool>> predicate);
    }
}