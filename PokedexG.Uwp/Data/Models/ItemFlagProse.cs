using PokedexG.Uwp.Data.Models.Interfaces;

namespace PokedexG.Uwp.Data.Models
{
    public class EFItemFlagProse : IEFModel
    {
        public int ItemFlagId { get; set; }
        public int LocalLanguageId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual EFItemFlags ItemFlag { get; set; }
        public virtual EFLanguages LocalLanguage { get; set; }
    }
}
