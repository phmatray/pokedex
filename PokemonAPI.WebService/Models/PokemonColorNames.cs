using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public partial class EFPokemonColorNames : IEFModel
    {
        public int PokemonColorId { get; set; }
        public int LocalLanguageId { get; set; }
        public string Name { get; set; }

        public virtual EFLanguages LocalLanguage { get; set; }
        public virtual EFPokemonColors PokemonColor { get; set; }
    }
}
