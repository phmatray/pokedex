namespace PokedexG.Uwp.Models
{
    public class GameVersion
    {
        public int Id { get; set; }
        public string Identifier { get; set; }
        public string Name { get; set; }
        public int VersionGroupId { get; set; }
        public string VersionGroupIdentifier { get; set; }
        public int Generation { get; set; }
        public int LanguageId { get; set; }
        public string LanguageName { get; set; }
        public string RegionIdentifier { get; set; }
        public string RegionName { get; set; }
        public int PokedexId { get; set; }
        public string PokedexName { get; set; }
        public string PokedexDescription { get; set; }

        public override string ToString()
        {
            return $"Name: {Name}";
        }
    }
}