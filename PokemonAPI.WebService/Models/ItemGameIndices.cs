namespace PokemonAPI.WebService.Models
{
    public partial class ItemGameIndices
    {
        public int ItemId { get; set; }
        public int GenerationId { get; set; }
        public int GameIndex { get; set; }

        public virtual Generations Generation { get; set; }
        public virtual Items Item { get; set; }
    }
}
