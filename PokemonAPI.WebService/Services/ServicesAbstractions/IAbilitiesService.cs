using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Models;
using Type = System.Type;

namespace PokemonAPI.WebService.Services.ServicesAbstractions
{
    public interface IAbilitiesService
    {
        Task<int> Count();
        Task<List<NamedAPIResource>> GetAll(int limit, int offset, Type controllerType);

        Task<List<NamedAPIResource>> GetAll(Expression<Func<EFAbilities, bool>> predicate,
            int limit, int offset, Type controllerType);

        Task<Ability> Get(int id);
        Task<Ability> Get(string name);
        Task<Ability> Get(Expression<Func<EFAbilities, bool>> predicate);
    }
}