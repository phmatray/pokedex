using System;
using System.Text;
using SQLite.Net;

namespace PokedexG.Uwp.Utils.SQLiteHelpers
{
    public static class SQLiteCsharpGenerator
    {
        public static string GenerateCsharpModels(this SQLiteConnection connection)
        {
            var sb = new StringBuilder();

            foreach (var tableName in connection.GetTableNames())
            {
                sb.Append(ToCsharpModel(connection, tableName));
                sb.AppendLine();
            }

            var model = sb.ToString();
            return model;
        }

        public static string GenerateCsharpRepositories(this SQLiteConnection connection)
        {
            var sb = new StringBuilder();

            foreach (var tableName in connection.GetTableNames())
            {
                sb.Append(ToCsharpRepository(tableName));
                sb.AppendLine();
            }

            var model = sb.ToString();
            return model;
        }

        private static StringBuilder ToCsharpModel(SQLiteConnection connection, string tableName)
        {
            var sb = new StringBuilder();
            var columnsInfos = connection.GetColumnsInfos(tableName);

            sb.AppendLine($"[Table(\"{tableName}\")]");
            sb.AppendLine($"public class {tableName.ToPascalCase()}Row");
            sb.Append("{");
            foreach (var c in columnsInfos)
            {
                string type = SQLiteTypeToCsharpType(c.Type, c.Notnull);

                sb.AppendLine();
                if (c.Pk == 1)
                    sb.AppendLine("    [PrimaryKey]");
                sb.AppendLine($"    [Column(\"{c.Name}\")]");
                sb.AppendLine($"    public {type} {c.Name.ToPascalCase()} {{ get; set; }}");
            }
            sb.AppendLine("}");
            return sb;
        }

        private static string SQLiteTypeToCsharpType(string type, int notnull)
        {
            if (type == "INTEGER")
                return notnull == 1 ? "int" : "int?";
            if (type == "SMALLINT")
                return notnull == 1 ? "short" : "short?";
            if (type == "BOOLEAN")
                return notnull == 1 ? "bool" : "bool?";
            if (type == "TEXT" || type.StartsWith("VARCHAR"))
                return "string";

            throw new ArgumentOutOfRangeException();
        }

        private static StringBuilder ToCsharpRepository(string tableName)
        {
            var sb = new StringBuilder();

            sb.AppendLine($"public partial class {tableName.ToPascalCase()}Repo" +
                          $" : RepositoryBase<{tableName.ToPascalCase()}Row>");
            sb.AppendLine("{");
            sb.AppendLine("}");

            return sb;
        }
    }
}