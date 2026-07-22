// RECONSTRUCTION 2026-07-23 — remplace le mappeur de SQLite.Net-PCL (mort avec WinRT) par
// Microsoft.Data.Sqlite. Même contrat que l'original : chaque colonne du résultat est affectée
// à la propriété publique du même nom (les requêtes aliasent déjà chaque colonne) ; les colonnes
// dupliquées sont affectées dans l'ordre, la dernière gagne ; NULL → null.
using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.Data.Sqlite;

namespace PokedexG.Uwp.Utils.SQLiteHelpers
{
    public static class SQLiteHelper
    {
        public static List<T> QueryWithParameters<T>(this SqliteConnection connection, string query,
            params SQLiteCommandParameter[] args) where T : new()
        {
            using var command = connection.CreateCommand();
            command.CommandText = query;
            foreach (var parameter in args)
                command.Parameters.AddWithValue(parameter.Name, parameter.Value);

            var results = new List<T>();
            using var reader = command.ExecuteReader();

            var properties = new PropertyInfo[reader.FieldCount];
            for (var i = 0; i < reader.FieldCount; i++)
                properties[i] = typeof(T).GetProperty(reader.GetName(i),
                    BindingFlags.Public | BindingFlags.Instance);

            while (reader.Read())
            {
                var item = new T();
                for (var i = 0; i < reader.FieldCount; i++)
                {
                    var property = properties[i];
                    if (property == null || !property.CanWrite)
                        continue;

                    if (reader.IsDBNull(i))
                    {
                        property.SetValue(item, null);
                        continue;
                    }

                    var targetType = Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType;
                    var value = reader.GetValue(i);
                    property.SetValue(item, targetType == typeof(bool)
                        ? Convert.ToInt64(value) != 0
                        : Convert.ChangeType(value, targetType));
                }
                results.Add(item);
            }

            return results;
        }
    }
}
