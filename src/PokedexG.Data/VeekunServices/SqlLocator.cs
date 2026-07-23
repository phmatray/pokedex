// RECONSTRUCTION 2026-07-23 — l'original lisait les fichiers .txt via StorageFile (ms-appx) ;
// les mêmes fichiers sont ici des ressources embarquées. Mêmes méthodes, même cache.
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace PokedexG.Uwp.Services.VeekunServices
{
    internal static class SqlLocator
    {
        private static string _pokedexesQuery;
        private static string _pokemonMovesQuery;
        private static string _versionsQuery;
        private static string _pokemonsQuery;
        private static string _pokemonQuery;
        private static string _pokemonAbilitiesQuery;
        private static string _pokemonLocationsQuery;
        private static string _pokemonEgggroupsQuery;
        private static string _pokemonsByEgggroupQuery;
        private static string _pokemonsByTypeQuery;
        private static string _pokemonEvolutionsQuery;
        private static string _machinesQuery;
        private static string _typesQuery;
        private static string _typeQuery;
        private static string _typeRelationsQuery;

        internal static async Task<string> GetPokedexesQuery() =>
            _pokedexesQuery ?? (_pokedexesQuery = await ReadFile("get-pokedexes_clean.txt"));

        internal static async Task<string> GetPokemonMovesQuery() =>
            _pokemonMovesQuery ?? (_pokemonMovesQuery = await ReadFile("get-pokemon-moves_clean.txt"));

        internal static async Task<string> GetVersionsQuery() =>
            _versionsQuery ?? (_versionsQuery = await ReadFile("get-versions_clean.txt"));

        internal static async Task<string> GetPokemonsQuery() =>
            _pokemonsQuery ?? (_pokemonsQuery = await ReadFile("get-pokemons_clean.txt"));

        internal static async Task<string> GetPokemonQuery() =>
            _pokemonQuery ?? (_pokemonQuery = await ReadFile("get-pokemon_clean.txt"));

        internal static async Task<string> GetPokemonAbilitiesQuery() =>
            _pokemonAbilitiesQuery ?? (_pokemonAbilitiesQuery = await ReadFile("get-pokemon-abilities_clean.txt"));

        internal static async Task<string> GetPokemonLocationsQuery() =>
            _pokemonLocationsQuery ?? (_pokemonLocationsQuery = await ReadFile("get-pokemon-locations_clean.txt"));

        internal static async Task<string> GetPokemonEgggroupsQuery() =>
            _pokemonEgggroupsQuery ?? (_pokemonEgggroupsQuery = await ReadFile("get-pokemon-egggroups_clean.txt"));

        internal static async Task<string> GetPokemonsByEgggroupQuery() =>
            _pokemonsByEgggroupQuery ?? (_pokemonsByEgggroupQuery = await ReadFile("get-pokemons-byegggroup_clean.txt"));

        internal static async Task<string> GetPokemonsByTypeQuery() =>
            _pokemonsByTypeQuery ?? (_pokemonsByTypeQuery = await ReadFile("get-pokemons-bytype_clean.txt"));

        internal static async Task<string> GetPokemonEvolutionsQuery() =>
            _pokemonEvolutionsQuery ?? (_pokemonEvolutionsQuery = await ReadFile("get-pokemon-evolutions_clean.txt"));

        internal static async Task<string> GetMachinesQuery() =>
            _machinesQuery ?? (_machinesQuery = await ReadFile("get-machines_clean.txt"));

        internal static async Task<string> GetTypesQuery() =>
            _typesQuery ?? (_typesQuery = await ReadFile("get-types_clean.txt"));

        internal static async Task<string> GetTypeQuery() =>
            _typeQuery ?? (_typeQuery = await ReadFile("get-type_clean.txt"));

        internal static async Task<string> GetTypeRelationsQuery() =>
            _typeRelationsQuery ?? (_typeRelationsQuery = await ReadFile("get-type-relations_clean.txt"));

        private static Task<string> ReadFile(string fileName)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = assembly.GetManifestResourceNames()
                .Single(n => n.EndsWith(fileName, StringComparison.Ordinal));
            using var stream = assembly.GetManifestResourceStream(resourceName);
            using var reader = new StreamReader(stream);
            return Task.FromResult(reader.ReadToEnd());
        }
    }
}
