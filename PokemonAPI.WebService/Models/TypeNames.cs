using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public partial class TypeNames : IName
    {
        public int TypeId { get; set; }
        public int LocalLanguageId { get; set; }
        public string Name { get; set; }

        public virtual Languages LocalLanguage { get; set; }
        public virtual Types Type { get; set; }
    }
}
