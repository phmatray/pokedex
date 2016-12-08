using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PokedexG.Uwp.Models;
using PokedexG.Uwp.Utils.SQLiteHelpers;

namespace PokedexG.Uwp.Services.VeekunServices
{
    public static class Veekun
    {
        public static async Task<List<Move>> GetMovesAsync(int pokemonId,
            int moveMethodId = Constants.DefaultMoveMethodId,
            int versionGroupId = Constants.DefaultVersionGroupsId,
            int languageId = Constants.DefaultLanguageId)
        {
            return PokemonDbConnection.DbConnection // service
                .QueryWithParameters<Move>(await SqlLocator.GetPokemonMovesQuery(), // query
                    new SQLiteCommandParameter {Name = "@pokemonId", Value = pokemonId}, // query parameters
                    new SQLiteCommandParameter {Name = "@moveMethodId", Value = moveMethodId},
                    new SQLiteCommandParameter {Name = "@versionGroupId", Value = versionGroupId},
                    new SQLiteCommandParameter {Name = "@languageId", Value = languageId});
        }

        public static async Task<List<Pokedex>> GetPokedexesAsync(int languageId = Constants.DefaultLanguageId)
        {
            return PokemonDbConnection.DbConnection
                .QueryWithParameters<Pokedex>(await SqlLocator.GetPokedexesQuery(),
                    new SQLiteCommandParameter {Name = "@languageId", Value = languageId});
        }

        public static async Task<List<GameVersion>> GetVersionsAsync(int languageId = Constants.DefaultLanguageId)
        {
            return PokemonDbConnection.DbConnection
                .QueryWithParameters<GameVersion>(await SqlLocator.GetVersionsQuery(),
                    new SQLiteCommandParameter {Name = "@languageId", Value = languageId});
        }

        public static async Task<List<Pokemon>> GetPokemonsAsync(
            int versionId = Constants.DefaultVersionId,
            int languageId = Constants.DefaultLanguageId)
        {
            return PokemonDbConnection.DbConnection
                .QueryWithParameters<Pokemon>(await SqlLocator.GetPokemonsQuery(),
                    new SQLiteCommandParameter {Name = "@versionId", Value = versionId},
                    new SQLiteCommandParameter {Name = "@languageId", Value = languageId});
        }

        public static async Task<PokemonDetails> GetPokemonAsync(int formId,
            int versionId = Constants.DefaultVersionId,
            int languageId = Constants.DefaultLanguageId)
        {
            return PokemonDbConnection.DbConnection
                .QueryWithParameters<PokemonDetails>(await SqlLocator.GetPokemonQuery(),
                    new SQLiteCommandParameter {Name = "@versionId", Value = versionId},
                    new SQLiteCommandParameter {Name = "@formId", Value = formId},
                    new SQLiteCommandParameter {Name = "@languageId", Value = languageId})
                .FirstOrDefault();
        }

        public static async Task<List<PokemonAbility>> GetPokemonAbilitiesAsync(int pokemonId,
            int versionId = Constants.DefaultVersionId,
            int languageId = Constants.DefaultLanguageId)
        {
            return PokemonDbConnection.DbConnection
                .QueryWithParameters<PokemonAbility>(await SqlLocator.GetPokemonAbilitiesQuery(),
                    new SQLiteCommandParameter {Name = "@pokemonId", Value = pokemonId},
                    new SQLiteCommandParameter {Name = "@versionId", Value = versionId},
                    new SQLiteCommandParameter {Name = "@languageId", Value = languageId});
        }

        public static async Task<List<PokemonLocation>> GetPokemonLocationsAsync(int pokemonId,
            int versionId = Constants.DefaultVersionId,
            int languageId = Constants.DefaultLanguageId)
        {
            return PokemonDbConnection.DbConnection
                .QueryWithParameters<PokemonLocation>(await SqlLocator.GetPokemonLocationsQuery(),
                    new SQLiteCommandParameter {Name = "@pokemonId", Value = pokemonId},
                    new SQLiteCommandParameter {Name = "@versionId", Value = versionId},
                    new SQLiteCommandParameter {Name = "@languageId", Value = languageId});
        }

        public static async Task<List<PokemonEgggroup>> GetPokemonEgggroupsAsync(int pokemonId,
            int languageId = Constants.DefaultLanguageId)
        {
            return PokemonDbConnection.DbConnection
                .QueryWithParameters<PokemonEgggroup>(await SqlLocator.GetPokemonEgggroupsQuery(),
                    new SQLiteCommandParameter {Name = "@pokemonId", Value = pokemonId},
                    new SQLiteCommandParameter {Name = "@languageId", Value = languageId});
        }

        public static async Task<List<PokemonLite>> GetPokemonsByEgggroupAsync(int egggroupId,
            int languageId = Constants.DefaultLanguageId)
        {
            return PokemonDbConnection.DbConnection
                .QueryWithParameters<PokemonLite>(await SqlLocator.GetPokemonsByEgggroupQuery(),
                    new SQLiteCommandParameter {Name = "@egggroupId", Value = egggroupId},
                    new SQLiteCommandParameter { Name = "@languageId", Value = languageId });
        }

        public static async Task<List<PokemonLite>> GetPokemonsByTypeAsync(int typeId,
            int languageId = Constants.DefaultLanguageId)
        {
            return PokemonDbConnection.DbConnection
                .QueryWithParameters<PokemonLite>(await SqlLocator.GetPokemonsByTypeQuery(),
                    new SQLiteCommandParameter {Name = "@typeId", Value = typeId},
                    new SQLiteCommandParameter { Name = "@languageId", Value = languageId });
        }

        public static async Task<List<PokemonEvolution>> GetPokemonEvolutionsAsync(int specieId,
            int languageId = Constants.DefaultLanguageId,
            int generationId = Constants.DefaultGenerationId)
        {
            return PokemonDbConnection.DbConnection
                .QueryWithParameters<PokemonEvolution>(await SqlLocator.GetPokemonEvolutionsQuery(),
                    new SQLiteCommandParameter {Name = "@specieId", Value = specieId},
                    new SQLiteCommandParameter {Name = "@languageId", Value = languageId},
                    new SQLiteCommandParameter {Name = "@generation", Value = generationId});
        }

        public static async Task<List<Machine>> GetMachinesAsync(
            int versionGroupId = Constants.VersionGroupsIdXy,
            int languageId = Constants.DefaultLanguageId)
        {
            return PokemonDbConnection.DbConnection
                .QueryWithParameters<Machine>(await SqlLocator.GetMachinesQuery(),
                    new SQLiteCommandParameter {Name = "@versionGroupId", Value = versionGroupId},
                    new SQLiteCommandParameter {Name = "@languageId", Value = languageId});
        }

        public static async Task<List<TypeLite>> GetTypeLitesAsync(
            int languageId = Constants.DefaultLanguageId)
        {
            return PokemonDbConnection.DbConnection
                .QueryWithParameters<TypeLite>(await SqlLocator.GetTypesQuery(),
                    new SQLiteCommandParameter { Name = "@languageId", Value = languageId });
        }

        public static async Task<TypeLite> GetTypeAsync(int typeId,
            int languageId = Constants.DefaultLanguageId)
        {
            return PokemonDbConnection.DbConnection
                .QueryWithParameters<TypeLite>(await SqlLocator.GetTypeQuery(),
                    new SQLiteCommandParameter {Name = "@typeId", Value = typeId},
                    new SQLiteCommandParameter {Name = "@languageId", Value = languageId})
                .FirstOrDefault();
        }

        public static async Task<List<TypeRelation>> GetTypeRelationsAsync(
            int languageId = Constants.DefaultLanguageId)
        {
            return PokemonDbConnection.DbConnection
                .QueryWithParameters<TypeRelation>(await SqlLocator.GetTypeRelationsQuery(),
                    new SQLiteCommandParameter { Name = "@languageId", Value = languageId });
        }
    }
}