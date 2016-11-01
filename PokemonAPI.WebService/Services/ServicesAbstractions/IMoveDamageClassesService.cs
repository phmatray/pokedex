using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Models;
using Type = System.Type;

namespace PokemonAPI.WebService.Services.ServicesAbstractions
{
    public interface IMoveDamageClassesService
    {
        Task<int> Count();
        Task<List<NamedAPIResource>> GetAll(int limit, int offset, Type controllerType);

        Task<List<NamedAPIResource>> GetAll(Expression<Func<EFMoveDamageClasses, bool>> predicate,
            int limit, int offset, Type controllerType);

        Task<MoveDamageClass> Get(int id);
        Task<MoveDamageClass> Get(string name);
        Task<MoveDamageClass> Get(Expression<Func<EFMoveDamageClasses, bool>> predicate);
    }
}