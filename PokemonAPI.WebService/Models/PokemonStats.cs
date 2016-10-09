namespace PokemonAPI.WebService.Models
{
    public partial class PokemonStats
    {
        public int PokemonId { get; set; }
        public int StatId { get; set; }
        public int BaseStat { get; set; }
        public int Effort { get; set; }

        public virtual Pokemon Pokemon { get; set; }
        public virtual Stats Stat { get; set; }
    }
}
