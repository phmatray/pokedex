namespace PokemonAPI.WebService.Models
{
    public partial class PokemonTypes
    {
        public int PokemonId { get; set; }
        public int TypeId { get; set; }
        public int Slot { get; set; }

        public virtual Pokemon Pokemon { get; set; }
        public virtual Types Type { get; set; }
    }
}
