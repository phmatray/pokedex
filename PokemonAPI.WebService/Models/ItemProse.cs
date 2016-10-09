namespace PokemonAPI.WebService.Models
{
    public partial class ItemProse
    {
        public int ItemId { get; set; }
        public int LocalLanguageId { get; set; }
        public string ShortEffect { get; set; }
        public string Effect { get; set; }

        public virtual Items Item { get; set; }
        public virtual Languages LocalLanguage { get; set; }
    }
}
