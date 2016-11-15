using PokedexG.Uwp.Data.Models.Interfaces;

namespace PokedexG.Uwp.Data.Models
{
    public class EFItemCategoryProse : IEFModel
    {
        public int ItemCategoryId { get; set; }
        public int LocalLanguageId { get; set; }
        public string Name { get; set; }

        public virtual EFItemCategories ItemCategory { get; set; }
        public virtual EFLanguages LocalLanguage { get; set; }
    }
}
