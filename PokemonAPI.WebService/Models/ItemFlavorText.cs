namespace PokemonAPI.WebService.Models
{
    public partial class ItemFlavorText
    {
        public int ItemId { get; set; }
        public int VersionGroupId { get; set; }
        public int LanguageId { get; set; }
        public string FlavorText { get; set; }

        public virtual Items Item { get; set; }
        public virtual Languages Language { get; set; }
        public virtual VersionGroups VersionGroup { get; set; }
    }
}
