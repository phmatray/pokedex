using System.IO;
using Windows.Storage;
using PokedexG.Uwp.Utils.SQLiteHelpers;
using SQLite.Net;
using SQLite.Net.Platform.WinRT;

namespace PokedexG.Uwp.Services.VeekunServices
{
    public static class PokemonDbConnection
    {
        private static SQLiteConnection _dbConnection;
        public static SQLiteConnection DbConnection
            => _dbConnection ?? (_dbConnection = OpenDatabase());

        private static SQLiteConnection OpenDatabase()
        {
            const string fileName = Constants.DatabaseName;
            var localPath = Path.Combine(ApplicationData.Current.LocalFolder.Path, fileName);

            // connect to the database file and return it.
            var db = new SQLiteConnection(new SQLitePlatformWinRT(), localPath).CopyDbInMemory();
            return db;
        }
    }
}