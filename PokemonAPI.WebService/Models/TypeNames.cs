using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public partial class EFTypeNames : IEFModel
    {
        public int TypeId { get; set; }
        public int LocalLanguageId { get; set; }
        public string Name { get; set; }

        public virtual EFLanguages LocalLanguage { get; set; }
        public virtual EFTypes Type { get; set; }
    }
}
