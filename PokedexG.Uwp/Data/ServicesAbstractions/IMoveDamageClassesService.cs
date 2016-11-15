using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PokedexG.Uwp.Data.Models;
using PokemonAPI.Models.Rsc;

namespace PokedexG.Uwp.Data.ServicesAbstractions
{
    public interface IMoveDamageClassesService
    {
        Task<int> Count();
        Task<List<NamedAPIResource>> GetAll(int limit, int offset);
        Task<List<NamedAPIResource>> GetAll(Expression<Func<EFMoveDamageClasses, bool>> predicate, int limit, int offset);
        Task<MoveDamageClass> Get(int id);
        Task<MoveDamageClass> Get(string name);
        Task<MoveDamageClass> Get(Expression<Func<EFMoveDamageClasses, bool>> predicate);
    }
}