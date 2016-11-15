using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PokedexG.Uwp.Data.Models;
using PokemonAPI.Models.Rsc;

namespace PokedexG.Uwp.Data.ServicesAbstractions
{
    public interface IAbilitiesService
    {
        Task<int> Count();
        Task<List<NamedAPIResource>> GetAll(int limit, int offset);
        Task<List<NamedAPIResource>> GetAll(Expression<Func<EFAbilities, bool>> predicate, int limit, int offset);
        Task<Ability> Get(int id);
        Task<Ability> Get(string name);
        Task<Ability> Get(Expression<Func<EFAbilities, bool>> predicate);
    }
}