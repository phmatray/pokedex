// RECONSTRUCTION 2026-07-23 — l'original ouvrait pokedex.sqlite copié dans le dossier local
// WinRT puis le clonait en mémoire ; ici la base du dépôt (PokedexG.Uwp/Data/pokedex.sqlite,
// inchangée) est ouverte en lecture seule. Même contrat : une connexion statique partagée.
using System;
using System.IO;
using Microsoft.Data.Sqlite;

namespace PokedexG.Uwp.Services.VeekunServices
{
    public static class PokemonDbConnection
    {
        public static string DatabasePath { get; set; } = FindDatabase();

        private static SqliteConnection _dbConnection;
        public static SqliteConnection DbConnection
            => _dbConnection ?? (_dbConnection = OpenDatabase());

        private static SqliteConnection OpenDatabase()
        {
            var db = new SqliteConnection($"Data Source={DatabasePath};Mode=ReadOnly;Cache=Shared");
            db.Open();
            return db;
        }

        private static string FindDatabase()
        {
            var dir = new DirectoryInfo(AppContext.BaseDirectory);
            while (dir != null)
            {
                var candidate = Path.Combine(dir.FullName, "PokedexG.Uwp", "Data", Constants.DatabaseName);
                if (File.Exists(candidate))
                    return candidate;
                dir = dir.Parent;
            }
            throw new FileNotFoundException(
                $"{Constants.DatabaseName} introuvable en remontant depuis {AppContext.BaseDirectory} ; " +
                "définir PokemonDbConnection.DatabasePath explicitement.");
        }
    }
}
