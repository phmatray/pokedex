namespace PokemonAPI.WebService.Models
{
    public partial class ItemCategoryProse
    {
        public int ItemCategoryId { get; set; }
        public int LocalLanguageId { get; set; }
        public string Name { get; set; }

        public virtual ItemCategories ItemCategory { get; set; }
        public virtual Languages LocalLanguage { get; set; }
    }
}
