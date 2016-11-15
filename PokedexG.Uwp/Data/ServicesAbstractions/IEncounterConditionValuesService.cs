using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PokedexG.Uwp.Data.Models;
using PokemonAPI.Models.Rsc;

namespace PokedexG.Uwp.Data.ServicesAbstractions
{
    public interface IEncounterConditionValuesService
    {
        Task<int> Count();
        Task<List<NamedAPIResource>> GetAll(int limit, int offset);
        Task<List<NamedAPIResource>> GetAll(Expression<Func<EFEncounterConditionValues, bool>> predicate, int limit, int offset);
        Task<EncounterConditionValue> Get(int id);
        Task<EncounterConditionValue> Get(string name);
        Task<EncounterConditionValue> Get(Expression<Func<EFEncounterConditionValues, bool>> predicate);
    }
}