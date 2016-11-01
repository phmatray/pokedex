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
    public class LocationAreasCacheService : ILocationAreasCacheService
    {
        private readonly IMemoryCache _memoryCache;
        private readonly ILogger<LocationAreasCacheService> _logger;
        private readonly ILocationAreasService _locationAreasService;
        private readonly string _typeName;

        public LocationAreasCacheService(
            IMemoryCache memoryCache,
            ILogger<LocationAreasCacheService> logger,
            ILocationAreasService locationAreasService)
        {
            _memoryCache          = memoryCache;
            _logger               = logger;
            _locationAreasService = locationAreasService;
            _typeName             = GetType().Name;
        }

        public async Task<int> Count()
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-Count",
                entry => _locationAreasService.Count());

        public async Task<List<NamedAPIResource>> GetAll(int limit, int offset, Type controllerType)
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-GetAll-{limit}-{offset}",
                entry => _locationAreasService.GetAll(limit, offset, typeof(LocationAreasController)));

        public async Task<LocationArea> Get(int id)
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-Get-{id}",
                entry => _locationAreasService.Get(id));

        public async Task<LocationArea> Get(string name)
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-Get-{name}",
                entry => _locationAreasService.Get(name));
    }
}