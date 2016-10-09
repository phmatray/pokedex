namespace PokedexG.Uwp.Models
{
    public class PokemonLocation
    {
        public int PokemonId { get; set; }
        public int MinLevel { get; set; }
        public int MaxLevel { get; set; }
        public int Rarity { get; set; }
        public string RegionName { get; set; }
        public string LocationName { get; set; }
        public string EncounterMethod { get; set; }
        public string LanguageName { get; set; }
        public string VersionName { get; set; }
    }
}