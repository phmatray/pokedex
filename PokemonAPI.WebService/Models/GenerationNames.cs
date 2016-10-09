using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public partial class GenerationNames : IName
    {
        public int GenerationId { get; set; }
        public int LocalLanguageId { get; set; }
        public string Name { get; set; }

        public virtual Generations Generation { get; set; }
        public virtual Languages LocalLanguage { get; set; }
    }
}
