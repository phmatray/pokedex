namespace PokemonAPI.WebService.Models
{
    public partial class ItemFlavorSummaries
    {
        public int ItemId { get; set; }
        public int LocalLanguageId { get; set; }
        public string FlavorSummary { get; set; }

        public virtual Items Item { get; set; }
        public virtual Languages LocalLanguage { get; set; }
    }
}
