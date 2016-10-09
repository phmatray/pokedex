namespace PokemonAPI.WebService.Models
{
    public partial class PokemonItems
    {
        public int PokemonId { get; set; }
        public int VersionId { get; set; }
        public int ItemId { get; set; }
        public int Rarity { get; set; }

        public virtual Items Item { get; set; }
        public virtual Pokemon Pokemon { get; set; }
        public virtual Versions Version { get; set; }
    }
}
