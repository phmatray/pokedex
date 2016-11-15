using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PokedexG.Uwp.Data.Models;
using PokemonAPI.Models.Rsc;

namespace PokedexG.Uwp.Data.ServicesAbstractions
{
    public interface IMovesService
    {
        Task<int> Count();
        Task<List<NamedAPIResource>> GetAll(int limit, int offset);
        Task<List<NamedAPIResource>> GetAll(Expression<Func<EFMoves, bool>> predicate, int limit, int offset);
        Task<Move> Get(int id);
        Task<Move> Get(string name);
        Task<Move> Get(Expression<Func<EFMoves, bool>> predicate);
    }
}