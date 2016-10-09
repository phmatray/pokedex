using System.Collections.Generic;
using SQLite.Net;
using SQLite.Net.Async;
using SQLite.Net.Platform.WinRT;

namespace PokedexG.Uwp.Utils.SQLiteHelpers
{
    public static class SQLiteAsyncConnectionHelper
    {
        public static List<T> QueryWithParameters<T>(this SQLiteAsyncConnection connection, string query,
            params SQLiteCommandParameter[] args)
        {
            return CreateCommand(connection, query, args).ExecuteQuery<T>();
        }

        public static SQLiteCommand CreateCommand(this SQLiteAsyncConnection connection,
            string cmdText, params SQLiteCommandParameter[] args)
        {
            var sqLiteCommand = connection.CreateCommand(cmdText);
            foreach (var parameter in args)
                sqLiteCommand.Bind(parameter.Name, parameter.Value);
            return sqLiteCommand;
        }

        public static SQLiteAsyncConnection CopyDbInMemory(this SQLiteAsyncConnection source)
        {
            var inMemoryDb = CreateDbInMemory();
            
            var api = new SQLiteApiWinRT();
            var dbBackupHandle = api.BackupInit(inMemoryDb.Handle, "main", source.Handle, "main");
            api.BackupStep(dbBackupHandle, -1);
            api.BackupFinish(dbBackupHandle);

            return inMemoryDb;
        }

        public static SQLiteAsyncConnection CreateDbInMemory()
        {
            return new SQLiteAsyncConnection(new SQLitePlatformWinRT(), ":memory:");
        }

        public static List<string> GetTableNames(this SQLiteAsyncConnection connection)
        {
            using (var db = connection)
            {
                return db
                    .Table<SQLiteMaster>()
                    .Where(x => x.Type == "table")
                    .Select(x => x.Name)
                    .ToList();
            }
        }

        public static List<ColumnInfos> GetColumnsInfos(this SQLiteConnection connection, string tableName)
        {
            using (var db = connection)
            {
                return db
                    .CreateCommand($"PRAGMA table_info({tableName});")
                    .ExecuteQuery<ColumnInfos>();
            }
        }
    }
}