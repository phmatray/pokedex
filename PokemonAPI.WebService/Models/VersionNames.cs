using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public partial class VersionNames : IName
    {
        public int VersionId { get; set; }
        public int LocalLanguageId { get; set; }
        public string Name { get; set; }

        public virtual Languages LocalLanguage { get; set; }
        public virtual Versions Version { get; set; }
    }
}
