namespace PokemonAPI.WebService.Models
{
    public partial class PokemonSpeciesFlavorText
    {
        public int SpeciesId { get; set; }
        public int VersionId { get; set; }
        public int LanguageId { get; set; }
        public string FlavorText { get; set; }

        public virtual Languages Language { get; set; }
        public virtual PokemonSpecies Species { get; set; }
        public virtual Versions Version { get; set; }
    }
}
