using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Models;
using Type = System.Type;

namespace PokemonAPI.WebService.Services.ServicesAbstractions
{
    public interface IPokemonFormsService
    {
        Task<int> Count();
        Task<List<NamedAPIResource>> GetAll(int limit, int offset, Type controllerType);

        Task<List<NamedAPIResource>> GetAll(Expression<Func<EFPokemonForms, bool>> predicate,
            int limit, int offset, Type controllerType);

        Task<PokemonForm> Get(int id);
        Task<PokemonForm> Get(string name);
        Task<PokemonForm> Get(Expression<Func<EFPokemonForms, bool>> predicate);
    }
}