using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public partial class PokemonSpeciesNames : IName, IGenus
    {
        public int PokemonSpeciesId { get; set; }
        public int LocalLanguageId { get; set; }
        public string Name { get; set; }
        public string Genus { get; set; }

        public virtual Languages LocalLanguage { get; set; }
        public virtual PokemonSpecies PokemonSpecies { get; set; }
    }
}
