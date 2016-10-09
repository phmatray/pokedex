namespace PokedexG.Uwp.Models
{
    public class Pokedex
    {
        public int Id { get; set; }
        public string Identifier { get; set; }
        public string Region { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string VersionIdentifier { get; set; }
        public int GenerationId { get; set; }
        public string GenerationName { get; set; }
        public string LanguageName { get; set; }
    }
}