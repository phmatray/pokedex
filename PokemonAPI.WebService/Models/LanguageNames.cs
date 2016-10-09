using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public partial class LanguageNames : IName
    {
        public int LanguageId { get; set; }
        public int LocalLanguageId { get; set; }
        public string Name { get; set; }

        public virtual Languages Language { get; set; }
        public virtual Languages LocalLanguage { get; set; }
    }
}
