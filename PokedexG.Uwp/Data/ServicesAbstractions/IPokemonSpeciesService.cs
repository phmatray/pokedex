using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PokedexG.Uwp.Data.Models;
using PokemonAPI.Models.Rsc;

namespace PokedexG.Uwp.Data.ServicesAbstractions
{
    public interface IPokemonSpeciesService
    {
        Task<int> Count();
        Task<List<NamedAPIResource>> GetAll(int limit, int offset);
        Task<List<NamedAPIResource>> GetAll(Expression<Func<EFPokemonSpecies, bool>> predicate, int limit, int offset);
        Task<PokemonSpecies> Get(int id);
        Task<PokemonSpecies> Get(string name);
        Task<PokemonSpecies> Get(Expression<Func<EFPokemonSpecies, bool>> predicate);
    }
}