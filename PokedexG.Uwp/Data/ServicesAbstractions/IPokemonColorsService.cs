using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PokedexG.Uwp.Data.Models;
using PokemonAPI.Models.Rsc;

namespace PokedexG.Uwp.Data.ServicesAbstractions
{
    public interface IPokemonColorsService
    {
        Task<int> Count();
        Task<List<NamedAPIResource>> GetAll(int limit, int offset);
        Task<List<NamedAPIResource>> GetAll(Expression<Func<EFPokemonColors, bool>> predicate, int limit, int offset);
        Task<PokemonColor> Get(int id);
        Task<PokemonColor> Get(string name);
        Task<PokemonColor> Get(Expression<Func<EFPokemonColors, bool>> predicate);
    }
}