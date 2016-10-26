using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using PokemonAPI.Models.Rsc;

namespace PokemonAPI.WebService.Controllers
{
    public class PokemonsCacheService : IPokemonsCacheService
    {
        private readonly IMemoryCache _memoryCache;
        private readonly ILogger<PokemonsCacheService> _logger;
        private readonly IPokemonsService _pokemonsService;

        public PokemonsCacheService(
            IMemoryCache memoryCache,
            ILogger<PokemonsCacheService> logger,
            IPokemonsService pokemonsService)
        {
            _memoryCache     = memoryCache;
            _logger          = logger;
            _pokemonsService = pokemonsService;
        }

        public async Task<NamedAPIResourceList> GetAll(int limit, int offset)
        {
            string cacheKey = $"PokemonsService-GetAll-{limit}-{offset}";
            NamedAPIResourceList pokemons;

            // TryGet returns true if the cache entry was found
            if (!_memoryCache.TryGetValue(cacheKey, out pokemons))
            {
                // fetch the value from the source
                pokemons = await _pokemonsService.GetAll(limit, offset);

                // store in the cache
                _memoryCache.Set(cacheKey, pokemons, new MemoryCacheEntryOptions());
                //.SetAbsoluteExpiration(TimeSpan.FromMinutes(1)));
                _logger.LogInformation($"{cacheKey} updated from source.");
            }
            else
            {
                _logger.LogInformation($"{cacheKey} retrieved from cache.");
            }

            return pokemons;
        }

        public async Task<Pokemon> Get(int id)
        {
            string cacheKey = $"PokemonsService-Get-{id}";
            Pokemon pokemon;

            // TryGet returns true if the cache entry was found
            if (!_memoryCache.TryGetValue(cacheKey, out pokemon))
            {
                // fetch the value from the source
                pokemon = await _pokemonsService.Get(id);

                // store in the cache
                _memoryCache.Set(cacheKey, pokemon, new MemoryCacheEntryOptions());
                //.SetAbsoluteExpiration(TimeSpan.FromMinutes(1)));
                _logger.LogInformation($"{cacheKey} updated from source.");
            }
            else
            {
                _logger.LogInformation($"{cacheKey} retrieved from cache.");
            }

            return pokemon;
        }

        public async Task<List<LocationAreaEncounter>> GetEncounters(int pokemonId)
        {
            string cacheKey = $"PokemonsService-GetEncounters-{pokemonId}";
            List<LocationAreaEncounter> encounters;

            // TryGet returns true if the cache entry was found
            if (!_memoryCache.TryGetValue(cacheKey, out encounters))
            {
                // fetch the value from the source
                encounters = await _pokemonsService.GetEncounters(pokemonId);

                // store in the cache
                _memoryCache.Set(cacheKey, encounters, new MemoryCacheEntryOptions());
                //.SetAbsoluteExpiration(TimeSpan.FromMinutes(1)));
                _logger.LogInformation($"{cacheKey} updated from source.");
            }
            else
            {
                _logger.LogInformation($"{cacheKey} retrieved from cache.");
            }

            return encounters;
        }
    }
}