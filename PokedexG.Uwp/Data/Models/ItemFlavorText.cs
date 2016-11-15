using PokedexG.Uwp.Data.Models.Interfaces;

namespace PokedexG.Uwp.Data.Models
{
    public class EFItemFlavorText : IEFModel
    {
        public int ItemId { get; set; }
        public int VersionGroupId { get; set; }
        public int LanguageId { get; set; }
        public string FlavorText { get; set; }

        public virtual EFItems Item { get; set; }
        public virtual EFLanguages Language { get; set; }
        public virtual EFVersionGroups VersionGroup { get; set; }
    }
}
