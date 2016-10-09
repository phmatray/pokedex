namespace PokemonAPI.WebService.Models
{
    public partial class ItemNames
    {
        public int ItemId { get; set; }
        public int LocalLanguageId { get; set; }
        public string Name { get; set; }

        public virtual Items Item { get; set; }
        public virtual Languages LocalLanguage { get; set; }
    }
}
