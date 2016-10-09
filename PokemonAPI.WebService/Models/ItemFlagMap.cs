namespace PokemonAPI.WebService.Models
{
    public partial class ItemFlagMap
    {
        public int ItemId { get; set; }
        public int ItemFlagId { get; set; }

        public virtual ItemFlags ItemFlag { get; set; }
        public virtual Items Item { get; set; }
    }
}
