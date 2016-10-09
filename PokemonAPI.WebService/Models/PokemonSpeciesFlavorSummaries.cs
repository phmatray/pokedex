namespace PokemonAPI.WebService.Models
{
    public partial class PokemonSpeciesFlavorSummaries
    {
        public int PokemonSpeciesId { get; set; }
        public int LocalLanguageId { get; set; }
        public string FlavorSummary { get; set; }

        public virtual Languages LocalLanguage { get; set; }
        public virtual PokemonSpecies PokemonSpecies { get; set; }
    }
}
