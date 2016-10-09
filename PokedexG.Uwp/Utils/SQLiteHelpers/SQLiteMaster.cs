using SQLite.Net.Attributes;

namespace PokedexG.Uwp.Utils.SQLiteHelpers
{
    [Table("sqlite_master")]
    public class SQLiteMaster
    {
        [Column("type")]
        public string Type { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("tbl_name")]
        public string TblName { get; set; }

        [Column("rootpage")]
        public int Rootpage { get; set; }

        [Column("sql")]
        public string Sql { get; set; }
    }
}