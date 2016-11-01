using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Controllers;
using PokemonAPI.WebService.Services.CacheServicesAbstractions;
using PokemonAPI.WebService.Services.ServicesAbstractions;
using Type = System.Type;

namespace PokemonAPI.WebService.Services.CacheServices
{
    public class EncounterConditionsValuesCacheService : IEncounterConditionValuesCacheService
    {
        private readonly IMemoryCache _memoryCache;
        private readonly ILogger<EncounterConditionsValuesCacheService> _logger;
        private readonly IEncounterConditionValuesService _encounterConditionsValuesService;
        private readonly string _typeName;

        public EncounterConditionsValuesCacheService(
            IMemoryCache memoryCache,
            ILogger<EncounterConditionsValuesCacheService> logger,
            IEncounterConditionValuesService encounterConditionsValuesService)
        {
            _memoryCache                      = memoryCache;
            _logger                           = logger;
            _encounterConditionsValuesService = encounterConditionsValuesService;
            _typeName                         = GetType().Name;
        }

        public async Task<int> Count()
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-Count",
                entry => _encounterConditionsValuesService.Count());

        public async Task<List<NamedAPIResource>> GetAll(int limit, int offset, Type controllerType)
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-GetAll-{limit}-{offset}",
                entry => _encounterConditionsValuesService.GetAll(limit, offset, typeof(EncounterConditionValuesController)));

        public async Task<EncounterConditionValue> Get(int id)
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-Get-{id}",
                entry => _encounterConditionsValuesService.Get(id));

        public async Task<EncounterConditionValue> Get(string name)
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-Get-{name}",
                entry => _encounterConditionsValuesService.Get(name));
    }
}