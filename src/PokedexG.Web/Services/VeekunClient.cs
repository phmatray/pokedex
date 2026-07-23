// Équivalent web de la façade Veekun : mêmes lectures, servies par l'API statique générée
// depuis pokedex.sqlite (requêtes 2014 verbatim). Réponses mises en cache pour la session.
using System.Net.Http.Json;
using System.Text.Json;
using PokedexG.Uwp.Models;

namespace PokedexG.Web.Services;

public class VeekunClient
{
    private readonly HttpClient _http;
    private readonly Dictionary<string, object> _cache = new();

    public VeekunClient(HttpClient http) => _http = http;

    public Task<List<Pokemon>> GetPokemonsAsync() => GetAsync<List<Pokemon>>("data/pokemons.json");
    public Task<List<Pokedex>> GetPokedexesAsync() => GetAsync<List<Pokedex>>("data/pokedexes.json");
    public Task<List<TypeLite>> GetTypeLitesAsync() => GetAsync<List<TypeLite>>("data/types.json");
    public Task<List<TypeRelation>> GetTypeRelationsAsync() => GetAsync<List<TypeRelation>>("data/type-relations.json");
    public Task<List<Machine>> GetMachinesAsync() => GetAsync<List<Machine>>("data/machines.json");

    public Task<PokemonDetailsBundle> GetBundleAsync(int formId)
        => GetAsync<PokemonDetailsBundle>($"data/pokemon/{formId}.json");

    public Task<TypeBundle> GetTypeBundleAsync(int typeId)
        => GetAsync<TypeBundle>($"data/type/{typeId}.json");

    public Task<List<PokemonLite>> GetPokemonsByEgggroupAsync(int eggGroupId)
        => GetAsync<List<PokemonLite>>($"data/egggroup/{eggGroupId}.json");

    private async Task<T> GetAsync<T>(string path) where T : class
    {
        if (_cache.TryGetValue(path, out var hit))
            return (T)hit;

        var value = await _http.GetFromJsonAsync<T>(path)
                    ?? throw new JsonException($"Réponse vide pour {path}");
        _cache[path] = value;
        return value;
    }

    public class TypeBundle
    {
        public TypeLite? Type { get; set; }
        public List<PokemonLite> Pokemons { get; set; } = new();
    }
}
