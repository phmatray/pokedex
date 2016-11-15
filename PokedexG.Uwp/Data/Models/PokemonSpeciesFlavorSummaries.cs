using PokedexG.Uwp.Data.Models.Interfaces;

namespace PokedexG.Uwp.Data.Models
{
    public class EFPokemonSpeciesFlavorSummaries : IEFModel
    {
        public int PokemonSpeciesId { get; set; }
        public int LocalLanguageId { get; set; }
        public string FlavorSummary { get; set; }

        public virtual EFLanguages LocalLanguage { get; set; }
        public virtual EFPokemonSpecies PokemonSpecies { get; set; }
    }
}
