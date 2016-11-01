using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Models;
using Type = System.Type;

namespace PokemonAPI.WebService.Services.ServicesAbstractions
{
    public interface IMachinesService
    {
        Task<int> Count();
        Task<List<APIResource>> GetAll(int limit, int offset, Type controllerType);

        Task<List<APIResource>> GetAll(Expression<Func<EFMachines, bool>> predicate,
            int limit, int offset, Type controllerType);

        Task<Machine> Get(int machineNumber, int versionGroupId);
        Task<Machine> Get(Expression<Func<EFMachines, bool>> predicate);
    }
}