namespace PokemonAPI.WebService.Models
{
    public partial class ItemPocketNames
    {
        public int ItemPocketId { get; set; }
        public int LocalLanguageId { get; set; }
        public string Name { get; set; }

        public virtual ItemPockets ItemPocket { get; set; }
        public virtual Languages LocalLanguage { get; set; }
    }
}
