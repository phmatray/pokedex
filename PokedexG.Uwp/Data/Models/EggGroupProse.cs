using PokedexG.Uwp.Data.Models.Interfaces;

namespace PokedexG.Uwp.Data.Models
{
    public class EFEggGroupProse : IEFModel
    {
        public int EggGroupId { get; set; }
        public int LocalLanguageId { get; set; }
        public string Name { get; set; }

        public virtual EFEggGroups EggGroup { get; set; }
        public virtual EFLanguages LocalLanguage { get; set; }
    }
}
