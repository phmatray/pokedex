using SQLite.Net.Attributes;

namespace PokedexG.Uwp.Utils.SQLiteHelpers
{
    public class ColumnInfos
    {
        [Column("cid")]
        public int Cid { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("type")]
        public string Type { get; set; }

        [Column("notnull")]
        public int Notnull { get; set; }

        [Column("dflt_value")]
        public string DfltValue { get; set; }

        [Column("pk")]
        public int Pk { get; set; }
    }
}