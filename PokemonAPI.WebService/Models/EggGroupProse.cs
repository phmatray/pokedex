using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public partial class EggGroupProse : IName
    {
        public int EggGroupId { get; set; }
        public int LocalLanguageId { get; set; }
        public string Name { get; set; }

        public virtual EggGroups EggGroup { get; set; }
        public virtual Languages LocalLanguage { get; set; }
    }
}
