namespace PokemonAPI.WebService.Models
{
    public partial class PokemonSpeciesProse
    {
        public int PokemonSpeciesId { get; set; }
        public int LocalLanguageId { get; set; }
        public string FormDescription { get; set; }

        public virtual Languages LocalLanguage { get; set; }
        public virtual PokemonSpecies PokemonSpecies { get; set; }
    }
}
