using System;
using System.Threading.Tasks;
using Windows.Storage;

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
            _pokedexesQuery ??
            (_pokedexesQuery = await ReadFile(
                $"{Constants.SqlDirectory}/get-pokedexes_clean{Constants.SqlFileExtension}"));

        internal static async Task<string> GetPokemonMovesQuery() =>
            _pokemonMovesQuery ??
            (_pokemonMovesQuery = await ReadFile(
                $"{Constants.SqlDirectory}/get-pokemon-moves_clean{Constants.SqlFileExtension}"));

        internal static async Task<string> GetVersionsQuery() =>
            _versionsQuery ??
            (_versionsQuery = await ReadFile(
                $"{Constants.SqlDirectory}/get-versions_clean{Constants.SqlFileExtension}"));

        internal static async Task<string> GetPokemonsQuery() =>
            _pokemonsQuery ??
            (_pokemonsQuery = await ReadFile(
                $"{Constants.SqlDirectory}/get-pokemons_clean{Constants.SqlFileExtension}"));

        internal static async Task<string> GetPokemonQuery() =>
            _pokemonQuery ??
            (_pokemonQuery = await ReadFile(
                $"{Constants.SqlDirectory}/get-pokemon_clean{Constants.SqlFileExtension}"));

        internal static async Task<string> GetPokemonAbilitiesQuery() =>
            _pokemonAbilitiesQuery ??
            (_pokemonAbilitiesQuery = await ReadFile(
                $"{Constants.SqlDirectory}/get-pokemon-abilities_clean{Constants.SqlFileExtension}"));

        internal static async Task<string> GetPokemonLocationsQuery() =>
            _pokemonLocationsQuery ??
            (_pokemonLocationsQuery = await ReadFile(
                $"{Constants.SqlDirectory}/get-pokemon-locations_clean{Constants.SqlFileExtension}"));

        internal static async Task<string> GetPokemonEgggroupsQuery() =>
            _pokemonEgggroupsQuery ??
            (_pokemonEgggroupsQuery = await ReadFile(
                $"{Constants.SqlDirectory}/get-pokemon-egggroups_clean{Constants.SqlFileExtension}"));

        internal static async Task<string> GetPokemonsByEgggroupQuery() =>
            _pokemonsByEgggroupQuery ??
            (_pokemonsByEgggroupQuery = await ReadFile(
                $"{Constants.SqlDirectory}/get-pokemons-byegggroup_clean{Constants.SqlFileExtension}"));

        internal static async Task<string> GetPokemonsByTypeQuery() =>
            _pokemonsByTypeQuery ??
            (_pokemonsByTypeQuery = await ReadFile(
                $"{Constants.SqlDirectory}/get-pokemons-bytype_clean{Constants.SqlFileExtension}"));

        internal static async Task<string> GetPokemonEvolutionsQuery() =>
            _pokemonEvolutionsQuery ??
            (_pokemonEvolutionsQuery = await ReadFile(
                $"{Constants.SqlDirectory}/get-pokemon-evolutions_clean{Constants.SqlFileExtension}"));

        internal static async Task<string> GetMachinesQuery() =>
            _machinesQuery ?? 
            (_machinesQuery = await ReadFile(
                $"{Constants.SqlDirectory}/get-machines_clean{Constants.SqlFileExtension}"));

        internal static async Task<string> GetTypesQuery() =>
            _typesQuery ??
            (_typesQuery = await ReadFile(
                $"{Constants.SqlDirectory}/get-types_clean{Constants.SqlFileExtension}"));

        internal static async Task<string> GetTypeQuery() => 
            _typeQuery ??
            (_typeQuery = await ReadFile(
                $"{Constants.SqlDirectory}/get-type_clean{Constants.SqlFileExtension}"));

        internal static async Task<string> GetTypeRelationsQuery() => 
            _typeRelationsQuery ??
            (_typeRelationsQuery = await ReadFile(
                $"{Constants.SqlDirectory}/get-type-relations_clean{Constants.SqlFileExtension}"));

        private static async Task<string> ReadFile(string fileLocation)
        {
            var uri = new Uri(fileLocation);
            var file = await StorageFile.GetFileFromApplicationUriAsync(uri);
            return await FileIO.ReadTextAsync(file);
        }
    }
}