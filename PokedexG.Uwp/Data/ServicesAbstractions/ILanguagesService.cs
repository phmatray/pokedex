using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PokedexG.Uwp.Data.Models;
using PokemonAPI.Models.Rsc;

namespace PokedexG.Uwp.Data.ServicesAbstractions
{
    public interface ILanguagesService
    {
        Task<int> Count();
        Task<List<NamedAPIResource>> GetAll(int limit, int offset);
        Task<List<NamedAPIResource>> GetAll(Expression<Func<EFLanguages, bool>> predicate, int limit, int offset);
        Task<Language> Get(int id);
        Task<Language> Get(string name);
        Task<Language> Get(Expression<Func<EFLanguages, bool>> predicate);
    }
}