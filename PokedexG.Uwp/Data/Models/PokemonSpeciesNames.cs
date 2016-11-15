using PokedexG.Uwp.Data.Models.Interfaces;

namespace PokedexG.Uwp.Data.Models
{
    public class EFPokemonSpeciesNames : IEFModel
    {
        public int PokemonSpeciesId { get; set; }
        public int LocalLanguageId { get; set; }
        public string Name { get; set; }
        public string Genus { get; set; }

        public virtual EFLanguages LocalLanguage { get; set; }
        public virtual EFPokemonSpecies PokemonSpecies { get; set; }
    }
}
