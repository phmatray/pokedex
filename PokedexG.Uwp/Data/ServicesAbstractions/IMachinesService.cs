using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PokedexG.Uwp.Data.Models;
using PokemonAPI.Models.Rsc;

namespace PokedexG.Uwp.Data.ServicesAbstractions
{
    public interface IMachinesService
    {
        Task<int> Count();
        Task<List<APIResource>> GetAll(int limit, int offset);
        Task<List<APIResource>> GetAll(Expression<Func<EFMachines, bool>> predicate, int limit, int offset);
        Task<Machine> Get(int machineNumber, int versionGroupId);
        Task<Machine> Get(Expression<Func<EFMachines, bool>> predicate);
    }
}