using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PokedexG.Uwp.Models;
using PokedexG.Uwp.Utils.SQLiteHelpers;

namespace PokedexG.Uwp.Services.VeekunServices
{
    public static class Veekun
    {
        public static async Task<List<Move>> GetMoves(int pokemonId,
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

        public static async Task<List<Pokedex>> GetPokedexes(int languageId = Constants.DefaultLanguageId)
        {
            return PokemonDbConnection.DbConnection
                .QueryWithParameters<Pokedex>(await SqlLocator.GetPokedexesQuery(),
                    new SQLiteCommandParameter {Name = "@languageId", Value = languageId});
        }

        public static async Task<List<GameVersion>> GetVersions(int languageId = Constants.DefaultLanguageId)
        {
            return PokemonDbConnection.DbConnection
                .QueryWithParameters<GameVersion>(await SqlLocator.GetVersionsQuery(),
                    new SQLiteCommandParameter {Name = "@languageId", Value = languageId});
        }

        public static async Task<List<Pokemon>> GetPokemons(
            int versionId = Constants.DefaultVersionId,
            int languageId = Constants.DefaultLanguageId)
        {
            return PokemonDbConnection.DbConnection
                .QueryWithParameters<Pokemon>(await SqlLocator.GetPokemonsQuery(),
                    new SQLiteCommandParameter {Name = "@versionId", Value = versionId},
                    new SQLiteCommandParameter {Name = "@languageId", Value = languageId});
        }

        public static async Task<PokemonDetails> GetPokemon(int formId,
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

        public static async Task<List<PokemonAbility>> GetPokemonAbilities(int pokemonId,
            int versionId = Constants.DefaultVersionId,
            int languageId = Constants.DefaultLanguageId)
        {
            return PokemonDbConnection.DbConnection
                .QueryWithParameters<PokemonAbility>(await SqlLocator.GetPokemonAbilitiesQuery(),
                    new SQLiteCommandParameter {Name = "@pokemonId", Value = pokemonId},
                    new SQLiteCommandParameter {Name = "@versionId", Value = versionId},
                    new SQLiteCommandParameter {Name = "@languageId", Value = languageId});
        }

        public static async Task<List<PokemonLocation>> GetPokemonLocations(int pokemonId,
            int versionId = Constants.DefaultVersionId,
            int languageId = Constants.DefaultLanguageId)
        {
            return PokemonDbConnection.DbConnection
                .QueryWithParameters<PokemonLocation>(await SqlLocator.GetPokemonLocationsQuery(),
                    new SQLiteCommandParameter {Name = "@pokemonId", Value = pokemonId},
                    new SQLiteCommandParameter {Name = "@versionId", Value = versionId},
                    new SQLiteCommandParameter {Name = "@languageId", Value = languageId});
        }

        public static async Task<List<PokemonEgggroup>> GetPokemonEgggroups(int pokemonId,
            int languageId = Constants.DefaultLanguageId)
        {
            return PokemonDbConnection.DbConnection
                .QueryWithParameters<PokemonEgggroup>(await SqlLocator.GetPokemonEgggroupsQuery(),
                    new SQLiteCommandParameter {Name = "@pokemonId", Value = pokemonId},
                    new SQLiteCommandParameter {Name = "@languageId", Value = languageId});
        }

        public static async Task<List<PokemonLite>> GetPokemonsByEgggroup(int egggroupId,
            int languageId = Constants.DefaultLanguageId)
        {
            return PokemonDbConnection.DbConnection
                .QueryWithParameters<PokemonLite>(await SqlLocator.GetPokemonsByEgggroupQuery(),
                    new SQLiteCommandParameter {Name = "@egggroupId", Value = egggroupId},
                    new SQLiteCommandParameter { Name = "@languageId", Value = languageId });
        }

        public static async Task<List<PokemonLite>> GetPokemonsByType(int typeId,
            int languageId = Constants.DefaultLanguageId)
        {
            return PokemonDbConnection.DbConnection
                .QueryWithParameters<PokemonLite>(await SqlLocator.GetPokemonsByTypeQuery(),
                    new SQLiteCommandParameter {Name = "@typeId", Value = typeId},
                    new SQLiteCommandParameter { Name = "@languageId", Value = languageId });
        }

        public static async Task<List<PokemonEvolution>> GetPokemonEvolutions(int specieId,
            int languageId = Constants.DefaultLanguageId,
            int generationId = Constants.DefaultGenerationId)
        {
            return PokemonDbConnection.DbConnection
                .QueryWithParameters<PokemonEvolution>(await SqlLocator.GetPokemonEvolutionsQuery(),
                    new SQLiteCommandParameter {Name = "@specieId", Value = specieId},
                    new SQLiteCommandParameter {Name = "@languageId", Value = languageId},
                    new SQLiteCommandParameter {Name = "@generation", Value = generationId});
        }

        public static async Task<List<Machine>> GetMachines(
            int versionGroupId = Constants.VersionGroupsIdXy,
            int languageId = Constants.DefaultLanguageId)
        {
            return PokemonDbConnection.DbConnection
                .QueryWithParameters<Machine>(await SqlLocator.GetMachinesQuery(),
                    new SQLiteCommandParameter {Name = "@versionGroupId", Value = versionGroupId},
                    new SQLiteCommandParameter {Name = "@languageId", Value = languageId});
        }

        public static async Task<List<TypeLite>> GetTypeLites(
            int languageId = Constants.DefaultLanguageId)
        {
            return PokemonDbConnection.DbConnection
                .QueryWithParameters<TypeLite>(await SqlLocator.GetTypesQuery(),
                    new SQLiteCommandParameter { Name = "@languageId", Value = languageId });
        }

        public static async Task<TypeLite> GetType(int typeId,
            int languageId = Constants.DefaultLanguageId)
        {
            return PokemonDbConnection.DbConnection
                .QueryWithParameters<TypeLite>(await SqlLocator.GetTypeQuery(),
                    new SQLiteCommandParameter {Name = "@typeId", Value = typeId},
                    new SQLiteCommandParameter {Name = "@languageId", Value = languageId})
                .FirstOrDefault();
        }

        public static async Task<List<TypeRelation>> GetTypeRelations(
            int languageId = Constants.DefaultLanguageId)
        {
            return PokemonDbConnection.DbConnection
                .QueryWithParameters<TypeRelation>(await SqlLocator.GetTypeRelationsQuery(),
                    new SQLiteCommandParameter { Name = "@languageId", Value = languageId });
        }
    }
}